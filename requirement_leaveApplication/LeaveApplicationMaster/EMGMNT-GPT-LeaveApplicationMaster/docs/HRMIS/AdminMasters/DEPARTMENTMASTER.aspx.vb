Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class DEPARTMENTMASTER
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        'Session("_edept ") = "9000"
        'Session("dept") = "9000"

        _eid = Session("empcode")
        _ename = Session("_ename ")
        _edept = Session("_edept ")

        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (19)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
    End Sub


    Protected Sub Bdept_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdept_save.Click
        ' ###################### insert record to department table #################

        Dim pid, rno, did As Integer
        pid = 0
        did = 0

        InsertDepartment(Tdeptcode.Text, TDeptname.Text, dJhead.SelectedValue, Convert.ToString(Ddirect.SelectedValue), Convert.ToString(dsection.SelectedValue), tdabbrevation.Text, pid, did, _eid)
        If recstatus = True Then
            MessageBox("Record Saved successfully")
            ' pdept.Visible = True
            Tdeptcode.Text = ""
            TDeptname.Text = ""
            tdabbrevation.Text = ""
        Else
            lblmsg.Text = MyerrorMsg
        End If
        grddepartment.DataBind()

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class