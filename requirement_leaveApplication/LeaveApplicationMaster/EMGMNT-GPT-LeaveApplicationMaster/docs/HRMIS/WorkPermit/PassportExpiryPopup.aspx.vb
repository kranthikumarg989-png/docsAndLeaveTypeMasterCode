Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Partial Class PassportExpiryPopup
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
        If (Not IsPostBack()) Then
            BindGrid()
        End If
    End Sub
    Sub BindGrid()
        Dim str As String
        str = Request.QueryString("id")
        Dim strArray(2) As String
        strArray = str.Split("-")
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_passportdetail_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "ExpiryDetails")
                sqlCmd.Parameters.Add("@ExpMonth", strArray(0).Trim())
                sqlCmd.Parameters.Add("@ExpYear", strArray(1).Trim())
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        gv.DataSource = ds
        gv.DataBind()
        
    End Sub
    Protected Sub gv_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv.RowCommand
        Dim ID As String = ""
        If (e.CommandName = "btnDelete") Then
            For Each gvRow As GridViewRow In gv.Rows
                If (CType(gvRow.FindControl("chkDelete"), CheckBox).Checked) Then
                    ID += "," + gv.DataKeys(gvRow.RowIndex).Value.ToString()
                End If
            Next
            Using sqlCon As New SqlConnection(strCon)
                sqlCon.Open()
                Using sqlCmd As New SqlCommand("sp_passportdetail_in", sqlCon)
                    sqlCmd.CommandType = CommandType.StoredProcedure
                    sqlCmd.Parameters.AddWithValue("@Type", "Request")
                    sqlCmd.Parameters.AddWithValue("@UIDs", ID)
                    sqlCmd.ExecuteNonQuery()
                End Using
            End Using
            'lblMsg.Text = "Details submitted successfully"
            BindGrid()
        End If
    End Sub
End Class
