Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class BTvisaentry
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (109)
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
    End Sub

    Protected Sub tbtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtempcode.TextChanged
        empcode = tbtempcode.Text.Trim
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblname.Text = dr("empname").ToString
                lbtsection.Text = dr("sectioncode").ToString
                lbtdept.Text = dr("departmentcode").ToString
                lbtdesig.Text = dr("designation").ToString
                If dr("passportno") Is System.DBNull.Value Then
                    lbtpassport.Text = "-"
                Else
                    lbtpassport.Text = dr("passportno").ToString
                End If

                lbtnation.Text = dr("nationality").ToString
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                tbtempcode.Text = ""
                lblname.Text = ""
                lbtsection.Text = ""
                lbtdept.Text = ""
                lbtdesig.Text = ""
                lbtpassport.Text = ""
                lbtnation.Text = ""
            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub bsave_btvisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsave_btvisa.Click
        Dim fd1 As String
        fd1 = TbtVexpiry.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        getBTrecID()

        InsertBTVisa(tbtempcode.Text, Convert.ToString(dcountry.SelectedValue.Trim), Convert.ToString(Dbtvisatype.SelectedValue.Trim), Convert.ToString(DJourneytype.SelectedValue.Trim), Tbtvisaperiod.Text, fd, _eid, posid)
        If recstatus = True Then
            MessageBox("Record Saved successfully")
            Tbtvisaperiod.Text = ""
            TbtVexpiry.Text = ""
            'lbtdept.Text = ""
            'lbtsection.Text = ""
            'lbtdesig.Text = ""
            'lbtpassport.Text = ""
            'lbtnation.Text = ""
            GridView1.DataBind()
        End If

    End Sub
End Class