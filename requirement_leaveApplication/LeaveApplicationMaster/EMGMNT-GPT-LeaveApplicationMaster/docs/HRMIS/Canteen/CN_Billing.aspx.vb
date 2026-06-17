Imports E_Management.crmlognetglobal
Imports System.Data.SqlClient

Partial Public Class CN_Billing
    Inherits System.Web.UI.Page

    Dim ClsObj As New CRMlognetglobal

    Dim SqlCon As New SqlConnection
    Dim SqlCmd As New SqlCommand
    Dim SqlDs As New DataSet
    Dim SqlAd As New SqlDataAdapter

    Dim strHostName As String = ""
    Dim strIPAddress As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()


    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        LblMsg.Text = ""

        If Val(TxtBillAmount.Text) <= 0 Then
            LblMsg.Text = "Invalid Amount!"
            Exit Sub
        End If

        If CmbCanteen.Text = "-Select-" Then
            LblMsg.Text = "Please Select Canteen Name!"
            Exit Sub
        End If

        Dim Designation As String = ""
        Dim CrdValue As Double = 0
        Dim Balance As Double
        Dim CurrentUsage As Double = 0
        Dim DepartmentCode As String = ""
        Dim SectionCode As String = ""
        Dim EmpName As String = ""

        SqlDs = New DataSet
        SqlDs = CheckEmpID(TxtEID.Text)

        If SqlDs.Tables(0).Rows.Count >= 1 Then
            EmpName = SqlDs.Tables(0).Rows(0).Item(1)
            Designation = SqlDs.Tables(0).Rows(0).Item(2)
            DepartmentCode = SqlDs.Tables(0).Rows(0).Item(3)
            SectionCode = SqlDs.Tables(0).Rows(0).Item(4)
        Else
            LblMsg.Text = "Please Check the Employee ID!"
            Exit Sub
        End If

        If Val(TxtBillAmount.Text) > 6 Then
            LblMsg.Text = "For One Transaction Rm.6/- Only Allowed!"
            Exit Sub
        End If

        'If CmbCanteen.Text = "Test_Canteen" Then
        '    CrdValue = 50
        'Else

        SqlDs = New DataSet
        SqlDs = SelectAllowance(Designation)

        If SqlDs.Tables(0).Rows.Count >= 1 Then
            CrdValue = SqlDs.Tables(0).Rows(0).Item(0)
        Else
            LblMsg.Text = "Allowance Not Alloted for " & Designation
            Exit Sub
        End If


        'End If



        SqlDs = New DataSet
        SqlDs = SelectTransaction(TxtEID.Text)

        If SqlDs.Tables(0).Rows.Count >= 1 Then
            CrdValue = CrdValue - SqlDs.Tables(0).Rows(0).Item(1)
        End If

        CurrentUsage = TxtBillAmount.Text
        Balance = CrdValue - CurrentUsage

        If Balance < 0 Then
            LblMsg.Text = "Insufficient Amount! Available Balance :" & Math.Round(CrdValue, 2)
            Exit Sub
        End If

        If InsertTransaction(TxtEID.Text, EmpName, Designation, CrdValue, CurrentUsage, Balance, TxtDate.Text & " " & TimeOfDay, CmbCanteen.Text, strIPAddress, DepartmentCode, SectionCode) Then
            LblMsg.Text = "Successfully Updated!"
            TxtEID.Text = ""
            TxtBillAmount.Text = ""

            TxtEID.Focus()
        End If

    End Sub

    Public Function SelectTransaction( _
ByVal EMployeeID As String) As DataSet
        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2)
        SqlCon.Open()

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "CN_SP_SelectDailyTransaction"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@EMployeeID", EMployeeID)

        SqlCmd.Connection = SqlCon

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        Return SqlDs

    End Function



    Public Function SelectAllowance( _
ByVal Designation As String) As DataSet
        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2)
        SqlCon.Open()
        SqlCmd.Parameters.Clear()
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "CN_SP_SelectAllowance"

        SqlCmd.Parameters.AddWithValue("@Designation", Designation)


        SqlCmd.Connection = SqlCon

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        Return SqlDs

    End Function



    Public Function CheckEmpID(ByVal UName As String) As DataSet

        ClsObj.db_cn()

        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2)
        SqlCon.Open()

        SqlCmd = New SqlCommand("Select Empcode, EmpName, Designation, DepartmentCode, SectionCode  From EmpMaster A, UserInfo B Where A.EmpCodei=B.BadgeNumber and Empcode='" & UName & "' and Resigned='N'", SqlCon)
        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "UserDetails")

        If SqlDs.Tables(0).Rows.Count >= 1 Then
            Return SqlDs
            Exit Function
        Else

        End If


        SqlCon = New SqlConnection(CRMlognetglobal.MelHrmis)
        SqlCon.Open()

        SqlCmd = New SqlCommand("Select Empcode, EmpName, Designation, DepartmentCode, SectionCode  From EmpMaster A, UserInfo B Where A.EmpCodei=B.BadgeNumber and Empcode='" & UName & "' and Resigned='N'", SqlCon)
        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlAd.Fill(SqlDs, "UserDetails")

        If SqlDs.Tables(0).Rows.Count >= 1 Then
            Return SqlDs
            Exit Function
        Else

        End If

        SqlCon = New SqlConnection(CRMlognetglobal.OutHrmis)
        SqlCon.Open()

        SqlCmd = New SqlCommand("Select Empcode, EmpName, Designation, DepartmentCode, SectionCode  From EmpMaster A, UserInfo B Where A.EmpCodei=B.BadgeNumber and Empcode='" & UName & "' and Resigned='N'", SqlCon)
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "UserDetails")

        If SqlDs.Tables(0).Rows.Count >= 1 Then
            Return SqlDs
            Exit Function
        End If

        SqlCon = New SqlConnection(CRMlognetglobal.MliHrmis)
        SqlCon.Open()

        SqlCmd = New SqlCommand("Select Empcode, EmpName, Designation, DepartmentCode, SectionCode  From EmpMaster A, UserInfo B Where A.EmpCodei=B.BadgeNumber and Empcode='" & UName & "' and Resigned='N'", SqlCon)
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "UserDetails")


        Return SqlDs
    End Function

    Public Function InsertTransaction( _
   ByVal EMployeeID As String, _
   ByVal EmployeeName As String, _
   ByVal Designation As String, _
   ByVal PreviousBalance As Double, _
   ByVal CurrentUsage As Double, _
   ByVal CurrentBalance As Double, _
   ByVal TransactionDate As DateTime, _
   ByVal CanteenName As String, _
   ByVal CanteenIP As String, ByVal DepartmentCode As String, ByVal SectionCode As String) As Boolean
        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2)
        SqlCon.Open()

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "CN_SP_DailyTransactionS"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@EMployeeID", EMployeeID)
        SqlCmd.Parameters.AddWithValue("@EmployeeName", EmployeeName)
        SqlCmd.Parameters.AddWithValue("@Designation", Designation)
        SqlCmd.Parameters.AddWithValue("@PreviousBalance", PreviousBalance)
        SqlCmd.Parameters.AddWithValue("@CurrentUsage", CurrentUsage)
        SqlCmd.Parameters.AddWithValue("@CurrentBalance", CurrentBalance)
        SqlCmd.Parameters.AddWithValue("@TransactionDate", TransactionDate)
        SqlCmd.Parameters.AddWithValue("@CanteenName", CanteenName)
        SqlCmd.Parameters.AddWithValue("@CanteenIP", CanteenIP)
        SqlCmd.Parameters.AddWithValue("@DepartmentCode", DepartmentCode)
        SqlCmd.Parameters.AddWithValue("@SectionCode", SectionCode)

        SqlCmd.Connection = SqlCon

        Dim X As Integer = SqlCmd.ExecuteNonQuery()
        If X = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        From1.Visible = True
    End Sub

    Protected Sub From1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles From1.SelectionChanged
        TxtDate.Text = ""
        TxtDate.Text = From1.SelectedDate.ToString("dd-MMM-yyyy")
        From1.Visible = False
    End Sub
End Class