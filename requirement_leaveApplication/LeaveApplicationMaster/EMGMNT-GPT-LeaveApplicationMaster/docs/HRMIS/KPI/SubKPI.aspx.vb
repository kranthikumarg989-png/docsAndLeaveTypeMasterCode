Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class SubKPI
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (75)
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

        ' lblyear.Text = Date.Now.Year

        lblmsg.Text = ""
        Dim mon = Date.Now.Month
        Dim yr
        MyApp.GetfiscalYear()
        yr = _fisyrStart.Year
        lblyear.Text = yr





    End Sub


    Protected Sub SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVE.Click
        Dim A, B, C, D
        If Q1.Checked = True Then
            A = "True"
        Else
            A = "False"
        End If

        If q2.Checked = True Then
            B = "True"
        Else
            B = "False"
        End If

        If Q3.Checked = True Then
            C = "True"
        Else
            C = "False"
        End If

        If Q4.Checked = True Then
            D = "True"
        Else
            D = "False"
        End If

        If Q1.Checked = False And q2.Checked = False And Q3.Checked = False And Q4.Checked = False Then
            lblmsg.Text = "Select atleast one quarter"

            Exit Sub

        End If


        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Call MyGlobal.dbSp_open("hrmis_kpi_subkpi_new")

            Cmd.Parameters.AddWithValue("@Major_KPINO", ddlmajor.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@MajorKPI_Details", lblmjr.Text)
            Cmd.Parameters.AddWithValue("@SubKPI_Details", txtsubkpi.Text.Trim)
            Cmd.Parameters.AddWithValue("@q1", A)
            Cmd.Parameters.AddWithValue("@q2", B)
            Cmd.Parameters.AddWithValue("@q3", C)
            Cmd.Parameters.AddWithValue("@q4", D)
            Cmd.Parameters.AddWithValue("@uom", ddlUom.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@curent", txtcurrent.Text.Trim)
            Cmd.Parameters.AddWithValue("@target", txttarget.Text.Trim)
            Cmd.Parameters.AddWithValue("@individual", lblinv.Text)
            Cmd.Parameters.AddWithValue("@Department_Code", Session("_edept"))
            Cmd.Parameters.AddWithValue("@KPI_Year", lblyear.Text)
            Cmd.Parameters.AddWithValue("@Employee_Code", Session("empcode"))
            Cmd.Parameters.AddWithValue("@subnumber", lblrno.text)
            Cmd.Parameters.AddWithValue("@updbasis", Rbupdate.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@stat", "S")

            Cmd.ExecuteNonQuery()
          
        Catch ex As SqlException
            MessageBox(ex.Message)
            Exit Sub
        End Try
        lblmsg.Text = "Record Saved Successfully"

        lblmjr.Text = ""
        lblinv.Text = ""
        lblrno.Text = ""
        txtsubkpi.Text = ""
        txtcurrent.Text = ""
        txttarget.Text = ""
        Q1.Checked = False
        q2.Checked = False
        Q3.Checked = False
        Q4.Checked = False
        Rbupdate.SelectedValue = "-1"
        ddlmajor.SelectedValue = "-1"
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub ddlmajor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlmajor.SelectedIndexChanged

        Dim dsKPI As DataSet
        Try
            dsKPI = GetKPIRec(ddlmajor.SelectedValue)
            Dim dr As DataRow
            If dsKPI.Tables(0).Rows.Count > 0 Then
                dr = dsKPI.Tables(0).Rows(0)
                lblmjr.Text = dr("Major_kpidetails").ToString
                lblinv.Text = dr("opn").ToString
            End If
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim label As Label = TryCast(e.Row.FindControl("label1"), Label)
            Dim button As LinkButton = TryCast(e.Row.FindControl("LinkButton1"), LinkButton)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("LinkButton5"), LinkButton)
            If status = "S" Then
                button.Visible = True
                label.Visible = False
                button2.Visible = True
            Else
                label.Visible = True
                button.Visible = False
                button2.Visible = False
            End If

            If status = "S" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Yellow
                ' e.Row.Cells(7).Text = "Scheduled"
            ElseIf status = "A" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Green
            ElseIf status = "R" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub
    Function GetKPIRec(ByVal rno As Integer) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select *,Ltrim(rtrim(individual)) as opn from dbo.KPI_MajorSetting where major_kpino= '" & rno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Public Sub EditKPI(ByVal sender As Object, ByVal e As CommandEventArgs)
        rno = e.CommandArgument
        lblrno.Text = e.CommandArgument
        Dim rd
        Dim dsKPI As DataSet
        Try
            dsKPI = GetSubKPIRec(rno)
            Dim dr As DataRow
            If dsKPI.Tables(0).Rows.Count > 0 Then
                dr = dsKPI.Tables(0).Rows(0)
                ddlmajor.Text = dr("Major_kpino").ToString
                lblmjr.Text = dr("MajorKPI_Details").ToString
                txtsubkpi.Text = dr("subkpi_details").ToString
                ddlUom.Text = dr("uom").ToString
                txtcurrent.Text = dr("curent").ToString
                txttarget.Text = dr("target").ToString

                If dr("q1").ToString.Trim = True Then
                    Q1.Checked = True
                Else
                    Q1.Checked = False
                End If

                If dr("q2").ToString.Trim = True Then
                    q2.Checked = True
                Else
                    q2.Checked = False
                End If

                If dr("q3").ToString.Trim = True Then
                    Q3.Checked = True
                Else
                    Q3.Checked = False

                End If
                If dr("q4").ToString.Trim = True Then
                    Q4.Checked = True
                Else
                    Q4.Checked = False
                End If

                ''' get whetehr set by ind or not
                Dim dskpi1 As DataSet
                Dim dr1 As DataRow
                dskpi1 = GetKPIRec(dr("Major_kpino"))
                If dskpi1.Tables(0).Rows.Count > 0 Then
                    dr1 = dskpi1.Tables(0).Rows(0)
                    lblinv.Text = dr1("opn").ToString
                End If
                Rbupdate.SelectedValue = dr("updbasis").ToString
            End If

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub
    Function GetSubKPIRec(ByVal rno As Integer) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from dbo.KPI_SubSetting  where sub_kpino= '" & rno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPISub")
        con.Close()
        Return ds
    End Function
    Public Sub kpidELETE(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim APPNO
        APPNO = e.CommandArgument
        Dim cmd1 As New SqlCommand
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        con.Open()
        cmd1 = New SqlCommand("DELETE FROM KPI_SubSetting  where sub_kpino= '" & APPNO & "'", con)
        cmd1.ExecuteNonQuery()
        con.Close()
        GridView1.DataBind()

    End Sub

End Class