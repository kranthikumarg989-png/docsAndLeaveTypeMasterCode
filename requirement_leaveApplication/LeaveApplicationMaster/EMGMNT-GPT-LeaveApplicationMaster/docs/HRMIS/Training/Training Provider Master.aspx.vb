Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Training_Provider_Master
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim code As Decimal

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (149)
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

        If Not IsPostBack Then
            Dim codeno As Integer
            GetTPMcode()
            codeno = posid
            lblcode.Text = posid
        End If
      

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"

    End Sub

    Protected Sub SAVEPM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEPM.Click
        'Try
        '    MyGlobal.Open_Con()
        '    MyGlobal.Con_Str()

        '    Call MyGlobal.dbSp_open("training_updpm")
        '    Cmd.Parameters.AddWithValue("@code", code.ToString)
        '    Cmd.Parameters.AddWithValue("@name", name.Text)
        '    Cmd.Parameters.AddWithValue("@registrationno", registrationno.Text)
        '    Cmd.Parameters.AddWithValue("@address", address.Text)
        '    Cmd.Parameters.AddWithValue("@courses", courses.Text)
        '    Cmd.Parameters.AddWithValue("@others", others.Text)
        '    Cmd.Parameters.AddWithValue("@trainers", trainers.Text)
        '    Cmd.Parameters.AddWithValue("@contactno", contactno.Text)
        '    Cmd.ExecuteNonQuery()

        '    lblmsg.Text = "TRAINING PROVIDER MASTER UPDATED"


        '    name.Text = ""
        '    registrationno.Text = ""
        '    address.Text = ""
        '    courses.Text = ""
        '    others.Text = ""
        '    trainers.Text = ""
        '    contactno.Text = ""
        'Catch ex As SqlException
        '    lblmsg.Text = ex.Message
        '    lblmsg.ForeColor = Drawing.Color.Red
        'End Try
                    

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Call MyGlobal.dbSp_open("training_pm")
            Cmd.Parameters.AddWithValue("@lblcode", lblcode.Text)
            Cmd.Parameters.AddWithValue("@name", name.Text)
            Cmd.Parameters.AddWithValue("@registrationno", registrationno.Text)
            Cmd.Parameters.AddWithValue("@address", address.Text)
            Cmd.Parameters.AddWithValue("@courses", courses.Text)
            Cmd.Parameters.AddWithValue("@others", others.Text)
            Cmd.Parameters.AddWithValue("@trainers", trainers.Text)
            Cmd.Parameters.AddWithValue("@contactno", contactno.Text)
            Cmd.ExecuteNonQuery()

            lblmsg.Text = "NEW ENTRY ADDED TO TRAINING PROVIDER MASTER"


            name.Text = ""
            registrationno.Text = ""
            address.Text = ""
            courses.Text = ""
            others.Text = ""
            trainers.Text = ""
            contactno.Text = ""
            Dim codeno As Integer
            GetTPMcode()
            codeno = posid
            lblcode.Text = posid

        Catch ex As SqlException
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Red
        End Try

        MyGlobal.db_close()
        GridView1.DataBind()
    End Sub

 

End Class