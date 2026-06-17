Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class jobPurposeSetting
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim revno As Integer
    Dim jpurpose As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (133)
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

        If Not IsPostBack Then
            GridView1.DataBind()
        End If

    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
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
                ClearControls()
                MessageBox("EmployeeCode doesnot Exist!!")
                lblename.Text = ""
                lblsect.Text = ""
                lbldept.Text = ""
                lbldesig.Text = ""
                txtempcode.Text = ""

            End If
        End If
        GetJobPurpose(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblpurpose.Text = dr("jobpurpose").ToString
            Else
                lblpurpose.Text = "Not Allocated"
            End If
        Else
            lblpurpose.Text = "Not Allocated"
        End If
        GetJobcode(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblcode.Text = dr("jobcode").ToString
            Else
                lblcode.Text = "Not Allocated"
            End If
        Else
            lblcode.Text = "Not Allocated"
        End If
    End Sub

    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        empcode = txtempcode.Text.Trim
        CheckRecordAvail(empcode)
        jpurpose = txtpurpose.Text.Trim
        If recstatus = False Then
            InsertJpurpose(empcode, lblcode.Text.Trim, jpurpose, empcode, "1")
        ElseIf recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                revno = dr("version").ToString
            End If
            If chbsave.Checked = True Then
                revno = revno + 1
            End If
            InsertJpurpose(empcode, lblcode.Text.Trim, jpurpose, empcode, revno)
        End If
        GridView1.DataBind()
    End Sub
    Private Sub ClearControls()
        lblename.Text = ""
        lbldept.Text = ""
        lblsect.Text = ""
        lbldesig.Text = ""
        lblcode.Text = ""
        lblpurpose.Text = ""
        txtpurpose.Text = ""
    End Sub
End Class