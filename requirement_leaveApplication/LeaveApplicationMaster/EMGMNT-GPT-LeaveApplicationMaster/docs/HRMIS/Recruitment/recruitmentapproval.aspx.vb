Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class recruitmentapproval
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        con = New SqlConnection(constr)
        con.Open()
        'Session("_ename") = "IT"   'for implement purpose hotcode removed
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As Date
        dt = Date.Now.ToShortDateString
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim recno As String = GridView1.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("RadioButtonList1"), RadioButtonList).SelectedValue
            Dim stsrea As String = DirectCast(GridView1.Rows(i).FindControl("reason"), TextBox).Text
            ''05-05-2014 commented below 4 lines for recruitment approval error correction
            'MyGlobal.Open_Con()
            'MyGlobal.Con_Str()
            'DS = Open_gatepass(con, DAP, 2, "update man_request set status = '" & status & "',statusreason='" & stsrea & "',approvedby='" & Session("_ename") & "',dateapproval='" & dt & "' where requisitionno = '" & recno & "'")
            'MyGlobal.db_close()
            ''#####
            ''05-05-2014
            UpdateRecruitApprovalmmsb(status, stsrea, Session("_ename"), dt, recno)
            If recstatus = True Then

            Else
                LblMsg.Text = SQLstat & "---" & MyerrorMsg
                LblMsg.ForeColor = Drawing.Color.Red
                Exit Sub
            End If
            ''#####
        Next
        GridView1.DataBind()
    End Sub
End Class