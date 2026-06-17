Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class HODApproveSUbKPI
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (77)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If


        If Not IsPostBack Then
            GetHeadDept()
        End If
      
    End Sub

    Private Sub GetHeadDept()
        Dim dsh As DataSet
        Dim drh As DataRow
        Dim headdept, mydept

        dsh = GetHeadAssignment()
        If dsh.Tables(0).Rows.Count > 0 Then
            drh = dsh.Tables(0).Rows(0)
            mydept = drh("ldepartmentcode").ToString
            Dim hoddepts = mydept.split(",")
            For i As Integer = 0 To hoddepts.Length - 1
                headdept = headdept & "'" & hoddepts(i) & "',"
            Next
            headdept = headdept.remove(headdept.length - 1, 1)
        Else
            headdept = "'" & Session("_edept") & "'"
        End If
        ' Label1.Text = headdept
        BindGrid(headdept)

    End Sub
    Function GetHeadAssignment() As DataSet

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from head_assignment_emanagement where empcode ='" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Private Sub BindGrid(ByVal dept As String)
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()

        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT KPI_SubSetting.MajorKPI_Details, KPI_SubSetting.Sub_KPINO, KPI_SubSetting.SubKPI_Details, ltrim(rtrim(KPI_SubSetting.q4)) as q4, ltrim(rtrim(KPI_SubSetting.q3)) as q3, ltrim(rtrim(KPI_SubSetting.q2)) as q2, ltrim(rtrim(KPI_SubSetting.q1)) as q1, KPI_SubSetting.uom, KPI_SubSetting.curent, KPI_SubSetting.target, Ltrim(Rtrim(KPI_SubSetting.UpdBasis)) as updbasis, KPI_SubSetting.Status, KPI_SubSetting.Employee_Code, empmaster.empname ,empmaster.departmentcode, empmaster.sectioncode FROM KPI_SubSetting INNER JOIN empmaster ON KPI_SubSetting.Employee_Code = empmaster.empcode WHERE (KPI_SubSetting.Status = 'S') AND (KPI_SubSetting.Department_Code in (" & dept & "))", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor2")

        GridView1.DataSource = ds
        GridView1.DataBind()
        GridView1.Visible = True
        con.Close()
    End Sub
    Private Sub GRidVIEW1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GetHeadDept()

        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
        GridView1.Visible = True

    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim q1 As CheckBox = TryCast(e.Row.FindControl("q1"), CheckBox)
            Dim q2 As CheckBox = TryCast(e.Row.FindControl("q1"), CheckBox)
            Dim q3 As CheckBox = TryCast(e.Row.FindControl("q1"), CheckBox)
            Dim q4 As CheckBox = TryCast(e.Row.FindControl("q1"), CheckBox)

            If q1.Text = "true" Then
                q1.Checked = True
            ElseIf q1.Text = "false" Then
                q1.Checked = False
            End If

            If q2.Text = "true" Then
                q2.Checked = True
            ElseIf q2.Text = "false" Then
                q2.Checked = False
            End If

            If q3.Text = "true" Then
                q3.Checked = True
            ElseIf q3.Text = "false" Then
                q3.Checked = False
            End If

            If q4.Text = "true" Then
                q4.Checked = True
            ElseIf q4.Text = "false" Then
                q4.Checked = False
            End If


            'If status = "S" Then
            '    Button.Visible = True
            '    Label.Visible = False
            '    button2.Visible = True
            'Else
            '    Label.Visible = True
            '    Button.Visible = False
            '    button2.Visible = False
            'End If
            'If status = "S" Then
            '    e.Row.Cells(7).ForeColor = Drawing.Color.Yellow
            '    ' e.Row.Cells(7).Text = "Scheduled"
            'ElseIf status = "A" Then
            '    e.Row.Cells(7).ForeColor = Drawing.Color.Green
            'ElseIf status = "R" Then
            '    e.Row.Cells(7).ForeColor = Drawing.Color.Red
            'End If
        End If
    End Sub
    Public Sub UpdateLeaveApproval(ByVal sender As Object, ByVal e As EventArgs)
      
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim rno As String = GridView1.Rows(i).Cells(0).Text
            Dim q1 As CheckBox = DirectCast(GridView1.Rows(i).FindControl("Q1"), CheckBox)
            Dim q2 As CheckBox = DirectCast(GridView1.Rows(i).FindControl("Q2"), CheckBox)
            Dim q3 As CheckBox = DirectCast(GridView1.Rows(i).FindControl("Q3"), CheckBox)
            Dim q4 As CheckBox = DirectCast(GridView1.Rows(i).FindControl("Q4"), CheckBox)
            Dim upd As String = DirectCast(GridView1.Rows(i).FindControl("rbupd"), RadioButtonList).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rbstatus"), RadioButtonList).Text

            Dim A, B, C, D

            If q1.Checked = True Then
                A = "True"
            Else
                A = "False"
            End If

            If q2.Checked = True Then
                B = "True"
            Else
                B = "False"
            End If

            If q3.Checked = True Then
                C = "True"
            Else
                C = "False"
            End If

            If q4.Checked = True Then
                D = "True"
            Else
                D = "False"
            End If

            If q1.Checked = False And q2.Checked = False And q3.Checked = False And q4.Checked = False Then
                Messagebox("Please Select atleast one quarter")
                Exit Sub
            End If

            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_SubKPI(Con, DAP, 2, "update kpi_subsetting set status = '" & status & "' ,updbasis = '" & upd & "' ,Q1 = '" & A & "',q2 = '" & B & "',Q3 = '" & C & "',Q4 = '" & D & "'  where sub_kpino = '" & rno & "'")
       
        Next
        GetHeadDept()
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub searchgrid1(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim str
        str = txtsearch1.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView1.Rows.Count - 1
                Dim lbn As String = GridView1.Rows(n).Cells(1).Text
                Dim empname As String = GridView1.Rows(n).Cells(2).Text
                Dim dept As String = GridView1.Rows(n).Cells(3).Text
                Dim sect As String = GridView1.Rows(n).Cells(4).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Or dept.ToString.ToLower.Contains(str.ToString.ToLower) = True Or sect.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridView1.Rows(n).Focus()
                    GridView1.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridView1.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If

    End Sub


End Class