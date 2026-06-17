Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class man_recruitmentrequistionHR
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        lbldate.Text = Date.Now.ToShortDateString
        sqltext = "select max(requisitionno)+1as maxno from man_request"
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If IsPostBack = False Then
                reqno.Text = rdr("maxno")
            End If
        End While
        rdr.Close()
        If IsPostBack = False Then
            SqlDataSource6.InsertParameters.Add("aplno", reqno.Text)
            SqlDataSource6.Insert()
        End If
    End Sub
    Protected Sub ddldept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldept.SelectedIndexChanged
        If ddldept.SelectedItem.Value <> "" Then
            ddlsect.Items.Clear()
            sqltext = "select sectioncode + '--' + sectionname from sectionmaster where departmentcode='" & Val(ddldept.Text) & "'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                ddlsect.Items.Add(rdr(0))
            End While
            rdr.Close()
        End If
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        sqltext = "select*from empmaster where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            empname.Text = rdr("empname")
            department.Text = rdr("departmentcode")
            section.Text = rdr("sectioncode")
        End While
        rdr.Close()
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If IsNumeric(noofvacancies.Text) = True Then
        Else
            MessageBox("Enter Numbers only!")
            noofvacancies.Text = ""
            noofvacancies.Focus()
            Exit Sub
        End If
        sqltext = "update man_request set requisitionno='" & (reqno.Text) & "',requestdate='" & (lbldate.Text) & "',requestorempcode='" & (empcode.Text) & "',designation='" & (ddldesig.Text) & "',vacancies='" & (noofvacancies.Text) & "',postvacant='" & (vacantpost.Text) & "',equalification='" & (qualific.Text) & "',jobdescription='" & (jobdesc.Text) & "',pqualification='" & (professional.Text) & "',experiencedetails='" & (experience.Text) & "',otherskills='" & (otherskills.Text) & "',requireddate='" & (txtdate.Text) & "',responsibilites='" & (response.Text) & "',gender='" & (gender.Text) & "',status='S' where requisitionno='" & (reqno.Text) & "'"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        MessageBox("Record saved")
        Server.Transfer("recruitmentstatus.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class