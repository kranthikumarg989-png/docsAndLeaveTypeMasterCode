Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class UpdateLicenseInfo
    Inherits System.Web.UI.Page

    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Dim SqlDs1 As New DataSet
            SqlDs1 = New DataSet()
            SqlDs1 = LicenseData("EmpDetails", 0, 0, 0, DateTime.Now, 0, DateTime.Now, "-", "-", "-", 0)
            CmbEmpCode.DataValueField = "EmpCode"
            CmbEmpCode.DataTextField = "ECName"
            CmbEmpCode.DataSource = SqlDs1.Tables(0)
            CmbEmpCode.DataBind()

            CmbEmpCode.Items.Insert(0, "-Select-")


            SqlDs1 = New DataSet()
            SqlDs1 = LicenseData("SupplierDetails", 0, 0, 0, DateTime.Now, 0, DateTime.Now, "-", "-", "-", 0)
            CmbSupplier.DataValueField = "SupplierCode"
            CmbSupplier.DataTextField = "SName"
            CmbSupplier.DataSource = SqlDs1.Tables(0)
            CmbSupplier.DataBind()

            CmbSupplier.Items.Insert(0, "-Select-")

        End If
    End Sub


    Private Function LicenseData(ByVal Options As String, ByVal EmpCode As String, ByVal CarNo As String, ByVal LNo As String, ByVal LExpiryDate As DateTime, ByVal RTNo As String, ByVal RTExpiryDate As DateTime, ByVal VanNo As String, ByVal VanDriverName As String, ByVal Type As String, ByVal ICNumber As String) As DataSet

        Dim ClsObj As New CRMlognetglobal
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim SqlDs As New DataSet
        Dim SqlAd As New SqlDataAdapter

        ClsObj.db_cn()

        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
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

    Protected Sub CmbEmpCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEmpCode.SelectedIndexChanged
        LblMsg.Text = ""
        LblEmpCode.Text = CmbEmpCode.SelectedValue
        LblEmpName.Text = CmbEmpCode.SelectedItem.Text.Substring(7)

        Dim SqlDs1 As New DataSet
        SqlDs1 = New DataSet()
        SqlDs1 = LicenseData("Select", LblEmpCode.Text, 0, 0, DateTime.Now, 0, DateTime.Now, "-", "-", "-", 0)

        If SqlDs1.Tables(0).Rows.Count >= 1 Then
            TxtCarNumber.Text = SqlDs1.Tables(0).Rows(0).Item(1)
            TxtLicenseNo.Text = SqlDs1.Tables(0).Rows(0).Item(2)
            TxtLicenseExpiryDate.Text = SqlDs1.Tables(0).Rows(0).Item(3)
            TxtRoadTaxNo.Text = SqlDs1.Tables(0).Rows(0).Item(4)
            TxtRoadTaxExpiryDate.Text = SqlDs1.Tables(0).Rows(0).Item(5)
        End If

    End Sub

    
    Protected Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            Session("cempcode") = ""
            If CmbEmpCode.SelectedIndex = 0 Then
                LblMsg.ForeColor = Drawing.Color.Red
                LblMsg.Text = "Please select employee code!"
                Exit Sub
            End If

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
            Session("licpage") = "LicMaster"
            Response.Redirect("PrintCarSticker.aspx")
        Catch ex As Exception
            MessageBox(ex.ToString)
        End Try
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Rbtn1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtn1.CheckedChanged
        If Rbtn1.Checked = True Then
            tbl1.Visible = True
            tbl2.Visible = False
        Else
            tbl1.Visible = False
        End If

    End Sub

    Protected Sub Rbtn2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtn2.CheckedChanged
        If Rbtn2.Checked = True Then
            tbl2.Visible = True
            tbl1.Visible = False
        Else
            tbl2.Visible = False
        End If

    End Sub

    Protected Sub BtnUpdate1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate1.Click
        Try
            Session("cempcode") = ""

            If CmbSupplier.SelectedIndex = 0 Then
                LblMsg2.ForeColor = Drawing.Color.Red
                LblMsg2.Text = "Please select supplier!"
                Exit Sub
            End If

            If TxtVanNumber.Text.Trim.Equals("") Then
                LblMsg2.ForeColor = Drawing.Color.Red
                LblMsg2.Text = "Please enter van number!"
                Exit Sub
            End If

            If TxtLicenseNo1.Text.Trim.Equals("") Then
                TxtLicenseNo1.Text = "-"
            End If

            If TxtRoadTaxNo1.Text.Trim.Equals("") Then
                TxtRoadTaxNo1.Text = "-"
            End If

            If TXTICNO.Text.Trim.Equals("") Then
                LblMsg2.ForeColor = Drawing.Color.Red
                LblMsg2.Text = "Please enter IC Number of the driver!"
                Exit Sub
            End If

            Dim SqlDs1 As New DataSet
            Dim td1 As String
            td1 = TxtLicenseExpiryDate1.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            If td1 < DateTime.Now Then
                LblMsg2.ForeColor = Drawing.Color.Red
                LblMsg2.Text = "Please check license expiry date!"
                Exit Sub
            End If

            Dim td2 As String
            td2 = TxtRoadTaxExpiryDate1.Text.Trim
            Dim strdate3() As String = td2.Split("/"c)
            td2 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            If td2 < DateTime.Now Then
                LblMsg2.ForeColor = Drawing.Color.Red
                LblMsg2.Text = "Please check road tax expiry date!"
                Exit Sub
            End If

            SqlDs1 = New DataSet()
            SqlDs1 = LicenseData("Insert", UCase(LblSupplierCode.Text.Trim), UCase(TxtVanNumber.Text.Trim.Replace(" ", "").Replace("  ", "")), UCase(TxtLicenseNo.Text.Trim.Replace(" ", "").Replace("  ", "")), td1, UCase(TxtRoadTaxNo.Text.Trim.Replace(" ", "").Replace("  ", "")), td2, TxtVanNumber.Text, UCase(TxtDriverName.Text), "Supplier", TXTICNO.Text.Trim)
            LblMsg2.ForeColor = Drawing.Color.Green
            LblMsg2.Text = "Successfully updated!"
            Session("cempcode") = UCase(TxtVanNumber.Text.Trim.Replace(" ", "").Replace("  ", ""))
            Session("rpttype") = "Supplier"
            Session("licpage") = "LicMaster"
            Response.Redirect("PrintCarSticker.aspx")
        Catch ex As Exception
            MessageBox(ex.ToString)
        End Try
    End Sub

    Protected Sub CmbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSupplier.SelectedIndexChanged
        LblMsg.Text = ""
        LblSupplierCode.Text = CmbSupplier.SelectedValue
        LblSupplierName.Text = CmbSupplier.SelectedItem.Text.Substring(1, CmbSupplier.SelectedItem.Text.IndexOf("[") - 1)

        Dim SqlDs1 As New DataSet
        SqlDs1 = New DataSet()
        SqlDs1 = LicenseData("VanNo", UCase(LblSupplierCode.Text.Trim), 0, 0, DateTime.Now, 0, DateTime.Now, 0, 0, "-", 0)

        CMBVanNo.DataValueField = "CarNo"
        CMBVanNo.DataTextField = "CarNo"
        CMBVanNo.DataSource = SqlDs1.Tables(0)
        CMBVanNo.DataBind()
        CMBVanNo.Items.Insert(0, "-Select-")
    End Sub

    Protected Sub CMBVanNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBVanNo.SelectedIndexChanged

        If CMBVanNo.SelectedIndex = 0 Then
            TxtVanNumber.Enabled = True
            TxtVanNumber.Text = ""
            TxtLicenseNo1.Text = ""
            TxtLicenseExpiryDate1.Text = ""
            TxtRoadTaxNo1.Text = ""
            TxtRoadTaxExpiryDate1.Text = ""
            TxtDriverName.Text = ""
            TXTICNO.Text = ""
        Else
            TxtVanNumber.Enabled = False
            Dim SqlDs1 As New DataSet
            SqlDs1 = New DataSet()
            SqlDs1 = LicenseData("ByCarNo", UCase(LblSupplierCode.Text.Trim), CMBVanNo.SelectedItem.Text, 0, DateTime.Now, 0, DateTime.Now, 0, 0, "-", 0)

            If SqlDs1.Tables(0).Rows.Count >= 1 Then
                TxtVanNumber.Text = SqlDs1.Tables(0).Rows(0).Item(1)
                TxtLicenseNo1.Text = SqlDs1.Tables(0).Rows(0).Item(2)
                TxtLicenseExpiryDate1.Text = SqlDs1.Tables(0).Rows(0).Item(3)
                TxtRoadTaxNo1.Text = SqlDs1.Tables(0).Rows(0).Item(4)
                TxtRoadTaxExpiryDate1.Text = SqlDs1.Tables(0).Rows(0).Item(5)
                TxtDriverName.Text = SqlDs1.Tables(0).Rows(0).Item(6)
                TXTICNO.Text = SqlDs1.Tables(0).Rows(0).Item(7)
            End If

        End If
    End Sub
End Class