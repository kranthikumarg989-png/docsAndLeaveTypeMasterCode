Imports System.Data.SqlClient

Partial Public Class MonitoringStaffWorkingHoursMain
    Inherits System.Web.UI.Page

    Dim ClsObj As New CRMlognetglobal

    Dim SqlCon As New SqlConnection
    Dim SqlCmd As New SqlCommand
    Dim SqlDs As New DataSet
    Dim SqlAd As New SqlDataAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            CmbDepartment.Items.Add("View All")
            Dim TmpDs As New DataSet



            TmpDs = New DataSet
            TmpDs = DistinctDepartment()
            For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbDepartment.Items.Add(TmpDs.Tables(0).Rows(Tmpi).Item(0))
            Next

            TmpDs = New DataSet
            TmpDs = DistinctStaffName()
            For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbIndividual.Items.Add(TmpDs.Tables(0).Rows(Tmpi).Item(0) & "[" & TmpDs.Tables(0).Rows(Tmpi).Item(1) & "]")
            Next

            TxtFrom.Text = DateTime.Today.AddDays(-(Day(DateTime.Today) - 1)).ToString("dd-MMM-yyyy")
            TxtTo.Text = (Convert.ToDateTime(TxtFrom.Text).AddMonths(1)).AddDays(-1).ToString("dd-MMM-yyyy")

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CmbDepartment.Text <> "View All" Then
            Session("options") = "ByDepartment"
        Else
            Session("options") = "View All"
        End If

        Session("from1") = Convert.ToDateTime(TxtFrom.Text).ToString("dd-MMM-yyyy")
        Session("to1") = Convert.ToDateTime(TxtTo.Text).ToString("dd-MMM-yyyy")
        Session("code") = CmbDepartment.Text
        Session("Rptoptions") = "DeptReport"

        Response.Redirect("MonitoringStaffWorkingHours.aspx")

    End Sub

    Public Function DistinctDepartment() As DataSet
        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2)
        SqlCon.Open()

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_DistinctDepartment"
        SqlCmd.Parameters.Clear()

        SqlCmd.Connection = SqlCon

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        Return SqlDs

    End Function

    Public Function DistinctStaffName() As DataSet
        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2)
        SqlCon.Open()

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_StaffName"
        SqlCmd.Parameters.Clear()

        SqlCmd.Connection = SqlCon

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        Return SqlDs

    End Function

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        From1.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        To1.Visible = True
    End Sub

    Protected Sub From1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles From1.SelectionChanged
        TxtFrom.Text = ""
        TxtFrom.Text = From1.SelectedDate.ToString("dd-MMM-yyyy")
        From1.Visible = False

    End Sub

    Protected Sub To1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles To1.SelectionChanged
        TxtTo.Text = ""
        TxtTo.Text = To1.SelectedDate.ToString("dd-MMM-yyyy")
        To1.Visible = False
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        
        Session("options") = "View All"


        Session("from1") = Convert.ToDateTime(TxtFrom.Text).ToString("dd-MMM-yyyy")
        Session("to1") = Convert.ToDateTime(TxtTo.Text).ToString("dd-MMM-yyyy")
        Session("code") = CmbIndividual.Text.Substring(CmbIndividual.Text.IndexOf("[") + 1, (CmbIndividual.Text.IndexOf("]") - CmbIndividual.Text.IndexOf("[") - 1))
        Session("Rptoptions") = "IndividualReport"

        Response.Redirect("MonitoringStaffWorkingHours.aspx")
    End Sub

    
End Class