Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class individualallocation
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim stime As String
    Dim etime As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (95)
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
        Label1.Text = ""
    End Sub

    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        empcode = txtempcode.Text
        Insertempmasterroute(empcode, DropDownList1.SelectedValue.Trim, DropDownList2.SelectedValue.Trim)
        If recstatus = True Then
            Label1.Text = "Record Added"
            txtempcode.Text = ""
            lblename.Text = ""
            lblsect.Text = ""
            lbldept.Text = ""
            lbldesig.Text = ""
            DropDownList1.SelectedValue = "-1"
            DropDownList2.SelectedValue = "-1"
        Else
            Label1.Text = MyerrorMsg & "Error!!! Cannot add Record"
        End If
        GridView1.DataBind()
    End Sub

    Protected Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
        empcode = txtempcode.Text.Trim
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString
                lbldept.Text = dr("departmentcode").ToString
                lbldesig.Text = dr("designation").ToString
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        Else
            Label1.Text = MyerrorMsg
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class