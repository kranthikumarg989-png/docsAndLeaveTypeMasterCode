Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class WeeklyMaxOThrs
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
            MyScreenId = (69)
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
        If Not IsPostBack Then
            getdata()
        End If
    End Sub
    Private Sub getdata()
        Dim ds As New DataSet
        Dim dr1 As DataRow

        ds = getOTdataDetails()
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            maxhrs.Text = dr1("Tothrs").ToString
            lbledit.Text = dr1("recno").ToString
        End If
    End Sub
    Function getOTdataDetails() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from OT_WeekMaxHrs ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MaxOT")
        con.Close()
        Return ds
    End Function

    Protected Sub SubmitOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitOT.Click
        If lbledit.Text <> "-" Then
            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("OT_WkMaxHrs")
                Cmd.Parameters.AddWithValue("@Tothrs", maxhrs.Text)
                Cmd.Parameters.AddWithValue("@rno", lbledit.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.ExecuteNonQuery()
                LblMsg.Text = " WEEKLY MAXIMUM OT HOURS HAS BEEN UPDATED"

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Green

            End Try

        Else
            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("OT_WeekMaxHrs_ins")
                Cmd.Parameters.AddWithValue("@Tothrs", maxhrs.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.ExecuteNonQuery()
                LblMsg.Text = " WEEKLY MAXIMUM OT HOURS HAS BEEN ADDED"

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Green

            End Try
            MyGlobal.db_close()

        End If
        getdata()

    End Sub
End Class