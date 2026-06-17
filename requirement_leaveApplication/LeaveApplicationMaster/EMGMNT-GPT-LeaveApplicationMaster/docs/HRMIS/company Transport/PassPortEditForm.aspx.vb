Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

 
Imports System.Globalization

Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Public Class PassPortEditForm
    Inherits System.Web.UI.Page
    Public strCon As String = System.Configuration.ConfigurationManager.ConnectionStrings("Sqlcon1").ToString()
    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim sqladapter As New SqlDataAdapter()
    Dim ds As New DataSet()

    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Text = ""
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (527)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
        MyApp.GetfiscalYear()

    End Sub

    Protected Sub tpeno_TextChanged(sender As Object, e As EventArgs) Handles tpeno.TextChanged

        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("passportdetailsedit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@type", "Selectvalues")
                sqlCmd.Parameters.AddWithValue("@empcode", tpeno.Text)
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        If ds.Tables(0).Rows.Count > 0 Then
            tpename.Text = ds.Tables(0).Rows(0)("name").ToString()
            tppno.Text = ds.Tables(0).Rows(0)("passportno").ToString()
            tpsect.Text = ds.Tables(0).Rows(0)("SectionCode").ToString()
            tpissuedcountry.Text = ds.Tables(0).Rows(0)("ppissuedcountry").ToString()
            tpaddress.Text = ds.Tables(0).Rows(0)("address").ToString()
            If (ds.Tables(0).Rows(0)("Country").ToString() <> "" AndAlso ds.Tables(0).Rows(0)("Country").ToString() <> "-") Then
                tpcountry.SelectedValue = ds.Tables(0).Rows(0)("Country").ToString()
            End If
 
            If (ds.Tables(0).Rows(0)("KDRefNo").ToString() <> "" AndAlso ds.Tables(0).Rows(0)("KDRefNo").ToString() <> "-") Then
                CmbKdnRefNo.SelectedValue = ds.Tables(0).Rows(0)("KDRefNo").ToString().Trim
            End If

            TxtAgent.Text = ds.Tables(0).Rows(0)("Agent").ToString()
            TxtFatherName.Text = ds.Tables(0).Rows(0)("FatherName").ToString()
            TxtContactNo.Text = ds.Tables(0).Rows(0)("ContactNo").ToString()
            tpgender.Text = ds.Tables(0).Rows(0)("Sex").ToString()
            tpdept.Text = ds.Tables(0).Rows(0)("DepartmentCode").ToString()
            tpdesig.Text = ds.Tables(0).Rows(0)("Designation").ToString()
            tpedate.Text = ds.Tables(0).Rows(0)("ppexpirydate").ToString()
            tpissuedplace.Text = ds.Tables(0).Rows(0)("ppissuedplace").ToString()
            If (ds.Tables(0).Rows(0)("empgroup").ToString() <> "" AndAlso ds.Tables(0).Rows(0)("empgroup").ToString() <> "-") Then
                dpgrp.SelectedValue = ds.Tables(0).Rows(0)("empgroup").ToString()
            End If
            tdatearrived.Text = ds.Tables(0).Rows(0)("arriveddate").ToString()
            If (ds.Tables(0).Rows(0)("KDNApproval").ToString() <> "" AndAlso ds.Tables(0).Rows(0)("KDNApproval").ToString() <> "-") Then
                CmbKDNApproval.SelectedValue = ds.Tables(0).Rows(0)("KDNApproval").ToString()
            End If

            TxtContractPeriod.Text = ds.Tables(0).Rows(0)("ContractPeriod").ToString()
            TxtMotherName.Text = ds.Tables(0).Rows(0)("MotherName").ToString()
            TxtBarcode.Text = ds.Tables(0).Rows(0)("Barcode").ToString()
            tpeno.Enabled = False
        Else
            lblMsg.Text = "Employee No does not exists"
            tpeno.Text = ""
            tpeno.Focus()
        End If

    End Sub

    Protected Sub bsave_passport_Click(sender As Object, e As EventArgs) Handles bsave_passport.Click
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("passportdetailsedit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@type", "Updatevalues")
                sqlCmd.Parameters.AddWithValue("@empcode", tpeno.Text)
                sqlCmd.Parameters.AddWithValue("@passportno", tppno.Text)
                sqlCmd.Parameters.AddWithValue("@issuedcountry", tpissuedcountry.Text)
                sqlCmd.Parameters.AddWithValue("@address", tpaddress.Text)
                sqlCmd.Parameters.AddWithValue("@countryname", tpcountry.SelectedValue.ToString())
                sqlCmd.Parameters.AddWithValue("@KDNrefno", CmbKdnRefNo.SelectedValue.ToString())
                sqlCmd.Parameters.AddWithValue("@agent", TxtAgent.Text)
                sqlCmd.Parameters.AddWithValue("@fathername", TxtFatherName.Text)
                sqlCmd.Parameters.AddWithValue("@contactno", TxtContactNo.Text)
                sqlCmd.Parameters.AddWithValue("@passportExpirydate", convertToDate(tpedate.Text))
                sqlCmd.Parameters.AddWithValue("@issuedplace", tpissuedplace.Text)
                sqlCmd.Parameters.AddWithValue("@groupcode", dpgrp.SelectedValue.ToString())
                sqlCmd.Parameters.AddWithValue("@datearrived", convertToDate(tdatearrived.Text))
                sqlCmd.Parameters.AddWithValue("@KDNapproval", CmbKDNApproval.SelectedValue.ToString())
                sqlCmd.Parameters.AddWithValue("@contractperiod", TxtContractPeriod.Text)
                sqlCmd.Parameters.AddWithValue("@mothername", TxtMotherName.Text)
                sqlCmd.Parameters.AddWithValue("@barcode", TxtBarcode.Text)

                sqlCmd.ExecuteNonQuery()
                lblMsg.Text = "Updated successfully"
                Clear_Click(sender, e)
            End Using
        End Using

    End Sub

    Function convertToDate(ByVal strDate As String) As String
        If (strDate.Length > 0) Then
            Dim array() As String
            array = strDate.Split("/")
            Return array(1) + "/" + array(0) + "/" + array(2)
        Else
            Return strDate
        End If
    End Function

    Protected Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        tpeno.Text = ""
        tpeno.Enabled = True
        tpename.Text = ""
        tppno.Text = ""
        tpsect.Text = ""
        tpissuedcountry.Text = ""
        tpaddress.Text = ""
        tpcountry.SelectedIndex = "-1"
        CmbKdnRefNo.SelectedIndex = "-1"
        TxtAgent.Text = ""
        TxtFatherName.Text = ""
        TxtContactNo.Text = ""
        tpgender.Text = ""
        tpdept.Text = ""
        tpdesig.Text = ""
        tpedate.Text = ""
        tpissuedplace.Text = ""
        dpgrp.SelectedIndex = "-1"
        tdatearrived.Text = ""
        CmbKDNApproval.SelectedIndex = "-1"
        TxtContractPeriod.Text = ""
        TxtMotherName.Text = ""
        TxtBarcode.Text = ""
    End Sub
End Class