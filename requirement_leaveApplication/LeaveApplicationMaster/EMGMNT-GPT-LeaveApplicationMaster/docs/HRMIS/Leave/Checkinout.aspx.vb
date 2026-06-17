Imports System.Data.SqlClient
Imports System.Data
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
Partial Public Class Checkinout
    Inherits Messagebox

    Dim Con As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim Ad As New SqlDataAdapter
    Dim Ds As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            TxtFrm.Text = DateTime.Now.ToString("dd-MMM-yyyy")
            TxtTo.Text = DateTime.Now.ToString("dd-MMM-yyyy")
            DispData("MM-BySummaryandMinutes", DateTime.Now, DateTime.Now.AddDays(1), "")
        End If
        

    End Sub

    Public Sub DispData(ByVal Options As String, ByVal Dt1 As DateTime, ByVal Dt2 As DateTime, ByVal EmpCode As String)
        Con = New SqlConnection("Data Source=192.168.0.252;Initial Catalog=TMS;uid=sa")
        Con.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_Select_TblCheckinoutSynchronize_MM"
        Cmd.Connection = Con
        Cmd.Parameters.AddWithValue("@Options", Options)
        Cmd.Parameters.AddWithValue("@Date1", Dt1.ToString("dd-MMM-yyyy"))
        Cmd.Parameters.AddWithValue("@Date2", Dt2.ToString("dd-MMM-yyyy"))
        Cmd.Parameters.AddWithValue("@EmpCode", EmpCode)
        Ad = New SqlDataAdapter(Cmd)
        
        Dim i As Integer
        Dim Sum As Double = 0

        Dim Str As String
        If CmbOptions.Text = "BySummaryandMinutes" Then
            Str = " (Abnormal Data Ignored!, for Abnormal Data Please Check with other options!)"
        Else
            Str = ""
        End If


        If CmbOptions.Text <> "BySummary" And CmbOptions.Text <> "BySummaryandMinutes" Then

            Ds = New DataSet()
            Ad.Fill(Ds, "Details")
            GridView1.DataSource = Ds.Tables(0)
            GridView1.DataBind()
            Con.Close()

            GridView2.Visible = False
            GridView1.Visible = True

            For i = 0 To GridView1.Rows.Count - 1
                GridView1.Rows(i).Cells(0).Text = (i + 1)
                If GridView1.Rows(i).Cells(5).Text = "A" Then
                    GridView1.Rows(i).BackColor = Drawing.Color.Red
                    GridView1.Rows(i).ForeColor = Drawing.Color.White
                    GridView1.Rows(i).Cells(5).Text = "Abnormal"
                    GridView1.Rows(i).Cells(4).Text = ""
                    GridView1.Rows(i).Cells(6).Text = ""
                    GridView1.Rows(i).Cells(7).Text = ""
                Else
                    GridView1.Rows(i).Cells(7).Text = Math.Round(GridView1.Rows(i).Cells(6).Text / 60, 1)
                    Sum = Sum + Val(GridView1.Rows(i).Cells(7).Text)
                End If
            Next

            LblCaption.Text = "No of Days: " & (DateDiff(DateInterval.Day, Convert.ToDateTime(TxtFrm.Text), Convert.ToDateTime(TxtTo.Text)) + 1) & "          Total Hours:" & Math.Round(Sum / 60, 1) & " Hrs.          Average Per Day: " & Math.Round((Sum / 60) / (DateDiff(DateInterval.Day, Convert.ToDateTime(TxtFrm.Text), Convert.ToDateTime(TxtTo.Text)) + 1), 1) & " Hrs.                   " & Str
        Else

            Ds = New DataSet()
            Ad.Fill(Ds, "Details")
            GridView2.DataSource = Ds.Tables(0)
            GridView2.DataBind()
            Con.Close()

            GridView2.Visible = True
            GridView1.Visible = False

            For i = 0 To GridView2.Rows.Count - 1
                GridView2.Rows(i).Cells(0).Text = (i + 1)
                If GridView2.Rows(i).Cells(3).Text = "A" Then
                    GridView2.Rows(i).BackColor = Drawing.Color.Red
                    GridView2.Rows(i).ForeColor = Drawing.Color.White
                    GridView2.Rows(i).Cells(5).Text = ""
                    GridView2.Rows(i).Cells(6).Text = ""
                    GridView2.Rows(i).Cells(3).Text = "Abnormal"
                    GridView2.Rows(i).Cells(7).Text = ""
                    GridView2.Rows(i).Cells(8).Text = ""
                Else
                    GridView2.Rows(i).Cells(6).Text = Math.Round(GridView2.Rows(i).Cells(6).Text / 60, 1)
                    GridView2.Rows(i).Cells(7).Text = Math.Round(GridView2.Rows(i).Cells(6).Text / GridView2.Rows(i).Cells(4).Text, 1)
                    GridView2.Rows(i).Cells(8).Text = GridView2.Rows(i).Cells(6).Text / (DateDiff(DateInterval.Day, Convert.ToDateTime(TxtFrm.Text), Convert.ToDateTime(TxtTo.Text)) + 1)
                    GridView2.Rows(i).Cells(5).Text = GridView2.Rows(i).Cells(4).Text / (DateDiff(DateInterval.Day, Convert.ToDateTime(TxtFrm.Text), Convert.ToDateTime(TxtTo.Text)) + 1)
                    Sum = Sum + Val(GridView2.Rows(i).Cells(6).Text)
                End If
            Next
            LblCaption.Text = "No of Days: " & (DateDiff(DateInterval.Day, Convert.ToDateTime(TxtFrm.Text), Convert.ToDateTime(TxtTo.Text)) + 1) & "          Total Hours:" & Math.Round(Sum / 60, 1) & " Hrs.          Average Per Day: " & Math.Round((Sum / 60) / (DateDiff(DateInterval.Day, Convert.ToDateTime(TxtFrm.Text), Convert.ToDateTime(TxtTo.Text)) + 1), 1) & " Hrs.                   " & Str
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Calendar2.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TxtFrm.Text = Calendar1.SelectedDate.ToString("dd-MMM-yyyy")
        Calendar1.Visible = False
    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        TxtTo.Text = Calendar2.SelectedDate.ToString("dd-MMM-yyyy")
        Calendar2.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CmbOptions.Text = "ByDate" Or CmbOptions.Text = "ByMins" Or CmbOptions.Text = "BySummary" Or CmbOptions.Text = "BySummaryandMinutes" Then
            If TxtFrm.Text.Equals("") Then
                msg("Please Select From Date")
                Exit Sub
            End If

            If TxtTo.Text.Equals("") Then
                msg("Please Select To Date")
                Exit Sub
            End If

        ElseIf CmbOptions.Text = "ByIDandDate" Then

            If TxtFrm.Text.Equals("") Then
                msg("Please Select From Date")
                Exit Sub
            End If

            If TxtTo.Text.Equals("") Then
                msg("Please Select To Date")
                Exit Sub
            End If

            If TxtFrm.Text.Equals("") Then
                msg("Please Select From Date")
                Exit Sub
            End If

            If TxtEmpId.Text.Equals("") Then
                msg("Please Enter Employee Code")
                Exit Sub
            End If

        ElseIf CmbOptions.Text = "ByID" Then
            If TxtEmpId.Text.Equals("") Then
                msg("Please Enter Employee Code")
                Exit Sub
            End If

        End If

        DispData("MM-" & CmbOptions.Text, TxtFrm.Text, DateAdd(DateInterval.Day, 1, Convert.ToDateTime(TxtTo.Text)), TxtEmpId.Text)

    End Sub

    Protected Sub CmbOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOptions.SelectedIndexChanged

    End Sub
End Class