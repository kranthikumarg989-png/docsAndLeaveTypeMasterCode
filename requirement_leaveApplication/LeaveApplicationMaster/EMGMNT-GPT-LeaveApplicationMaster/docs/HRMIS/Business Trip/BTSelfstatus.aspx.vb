Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class BTSelfstatus
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (48)
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

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "btstatus")).Trim
            Dim label As Label = TryCast(e.Row.FindControl("label1"), Label)
            Dim button As LinkButton = TryCast(e.Row.FindControl("LinkButton1"), LinkButton)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("LinkButton5"), LinkButton)

            If status.Trim = "scheduled" Or status.Trim = "SCHEDULED" Then
                button.Visible = True
                label.Visible = False
                button2.Visible = True

            Else
                label.Visible = True
                button.Visible = False
                button2.Visible = False

            End If

            If status.Trim = "scheduled" Or status.Trim = "SCHEDULED" Then
                ' color the background of the row yellow
                e.Row.Cells(7).ForeColor = Drawing.Color.Yellow
                ' e.Row.Cells(0).Attributes.Add("class", "statusclass")
            ElseIf status.Trim = "Approved" Or status.Trim = "APPROVED" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Green
            ElseIf status.Trim = "Rejected" Or status.Trim = "REJECTED" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub
    Public Sub getBTData(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim recno
        recno = e.CommandArgument
        Session("bteditnum") = recno
        Response.Redirect("btform.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Public Sub btcancel(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            cancelBT(e.CommandArgument)
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class