Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class RptbudgetOTallDept
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String
    Dim total As Decimal = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' Session("empcode") = "014543"

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (72)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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

        bindOTGrid()
        LBLFROM.Text = Session("budgetfrom")
        LBLTO.Text = Session("budgetTO")
    End Sub

    Private Sub bindOTGrid()

        Dim opn
        Dim myval

        opn = Session("budgetopn")
        Dim fromd As String = Session("budgetfrom")
        Dim tod As String = Session("budgetto")
        myval = Session("budgetval")


        'Bind Grid view

        MyGlobal.Con_Str()
        Dim ds1 As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("ot_budgetfetch", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@fromdate", fromd)
        Command.Parameters.AddWithValue("@todate", tod)
        Command.Parameters.AddWithValue("@Operation", opn)
        Command.Parameters.AddWithValue("@myval", myval)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "OTRec")
        GridView1.DataSource = ds1
        GridView1.DataBind()
        con.Close()


    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblUnitsInStock As Label = DirectCast(e.Row.FindControl("Label5"), Label)
            If lblUnitsInStock.Text <> "" Then
                Dim stock As Decimal = [Decimal].Parse(lblUnitsInStock.Text)
                total += stock
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim lbl As Label = DirectCast(e.Row.FindControl("lbltot"), Label)
            lbl.Text = total.ToString
        End If

    End Sub

End Class