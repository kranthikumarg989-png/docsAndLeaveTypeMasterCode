Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class EmployeeLicenseUpdate
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim constr As String = ConfigurationManager.ConnectionStrings("Sqlcon1").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            
            LblEmpCode.Text = Session("empcode").ToString()

            LblEmpName.Text = Session("empname").ToString()


           

        End If
    End Sub

    Private Function LicenseData(ByVal Options As String, ByVal EmpCode As String, ByVal CarNo As String, ByVal LNo As String, ByVal LExpiryDate As DateTime, ByVal RTNo As String, ByVal RTExpiryDate As DateTime, ByVal VanNo As String, ByVal VanDriverName As String, ByVal Type As String, ByVal ICNumber As String) As DataSet

        Dim ClsObj As New CRMlognetglobal
        ' Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim SqlDs As New DataSet
        Dim SqlAd As New SqlDataAdapter

        ClsObj.db_cn()
        Dim SqlCon As New SqlConnection(constr)
        ' SqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        SqlCon.Open()
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "LicenseData"
        SqlCmd.Connection = SqlCon

        SqlCmd.Parameters.Clear()
        'ByVal Options As String, bYvAL EmpCode as String, ByVal LicenseNo as String, Byval LicenseExpiryDate Date, Byval RTNo as String, RTExpiryDate as Date
        SqlCmd.Parameters.AddWithValue("@Options", Options)
        SqlCmd.Parameters.AddWithValue("@EmpCode", EmpCode)
        SqlCmd.Parameters.AddWithValue("@CarNo", CarNo)
        SqlCmd.Parameters.AddWithValue("@LNo", LNo)
        SqlCmd.Parameters.AddWithValue("@LExpiryDate", LExpiryDate)
        SqlCmd.Parameters.AddWithValue("@RTNo", RTNo)
        SqlCmd.Parameters.AddWithValue("@RTExpiryDate", RTExpiryDate)
        SqlCmd.Parameters.AddWithValue("@CreatedBy", Session("empcode"))
        'SqlCmd.Parameters.AddWithValue("@VanNo", VanNo)
        SqlCmd.Parameters.AddWithValue("@VanDriverName", VanDriverName)
        SqlCmd.Parameters.AddWithValue("@Type", Type)
        SqlCmd.Parameters.AddWithValue("@ICNumber", ICNumber)




        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        SqlCon.Close()

        Return SqlDs



    End Function

   


    Protected Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            Session("cempcode") = ""
           

            If TxtCarNumber.Text.Trim.Equals("") Then
                LblMsg.ForeColor = Drawing.Color.Red
                LblMsg.Text = "Please enter car number!"
                Exit Sub
            End If

            If TxtLicenseNo.Text.Trim.Equals("") Then
                TxtLicenseNo.Text = "-"
            End If

            If TxtRoadTaxNo.Text.Trim.Equals("") Then
                TxtRoadTaxNo.Text = "-"
            End If


            Dim SqlDs1 As New DataSet
            Dim td1 As String
            td1 = TxtLicenseExpiryDate.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            If td1 < DateTime.Now Then
                LblMsg.ForeColor = Drawing.Color.Red
                LblMsg.Text = "Please check license expiry date!"
                Exit Sub
            End If

            Dim td2 As String
            td2 = TxtRoadTaxExpiryDate.Text.Trim
            Dim strdate3() As String = td2.Split("/"c)
            td2 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            If td2 < DateTime.Now Then
                LblMsg.ForeColor = Drawing.Color.Red
                LblMsg.Text = "Please check road tax expiry date!"
                Exit Sub
            End If

            SqlDs1 = New DataSet()
            SqlDs1 = LicenseData("Insert", LblEmpCode.Text, UCase(TxtCarNumber.Text.Trim.Replace(" ", "").Replace("  ", "")), UCase(TxtLicenseNo.Text.Trim.Replace(" ", "").Replace("  ", "")), td1, UCase(TxtRoadTaxNo.Text.Trim.Replace(" ", "").Replace("  ", "")), td2, "-", "-", "Employee", 0)
            LblMsg.ForeColor = Drawing.Color.Green
            LblMsg.Text = "Successfully updated!"
            Session("cempcode") = LblEmpCode.Text
            Session("rpttype") = "Employee"
            InsertHistory()
            ' Response.Redirect("EmployeeLicenseUpdate.aspx")
        Catch ex As Exception
            MessageBox(ex.ToString)
        End Try
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Public Function InsertHistory()

        Dim td1 As String
        td1 = TxtLicenseExpiryDate.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td2 As String
        td2 = TxtRoadTaxExpiryDate.Text.Trim
        Dim strdate3() As String = td2.Split("/"c)
        td2 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)


        Dim dss As New DataSet()
        Dim sda As New SqlDataAdapter()
        Dim ConnectionString As String
        '   ConnectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Hrmis;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"

        Using sqlconn As New SqlConnection(constr)
            sqlconn.Open()
            Using sqlcmd As New SqlCommand("LicenseData", sqlconn)
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandTimeout = 120
                sqlcmd.Parameters.Add(New SqlParameter("@Options", "InsertHistory"))

                sqlcmd.Parameters.AddWithValue("@EmpCode", LblEmpCode.Text)
                sqlcmd.Parameters.AddWithValue("@CarNo", UCase(TxtCarNumber.Text.Trim.Replace(" ", "").Replace("  ", "")))
                sqlcmd.Parameters.AddWithValue("@LNo", UCase(TxtLicenseNo.Text.Trim.Replace(" ", "").Replace("  ", "")))
                sqlcmd.Parameters.AddWithValue("@LExpiryDate", td1)
                sqlcmd.Parameters.AddWithValue("@RTNo", UCase(TxtRoadTaxNo.Text.Trim.Replace(" ", "").Replace("  ", "")))
                sqlcmd.Parameters.AddWithValue("@RTExpiryDate", td2)
                sqlcmd.Parameters.AddWithValue("@CreatedBy", Session("empcode"))

                sda = New SqlDataAdapter(sqlcmd)
                sda.Fill(dss)
            End Using
            sqlconn.Close()
        End Using
        Return dss
    End Function

   
  

End Class