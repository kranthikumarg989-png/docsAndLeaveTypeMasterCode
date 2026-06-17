Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class sectionmaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        'Session("empcode") = "014543"
        'Session("_edept ") = "9000"
        'Session("dept") = "9000"

        _eid = Session("empcode")
        _ename = Session("_ename ")
        _edept = Session("_edept ")

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (20)
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

        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"
    End Sub

    Protected Sub bsave_section_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsave_section.Click
        ' ###################### insert record to Section table #################

        Dim acode, pcode As String
        acode = ""
        pcode = ""
        InsertSection(Tscode.Text, Tsname.Text, Convert.ToString(Dsdeptcode.SelectedValue), Convert.ToString(Dsdeptcode.SelectedValue), Convert.ToString(dsaqis.SelectedValue), acode, pcode, _eid, Date.Now)
        If recstatus = True Then
            MessageBox("Record Saved successfully")
            '   psection.Visible = True
            Tscode.Text = ""
            Tsname.Text = ""
        ElseIf recstatus = False Then
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class