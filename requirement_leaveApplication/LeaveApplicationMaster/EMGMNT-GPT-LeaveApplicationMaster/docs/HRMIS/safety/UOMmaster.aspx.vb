Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Partial Public Class UOMmaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (138)
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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub saveUOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveUOM.Click
        If oumname.Text <> "" And oumcode.Text <> "" Then
            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("safety_UOMmaster")
                Cmd.Parameters.AddWithValue("@oumname", oumname.Text)
                Cmd.Parameters.AddWithValue("@oumcode", oumcode.Text)
                'messagebox(oumname, oumcode)

                Cmd.ExecuteNonQuery()

                lblmsg.Text = "NEW ENTRY ADDED TO UOM MASTER"
                oumname.Text = ""
                oumcode.Text = ""
                messagebox("NEW ENTRY ADDED TO UOM MASTER")
            Catch ex As SqlException
                messagebox(ex.Message)
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Red

            End Try
        Else

            messagebox("Please enter values for UOM Name and UOM Code")

        End If
        MyGlobal.db_close()
        GridView2.DataBind()
    End Sub
    Protected Sub savemeas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savemeas.Click

        If measurementname.Text <> "" Then

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("safety_MeasMaster")
                Cmd.Parameters.AddWithValue("@measurementname", measurementname.Text)
                Cmd.ExecuteNonQuery()

                lblmsg1.Text = "NEW ENTRY ADDED TO MEASUREMENT MASTER"

                measurementname.Text = ""
                messagebox("NEW ENTRY ADDED TO MEASUREMENT MASTER")
            Catch ex As SqlException
                lblmsg1.Text = ex.Message
                lblmsg1.ForeColor = Drawing.Color.Red

            End Try

        Else

            messagebox("Please enter value for Measurement Name")

        End If

        MyGlobal.db_close()
        GridView1.DataBind()

    End Sub
End Class