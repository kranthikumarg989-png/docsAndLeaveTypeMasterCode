Imports System.Data
Imports System.Web.Security
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TCPRINT
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim DynCol As Integer
    Dim TCno, BTno, stat

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empcode") = "" Then
            Response.Redirect("~\logout.aspx")
        End If

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        stat = Request.QueryString("stat")
        If Request.QueryString("rno") <> "" And stat = 1 Then
            TCno = Request.QueryString("rno")
            CreateDynamicTable(TCno)
            lbprint.Visible = False
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.print('tcPRINT.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")

        ElseIf Request.QueryString("rno") <> "" And stat <> 1 Then
            TCno = Request.QueryString("rno")
            CreateDynamicTable(TCno)
            lbprint.Visible = True
        End If

    End Sub
    Private Sub CreateDynamicTable(ByVal tcno As String)

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        ' DS = Open_TC(Con, DAP, 2, "select *, colnos as col from hrmis_tc_travellingclaimnew where rno = '" & tcno & "' ")
        DS = Open_TC(Con, DAP, 2, "select *, colnos as col,* from hrmis_tc_travellingclaimnew,empmaster  where empmaster.empcode = hrmis_tc_travellingclaimnew.empcode and rno = '" & tcno & "' ")

        Dim dr As DataRow
        Dim columns
        Dim ddlallowance = ""
        Dim txttravel = ""
        Dim mybtno

        If DS.Tables("TC").Rows.Count <> 0 Then
            dr = DS.Tables(0).Rows(0)
            columns = dr("col").ToString
            lblbt.Text = dr("btrno").ToString
            lblemp.Text = dr("empcode").ToString
            lblds.Text = dr("departmentcode").ToString & "-" & dr("sectioncode").ToString
            lblname.Text = dr("empname").ToString


            lbldepart.Text = Format(Convert.ToDateTime(dr("dtime")), "hh:mm")
            lblarrive.Text = Format(Convert.ToDateTime(dr("atime")), "hh:mm")

            If Not dr("allowancecurrency") Is System.DBNull.Value Then
                ddlallowance = dr("allowancecurrency").ToString
            End If

            If Not dr("tallowance") Is System.DBNull.Value Then
                txttravel = dr("tallowance").ToString
            End If

            If Not dr("allowanceinRM") Is System.DBNull.Value Then
                allowanceRM.Text = dr("allowanceinRM").ToString
            End If
            lblallowance.Text = txttravel & " " & ddlallowance
            mybtno = dr("btrno").ToString

            If Not dr("AllowanceEXR") Is System.DBNull.Value Then
                lblex.Text = dr("AllowanceEXR").ToString
            End If
            If Not dr("fmdremarks") Is System.DBNull.Value Then
                txtremarks.Text = dr("fmdremarks").ToString
            End If

        Else
            columns = 0
        End If


        Dim dsbt As DataSet
        Dim drbt As DataRow
        Dim depart, arrive


        dsbt = Open_BT(Con, DAP, 1, "where recno = '" & mybtno & "'")
        If dsbt.Tables("BT").Rows.Count <> 0 Then
            drbt = dsbt.Tables(0).Rows(0)

            lbldepart.Text = Format(Convert.ToDateTime(dr("dtime")), "hh:mm tt")
            lblarrive.Text = Format(Convert.ToDateTime(dr("atime")), "hh:mm tt")
            If Not IsPostBack Then
                If Not drbt("COLLEAGUE_DETAILS") Is System.DBNull.Value Then
                    tcname.Text = drbt("COLLEAGUE_DETAILS").ToString
                    tcname.Text = tcname.Text.TrimEnd(",")
                End If

                If Not drbt("sharedepts") Is System.DBNull.Value Then
                    tcdept.Text = drbt("sharedepts").ToString
                    tcdept.Text = tcdept.Text.TrimEnd(",")
                End If

                If Not drbt("destination") Is System.DBNull.Value Then
                    TCDEST.Text = drbt("destination").ToString
                End If
                tcpurpose.Text = drbt("purpose").ToString
                depart = Format(Convert.ToDateTime(drbt("fromdate")), "dd/MM/yy")
                arrive = Format(Convert.ToDateTime(drbt("todate")), "dd/MM/yy")
            End If

        End If

        lbldepart.Text = depart & " " & lbldepart.Text
        lblarrive.Text = arrive & " " & lblarrive.Text


        Dim rows = 27
        columns = columns + 1 + 1

        Dim labellist As New ArrayList
        labellist.Add("DESCRIPTION")
        labellist.Add("Accommodation")
        labellist.Add("Airport / Port Tax")
        labellist.Add("Entertainment / Souvenir ")
        labellist.Add("Parking Fee ")
        labellist.Add("Petrol ")
        labellist.Add("Telephone / FAX")
        labellist.Add("Toll Fee ")
        labellist.Add("Transportation  ")
        labellist.Add("Miscellaneous ")
        labellist.Add("Others")
        labellist.Add("OTHER DETAILS")
        labellist.Add("")
        labellist.Add("")
        labellist.Add("TOTAL")
        labellist.Add("Exchange Rate")
        labellist.Add("TOTAL(in RM)")
        labellist.Add("Total Expenses(in RM)") '17
        labellist.Add("Advance Amount(in RM)") '18
        labellist.Add("CASH ADVANCE DETAILS")  '19
        labellist.Add("cash Taken in advance ") '20
        labellist.Add("cash Refund (Amount)") '21
        labellist.Add("Refund Amount (in RM)") '22
        labellist.Add("Total Refund (in RM)") '23
        labellist.Add("BALANCE DETAILS") '24
        labellist.Add("Claimable From Traveller ") '25
        labellist.Add("Payable To Traveller ") '26
        'labellist.Add("Grand Total)") '27

        '''''''''' SEPERATE CURRENCY AND AMOUNT

        PlaceHolder1.Controls.Clear()
        Dim tblRows As Integer = rows
        Dim tblCols As Integer = columns
        Dim tbl As Table = New Table()

        tbl.BorderWidth = 1
        tbl.BorderStyle = BorderStyle.Solid
        tbl.BorderColor = Drawing.Color.Black
        tbl.CellPadding = 3
        tbl.CellSpacing = 0
        tbl.Font.Size = 10
        '   tbl.Font.Name = "calibri"

        tbl.Width = 650%
        tbl.Height = 700%
        tbl.BackColor = Drawing.Color.White


        PlaceHolder1.Controls.Add(tbl)

        Dim cval As String
        Dim aval As String
        Dim tval As String
        Dim enval As String
        Dim pfval As String
        Dim pval As String
        Dim fval As String
        Dim tolval As String
        Dim trnval As String
        Dim mval As String
        Dim oval As String
        Dim d1val As String
        Dim d2val As String
        Dim totval As String
        Dim crval As String
        Dim ctval As String
        Dim EXRval As String
        Dim RMval As String
        Dim rmrfund As String
        For i As Integer = 0 To tblRows - 1
            Dim tr As TableRow = New TableRow()
            For j As Integer = 0 To tblCols - 1
                If j = 0 Then
                    Dim tc As TableCell = New TableCell()
                    Dim label As New Label
                    label.Text = labellist.Item(i)
                    If i = 11 Or i = 19 Or i = 24 Then
                        tc.ColumnSpan = tblCols
                        tc.HorizontalAlign = HorizontalAlign.Left
                        tc.ControlStyle.Font.Bold = True
                        tc.Controls.Add(label)
                        tc.BackColor = Drawing.Color.GreenYellow
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    Else
                        tc.Controls.Add(label)
                        tc.BackColor = Drawing.Color.Beige
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    End If
                    If i = 14 Then

                        tc.Controls.Add(label)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    End If
                    If i = 17 Or i = 18 Or i = 23 Then
                        tc.ColumnSpan = tblCols - 1
                        tc.HorizontalAlign = HorizontalAlign.Right
                        tc.ControlStyle.Font.Bold = True
                        tc.BorderWidth = 1
                    End If
                    If (j = 0 And i = 12) Then
                        Dim lbl As Label = New Label
                        If Not dr("description1") Is System.DBNull.Value Then
                            lbl.Text = dr("description1").ToString
                        End If
                        tc.BorderWidth = 1
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)

                    End If
                    If (j = 0 And i = 13) Then
                        Dim lbl As Label = New Label
                        If Not dr("description2") Is System.DBNull.Value Then
                            lbl.Text = dr("description2").ToString
                        End If
                        tc.Controls.Add(lbl)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    End If

                ElseIf (j = tblCols - 1 And i <> 11 And i <> 17 And i <> 18 And i <> 19 And i <> 23 And i <> 24 And i <> 25 And i <> 26) Then
                    Dim tc As TableCell = New TableCell()
                    Dim label As New Label
                    Dim lbl As Label = New Label
                    If i = 0 Then
                        lbl.Text = "Total"
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 1 Then
                        If Not dr("totalacco") Is System.DBNull.Value Then
                            lbl.Text = dr("totalacco").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 2 Then
                        If Not dr("totalairport") Is System.DBNull.Value Then
                            lbl.Text = dr("totalairport").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 3 Then
                        If Not dr("totalent") Is System.DBNull.Value Then
                            lbl.Text = dr("totalent").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 4 Then
                        If Not dr("totalpark") Is System.DBNull.Value Then
                            lbl.Text = dr("totalpark").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 5 Then
                        If Not dr("totalpetrol") Is System.DBNull.Value Then
                            lbl.Text = dr("totalpetrol").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 6 Then
                        If Not dr("totalphone") Is System.DBNull.Value Then
                            lbl.Text = dr("totalphone").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 7 Then
                        If Not dr("totaltoll") Is System.DBNull.Value Then
                            lbl.Text = dr("totaltoll").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 8 Then
                        If Not dr("totaltrans") Is System.DBNull.Value Then
                            lbl.Text = dr("totaltrans").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 9 Then
                        If Not dr("totalmisc") Is System.DBNull.Value Then
                            lbl.Text = dr("totalmisc").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 10 Then
                        If Not dr("totalothers") Is System.DBNull.Value Then
                            lbl.Text = dr("totalothers").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 12 Then
                        If Not dr("totaloth1") Is System.DBNull.Value Then
                            lbl.Text = dr("totaloth1").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 13 Then
                        If Not dr("totaloth2") Is System.DBNull.Value Then
                            lbl.Text = dr("totaloth2").ToString
                        End If
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    End If
                Else
                    Dim tc As TableCell = New TableCell()
                    tc.BorderWidth = 1
                    tc.BorderStyle = BorderStyle.Solid
                    tc.BorderColor = Drawing.Color.Black

                    Dim txt As New Label
                    txt.ID = "R" & i & "C" & j
                    If i = 0 Then
                        cval = "cur" & j
                        txt.Text = dr(cval).ToString
                        tc.BackColor = Drawing.Color.Beige
                        tc.Controls.Add(txt)
                        tc.BorderStyle = BorderStyle.Solid
                        tc.BorderColor = Drawing.Color.Black
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 1 Then
                        aval = "ACC" & j
                        txt.Text = dr(aval).ToString
                        tc.Controls.Add(txt)

                        tc.BorderStyle = BorderStyle.Solid
                        tc.BorderColor = Drawing.Color.Black
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 2 Then
                        tval = "TAX" & j
                        txt.Text = dr(tval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 3 Then
                        enval = "ent" & j
                        txt.Text = dr(enval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 4 Then
                        pfval = "pfee" & j
                        txt.Text = dr(pfval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 5 Then
                        pval = "pet" & j
                        txt.Text = dr(pval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 6 Then
                        fval = "fax" & j
                        txt.Text = dr(fval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 7 Then
                        tolval = "toll" & j
                        txt.Text = dr(tolval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 8 Then
                        trnval = "trans" & j
                        txt.Text = dr(trnval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 9 Then
                        mval = "mis" & j
                        txt.Text = dr(mval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 10 Then
                        oval = "oth" & j
                        txt.Text = dr(oval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 12 Then
                        d1val = "desc1" & j
                        txt.Text = dr(d1val).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 13 Then
                        d2val = "desc2" & j
                        txt.Text = dr(d2val).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 14 Then
                        totval = "tot" & j
                        txt.Text = dr(totval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 15 Then
                        EXRval = "EXR" & j
                        txt.Text = dr(EXRval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 16 Then
                        RMval = "totRM" & j
                        txt.Text = dr(RMval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                        tc.BackColor = Drawing.Color.Orange

                    ElseIf i = 20 Then
                        ctval = "ctaken" & j
                        txt.Text = dr(ctval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 21 Then
                        crval = "crfund" & j
                        txt.Text = dr(crval).ToString
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 18 And j = 1 Then
                        txt.Text = dr("advanceamount")
                        tc.BackColor = Drawing.Color.Yellow
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                    ElseIf i = 17 And j = 1 Then
                        If Not dr("totalexpenses") Is System.DBNull.Value Then
                            txt.Text = dr("totalExpenses")
                            tc.BackColor = Drawing.Color.Teal
                            tc.ForeColor = Drawing.Color.White
                        Else
                            tc.BackColor = Drawing.Color.Teal
                            tc.ForeColor = Drawing.Color.White
                        End If
                        tc.BorderWidth = 1
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)
                    ElseIf i = 23 And j = 1 Then
                        If Not dr("totalrefund") Is System.DBNull.Value Then
                            txt.Text = dr("totalrefund")
                            tc.BackColor = Drawing.Color.Teal
                            tc.ForeColor = Drawing.Color.White
                        Else
                            tc.BackColor = Drawing.Color.Teal
                            tc.ForeColor = Drawing.Color.White
                        End If
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)

                    ElseIf i = 22 Then
                        rmrfund = "totalrfund" & j
                        txt.Text = dr(rmrfund).ToString
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)
                        tc.BorderWidth = 1
                        tc.BackColor = Drawing.Color.Yellow

                    ElseIf i = 25 And j = 1 Then
                        If Not dr("totalclaimable") Is System.DBNull.Value Then
                            txt.Text = dr("totalclaimable")
                            tc.BackColor = Drawing.Color.Yellow
                        Else
                            tc.BackColor = Drawing.Color.Yellow
                        End If
                        tc.Controls.Add(txt)
                        tc.BorderWidth = 1
                        tr.Cells.Add(tc)
                      
                    ElseIf i = 26 And j = 1 Then
                        If Not dr("totalpayable") Is System.DBNull.Value Then
                            txt.Text = dr("totalpayable")
                            tc.BackColor = Drawing.Color.Yellow
                        Else
                            tc.BackColor = Drawing.Color.Yellow
                        End If
                        tc.BorderWidth = 1
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)


                    End If
                End If
            Next j
            tbl.BorderWidth = 1
            tbl.Rows.Add(tr)
        Next i
        ViewState("dynamictable") = True
    End Sub
    ' Rows property to hold the Rows in the ViewState
    Protected Property Rows() As Integer
        Get
            If Not ViewState("Rows") Is Nothing Then
                Return CInt(Fix(ViewState("Rows")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Rows") = value
        End Set
    End Property
    ' Columns property to hold the Columns in the ViewState
    Protected Property Columns() As Integer
        Get
            If Not ViewState("Columns") Is Nothing Then
                Return CInt(Fix(ViewState("Columns")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Columns") = value
        End Set
    End Property

    Protected Sub lbprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbprint.Click
        lbprint.Visible = False
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.print('tcPRINT.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")

    End Sub
End Class