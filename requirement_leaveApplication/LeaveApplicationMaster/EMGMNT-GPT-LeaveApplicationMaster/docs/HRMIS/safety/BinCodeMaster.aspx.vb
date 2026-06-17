Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class BinCodeMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (137)
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
        'Session("empcode") = "014543"
        LblMsg.Text = ""
    End Sub
    Protected Sub SubmitBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitBC.Click

        If lbledit.Text = "-" Then

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("safety_bc")
                Cmd.Parameters.AddWithValue("@deptcode", deptcode.SelectedValue)
                Cmd.Parameters.AddWithValue("@sectcode", sectcode.SelectedValue)
                Cmd.Parameters.AddWithValue("@wastetype", wastetype.SelectedValue)
                Cmd.Parameters.AddWithValue("@items", Items.SelectedValue)
                Cmd.Parameters.AddWithValue("@bincode", bincode.Text)
                Cmd.Parameters.AddWithValue("@location", location.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@datekeyin", DateTime.Now)
                Cmd.ExecuteNonQuery()

                LblMsg.Text = "NEW ENTRY ADDED TO BIN CODE MASTER"

                deptcode.SelectedValue = "-1"
                sectcode.SelectedValue = "-1"
                wastetype.SelectedValue = "-1"
                Items.SelectedValue = "-1"
                bincode.Text = ""
                location.Text = ""
                lbledit.Text = ""

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try

        Else

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("updsafety_bc")
                Cmd.Parameters.AddWithValue("@deptcode", deptcode.SelectedValue)
                Cmd.Parameters.AddWithValue("@sectcode", sectcode.SelectedValue)
                Cmd.Parameters.AddWithValue("@wastetype", wastetype.SelectedValue)
                Cmd.Parameters.AddWithValue("@items", Items.SelectedValue)
                Cmd.Parameters.AddWithValue("@bincode", bincode.Text)
                Cmd.Parameters.AddWithValue("@location", location.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@datekeyin", DateTime.Now)
                Cmd.Parameters.AddWithValue("@vid", lbledit.Text)
                Cmd.ExecuteNonQuery()

                LblMsg.Text = "BIN CODE MASTER UPDATED"
                deptcode.SelectedValue = "-1"
                sectcode.SelectedValue = "-1"
                wastetype.SelectedValue = "-1"
                Items.SelectedValue = "-1"
                bincode.Text = ""
                location.Text = ""
                lbledit.Text = ""

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try
        End If
        MyGlobal.db_close()

        GridView1.DataBind()
    End Sub
    Public Sub getsafetybc(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = getbcDetails(appno)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            deptcode.SelectedValue = dr1("deptcode").ToString
            sectcode.SelectedValue = dr1("sectcode").ToString
            wastetype.SelectedValue = dr1("wastetype").ToString
            items.SelectedValue = dr1("items").ToString
            bincode.Text = dr1("bincode").ToString
            location.Text = dr1("location").ToString
            lbledit.Text = dr1("recordno").ToString

        End If
    End Sub

    Function getbcDetails(ByVal recordno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from safety_bincode where recordno = '" & recordno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "BC")
        con.Close()
        Return ds
    End Function

End Class