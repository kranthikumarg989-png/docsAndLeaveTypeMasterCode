Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports E_Management.crmlognetglobal

Partial Public Class Canteen_BreakTime_New
    Inherits System.Web.UI.Page

    Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
    Dim sqlCon As SqlConnection
    Dim sqlCmd As SqlCommand
    Dim SqlAd As New SqlDataAdapter
    Dim Sqlds As New DataSet()
    Dim ClsObj As New CRMlognetglobal
    Dim TmpDs As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("Department", DateTime.Now, DateTime.Now, "-", "-", "-")
            'Lbl1.Text = TmpDs.Tables(0).Rows.Count
            CmbDepartment.DataSource = TmpDs.Tables(0)
            CmbDepartment.DataValueField = "DepartmentCode"
            CmbDepartment.DataTextField = "DepartmentName"
            CmbDepartment.DataBind()
            CmbDepartment.Items.Insert(0, "-Select-")

            TmpDs = New DataSet()
            TmpDs = SP_Fun1("EmpCode", DateTime.Now, DateTime.Now, "-", "-", "-")
            'Lbl1.Text = TmpDs.Tables(0).Rows.Count
            CmbEmployeeCode.DataSource = TmpDs.Tables(0)
            CmbEmployeeCode.DataValueField = "EmpCode"
            CmbEmployeeCode.DataTextField = "EmpName"
            CmbEmployeeCode.DataBind()
            CmbEmployeeCode.Items.Insert(0, "-Select-")
            TxtFrm.Text = DateTime.Today.AddDays(-1)
            TxtTo.Text = DateTime.Today.AddDays(-1)
        End If
    End Sub

    'Public Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    GridView1.PageIndex = e.NewPageIndex
    '    GridView1.DataBind()
    'End Sub

        


    Public Function SP_Fun1(ByVal Options As String, ByVal Date1 As DateTime, ByVal Date2 As DateTime, ByVal DCode As String, ByVal SCode As String, ByVal Ecode As String) As DataSet
        ClsObj.db_cn()
        sqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        'Lbl1.Text = CRMlognetglobal.sConnString2
        sqlCon.Open()
        sqlCmd = New SqlCommand
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_CanteenData"
        sqlCmd.Parameters.Clear()
        sqlCmd.Parameters.AddWithValue("@Options", Options)
        sqlCmd.Parameters.AddWithValue("@Date1", Date1)
        sqlCmd.Parameters.AddWithValue("@Date2", Date2)
        sqlCmd.Parameters.AddWithValue("@DCode", DCode)
        sqlCmd.Parameters.AddWithValue("@SCode", SCode)
        sqlCmd.Parameters.AddWithValue("@Ecode", Ecode)

        sqlCmd.Connection = sqlCon

        SqlAd = New SqlDataAdapter(sqlCmd)

        Sqlds = New DataSet

        SqlAd.Fill(Sqlds, "Details")

        Return Sqlds

    End Function


    Protected Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        If RBtn1.Checked = True Then
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("ByDateA", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), "-", "-", "-")
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "Abnormal Data - By Date"
        Else
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("ByDate", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), "-", "-", "-")
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "All Data - By Date"
        End If



    End Sub

    Protected Sub CmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDepartment.SelectedIndexChanged
        TmpDs = New DataSet()
        TmpDs = SP_Fun1("Section", DateTime.Now, DateTime.Now, CmbDepartment.SelectedValue, "-", "-")
        'Lbl1.Text = TmpDs.Tables(0).Rows.Count
        CmbSection.DataSource = TmpDs.Tables(0)
        CmbSection.DataValueField = "SectionCode"
        CmbSection.DataTextField = "SectionName"
        CmbSection.DataBind()
        CmbSection.Items.Insert(0, "-Select-")

    End Sub

    Protected Sub CmbSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSection.SelectedIndexChanged


    End Sub

    Protected Sub CmbEmployeeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEmployeeCode.SelectedIndexChanged

    End Sub

    Protected Sub DView2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DView2.Click
        If RBtn1.Checked = True Then
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("BySectionA", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), "-", CmbSection.SelectedValue, "-")
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "Abnormal Data - By Section"
        Else
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("BySection", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), "-", CmbSection.SelectedValue, "-")
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "All Data - By Section"
        End If
    End Sub

    Protected Sub DView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DView1.Click
        If RBtn1.Checked = True Then
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("ByDepartmentA", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), CmbDepartment.SelectedValue, "-", "-")
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "Abnormal Data - By Department"
        Else
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("ByDepartment", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), CmbDepartment.SelectedValue, "-", "-")
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "All Data - By Department"
        End If
    End Sub

    Protected Sub DView3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DView3.Click
        If RBtn1.Checked = True Then
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("ByEmployeeA", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), "-", "-", CmbEmployeeCode.SelectedValue)
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "Abnormal Data - By Employee"
        Else
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("ByEmployee", TxtFrm.Text, Convert.ToDateTime(TxtTo.Text).AddDays(1), "-", "-", CmbEmployeeCode.SelectedValue)
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Lbl1.Text = "All Data - By Employee"
        End If
    End Sub
End Class