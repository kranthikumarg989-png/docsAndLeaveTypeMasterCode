Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CategoryTypeMaster
    Inherits System.Web.UI.Page
    Dim connection As String
    Dim dtCommon As DataTable = New DataTable()
    Dim drCommon As SqlDataReader
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (356)
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

        connection = ConfigurationManager.ConnectionStrings("Sqlcon1").ConnectionString
        If IsPostBack = False Then
            CatCode()
            LoadGrid()
            txtCatDesc.Text = ""
        End If
    End Sub
    Protected Sub CatCode()
        Dim dtCatCode As DataTable = New DataTable()
        Dim strCatCode As String = "select isnull(max(CatCode),0)+1 as CatCode from dbo.Tb_PPE_CategoryType"
        CommonDrDt(strCatCode)
        dtCatCode = dtCommon
        lblCateCode.Text = dtCatCode.Rows(0)("CatCode").ToString()
    End Sub
    Protected Sub LoadGrid()
        Dim dtCatCode As DataTable = New DataTable()
        Dim strCatCode As String = "Select CatCode,Description from Tb_PPE_CategoryType"
        CommonDrDt(strCatCode)
        dtCatCode = dtCommon
        dgvCategory.DataSource = dtCatCode
        dgvCategory.DataBind()
    End Sub
    Protected Sub CommonDrDt(ByVal strQuery As String)
        Dim con As SqlConnection = New SqlConnection(connection)
        dtCommon = New DataTable()
        '******* 
        Dim cmdMailId As SqlCommand = New SqlCommand(strQuery, con)
        con.Open()
        drCommon = cmdMailId.ExecuteReader()
        dtCommon.Load(drCommon)
        con.Close()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim returnVal As Integer
        Dim con As SqlConnection = New SqlConnection(connection)
        con.Open()

        Dim cmd As SqlCommand = New SqlCommand("SP_PPE_CategoryType", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@CatCode", SqlDbType.VarChar).Value = lblCateCode.Text
        cmd.Parameters.Add("@CatDesc", SqlDbType.VarChar).Value = txtCatDesc.Text.Trim()
        'cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "014543"
        cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Session("empcode").ToString()
        'cmd.Parameters.Add("@CreatedDate", SqlDbType.VarChar).Value = DateTime.Now.ToString("MM/dd/yyyy")

        Dim param1 As SqlParameter
        param1 = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int)
        param1.Direction = ParameterDirection.ReturnValue
        cmd.ExecuteNonQuery()
        returnVal = Convert.ToInt32(param1.Value)
        con.Close()

        If returnVal = 2627 Then
            lblMsg.Text = "Record Already Exist"
        ElseIf returnVal = 0 Then
            lblMsg.Text = "Record Saved successfully"
        End If

        LoadGrid()
        CatCode()
        txtCatDesc.Text = ""
    End Sub
End Class