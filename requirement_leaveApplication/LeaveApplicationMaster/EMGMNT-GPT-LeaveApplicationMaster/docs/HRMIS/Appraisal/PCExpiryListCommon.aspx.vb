Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PCExpiryListCommon
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        'Session("empcode") = "014623"
        thisdate = Date.Now
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Private Sub GridProbation_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridProbation.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("linkbutton2"), LinkButton)
            Dim lbl As Label = TryCast(e.Row.FindControl("lblappraisal"), Label)
            Dim lbl2 As Label = TryCast(e.Row.FindControl("label2"), Label)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim


   
            If lbl.Text = "Y" Then
                button2.Visible = True
                lbl2.Visible = False
            Else
                button2.Visible = False
                lbl2.Visible = True
            End If

            If confirm = "C" Then
                e.Row.Cells(11).Text = "Confirm"
            ElseIf confirm = "EC" Then
                e.Row.Cells(11).Text = "Extend Contract"
            ElseIf confirm = "E" Then
                e.Row.Cells(11).Text = "Extend Probation"
            End If

        End If
    End Sub

    Public Sub Rptappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)
        Response.Redirect("AppraisalRptstaff.aspx")
    End Sub
    Public Sub Rptappraisal_opt(ByVal sender As Object, ByVal e As CommandEventArgs)
        Response.Redirect("AppraisalRptopt.aspx")
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
             Dim lbl2 As Label = TryCast(e.Row.FindControl("lblopt"), Label)
            Dim lbl As Label = TryCast(e.Row.FindControl("lblappraisalo"), Label)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("linkbuttonopt"), LinkButton)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim

     
            If lbl.Text = "Y" Then
                button2.Visible = True
                lbl2.Visible = False
            Else
                button2.Visible = False
                lbl2.Visible = True
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

    Private Sub ProbContractExpList_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        ' MessageBox("hi")
    End Sub
End Class
