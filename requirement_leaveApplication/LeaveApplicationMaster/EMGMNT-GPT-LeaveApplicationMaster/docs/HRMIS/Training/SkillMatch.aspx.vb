Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class SkillMatch
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (153)
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
        lblmsg1.Text = ""
        lbld.Visible = "false"
    End Sub

    Protected Sub DDL2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDL2.SelectedIndexChanged
        lbld.Text = DDL2.SelectedValue
        Dim job As String
        Dim dr As DataRow
        job = DDL2.SelectedValue
        chkcodeAvail1(job)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count <> 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbldesig.Text = dr("designation").ToString
            End If
        Else
        End If

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    'Private Sub Getdeptdesig(ByVal desig)
    '    Dim result
    '    desig = RecordId
    '    Getdesvalue()
    '    result = RecordId
    'End Sub

    Protected Sub SAVESMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVESMA.Click

        messagebox(rb1.SelectedValue)

        If (rb1.SelectedValue <> "EA" And rb1.SelectedValue <> "MD" And rb1.SelectedValue = "-1") Then
            Try
                Call MyGlobal.dbSp_open("training_skillmatch")
                Cmd.Parameters.AddWithValue("@DDL1", DDL1.SelectedValue)
                Cmd.Parameters.AddWithValue("@DDL2", DDL2.SelectedValue)
                Cmd.Parameters.AddWithValue("@lbldesig", lbldesig.Text)
                Cmd.Parameters.AddWithValue("@DDL3", DDL3.SelectedValue)
                Cmd.Parameters.AddWithValue("@DDL4", DDL4.SelectedValue)

                Cmd.ExecuteNonQuery()



                lblmsg1.Text = "Table Successfully Updated !"
            Catch ex As SqlException
                messagebox(ex.Message)
                lblmsg1.Text = ex.Message
                lblmsg1.ForeColor = Drawing.Color.Green

                Exit Sub

            End Try



        ElseIf (rb1.SelectedValue = "EA" Or rb1.SelectedValue = "MD") Then

            Try
                Call MyGlobal.dbSp_open("training_smeamd")
                Cmd.Parameters.AddWithValue("@rb1", rb1.SelectedValue)
                Cmd.Parameters.AddWithValue("@DDL3", DDL3.SelectedValue)
                Cmd.Parameters.AddWithValue("@DDL4", DDL4.SelectedValue)



                Cmd.ExecuteNonQuery()

                lblmsg1.Text = "Table Successfully Updated !"
            Catch ex As SqlException
                messagebox(ex.Message)
                lblmsg1.Text = ex.Message
                lblmsg1.ForeColor = Drawing.Color.Green

                Exit Sub

            End Try

        End If


        MyGlobal.db_close()
        GridView1.DataBind()

    End Sub

    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        If rb1.SelectedValue = "EA" Then
            lbld.Text = "EA"
        ElseIf rb1.SelectedValue = "MD" Then
            lbld.Text = "MD"
        Else
            lbld.Text = ""
        End If
    End Sub

    'Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    rb1.Visible = "true"
    'End Sub
End Class