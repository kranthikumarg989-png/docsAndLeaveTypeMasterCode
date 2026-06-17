Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Reportappraisal
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
    End Sub
   
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue
        Dim dept, desig, sect, status, emp

        desig = Trim(ddldesigr.SelectedValue)
        emp = Trim(txtempidr.Text)
        sect = Trim(ddlsectrpt.SelectedValue)
        dept = ddldeptr.SelectedValue.Trim


        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)


        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim operation, sel

        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            sel = dept
            operation = "Dept"

        ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
            sel = sect
            operation = "sect"

        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            sel = desig
            operation = "desig"

        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            sel = emp
            operation = "emp"
        Else
            sel = emp
            operation = "all"
        End If

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Hrmis_Appraisal_GetEmpforReports", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@dept", sel)
        Command.Parameters.AddWithValue("@Operation", operation)
        Command.Parameters.AddWithValue("@fdate", fd)
        Command.Parameters.AddWithValue("@tdate", td)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empprob1")
        con.Close()
        GridView1.DataSource = ds
        GridView1.DataBind()
        GridView1.Visible = True
    End Sub
    Protected Sub Appraisal_view1(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("rptapprno") = e.CommandArgument
        Response.Redirect("AppraisalRptstaff.aspx")
    End Sub
    Function GetExplist(ByVal code As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        '  Command = New SqlCommand("SELECT * ,dateadd(mm,probation,dateofjoin) as probationends ,datediff(dd,getdate(), dateadd(mm,probation,dateofjoin)) as daydiff FROM designation, empmaster   WHERE empmaster.designation = designation.designationname and datediff(mm,getdate(), dateadd(mm,probation,dateofjoin)) <= 1 and datediff(mm,getdate(), dateadd(mm,probation,dateofjoin)) > 0  order by empcode", con)
        Command = New SqlCommand("hrmis_appraisal_alert", con)

        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empprob1")
        con.Close()
        Return ds
    End Function
End Class