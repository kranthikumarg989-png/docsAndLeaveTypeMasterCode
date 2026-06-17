Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class KPI_HOd_approve
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (232)
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
            Panel2.Visible = False
            Panel3.Visible = False
        End If

    End Sub
    Public Sub UpdateKPIApproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rb1"), RadioButtonList).SelectedValue
            Dim total As String = DirectCast(GridView1.Rows(i).FindControl("txttotal"), TextBox).Text
            Dim grade As String = DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text
            Dim EMP = GridView1.Rows(i).Cells(1).Text
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Dim DS1 As DataSet
            DS = Open_KPIGrade(Con, DAP, 2, "update kpi_grade_result set status = '" & status & "' ,total = '" & total & "' ,grade = '" & grade & "'  where slno = '" & slno & "'")
            '       DS1 = Open_SubKPI(Con, DAP, 2, "update kpi_DAILYUPDATE set status = '" & status & "' where KPI_MONTH = '" & ddlmon.SelectedValue.Trim & "' AND KPI_YEAR = '" & ddlyr.SelectedValue.Trim & "' AND EMPLOYEE_CODE = '" & EMP & "'")

        Next
        GetHeadDept()

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        ' GetHeadDept()
        getdesigname(Session("_edesig"))
        Dim dcode
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                dcode = dr("desigcode").ToString.Trim
                Session("dcode") = dcode
            End If
        End If

        ' If Not IsPostBack Then
        If dcode = "EA" Or dcode = "MD" Or dcode = "GM" Or dcode = "DGM" Or dcode = "PL Man" Or dcode = "SGM" Or dcode = "SPM" Then
            GridView1.Visible = False

            Panel2.Visible = False
            Panel3.Visible = True


            BindGrid()
        Else
            GetHeadDept()
            'Gridgpapp.Visible = True
        End If
        ' End If
    End Sub
    Private Sub GetHeadDept()
        'Dim dsh As DataSet
        'Dim drh As DataRow
        'Dim headdept, mydept
        'Dim hoddepts
        'dsh = GetHeadAssignment()
        'If dsh.Tables(0).Rows.Count > 0 Then
        '    drh = dsh.Tables(0).Rows(0)
        '    headdept = drh("ldepartmentcode").ToString
        'Else
        '    headdept = Session("_edept")
        'End If
        'Label1.Text = headdept
        'BindGrid(headdept)

        '''17082011

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
            headdept = Session("_edept")
        End If
        Label1.Text = headdept
        BindGrid(headdept)

    End Sub


    Function GetHeadAssignment() As DataSet

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
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,ltrim(rtrim(kpi_grade_result.total)) as total,kpi_grade_result.status, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON  kpi_grade_result.empcode = empmaster.empcode inner join designation as designation on empmaster.designation = designation.designationname WHERE (kpi_grade_result.yr = '" & ddlyr.SelectedValue & "') AND (kpi_grade_result.mnth = '" & ddlmon.SelectedValue & "') AND (empmaster.departmentcode in (" & dept & ") ) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled' and dlevel < '4' and empmaster.empcode <> '" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")

        GridView1.DataSource = ds
        GridView1.DataBind()
        GridView1.Visible = True

        Panel2.Visible = True
        Panel3.Visible = False


        con.Close()
    End Sub
    Private Sub GRidVIEW2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging

        BindGrid()
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
        GridView2.Visible = True

    End Sub
    Protected Sub calculateTotal2(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As TextBox
        Dim totVal As Double
        Dim rno
        Dim grade

        For i As Integer = 0 To GridView2.Rows.Count - 1
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            Dim slno As String = GridView2.Rows(i).Cells(0).Text
            total = DirectCast(GridView2.Rows(i).FindControl("txttotal"), TextBox)
            grade = DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text

            If total.Text <> "" Then
                totVal = Double.Parse(total.Text.Trim)
                If totVal >= 100 Then
                    DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text = "A"
                ElseIf totVal <= 0 Then
                    DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text = "E"
                ElseIf totVal > 0 And totVal < 51 Then
                    DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text = "E"
                ElseIf totVal > 50 And totVal < 61 Then
                    DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text = "D"
                ElseIf totVal > 60 And totVal < 71 Then
                    DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text = "C"
                ElseIf totVal > 70 And totVal < 86 Then
                    DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text = "B"
                ElseIf totVal > 85 And totVal < 101 Then
                    DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text = "A"
                End If
            End If
        Next
    End Sub
    Public Sub UpdateKPIApproval2(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim slno As String = GridView2.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView2.Rows(i).FindControl("rb1"), RadioButtonList).SelectedValue
            Dim total As String = DirectCast(GridView2.Rows(i).FindControl("txttotal"), TextBox).Text
            Dim grade As String = DirectCast(GridView2.Rows(i).FindControl("lblgrade"), Label).Text
            Dim EMP = GridView2.Rows(i).Cells(1).Text
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Dim DS1 As DataSet
            DS = Open_KPIGrade(Con, DAP, 2, "update kpi_grade_result set status = '" & status & "' ,total = '" & total & "' ,grade = '" & grade & "'  where slno = '" & slno & "'")
            '       DS1 = Open_SubKPI(Con, DAP, 2, "update kpi_DAILYUPDATE set status = '" & status & "' where KPI_MONTH = '" & ddlmon.SelectedValue.Trim & "' AND KPI_YEAR = '" & ddlyr.SelectedValue.Trim & "' AND EMPLOYEE_CODE = '" & EMP & "'")

        Next
        BindGrid()

    End Sub
    Private Sub BindGrid()
        MyGlobal.Con_Str()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()

        Dim Command As New SqlCommand
        Command = New SqlCommand("KPIApproval", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.Add("@stat", Session("dcode"))
        Command.Parameters.Add("@mon", ddlmon.SelectedValue.Trim)
        Command.Parameters.Add("@yr", ddlyr.SelectedValue.Trim)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "HOdLEave")

        GridView2.DataSource = ds
        GridView2.DataBind()
        GridView2.Visible = True

        GridView1.Visible = False


        Panel2.Visible = False
        Panel3.Visible = True

        con.Close()
    End Sub
    Protected Sub calculateTotal(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As TextBox
        Dim totVal As Double

        Dim rno
        Dim grade



        For i As Integer = 0 To GridView1.Rows.Count - 1
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            total = DirectCast(GridView1.Rows(i).FindControl("txttotal"), TextBox)
            grade = DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text



            If total.Text <> "" Then

                totVal = Double.Parse(total.Text.Trim)

                If totVal >= 100 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "A"
                ElseIf totVal <= 0 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "E"
                ElseIf totVal > 0 And totVal < 51 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "E"
                ElseIf totVal > 50 And totVal < 61 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "D"
                ElseIf totVal > 60 And totVal < 71 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "C"
                ElseIf totVal > 70 And totVal < 86 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "B"
                ElseIf totVal > 85 And totVal < 101 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "A"
                End If

            End If

        Next
    End Sub
    Private Sub GRidVIEW1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GetHeadDept()

        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
        GridView1.Visible = True

    End Sub

    Protected Sub searchgrid1(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim str
        str = txtsearch1.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView1.Rows.Count - 1
                Dim lbn As String = GridView1.Rows(n).Cells(1).Text
                Dim empname As String = GridView1.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridView1.Rows(n).Focus()
                    GridView1.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridView1.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If

    End Sub
    Protected Sub searchgrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim str
        str = txtsearch2.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView2.Rows.Count - 1
                Dim lbn As String = GridView2.Rows(n).Cells(1).Text
                Dim empname As String = GridView2.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridView2.Rows(n).Focus()
                    GridView2.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridView2.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If

    End Sub


End Class