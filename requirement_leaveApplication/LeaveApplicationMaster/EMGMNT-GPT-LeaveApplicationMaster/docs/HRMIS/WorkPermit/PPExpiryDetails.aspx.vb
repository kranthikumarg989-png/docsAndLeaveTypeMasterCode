Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Partial Class PPExpiryDetails
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
        If (Not IsPostBack()) Then
            BindGrid()
        End If
    End Sub
    Sub BindGrid()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_passportdetail_in", sqlCon)
                sqlCmd.Parameters.AddWithValue("@Type", "Expiry")
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        gv.DataSource = ds
        gv.DataBind()
    End Sub
End Class

