Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class IndustrialTraining
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim code As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (154)
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

    Protected Sub SAVEIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEIT.Click

        Dim fd1 As String
        fd1 = letdt.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = applndt.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)


        Dim qd1 As String
        qd1 = prgmto.Text.Trim
        Dim strdate3() As String = qd1.Split("/"c)
        qd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        Dim qd As Date
        qd = CDate(qd1)


        Dim pd1 As String
        pd1 = prgmfrm.Text.Trim
        Dim strdate4() As String = pd1.Split("/"c)
        pd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

        Dim pd As Date
        pd = CDate(pd1)



        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Call MyGlobal.dbSp_open("Training_ind")
            Cmd.Parameters.AddWithValue("@name", name.Text)
            Cmd.Parameters.AddWithValue("@icno", icno.Text)
            Cmd.Parameters.AddWithValue("@add1", add1.Text)
            Cmd.Parameters.AddWithValue("@add2", add2.Text)
            Cmd.Parameters.AddWithValue("@letdt", fd)
            Cmd.Parameters.AddWithValue("@applndt", td)
            Cmd.Parameters.AddWithValue("@prgmfrm", pd)
            Cmd.Parameters.AddWithValue("@prgmto", qd)
            Cmd.Parameters.AddWithValue("@dept", dept.Text)
            Cmd.Parameters.AddWithValue("@duration", duration.Text)


            Cmd.ExecuteNonQuery()

            lblmsg.Text = "Industrial Training Details Updated"
            name.Text = ""
            '   icno.Text = ""
            add1.Text = ""
            add2.Text = ""
            applndt.Text = ""
            '  letdt.Text = ""
            prgmfrm.Text = ""
            prgmto.Text = ""
            dept.Text = ""
            duration.Text = ""

        Catch ex As SqlException
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Green
            Exit Sub

        End Try

        MyGlobal.db_close()

        Session("tdicno") = icno.Text
        Session("tdldate") = fd
        Response.Redirect("indtrainingrpt.aspx")
    End Sub

End Class