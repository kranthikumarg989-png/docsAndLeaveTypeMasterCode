Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class WasteWaterMonitoring
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno, sqltext As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MyGlobal.Open_Con()
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (143)
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
        MyGlobal.Open_Con_dmis()
        '  Session("empcode") = "014543"
    End Sub
    Protected Sub wwmsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wwmsave.Click
        Dim incoming
        incoming = ip1.Text & "," & ip2.Text
        Dim waterph
        waterph = tp1.Text & "," & tp2.Text
        Dim cod
        cod = cp1.Text & "," & cp2.Text
        Try
            Con.Open()
            'Call MyGlobal.dbSp_open_dmis("safety_wwm")
            Cmd = New SqlCommand("[dbo].[safety_wwm]", Con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@year", year.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@month", month.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@day", day.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@incoming", incoming)
            Cmd.Parameters.AddWithValue("@waterph", waterph)
            Cmd.Parameters.AddWithValue("@cod", cod)
            Cmd.Parameters.AddWithValue("@plantno", plantno.SelectedValue)
            Cmd.Parameters.AddWithValue("@datadate", Date.Now.ToShortDateString)
            Cmd.ExecuteNonQuery()
            'sqltext = "insert into wastewater()"
            lblmsg.Text = "NEW ENTRY ADDED"
            year.SelectedValue = "-1"
            month.SelectedValue = "-1"
            day.SelectedValue = "-1"
            ip1.Text = "P1:"
            ip2.Text = "P2:"
            tp1.Text = "P1:"
            tp2.Text = "P2: "
            cp1.Text = "P1:"
            cp2.Text = "P2:"
            plantno.SelectedValue = "-1"
        Catch ex As SqlException
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Green
        End Try
        MyGlobal.db_close()
    End Sub
End Class