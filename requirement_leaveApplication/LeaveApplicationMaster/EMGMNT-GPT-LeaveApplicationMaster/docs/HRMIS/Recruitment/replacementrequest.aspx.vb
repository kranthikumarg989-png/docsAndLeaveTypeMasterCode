Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class replacementrequest
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim sqltext, bac As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Private Sub replacementrequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        empcode.Focus()
        datetoday.Text = Date.Now.ToShortDateString
        Getsno_manpower()
        reqno.Text = posid
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'bac = "back"
        If Session("no") <> "" Then
            datetoday.Text = Date.Now.ToShortDateString
            empcode.ReadOnly = True
            empcodepre.ReadOnly = True
            save.Text = "Update"
            gender.Focus()
            sqltext = "select requisitionno,reasonleaving,gender,requireddate,noofmonth,rdesignation,equalification,jobdescription,pqualification,experiencedetails,otherskills from man_replace where requisitionno='" & Session("no") & "'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                reqno.Text = rdr(0)
                reasonpre.Text = rdr(1)
                gender.Text = rdr(2)
                datetojoin.Text = rdr(3)
                tempmonth.Text = rdr(4)
                ddldesig.Text = rdr(5)
                edu.Text = rdr(6)
                job.Text = rdr(7)
                prof.Text = rdr(8)
                exp.Text = rdr(9)
                otherskills.Text = rdr(10)
            End While
            rdr.Close()
        End If
        Session("no") = ""
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        If IsNumeric(empcode.Text) Then
            sqltext = "select empname,sectioncode,departmentcode from empmaster where empcode='" & (empcode.Text) & "' and resigned='N'"
            name.Text = ""
            section.Text = ""
            dept.Text = ""
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read()
                name.Text = rdr(0)
                section.Text = rdr(1)
                dept.Text = rdr(2)
            End While
            rdr.Close()
            empcodepre.Focus()
            If name.Text = "" Then
                MessageBox("Enter Correct Empcode")
                empcode.Text = ""
                empcode.Focus()
            End If
        Else
            MessageBox("Empcode Not Exist in The Database")
            name.Text = ""
            section.Text = ""
            dept.Text = ""
            empcode.Text = ""
            empcode.Focus()
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub empcodepre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcodepre.TextChanged
        If IsNumeric(empcodepre.Text) Then
            sqltext = "select empname,sectioncode,departmentcode,designation from empmaster where empcode='" & (empcodepre.Text) & "' and resigned='Y'"
            namepre.Text = ""
            sectionpre.Text = ""
            deptpre.Text = ""
            desigpre.Text = ""
            reasonpre.Text = ""
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
            If namepre.Text = "" Then
                MessageBox("Enter Resigned Empcode Only")
                empcodepre.Text = ""
                empcodepre.Focus()
            End If
        Else
            MessageBox("Enter Employee numbers only")
            namepre.Text = ""
            sectionpre.Text = ""
            deptpre.Text = ""
            desigpre.Text = ""
            reasonpre.Text = ""
            empcodepre.Text = ""
            empcodepre.Focus()
        End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If save.Text = "Update" Then
            sqltext = "update man_replace set requestdate='" & (datetoday.Text) & "',reasonleaving='" & (reasonpre.Text) & "',gender='" & (gender.Text) & "',requireddate='" & (datetojoin.Text) & "',noofmonth='" & (tempmonth.Text) & "',rdesignation='" & (ddldesig.Text) & "',equalification='" & (edu.Text) & "',jobdescription='" & (job.Text) & "',pqualification='" & (prof.Text) & "',experiencedetails='" & (exp.Text) & "',otherskills='" & (otherskills.Text) & "' where requisitionno='" & (reqno.Text) & "' "
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
            MessageBox("Record Updated Sucessfully")
            Server.Transfer("replacementstatus.aspx")
        Else
            sqltext = "insert into man_replace values('" & (reqno.Text) & "','" & (datetoday.Text) & "','" & (empcode.Text) & "','" & (empcodepre.Text) & "','" & (reasonpre.Text) & "','" & (edu.Text) & "','" & (job.Text) & "','" & (prof.Text) & "','" & (exp.Text) & "','" & (otherskills.Text) & "','" & (ddldesig.Text) & "','" & (datetojoin.Text) & "','N','" & (tempmonth.Text) & "','S','','','','','','" & (gender.Text) & "','','')"
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
            'MessageBox("Record Saved")
            Server.Transfer("replacementstatus.aspx")
        End If
    End Sub
End Class