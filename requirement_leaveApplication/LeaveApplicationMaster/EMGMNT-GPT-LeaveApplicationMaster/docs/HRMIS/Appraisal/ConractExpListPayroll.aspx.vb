Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ConractExpListPayroll
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode
    Dim thisdate As Date
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        thisdate = Date.Now
    End Sub
    Private Sub Grdcontract_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdContract.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim APP As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Appraisal")).Trim
            Dim button As LinkButton = TryCast(e.Row.FindControl("link1"), LinkButton)
            Dim lbl As Label = TryCast(e.Row.FindControl("label2"), Label)
            Dim pbutton As LinkButton = TryCast(e.Row.FindControl("link2"), LinkButton)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim

            If lbl.Text <> "" Then
                Session("employeecode") = lbl.Text
            Else
                Session("empoyeecode") = button
            End If

            If status = "EA" Or status = "A" Then
                pbutton.Visible = True
            Else
                pbutton.Visible = False
            End If

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
            Dim pbutton As LinkButton = TryCast(e.Row.FindControl("linkbutto"), LinkButton)
            Dim confirm As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "confirmd")).Trim

            If status = "EA" Or status = "A" Then
                pbutton.Visible = True
            Else
                pbutton.Visible = False
            End If

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
    Public Sub Printappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim ltrname
        ltrname = e.CommandArgument
        Session("LtrPrint") = ltrname

        If LTrim(RTrim(ltrname)) = "C" Then
            Response.Redirect("~\hrmis\CMG\ChangeSectDeptPromEtc.aspx")
        ElseIf LTrim(RTrim(ltrname)) = "EC" Then
            Response.Redirect("~\hrmis\CMG\ChangeSectDeptPromEtc.aspx")
        ElseIf LTrim(RTrim(ltrname)) = "E" Then

        End If
    End Sub

    Public Sub Rptappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)
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


    Protected Sub HODAPP(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim GrdContract As GridView
        For i As Integer = 0 To GrdContract.Rows.Count - 1
            Dim emp As String = DirectCast(GrdContract.Rows(i).FindControl("label2"), Label).Text
            Dim stats As String = DirectCast(GrdContract.Rows(i).FindControl("STAT"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            If stats = "C" Then
                DS = emanagement.globalinfo.Open_empappraisal(Con, DAP, 2, "update emp_appraisalnote set status ='C' where empcode = '" & emp & "'")
                MyGlobal.db_close()
            End If
        Next
        GrdContract.DataBind()
    End Sub

    Protected Sub HODAPP2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim emp As String = DirectCast(GridView1.Rows(i).FindControl("label2"), Label).Text
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