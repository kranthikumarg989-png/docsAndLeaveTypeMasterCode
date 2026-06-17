Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class VehicleMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
       
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (85)
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
        MyApp.GetfiscalYear()
        _eid = Session("empcode")
    End Sub
    Protected Sub bsave_vehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsave_vehicle.Click
        Dim fd1 As String
        fd1 = Tvpurdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        If Label1.Text = "" Then
            Insertvehicledetails(Tvno.Text, tvmodel.Text, Convert.ToString(Dvcategory.SelectedValue), fd, tcno.Text, Convert.ToString(Dfuel.SelectedValue), Tcolor.Text, teno.Text, tecc.Text, Tymodel.Text, Tseats.Text, Convert.ToString(Ddept.SelectedValue), _eid)
        Else
            Updatevehicledetails(Label1.Text, tvmodel.Text, Convert.ToString(Dvcategory.SelectedValue), fd, tcno.Text, Convert.ToString(Dfuel.SelectedValue), Tcolor.Text, teno.Text, tecc.Text, Tymodel.Text, Tseats.Text, Convert.ToString(Ddept.SelectedValue), _eid)
        End If
        If recstatus = True Then
            MessageBox("Record Saved successfully")
            Tvno.Text = ""
            tvmodel.Text = ""
            Tvpurdate.Text = ""
            tcno.Text = ""
            Tcolor.Text = ""
            teno.Text = ""
            tecc.Text = ""
            Tymodel.Text = ""
            Tseats.Text = ""
            Label1.Text = ""
        Else
            lblmsg.Text = MyerrorMsg
        End If
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub getvehicledetails(ByVal sender As Object, ByVal e As CommandEventArgs)
        rno = e.CommandArgument
        MessageBox(rno)
        Try
            Getvmdetails(rno)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    Tvno.Text = dr("vehicleno").ToString
                    tvmodel.Text = dr("model").ToString
                    Dvcategory.SelectedValue = dr("category").ToString
                    Tvpurdate.Text = Format(Convert.ToDateTime(dr("datepurchase")), "dd/MM/yy")
                    tcno.Text = dr("casisno").ToString
                    Dfuel.SelectedValue = dr("fueltype").ToString
                    Tcolor.Text = dr("colour").ToString
                    teno.Text = dr("engineno").ToString
                    tecc.Text = dr("enginecc").ToString
                    Tymodel.Text = dr("myear").ToString
                    Tseats.Text = dr("seats").ToString
                    Ddept.SelectedValue = dr("department").ToString
                    Label1.Text = dr("rno").ToString

                End If
            End If
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub
End Class