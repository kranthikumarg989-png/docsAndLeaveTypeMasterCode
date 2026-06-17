Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class checkOutPrintNew
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
        If (Not Page.IsPostBack()) Then
            txtdatepicker.Text = System.DateTime.Now.ToString("dd/MM/yyyy")
            ddlbatchno.Visible = False
            btnPrint.Visible = False
            batchname.Visible = False
            Session("WPEmp") = Nothing
        End If
    End Sub



    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim type As String = Request.QueryString("Type")
        Dim ID As String = ""
        'Dim chck As Date = txtdatepicker.Text
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "chckoutprint")
                sqlCmd.Parameters.AddWithValue("@chkoutdate", txtdatepicker.Text)
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
                If (ds.Tables(0).Rows.Count > 0) Then
                    ddlbatchno.DataTextField = "batchno"
                    ddlbatchno.DataValueField = "batchno"
                    ddlbatchno.DataSource = ds
                    ddlbatchno.DataBind()
                    ddlbatchno.Visible = True
                    btnPrint.Visible = True
                    batchname.Visible = True
                Else
                    ddlbatchno.Visible = False
                    btnPrint.Visible = False
                    batchname.Visible = False
                End If
                sqlCon.Close()
            End Using
        End Using

        'Dim s As String = "window.open('checkoutprint.aspx', 'popup_window', 'width=900,height=600,left=10,top=10,resizable=yes,scrollbars=yes');"
        'ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim s As String = "window.open('checkoutprint.aspx?checkoutdate=" + txtdatepicker.Text + "&batchno=" + ddlbatchno.SelectedItem.Value.ToString() + "', 'popup_window', 'width=900,height=600,left=10,top=10,resizable=yes,scrollbars=yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

    End Sub

End Class
