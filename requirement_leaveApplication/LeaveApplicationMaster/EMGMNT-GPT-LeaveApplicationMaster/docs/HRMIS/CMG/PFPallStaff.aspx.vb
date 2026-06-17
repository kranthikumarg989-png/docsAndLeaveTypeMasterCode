Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class PFPallStaff
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim sqltext As String
    Dim rdr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (221)
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

        Con = New SqlConnection(constr)
        Con.Open()
        'Session("empcode") = "014543"
        'labelmsg.Text = ""
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        If IsNumeric(empcode.Text) = True Then
            sqltext = "select empname,departmentcode,designation from empmaster where empcode='" & (empcode.Text) & "' and designation<>'operator'"
            Cmd = New SqlCommand(sqltext, Con)
            rdr = Cmd.ExecuteReader
            While rdr.Read
                name.Text = rdr(0)
                dept.Text = rdr(1)
                desig.Text = rdr(2)
            End While

            rdr.Close()
            SavePFPstaff.Enabled = True
        Else
            MessageBox("Invalid Empcode")
            empcode.Text = ""
            empcode.Focus()
            Exit Sub
        End If
    End Sub
    Protected Sub SavePFPstaff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePFPstaff.Click
        Dim dd1 As String
        Dim dd As String

        dd1 = letdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)
        Session("letdet") = letdt.Text.Trim


        Dim fd1 As String
        fd1 = eff_frm.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Session("efffrom") = eff_frm.Text.Trim
        If IsNumeric(pfpamt.Text) = False Then
            MessageBox("Enter Amount!")
            pfpamt.Text = ""
            pfpamt.Focus()
            Exit Sub
        End If
        sqltext = "insert into hr_pfp values('" & (empcode.Text) & "','" & (pfpamt.Text) & "','" & dd & "','" & fd & "')"
        Cmd = New SqlCommand(sqltext, Con)
        Cmd.ExecuteNonQuery()
        SavePFPstaff.Enabled = False
        Session("name") = name.Text
        Session("dept") = dept.Text
        Session("desig") = desig.Text
        Session("empcode") = empcode.Text
        Session("vdate") = letdt.Text.Trim
        Session("edate") = eff_frm.Text.Trim
        Session("pfp") = pfpamt.Text
        Response.Redirect("letterallstaff.aspx")
        'Response.Redirect("l1.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class