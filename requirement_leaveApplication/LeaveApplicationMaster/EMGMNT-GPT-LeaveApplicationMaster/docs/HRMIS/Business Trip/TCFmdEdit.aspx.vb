Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO.Path
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TCFmdEdit
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim DynCol As Integer
    Dim TCno, BTno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("empcode") = "" Then
            Response.Redirect("~\logout.aspx")
        End If

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        If Request.QueryString("rno") <> "" Then
            TCno = Request.QueryString("rno")
            lbltc.Text = TCno
            CreateDynamicTable(TCno)
        End If
        If Request.QueryString("btno") <> "" Then
            BTno = Request.QueryString("btno")
        End If
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
    Private Sub CreateDynamicTable(ByVal tcno As String)


        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        DS = Open_TC(Con, DAP, 2, "select *, colnos as col from hrmis_tc_travellingclaimnew ,empmaster  where empmaster.empcode = hrmis_tc_travellingclaimnew.empcode and rno = '" & tcno & "' ")
        Dim dr As DataRow
        Dim columns
        Dim mybtno


        If DS.Tables("TC").Rows.Count <> 0 Then
            dr = DS.Tables(0).Rows(0)
            columns = dr("col").ToString

            lblemp.Text = dr("empcode").ToString
            lblds.Text = dr("departmentcode").ToString & "-" & dr("sectioncode").ToString
            lblname.Text = dr("empname").ToString
            'lbldepart.Text = Format(Convert.ToDateTime(dr("dtime")), "hh:mm tt")
            lblarrive.Text = Format(Convert.ToDateTime(dr("atime")), "hh:mm tt")

            If Not IsPostBack Then
                If Not dr("allowancecurrency") Is System.DBNull.Value Then
                    DDLALLOWANCE.SelectedValue = dr("allowancecurrency")
                End If

                If Not dr("tallowance") Is System.DBNull.Value Then
                    If Not dr("tallowance").ToString = "0" Then
                        txttravel.Text = dr("tallowance").ToString
                    End If
                End If
                mybtno = dr("btrno").ToString
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
                ' tcpurpose.Text = drbt("purpose").ToString
                depart = Format(Convert.ToDateTime(drbt("fromdate")), "dd/MM/yy")
                arrive = Format(Convert.ToDateTime(drbt("todate")), "dd/MM/yy")
            End If

        End If
        lbldepart.Text = depart & " " & lbldepart.Text
        lblarrive.Text = arrive & " " & lblarrive.Text
        '''

        '''

        Dim rows = 27
        columns = columns + 1 + 1
        lblcol.Text = columns

        Dim labellist As New ArrayList
        labellist.Add("DESCRIPTION")
        labellist.Add("Accomadation")
        labellist.Add("Airport / Port Tax")
        labellist.Add("Entertainment / Souvenir ")
        labellist.Add("Parking Fee ")
        labellist.Add("Petrol ")
        labellist.Add("Telephone / FAX")
        labellist.Add("Toll Fee ")
        labellist.Add("Transportation  ")
        labellist.Add("Miscellaneous ")
        labellist.Add("Others")
        labellist.Add("Other Details")
        labellist.Add("")
        labellist.Add("")
        labellist.Add("TOTAL")
        labellist.Add("Exchange Rate")
        labellist.Add("TOTAL(in RM)")
        labellist.Add("Total Expenses(in RM)") '17
        labellist.Add("Advance Amount(in RM)") '18
        labellist.Add("Cash Advance Details")  '19
        labellist.Add("cash Taken in advance ") '20
        labellist.Add("cash Refund (Amount)") '21
        labellist.Add("Refund Amount (in RM)") '22
        labellist.Add("Total Refund (in RM)") '23
        labellist.Add("Balance Details") '24
        labellist.Add("Claimable From Traveller ") '25
        labellist.Add("Payable To Traveller ") '26
        '   labellist.Add("Grand Total)") '27

        '''''''''' SEPERATE CURRENCY AND AMOUNT

        PlaceHolder1.Controls.Clear()
        Dim tblRows As Integer = rows
        Dim tblCols As Integer = columns
        Dim tbl As Table = New Table()

        ' tbl.BorderStyle = BorderStyle.Solid
        tbl.CellPadding = 1
        tbl.CellSpacing = 1
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
        Dim desc As String
        Dim RMrfund As String


        For i As Integer = 0 To tblRows - 1
            Dim tr As TableRow = New TableRow()
            For j As Integer = 0 To tblCols - 1

                If j = 0 Then
                    Dim tc As TableCell = New TableCell()
                    Dim label As New Label
                    label.Text = labellist.Item(i)
                    If i = 11 Or i = 19 Or i = 24 Then
                        tc.ColumnSpan = tblCols
                        tc.HorizontalAlign = HorizontalAlign.Center
                        tc.ControlStyle.Font.Bold = True
                        tc.BackColor = Drawing.Color.GreenYellow
                        tc.Controls.Add(label)
                        tr.Cells.Add(tc)
                    Else
                        tc.Controls.Add(label)
                        tc.BackColor = Drawing.Color.Beige
                        tr.Cells.Add(tc)
                    End If

                    If i = 14 Then
                        tc.Controls.Add(label)
                        tc.BackColor = Drawing.Color.Teal
                        tc.ForeColor = Drawing.Color.White
                        tr.Cells.Add(tc)
                    End If
                    If i = 17 Or i = 18 Or i = 23 Then
                        tc.ColumnSpan = tblCols - 1
                        tc.HorizontalAlign = HorizontalAlign.Right
                        tc.ControlStyle.Font.Bold = True
                    End If

                    If (j = 0 And i = 12) Then
                        Dim lbl As Label = New Label
                        lbl.Text = dr("description1").ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    End If
                    If (j = 0 And i = 13) Then
                        Dim lbl As Label = New Label
                        lbl.Text = dr("description2").ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    End If

                ElseIf (j = tblCols - 1 And i <> 11 And i <> 17 And i <> 18 And i <> 19 And i <> 23 And i <> 24 And i <> 25 And i <> 26) Then
                    If i = 0 Then
                        Dim tc As TableCell = New TableCell()
                        Dim label As New Label
                        Dim lbl As Label = New Label
                        lbl.Text = "Total"
                        lbl.BackColor = Drawing.Color.Orange

                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    Else
                        Dim tc As TableCell = New TableCell()
                        Dim label As New Label
                        Dim lbl As Label = New Label
                        'lbl.Text = "R" & i & "C" & j
                        lbl.ID = "R" & i & "C" & j
                        lbl.Width = 50
                        lbl.BackColor = Drawing.Color.Orange

                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    End If

                Else
                    Dim tc As TableCell = New TableCell()
                    tc.BorderWidth = 1
                    tc.BorderStyle = BorderStyle.Solid
                    tc.BorderColor = Drawing.Color.White
                    Dim lbl As TextBox = New TextBox()
                    lbl.Width = 50
                    lbl.ID = "R" & i & "C" & j
                    Dim txt As New Label
                    txt.ID = "R" & i & "C" & j
                    If i = 0 Then
                        cval = "cur" & j
                        txt.Text = dr(cval).ToString
                        tc.BackColor = Drawing.Color.Beige
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)
                    ElseIf i = 1 Then
                        aval = "ACC" & j
                        lbl.Text = dr(aval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 2 Then
                        tval = "TAX" & j
                        lbl.Text = dr(tval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 3 Then
                        enval = "ent" & j
                        lbl.Text = dr(enval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 4 Then
                        pfval = "pfee" & j
                        lbl.Text = dr(pfval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 5 Then
                        pval = "pet" & j
                        lbl.Text = dr(pval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 6 Then
                        fval = "fax" & j
                        lbl.Text = dr(fval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 7 Then
                        tolval = "toll" & j
                        lbl.Text = dr(tolval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 8 Then
                        trnval = "trans" & j
                        lbl.Text = dr(trnval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 9 Then
                        mval = "mis" & j
                        lbl.Text = dr(mval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 10 Then
                        oval = "oth" & j
                        lbl.Text = dr(oval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 12 Then
                        d1val = "desc1" & j
                        lbl.Text = dr(d1val).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 13 Then
                        d2val = "desc2" & j
                        lbl.Text = dr(d2val).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 14 Then
                        totval = "tot" & j
                        lbl.Text = dr(totval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 15 Then
                        EXRval = "EXR" & j
                        lbl.Text = dr(EXRval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 16 Then
                        RMval = "totRM" & j
                        txt.Text = dr(RMval).ToString
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)
                        tc.BackColor = Drawing.Color.Orange
                    ElseIf i = 20 Then
                        ctval = "ctaken" & j
                        lbl.Text = dr(ctval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 21 Then
                        crval = "crfund" & j
                        lbl.Text = dr(crval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 18 And j = 1 Then
                        txt.Text = dr("advanceamount")
                        tc.BackColor = Drawing.Color.Yellow
                        tc.Controls.Add(txt)
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
                        tr.Cells.Add(tc)
                    ElseIf i = 22 Then
                        RMrfund = "totalrfund" & j
                        txt.Text = dr(RMrfund).ToString
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)
                        tc.BackColor = Drawing.Color.Orange
                    ElseIf i = 25 And j = 1 Then
                        If Not dr("totalclaimable") Is System.DBNull.Value Then
                            txt.Text = dr("totalclaimable")
                            tc.BackColor = Drawing.Color.Yellow
                        Else
                            tc.BackColor = Drawing.Color.Yellow
                        End If
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)

                    ElseIf i = 26 And j = 1 Then
                        If Not dr("totalpayable") Is System.DBNull.Value Then
                            txt.Text = dr("totalpayable")
                            tc.BackColor = Drawing.Color.Yellow
                        Else
                            tc.BackColor = Drawing.Color.Yellow
                        End If
                        tc.Controls.Add(txt)
                        tr.Cells.Add(tc)
                        'ElseIf i = 27 And j = 1 Then
                        '    If Not dr("grandtotal") Is System.DBNull.Value Then
                        '        txt.Text = dr("grandtotal")
                        '    End If
                        'tc.BackColor = Drawing.Color.Red
                        'tc.ForeColor = Drawing.Color.White
                        'tc.Controls.Add(txt)
                        'tr.Cells.Add(tc)
                    End If
                    lbl.AutoPostBack = True
                    AddHandler lbl.TextChanged, AddressOf TextBox_TextChanged
                End If
            Next j
            tbl.Rows.Add(tr)
        Next i
        If Not dr("remarks") Is System.DBNull.Value Then
            txtremarks.Text = dr("remarks").ToString
        Else
            txtremarks.Text = ""
        End If
        ViewState("dynamictable") = True
    End Sub
    Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim c = lblcol.Text
        Dim total As Double
        Dim t As TextBox
        Dim txtVal As Double
        Dim finaltot As TextBox

        For i As Integer = 1 To c - 2
            For j As Integer = 1 To 13
                If Not j = 11 Then
                    Dim val = "R" & j & "C" & i
                    t = DirectCast(PlaceHolder1.FindControl(val), TextBox)
                    If t.Text = "" Then
                        t.Text = 0
                    End If
                    txtVal = Double.Parse(t.Text.ToString)
                    total = Double.Parse(total)
                    total += txtVal
                End If
            Next
            Dim totVal = "R14C" & i
            finaltot = DirectCast(PlaceHolder1.FindControl(totVal), TextBox)
            finaltot.Text = total
            total = 0
        Next
        ' to calculate tot after key in EXR
        Dim exrval As TextBox
        Dim sumval As TextBox

        Dim exrintval As Double
        Dim sumintval As Double

        Dim result As Double
        Dim totexp As Double
        totexp = 0
        Dim totrefund As Double = 0

        For i As Integer = 1 To c - 2

            Dim Exr = "R15C" & i
            exrval = DirectCast(PlaceHolder1.FindControl(Exr), TextBox)
            exrintval = Double.Parse(exrval.Text)

            Dim val = "R14C" & i
            sumval = DirectCast(PlaceHolder1.FindControl(val), TextBox)
            sumintval = Double.Parse(sumval.Text)

            result = exrintval * sumintval

            Dim refundamt As Label = DirectCast(PlaceHolder1.FindControl("R22c" & i), Label)
            Dim cashrefund As TextBox = DirectCast(PlaceHolder1.FindControl("R21c" & i), TextBox)
            Dim cashval As Double = Double.Parse(cashrefund.Text)

            Dim refundrm As Double
            refundrm = cashval * exrintval
            refundamt.Text = System.Math.Round(refundrm, 2)

            Dim totval = "R16C" & i
            Dim finaltotal As Label = DirectCast(PlaceHolder1.FindControl(totval), Label)
            finaltotal.Text = System.Math.Round(result, 2)

            Dim totalexpenses As Label = DirectCast(PlaceHolder1.FindControl("R17C1"), Label)
            totexp = totexp + result
            totalexpenses.Text = System.Math.Round(totexp, 2)
            lblexp.Text = System.Math.Round(totexp, 2)

            Dim totalrefund As Label = DirectCast(PlaceHolder1.FindControl("R23C1"), Label)
            totrefund = totrefund + refundrm
            totalrefund.Text = System.Math.Round(totrefund, 2)
            lblrefund.Text = System.Math.Round(totrefund, 2)
        Next
    End Sub
    'Private Sub Btn_click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim totexpense As Label = DirectCast(PlaceHolder1.FindControl("R17c1"), Label)
    '    Dim advamt As Label = DirectCast(PlaceHolder1.FindControl("R18c1"), Label)
    '    Dim totalrefund As Label = DirectCast(PlaceHolder1.FindControl("R23C1"), Label)

    '    Dim tot As Double
    '    Dim expense As Double
    '    Dim advance As Double
    '    Dim refund As Double
    '    If totexpense.Text <> "" Then
    '        expense = Double.Parse(totexpense.Text)
    '    End If
    '    If advamt.Text <> "" Then
    '        advance = Double.Parse(advamt.Text)
    '    End If
    '    Dim claimamt As Double
    '    Dim payamt As Double
    '    If totalrefund.Text <> "" Then
    '        refund = Double.Parse(totalrefund.Text)
    '    End If

    '    If advance > 0 And expense > 0 Then
    '        If advance > expense Then
    '            claimamt = (advance - expense)
    '            payamt = 0
    '            tot = claimamt - refund
    '        Else
    '            claimamt = 0
    '            payamt = (expense - advance)
    '            tot = payamt + refund
    '        End If

    '        Dim claim As Label = DirectCast(PlaceHolder1.FindControl("R25c1"), Label)
    '        claim.Text = claimamt
    '        lblclaim.text = claimamt

    '        Dim payable As Label = DirectCast(PlaceHolder1.FindControl("R25c3"), Label)
    '        payable.Text = payamt
    '        lblpay.Text = payamt

    '        Dim gtotal As Label = DirectCast(PlaceHolder1.FindControl("R26C1"), Label)
    '        gtotal.Text = tot
    '        lbltot.Text = tot
    '    End If
    'End Sub
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        Dim STARTLOOP = 1
        Dim deptt As String
        Dim arrt As String

        Dim cur As String
        Dim Acc As String
        Dim tax As String
        Dim ent As String
        Dim pfee As String
        Dim pet As String
        Dim fax As String
        Dim toll As String
        Dim trans As String
        Dim mis As String
        Dim oth As String
        Dim desc1 As String
        Dim desc2 As String
        Dim tot As String
        Dim ct As String
        Dim cr As String

        Dim exr As String
        Dim totrm As String
        Dim trfund As String


        Dim cval As String
        Dim ctval As String
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

        Dim exrval As String
        Dim totrmval As String
        Dim trfundval As String


        Dim aval1 As TextBox
        Dim tval1 As TextBox
        Dim enval1 As TextBox
        Dim pfval1 As TextBox
        Dim pval1 As TextBox
        Dim fval1 As TextBox
        Dim tolval1 As TextBox
        Dim trnval1 As TextBox
        Dim mval1 As TextBox
        Dim oval1 As TextBox
        Dim d1val1 As TextBox
        Dim d2val1 As TextBox
        Dim totval1 As TextBox
        Dim crval1 As TextBox
        Dim exrval1 As TextBox
        Dim totrmval1 As Label
        Dim trfundval1 As Label
        Dim endloop = lblcol.Text.Trim - 2

        Dim curallowance As String
        curallowance = DDLALLOWANCE.SelectedValue
        If txttravel.Text.Length = 0 Or curallowance = "-1" Then
            MessageBox("Please Key in Travelling allowance Details ")
            Exit Sub
        End If

        While STARTLOOP <= endloop

            cur = "cur" & STARTLOOP
            Acc = "Acc" & STARTLOOP
            tax = "tax" & STARTLOOP
            ent = "ent" & STARTLOOP
            pfee = "pfee" & STARTLOOP
            pet = "pet" & STARTLOOP
            fax = "fax" & STARTLOOP
            toll = "toll" & STARTLOOP
            trans = "trans" & STARTLOOP
            mis = "mis" & STARTLOOP
            oth = "oth" & STARTLOOP
            desc1 = "desc1" & STARTLOOP
            desc2 = "desc2" & STARTLOOP
            tot = "tot" & STARTLOOP
            ct = "CTaken" & STARTLOOP
            cr = "CRfund" & STARTLOOP
            exr = "EXR" & STARTLOOP
            totrm = "totRM" & STARTLOOP
            trfund = "totalrfund" & STARTLOOP

            aval1 = DirectCast(PlaceHolder1.FindControl("R1C" & STARTLOOP), TextBox)
            tval1 = DirectCast(PlaceHolder1.FindControl("R2C" & STARTLOOP), TextBox)
            enval1 = DirectCast(PlaceHolder1.FindControl("R3C" & STARTLOOP), TextBox)
            pfval1 = DirectCast(PlaceHolder1.FindControl("R4C" & STARTLOOP), TextBox)
            pval1 = DirectCast(PlaceHolder1.FindControl("R5C" & STARTLOOP), TextBox)
            fval1 = DirectCast(PlaceHolder1.FindControl("R6C" & STARTLOOP), TextBox)
            tolval1 = DirectCast(PlaceHolder1.FindControl("R7C" & STARTLOOP), TextBox)
            trnval1 = DirectCast(PlaceHolder1.FindControl("R8C" & STARTLOOP), TextBox)
            mval1 = DirectCast(PlaceHolder1.FindControl("R9C" & STARTLOOP), TextBox)
            oval1 = DirectCast(PlaceHolder1.FindControl("R10C" & STARTLOOP), TextBox)
            d1val1 = DirectCast(PlaceHolder1.FindControl("R12C" & STARTLOOP), TextBox)
            d2val1 = DirectCast(PlaceHolder1.FindControl("R13C" & STARTLOOP), TextBox)
            totval1 = DirectCast(PlaceHolder1.FindControl("R14C" & STARTLOOP), TextBox)
            exrval1 = DirectCast(PlaceHolder1.FindControl("R15C" & STARTLOOP), TextBox)
            totrmval1 = DirectCast(PlaceHolder1.FindControl("R16C" & STARTLOOP), Label)
            crval1 = DirectCast(PlaceHolder1.FindControl("R21C" & STARTLOOP), TextBox)
            trfundval1 = DirectCast(PlaceHolder1.FindControl("R22C" & STARTLOOP), Label)

            aval = aval1.Text.Trim
            tval = tval1.Text.Trim
            enval = enval1.Text.Trim
            pfval = pfval1.Text.Trim
            pval = pval1.Text.Trim
            fval = fval1.Text.Trim
            tolval = tolval1.Text.Trim
            trnval = trnval1.Text.Trim
            mval = mval1.Text.Trim
            oval = oval1.Text.Trim
            d1val = d1val1.Text.Trim
            d2val = d2val1.Text.Trim
            totval = totval1.Text.Trim
            crval = crval1.Text.Trim

            exrval = exrval1.Text.Trim
            totrmval = totrmval1.Text.Trim
            trfundval = trfundval1.Text.Trim

            Dim Sqlstat As String

            '''''For side calculation entry
            Dim accval = "R1C" & endloop + 1
            Dim acco As Label = DirectCast(PlaceHolder1.FindControl(accval), Label)

            Dim portval = "R2C" & endloop + 1
            Dim port As Label = DirectCast(PlaceHolder1.FindControl(portval), Label)

            Dim entval = "R3C" & endloop + 1
            Dim entv As Label = DirectCast(PlaceHolder1.FindControl(entval), Label)

            Dim parkval = "R4C" & endloop + 1
            Dim park As Label = DirectCast(PlaceHolder1.FindControl(parkval), Label)

            Dim petrolval = "R5C" & endloop + 1
            Dim petrol As Label = DirectCast(PlaceHolder1.FindControl(petrolval), Label)

            Dim phval = "R6C" & endloop + 1
            Dim phone As Label = DirectCast(PlaceHolder1.FindControl(phval), Label)

            Dim tollval = "R7C" & endloop + 1
            Dim tollv As Label = DirectCast(PlaceHolder1.FindControl(tollval), Label)

            Dim transval = "R8C" & endloop + 1
            Dim transv As Label = DirectCast(PlaceHolder1.FindControl(transval), Label)

            Dim miscval = "R9C" & endloop + 1
            Dim misc As Label = DirectCast(PlaceHolder1.FindControl(miscval), Label)

            Dim othval = "R10C" & endloop + 1
            Dim other As Label = DirectCast(PlaceHolder1.FindControl(othval), Label)

            Dim oth1val = "R12C" & endloop + 1
            Dim other1 As Label = DirectCast(PlaceHolder1.FindControl(oth1val), Label)

            Dim oth2val = "R13C" & endloop + 1
            Dim other2 As Label = DirectCast(PlaceHolder1.FindControl(oth2val), Label)
            ''' end here
       

            Try
                Sqlstat = "update HRMIS_TC_Travellingclaimnew set AllowanceinRM = '" & lblTA.Text.Trim & "',AllowanceEXR = '" & txtea.Text & "',totalexpenses = '" & lblexp.Text & "',allowancecurrency = '" & curallowance & "' ,tallowance = '" & txttravel.Text & "', totalpayable='" & lblpay.Text & "',totalclaimable='" & lblclaim.Text & "',totalrefund='" & lblrefund.Text & "',remarks = '" & txtremarks.Text & "'," & Acc & " = '" & aval & "'," & tax & " = '" & tval & "'," & ent & " = '" & enval & "'," & pfee & " = '" & pfval & "'," & pet & " = '" & pval & "'," & fax & " = '" & fval & "'," & toll & " = '" & tolval & "'," & trans & " = '" & trnval & "' ," & mis & " = '" & mval & "'," & oth & " = '" & oval & "'," & desc1 & " = '" & d1val & "' ," & desc2 & " = '" & d2val & "'," & tot & " = '" & totval + "' ," & cr & " = '" & crval & "'," & exr & " = '" & exrval & "'," & totrm & " = '" & totrmval & "'," & trfund & " = '" & trfundval & "',totalacco = '" & acco.Text.Trim & "',totalairport = '" & port.Text.Trim & "',totalent = '" & entv.Text.Trim & "',totalpark = '" & park.Text.Trim & "',totalpetrol = '" & petrol.Text.Trim & "',totalphone = '" & phone.Text.Trim & "' ,totaltoll = '" & tollv.Text.Trim & "',totaltrans = '" & transv.Text.Trim & "',totalmisc = '" & misc.Text.Trim & "',totalothers = '" & other.Text.Trim & "',totaloth1 = '" & other1.Text.Trim & "',totaloth2 = '" & other2.Text.Trim & "'  where rno = '" & lbltc.Text.Trim & "'"
                ' Sqlstat = "update HRMIS_TC_Travellingclaimnew set " & cur & " = '" & cval & "'," & Acc & " = '" & aval & "'," & tax & " = '" & tval & "'," & ent & " = '" & enval & "'," & pfee & " = '" & pfval & "'," & pet & " = '" & pval & "'," & fax & " = '" & fval & "'," & toll & " = '" & tolval & "'," & trans & " = '" & trnval & "' ," & mis & " = '" & mval & "'," & oth & " = '" & oval & "'," & desc1 & " = '" & d1val & "' ," & desc2 & " = '" & d2val & "'," & tot & " = '" & totval & "' ," & ct & " = '" & ctval & "'," & cr & " = '" & crval & "' where rno = '" & rno & "'"
                DS = Open_TC(Con, DAP, 2, Sqlstat)
            Catch ex As Exception
                MessageBox("Cannot Save." & ex.Message)
                Exit Sub
            End Try
            STARTLOOP = STARTLOOP + 1

        End While
        MessageBox("REcord Modified")
        Response.Redirect("tcfinance.aspx")

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dototalcalculation()
        lblpay.Text = "0"
        lblclaim.Text = "0"
        Dim totexpense As Label = DirectCast(PlaceHolder1.FindControl("R17c1"), Label)
        Dim advamt As Label = DirectCast(PlaceHolder1.FindControl("R18c1"), Label)
        Dim totalrefund As Label = DirectCast(PlaceHolder1.FindControl("R23C1"), Label)

        Dim tot As Double
        Dim expense As Double
        Dim advance As Double
        Dim refund As Double

        If txttravel.Text.Length = 0 Or DDLALLOWANCE.SelectedValue = "-1" Then
            MessageBox("Please Key in Travelling allowance Details ")
            Exit Sub
        End If

        If txtea.Text = "" Then
            MessageBox("Please key in Ex.Rate of Travellin allowance Currency!!")
            Exit Sub
        End If

        Dim totallowance As Double
        totallowance = lblTA.Text

        If totexpense.Text <> "" Then
            expense = Double.Parse(totexpense.Text) + totallowance
        End If


        totexpense.Text = expense
        lblexp.Text = expense

        If advamt.Text <> "" Then
            advance = Double.Parse(advamt.Text)
        End If
        Dim claimamt As Double
        Dim payamt As Double

        If totalrefund.Text <> "" Then
            refund = Double.Parse(totalrefund.Text)
        End If

        Dim allowance As Double
        Dim exr As Double

        If txttravel.Text <> "" And txtea.Text <> "" Then
            allowance = Double.Parse(txttravel.Text)
            exr = Double.Parse(txtea.Text)
        End If


        If txttravel.Text <> "" And txtea.Text <> "" Then
            ' lblTA.Text = allowance * exr
            lblTA.Text = System.Math.Round(allowance * exr, 2)
        End If


        If advance >= 0 And expense > 0 Then
            If advance > expense Then
                'claimamt = (advance - expense)
                'payamt = 0
                'tot = claimamt - refund
                'Dim claim As Label = DirectCast(PlaceHolder1.FindControl("R25c1"), Label)
                'Dim payable As Label = DirectCast(PlaceHolder1.FindControl("R26c1"), Label)

                ''If tot > totallowance Then
                ''    tot = tot - totallowance
                ''    claim.Text = tot
                ''    lblclaim.Text = tot
                ''    lblpay.Text = 0
                ''    payable.Text = 0
                ''ElseIf tot < totallowance Then
                ''    claim.Text = 0
                ''    lblclaim.Text = 0
                ''    lblpay.Text = totallowance - tot
                ''    payable.Text = totallowance - tot
                ''ElseIf tot = totallowance Then
                ''    claim.Text = 0
                ''    lblclaim.Text = 0
                ''    lblpay.Text = 0
                ''    payable.Text = 0
                ''End If

                'claim.Text = System.Math.Round(tot, 2)
                'lblclaim.Text = System.Math.Round(tot, 2)
                'lblpay.Text = 0
                'payable.Text = 0

                claimamt = (advance - expense)
                payamt = 0
                Dim claim As Label = DirectCast(PlaceHolder1.FindControl("R25c1"), Label)
                Dim payable As Label = DirectCast(PlaceHolder1.FindControl("R26c1"), Label)

                If refund > claimamt Then
                    tot = refund - claimamt
                    payable.Text = System.Math.Round(tot, 2)
                    lblpay.Text = System.Math.Round(tot, 2)
                    claim.Text = 0
                    lblclaim.Text = 0
                Else
                    tot = claimamt - refund
                    claim.Text = System.Math.Round(tot, 2)
                    lblclaim.Text = System.Math.Round(tot, 2)
                    lblpay.Text = 0
                    payable.Text = 0
                End If

            Else
                claimamt = 0
                payamt = (expense - advance)
                tot = payamt + refund
                Dim payable As Label = DirectCast(PlaceHolder1.FindControl("R26c1"), Label)
                payable.Text = System.Math.Round(tot, 2)
                lblpay.Text = System.Math.Round(tot, 2)
                lblclaim.Text = 0

                Dim claim As Label = DirectCast(PlaceHolder1.FindControl("R25c1"), Label)
                claim.Text = 0
            End If
            'Dim gtotal As Label = DirectCast(PlaceHolder1.FindControl("R27C1"), Label)
            'gtotal.Text = tot
            'lbltot.Text = tot
        End If
        ''' Perform vertical calculation

        Dim rows = 27
        Dim cols = lblcol.Text
        Dim AccoTot
        Dim APTot
        Dim EntTot
        Dim ParkTot
        Dim PetrolTot
        Dim FaxTot
        Dim tolltot
        Dim Transtot
        Dim MiscTot
        Dim Othtot
        Dim Oth1Tot
        Dim Oth2Tot

        Dim t
        Dim txtval
        Dim total
        Dim exrtxt
        Dim exrval
        For i As Integer = 1 To 13
            For j As Integer = 1 To cols - 2
                If Not i = 11 Then
                    Dim accval = "R1C" & j
                    Dim acc As TextBox = DirectCast(PlaceHolder1.FindControl(accval), TextBox)

                    Dim portval = "R2C" & j
                    Dim port As TextBox = DirectCast(PlaceHolder1.FindControl(portval), TextBox)

                    Dim entval = "R3C" & j
                    Dim ent As TextBox = DirectCast(PlaceHolder1.FindControl(entval), TextBox)

                    Dim parkval = "R4C" & j
                    Dim park As TextBox = DirectCast(PlaceHolder1.FindControl(parkval), TextBox)

                    Dim petrolval = "R5C" & j
                    Dim petrol As TextBox = DirectCast(PlaceHolder1.FindControl(petrolval), TextBox)

                    Dim phval = "R6C" & j
                    Dim phone As TextBox = DirectCast(PlaceHolder1.FindControl(phval), TextBox)

                    Dim tollval = "R7C" & j
                    Dim toll As TextBox = DirectCast(PlaceHolder1.FindControl(tollval), TextBox)

                    Dim transval = "R8C" & j
                    Dim trans As TextBox = DirectCast(PlaceHolder1.FindControl(transval), TextBox)

                    Dim miscval = "R9C" & j
                    Dim misc As TextBox = DirectCast(PlaceHolder1.FindControl(miscval), TextBox)

                    Dim othval = "R10C" & j
                    Dim other As TextBox = DirectCast(PlaceHolder1.FindControl(othval), TextBox)

                    Dim oth1val = "R12C" & j
                    Dim other1 As TextBox = DirectCast(PlaceHolder1.FindControl(oth1val), TextBox)

                    Dim oth2val = "R13C" & j
                    Dim other2 As TextBox = DirectCast(PlaceHolder1.FindControl(oth2val), TextBox)


                    Dim Exrt = "R15C" & j
                    exrval = DirectCast(PlaceHolder1.FindControl(Exrt), TextBox)
                    If exrval.text = "" Then
                        exrval.text = "0"
                    End If

                    '''''''''''''''''
                    If i = 1 Then

                        If acc.Text = "" Then
                            acc.Text = "0"
                        End If
                        Dim AccoRes
                        AccoTot = Double.Parse(acc.Text) * Double.Parse(exrval.text)
                        Dim atotVal = "R1C" & cols - 1
                        AccoRes += AccoTot
                        Dim acccomadation As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        acccomadation.Text = System.Math.Round(AccoRes, 2)

                    ElseIf i = 2 Then

                        If port.Text = "" Then
                            port.Text = "0"
                        End If
                        Dim portRes
                        APTot = Double.Parse(port.Text) * Double.Parse(exrval.text)
                        portRes += APTot

                        Dim atotVal = "R2C" & cols - 1
                        Dim airport As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        airport.Text = System.Math.Round(portRes, 2)

                    ElseIf i = 3 Then

                        If ent.Text = "" Then
                            ent.Text = "0"
                        End If

                        EntTot = Double.Parse(ent.Text) * Double.Parse(exrval.text)
                        Dim entRes
                        entRes += EntTot

                        Dim atotVal = "R3C" & cols - 1
                        Dim airport As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        airport.Text = System.Math.Round(entRes, 2)

                    ElseIf i = 4 Then

                        If park.Text = "" Then
                            park.Text = "0"
                        End If

                        ParkTot = Double.Parse(park.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += ParkTot

                        Dim atotVal = "R4C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 5 Then

                        If petrol.Text = "" Then
                            petrol.Text = "0"
                        End If

                        PetrolTot = Double.Parse(petrol.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += PetrolTot

                        Dim atotVal = "R5C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 6 Then

                        If phone.Text = "" Then
                            phone.Text = "0"
                        End If

                        Dim totr
                        totr = Double.Parse(phone.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += totr

                        Dim atotVal = "R6C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 7 Then

                        If toll.Text = "" Then
                            toll.Text = "0"
                        End If

                        Dim totr
                        totr = Double.Parse(toll.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += totr

                        Dim atotVal = "R7C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 8 Then

                        If trans.Text = "" Then
                            trans.Text = "0"
                        End If

                        Dim totr
                        totr = Double.Parse(trans.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += totr

                        Dim atotVal = "R8C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 9 Then

                        If misc.Text = "" Then
                            misc.Text = "0"
                        End If

                        Dim totr
                        totr = Double.Parse(misc.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += totr

                        Dim atotVal = "R9C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 10 Then

                        If other.Text = "" Then
                            other.Text = "0"
                        End If

                        Dim totr
                        totr = Double.Parse(other.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += totr

                        Dim atotVal = "R10C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 12 Then

                        If other1.Text = "" Then
                            other1.Text = "0"
                        End If

                        Dim totr
                        totr = Double.Parse(other1.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += totr

                        Dim atotVal = "R12C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)

                    ElseIf i = 13 Then

                        If other2.Text = "" Then
                            other2.Text = "0"
                        End If

                        Dim totr
                        totr = Double.Parse(other2.Text) * Double.Parse(exrval.text)
                        Dim Res
                        Res += totr

                        Dim atotVal = "R13C" & cols - 1
                        Dim lbl As Label = DirectCast(PlaceHolder1.FindControl(atotVal), Label)
                        lbl.Text = System.Math.Round(Res, 2)
                    End If
                End If
            Next
        Next

    End Sub
    Private Sub dototalcalculation()
        Dim c = lblcol.Text
        Dim total As Double
        Dim t As TextBox
        Dim txtVal As Double
        Dim finaltot As TextBox

        For i As Integer = 1 To c - 2
            For j As Integer = 1 To 13
                If Not j = 11 Then
                    Dim val = "R" & j & "C" & i
                    t = DirectCast(PlaceHolder1.FindControl(val), TextBox)
                    If t.Text = "" Then
                        t.Text = 0
                    End If
                    txtVal = Double.Parse(t.Text.ToString)
                    total = Double.Parse(total)
                    total += txtVal
                End If
            Next
            Dim totVal = "R14C" & i
            finaltot = DirectCast(PlaceHolder1.FindControl(totVal), TextBox)
            finaltot.Text = System.Math.Round(total, 2)
            total = 0
        Next
        ' to calculate tot after key in EXR
        Dim exrval As TextBox
        Dim sumval As TextBox

        Dim exrintval As Double
        Dim sumintval As Double

        Dim result As Double
        Dim totexp As Double
        totexp = 0
        Dim totrefund As Double = 0

        For i As Integer = 1 To c - 2

            Dim Exr = "R15C" & i
            exrval = DirectCast(PlaceHolder1.FindControl(Exr), TextBox)
            exrintval = Double.Parse(exrval.Text)

            Dim val = "R14C" & i
            sumval = DirectCast(PlaceHolder1.FindControl(val), TextBox)
            sumintval = Double.Parse(sumval.Text)

            result = exrintval * sumintval

            Dim refundamt As Label = DirectCast(PlaceHolder1.FindControl("R22c" & i), Label)
            Dim cashrefund As TextBox = DirectCast(PlaceHolder1.FindControl("R21c" & i), TextBox)
            Dim cashval As Double = Double.Parse(cashrefund.Text)

            Dim refundrm As Double
            refundrm = cashval * exrintval
            refundamt.Text = refundrm

            Dim totval = "R16C" & i
            Dim finaltotal As Label = DirectCast(PlaceHolder1.FindControl(totval), Label)
            finaltotal.Text = System.Math.Round(result, 2)

            Dim totalexpenses As Label = DirectCast(PlaceHolder1.FindControl("R17C1"), Label)
            totexp = totexp + result
            totalexpenses.Text = System.Math.Round(totexp, 2)
            lblexp.Text = System.Math.Round(totexp, 2)

            Dim totalrefund As Label = DirectCast(PlaceHolder1.FindControl("R23C1"), Label)
            totrefund = totrefund + refundrm
            totalrefund.Text = System.Math.Round(totrefund, 2)
            lblrefund.Text = System.Math.Round(totrefund, 2)
        Next
    End Sub
    Protected Sub txtea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtea.TextChanged
        Dim allowance As Double
        Dim exr As Double
        If txttravel.Text.Trim <> "" And txtea.Text.Trim <> "" Then
            allowance = Double.Parse(txttravel.Text)
            exr = Double.Parse(txtea.Text)
        End If
        If txtea.Text = "" Then
            MessageBox("Please key in Ex.Rate of Travellin allowance Currency!!")
            Exit Sub
        End If
        If txttravel.Text <> "" Or txtea.Text <> "" Then
            lblTA.Text = System.Math.Round(allowance * exr, 2)
        End If
    End Sub

    Protected Sub txttravel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttravel.TextChanged
        Dim allowance As Double
        Dim exr As Double

        If txttravel.Text.Trim <> "" And txtea.Text.Trim <> "" Then
            allowance = Double.Parse(txttravel.Text)
            exr = Double.Parse(txtea.Text)
        End If

        If txtea.Text = "" Then
            MessageBox("Please key in Ex.Rate of Travellin allowance Currency!!")
            Exit Sub
        End If

        If txttravel.Text <> "" Or txtea.Text <> "" Then
            lblTA.Text = System.Math.Round(allowance * exr, 2)
        End If
    End Sub
End Class