Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class HODAPPROVAL1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (43)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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


        If Not IsPostBack Then
            If dcode = "EA" Or UCase(dcode) = "DIRECTOR" Or dcode = "MD" Or dcode = "GM" Or dcode = "DGM" Or dcode = "PL Man" Or dcode = "SGM" Or dcode = "SPM" Then
                GridView1.Visible = False
                Panel1.Visible = False
                BindGrid()
            Else
                GetHeadDept()
                GridView1.Visible = True
                Panel1.Visible = True
            End If
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
        '  Label1.Text = headdept
        BindGridhod(headdept)

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
    Private Sub BindGridhod(ByVal dept As String)
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        ' Command = New SqlCommand("SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,ltrim(rtrim(kpi_grade_result.total)) as total,kpi_grade_result.status, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON kpi_grade_result.empcode = empmaster.empcode WHERE (kpi_grade_result.yr = '" & ddlyr.SelectedValue & "') AND (kpi_grade_result.mnth = '" & ddlmon.SelectedValue & "') AND (empmaster.departmentcode in (" & dept & ") ) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled'", con)
        Command = New SqlCommand("SELECT clinicstaffgatepass.passno, clinicstaffgatepass.empcode, clinicstaffgatepass.department, clinicstaffgatepass.category, clinicstaffgatepass.sect, clinicstaffgatepass.status, clinicstaffgatepass.dateapplied, clinicstaffgatepass.etimeout, clinicstaffgatepass.etimein, clinicstaffgatepass.sickness, empmaster.empname  FROM clinicstaffgatepass CROSS JOIN empmaster inner join designation as designation on empmaster.designation = designation.designationname  WHERE (empmaster.departmentcode in (" & dept & ") ) AND (clinicstaffgatepass.status = 'S') and empmaster.empcode <> '" & Session("empcode") & "' and (dlevel < '4') AND  clinicstaffgatepass.empcode = empmaster.empcode ORDER BY clinicstaffgatepass.passno DESC", con)

        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "CPaPPROVALShod")

        GridView1.DataSource = ds
        GridView1.DataBind()
        GridView1.Visible = True
        Panel1.Visible = True

        GridView2.Visible = False
        Panel2.Visible = False

        con.Close()
    End Sub
    Private Sub BindGrid()
        MyGlobal.Con_Str()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()

        Dim Command As New SqlCommand
        Command = New SqlCommand("CpApproval", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.Add("@stat", Session("dcode"))
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "HOdLEave")

        GridView2.DataSource = ds
        GridView2.DataBind()
        GridView2.Visible = True
        Panel2.Visible = True

        con.Close()
    End Sub
    Private Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        BindGrid()
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
        GridView2.Visible = True
        Panel2.Visible = True

        GridView1.Visible = False
        Panel1.Visible = False
    End Sub
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GetHeadDept()
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
        GridView1.Visible = True
        Panel1.Visible = True

        GridView2.Visible = False
        Panel2.Visible = False
    End Sub
    Public Sub UpdateclinicApproval(ByVal sender As Object, ByVal e As EventArgs)

        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim passno As String = GridView1.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If status = "A" Then
                DS = Open_clinic(Con, DAP, 2, "update clinicstaffgatepass set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approveddate = getdate()  where passno = '" & passno & "'")
            End If
            MyGlobal.db_close()
        Next
        GetHeadDept()
        GridView1.DataBind()
    End Sub

    Public Sub UpdateclinicApproval2(ByVal sender As Object, ByVal e As EventArgs)

        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim passno As String = GridView2.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView2.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If status = "A" Then
                DS = Open_clinic(Con, DAP, 2, "update clinicstaffgatepass set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approveddate = getdate()  where passno = '" & passno & "'")
            End If
            MyGlobal.db_close()
        Next
        BindGrid()
        GridView2.DataBind()
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