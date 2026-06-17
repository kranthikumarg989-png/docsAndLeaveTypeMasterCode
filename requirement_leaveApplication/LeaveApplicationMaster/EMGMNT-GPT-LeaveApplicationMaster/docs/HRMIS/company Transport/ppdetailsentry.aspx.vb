Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

 Partial Public Class ppdetailsentry
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (103)
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

    Public Function GetPassportBarCode(ByVal txt1 As Integer, ByVal txt2 As Integer, ByVal Typ As String) As DataSet
        Try
            Dim ClsObj As New CRMlognetglobal

            Dim SqlDs1 As New DataSet
            Dim SqlCmd As New SqlCommand
            Dim SqlCon As New SqlConnection
            Dim SqlAd As New SqlDataAdapter

            ClsObj.db_cn()
            SqlCon = New SqlConnection(CRMlognetglobal.sConnString2)
            SqlCon.Open()

            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SP_PassportBarcode"
            SqlCmd.Parameters.Clear()

            SqlCmd.Connection = SqlCon

            SqlCmd.Parameters.AddWithValue("@Mn1", txt1)
            SqlCmd.Parameters.AddWithValue("@Yr1", txt2)
            SqlCmd.Parameters.AddWithValue("@Typ", Typ)

            SqlAd = New SqlDataAdapter(SqlCmd)

            SqlDs1 = New DataSet

            SqlAd.Fill(SqlDs1, "Details")

            Return SqlDs1

        Catch ex As Exception
            recstatus = False
            MyerrorMsg = ex.Message
        End Try
        Return dsdata
    End Function

    Protected Sub bsave_passport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsave_passport.Click
        Dim strdate1() As String = tdatearrived.Text.Split("/"c)

        Dim Ds1 As New DataSet
        Ds1 = GetPassportBarCode(strdate1(1), 2000 + strdate1(2), "barcode")



        Dim dr As DataRow
        If Ds1.Tables(0).Rows.Count > 0 Then
            dr = Ds1.Tables(0).Rows(0)
            TxtBarcode.Text = (dr.Item(0) - 2000).ToString + "-" + dr.Item(1).ToString + "-" + (dr.Item(2) + 1).ToString
        Else
            TxtBarcode.Text = strdate1(2) + "-" + Convert.ToInt16(strdate1(1)).ToString + "-" + "1"
        End If


        'Exit Sub

        Dim fd1 As String
        fd1 = tpedate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = tdatearrived.Text.Trim
        Dim strdated() As String = td1.Split("/"c)
        td1 = strdated(1) & "/" & strdated(0) & "/" & strdated(2)

        Dim td As Date
        td = CDate(td1)
        _eid = Session("empcode")

        Try
            Insertpassportdetails(tpeno.Text, tppno.Text, tpename.Text, fd, tpissuedcountry.Text, tpissuedplace.Text, Convert.ToString(dpgrp.SelectedValue.Trim), Convert.ToString(tpcountry.SelectedValue.Trim), tpaddress.Text, td, _
            CmbKdnRefNo.Text, CmbKDNApproval.Text, TxtAgent.Text, TxtFatherName.Text, TxtMotherName.Text, TxtContactNo.Text, TxtContractPeriod.Text, TxtBarcode.Text)

            MessageBox("Record Saved successfully")
            tpeno.Text = ""
            tppno.Text = ""
            tpename.Text = ""
            tpdept.Text = ""
            tpsect.Text = ""
            tpissuedplace.Text = ""
            tpaddress.Text = ""
            tdatearrived.Text = ""
            tpgender.Text = ""
            tpissuedcountry.Text = ""
            tpdesig.Text = ""
            tpcountry.SelectedValue = "-"
            dpgrp.SelectedValue = "-"
            tpedate.Text = ""


            TxtContactNo.Text = ""
            TxtFatherName.Text = ""
            TxtMotherName.Text = ""

            MessageBox("Record Saved!!" & TxtBarcode.Text)


        Catch ex As Exception
            MessageBox("Cannot Save Data" & ex.Message)
        End Try
    End Sub

    Protected Sub tpeno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpeno.TextChanged
        empcode = tpeno.Text.Trim
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                tpename.Text = dr("empname").ToString
                tpsect.Text = dr("sectioncode").ToString
                tpdept.Text = dr("departmentcode").ToString
                tpdesig.Text = dr("designation").ToString
                tpgender.Text = dr("sex").ToString
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                tpeno.Text = ""
                tpename.Text = ""
                tpsect.Text = ""
                tpdept.Text = ""
                tpdesig.Text = ""
                tpgender.Text = ""
            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub tpcountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpcountry.SelectedIndexChanged
        If tpcountry.Text = "Nepal" Then
            TxtContractPeriod.Text = "3"
        ElseIf tpcountry.Text = "Indonesia" Then
            TxtContractPeriod.Text = "2"
        Else
            TxtContractPeriod.Text = "3"
        End If
    End Sub
End Class