Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class summondetails
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (88)
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
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        ' GetareaCode()
        Dim fd1 As String
        fd1 = txtsdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim dd1 As String
        dd1 = txtddate.Text.Trim
        Dim strdd() As String = dd1.Split("/"c)
        dd1 = strdd(1) & "/" & strdd(0) & "/" & strdd(2)

        Dim dd As Date
        dd = CDate(dd1)

        Dim pd1 As String
        pd1 = txtpdate.Text.Trim
        Dim strpd() As String = pd1.Split("/"c)
        pd1 = strpd(1) & "/" & strpd(0) & "/" & strpd(2)

        Dim pd As Date
        pd = CDate(pd1)

        Insertsummon(Convert.ToString(DropDownList1.SelectedValue.Trim), fd, dd, txtreason.Text.Trim, txtamt.Text.Trim, pd, txtname.Text.Trim, _eid)
        If recstatus = True Then
            MessageBox("summon details stored")
            txtsdate.Text = ""
            txtddate.Text = ""
            txtpdate.Text = ""
            txtreason.Text = ""
            txtname.Text = ""
            txtamt.Text = ""
        Else
            lblmsg.text = MyerrorMsg
            MessageBox("Error!!! Cannot save Data")
        End If
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

End Class