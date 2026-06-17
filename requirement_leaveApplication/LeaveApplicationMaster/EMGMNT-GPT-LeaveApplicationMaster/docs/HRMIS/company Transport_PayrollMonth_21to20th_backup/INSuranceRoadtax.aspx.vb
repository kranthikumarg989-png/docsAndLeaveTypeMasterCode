Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class INSuranceRoadtax
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (86)
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
        _eid = Session("empcode")
    End Sub

    Protected Sub ddlvno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlvno.SelectedIndexChanged
        Try
            Getvmdetails1(ddlvno.SelectedValue.Trim)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    lblvmodel.Text = dr("model").ToString
                    lbldate.Text = Format(Convert.ToDateTime(dr("datepurchase")), "dd/MM/yy")
                    lblchasis.Text = dr("casisno").ToString
                    lblcolor.Text = dr("colour").ToString
                    lblyear.Text = dr("myear").ToString
                End If
            Else
                lblmsg.text = MyerrorMsg
            End If
        Catch ex As Exception
            Messagebox(ex.Message)
        End Try
    End Sub

    Protected Sub bvisave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bvisave.Click
        Dim rval As String
        rval = RadioButtonList1.SelectedValue.Trim
        Dim fd1 As String
        fd1 = TXTFROM.Text

        Dim strdate() As String
        strdate = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtto.Text

        Dim strdate1() As String
        strdate1 = td1.Split("/"c)
        td1 = strdate1(1) & "/" & strdate1(0) & "/" & strdate1(2)

        Dim td As Date
        td = CDate(td1)

        If rval = "RT" Then
            InsertRoadTax(ddlvno.SelectedValue.Trim, fd, td, txtamt.Text.Trim, _eid)
            grdtax.DataBind()
        ElseIf rval = "I" Then
            InsertInsurance(ddlvno.SelectedValue.Trim, fd, td, txtamt.Text.Trim, _eid)
            grdins.DataBind()
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class