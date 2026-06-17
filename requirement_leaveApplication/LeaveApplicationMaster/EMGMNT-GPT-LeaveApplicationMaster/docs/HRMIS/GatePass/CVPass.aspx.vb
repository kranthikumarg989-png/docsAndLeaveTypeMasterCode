Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CVPass
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        'Session("_edept ") = "9000"
        'Session("dept") = "9000"

        _eid = Session("empcode")
        _ename = Session("_ename ")
        _edept = Session("_edept ")

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (39)
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
        thisdate = DateTime.Now
        If Not IsPostBack Then
            csbtnsave.Visible = True
            csbtnupd.Visible = False
        End If
        Dim CVNUM As String
        If Not IsPostBack Then

            If Session("CPeditnum") <> "" Then
                CVNUM = Session("CPeditnum")
                cslstvdept.DataBind()
                editcvpass(CVNUM)
                csbtnsave.Visible = False
                csbtnupd.Visible = True
            Else
                csbtnsave.Visible = True
                csbtnupd.Visible = False
            End If
        End If
        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")
    End Sub
    Protected Sub csbtnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csbtnsave.Click
        Dim arrtime As String
        Dim i As Integer
        i = 0
        arrtime = csddlhr.SelectedValue + ":" + csddlmin.SelectedValue + " " + Convert.ToString(csddlam.SelectedValue)
        Dim csseldept As String = ""

        For i = 0 To cslstvdept.Items.Count - 1
            If cslstvdept.Items(i).Selected Then
                csseldept = csseldept & cslstvdept.Items(i).Value & ","
            End If
        Next
        If cslstvdept.SelectedValue = "-1" Then
            MessageBox("Select Visitor Department")
            Exit Sub
        End If

        Dim fd1 As String
        fd1 = cstxtarrival.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)



        InsertCustomerPass(_eid, csddlvtype.SelectedValue, cstxtcompname.Text, cstxtpic.Text, cstxtnop.Text, cstxtcontact.Text, fd, arrtime, cstxtpurpose.Text, cstxtrecp.Text, thisdate, _edept, csseldept, cstxtvname.Text, csrdtaxi.SelectedValue, csddltaxi.SelectedValue, csrdhotel.SelectedValue, ccddlhotel.SelectedValue, cstxthotel.Text)
        If recstatus = True Then
            cstxtpic.Text = ""
            cstxtnop.Text = ""
            cstxtcontact.Text = ""
            cstxtarrival.Text = ""
            cstxtpurpose.Text = ""
            cstxtrecp.Text = ""
            cstxtvname.Text = ""
            cstxthotel.Text = ""
            csrdtaxi.SelectedValue = "N"
            csrdhotel.SelectedValue = "N"
            csddltaxi.SelectedValue = "select"
            ccddlhotel.SelectedValue = "select"
            csddlvtype.SelectedValue = "select"
            MessageBox("Pass has been Scheduled....")
            Response.Redirect("cvselfstatus.aspx")
            ' pnlcsstatus.Visible = True
        Else
            ' pnlcsstatus.Visible = False
            MessageBox("Record Not saved....Try again !!")
        End If

    End Sub
    Protected Sub csrdtaxi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csrdtaxi.SelectedIndexChanged
        If csrdtaxi.SelectedValue = "Y" Then
            csddltaxi.Visible = True
            lbltaxi.Visible = True
        Else
            csddltaxi.Visible = False
            lbltaxi.Visible = False
        End If
    End Sub
    Protected Sub csrdhotel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csrdhotel.SelectedIndexChanged
        If csrdhotel.SelectedValue = "Y" Then
            cstxthotel.Visible = True
            lblhotel.Visible = True
            lblhotelname.Visible = True
            ccddlhotel.Visible = True
        Else
            cstxthotel.Visible = False
            lblhotel.Visible = False
            lblhotelname.Visible = False
            ccddlhotel.Visible = False
        End If
    End Sub
    Protected Sub csbtnupd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csbtnupd.Click
        Dim arrtime As String
        Dim i As Integer
        i = 0
        arrtime = csddlhr.SelectedValue + ":" + csddlmin.SelectedValue + " " + Convert.ToString(csddlam.SelectedValue)

        Dim fd1 As String
        fd1 = cstxtarrival.Text.Trim()
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim csseldept As String
        For i = 0 To cslstvdept.Items.Count - 1
            If cslstvdept.Items(i).Selected Then
                csseldept = csseldept & cslstvdept.Items(i).Value & ","
            End If
        Next
        If cstxtrecp.Text = "" Then
            cstxtrecp.Text = "-"
        End If
        If cstxtpurpose.Text = "" Then
            cstxtpurpose.Text = "-"
        End If

        UpdateCustomerPass(_eid, csddlvtype.SelectedValue, cstxtcompname.Text, cstxtpic.Text, cstxtnop.Text, cstxtcontact.Text, fd, arrtime, cstxtpurpose.Text, cstxtrecp.Text, thisdate, _edept, csseldept, cstxtvname.Text, csrdtaxi.SelectedValue, csddltaxi.SelectedValue, csrdhotel.SelectedValue, ccddlhotel.SelectedValue, cstxthotel.Text, hidrno.Value, csrdstatus.SelectedValue)
        If recstatus = True Then
            cstxtpic.Text = ""
            cstxtnop.Text = ""
            cstxtcontact.Text = ""
            cstxtarrival.Text = ""
            cstxtpurpose.Text = ""
            cstxtrecp.Text = ""
            cstxtvname.Text = ""
            cstxthotel.Text = ""
            csrdtaxi.SelectedValue = "N"
            csrdhotel.SelectedValue = "N"
            csddltaxi.SelectedValue = "select"
            ccddlhotel.SelectedValue = "select"
            csddlvtype.SelectedValue = "select"
            MessageBox("Pass has been Updated....")
            Response.Redirect("cvselfstatus.aspx")

        Else

            csbtnupd.Visible = True
            csbtnsave.Visible = False
            MessageBox("Record Not saved....Try again !!")
        End If
    End Sub
    Private Sub editcvpass(ByVal pass As String)
        Dim deldepts As String
        Try
            GetCustPassDetails(pass)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    csddlvtype.SelectedValue = dr("visitortype").ToString
                    cstxtpic.Text = dr("companypersonincharge").ToString
                    cstxtcompname.Text = dr("companyname").ToString
                    cstxtvname.Text = dr("personincharge").ToString
                    cstxtnop.Text = dr("noofperson").ToString
                    cstxtcontact.Text = dr("contactno").ToString
                    cstxtarrival.Text = Format(Convert.ToDateTime(dr("arrivaldate")), "dd/MM/yy")
                    'csddlhr.SelectedItem.Text = Format(Convert.ToDateTime(dr("arrivaltime")), "hh")
                    csddlmin.SelectedValue = Format(Convert.ToDateTime(dr("arrivaltime")), "mm")
                    csddlam.SelectedValue = Format(Convert.ToDateTime(dr("arrivaltime")), "tt")
                    cstxtpurpose.Text = dr("purpose").ToString
                    cstxtrecp.Text = dr("receptionarea").ToString
                    Dim seldept
                    seldept = dr("visitdepartment").ToString
                    Dim depts() As String = seldept.split(",")
                    Dim k, j
                    For k = 0 To depts.Length - 1
                        For j = 0 To cslstvdept.Items.Count - 1
                            If cslstvdept.Items(j).Value = (depts(k)) Then
                                cslstvdept.Items(j).Selected = True
                            End If
                        Next
                    Next

                    If Trim(dr("taxibooking")).ToString = "Y" Then
                        csrdtaxi.SelectedValue = Trim(dr("taxibooking")).ToString
                        csddltaxi.SelectedValue = dr("taxicost").ToString
                        csddltaxi.Visible = True
                        lbltaxi.Visible = True
                    Else
                        csrdtaxi.SelectedValue = Trim(dr("taxibooking")).ToString
                        csddltaxi.Visible = False
                        lbltaxi.Visible = False
                    End If
                    If Trim(dr("hotelarrangement")).ToString = "Y" Then
                        cstxthotel.Visible = True
                        lblhotel.Visible = True
                        lblhotelname.Visible = True
                        ccddlhotel.Visible = True
                        csrdhotel.SelectedValue = Trim(dr("hotelarrangement")).ToString
                        ccddlhotel.SelectedValue = dr("hotelcost").ToString
                        cstxthotel.Text = dr("hotelname").ToString
                    Else
                        csrdhotel.SelectedValue = Trim(dr("hotelarrangement")).ToString
                        cstxthotel.Visible = False
                        lblhotel.Visible = False
                        lblhotelname.Visible = False
                        ccddlhotel.Visible = False
                    End If

                    If Trim(dr("status")).ToString = "S" Then
                        csrdstatus.SelectedValue = Trim(dr("status")).ToString
                    End If
                    hidrno.Value = dr("recno").ToString
                    '  deldepts = dr("visitdepartment").ToString
                End If
            End If
            '  pnlcsstatus.Visible = False
            csbtnupd.Visible = True
            csbtnsave.Visible = False
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

End Class