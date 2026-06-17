Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class clinicpassqueue
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim _from, _to
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (44)
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


        _from = DateTime.Now.AddMonths(-1)
        Dim days = System.DateTime.DaysInMonth(Year(_from), Month(_from))

        _from = Month(_from) & "/01/" & Year(_from)
        '  _to = Month(_from) & "/" & days & "/" & Year(_from)
        _to = DateTime.Now



        If IsPostBack = False Then
            Session("cltype") = ""
            Session("cliniceditnum") = ""
        End If
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            If status = "A" Then
                '  e.Row.Cells(9).ForeColor = Drawing.Color.Green
                e.Row.Cells(3).Text = "APPROVED"
            End If
        End If
    End Sub
    Public Sub getclinicData(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim appno
        appno = e.CommandArgument
        Session("cltype") = ""
        Session("cliniceditnum") = appno
        Response.Redirect("admin.aspx")
    End Sub
    Public Sub getclinichistory(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim emp
        emp = e.CommandArgument
        lblemp.Text = emp
        pnlhistory.Visible = True
        leavempe.Show()
    End Sub

    Protected Sub SqlDataSource1_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(1).Value = _from
        e.Command.Parameters(2).Value = _to
    End Sub

    
    Protected Sub ClinicPassLinkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClinicPassLinkBtn.Click
        Session("cltype") = "NoEntry"
        Session("cliniceditnum") = "0"
        Response.Redirect("Admin.aspx")
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        If TxtFrom1.Text = "" Then
            Messagebox("Please Selet From Date!")
            Exit Sub
        End If

        If TxtTo1.Text = "" Then
            MessageBox("Please Selet TO Date!")
            Exit Sub
        End If

        Session("cl_Option1") = "-"
        Session("cl_date1") = TxtFrom1.Text
        Session("cl_date2") = TxtTo1.Text
        Response.Redirect("CPassNoEntryReport.aspx")
    End Sub
End Class