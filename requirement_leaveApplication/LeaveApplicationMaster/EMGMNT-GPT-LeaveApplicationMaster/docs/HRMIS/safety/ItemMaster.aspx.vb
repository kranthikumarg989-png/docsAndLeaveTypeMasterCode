Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class ItemMaster
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
            MyScreenId = (136)
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

    Protected Sub saveim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveim.Click

        If lbledit.Text = "-" Then

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("safety_im")
                Cmd.Parameters.AddWithValue("@Desc", desc.SelectedValue)
                Cmd.Parameters.AddWithValue("@item", item.Text)
                Cmd.Parameters.AddWithValue("@code", code.Text)
                Cmd.Parameters.AddWithValue("@oum", oum.SelectedValue)
                Cmd.Parameters.AddWithValue("@measurement", measurement.SelectedValue)
                Cmd.Parameters.AddWithValue("@stdmeasurement", stdmeasurement.Text)
                Cmd.Parameters.AddWithValue("@controlspec", controlspec.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@datekeyin", DateTime.Now)
                Cmd.ExecuteNonQuery()

                LblMsg.Text = "NEW ENTRY ADDED TO ITEM MASTER"

                desc.SelectedValue = "-1"
                item.Text = ""
                code.Text = ""
                oum.SelectedValue = "-1"
                measurement.SelectedValue = "-1"
                stdmeasurement.Text = ""
                controlspec.Text = ""
                lbledit.Text = ""

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try

        Else

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("updsafety_im")
                Cmd.Parameters.AddWithValue("@Desc", desc.SelectedValue)
                Cmd.Parameters.AddWithValue("@item", item.Text)
                Cmd.Parameters.AddWithValue("@code", code.Text)
                Cmd.Parameters.AddWithValue("@oum", oum.SelectedValue)
                Cmd.Parameters.AddWithValue("@measurement", measurement.SelectedValue)
                Cmd.Parameters.AddWithValue("@stdmeasurement", stdmeasurement.Text)
                Cmd.Parameters.AddWithValue("@controlspec", controlspec.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@datekeyin", DateTime.Now)
                Cmd.Parameters.AddWithValue("@vid", lbledit.Text)
                Cmd.ExecuteNonQuery()

                LblMsg.Text = "ITEM MASTER UPDATED"
                desc.SelectedValue = "-1"
                item.Text = ""
                code.Text = ""
                oum.SelectedValue = "-1"
                measurement.SelectedValue = "-1"
                stdmeasurement.Text = ""
                controlspec.Text = ""
                lbledit.Text = ""

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try
        End If
        MyGlobal.db_close()

        GridView1.DataBind()
    End Sub
    Public Sub getsafety(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = getOTdataDetails(appno)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            desc.SelectedValue = dr1("description").ToString
            item.Text = dr1("item").ToString
            code.Text = dr1("code").ToString
            oum.SelectedValue = dr1("oum").ToString
            measurement.SelectedValue = dr1("measurement").ToString
            controlspec.Text = dr1("controlspec").ToString
            stdmeasurement.Text = dr1("stdmeasurement").ToString
            lbledit.Text = dr1("recordno").ToString
            
        End If
    End Sub

    Function getOTdataDetails(ByVal recordno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from safety_schedulemaster where recordno = '" & recordno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "SY")
        con.Close()
        Return ds
    End Function
End Class