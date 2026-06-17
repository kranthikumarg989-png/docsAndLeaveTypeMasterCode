Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class HODapprovalOT
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (66)
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
        'Label1.Text = headdept
        BindGrid(headdept)
        BindDdl(headdept)
        Session("otheaddept") = headdept

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
        Command = New SqlCommand("SELECT empmaster.empcode AS Expr1, otentry.empcode, otentry.shift, otentry.hrs, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode, otentry.dateapplied, otentry.OT, otentry.datecheck, otentry.ottype, empmaster.resigned, otentry.remark, otentry.status, otentry.RecNo FROM empmaster INNER JOIN otentry ON empmaster.empcode = otentry.empcode inner join designation as designation on empmaster.designation = designation.designationname  WHERE (otentry.OT = 'Y') AND (empmaster.resigned = 'N') AND (otentry.status = 'S') AND (empmaster.departmentcode in (" & dept & ")) and (dlevel < '4')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "OTApprovalHOD")

        HodOTapproval.DataSource = ds
        HodOTapproval.DataBind()
        HodOTapproval.Visible = True
        Panel2.Visible = True
        con.Close()

    End Sub
    Private Sub Bindddl(ByVal dept As String)
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT departmentcode FROM department WHERE departmentcode in (" & dept & ") ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "OTdeptHOD")

        ddldeptr.DataSource = ds
        ddldeptr.DataTextField = "departmentcode"
        ddldeptr.DataValueField = "departmentcode"
        ddldeptr.DataBind()
        con.Close()

    End Sub
    Private Sub Bindsectddl(ByVal dept As String)
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT sectioncode FROM sectionmaster WHERE departmentcode = '" & dept & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "OTdeptHOD")

        ddlsectrpt.DataSource = ds
        ddlsectrpt.DataTextField = "sectioncode"
        ddlsectrpt.DataValueField = "sectioncode"
        ddlsectrpt.DataBind()
        con.Close()

    End Sub
    Public Sub Hodapproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To HodOTapproval.Rows.Count - 1
            Dim RecNo As String = HodOTapproval.Rows(i).Cells(0).Text
            'Dim remark As String = HodOTapproval.Rows(i).Cells(12).Text
            Dim hrs As String = DirectCast(HodOTapproval.Rows(i).FindControl("TextBox4"), TextBox).Text
            Dim remark As String = DirectCast(HodOTapproval.Rows(i).FindControl("TextBox5"), TextBox).Text
            Dim status As String = DirectCast(HodOTapproval.Rows(i).FindControl("OTapprovalStat"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_approvalOTHod(Con, DAP, 2, "update otentry set status = '" & status & "', remark = '" & remark & "', hrs = '" & hrs & "', approvedby = '" & Session("empcode") & "' ,approveddate = getdate()  where RecNo = '" & RecNo & "'")
            MyGlobal.db_close()
        Next
        GetHeadDept()
        HodOTapproval.DataBind()

    End Sub
    Private Sub HodOTapproval_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles HodOTapproval.PageIndexChanging
        GetHeadDept()

        HodOTapproval.PageIndex = e.NewPageIndex
        HodOTapproval.DataBind()
        HodOTapproval.Visible = True

    End Sub

    Protected Sub searchgrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim str
        str = txtsearch2.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To HodOTapproval.Rows.Count - 1
                Dim lbn As String = HodOTapproval.Rows(n).Cells(3).Text
                Dim empname As String = HodOTapproval.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    HodOTapproval.Rows(n).Focus()
                    HodOTapproval.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    HodOTapproval.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If

    End Sub


    Protected Sub ddldeptr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldeptr.SelectedIndexChanged
        Bindsectddl(ddldeptr.SelectedValue)
    End Sub

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click

        Dim opn
        Dim Dept As String
        Dept = ddldeptr.SelectedValue.Trim
        Dim sect As String
        sect = ddlsectrpt.SelectedValue.Trim
        Dim ecode As String
        ecode = txtempidr.Text.Trim
        Dim desig As String
        Dim sqlstr
        'Dim lvl As String
        'lvl = ddllevel.SelectedValue.Trim
        Dim myval

        If rdoptions.SelectedValue = "Dept" And ddldeptr.SelectedValue = "-1" Then
            lblmsg.Text = "Please select Department"
            Exit Sub

        ElseIf rdoptions.SelectedValue = "Sect" And (ddlsectrpt.SelectedValue = "-1" Or ddldeptr.SelectedValue = "-1") Then
            lblmsg.Text = "Please select Department & Section"
            Exit Sub

        ElseIf rdoptions.SelectedValue = "Emp" And txtempidr.Text = "" Then
            lblmsg.Text = "Please Keyin empcode"
            Exit Sub
     
        End If

        If rdoptions.SelectedValue = "Dept" And ddldeptr.SelectedValue <> "-1" Then
            myval = ddldeptr.SelectedValue.Trim
            sqlstr = "SELECT empmaster.empcode AS Expr1, otentry.empcode, otentry.shift, otentry.hrs, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode, otentry.dateapplied, otentry.OT, otentry.datecheck, otentry.ottype, empmaster.resigned, otentry.remark, otentry.status, otentry.RecNo FROM empmaster INNER JOIN otentry ON empmaster.empcode = otentry.empcode inner join designation as designation on empmaster.designation = designation.designationname  WHERE (otentry.OT = 'Y') AND (empmaster.resigned = 'N') AND (otentry.status = 'S') AND (empmaster.departmentcode = '" & Dept & "') and (dlevel < '4')"

        ElseIf rdoptions.SelectedValue = "Sect" And ddlsectrpt.SelectedValue <> "-1" Then
            myval = ddldeptr.SelectedValue.Trim
            sqlstr = "SELECT empmaster.empcode AS Expr1, otentry.empcode, otentry.shift, otentry.hrs, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode, otentry.dateapplied, otentry.OT, otentry.datecheck, otentry.ottype, empmaster.resigned, otentry.remark, otentry.status, otentry.RecNo FROM empmaster INNER JOIN otentry ON empmaster.empcode = otentry.empcode inner join designation as designation on empmaster.designation = designation.designationname  WHERE (otentry.OT = 'Y') AND (empmaster.resigned = 'N') AND (otentry.status = 'S') AND (empmaster.sectioncode = '" & sect & "') and (dlevel < '4')"

        ElseIf rdoptions.SelectedValue = "Emp" And txtempidr.Text <> "" Then
            myval = txtempidr.Text.Trim
            sqlstr = "SELECT empmaster.empcode AS Expr1, otentry.empcode, otentry.shift, otentry.hrs, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode, otentry.dateapplied, otentry.OT, otentry.datecheck, otentry.ottype, empmaster.resigned, otentry.remark, otentry.status, otentry.RecNo FROM empmaster INNER JOIN otentry ON empmaster.empcode = otentry.empcode inner join designation as designation on empmaster.designation = designation.designationname  WHERE (otentry.OT = 'Y') AND (empmaster.resigned = 'N') AND (otentry.status = 'S') AND (empmaster.departmentcode in (" & Session("otheaddept") & ")) and (dlevel < '4') and empmaster.empcode = '" & txtempidr.Text & "'"

        ElseIf rdoptions.SelectedValue = "all" Then
            sqlstr = "SELECT empmaster.empcode AS Expr1, otentry.empcode, otentry.shift, otentry.hrs, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode, otentry.dateapplied, otentry.OT, otentry.datecheck, otentry.ottype, empmaster.resigned, otentry.remark, otentry.status, otentry.RecNo FROM empmaster INNER JOIN otentry ON empmaster.empcode = otentry.empcode inner join designation as designation on empmaster.designation = designation.designationname  WHERE (otentry.OT = 'Y') AND (empmaster.resigned = 'N') AND (otentry.status = 'S') AND (empmaster.departmentcode in (" & Session("otheaddept") & ")) and (dlevel < '4')"

        End If

        'Bind Grid view

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqlstr, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "OTApprovalHOD")

        HodOTapproval.DataSource = ds
        HodOTapproval.DataBind()
        HodOTapproval.Visible = True
        Panel2.Visible = True
        con.Close()

    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = True
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            txtempidr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            txtempidr.Enabled = False
        End If
        Panel2.Visible = False

    End Sub

End Class