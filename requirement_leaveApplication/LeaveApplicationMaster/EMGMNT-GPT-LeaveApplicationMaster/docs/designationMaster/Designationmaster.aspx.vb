Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class Designationmaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

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
            MyScreenId = (21)
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
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        getpositionID()
        Dim id, rno As Integer
        rno = 0
        If posid < 0 Then
            id = 1
        Else
            id = posid + 1
        End If
        ' _eid = "014543"
        If Tdesigctq.Text = "" Then
            Tdesigctq.Text = 0
        End If
        If Tdesigins.Text = "" Then
            Tdesigins.Text = 0
        End If
        InsertDesignation(Tdesignation.Text, Convert.ToString(Ddesiglevel.SelectedItem), Tdesigcode.Text, Convert.ToString(ddesigprobation.SelectedItem), Convert.ToString(TdesiginsCatagory.SelectedItem), Tdesigins.Text, Tdesigctq.Text, id, _eid)

        If recstatus = True Then
            MessageBox("Record Saved successfully")
            'pdesig.Visible = True
            Tdesignation.Text = ""
            Tdesigcode.Text = ""
            Tdesigins.Text = ""
            Tdesigctq.Text = ""
        ElseIf recstatus = False Then
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red

        End If
        pnldesignation.Visible = True
        grddesignation.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub Bclear_desig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bclear_desig.Click
        ClrDesigCtrl()
        grddesignation.DataBind()
        pnldesignation.Visible = True
    End Sub
    ' ###################### function to clear controls in designation form #################
    Private Sub ClrDesigCtrl()
        Ddesiglevel.SelectedIndex = 0
        Tdesignation.Text = ""
        Tdesigcode.Text = ""
        Tdesigins.Text = ""
        TdesiginsCatagory.SelectedIndex = 0
        ddesigprobation.SelectedIndex = 0
        btnsave.Enabled = True
        Tdesignation.Enabled = True
    End Sub
End Class