Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Checkoutmemo
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
        'Dim type As String = Request.QueryString("Type")
        'hideType.Value = type
        'If (type = "Employee") Then
        '    divByEmp.Visible = True
        '    divByMonth.Visible = False
        'Else
        '    divByEmp.Visible = False
        '    divByMonth.Visible = True
        'End If
        lblMsg.Text = ""
        If (Not Page.IsPostBack()) Then
            Datetext.Text = System.DateTime.Now.ToString("dd/MM/yyyy")
            BindGrid()
        End If
    End Sub

    Sub BindGrid()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "getInCOM")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using

        If (ds.Tables(0).Rows.Count > 0) Then
            gv.DataSource = ds
            gv.Visible = True
            btnSubmit.Visible = True
            divCheckoutOn.Visible = True
            gv.DataBind()
        Else
            btnSubmit.Visible = False
            divCheckoutOn.Visible = False
            gv.Visible = False
        End If
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim ID As String = ""
        'Dim chck As Date = Datetext.Text
        Dim bno As Integer = 0
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "chckout")
                sqlCmd.Parameters.AddWithValue("@chkoutdate", Datetext.Text)
                Using readerObj As SqlDataReader = sqlCmd.ExecuteReader
                    'This will loop through all returned records 
                    While readerObj.Read
                        bno = Convert.ToInt32(readerObj("batchno"))
                        'handle returned value before next loop here
                    End While
                End Using
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)

                sqlCon.Close()
            End Using
        End Using
        bno = bno + 1

        For Each gvRow As GridViewRow In gv.Rows
            If (CType(gvRow.FindControl("chkDelete"), CheckBox).Checked) Then
                ID += ", " + gv.DataKeys(gvRow.RowIndex).Value.ToString()
                Dim strLastworking As String = CType(gvRow.FindControl("txtLastworkingDay"), TextBox).Text
                Dim strSalary As String = CType(gvRow.FindControl("txtSalary"), TextBox).Text
                Dim strSendBack As String = CType(gvRow.FindControl("txtSendBack"), TextBox).Text
                Dim strReplacement As String = CType(gvRow.FindControl("txtReplacement"), TextBox).Text
                Dim strHRPurpose As String = CType(gvRow.FindControl("txtHRPurpose"), TextBox).Text
                Using sqlCon As New SqlConnection(strCon)
                    sqlCon.Open()
                    Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                        sqlCmd.CommandType = CommandType.StoredProcedure
                        sqlCmd.Parameters.AddWithValue("@Type", "CheckoutMemo")
                        sqlCmd.Parameters.AddWithValue("@WPRNo", gv.DataKeys(gvRow.RowIndex).Value.ToString())
                        sqlCmd.Parameters.AddWithValue("@Lastworking", strLastworking)
                        sqlCmd.Parameters.AddWithValue("@Salary", strSalary)
                        sqlCmd.Parameters.AddWithValue("@SendBack", strSendBack)
                        sqlCmd.Parameters.AddWithValue("@Replacement", strReplacement)
                        sqlCmd.Parameters.AddWithValue("@HRPurpose", strHRPurpose)
                        sqlCmd.Parameters.AddWithValue("@EmpCode", Session("EmpCode").ToString())
                        sqlCmd.Parameters.AddWithValue("@chkoutdate", Datetext.Text)
                        sqlCmd.Parameters.AddWithValue("@batchno", bno.ToString())
                        sqlCmd.ExecuteNonQuery()
                    End Using
                End Using
            End If
        Next

        lblMsg.Text = "Details updated successfully"
        BindGrid()
        'Dim s As String = "window.open('checkoutprint.aspx', 'popup_window', 'width=900,height=600,left=10,top=10,resizable=yes,scrollbars=yes');"
        'ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub
End Class
