Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class GpApproval
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim EMPID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (229)
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
        pnlgphistory.Visible = False

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
                Gridgpapp.Visible = False
                Panel1.Visible = False
                BindGrid()
            Else
                GetHeadDept()
                'Gridgpapp.Visible = True
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
    Private Sub BindGrid()
        MyGlobal.Con_Str()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()

        Dim Command As New SqlCommand
        Command = New SqlCommand("gpApproval", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.Add("@stat", Session("dcode"))
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "HOdLEave")

        GridView2.DataSource = ds
        GridView2.DataBind()
        GridView2.Visible = True
        pnlsearch.Visible = True

        Gridgpapp.Visible = False
        Panel1.Visible = False

        con.Close()
    End Sub
    Private Sub BindGridhod(ByVal dept As String)
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        ' Command = New SqlCommand("SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,ltrim(rtrim(kpi_grade_result.total)) as total,kpi_grade_result.status, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON kpi_grade_result.empcode = empmaster.empcode WHERE (kpi_grade_result.yr = '" & ddlyr.SelectedValue & "') AND (kpi_grade_result.mnth = '" & ddlmon.SelectedValue & "') AND (empmaster.departmentcode in (" & dept & ") ) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled'", con)
        Command = New SqlCommand("SELECT staffgatepass.empcode,staffgatepass.passno,staffgatepass.purpose, staffgatepass.date1, staffgatepass.purpose, staffgatepass.outdate, staffgatepass.outtime, staffgatepass.intime, staffgatepass.gatepasstype, staffgatepass.status,staffgatepass.remarks, empmaster.empname,  empmaster.sectioncode, empmaster.departmentcode FROM staffgatepass CROSS JOIN empmaster inner join designation as designation on empmaster.designation = designation.designationname WHERE ((staffgatepass.status = 'scheduled')  OR (staffgatepass.status = 'SCHEDULED')) AND (staffgatepass.outdate >= convert(varchar(10),GETDATE(),101)) and (empmaster.departmentcode in (" & dept & ") )  and empmaster.empcode <> '" & Session("empcode") & "' and (dlevel < '4') and staffgatepass.empcode = empmaster.empcode order by passno desc", con)

        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "gpaPPROVALShod")

        Gridgpapp.DataSource = ds
        Gridgpapp.DataBind()

        Gridgpapp.Visible = True
        Panel1.Visible = True
        pnlsearch.Visible = False
        GridView2.Visible = False

        con.Close()
    End Sub
    Private Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        BindGrid()
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()

        GridView2.Visible = True
        pnlsearch.Visible = True
        Gridgpapp.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub Gridgpapp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gridgpapp.PageIndexChanging
        GetHeadDept()
        Gridgpapp.PageIndex = e.NewPageIndex
        Gridgpapp.DataBind()

        GridView2.Visible = False
        pnlsearch.Visible = False
        Panel1.Visible = True
        Gridgpapp.Visible = True
    End Sub

    Public Sub UpdateGpApproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To Gridgpapp.Rows.Count - 1
            Dim passno As String = Gridgpapp.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(Gridgpapp.Rows(i).FindControl("rbgpstatus"), RadioButtonList).SelectedValue
            ' Dim remark As String = DirectCast(Gridgpapp.Rows(i).FindControl("txtremarks"), TextBox).Text
            'Dim rbgpstatus As RadioButtonList = TryCast(Gridgpapp.FindControl("rbgpstatus"), RadioButtonList)
            UpdateApproval(passno, status, Session("empcode"))
        Next
        GetHeadDept()
        Gridgpapp.DataBind()
    End Sub

    Public Sub UpdateGpApproval2(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim passno As String = GridView2.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView2.Rows(i).FindControl("rbgpstatus"), RadioButtonList).SelectedValue
            ' Dim remark As String = DirectCast(Gridgpapp.Rows(i).FindControl("txtremarks"), TextBox).Text
            'Dim rbgpstatus As RadioButtonList = TryCast(Gridgpapp.FindControl("rbgpstatus"), RadioButtonList)
            UpdateApproval(passno, status, Session("empcode"))
        Next
        BindGrid()
        GridView2.DataBind()
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Fetch the customer id      
        Dim lb As LinkButton = TryCast(sender, LinkButton)
        Session("emp") = lb.Text
        EMPID = lb.Text

        GetTotPerGp(EMPID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbltotpergp.Text = dr("PersonalGP").ToString
            End If
        End If
        GetTotOffGp(EMPID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbltotOffGp.Text = dr("OfficialGP").ToString
            End If
        End If
        GetTotPending(EMPID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblgppending.Text = dr("PersonalGP").ToString
            End If
        End If
        'lbltxtempid.Text = empID
        GetEmpVehino(EMPID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbltxtempid.Text = dr("empname").ToString
                txtdept2.Text = dr("departmentcode").ToString + "-" + dr("sectioncode").ToString
                Label15.Text = dr("designation")
            End If
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        BindGridGpHistory(EMPID)
        pnlgphistory.Visible = True
        rathimpe.Show()
    End Sub
    Public Sub BindGridGpHistory(ByVal empid As String)
        GetGpHistory(empid, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            GrdGphistory.DataSource = dsdata.Tables(0).DefaultView
            'GrdGphistory.AllowPaging = True
            GrdGphistory.HeaderStyle.ForeColor = Drawing.Color.Red
            GrdGphistory.HeaderStyle.VerticalAlign = VerticalAlign.Middle
            GrdGphistory.DataBind()
        End If
    End Sub
    Private Sub GrdGphistory_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdGphistory.PageIndexChanging
        BindGridGpHistory(Session("emp"))
        GrdGphistory.PageIndex = e.NewPageIndex
        GrdGphistory.DataBind()
        pnlgphistory.Visible = True
        rathimpe.Show()
    End Sub

    Protected Sub sqlCvapproval_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlCvapproval.Selecting
        e.Command.Parameters(0).Value = _edept
    End Sub
    Public Sub UpdateCVApproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GrdCVApproval.Rows.Count - 1
            Dim passno As String = GrdCVApproval.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GrdCVApproval.Rows(i).FindControl("rbcvstatus"), RadioButtonList).SelectedValue
            'Dim rbgpstatus As RadioButtonList = TryCast(Gridgpapp.FindControl("rbgpstatus"), RadioButtonList)
            UpdatefncCVApproval(passno, status)
        Next
        GrdCVApproval.DataBind()
    End Sub
    Protected Sub searchgridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim str
        str = txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To Gridgpapp.Rows.Count - 1
                Dim lbn As String = DirectCast(Gridgpapp.Rows(n).FindControl("linkbutton2"), LinkButton).Text
                Dim empname As String = DirectCast(Gridgpapp.Rows(n).FindControl("label1"), Label).Text

                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    Gridgpapp.Rows(n).Focus()
                    Gridgpapp.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    Gridgpapp.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub

    Protected Sub searchgrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Dim str
        str = search.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView2.Rows.Count - 1
                Dim lbn As String = DirectCast(GridView2.Rows(n).FindControl("linkbutton2"), LinkButton).Text
                Dim empname As String = DirectCast(GridView2.Rows(n).FindControl("label1"), Label).Text
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