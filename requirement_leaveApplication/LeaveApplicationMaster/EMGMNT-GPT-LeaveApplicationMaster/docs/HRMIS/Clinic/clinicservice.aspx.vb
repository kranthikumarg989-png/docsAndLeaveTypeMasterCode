Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class clinicservice
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, dt, ecode As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (235)
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

    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        dt = Date.Now.ToShortDateString
        ecode = Session("empcode")
        Dim mn, yr As String
        If month.SelectedValue = "-1" Then
            MessageBox("Select month")
            month.Focus()
            Exit Sub
        ElseIf clinic.SelectedValue = "-1" Then
            MessageBox("Select clinic name")
            clinic.Focus()
            Exit Sub
        End If
        If mc.Text <> "" And dv.Text <> "" And com.Text <> "" Then
            If IsNumeric(mc.Text) = False Then
                MessageBox("Enter Cost Only!")
                mc.Text = ""
                mc.Focus()
                Exit Sub
            ElseIf IsNumeric(dv.Text) = False Then
                MessageBox("Enter numeric values Only!")
                dv.Text = ""
                dv.Focus()
                Exit Sub
            ElseIf IsNumeric(com.Text) = False Then
                MessageBox("Enter MedicineCost Only!")
                com.Text = ""
                com.Focus()
                Exit Sub
            End If
        Else
            MessageBox("Textbox Should not Blank")
            Exit Sub
        End If
        If year.SelectedValue <> "-1" Then
            sqltext = "select months,years from clinicservice where months='" & (month.SelectedValue.Trim) & "' and years='" & (year.SelectedValue.Trim) & "'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                mn = rdr(0).ToString.Trim
                yr = rdr(1).ToString.Trim
            End While
            rdr.Close()
            If month.SelectedValue = mn And year.SelectedValue = yr Then
                MessageBox("Record Already Exist")
                Exit Sub
            End If
        Else
            MessageBox("Select year")
            year.Focus()
            Exit Sub
        End If
        sqltext = "insert into clinicservice values('" & (month.SelectedValue.Trim) & "','" & (year.SelectedValue.Trim) & "','" & (mc.Text) & "','" & (dv.Text) & "','" & (com.Text) & "','" & ecode & "','" & dt & "','" & (clinic.SelectedValue.Trim) & "')"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        MessageBox("Record Saved")
        mc.Text = ""
        dv.Text = ""
        com.Text = ""
        month.SelectedValue = "-1"
        clinic.SelectedValue = "-1"
        year.SelectedValue = "-1"
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class