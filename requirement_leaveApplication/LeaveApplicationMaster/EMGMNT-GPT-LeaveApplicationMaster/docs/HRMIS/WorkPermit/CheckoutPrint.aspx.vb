Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class CheckoutPrint
    Inherits System.Web.UI.Page
    Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim sqladapter As New SqlDataAdapter()
    Dim ds As New DataSet()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        If (Session("WPRNo") = Nothing) Then
            'Response.Redirect("Checkoutprint.aspx")
        End If
        'Dim chckdate As Date = Request.QueryString(0)
        lblPrintDate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")
        'Dim str As String = Session("WPRNo").ToString()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "CMDetails")
                sqlCmd.Parameters.AddWithValue("@chkoutdate", Request.QueryString("checkoutdate"))
                sqlCmd.Parameters.AddWithValue("@batchno", Request.QueryString("batchno"))
                'sqlCmd.Parameters.AddWithValue("@UIDs", Session("WPRNo").ToString())
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        gv.DataSource = ds
        gv.DataBind()
    End Sub

End Class
