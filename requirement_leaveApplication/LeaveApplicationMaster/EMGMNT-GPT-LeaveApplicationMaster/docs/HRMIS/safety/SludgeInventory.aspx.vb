Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class SludgeInventory
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (142)
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
        '''''''''''''''''''''''''''''''

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_dMIS()
        'Session("empcode") = "014543"
    End Sub

    Protected Sub saveSI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVESI.Click

        Try
            Dim closingbalance As Decimal
            Dim disposalqty As Decimal
            disposalqty = dispqty.Text
            MyGlobal.Con_Str()
            MyGlobal.Open_Con_dMIS()

            Call MyGlobal.dbSp_open_dmis("safety_sludgeinventory")
            Cmd.Parameters.AddWithValue("@year", year.SelectedValue)
            Cmd.Parameters.AddWithValue("@disptype", disptype.SelectedValue)
            Cmd.Parameters.AddWithValue("@department", dept.SelectedValue)
            Cmd.Parameters.AddWithValue("@rawmtl", rawmtl.Text)
            Cmd.Parameters.AddWithValue("@dispqty", dispqty.text)
            Cmd.Parameters.AddWithValue("@price", price.Text)
            Cmd.Parameters.AddWithValue("@month", month.SelectedValue)
            Cmd.Parameters.AddWithValue("@sludgecat", sludgecat.Text)
            Cmd.Parameters.AddWithValue("@sect", sect.SelectedValue)
            Cmd.Parameters.AddWithValue("@prdqty", prdqty.Text)
            Cmd.Parameters.AddWithValue("@uom", uom.Text)
            Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
            Cmd.Parameters.AddWithValue("@keyindate", DateTime.Now)
            Cmd.ExecuteNonQuery()
            lblmsg.Text = "NEW ENTRY ADDED"

            Try
                Dim sludgetype = disptype.SelectedValue
                Dim sludgecategory = sludgecat.Text
                Dim openingbal As Decimal
                
                Dim ds As DataSet
                Dim dr As DataRow
                MyGlobal.Con_Str()
                MyGlobal.Open_Con_dMIS()
                ds = Open_sludgeinventory(Con, DAP, 2, "select openingbalance from sludgeinventory WHERE sludgecode='" & disptype.SelectedValue & "' and categorycode='" & sludgecat.Text & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    dr = ds.Tables(0).Rows(0)
                    'openingbal = openingbalance
                    openingbal = dr("openingbalance").ToString
                    closingbalance = (openingbal + disposalqty)
                    If closingbalance > openingbal Then
                        dssafety = Open_sludgeupd(Con, DAP, 2, "update sludgeinventory set openingbalance = '" & closingbalance & "' WHERE sludgecode='" & disptype.SelectedValue & "' and categorycode='" & sludgecat.Text & "'")

                    Else

                    End If
                End If
                MyGlobal.db_close()

            Catch ex As Exception
            End Try
            year.SelectedValue = "-1"
            month.SelectedValue = "-1"
            disptype.SelectedValue = "-1"
            dept.SelectedValue = "-1"
            sect.SelectedValue = "-1"
            rawmtl.Text = ""
            dispqty.Text = ""
            price.Text = ""
            sludgecat.Text = ""
            prdqty.Text = ""
            uom.Text = ""
            dispmode.Text = ""


        Catch ex As SqlException
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Green
        End Try
        MyGlobal.db_close()
    End Sub

    Protected Sub disptype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disptype.SelectedIndexChanged
        Dim sludgetype = disptype.SelectedValue
        If sludgetype <> "-1" Then
            Loadrelated()
        End If
    End Sub
    Public Sub Loadrelated()
        Dim dispmode
        Dim ds As DataSet
        Dim dr As DataRow
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_dMIS()
        ds = Open_sludgemaster(Con, DAP, 1, "WHERE sludgecode='" & disptype.SelectedValue & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            dr = ds.Tables(0).Rows(0)
            sludgecat.Text = dr("categorycode").ToString
            uom.text = dr("uom").ToString
            price.text = dr("price").ToString

        Else
            'lblmsg.Text = "xxx xxx xxx"
        End If
        MyGlobal.db_close()
    End Sub
    Public Sub Loadcalc()
       
    End Sub
End Class
