Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared
Imports E_Management.[Global]
Imports System.IO
Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Net.Security
Partial Public Class BreakTimeMonitoring
    Inherits Messagebox

    Dim crReportDocument As StaffBreakTime
    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo
    Dim TmpDs As New DataSet
    Dim Cr As New ReportDocument
    Dim crDiskFileDestinationOptions As DiskFileDestinationOptions
    Dim crExportOptions As ExportOptions

    Dim SaveRptname, saverptname1 As String
    Dim ExportPath, ExportPath1 As String

    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition

    Dim Con As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim Ad As New SqlDataAdapter
    Dim Ds As New DataSet


    Dim strCon As String = "Data Source=192.168.0.252;Initial Catalog=TMS;uid=sa;"
    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim adapter As New SqlDataAdapter()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            TxtFrm.Text = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy")
            TxtTo.Text = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy")

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TxtFrm.Text.Equals("") Then
            msg("Please Select From Date")
            Exit Sub
        End If

        If TxtTo.Text.Equals("") Then
            msg("Please Select To Date")
            Exit Sub
        End If

         

        DispData("All", TxtFrm.Text, DateAdd(DateInterval.Day, 1, Convert.ToDateTime(TxtTo.Text)), "-")



       



    End Sub


    Public Sub DispData(ByVal Options As String, ByVal Dt1 As DateTime, ByVal Dt2 As DateTime, ByVal EmpCode As String)
        Con = New SqlConnection("Data Source=192.168.0.252;Initial Catalog=TMS;uid=sa")
        Con.Open()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_Select_TblCheckinoutSynchronize_BreakTime1"
        Cmd.Connection = Con
        Cmd.Parameters.AddWithValue("@Options", Options)
        Cmd.Parameters.AddWithValue("@Date1", Dt1.ToString("dd-MMM-yyyy"))
        Cmd.Parameters.AddWithValue("@Date2", Dt2.ToString("dd-MMM-yyyy"))
        Cmd.Parameters.AddWithValue("@EmpCode", EmpCode)
        Ad = New SqlDataAdapter(Cmd)
        Cmd.ExecuteNonQuery()

        Session("frm") = TxtFrm.Text
        Session("tod") = TxtTo.Text

        Session("ttl") = "From  " & Convert.ToDateTime(TxtFrm.Text).ToString("dd-MMM-yyyy") & " To " & Convert.ToDateTime(TxtTo.Text).ToString("dd-MMM-yyyy")

        Response.Redirect("BreakTimeMonitoringDesign.aspx")

    End Sub

  

    
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Session("brkDeptCode") = DropDownList1.SelectedValue
    End Sub

    Sub BindGrid4(ByVal gvControl As GridView, ByVal Type As String)
        Session("frm") = TxtFrm.Text
        Session("tod") = TxtTo.Text

        Ds = New DataSet
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("SP_Select_TblCheckinoutSynchronize_BreakTime", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Options", "All")
                sqlCmd.Parameters.AddWithValue("@Date1", Session("frm").ToString)
                sqlCmd.Parameters.AddWithValue("@Date2", Session("tod").ToString)
                sqlCmd.Parameters.AddWithValue("@EmpCode", "-")



                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(Ds)
            End Using
        End Using

        GV1.DataSource = Ds
        GV1.DataBind()


        GV1.DataSource = Ds.Tables(0)
        GV1.DataBind()


        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=BreakTime-" & DateTime.Now.ToString.Replace(":", "") & ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        GV1.AllowPaging = False
        GV1.DataBind()


        'Change the Header Row back to white color 
        GV1.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'Apply style to Individual Cells 
        GV1.HeaderRow.Cells(0).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(1).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(2).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(3).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(4).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(5).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(6).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(7).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(8).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(9).Style.Add("background-color", "green")
        GV1.HeaderRow.Cells(10).Style.Add("background-color", "green")

        For i As Integer = 0 To GV1.Rows.Count - 1
            Dim row As GridViewRow = GV1.Rows(i)

            'Change Color back to white 
            row.BackColor = System.Drawing.Color.White

            'Apply text style to each Row 
            row.Attributes.Add("class", "textmode")

            'Apply style to Individual Cells of Alternating Row 
            If i Mod 2 <> 0 Then
                row.Cells(0).Style.Add("background-color", "#C2D69B")
                row.Cells(1).Style.Add("background-color", "#C2D69B")
                row.Cells(2).Style.Add("background-color", "#C2D69B")
                row.Cells(3).Style.Add("background-color", "#C2D69B")
                row.Cells(4).Style.Add("background-color", "#C2D69B")
                row.Cells(5).Style.Add("background-color", "#C2D69B")
                row.Cells(6).Style.Add("background-color", "#C2D69B")
                row.Cells(7).Style.Add("background-color", "#C2D69B")
                row.Cells(8).Style.Add("background-color", "#C2D69B")
                row.Cells(9).Style.Add("background-color", "#C2D69B")
                row.Cells(10).Style.Add("background-color", "#C2D69B")
            End If
        Next

        GV1.RenderControl(hw)

        'style to format numbers to string 
        Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"

        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()

    End Sub

    Protected Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        BindGrid4(GV1, "BreakTime")
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered 
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        BindGrid5(GV2, "BreakTime")
    End Sub

    Sub BindGrid5(ByVal gvControl As GridView, ByVal Type As String)
        Session("frm") = TxtFrm.Text
        Session("tod") = TxtTo.Text

        Ds = New DataSet
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("Canteen_AbnormalReport", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Options", "All")
                sqlCmd.Parameters.AddWithValue("@Date1", Session("frm").ToString)
                sqlCmd.Parameters.AddWithValue("@Date2", Session("tod").ToString)

                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(Ds)
            End Using
        End Using

        GV2.DataSource = Ds
        GV2.DataBind()


        GV2.DataSource = Ds.Tables(0)
        GV2.DataBind()


        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=BreakTime-Abnormal-" & DateTime.Now.ToString.Replace(":", "") & ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        GV2.AllowPaging = False
        GV2.DataBind()


        'Change the Header Row back to white color 
        GV2.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'Apply style to Individual Cells 
        GV2.HeaderRow.Cells(0).Style.Add("background-color", "green")
        GV2.HeaderRow.Cells(1).Style.Add("background-color", "green")
        GV2.HeaderRow.Cells(2).Style.Add("background-color", "green")
        GV2.HeaderRow.Cells(3).Style.Add("background-color", "green")
        GV2.HeaderRow.Cells(4).Style.Add("background-color", "green")
        GV2.HeaderRow.Cells(5).Style.Add("background-color", "green")
        GV2.HeaderRow.Cells(6).Style.Add("background-color", "green")
        GV2.HeaderRow.Cells(7).Style.Add("background-color", "green")

        For i As Integer = 0 To GV1.Rows.Count - 1
            Dim row As GridViewRow = GV1.Rows(i)

            'Change Color back to white 
            row.BackColor = System.Drawing.Color.White

            'Apply text style to each Row 
            row.Attributes.Add("class", "textmode")

            'Apply style to Individual Cells of Alternating Row 
            If i Mod 2 <> 0 Then
                row.Cells(0).Style.Add("background-color", "#C2D69B")
                row.Cells(1).Style.Add("background-color", "#C2D69B")
                row.Cells(2).Style.Add("background-color", "#C2D69B")
                row.Cells(3).Style.Add("background-color", "#C2D69B")
                row.Cells(4).Style.Add("background-color", "#C2D69B")
                row.Cells(5).Style.Add("background-color", "#C2D69B")
                row.Cells(6).Style.Add("background-color", "#C2D69B")
                row.Cells(7).Style.Add("background-color", "#C2D69B")
               
            End If
        Next

        GV2.RenderControl(hw)

        'style to format numbers to string 
        Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"

        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
End Class