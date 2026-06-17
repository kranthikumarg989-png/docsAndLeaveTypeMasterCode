Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class contractExpListCommon
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        '  BindGridcontract()
        thisdate = Date.Now
    End Sub
    Private Sub Grdcontract_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdContract.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim APP As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Appraisal")).Trim
            Dim button As LinkButton = TryCast(e.Row.FindControl("link1"), LinkButton)
            Dim lbl As Label = TryCast(e.Row.FindControl("label2"), Label)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim


            If APP = "Y" Then
                button.Visible = True
                lbl.Visible = False
            Else
                button.Visible = False
                lbl.Visible = True
            End If

            'If status = " " Then
            '    e.Row.Cells(13).ForeColor = Drawing.Color.Yellow
            '    e.Row.Cells(13).Text = "-"
            'End If

            'If APP = "F" Then
            '    e.Row.Cells(12).Text = "Y"
            'End If

            If confirm = "C" Then
                e.Row.Cells(14).Text = "Confirm"
            ElseIf confirm = "EC" Then
                e.Row.Cells(14).Text = "Extend Contract"
            ElseIf confirm = "E" Then
                e.Row.Cells(14).Text = "Extend Probation"
            End If
        End If

    End Sub


    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim APP As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Appraisal")).Trim
            Dim button As LinkButton = TryCast(e.Row.FindControl("linkbutton2"), LinkButton)
            Dim lbl As Label = TryCast(e.Row.FindControl("label2"), Label)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim


            If APP = "Y" Then
                button.Visible = True
                lbl.Visible = False
            Else
                button.Visible = False
                lbl.Visible = True
            End If

            If confirm = "C" Then
                e.Row.Cells(14).Text = "Confirm"
            ElseIf confirm = "EC" Then
                e.Row.Cells(14).Text = "Extend Contract"
            ElseIf confirm = "E" Then
                e.Row.Cells(14).Text = "Extend Probation"
            End If
        End If
    End Sub

    Public Sub Rptappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)
        Response.Redirect("AppraisalRptstaff.aspx")
    End Sub
    Public Sub Rptappraisal_opt(ByVal sender As Object, ByVal e As CommandEventArgs)
        Response.Redirect("AppraisalRptopt.aspx")
    End Sub
End Class