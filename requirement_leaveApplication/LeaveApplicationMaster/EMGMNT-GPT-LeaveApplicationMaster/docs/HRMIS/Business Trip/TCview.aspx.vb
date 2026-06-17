Imports System.Data
Imports System.Web.Security
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TCview
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
            CreateDynamicTable(TCno)
            lbprint.Visible = False
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.print('tcview.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")
        End If

        If Request.QueryString("btno") <> "" Then
            BTno = Request.QueryString("btno")
            CreateDynamicTable(TCno)
        End If
        ' tcprint.aspx?rno={0}&stat=1
    End Sub
    Private Sub CreateDynamicTable(ByVal tcno As String)

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '  DS = Open_TC(Con, DAP, 2, "select *, colnos as col from hrmis_tc_travellingclaimnew where rno = '" & tcno & "' ")
        DS = Open_TC(Con, DAP, 2, "select *, colnos as col,* from hrmis_tc_travellingclaimnew,empmaster  where empmaster.empcode = hrmis_tc_travellingclaimnew.empcode and rno = '" & tcno & "' ")

        Dim dr As DataRow
        Dim columns
        Dim ddlallowance = ""
        Dim txttravel = ""
        Dim mybtno

        'If DS.Tables("TC").Rows.Count <> 0 Then
        '    dr = DS.Tables(0).Rows(0)
        '    columns = dr("col").ToString
        '    lbldepart.Text = Format(Convert.ToDateTime(dr("dtime")), "hh:mm")
        '    lblarrive.Text = Format(Convert.ToDateTime(dr("atime")), "hh:mm")

        'Else
        '    columns = 0
        'End If

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

            'If Not dr("allowanceinRM") Is System.DBNull.Value Then
            '    allowanceRM.Text = dr("allowanceinRM").ToString
            'End If

            lblallowance.Text = txttravel & " " & ddlallowance
            mybtno = dr("btrno").ToString

        Else
            columns = 0
        End If

        Dim rows = 21
        columns = columns + 1

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
        labellist.Add("Total Expenses(in RM)")
        labellist.Add("Advance Amount(in RM)")
        labellist.Add("Cash Advance Details")
        labellist.Add("cash Taken in advance ")
        labellist.Add("cash Refund (Amount)")
        labellist.Add("Total Refund (in RM)")

        '''''''''' SEPERATE CURRENCY AND AMOUNT

        '  PlaceHolder1.Controls.Clear()
        Dim tblRows As Integer = rows
        Dim tblCols As Integer = Columns
        Dim tbl As Table = New Table()

        ' tbl.BorderStyle = BorderStyle.Solid

        tbl.BorderWidth = 1
        tbl.BorderStyle = BorderStyle.Solid
        tbl.BorderColor = Drawing.Color.Black
        tbl.CellPadding = 3
        tbl.CellSpacing = 0
        tbl.Font.Size = 12

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

        For i As Integer = 0 To tblRows - 1
            Dim tr As TableRow = New TableRow()
            For j As Integer = 0 To tblCols - 1
                If j = 0 Then
                    Dim tc As TableCell = New TableCell()
                    Dim label As New Label
                    label.Text = labellist.Item(i)
                    If i = 11 Or i = 17 Then
                        tc.ColumnSpan = tblCols
                        tc.HorizontalAlign = HorizontalAlign.Center
                        tc.ControlStyle.Font.Bold = True
                    End If
                    tc.Controls.Add(label)
                    tc.BackColor = Drawing.Color.Beige
                    tr.Cells.Add(tc)
                    If i = 14 Then
                        tc.Controls.Add(label)
                        tc.BackColor = Drawing.Color.Teal
                        tc.ForeColor = Drawing.Color.White
                        tr.Cells.Add(tc)
                    End If
                    If i = 15 Or i = 16 Or i = 20 Then
                        tc.ColumnSpan = tblCols - 1
                        tc.HorizontalAlign = HorizontalAlign.Right
                        tc.ControlStyle.Font.Bold = True
                    End If

                    If (j = 0 And i = 12) Then
                        Dim lbl As Label = New Label
                        If Not dr("description1") Is System.DBNull.Value Then
                            lbl.Text = dr("description1")
                        End If
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    End If
                    If (j = 0 And i = 13) Then
                        Dim lbl As Label = New Label
                        If Not dr("description2") Is System.DBNull.Value Then
                            lbl.Text = dr("description2")
                        End If
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    End If
                Else
                    Dim tc As TableCell = New TableCell()
                    tc.BorderWidth = 1
                    tc.BorderStyle = BorderStyle.Solid
                    tc.BorderColor = Drawing.Color.White
                    Dim lbl As Label = New Label()
                    If i = 0 Then
                        cval = "cur" & j
                        lbl.Text = dr(cval).ToString
                        tc.BackColor = Drawing.Color.Beige
                        tc.Controls.Add(lbl)
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
                        tc.BackColor = Drawing.Color.Teal
                        tc.ForeColor = Drawing.Color.White
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 18 Then
                        ctval = "ctaken" & j
                        lbl.Text = dr(ctval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 19 Then
                        crval = "crfund" & j
                        lbl.Text = dr(crval).ToString
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 16 And j = 1 Then
                        lbl.Text = dr("advanceamount")
                        tc.BackColor = Drawing.Color.Yellow
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 15 And j = 1 Then
                        If Not dr("totalexpenses") Is System.DBNull.Value Then
                            lbl.Text = dr("totalExpenses")
                            tc.BackColor = Drawing.Color.Yellow
                        Else
                            tc.BackColor = Drawing.Color.Yellow
                        End If
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    ElseIf i = 20 And j = 1 Then
                        If Not dr("totalrefund") Is System.DBNull.Value Then
                            lbl.Text = dr("totalrefund")
                            tc.BackColor = Drawing.Color.Yellow
                        Else
                            tc.BackColor = Drawing.Color.Yellow
                        End If
                        tc.Controls.Add(lbl)
                        tr.Cells.Add(tc)
                    End If
                End If
            Next j
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
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.print('tcview.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")
    End Sub
End Class