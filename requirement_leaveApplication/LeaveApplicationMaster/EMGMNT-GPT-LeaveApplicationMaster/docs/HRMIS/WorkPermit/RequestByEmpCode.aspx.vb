Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class RequestByEmpCode
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
            BindGrid2()
        End If
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
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
                    sqlCmd.Parameters.AddWithValue("@Type", "Request")
                    sqlCmd.Parameters.AddWithValue("@UIDs", UID)
                    sqlCmd.ExecuteNonQuery()
                End Using
            End Using
            Session("Request") = Nothing
            BindGrid2()
            lblMsg.Text = "Details Updated Sucessfully"
        End If
    End Sub

    Protected Sub txtEmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmp.TextChanged
        AddtoTable()
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
                sqlCmd.Parameters.AddWithValue("@Type", "ExpiryDetails")
                sqlCmd.Parameters.AddWithValue("@EmpCode", txtEmp.Text)
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
        BindGrid2()
    End Sub

    Sub BindGrid2()
        Dim dt As New DataTable()
        If (Not Session("Request") Is Nothing) Then
            dt = CType(Session("Request"), DataTable)
            gv.DataSource = dt
            gv.Visible = True
            gv.DataBind()
            If (gv.Rows.Count > 0) Then
                btnSubmit.Visible = True
            Else
                btnSubmit.Visible = False
            End If
        Else
            gv.Visible = False
            btnSubmit.Visible = False
        End If
    End Sub

End Class
