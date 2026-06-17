Imports E_Management.crmlognetglobal
Imports System.Data.SqlClient
Imports System.Data.IO

Partial Public Class StaffLeaveInfo
    Inherits System.Web.UI.Page
    Dim ClsObj As New CRMlognetglobal

    Dim SqlCon As New SqlConnection
    Dim SqlCmd As New SqlCommand
    Dim SqlDs As New DataSet
    Dim SqlAd As New SqlDataAdapter

    Dim D1 As New DateTime
    Dim D2 As New DateTime

    Dim SqlDs1 As New DataSet
    Dim SqlDs2 As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       
        btnView.Attributes.Add("onclick", "javascript:" + btnView.ClientID + ".disabled=true;" + ClientScript.GetPostBackEventReference(btnView, ""))

    End Sub

    Public Function SelectDistinctStaffID() As DataSet
        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        SqlCon.Open()

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_SelectDistinctStaffID"
        SqlCmd.Parameters.Clear()
        SqlCmd.Connection = SqlCon

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        Return SqlDs

    End Function

    Public Function LeaveDetails(ByVal EmpCode As String) As DataSet
       

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_LeaveDetails"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@EmpCode", EmpCode)
        SqlCmd.Parameters.AddWithValue("@Dat1", D1)
        SqlCmd.Parameters.AddWithValue("@Dat2", D2)
        SqlCmd.Parameters.AddWithValue("@Dat3", D2)

        SqlCmd.Connection = SqlCon

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        Return SqlDs

    End Function


    

    Protected Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click




        SqlDs1 = New DataSet
        SqlDs1 = SelectDistinctStaffID()

        If DateTime.Now.Month >= 4 Then
            D1 = Convert.ToDateTime("04-01-" & Year(DateTime.Now) & " 00:00:00 AM")
            D2 = Convert.ToDateTime("04-01-" & Year(DateTime.Now.AddYears(1)) & " 00:00:00 AM")
        Else
            D1 = Convert.ToDateTime("04-01-" & Year(DateTime.Now.AddYears(-1)) & " 00:00:00 AM")
            D2 = Convert.ToDateTime("04-01-" & Year(DateTime.Now) & " 00:00:00 AM")
        End If


        'D1 = DateTime.Now.AddMonths(-6)
        'D2 = DateTime.Now.AddMonths(5)

        Response.Write("<table Border=1 style='font-size:10;font-family:arial'>")

        Response.Write("<tr>")
        Response.Write("<th colspan=10>")
        Response.Write("Staff Leave Details")
        Response.Write("</th>")
        Response.Write("</tr>")


        Response.Write("<tr>")
        Response.Write("<th>")
        Response.Write("Empcode")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("EmpName")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("DepartmentCode")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("SectionCode")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("PositionName")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("Annual<br>Leave")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("Leave<br>Taken")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("Balance<br>Leave")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("MC")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("MC<br>Taken")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("MC<br>Remain")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("CFWD")
        Response.Write("</th>")
        Response.Write("<th>")
        Response.Write("Prorate")
        Response.Write("</th>")

        Response.Write("<th>")
        Response.Write("Balance Leave - CFWD")
        Response.Write("</th>")
        Response.Write("</tr>")

        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        SqlCon.Open()

        For Tmpi As Integer = 0 To SqlDs1.Tables(0).Rows.Count - 1
            SqlDs2 = New DataSet
            SqlDs2 = LeaveDetails(SqlDs1.Tables(0).Rows(Tmpi).Item(0))
            If SqlDs2.Tables(0).Rows.Count >= 1 Then

                Response.Write("<tr>")
                Response.Write("<th>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(0))
                Response.Write("</th>")
                Response.Write("<th>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(1))
                Response.Write("</th>")

                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(11))
                Response.Write("</td>")

                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(12))
                Response.Write("</td>")

                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(13))
                Response.Write("</td>")

                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(2))
                Response.Write("</td>")
                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(3))
                Response.Write("</td>")
                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(4))
                Response.Write("</td>")
                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(5))
                Response.Write("</td>")
                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(6))
                Response.Write("</td>")
                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(7))
                Response.Write("</td>")
                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(9))
                Response.Write("</td>")
                Response.Write("<td>")
                Response.Write(SqlDs2.Tables(0).Rows(0).Item(10))
                Response.Write("</td>")

                Response.Write("<td>")
                Response.Write((SqlDs2.Tables(0).Rows(0).Item(4)) - (SqlDs2.Tables(0).Rows(0).Item(9)))
                Response.Write("</td>")


                Response.Write("</tr>")
            End If

        Next

        Response.Write("</table>")

 

    End Sub

    
End Class