Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class ProbContractExpList
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        ' Session("empcode") = "014623"
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
            Dim button As LinkButton = TryCast(e.Row.FindControl("linkbutton1"), LinkButton)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("linkbutton2"), LinkButton)
            Dim lbl As Label = TryCast(e.Row.FindControl("lblappraisal"), Label)
            Dim lbl2 As Label = TryCast(e.Row.FindControl("label2"), Label)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim
            If lbl2.Text <> "" Then
                Session("employeecode") = lbl2.Text
            Else
                Session("empoyeecode") = button2
            End If

            If status = "EA" Or status = "A" Then
                button.Visible = True
            Else
                button.Visible = False
            End If

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
    Public Sub Printappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)

        Dim ltrname
        ltrname = e.CommandArgument
        Session("LtrPrint") = ltrname

        If LTrim(RTrim(ltrname)) = "C" Then
            Response.Redirect("~\hrmis\CMG\ChangeSectDeptPromEtc.aspx")
        ElseIf LTrim(RTrim(ltrname)) = "EC" Then
            Response.Redirect("~\hrmis\CMG\ChangeSectDeptPromEtc.aspx")
        ElseIf LTrim(RTrim(ltrname)) = "E" Then
            Response.Redirect("~\hrmis\CMG\ProbTrialPeriodExt.aspx")
        End If

    End Sub
    Public Sub Rptappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)
        'Response.Redirect("AppraisalRptstaff.aspx")
        Dim en
        en = e.CommandArgument
        Session("employeecode") = en
        Response.Redirect("StaffAppraisalFinalReport.aspx")

    End Sub
    Public Sub Rptappraisal_opt(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim en
        en = e.CommandArgument
        Session("ecodee") = en
        Response.Redirect("operatorAppraisalFinalReport.aspx")
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim button As LinkButton = TryCast(e.Row.FindControl("linkbutton1"), LinkButton)
            Dim lbl2 As Label = TryCast(e.Row.FindControl("lblopt"), Label)
            Dim lbl As Label = TryCast(e.Row.FindControl("lblappraisalo"), Label)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("linkbuttonopt"), LinkButton)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim

            If status = "EA" Or status = "A" Then
                button.Visible = True
            Else
                button.Visible = False
            End If
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
    Protected Sub HODAPP(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim GridProbation As GridView
        For i As Integer = 0 To GridProbation.Rows.Count - 1
            Dim emp As String = DirectCast(GridProbation.Rows(i).FindControl("label2"), Label).Text
            Dim stats As String = DirectCast(GridProbation.Rows(i).FindControl("STAT"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If stats = "C" Then
                DS = emanagement.globalinfo.Open_empappraisal(Con, DAP, 2, "update emp_appraisalnote set status ='C' where empcode = '" & emp & "'")

                MyGlobal.db_close()
            End If
        Next
        GridProbation.DataBind()
    End Sub

    Protected Sub HODAPP2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim emp As String = DirectCast(GridView1.Rows(i).FindControl("lblopt"), Label).Text
            Dim stats As String = DirectCast(GridView1.Rows(i).FindControl("STAT2"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If stats = "C" Then
                DS = emanagement.globalinfo.Open_empappraisal(Con, DAP, 2, "update emp_appraisalnote set status ='C' where empcode = '" & emp & "'")

                MyGlobal.db_close()
            End If
        Next
        GridView1.DataBind()
    End Sub
End Class