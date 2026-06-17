Imports System.Data.SqlClient
Partial Public Class Vehiclepass_Print
    Inherits System.Web.UI.Page
    Dim constr As String = ConfigurationManager.ConnectionStrings("Sqlcon1").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        If (IsPostBack = False) Then


            showgrid()


        End If
    End Sub


    Public Sub showgrid()
        Dim ds As DataSet
        Dim dt As New DataTable
        ds = getelement()
        dt = ds.Tables(0).Copy()

        If dt.Rows.Count > 0 Then
            msg.Visible = False
        Else
            msg.Visible = True


        End If




        GView1.DataSource = dt

        GView1.DataBind()
    End Sub

    Protected Sub Gview1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        'If e.CommandName = "Action" Then


        '    Dim Suppliercode As String = Convert.ToString(e.CommandArgument)




        'End If
    End Sub
    Public Function getelement()
        Dim dss As New DataSet()
        Dim sda As New SqlDataAdapter()
        Dim ConnectionString As String
        '   ConnectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Hrmis;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"

        Using sqlconn As New SqlConnection(constr)
            sqlconn.Open()
            Using sqlcmd As New SqlCommand("LicenseData", sqlconn)
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 120
                sqlcmd.Parameters.Add(New SqlParameter("@Options", "PrintDetails"))


                sda = New SqlDataAdapter(sqlcmd)
                sda.Fill(dss)
            End Using
            sqlconn.Close()
        End Using
        Return dss
    End Function

    Public Function UpdatePrintdetails(ByVal empcode As String)
        Dim dss As New DataSet()
        Dim sda As New SqlDataAdapter()
        Dim ConnectionString As String
        '   ConnectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Hrmis;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"

        Using sqlconn As New SqlConnection(constr)
            sqlconn.Open()
            Using sqlcmd As New SqlCommand("LicenseData", sqlconn)
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 120
                sqlcmd.Parameters.Add(New SqlParameter("@Options", "UpdatePrintDetails"))
                sqlcmd.Parameters.Add(New SqlParameter("@EmpCode", empcode))


                sda = New SqlDataAdapter(sqlcmd)
                sda.Fill(dss)
            End Using
            sqlconn.Close()
        End Using
        Return dss
    End Function


    Protected Sub lnkView_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim grdrow As GridViewRow = CType((CType(sender, LinkButton)).NamingContainer, GridViewRow)
        Dim empcode As String = grdrow.Cells(0).Text
       
        UpdatePrintdetails(empcode)
        Session("cempcode") = empcode
        Session("rpttype") = "Employee"
        Session("licpage") = "LicEmp"
        Response.Redirect("PrintCarSticker.aspx")


    End Sub

End Class