Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo

Imports System.IO
Imports System.Drawing
Imports System.Drawing.Image
Imports System.IO.Stream
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports E_Management.crmlognetglobal
Imports System.Web.Security

Partial Public Class Emp_MiscSettings
    Inherits Messagebox


    Dim SqlCon As New SqlConnection
    Dim SqlCmd As New SqlCommand
    Dim SqlDs As New DataSet
    Dim SqlAd As New SqlDataAdapter

    Dim D1 As New DateTime
    Dim D2 As New DateTime

    Dim SqlDs1 As New DataSet
    Dim SqlDs2 As New DataSet

    Dim MyGlobal As New emanagement.globalinfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            DispData()
        End If
    End Sub

    Private Sub DispData()
        MyGlobal.Con_Str()
        SqlCon = New SqlConnection(constr)
        SqlCon.Open()
        GridView1.DataSource = SelectBlockedEmpInfo(SqlCon)
        GridView1.DataBind()
        SqlCon.Close()
    End Sub
    Private Function SelectBlockedEmpInfo(ByVal Con1 As SqlConnection) As DataSet
       
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_BlockedEmpInfo"
        SqlCmd.Parameters.Clear()


        SqlCmd.Connection = SqlCon
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        Return SqlDs

    End Function


   
    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim SqlDs1 As New DataSet
        SqlDs1 = New DataSet()
        SqlDs1 = CheckOldEmpCode()

        Try

            If CmbOldCompany.Text.Trim.Equals("-Select-") Then
                LblMsg.Text = "Please select company name!"
                Exit Sub
            End If
            If SqlDs1.Tables(0).Rows.Count >= 1 Then
                LblMsg.Text = "Valid EmpCode"
            Else
                LblMsg.Text = "Please Check! Employee Code is not a valid!"
                Exit Sub
            End If
        Catch ex As Exception
            LblMsg.Text = "Please Select Company Name!"
            Exit Sub
        End Try

        MyGlobal.Con_Str()
        SqlCon = New SqlConnection(constr)
        SqlCon.Open()

        Dim Sts As String
        If RBtnYes.Checked = True Then
            Sts = "Yes"
        Else
            Sts = "NO"
        End If

        BlockedEmpList(SqlCon, TxtOldEmpCode.Text, Sts)
        SqlCon.Close()
        LblMsg.Text = "Successfully updated!...."
        TxtOldEmpCode.Text = ""

        TxtOldEmpCode.Focus()

        DispData()

    End Sub


    Private Function BlockedEmpList(ByVal Con1 As SqlConnection, ByVal EmployeeCode As String, ByVal SubsidyEligiblity As String)
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "CN_InsertBlockedEmpInfo"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@EmployeeCode", EmployeeCode)
        SqlCmd.Parameters.AddWithValue("@SubsidyEligiblity", SubsidyEligiblity)
        SqlCmd.Parameters.AddWithValue("@CreatedBy", Session("empcode").ToString())


        SqlCmd.Connection = SqlCon
        SqlCmd.ExecuteNonQuery()

    End Function


    Private Function CheckOldEmpCode() As DataSet

        Dim ClsObj As New CRMlognetglobal

        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim SqlDs As New DataSet
        Dim SqlAd As New SqlDataAdapter

        ClsObj.db_cn()

        If CmbOldCompany.Text = "MMSB" Then
            'MMSB HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        ElseIf CmbOldCompany.Text = "MMEL" Then
            'MEL HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.MelHrmis & "; Connect Timeout=6000000")
        ElseIf CmbOldCompany.Text = "MLI" Then
            'MLI HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.MliHrmis & "; Connect Timeout=6000000")
        ElseIf CmbOldCompany.Text = "OUTHRMIS" Then
            'OutSource HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.OutHrmis & "; Connect Timeout=6000000")
        Else
            Exit Function
        End If

        SqlCon.Open()

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "CN_CheckTransferredEmpCode"
        SqlCmd.Connection = SqlCon

        SqlCmd.Parameters.Clear()

        SqlCmd.Parameters.AddWithValue("@OldEmpCode", TxtOldEmpCode.Text)

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        SqlCon.Close()

        Return SqlDs

    End Function

End Class