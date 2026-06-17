Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.emanagement.[Global]
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class crvCsall
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Dim myGlo As New Emanagement.netglobal 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (40)
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

        ' Dim ConnInfo As New ConnectionInfo
        Dim fromd As String
        Dim tod As String
        'With ConnInfo
        '    .ServerName = sqlServerName
        '    .DatabaseName = sqlDBName
        '    .UserID = sqlUid
        '    .Password = sqlPwd
        'End With

        fromd = Session("cvfd")
        tod = Session("cvtd")


        Me.CrystalReportViewer1.ParameterFieldInfo.Clear()
        Me.CrystalReportViewer1.ReportSource = Server.MapPath("rptcspass.rpt")
        Dim ParamFields As ParameterFields = Me.CrystalReportViewer1.ParameterFieldInfo

        Dim gp_gpdaterange As New ParameterField
        gp_gpdaterange.Name = "csDateRange"
        Dim p_OrderDateRange_Value As New ParameterRangeValue
        p_OrderDateRange_Value.StartValue = fromd
        p_OrderDateRange_Value.EndValue = tod
        gp_gpdaterange.CurrentValues.Add(p_OrderDateRange_Value)
        ParamFields.Add(gp_gpdaterange)

        'For Each cnInfo As TableLogOnInfo In Me.CrystalReportViewer1.LogOnInfo
        '    cnInfo.ConnectionInfo = ConnInfo
        'Next
        Me.CrystalReportViewer1.RefreshReport()
    End Sub




End Class