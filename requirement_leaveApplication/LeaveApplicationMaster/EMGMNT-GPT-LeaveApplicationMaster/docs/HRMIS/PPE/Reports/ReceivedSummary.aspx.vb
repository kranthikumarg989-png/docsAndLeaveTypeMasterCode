Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Data.SqlClient
Partial Public Class ReceivedSummary1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim dtCommon As DataTable = New DataTable()
    Dim drCommon As SqlDataReader
    Dim connection As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection = ConfigurationManager.ConnectionStrings("Sqlcon1").ConnectionString
        If IsPostBack = False Then
            '------------- Check Access Rights ------------
            If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
                MyScreenId = (367)
                If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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
            '---------- End ---------------------------
            TbDepartment.Visible = False
            LoadDepartment()
        End If
    End Sub

    Protected Sub rbSearchList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSearchList.SelectedIndexChanged
        If rbSearchList.SelectedValue = "All" Then
            TbDepartment.Visible = False
            LoadDepartment()
        Else
            TbDepartment.Visible = True
        End If
    End Sub


    Protected Sub CommonDrDt(ByVal strQuery As String)
        Dim con As SqlConnection = New SqlConnection(connection)
        dtCommon = New DataTable()
        '******* 
        Dim cmdMailId As SqlCommand = New SqlCommand(strQuery, con)
        con.Open()
        drCommon = cmdMailId.ExecuteReader()
        dtCommon.Load(drCommon)
        con.Close()
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub LoadDepartment()
        Dim dtDept As DataTable = New DataTable()
        Dim strSpName As String = "SP_PPE_Department"
        CommonDrDt(strSpName)
        dtDept = dtCommon
        ddlDepartment.DataSource = dtDept
        ddlDepartment.DataTextField = "DeptCodeName"
        ddlDepartment.DataValueField = "departmentcode"
        ddlDepartment.DataBind()
        ddlDepartment.Items.Insert(0, "--Select--")
        ddlDepartment.Items(0).Value = "-1"
    End Sub

    Protected Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        TbDepartment.Visible = False
        rbSearchList.SelectedValue = "All"
        txtFrom.Text = ""
        txtTo.Text = ""
        LoadDepartment()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtFrom.Text <> "" And txtTo.Text <> "" Then
            Dim strdept As String
            If ddlDepartment.SelectedValue = "-1" Then
                strdept = ""
            Else
                strdept = ddlDepartment.SelectedValue
            End If
            Dim strScreenId As String = "RS"
            Response.Redirect(String.Format("Income_Stock_Viewer.aspx?FromDate={0}&ToDate={1}&Dept={2}&ScreenId={3}", txtFrom.Text, txtTo.Text, strdept, strScreenId))
        Else
            MessageBox("Select FromDate and ToDate")
            Exit Sub
        End If
    End Sub
End Class