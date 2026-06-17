Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class man_recruitmentrequistionRHR
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
        datetoday.Text = Date.Now.ToShortDateString
        sqltext = "select max(requisitionno)+1as maxno from man_replace"
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If IsPostBack = False Then
                reqno.Text = rdr("maxno")
            End If
        End While
        rdr.Close()
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        If IsNumeric(empcode.Text) Then
            sqltext = "select empname,sectioncode,departmentcode from empmaster where empcode='" & (empcode.Text) & "' and resigned='N'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read()
                name.Text = rdr(0)
                section.Text = rdr(1)
                dept.Text = rdr(2)
            End While
            rdr.Close()
            empcodepre.Focus()
        End If
    End Sub
    Protected Sub empcodepre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcodepre.TextChanged
        If IsNumeric(empcodepre.Text) Then
            sqltext = "select empname,sectioncode,departmentcode,designation from empmaster where empcode='" & (empcodepre.Text) & "' and resigned='Y'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read()
                namepre.Text = rdr(0)
                sectionpre.Text = rdr(1)
                deptpre.Text = rdr(2)
                desigpre.Text = rdr(3)
                ddldesig.Text = desigpre.Text
                reasonpre.Focus()
            End While
            rdr.Close()
        End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        sqltext = "insert into man_replace values('" & (reqno.Text) & "','" & (datetoday.Text) & "','" & (empcode.Text) & "','" & (empcodepre.Text) & "','" & (reasonpre.Text) & "','" & (edu.Text) & "','" & (job.Text) & "','" & (prof.Text) & "','" & (exp.Text) & "','" & (otherskills.Text) & "','" & (ddldesig.Text) & "','" & (datetojoin.Text) & "','N','" & (tempmonth.Text) & "','S','','','','','','" & (gender.Text) & "','','')"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        MessageBox("Record Saved")
        empcode.Text = ""
        empcodepre.Text = ""
        reasonpre.Text = ""
        edu.Text = ""
        job.Text = ""
        prof.Text = ""
        exp.Text = ""
        otherskills.Text = ""
        datetojoin.Text = ""
        tempmonth.Text = ""
        name.Text = ""
        dept.Text = ""
        section.Text = ""
        namepre.Text = ""
        deptpre.Text = ""
        sectionpre.Text = ""
        Server.Transfer("replacementstatus.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class