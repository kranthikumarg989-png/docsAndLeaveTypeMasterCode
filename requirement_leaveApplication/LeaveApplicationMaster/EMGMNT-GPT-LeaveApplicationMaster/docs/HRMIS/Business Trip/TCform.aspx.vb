Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO.Path
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TCform
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim DynCol As Integer
    Dim empcode
    Private Sub TCform_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        lblno.Text = 0
        empcode = Session("empcode")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (52)
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

        If Request.QueryString("lblmsg") = "saved" Then
            lblmsg.Text = "REcord Saved!!Your Travelling claim is forwaded to your HOD."
        End If

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        If Request.QueryString("rno") <> "" Then
            Label3.Text = Request.QueryString("rno")
            Panel1.Visible = True
            GenTable(Label3.Text.Trim)
        Else
            Panel1.Visible = False
        End If
    End Sub
    Private Sub GenTable(ByVal rno As String)
        GetBtInfo(rno)
        Dim fromd
        Dim myarray
        Dim advance
        Dim cash
        Dim Currency

        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                '  fromd = Format(Convert.ToDateTime(dr("fromdate")), "dd/MM/yy")
                fromd = dr("fromdate")
                If Not dr("sanctioned") Is System.DBNull.Value Then
                    advance = dr("sanctioned").ToString.Trim

                End If

                Dim TotalAdv
                If Not dr("totaladvance") Is System.DBNull.Value Then
                    TotalAdv = dr("totaladvance").ToString
                    lbltotadvacne.Text = TotalAdv
                End If

                lblfdate.Text = Format(Convert.ToDateTime(dr("fromdate")), "dd/MM/yy")

                ''''''''''' SEPERATE CURRENCY AND AMOUNT
                'lbladvance.Text = advance
                'Dim separator As Char() = New Char() {","c}
                'Dim strSplitArr As String() = advance.Split(separator)
                'If Len(advance) <> 0 Then
                '    For Each arrStr As String In strSplitArr
                '        If Not arrStr = "" Then
                '            myarray = Split(arrStr, " ")
                '            cash = myarray(1)
                '            Currency = myarray(2) & " " & myarray(3) & " " & myarray(4) & ")"
                '        End If
                '    Next
                'End If
                '''''''''' SEPERATE CURRENCY AND AMOUNT

                lbladvance.Text = advance
                Dim separator As Char() = New Char() {","c}
                Dim strSplitArr As String()
                If Len(advance) <> 1 Then
                    strSplitArr = advance.Split(separator)
                    For Each arrStr As String In strSplitArr
                        If Not arrStr = "" Then
                            myarray = Split(arrStr, " ")
                            cash = myarray(1)
                            Currency = myarray(2) & " " & myarray(3) & " " & myarray(4) & ")"
                        End If
                    Next
                    Dim rows = 18
                    Dim columns = strSplitArr.Length + lblno.Text.Trim
                    CreateDynamicTable(rows, columns)
                Else
                    Dim rows = 18
                    Dim columns = lblno.Text.Trim + 2
                    CreateDynamicTable(rows, columns)
                End If
            End If
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
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
    Private Sub CreateDynamicTable(ByVal Rows As Integer, ByVal columns As Integer)
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
        labellist.Add("If you cannot find any information above,Please use the below")
        labellist.Add("")
        labellist.Add("")
        labellist.Add("TOTAL")
        labellist.Add("Cash Advance Details")
        labellist.Add("cash Taken in advance ")
        labellist.Add("cash Refund (Amount)")

        '''''''''' SEPERATE CURRENCY AND AMOUNT
        Dim myarray
        Dim mycur As New ArrayList
        Dim mycash As New ArrayList
        Dim advance
        Dim cash
        Dim Currency
        Dim lenArray = 0
        Dim k As Integer = 0
        Dim l As Integer = 0
        Dim separator As Char() = New Char() {","c}
        If lbladvance.Text <> "0" Then
            Dim strSplitArr As String() = lbladvance.Text.Trim.Split(separator)

            For Each arrStr As String In strSplitArr
                If Not arrStr = "" Then
                    myarray = Split(arrStr, " ")
                    cash = myarray(1)
                    mycash.Add(cash)
                    Currency = myarray(2) & " " & myarray(3) & " " & myarray(4) & ")"
                    mycur.Add(Currency)
                    lenArray = lenArray + 1
                End If
            Next
        End If

        PlaceHolder1.Controls.Clear()
        ' Fetch the number of Rows and Columns for the table 
        ' using the properties
        Dim tblRows As Integer = Rows
        Dim tblCols As Integer = columns
        ' Create a Table and set its properties 
        Dim tbl As Table = New Table()
        ' Add the table to the placeholder control
        PlaceHolder1.Controls.Add(tbl)
        ' Now iterate through the table and add your controls 
        For i As Integer = 0 To tblRows - 1
            Dim tr As TableRow = New TableRow()
            For j As Integer = 0 To tblCols - 1
                If j = 0 Then
                    ' To Create 1st and 15th Row which is just Label
                    ' Description
                    ' If you cannot find any information above,Please use the below
                    Dim tc As TableCell = New TableCell()
                    Dim label As New Label
                    label.Text = labellist.Item(i)
                    If i = 11 Or i = 15 Then
                        tc.ColumnSpan = tblCols
                        tc.HorizontalAlign = HorizontalAlign.Center
                        tc.ControlStyle.Font.Bold = True
                    End If
                    tc.Controls.Add(label)
                    tc.BackColor = Drawing.Color.Beige
                    tr.Cells.Add(tc)

                    If (j = 0 And i = 0) Then
                        tc.HorizontalAlign = HorizontalAlign.Center
                        tc.VerticalAlign = VerticalAlign.Middle
                        tc.ControlStyle.ForeColor = Drawing.Color.White
                        tc.ControlStyle.BackColor = Drawing.Color.SteelBlue
                        tc.Font.Bold = True
                    End If
                    ' To add Text Box for 12th and 13th row in first column
                    If (j = 0 And i = 12) Or (j = 0 And i = 13) Then
                        Dim txtBox As TextBox = New TextBox()
                        txtBox.ID = "R" & i & "C" & j
                        tc.Controls.Add(txtBox)
                        tr.Cells.Add(tc)
                    End If
                Else

                    Dim tc As TableCell = New TableCell()
                    Dim txtBox As TextBox = New TextBox()
                    txtBox.ID = "R" & i & "C" & j
                    '   txtBox.Text = "R" & i & "C" & j
                    txtBox.Width = 50
                    txtBox.AutoPostBack = True
                    ' txtBox.Focus()
                    txtBox.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")

                    ' add sanctioned currency from DB as label if it is first row else add textbox
                    If i = 0 Then
                        If j > 0 Then
                            ' add approved currency as table heading
                            ' For k As Integer = 0 To lenArray - 1
                            If k <> lenArray Then
                                Dim label As New Label
                                label.Text = mycur(j - 1)
                                tc.Controls.Add(label)
                                tr.Cells.Add(tc)
                                tc.HorizontalAlign = HorizontalAlign.Center
                                tc.VerticalAlign = VerticalAlign.Middle
                                tc.ControlStyle.ForeColor = Drawing.Color.White
                                tc.ControlStyle.BackColor = Drawing.Color.SteelBlue
                                k = k + 1
                            Else
                                Dim ddl As New DropDownList
                                ''''''''''''''''''''''''''''''''''''''''' Get employee details ''''''''''''''''''''' #2
                                MyGlobal.Open_Con()
                                MyGlobal.Con_Str()
                                DS = Open_Currency(Con, DAP, 2, "SELECT distinct currencycode FROM pur_currencymaster order by currencycode")
                                If DS.Tables("currency").Rows.Count <> 0 Then
                                    ddl.DataSource = DS
                                    ddl.DataValueField = "Currencycode"
                                    ddl.DataTextField = "currencycode"
                                    ddl.ID = "R" & i & "C" & j
                                    ddl.DataBind()
                                End If
                                MyGlobal.db_close()
                                tc.Controls.Add(ddl)
                                tr.Cells.Add(tc)
                            End If
                            ' Next
                        End If
                    ElseIf i = 11 Or i = 15 Then

                    ElseIf i = 16 Then
                        If j > 0 Then
                            ' add approved currency as table heading
                            ' For k As Integer = 0 To lenArray - 1
                            If l <> lenArray Then
                                Dim label As New Label
                                label.Text = mycash(j - 1)
                                tc.Controls.Add(label)
                                tr.Cells.Add(tc)
                                tc.HorizontalAlign = HorizontalAlign.Center
                                tc.VerticalAlign = VerticalAlign.Middle
                                tc.ControlStyle.ForeColor = Drawing.Color.Yellow
                                tc.ControlStyle.BackColor = Drawing.Color.Tomato
                                l = l + 1
                            Else
                                tr.Cells.Add(tc)
                            End If
                            ' Next
                        End If
                    ElseIf i = 17 And j > 3 Then

                    Else
                        ' Add the control to the TableCell
                        tc.Controls.Add(txtBox)
                        ' Add the TableCell to the TableRow
                        tr.Cells.Add(tc)
                        '   txtBox.TextChanged += New EventHandler(Me.TextBox_TextChanged)
                        AddHandler txtBox.TextChanged, AddressOf TextBox_TextChanged

                    End If
                End If
            Next j
            ' Add the TableRow to the Table
            tbl.Rows.Add(tr)

        Next i
        ' This parameter helps determine in the LoadViewState event,
        ' whether to recreate the dynamic controls or not
        ViewState("dynamictable") = True
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        lblno.Text = lblno.Text.Trim + 1
        ' lblno.Text = DynCol
        GenTable(Label3.Text.Trim)
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim separator As Char() = New Char() {","c}
        Dim strSplitArr As String()
        Dim c

        If lbladvance.Text = "0" Then
            c = lblno.Text.Trim + 2
        Else
            strSplitArr = lbladvance.Text.Split(separator)
            c = strSplitArr.Length + lblno.Text.Trim
        End If

        Dim total As Double
        Dim t As TextBox
        Dim txtVal As Double
        Dim finaltot As TextBox

        For i As Integer = 1 To c - 1
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
    End Sub
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        GetTCrno()
        Dim rno = posid
        ''''''''''''''''''''''''''''''''''''''''' GET NO.OF COLUMN FROM DATABASE''''''''''''''''''''' #1
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        DS = Open_TC(Con, DAP, 2, "select max(colnos) as col from hrmis_tc_travellingclaimnew ")
        Dim dr As DataRow
        Dim ExistingCol

        If DS.Tables("TC").Rows.Count <> 0 Then
            dr = DS.Tables(0).Rows(0)
            ExistingCol = dr("col").ToString
        Else
            ExistingCol = 0
        End If

        Dim myarray
        Dim mycur As New ArrayList
        Dim mycash As New ArrayList
        Dim cash
        Dim Currency
        Dim lenArray = 0

        'Dim separator As Char() = New Char() {","c}
        'Dim strSplitArr As String() = lbladvance.Text.Split(separator)
        'Dim CurCol = (strSplitArr.Length + lblno.Text.Trim) - 1
        'If CurCol = "0" Then
        '    CurCol = "1"
        'End If
        'For Each arrStr As String In strSplitArr
        '    If Not arrStr = "" Then
        '        myarray = Split(arrStr, " ")
        '        cash = myarray(1)
        '        mycash.Add(cash)
        '        Currency = myarray(2) & " " & myarray(3) & " " & myarray(4) & ")"
        '        mycur.Add(Currency)
        '        lenArray = lenArray + 1
        '    End If
        'Next
        Dim separator As Char() = New Char() {","c}
        Dim strSplitArr As String()
        Dim CurCol
        If lbladvance.Text = "0" Then
            CurCol = lblno.Text.Trim - 1
            Currency = ""
            cash = ""
            mycash.Add(cash)
            mycur.Add(Currency)
        Else
            strSplitArr = lbladvance.Text.Split(separator)
            CurCol = (strSplitArr.Length + lblno.Text.Trim) - 1
            For Each arrStr As String In strSplitArr
                If Not arrStr = "" Then
                    myarray = Split(arrStr, " ")
                    cash = myarray(1)
                    mycash.Add(cash)
                    Currency = myarray(2) & " " & myarray(3) & " " & myarray(4) & ")"
                    mycur.Add(Currency)
                    lenArray = lenArray + 1
                End If
            Next
        End If
        If CurCol <= "0" Then
            CurCol = "1"
        End If
        '***************************** CREATE COLUMNS DYNAMICALLY in SQL ******************************
        Dim Newcol, Colnum
        If ExistingCol < CurCol Then
            Newcol = CurCol - ExistingCol
            For i As Integer = 1 To Newcol
                Colnum = ExistingCol + i
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Call MyGlobal.dbSp_open("HRMIS_TC_COLGEN")
                    Cmd.Parameters.AddWithValue("@val", Colnum)
                    Cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox("Cannot create Columns in TC table " & ex.Message)
                End Try
            Next
        End If

        '***************************** INSERT RECORDS TO DB ******************************
        Dim STARTLOOP = 1
        Dim k As Integer = 0
        Dim deptt As String
        Dim arrt As String

        'Dim fd1 As String
        'fd1 = lblfdate.Text.Trim
        'Dim strdate() As String = fd1.Split("/"c)
        'fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        'Dim fd As Date
        'fd = CDate(fd1)

        arrt = ddlihr.SelectedValue + ":" + ddlimin.SelectedValue + " " + Convert.ToString(ddliam.SelectedValue)
        deptt = ddlohr.SelectedValue + ":" + ddlomin.SelectedValue + " " + Convert.ToString(ddloam.SelectedValue)

        Dim des1 As TextBox = DirectCast(PlaceHolder1.FindControl("R12C0"), TextBox)
        Dim des2 As TextBox = DirectCast(PlaceHolder1.FindControl("R13C0"), TextBox)
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

        Dim cval11 As String

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
        Dim cval1 As DropDownList

        Dim curallowance As String
        curallowance = DDLALLOWANCE.SelectedValue
        If txttravel.Text.Length = 0 Or curallowance = "-1" Then
            lblmsg.Text = "Please Key in Travelling allowance Details "
            Exit Sub
        End If
        While STARTLOOP <= CurCol

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


            'If k < lenArray Then
            '    cval = mycur(STARTLOOP - 1)
            '    ctval = mycash(STARTLOOP - 1)
            '    crval1 = DirectCast(PlaceHolder1.FindControl("R17C" & STARTLOOP), TextBox)
            '    crval = crval1.Text.Trim
            'Else
            '    cval = "R0C" & STARTLOOP
            '    cval1 = DirectCast(PlaceHolder1.FindControl(cval), DropDownList)
            '    cval11 = cval1.SelectedValue
            '    cval = cval11
            '    crval = ""
            'End If

            If k < lenArray Then
                cval = mycur(STARTLOOP - 1)
                ctval = mycash(STARTLOOP - 1)
                crval1 = DirectCast(PlaceHolder1.FindControl("R17C" & STARTLOOP), TextBox)
                crval = crval1.Text.Trim
            Else
                cval = "R0C" & STARTLOOP
                cval1 = DirectCast(PlaceHolder1.FindControl(cval), DropDownList)
                cval11 = cval1.SelectedValue
                If cval1.SelectedValue.TrimEnd = "" Or cval1.SelectedValue = "-1" Then
                    lblmsg.Text = "Please select the currency"
                    cval1.Focus()
                    Exit Sub
                End If
                cval = cval11
                crval = ""
            End If

            k = k + 1

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

            Dim Sqlstat As String

            If STARTLOOP = 1 Then
                Try
                    Sqlstat = "Insert into HRMIS_TC_Travellingclaimnew(advanceamount,colnos,EMPCODE,RNO,btrno,remarks,description1,description2,dtime,atime,tallowance,ALLOWANCECURRENCY," & cur & "," & Acc & "," & tax & "," & ent & "," & pfee & "," & pet & "," & fax & "," & toll & "," & trans & "," & mis & "," & oth & "," & desc1 & "," & desc2 & "," & tot & "," & ct & "," & cr & ") values ('" & lbltotadvacne.Text & "','" & CurCol & "','" & empcode & "','" & rno & "','" & Label3.Text.Trim & "','" & txtremarks.Text.Trim & "','" & des1.Text.Trim & "','" & des2.Text.Trim & "','" & deptt & "','" & arrt & "','" & txttravel.Text & "','" & curallowance & "','" & cval & "','" & aval & "','" & tval & "','" & enval & "','" & pfval & "','" & pval & "','" & fval & "','" & tolval & "','" & trnval & "','" & mval & "','" & oval & "','" & d1val & "','" & d2val & "','" & totval & "','" & ctval & "','" & crval & "' )"
                    DS = Open_TC(Con, DAP, 2, Sqlstat)
                Catch ex As Exception
                    MessageBox("Cannot Insert Record. " & ex.Message)
                    Exit Sub
                End Try
            Else
                Try
                    Sqlstat = "update HRMIS_TC_Travellingclaimnew set " & cur & " = '" & cval & "'," & Acc & " = '" & aval & "'," & tax & " = '" & tval & "'," & ent & " = '" & enval & "'," & pfee & " = '" & pfval & "'," & pet & " = '" & pval & "'," & fax & " = '" & fval & "'," & toll & " = '" & tolval & "'," & trans & " = '" & trnval & "' ," & mis & " = '" & mval & "'," & oth & " = '" & oval & "'," & desc1 & " = '" & d1val & "' ," & desc2 & " = '" & d2val & "'," & tot & " = '" & totval & "' ," & ct & " = '" & ctval & "'," & cr & " = '" & crval & "' where rno = '" & rno & "'"
                    DS = Open_TC(Con, DAP, 2, Sqlstat)
                Catch ex As Exception
                    MessageBox("Cannot Complete Insertion in TC ." & ex.Message)
                    Exit Sub
                End Try
            End If
            STARTLOOP = STARTLOOP + 1
        End While
        DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set tcform= 'Y' where recno = '" & Label3.Text & "'")

        GridView1.DataBind()
        Response.Redirect("tcVIEW.aspx?RNO=" & rno & "")
        ' Response.Redirect("tcform.aspx?lblmsg=saved")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class