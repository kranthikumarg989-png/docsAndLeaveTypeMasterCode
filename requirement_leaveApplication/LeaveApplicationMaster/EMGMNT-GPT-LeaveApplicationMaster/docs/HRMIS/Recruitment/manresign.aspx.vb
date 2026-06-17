Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class manresign
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
        If IsPostBack = False Then
            empcode.Visible = False
            rb1.SelectedIndex = 3
            dept.Enabled = False
            desig.Enabled = False
            section.Enabled = False
        End If
        ddlcat.Visible = False
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        dept.Items.Clear()
        desig.Items.Clear()
        section.Items.Clear()
        If rb1.SelectedValue = "dept" Then
            dept.Enabled = True
            desig.Enabled = False
            section.Enabled = False
            sqltext = "select departmentcode + '--' +  departmentname from department  order by departmentcode"
        ElseIf rb1.SelectedValue = "desig" Then
            desig.Enabled = True
            dept.Enabled = False
            section.Enabled = False
            ddlcat.Visible = True
            sqltext = "select designationname from designation order by designationname"
        ElseIf rb1.SelectedValue = "sect" Then
            section.Enabled = True
            dept.Enabled = False
            desig.Enabled = False
            sqltext = "select sectioncode + '--' +sectionname from sectionmaster order by sectioncode"
        Else
            dept.Enabled = False
            desig.Enabled = False
            section.Enabled = False
            Exit Sub
        End If
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If dept.Enabled = True Then
                dept.Items.Add(rdr(0))
            End If
            If desig.Enabled = True Then
                desig.Items.Add(rdr(0))
            End If
            If section.Enabled = True Then
                section.Items.Add(rdr(0))
            End If
        End While
        rdr.Close()
    End Sub
    Protected Sub cb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.CheckedChanged
        If cb1.Checked = True Then
            empcode.Visible = True
            empcode.Focus()
            rb1.Enabled = False
            If rb1.Items(0).Selected = True Or rb1.Items(1).Selected = True Or rb1.Items(2).Selected = True Or rb1.Items(3).Selected = True Then
                rb1.SelectedItem.Selected = False
            End If
            fromdt.Text = ""
            todt.Text = ""
            fromdt.Enabled = False
            todt.Enabled = False
            dept.Items.Clear()
            desig.Items.Clear()
            section.Items.Clear()
        Else
            rb1.SelectedIndex = 3
            empcode.Text = ""
            empcode.Visible = False
            fromdt.Enabled = True
            todt.Enabled = True
            rb1.Enabled = True
        End If
        dept.Enabled = False
        desig.Enabled = False
        section.Enabled = False
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If empcode.Text <> "" Then
            Session("ecd") = empcode.Text
            Session("final") = "{empmaster.Empcode} =  '" & empcode.Text & "' And {empmaster.resigned} =  'Y'"
        Else
            If fromdt.Text = "" Or todt.Text = "" Then
                MessageBox("Enter Date Field")
                Exit Sub
            End If
            If rb1.SelectedValue = "dept" Then
                Session("final") = "{empmaster.dateoftermination} >= datetime('" & (fromdt.Text) & "')  And {empmaster.dateoftermination} <= datetime('" & (todt.Text) & "') and {empmaster.departmentcode} =  '" & (Val(dept.Text.Trim)) & "' And {empmaster.resigned} =  'Y'"
            ElseIf rb1.SelectedValue = "desig" And ddlcat.SelectedValue <> "A" Then
                Session("final") = "{empmaster.dateoftermination} >= datetime('" & (fromdt.Text) & "')  And {empmaster.dateoftermination} <= datetime('" & (todt.Text) & "') and {empmaster.designation} =  '" & (desig.Text) & "' and {empmaster.foreignemp} = '" & (Trim(ddlcat.SelectedValue)) & "' And {empmaster.resigned} =  'Y'"
            ElseIf rb1.SelectedValue = "desig" And ddlcat.SelectedValue = "A" Then
                Session("final") = "{empmaster.dateoftermination} >= datetime('" & (fromdt.Text) & "')  And {empmaster.dateoftermination} <= datetime('" & (todt.Text) & "') and {empmaster.designation} =  '" & (desig.Text) & "' And {empmaster.resigned} =  'Y'"
            ElseIf rb1.SelectedValue = "sect" Then
                Session("final") = "{empmaster.dateoftermination} >= datetime('" & (fromdt.Text) & "')  And {empmaster.dateoftermination} <= datetime('" & (todt.Text) & "') and {empmaster.sectioncode} =  '" & (Val(section.Text.Trim)) & "' And {empmaster.resigned} =  'Y'"
            ElseIf rb1.SelectedValue = "A" Then
                Session("final") = "{empmaster.dateoftermination} >= datetime('" & (fromdt.Text) & "')  And {empmaster.dateoftermination} <= datetime('" & (todt.Text) & "') And {empmaster.resigned} =  'Y'"
            End If
        End If
        Response.Redirect("manresignrpt.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class