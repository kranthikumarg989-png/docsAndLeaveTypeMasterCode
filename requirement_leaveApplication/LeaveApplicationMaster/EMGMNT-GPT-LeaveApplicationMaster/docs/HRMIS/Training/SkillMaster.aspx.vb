Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class SkillMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (150)
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
        MyApp.GetfiscalYear()
        _eid = Session("empcode")
        Label1.Text = ""
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click

        Try
            '        Try
            '            Getskillcode(td_skillcode.Text)
            '            Dim dr, dr1, dr2 As DataRow
            '            If recstatus = True Then
            '                If dsdata.Tables(0).Rows.Count > 0 Then
            '                    dr = dsdata.Tables(0).Rows(0)
            '                    td_skillcode.Text = dr("td_skillcode").ToString
            '                    If dr("td_skillcode") Is <> td_skillcode.text Then

            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Call MyGlobal.dbSp_open("training_skillmaster")
            Cmd.Parameters.AddWithValue("@td_skillcode", td_skillcode.Text)
            Cmd.Parameters.AddWithValue("@td_skilltitle", td_skilltitle.Text)
            Cmd.ExecuteNonQuery()

            Label1.Text = "Skillmaster Data Saved successfully"

            td_skillcode.Text = ""
            td_skilltitle.Text = ""

        Catch ex As Exception
            messagebox(ex.Message)
            Label1.Text = ex.Message

        End Try
        MyGlobal.db_close()
        GridView1.DataBind()

        '    else 
        '        Label1.Text = "Skill Code alreday exists"
        '        Cmd.ExecuteNonQuery()

        '        end if
        '        end if
        '        end if
        '    Catch ex As Exception
        '        messagebox(ex.Message)

        '    End Try

    End Sub



End Class