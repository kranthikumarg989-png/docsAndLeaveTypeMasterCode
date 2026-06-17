Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class man_recruitmentrequistion
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Dim pre As String
    Private Sub man_recruitmentrequistion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim cmd As New SqlCommand
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        empcode.Focus()
        lbldate.Text = Date.Now.ToShortDateString
        sqltext = "select max(requisitionno)+1 from man_request"
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If IsPostBack = False Then
                reqno.Text = rdr(0)
            End If
        End While
        rdr.Close()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("no") <> "" Then
            Con = New SqlConnection(constr)
            Con.Open()
            sqltext = "select requisitionno,requestorempcode,designation,vacancies,postvacant,equalification,jobdescription,pqualification,experiencedetails,otherskills,requireddate,responsibilites,gender from man_request where requisitionno='" & Session("no") & "' "
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                reqno.Text = rdr(0)
                empcode.Text = rdr(1)
                DropDownList1.Text = rdr(2)
                noofvacancies.Text = rdr(3)
                vacantpost.Text = rdr(4)
                qualific.Text = rdr(5)
                jobdesc.Text = rdr(6)
                professional.Text = rdr(7)
                experience.Text = (rdr(8))
                otherskills.Text = rdr(9)
                txtdate.Text = rdr(10)
                response.Text = rdr(11)
                DropDownList2.Text = rdr(12)
            End While
            rdr.Close()
            Session("no") = ""
            save.Text = "Update"
            empcode.ReadOnly = True
        End If
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        If IsNumeric(empcode.Text) Then
            sqltext = "select empname,sectioncode,departmentcode,designation from empmaster where empcode='" & (empcode.Text) & "'and resigned='N'"
            empname.Text = ""
            section.Text = ""
            department.Text = ""
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                empname.Text = rdr(0)
                section.Text = rdr(1)
                department.Text = rdr(2)
            End While
            rdr.Close()
            If empname.Text = "" Then
                MessageBox("Enter Correct Empcode")
                empcode.Text = ""
                empcode.Focus()
            End If
        Else
            MessageBox("Empcode Not Exist in The Database Re-enter correct Empcode")
            empname.Text = ""
            section.Text = ""
            department.Text = ""
            empcode.Text = ""
            empcode.Focus()
        End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If IsNumeric(noofvacancies.Text) = True Then
        Else
            MessageBox("Enter Numbers only!")
            noofvacancies.Text = ""
            noofvacancies.Focus()
            Exit Sub
        End If
        If save.Text = "Update" Then
            sqltext = "update man_request set requestdate='" & (lbldate.Text) & "',designation='" & (DropDownList1.Text) & "',vacancies='" & (noofvacancies.Text) & "',postvacant='" & (vacantpost.Text) & "',equalification='" & (qualific.Text) & "',jobdescription='" & (jobdesc.Text) & "',pqualification='" & (professional.Text) & "',experiencedetails='" & (experience.Text) & "',otherskills='" & (otherskills.Text) & "',requireddate='" & (txtdate.Text) & "',responsibilites='" & (response.Text) & "',gender='" & (DropDownList2.Text) & "' where requisitionno='" & (reqno.Text) & "'"
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
            MessageBox("record updated sucessfully")
            Server.Transfer("recruitmentstatus.aspx")
        Else
            sqltext = "insert into man_request values('" & (reqno.Text) & "','" & (lbldate.Text) & "','" & (empcode.Text) & "','" & (DropDownList1.Text) & "','" & (noofvacancies.Text) & "','','" & (vacantpost.Text) & "','" & (qualific.Text) & "','" & (jobdesc.Text) & "','" & (professional.Text) & "','" & (experience.Text) & "','" & (otherskills.Text) & "','" & (txtdate.Text) & "','" & (response.Text) & "','S','','','','','','" & (DropDownList2.Text) & "','','')"
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved")
            Server.Transfer("recruitmentstatus.aspx")
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class