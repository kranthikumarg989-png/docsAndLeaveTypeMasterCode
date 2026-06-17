Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Partial Class WorkPermitOut
    Inherits System.Web.UI.Page
    Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim sqladapter As New SqlDataAdapter()
    Dim ds As New DataSet()
    Dim ds2 As New DataSet()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        lblMsg.Text = ""
        If (Not Page.IsPostBack()) Then
            Session("Request") = Nothing
            BindStatus()
            BindEmpCode()
            BindGrid()
        End If
    End Sub
    Sub AddtoTable()
        Dim dtdr As DataRow
        Dim dt As New DataTable
        dt.Columns.Add("RNo")
        dt.Columns.Add("Month")
        dt.Columns.Add("Barcode")
        dt.Columns.Add("empcode")
        dt.Columns.Add("empname")
        dt.Columns.Add("department")
        dt.Columns.Add("section")
        dt.Columns.Add("DateofHire")
        dt.Columns.Add("Permitexpiry")
        dt.Columns.Add("Yrs")
        dt.Columns.Add("arriveddate")
        dt.Columns.Add("workpermitno")
        dt.Columns.Add("KDRefNo")
        dt.Columns.Add("MonthofExpiry")
        dt.Columns.Add("passportno")
        dt.Columns.Add("ppexpirydate")
        dt.Columns.Add("KDNApproval")
        If (Not Session("Request") Is Nothing) Then
            dt = CType(Session("Request"), DataTable)
        End If

        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "getWPbyBarCode_issue")
                sqlCmd.Parameters.AddWithValue("@BarCode", txtBarcode.Text)
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using

        Dim isAvail As Boolean = False
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim rno As String = dr("rno").ToString()
            For Each dr2 As DataRow In dt.Rows
                If (dr2("rno") = rno) Then
                    isAvail = True
                    Exit For
                End If
            Next
            If (Not isAvail) Then
                dtdr = dt.NewRow
                dtdr("rno") = dr("rno").ToString()
                dtdr("Month") = dr("Month").ToString()
                dtdr("Barcode") = dr("Barcode").ToString()
                dtdr("empcode") = dr("empcode").ToString()
                dtdr("empname") = dr("empname").ToString()
                dtdr("department") = dr("department").ToString()
                dtdr("section") = dr("section").ToString()
                dtdr("DateofHire") = dr("DateofHire").ToString()
                dtdr("Permitexpiry") = dr("Permitexpiry").ToString()
                dtdr("Yrs") = dr("Yrs").ToString()
                dtdr("arriveddate") = dr("arriveddate").ToString()
                dtdr("workpermitno") = dr("workpermitno").ToString()
                dtdr("KDRefNo") = dr("KDRefNo").ToString()
                dtdr("MonthofExpiry") = dr("MonthofExpiry").ToString()
                dtdr("passportno") = dr("passportno").ToString()
                dtdr("ppexpirydate") = dr("ppexpirydate").ToString()
                dtdr("KDNApproval") = dr("KDNApproval").ToString()
                dt.Rows.Add(dtdr)
            End If
        Next
        Session("Request") = dt
        BindGrid()
    End Sub

    Protected Sub txtBarcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        AddtoTable()
        txtBarcode.Text = ""
    End Sub

    Protected Sub gv_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv.RowCommand
        Dim dt As New DataTable()
        If (e.CommandName = "Remove") Then
            If (Not Session("Request") Is Nothing) Then
                dt = CType(Session("Request"), DataTable)
            End If
            For Each dr2 As DataRow In dt.Rows
                If (dr2("rno") = e.CommandArgument.ToString()) Then
                    dt.Rows.Remove(dr2)
                    Exit For
                End If
            Next
        End If
        BindGrid()
    End Sub

    'Sub BindGrid()
    '    Dim dt As New DataTable()
    '    If (Not Session("Request") Is Nothing) Then
    '        dt = CType(Session("Request"), DataTable)
    '        gv.DataSource = dt
    '        gv.Visible = True
    '        gv.DataBind()
    '    Else
    '        gv.Visible = False
    '    End If
    '    hideCount.Value = dt.Rows.Count().ToString()
    'End Sub

    Sub BindGrid()
        gv.Visible = True
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "InRequest")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        gv.DataSource = ds
        gv.DataBind()

        'Change the backcolor for selected items...
        If (Not Session("Request") Is Nothing) Then
            Dim dt As New DataTable()
            dt = CType(Session("Request"), DataTable)
            For Each gvRow As GridViewRow In gv.Rows
                For Each dr2 As DataRow In dt.Rows
                    If (dr2("rno").ToString() = gv.DataKeys(gvRow.RowIndex).Value.ToString()) Then
                        gvRow.BackColor = Drawing.ColorTranslator.FromHtml("#357CA5")
                        Exit For
                    End If
                Next
            Next
            hideCount.Value = dt.Rows.Count().ToString()
        Else
            hideCount.Value = ""
        End If
        
    End Sub

    Sub BindStatus()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "getWPStatus")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        ddlStatus.DataTextField = "Status"
        ddlStatus.DataValueField = "Code"
        ddlStatus.DataSource = ds
        ddlStatus.DataBind()
        ddlStatus.SelectedValue = "RP"
    End Sub

    Sub BindEmpCode()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_EmpMaster_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "GetAll")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        ddlEmpCode.DataTextField = "empcode"
        ddlEmpCode.DataValueField = "empcode"
        ddlEmpCode.DataSource = ds
        ddlEmpCode.DataBind()
        ddlEmpCode.Items.Insert(0, "Select")
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (Not Session("Request") Is Nothing) Then
            Dim UID As String = ""
            Dim dt As New DataTable()
            dt = CType(Session("Request"), DataTable)
            For Each dr2 As DataRow In dt.Rows
                UID += dr2("rno").ToString() + ","
            Next

            Using sqlCon As New SqlConnection(strCon)
                sqlCon.Open()
                Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                    sqlCmd.CommandType = CommandType.StoredProcedure
                    sqlCmd.Parameters.AddWithValue("@Type", "Issue")
                    sqlCmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue)
                    sqlCmd.Parameters.AddWithValue("@IssuedOn", txtReceivedDate.Text)
                    sqlCmd.Parameters.AddWithValue("@EmpCode", ddlEmpCode.SelectedValue)
                    sqlCmd.Parameters.AddWithValue("@UIDs", UID)
                    sqlCmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text)
                    sqlCmd.ExecuteNonQuery()
                End Using
            End Using
            lblMsg.Text = "Details Updated Sucessfully"
        End If
        Session("Request") = Nothing
        BindGrid()
    End Sub
End Class
