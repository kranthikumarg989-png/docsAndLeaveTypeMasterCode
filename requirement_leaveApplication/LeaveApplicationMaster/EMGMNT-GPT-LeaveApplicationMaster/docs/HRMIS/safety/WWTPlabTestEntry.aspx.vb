Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class WWTPlabTestEntry
    Inherits System.Web.UI.Page
    Dim MyGlobal As Emanagement.globalinfo
    Dim MyApp As Emanagement.EMSapplications
    Dim rdr As SqlDataReader
    Dim thisdate As Date
    Dim ampm, sqltext, rtb As String
    Dim n As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (144)
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
        '''''''''''''''''''''''''''''''
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_dMIS()
        ' Session("empcode") = "014543"
        ampm = Date.Now
        If ampm.Contains("AM") = True Then
            am.SelectedValue = "AM"
        Else
            am.SelectedValue = "PM"
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub SAVEWWT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEWWT.Click
        Try
            MyGlobal.Con_Str()
            MyGlobal.Open_Con_dmis()
            Con.Open()
            Dim dt
            Dim time
            time = hrs.Text + ":" + mins.Text + " " + Convert.ToString(am.SelectedValue)
            dt = time
            'Call MyGlobal.dbSp_open_dmis("safety_wwtplab")
            Cmd = New SqlCommand("[dbo].[safety_wwtplab]", Con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@year", year.SelectedValue)
            Cmd.Parameters.AddWithValue("@month", month.SelectedValue)
            Cmd.Parameters.AddWithValue("@samptyp", samptyp.Text)
            Cmd.Parameters.AddWithValue("@labname", labname.Text)
            Cmd.Parameters.AddWithValue("@labno", labno.Text)
            Cmd.Parameters.AddWithValue("@samptkn", samptkn.Text)
            Cmd.Parameters.AddWithValue("@tknby", tknby.Text)
            Cmd.Parameters.AddWithValue("@wwtpno", wwtpno.Text)
            Cmd.Parameters.AddWithValue("@myfile", "DUMMY") 'myfile.PostedFile)
            Cmd.Parameters.AddWithValue("@dt", dt)
            Cmd.Parameters.AddWithValue("@R1", R1.Text)
            Cmd.Parameters.AddWithValue("@R2", R2.Text)
            Cmd.Parameters.AddWithValue("@R3", R3.Text)
            Cmd.Parameters.AddWithValue("@R4", R4.Text)
            'Cmd.Parameters.AddWithValue("@R4", R4.Text)
            Cmd.Parameters.AddWithValue("@R5", R5.Text)
            Cmd.Parameters.AddWithValue("@R6", R6.Text)
            Cmd.Parameters.AddWithValue("@R7", R7.Text)
            Cmd.Parameters.AddWithValue("@R8", R8.Text)
            Cmd.Parameters.AddWithValue("@R9", R9.Text)
            Cmd.Parameters.AddWithValue("@R10", R10.Text)
            Cmd.Parameters.AddWithValue("@R11", R11.Text)
            Cmd.Parameters.AddWithValue("@R12", R12.Text)
            Cmd.Parameters.AddWithValue("@R13", R13.Text)
            Cmd.Parameters.AddWithValue("@R14", R14.Text)
            Cmd.Parameters.AddWithValue("@R15", R15.Text)
            Cmd.Parameters.AddWithValue("@R16", R16.Text)
            Cmd.Parameters.AddWithValue("@R17", R17.Text)
            Cmd.Parameters.AddWithValue("@R18", R18.Text)
            Cmd.Parameters.AddWithValue("@R19", R19.Text)
            Cmd.Parameters.AddWithValue("@R20", R20.Text)
            Cmd.Parameters.AddWithValue("@R21", R21.Text)
            Cmd.Parameters.AddWithValue("@R22", R22.Text)
            Cmd.ExecuteNonQuery()
            lblmsg.Text = "NEW ENTRY ADDED"

        Catch ex As SqlException
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Green
        End Try
        sqltext = "select count(year)from wwtplabtesttemp where year='" & (year.SelectedValue) & "' "
        Cmd = New SqlCommand(sqltext, Con)
        n = Cmd.ExecuteScalar
        If n = 0 Then
            Cmd = New SqlCommand("[dbo].[safety_wwtplabtempinsert]", Con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@year", year.SelectedValue)
            Cmd.ExecuteNonQuery()
            For n As Integer = 1 To 28
                If n = 1 Then
                    rtb = R1.Text
                ElseIf n = 2 Then
                    rtb = R2.Text
                ElseIf n = 3 Then
                    rtb = R3.Text
                ElseIf n = 4 Then
                    rtb = R4.Text
                ElseIf n = 5 Then
                    rtb = R5.Text
                ElseIf n = 6 Then
                    rtb = R6.Text
                ElseIf n = 7 Then
                    rtb = R7.Text
                ElseIf n = 8 Then
                    rtb = R8.Text
                ElseIf n = 9 Then
                    rtb = R9.Text
                ElseIf n = 10 Then
                    rtb = R10.Text
                ElseIf n = 11 Then
                    rtb = R11.Text
                ElseIf n = 12 Then
                    rtb = R12.Text
                ElseIf n = 13 Then
                    rtb = R13.Text
                ElseIf n = 14 Then
                    rtb = R14.Text
                ElseIf n = 15 Then
                    rtb = R15.Text
                ElseIf n = 16 Then
                    rtb = R16.Text
                ElseIf n = 17 Then
                    rtb = R17.Text
                ElseIf n = 18 Then
                    rtb = R18.Text
                ElseIf n = 19 Then
                    rtb = R19.Text
                ElseIf n = 20 Then
                    rtb = R20.Text
                ElseIf n = 21 Then
                    rtb = R21.Text
                ElseIf n = 22 Then
                    rtb = R22.Text
                ElseIf n = 23 Then
                    rtb = labname.Text
                ElseIf n = 24 Then
                    rtb = samptyp.Text
                ElseIf n = 25 Then
                    rtb = labno.Text
                ElseIf n = 26 Then
                    rtb = samptkn.Text
                ElseIf n = 27 Then
                    Dim time = hrs.Text + ":" + mins.Text + " " + Convert.ToString(am.SelectedValue)
                    rtb = time
                ElseIf n = 28 Then
                    rtb = tknby.Text
                End If
                sqltext = "update wwtplabtesttemp set column='" & rtb & "',tpno='" & (wwtpno.Text) & "' where year='" & (year.SelectedValue) & "' and no='" & n & "'"
                If sqltext.Contains("column") = True Then
                    sqltext = sqltext.Replace("column", month.SelectedItem.Text.Trim)
                    sqltext = sqltext.Replace("tpno", "w" & month.SelectedItem.Text.Trim)
                End If
                Cmd = New SqlCommand(sqltext, Con)
                Cmd.ExecuteNonQuery()
            Next
            messagebox("w" & month.SelectedItem.Text.Trim)
        Else
            For n As Integer = 1 To 28
                If n = 1 Then
                    rtb = R1.Text
                ElseIf n = 2 Then
                    rtb = R2.Text
                ElseIf n = 3 Then
                    rtb = R3.Text
                ElseIf n = 4 Then
                    rtb = R4.Text
                ElseIf n = 5 Then
                    rtb = R5.Text
                ElseIf n = 6 Then
                    rtb = R6.Text
                ElseIf n = 7 Then
                    rtb = R7.Text
                ElseIf n = 8 Then
                    rtb = R8.Text
                ElseIf n = 9 Then
                    rtb = R9.Text
                ElseIf n = 10 Then
                    rtb = R10.Text
                ElseIf n = 11 Then
                    rtb = R11.Text
                ElseIf n = 12 Then
                    rtb = R12.Text
                ElseIf n = 13 Then
                    rtb = R13.Text
                ElseIf n = 14 Then
                    rtb = R14.Text
                ElseIf n = 15 Then
                    rtb = R15.Text
                ElseIf n = 16 Then
                    rtb = R16.Text
                ElseIf n = 17 Then
                    rtb = R17.Text
                ElseIf n = 18 Then
                    rtb = R18.Text
                ElseIf n = 19 Then
                    rtb = R19.Text
                ElseIf n = 20 Then
                    rtb = R20.Text
                ElseIf n = 21 Then
                    rtb = R21.Text
                ElseIf n = 22 Then
                    rtb = R22.Text
                ElseIf n = 23 Then
                    rtb = labname.Text
                ElseIf n = 24 Then
                    rtb = samptyp.Text
                ElseIf n = 25 Then
                    rtb = labno.Text
                ElseIf n = 26 Then
                    rtb = samptkn.Text
                ElseIf n = 27 Then
                    Dim time = hrs.Text + ":" + mins.Text + " " + Convert.ToString(am.SelectedValue)
                    rtb = time
                ElseIf n = 28 Then
                    rtb = tknby.Text
                End If
                sqltext = "update wwtplabtesttemp set column='" & rtb & "',tpno='" & (wwtpno.Text) & "' where year='" & (year.SelectedValue) & "' and no='" & n & "'"
                If sqltext.Contains("column") = True Then
                    sqltext = sqltext.Replace("column", month.SelectedItem.Text.Trim)
                    sqltext = sqltext.Replace("tpno", "w" & month.SelectedItem.Text.Trim)
                End If
                Cmd = New SqlCommand(sqltext, Con)
                Cmd.ExecuteNonQuery()
            Next
        End If
        MyGlobal.db_close()
        Call clear()
    End Sub
    'Sub Upload(ByVal Source As Object, ByVal e As EventArgs)
    '    If Not (myFile.PostedFile Is Nothing) Then
    '        Dim intFileNameLength As Integer
    '        Dim strFileNamePath As String
    '        Dim strFileNameOnly As String
    '        'Logic to find the FileName (excluding the path)
    '        strFileNamePath = MyFile.PostedFile.FileName
    '        intFileNameLength = Instr(1, StrReverse(strFileNamePath), "\")
    '        strFileNameOnly = Mid(strFileNamePath, (Len(strFileNamePath) - intFileNameLength) + 2)
    '        myFile.PostedFile.SaveAs("c:\inetpub\wwwroot\yourwebapp\upload\" & strFileNameOnly)
    '    End If
    'End Sub
    Sub clear()
        year.SelectedValue = "-1"
        month.SelectedValue = "-1"
        samptyp.Text = ""
        labname.Text = ""
        samptkn.Text = ""
        labno.Text = ""
        tknby.Text = ""
        wwtpno.Text = ""
        hrs.Text = ""
        mins.Text = ""
        am.Text = ""
        R1.Text = ""
        R2.Text = ""
        R3.Text = ""
        R4.Text = ""
        R5.Text = ""
        R6.Text = ""
        R7.Text = ""
        R8.Text = ""
        R9.Text = ""
        R10.Text = ""
        R11.Text = ""
        R12.Text = ""
        R13.Text = ""
        R14.Text = ""
        R15.Text = ""
        R16.Text = ""
        R17.Text = ""
        R18.Text = ""
        R19.Text = ""
        R20.Text = ""
        R21.Text = ""
        R22.Text = ""
    End Sub
    Sub upd()
       
    End Sub
End Class