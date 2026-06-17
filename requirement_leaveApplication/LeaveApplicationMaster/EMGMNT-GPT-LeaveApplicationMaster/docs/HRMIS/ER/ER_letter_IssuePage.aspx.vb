Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ER_letter_IssuePage
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Protected WithEvents textbox As System.Web.UI.WebControls.TextBox
    Protected WithEvents label As System.Web.UI.WebControls.Label
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            empcode.Focus()
        End If
        HtmlEditor1.DesignModeEditable = False
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        If DropDownList1.SelectedValue <> "-1" Then
            Dim ds1 As DataSet
            Dim dr1 As DataRow
            Dim Lfields1, Lfieldtype
            Dim labellist As New ArrayList
            Dim strtext, prefix
            Dim o, k
            'messagebox(DropDownList1.SelectedItem.Text)
            strtext = "select field_name ,ltrim(rtrim(field_type)) as field_type,Ltrim(rtrim(prefix)) as prefix  from HRMIS_ER_LETTER_WIZARD where lettername='" & DropDownList1.SelectedItem.Text & "' and status =1"
            ds1 = GetLetterFields(strtext)
            If ds1.Tables(0).Rows.Count <> 0 Then
                o = ds1.Tables(0).Rows.Count
                For k = 0 To o - 1
                    dr1 = ds1.Tables(0).Rows(k)
                    Lfields1 = dr1("field_name").ToString
                    Lfieldtype = dr1("field_type").ToString
                    prefix = dr1("prefix").ToString
                    labellist.Add(Lfields1)
                Next
            End If
            CreateDynamicTable(o, 2)
        End If

    End Sub
    Function GetLetterFields(ByVal strtext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(strtext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "letter")
        con.Close()
        Return ds
    End Function
    Private Sub CreateDynamicTable(ByVal Rows As Integer, ByVal columns As Integer)
        Dim ds1 As DataSet
        Dim dr1 As DataRow
        Dim Lfields1, Lfieldtype
        Dim labellist As New ArrayList
        Dim strtext, prefix
        Dim o, k
        strtext = "select field_name ,ltrim(rtrim(field_type)) as field_type,Ltrim(rtrim(prefix)) as prefix  from HRMIS_ER_LETTER_WIZARD where lettername='" & DropDownList1.SelectedItem.Text & "' and status =1"
        ds1 = GetLetterFields(strtext)
        If ds1.Tables(0).Rows.Count <> 0 Then
            o = ds1.Tables(0).Rows.Count
            For k = 0 To o - 1
                dr1 = ds1.Tables(0).Rows(k)
                Lfields1 = dr1("field_name").ToString
                Lfieldtype = dr1("field_type").ToString
                prefix = dr1("prefix").ToString
                labellist.Add(Lfields1)
            Next
        End If
        PlaceHolder1.Controls.Clear()
        ' Fetch the number of Rows and Columns for the table 
        ' using the properties
        Dim tblRows As Integer = o
        Dim tblCols As Integer = 2
        ' Create a Table and set its properties 
        Dim tbl As Table = New Table()
        ' Add the table to the placeholder control
        PlaceHolder1.Controls.Add(tbl)
        For q As Integer = 0 To tblRows - 1
            Dim tr As TableRow = New TableRow()
            For j As Integer = 0 To tblCols - 1
                Dim tc As TableCell = New TableCell()
                '''' if first column, then label
                If j = 0 Then
                    Dim label As New Label
                    Dim val = labellist.Item(q)
                    val = val.Remove(0, prefix.Length)
                    ' label.Text = labellist.Item(q)
                    label.Text = val
                    tc.Controls.Add(label)
                    tc.BackColor = Drawing.Color.Beige
                    tr.Cells.Add(tc)
                    ' ''' if second column then textbox
                ElseIf j = 1 Then
                    Dim txtBox As TextBox = New TextBox()
                    'If Lfieldtype = "Text Area" Then
                    '    txtBox.TextMode = TextBoxMode.MultiLine
                    '   MessageBox(Lfieldtype)
                    'End If
                    Dim val = labellist.Item(q)
                    val = val.Remove(0, prefix.Length)
                    txtBox.ID = val
                    tc.Controls.Add(txtBox)
                    tr.Cells.Add(tc)
                End If
            Next j
            tbl.Rows.Add(tr)
        Next q
        ViewState("dynamictable") = True
    End Sub
    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim s As New Label
        'Label3.Text = "s"
        If HtmlEditor1.Text.Trim <> "" Then
            Session("_ecode") = "005000"  'for implement purpose hotcode removed
            SqlDataSource3.InsertParameters.Add("lettercontents", Me.HtmlEditor1.Text)
            SqlDataSource3.InsertParameters.Add("empcode", Me.empcode.Text)
            SqlDataSource3.InsertParameters.Add("lettername", Me.DropDownList1.SelectedItem.Text)
            SqlDataSource3.InsertParameters.Add("issuedate", DateTime.Now.ToString())
            SqlDataSource3.InsertParameters.Add("createdby", Session("_ecode").ToString)
            SqlDataSource3.InsertParameters.Add("status", "S")
            SqlDataSource3.InsertParameters.Add("lettertype", "ER")
            'messagebox(Label3.Text)
            'SqlDataSource3.InsertParameters.Add("issuedate", DateTime.Now.ToString("dd/MM/yyyy"))
            SqlDataSource3.Insert()
            MyGlobal.Con_Str()
            Call ddlsel()
            'messagebox("Letter Saved to DB")
            Dim htmledi As String
            htmledi = HtmlEditor1.Text
            Session("ht") = htmledi.ToString
            Session("ddlname") = DropDownList1.Text
            Server.Transfer("printmanual.aspx")
            Session("ht") = ""
        Else
            MessageBox("click Previewbutton or SpaceBar")
            Button1.Focus()
            Button3.Enabled = False
            Exit Sub
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'MessageBox("hi")
        Dim strcontent As String
        Dim oldvalue, newvalue
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        con.Open()
        cmd = New SqlCommand("select lettercontents from HRMIS_ER_MASTER_LETTER where lettername='" & (DropDownList1.SelectedItem.Text) & "' ", con)
        'cmd.Parameters.AddWithValue("@lettercontents", HtmlEditor1.Text)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            strcontent = dr("lettercontents").ToString()
            HtmlEditor1.Text = strcontent
        End While
        con.Close()
        cmd.Dispose()
        ''''' fetch field name
        Dim dsabs As DataSet
        Dim drabs As DataRow
        Dim Lfields
        Dim l, m
        Dim strtext
        Dim prefix As String
        Dim myval As String
        Dim txt
        Dim status
        strtext = "select field_name,Ltrim(rtrim(prefix)) as prefix,status from HRMIS_ER_LETTER_WIZARD where lettername='" & DropDownList1.SelectedItem.Text & "'"
        dsabs = GetLetterFields(strtext)
        If dsabs.Tables(0).Rows.Count <> 0 Then
            l = dsabs.Tables(0).Rows.Count
            For m = 0 To l - 1
                drabs = dsabs.Tables(0).Rows(m)
                Lfields = drabs("field_name").ToString
                prefix = drabs("prefix").ToString
                status = drabs("status").ToString
                oldvalue = Lfields
                myval = oldvalue
                newvalue = myval.Remove(0, prefix.Length)
                Dim strtexts As String = HtmlEditor1.Text
                If status = 1 Then
                    Dim txtt As TextBox
                    txtt = DirectCast(Me.PlaceHolder1.FindControl(newvalue), TextBox)
                    txt = strtexts.Replace(Lfields, txtt.Text)
                    strtexts = txt
                ElseIf status = 0 And newvalue <> "empcode" Then
                    Dim txtt As Label
                    txtt = DirectCast(Me.FindControl(newvalue), Label)
                    txt = strtexts.Replace(Lfields, txtt.Text)
                    strtexts = txt
                ElseIf status = 0 And newvalue = "empcode" Then
                    Dim txtt As TextBox
                    txtt = DirectCast(Me.FindControl(newvalue), TextBox)
                    txt = strtexts.Replace(Lfields, txtt.Text)
                    strtexts = txt
                End If
                HtmlEditor1.Text = strtexts
            Next
        End If
        Call sign()
        Button3.Enabled = True
        Button3.Focus()
    End Sub
    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        HtmlEditor1.Text = ""
        If (HtmlEditor1.Text = "") Then
            DropDownList1.SelectedValue = -1
            empcode.Text = ""
            empname.Text = ""
            emptype.Text = ""
            sectioncode.Text = ""
            departmentcode.Text = ""
            designation.Text = ""
            PlaceHolder1.Visible = False
        End If
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        companyname.Text = "Maruwa (Malaysia) Sdn.Bhd."
        empname.Text = ""
        sectioncode.Text = ""
        departmentcode.Text = ""
        designation.Text = ""
        emptype.Text = ""
        Dim empcode1
        HtmlEditor1.Text = ""
        PlaceHolder1.Visible = False
        empcode1 = empcode.Text
        GetEmpVehino(empcode1)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                empname.Text = dr("empname").ToString
                sectioncode.Text = dr("sectioncode").ToString
                departmentcode.Text = dr("departmentcode").ToString
                designation.Text = dr("designation").ToString
                emptype.Text = dr("emptype").ToString
            Else
            End If
        End If
        DropDownList1.SelectedValue = -1
        DropDownList1.Focus()
        Call checking()
        getDetails()
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        HtmlEditor1.Text = ""
        Dim ds1 As DataSet
        Dim dr1 As DataRow
        Dim Lfields1, Lfieldtype
        Dim labellist As New ArrayList
        Dim strtext, prefix
        Dim o, k
        Call position()
        PlaceHolder1.Visible = True
        strtext = "select field_name ,ltrim(rtrim(field_type)) as field_type,Ltrim(rtrim(prefix)) as prefix  from HRMIS_ER_LETTER_WIZARD where lettername='" & DropDownList1.SelectedItem.Text & "' and status =1"
        ds1 = GetLetterFields(strtext)
        If ds1.Tables(0).Rows.Count <> 0 Then
            o = ds1.Tables(0).Rows.Count
            For k = 0 To o - 1
                dr1 = ds1.Tables(0).Rows(k)
                Lfields1 = dr1("field_name").ToString
                Lfieldtype = dr1("field_type").ToString
                prefix = dr1("prefix").ToString
                labellist.Add(Lfields1)
            Next
        End If
        CreateDynamicTable(o, 2)
        Label2.Visible = True
        'PlaceHolder1.Controls.Add(Panel2)
        'Call fill()

    End Sub
    Sub position()
        If DropDownList1.SelectedItem.Selected = True Then
            HtmlEditor1.Style("left") = "6px"
            HtmlEditor1.Style("position") = "auto"
            HtmlEditor1.Style("z-index") = "100"
            HtmlEditor1.Style("top") = "367px"
        End If
    End Sub
    Sub checking()
        Dim str, dt As String
        dt = (Date.Now.Year)
        Dim con As New SqlConnection(constr)
        con.Open()
        ListBox1.Items.Clear()
        str = "select lettername,CONVERT(VARCHAR(10),issuedate,106)as issuedate from HRMIS_ER_MASTER_LETTER_SAVE where empcode='" & (empcode.Text) & "' and YEAR(issuedate)='" & dt & "'"
        cmd = New SqlCommand(str, con)
        dr = cmd.ExecuteReader
        While dr.Read
            ListBox1.Items.Add(dr(0) & "------" & dr(1))
        End While
        dr.Close()
        total.Text = ListBox1.Items.Count
    End Sub
    Sub fill()
        'Dim fndvis1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
        'Dim fndvis2 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
        'If fndvis1 = "" Then
        '    fndvis1 = Date.Now.ToShortDateString
        'ElseIf fndvis2 = "" Then
        '    fndvis2 = Date.Now.ToShortDateString
        'End If
        ''If PlaceHolder1.Visible = True Then
        ''    If DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Visible = True Or DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Visible = True Then
        ''        finddate = Date.Now.ToShortDateString
        ''    End If
        ''End If
    End Sub
    Sub sign()
        Dim cmd As New SqlCommand
        Dim str, find1, sig, desdep As String
        Dim con As New SqlConnection(constr)
        con.Open()
        If DropDownList1.Text = "Firstwarningabove30min" Or DropDownList1.Text = "Verbalwarningabove30min" Or DropDownList1.Text = "Employeecounseling" Or DropDownList1.Text = "Finalwarningabove30" Or DropDownList1.Text = "Finalwarninghostel" Or DropDownList1.Text = "Finalwarningbelow30" Or DropDownList1.Text = "Finalwarningmorethan1hour" Or DropDownList1.Text = "Firstwarningabove30min" Or DropDownList1.Text = "Firstwarningbelow30min" Or DropDownList1.Text = "Firstwarningmorethan1hour1" Or DropDownList1.Text = "Latemorethan24hrs" Or DropDownList1.Text = "Misconductreport" Or DropDownList1.Text = "Preliminarycounseling" Or DropDownList1.Text = "Verbalwarningabove30min" Or DropDownList1.Text = "Verbalwarningbelow30min" Or DropDownList1.Text = "Verbalwarningmorethan1hour" Or DropDownList1.Text = "Final warning(Over Night)" Then
        Else
            find1 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            If find1 <> "" Then
                str = "select empname,designation,departmentcode from empmaster where empcode='" & find1 & "'"
                cmd = New SqlCommand(str, con)
                dr = cmd.ExecuteReader
                While dr.Read
                    sig = dr(0).ToString
                    desdep = "(" & dr(1) & " - " & dr(2) & ")"
                End While
                dr.Close()
            End If
            Dim n As String = "005000"
            If HtmlEditor1.Text.Contains(find1) = True And HtmlEditor1.Text.Contains(n) = False Then
                HtmlEditor1.Text = HtmlEditor1.Text.Replace(find1, sig)
            ElseIf HtmlEditor1.Text.Contains(n) = True Then
                HtmlEditor1.Text = HtmlEditor1.Text.Replace(n, "Datuk ManiMaran Anthony")
            End If
            HtmlEditor1.Text = HtmlEditor1.Text + Environment.NewLine + desdep
        End If
    End Sub
    Sub ddlsel()
        Dim find1, find2, find3, find4, find5, find6, find7, find8, find9, find10
        Dim dt = Date.Now.ToString
        Dim cmd As New SqlCommand
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        MyGlobal.Open_Con()
        con.Open()
        If DropDownList1.Text = "Directfinalwarning" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("desmisconduct"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("vwdate"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("fwdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@itimedate", find4)
            cmd.Parameters.AddWithValue("@vwdate", find5)
            cmd.Parameters.AddWithValue("@fwdate", find6)
            cmd.Parameters.AddWithValue("@desc", find1)
            cmd.Parameters.AddWithValue("@secode", find2)
            cmd.Parameters.AddWithValue("@ldate", find3)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_misfinalwarning")
            'insert into er_misfinalwarning values(@ecode,@itimedate,@vwdate,@fwdate,@desc,,@secode,@ldate,@cby,GETDATE(),'','',@cont)

        ElseIf DropDownList1.Text = "Dismissalletter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_DISMISSAL]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("er_letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("er_icdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("er_ictime"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("er_icplace"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("er_incidentdate"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("er_listofproperties"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@letr_date", find1)
            cmd.Parameters.AddWithValue("@icdate", find2)
            cmd.Parameters.AddWithValue("@ictime", find3)
            cmd.Parameters.AddWithValue("@icplace", find4)
            cmd.Parameters.AddWithValue("@incidentdate", find5)
            cmd.Parameters.AddWithValue("@property", find6)
            cmd.Parameters.AddWithValue("@scode", find7)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edi", "")
            cmd.Parameters.AddWithValue("@rev", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_dismissal")
            'insert into er_dismissal values(@ecode,@letr_date,@icdate,@ictime,@icplace,@incidentdate,@property,@scode,@cby,getdate(),@edi,@rev,@cont)

        ElseIf DropDownList1.Text = "Employeecounseling" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_EMPCOUNSIL]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("cudate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("ctime"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("present"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("discussion"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("recomments"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("orcomments"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("atfollowup"), TextBox).Text
            find8 = DirectCast(Me.PlaceHolder1.FindControl("ersection"), TextBox).Text
            find9 = DirectCast(Me.PlaceHolder1.FindControl("cname"), TextBox).Text
            'find9 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@tandp", find2)
            cmd.Parameters.AddWithValue("@pax", find3)
            cmd.Parameters.AddWithValue("@subj", find4)
            cmd.Parameters.AddWithValue("@comment", find5)
            cmd.Parameters.AddWithValue("@report", find6)
            cmd.Parameters.AddWithValue("@followup", find7)
            cmd.Parameters.AddWithValue("@ccode", "")
            cmd.Parameters.AddWithValue("@action", find8)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edi", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_employeecounseling")
            'insert into er_employeecounseling values(@ecode,@ldate,@tandp,@pax,@subj,@comment,@report,@followup,@ccode,@action,@cby,GETDATE(),@edi,@revi,@cont)

        ElseIf DropDownList1.Text = "Explanationletter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_EXPLATION_INSERT]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("subjectrefer"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("fdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@sub", find1)
            cmd.Parameters.AddWithValue("@dt", find2)
            cmd.Parameters.AddWithValue("@letterdt", find3)
            cmd.Parameters.AddWithValue("@ecode", find4)
            cmd.Parameters.AddWithValue("@crtby", "IT")
            cmd.Parameters.AddWithValue("@edi", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@lettercont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_explanation")
            'insert into er_explanation values(@code,@sub,@dt,@letterdt,@ecode,@crtby,getdate(),@edi,@revi,@lettercont)

        ElseIf DropDownList1.Text = "Finalwarningabove30" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNINGABOVE30]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("firstwarningdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("lettergivenby"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@latecomingdate", find2)
            cmd.Parameters.AddWithValue("@latecomingtime", find3)
            cmd.Parameters.AddWithValue("@letterdate", find1)
            cmd.Parameters.AddWithValue("@firstwarningdate", find4)
            cmd.Parameters.AddWithValue("@lettergivenby", find5)
            cmd.Parameters.AddWithValue("@keyinby", "")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_finalwarningabove30")
            'insert into er_finalwarningabove30 values(@ecode,@latecomingdate,@latecomingtime,@letterdate,@firstwarningdate,@lettergivenby,getdate(),@keyinby)

            'cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("firstwarningdate"), TextBox).Text
            ''find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find4 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            'find5 = DirectCast(Me.PlaceHolder1.FindControl("vwdate"), TextBox).Text
            'cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            'cmd.Parameters.AddWithValue("@itimedate", find4)
            'cmd.Parameters.AddWithValue("@vwdate", find5)
            'cmd.Parameters.AddWithValue("@fwdate", find2)
            'cmd.Parameters.AddWithValue("@desc", "Finalwarningabove30")
            'cmd.Parameters.AddWithValue("@secode", "")
            'cmd.Parameters.AddWithValue("@ldate", find1)
            'cmd.Parameters.AddWithValue("@cby", "IT")
            'cmd.Parameters.AddWithValue("@edit", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_misfinalwarning")
            'insert into er_misfinalwarning values(@ecode,@itimedate,@vwdate,@fwdate,@desc,'',@secode,@ldate,@cby,GETDATE(),@edit,@revi,@cont)

        ElseIf DropDownList1.Text = "Finalwarningbelow30" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNINGLESS30]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("firstwarningdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("lettergivenby"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@latecomingdate", find2)
            cmd.Parameters.AddWithValue("@latecomingtime", find3)
            cmd.Parameters.AddWithValue("@letterdate", find1)
            cmd.Parameters.AddWithValue("@firstwarningdate", find4)
            cmd.Parameters.AddWithValue("@lettergivenby", find5)
            cmd.Parameters.AddWithValue("@keyinby", "")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_finalwarningless30")
            'insert into er_finalwarningless30 values(@ecode,@latecomingdate,@latecomingtime,@letterdate,@firstwarningdate,@lettergivenby,getdate(),@keyinby)

            'cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("firstwarningdate"), TextBox).Text
            ''find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find4 = DirectCast(Me.PlaceHolder1.FindControl("vwdate"), TextBox).Text
            'find5 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            'cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            'cmd.Parameters.AddWithValue("@itimedate", find5)
            'cmd.Parameters.AddWithValue("@vwdate", find4)
            'cmd.Parameters.AddWithValue("@fwdate", find2)
            'cmd.Parameters.AddWithValue("@desc", "Finalwarningbelow30")
            'cmd.Parameters.AddWithValue("@secode", "")
            'cmd.Parameters.AddWithValue("@ldate", find1)
            'cmd.Parameters.AddWithValue("@cby", "IT")
            'cmd.Parameters.AddWithValue("@edit", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_misfinalwarning")
            ''insert into er_misfinalwarning values(@ecode,@itimedate,@vwdate,@fwdate,@desc,'',@secode,@ldate,@cby,GETDATE(),@edit,@revi,@cont)

        ElseIf DropDownList1.Text = "Finalwarninghostel" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_HOSTEL_FINAL]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("reason"), TextBox).Text
            'find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("verbalwarningdate"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("firstwarningdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@mis", find2)
            cmd.Parameters.AddWithValue("@latetime", find4)
            cmd.Parameters.AddWithValue("@latedt", find5)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@verb", find6)
            cmd.Parameters.AddWithValue("@fdate", find7)
            cmd.Parameters.AddWithValue("@secode", "")
            cmd.Parameters.AddWithValue("@ed", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@letrcont", HtmlEditor1.Text)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to hrmis_er_host_finalwarning")
            'insert into hrmis_er_host_finalwarning values(@ecode,@mis,@latetime,@latedt,@ldate,@verb,@fdate,@secode,@ed,@revi,@letrcont,@cby,getdate())

        ElseIf DropDownList1.Text = "Finalwarningmorethan1hour" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNINGMOREHOUR]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("firstwarningdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("lettergivenby"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@latecomingdate", find2)
            cmd.Parameters.AddWithValue("@latecomingtime", find3)
            cmd.Parameters.AddWithValue("@letterdate", find1)
            cmd.Parameters.AddWithValue("@firstwarningdate", find4)
            cmd.Parameters.AddWithValue("@lettergivenby", find5)
            cmd.Parameters.AddWithValue("@keyinby", "")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_finalwarningless30")

            'cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            ''find2 = DirectCast(Me.PlaceHolder1.FindControl("firstwarningdate"), TextBox).Text
            ''find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find4 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            'find5 = DirectCast(Me.PlaceHolder1.FindControl("verbalwdate"), TextBox).Text
            'find6 = DirectCast(Me.PlaceHolder1.FindControl("finalwdate"), TextBox).Text
            'cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            'cmd.Parameters.AddWithValue("@itimedate", find4)
            'cmd.Parameters.AddWithValue("@vwdate", find5)
            'cmd.Parameters.AddWithValue("@fwdate", find6)
            'cmd.Parameters.AddWithValue("@desc", "Finalwarningmorethan1hour")
            'cmd.Parameters.AddWithValue("@secode", "")
            'cmd.Parameters.AddWithValue("@ldate", find1)
            'cmd.Parameters.AddWithValue("@cby", "IT")
            'cmd.Parameters.AddWithValue("@edit", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_misfinalwarning")
            'insert into er_misfinalwarning values(@ecode,@itimedate,@vwdate,@fwdate,@desc,'',@secode,@ldate,@cby,GETDATE(),@edit,@revi,@cont)

        ElseIf DropDownList1.Text = "Finalwarningletter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("vwdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("fwdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@itimedate", find3)
            cmd.Parameters.AddWithValue("@vwdate", find4)
            cmd.Parameters.AddWithValue("@fwdate", find5)
            cmd.Parameters.AddWithValue("@desc", "Finalwarning")
            cmd.Parameters.AddWithValue("@secode", find2)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_misfinalwarning")
            'insert into er_misfinalwarning values(@ecode,@itimedate,@vwdate,@fwdate,@desc,'',@secode,@ldate,@cby,GETDATE(),@edit,@revi,@cont)

        ElseIf DropDownList1.Text = "Firstwarning" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("counseling"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("verbalwdate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@itimedate", find4)
            cmd.Parameters.AddWithValue("@wdate", find3)
            cmd.Parameters.AddWithValue("@secode", find5)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@desc", "Firstwarning")
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@ed", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@letrcont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_misfirstwarning")
            'insert into er_misfirstwarning values(@ecode,@itimedate,@wdate,@secode,@ldate,@desc,@cby,getdate(),@ed,@revi,@letrcont)

        ElseIf DropDownList1.Text = "Firstwarningabove30min" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNINGABOVE30]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("verbalwarningdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@latecomingdate", find1)
            cmd.Parameters.AddWithValue("@letterdate", find2)
            cmd.Parameters.AddWithValue("@latecomingtime", find3)
            cmd.Parameters.AddWithValue("@vwdate", find4)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_firstwarningabove30min")
            'insert into er_firstwarningabove30min values(@code,@latecomingdate,@letterdate,@latecomingtime,@vwdate)

            'cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            'find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            'find4 = DirectCast(Me.PlaceHolder1.FindControl("verbalwarningdate"), TextBox).Text
            ''find5 = DirectCast(Me.PlaceHolder1.FindControl("companyname"), TextBox).Text
            ''find6 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find7 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            'cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            'cmd.Parameters.AddWithValue("@itimedate", find7)
            'cmd.Parameters.AddWithValue("@wdate", find4)
            'cmd.Parameters.AddWithValue("@secode", "")
            'cmd.Parameters.AddWithValue("@ldate", find2)
            'cmd.Parameters.AddWithValue("@desc", "Firstwarningabove30min")
            'cmd.Parameters.AddWithValue("@cby", "IT")
            'cmd.Parameters.AddWithValue("@ed", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@letrcont", HtmlEditor1.Text)
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_misfirstwarning")
            ''insert into er_misfirstwarning values(@ecode,@itimedate,@wdate,@secode,@ldate,@desc,@cby,getdate(),@ed,@revi,@letrcont)

        ElseIf DropDownList1.Text = "Firstwarningbelow30min" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNINGBELOW30]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("verbalwarningdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@latecomingtime", find1)
            cmd.Parameters.AddWithValue("@latecomingdate", find2)
            cmd.Parameters.AddWithValue("@letterdate", find3)
            cmd.Parameters.AddWithValue("@vwdate", find4)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_firstwarningbelow30min")
            'insert into er_firstwarningbelow30min values(@code,@latecomingdate,@letterdate,@latecomingtime,@vwdate)

            'cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("verbalwarningdate"), TextBox).Text
            ''find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find4 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            'cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            'cmd.Parameters.AddWithValue("@itimedate", find1)
            'cmd.Parameters.AddWithValue("@wdate", find2)
            'cmd.Parameters.AddWithValue("@secode", "")
            'cmd.Parameters.AddWithValue("@ldate", find4)
            'cmd.Parameters.AddWithValue("@desc", "Firstwarningbelow30min")
            'cmd.Parameters.AddWithValue("@cby", "IT")
            'cmd.Parameters.AddWithValue("@ed", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@letrcont", HtmlEditor1.Text)
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_misfirstwarning")
            'insert into er_misfirstwarning values(@ecode,@itimedate,@wdate,@secode,@ldate,@desc,@cby,getdate(),@ed,@revi,@letrcont)

        ElseIf DropDownList1.Text = "Firstwarningmorethan1hour1" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNINGMORETHANHOUR]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("verbalwarningdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@latecomingdate", find2)
            cmd.Parameters.AddWithValue("@letterdate", find4)
            cmd.Parameters.AddWithValue("@latecomingtime", find3)
            cmd.Parameters.AddWithValue("@vwdate", find5)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_firstwarningmorethan1hour")
            'insert into er_firstwarningmorethan1hour values(@code,@latecomingdate,@letterdate,@latecomingtime,@vwdate)

            'cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("verbalwarningdate"), TextBox).Text
            ''find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find4 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            'cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            'cmd.Parameters.AddWithValue("@itimedate", find1)
            'cmd.Parameters.AddWithValue("@wdate", find2)
            'cmd.Parameters.AddWithValue("@secode", "")
            'cmd.Parameters.AddWithValue("@ldate", find4)
            'cmd.Parameters.AddWithValue("@desc", "Firstwarningmorethan1hour1")
            'cmd.Parameters.AddWithValue("@cby", "IT")
            'cmd.Parameters.AddWithValue("@ed", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@letrcont", HtmlEditor1.Text)
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_misfirstwarning")
            'insert into er_misfirstwarning values(@ecode,@itimedate,@wdate,@secode,@ldate,@desc,@cby,getdate(),@ed,@revi,@letrcont)

        ElseIf DropDownList1.Text = "Formaladvice" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FORMALADVISE]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("discussiondate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("misconductdetails"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("natureofadvice"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("formalplan"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@discussion", find1)
            cmd.Parameters.AddWithValue("@ltrdate", find2)
            cmd.Parameters.AddWithValue("@misdetials", find3)
            cmd.Parameters.AddWithValue("@nature", find4)
            cmd.Parameters.AddWithValue("@formal", find5)
            cmd.Parameters.AddWithValue("@supempcode", find6)
            cmd.Parameters.AddWithValue("@creatby", "IT")
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@revision", "")
            cmd.Parameters.AddWithValue("@contents", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_formaladvice")
            'insert into er_formaladvice values(@code,@discussion,@ltrdate,@misdetials,@nature,@formal,@supempcode,@creatby,getdate(),@edit,@revision,@contents)

        ElseIf DropDownList1.Text = "Grievance" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_GRIEVANCE]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("typeofgrievance"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("briefgrievance"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@type", find1)
            cmd.Parameters.AddWithValue("@desc", find2)
            cmd.Parameters.AddWithValue("@ldate", find3)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@ed", "")
            cmd.Parameters.AddWithValue("@rev", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_grievance")
            'insert into er_grievance values(@ecode,@type,@desc,@ldate,@cby,getdate(),@ed,@rev,@cont)

        ElseIf DropDownList1.Text = "Latemorethan24hrs" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_LATEMORETHAN24HRS]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@letterdate", find1)
            cmd.Parameters.AddWithValue("@latecomingtime", find2)
            cmd.Parameters.AddWithValue("@latecomingdate", find3)
            cmd.ExecuteNonQuery()
            MessageBox("Record Saved to er_latemorethan24hrs")
            'insert into dbo.er_latemorethan24hrs values(@code,@latecomingtime,@latecomingdate,@letterdate)

            'cmd = New SqlCommand("[dbo].[HRMIS_ER_LATEFORWORK]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("warningdate"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            'find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            'find4 = DirectCast(Me.PlaceHolder1.FindControl("issuancefrom"), TextBox).Text
            'find5 = DirectCast(Me.PlaceHolder1.FindControl("issuanceto"), TextBox).Text
            'find6 = DirectCast(Me.PlaceHolder1.FindControl("reportactiontaken"), TextBox).Text
            ''find7 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            'cmd.Parameters.AddWithValue("@vwdate", find1)
            'cmd.Parameters.AddWithValue("@latedate", find2)
            'cmd.Parameters.AddWithValue("@time", find3)
            'cmd.Parameters.AddWithValue("@ifrom", find4)
            'cmd.Parameters.AddWithValue("@ito", find5)
            'cmd.Parameters.AddWithValue("@action", find6)
            'cmd.Parameters.AddWithValue("@secode", "")
            'cmd.Parameters.AddWithValue("@cby", "IT")
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_lateforwork")
            ''insert into er_lateforwork values(@ecode,@vwdate,@latedate,@time,@ifrom,@ito,@action,'',@secode,@cby,getdate())

        ElseIf DropDownList1.Text = "Misconductreport" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_MISCONDUCTREPORT]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("rptdescription"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("reportedby"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("witness"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("dateofissue"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("placelocation"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("reasondesc"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("dhremarks"), TextBox).Text
            find8 = DirectCast(Me.PlaceHolder1.FindControl("acttakenby"), TextBox).Text
            find9 = DirectCast(Me.PlaceHolder1.FindControl("erdremarks"), TextBox).Text
            find10 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@descp", find1)
            cmd.Parameters.AddWithValue("@repby", find2)
            cmd.Parameters.AddWithValue("@witness", find3)
            cmd.Parameters.AddWithValue("@doi", find4)
            cmd.Parameters.AddWithValue("@place", find5)
            cmd.Parameters.AddWithValue("@reason", find6)
            cmd.Parameters.AddWithValue("@dhremarks", find7)
            cmd.Parameters.AddWithValue("@takenby", find8)
            cmd.Parameters.AddWithValue("@erremark", find9)
            cmd.Parameters.AddWithValue("@ltr", find10)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_misconductreport")
            'insert into er_misconductreport values(@code,@descp,@repby,@witness,@doi,@place,@reason,@dhremarks,@takenby,@erremark,@ltr) 

        ElseIf DropDownList1.Text = "Misfinalwarning" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNING1]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("verbalwdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("finalwdate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("misconduct"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@itimedate", find1)
            cmd.Parameters.AddWithValue("@vwdate", find2)
            cmd.Parameters.AddWithValue("@fwdate", find3)
            cmd.Parameters.AddWithValue("@desc", find4)
            cmd.Parameters.AddWithValue("@secode", find5)
            cmd.Parameters.AddWithValue("@ldate", find6)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_misfinalwarning")
            'insert into er_misfinalwarning values(@ecode,@itimedate,@vwdate,@fwdate,@desc,'',@secode,@ldate,@cby,GETDATE(),@edit,@revi,@cont)

        ElseIf DropDownList1.Text = "Misfirstwarning letter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FIRSTWARNING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("timedateoffence"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("verbalwdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("desmisconduct"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@itimedate", find1)
            cmd.Parameters.AddWithValue("@wdate", find2)
            cmd.Parameters.AddWithValue("@secode", find3)
            cmd.Parameters.AddWithValue("@ldate", find4)
            cmd.Parameters.AddWithValue("@desc", find5)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@ed", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@letrcont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_misfirstwarning")
            'insert into er_misfirstwarning values(@ecode,@itimedate,@wdate,@secode,@ldate,@desc,@cby,getdate(),@ed,@revi,@letrcont)

        ElseIf DropDownList1.Text = "Preliminarycounseling" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_PIP_PRILIMINARY]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("pppjemp"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("pppjofficer"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("datecounselingemp"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("areasdeclining"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("reasondeclining"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("proposed"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("remarks"), TextBox).Text
            find8 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@period", find1)
            cmd.Parameters.AddWithValue("@counsellercode", find2)
            cmd.Parameters.AddWithValue("@datecounsiling", find3)
            cmd.Parameters.AddWithValue("@areas", find4)
            cmd.Parameters.AddWithValue("@reason", find5)
            cmd.Parameters.AddWithValue("@proposed", find6)
            cmd.Parameters.AddWithValue("@remarks", find7)
            cmd.Parameters.AddWithValue("@ltrdate", find8)
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@revision", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.Parameters.AddWithValue("@createdby", "IT")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_preliminarycounseling")
            'insert into er_preliminarycounseling values (@code,@period,@counsellercode,'',@datecounsiling,@areas,@reason,@proposed,@remarks,@ltrdate,@edit,@revision,@cont,@createdby,getdate())

        ElseIf DropDownList1.Text = "Showcausewarning" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_SHOWCAUSELETTER]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("reportdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("reporthours"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("misconduct"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("mdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@repdate", find1)
            cmd.Parameters.AddWithValue("@rephr", find2)
            cmd.Parameters.AddWithValue("@misdetials", find3)
            cmd.Parameters.AddWithValue("@mdate", find6)
            cmd.Parameters.AddWithValue("@doi", find4)
            cmd.Parameters.AddWithValue("@supempcode", find5)
            cmd.Parameters.AddWithValue("@creatby", "IT")
            cmd.Parameters.AddWithValue("@edi", "")
            cmd.Parameters.AddWithValue("@revision", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_showcauseletter")
            'insert into er_showcauseletter values(@code,@repdate,@rephr,@misdetials,@mdate,@doi,@supempcode,@creatby,getdate(),@edi,@revision,@cont)

        ElseIf DropDownList1.Text = "SuspensionLetter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_SUSPEND]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("sfromdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("stodate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("reason"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@fdate", find2)
            cmd.Parameters.AddWithValue("@tdate", find3)
            cmd.Parameters.AddWithValue("@reason", find4)
            cmd.Parameters.AddWithValue("@semp", find5)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@ct", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_suspension")
            'insert into er_suspension values(@ecode,@ldate,@fdate,@tdate,@reason,@semp,getdate(),@cby,@edit,@revi,@ct)

        ElseIf DropDownList1.Text = "Terminationletter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_TERMINATE]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("tletterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("tappdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("tdate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("lastdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@adate", find2)
            cmd.Parameters.AddWithValue("@desig", designation.Text)
            cmd.Parameters.AddWithValue("@tdate", find3)
            cmd.Parameters.AddWithValue("@lastdate", find4)
            cmd.Parameters.AddWithValue("@scode", find5)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@ed", "")
            cmd.Parameters.AddWithValue("@rev", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_termination")
            'insert into er_termination values(@ecode,@ldate,@adate,@desig,@tdate,@lastdate,@scode,@cby,getdate(),@ed,@rev,@cont)

        ElseIf DropDownList1.Text = "Verbalwarningabove30min" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_VERBALWARNINGABOVE30]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@letterdate", find1)
            cmd.Parameters.AddWithValue("@latecomingtime", find2)
            cmd.Parameters.AddWithValue("@latecomingdate", find3)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_verbalwarningabove30min")
            'insert into er_verbalwarningabove30min values(@code,@latecomingtime,@latecomingdate,@letterdate)
            '    cmd = New SqlCommand("[dbo].[HRMIS_ER_VERBALWARNING]", con)
            '    cmd.CommandType = CommandType.StoredProcedure
            '    find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            '    find2 = DirectCast(Me.PlaceHolder1.FindControl("desmisconduct"), TextBox).Text
            '    find3 = DirectCast(Me.PlaceHolder1.FindControl("actiontaken"), TextBox).Text
            '    'find4 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            '    find5 = DirectCast(Me.PlaceHolder1.FindControl("reason"), TextBox).Text
            '    find6 = DirectCast(Me.PlaceHolder1.FindControl("remarks"), TextBox).Text
            '    cmd.Parameters.AddWithValue("@code", empcode.Text)
            '    cmd.Parameters.AddWithValue("@ltrdate", find1)
            '    cmd.Parameters.AddWithValue("@misdetials", find2)
            '    cmd.Parameters.AddWithValue("@action", find3)
            '    cmd.Parameters.AddWithValue("@supempcode", "")
            '    cmd.Parameters.AddWithValue("@reason", find5)
            '    cmd.Parameters.AddWithValue("@remarks", find6)
            '    cmd.Parameters.AddWithValue("@edit", "")
            '    cmd.Parameters.AddWithValue("@revi", "")
            '    cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            '    cmd.Parameters.AddWithValue("@creatby", "IT")
            '    cmd.ExecuteNonQuery()
            '    MessageBox("Record saved to er_verbalwarning")
            '    'insert into er_verbalwarning values(@code,@ltrdate,@misdetials,@action,@supempcode,@reason,@remarks,@edit,@revi,@cont,@creatby,getdate())

        ElseIf DropDownList1.Text = "Verbalwarningbelow30min" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_VERBALWARNINGBELOW30]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@letterdate", find1)
            cmd.Parameters.AddWithValue("@latecomingtime", find2)
            cmd.Parameters.AddWithValue("@latecomingdate", find3)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_verbalwarningbelow30min")
            'insert into er_verbalwarningbelow30min values(@code,@latecomingtime,@latecomingdate,@letterdate)
            'previous sp below
            'cmd = New SqlCommand("[dbo].[HRMIS_ER_VERBALWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("desmisconduct"), TextBox).Text
            'find3 = DirectCast(Me.PlaceHolder1.FindControl("actiontaken"), TextBox).Text
            ''find4 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find5 = DirectCast(Me.PlaceHolder1.FindControl("reason"), TextBox).Text
            'find6 = DirectCast(Me.PlaceHolder1.FindControl("remarks"), TextBox).Text
            'cmd.Parameters.AddWithValue("@code", empcode.Text)
            'cmd.Parameters.AddWithValue("@ltrdate", find1)
            'cmd.Parameters.AddWithValue("@misdetials", find2)
            'cmd.Parameters.AddWithValue("@action", find3)
            'cmd.Parameters.AddWithValue("@supempcode", "")
            'cmd.Parameters.AddWithValue("@reason", find5)
            'cmd.Parameters.AddWithValue("@remarks", find6)
            'cmd.Parameters.AddWithValue("@edit", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            'cmd.Parameters.AddWithValue("@creatby", "IT")
            'cmd.ExecuteNonQuery()
            'insert into er_verbalwarning values(@code,@ltrdate,@misdetials,@action,@supempcode,@reason,@remarks,@edit,@revi,@cont,@creatby,getdate())

        ElseIf DropDownList1.Text = "Verbalwarningletter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_VERBALWARNING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("desmisconduct"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("actiontaken"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("reason"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("remarks"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@ltrdate", find1)
            cmd.Parameters.AddWithValue("@misdetials", find2)
            cmd.Parameters.AddWithValue("@action", find3)
            cmd.Parameters.AddWithValue("@supempcode", find4)
            cmd.Parameters.AddWithValue("@reason", find5)
            cmd.Parameters.AddWithValue("@remarks", find6)
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.Parameters.AddWithValue("@creatby", "IT")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_verbalwarning")
            'insert into er_verbalwarning values(@code,@ltrdate,@misdetials,@action,@supempcode,@reason,@remarks,@edit,@revi,@cont,@creatby,getdate())

        ElseIf DropDownList1.Text = "Verbalwarningmorethan1hour" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_VERBALWARNING1HOUR]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latecomingtime"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("latecomingdate"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@letterdate", find1)
            cmd.Parameters.AddWithValue("@latecomingtime", find2)
            cmd.Parameters.AddWithValue("@latecomingdate", find3)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_verbalwarningbelow30min")
            'insert into dbo.er_verbalwarningmorethan1hour values(@code,@latecomingtime,@latecomingdate,@letterdate)
            'cmd = New SqlCommand("[dbo].[HRMIS_ER_VERBALWARNING]", con)
            'cmd.CommandType = CommandType.StoredProcedure
            'find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            'find2 = DirectCast(Me.PlaceHolder1.FindControl("desmisconduct"), TextBox).Text
            'find3 = DirectCast(Me.PlaceHolder1.FindControl("actiontaken"), TextBox).Text
            ''find4 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            'find5 = DirectCast(Me.PlaceHolder1.FindControl("reason"), TextBox).Text
            'find6 = DirectCast(Me.PlaceHolder1.FindControl("remarks"), TextBox).Text
            'cmd.Parameters.AddWithValue("@code", empcode.Text)
            'cmd.Parameters.AddWithValue("@ltrdate", find1)
            'cmd.Parameters.AddWithValue("@misdetials", find2)
            'cmd.Parameters.AddWithValue("@action", find3)
            'cmd.Parameters.AddWithValue("@supempcode", "")
            'cmd.Parameters.AddWithValue("@reason", find5)
            'cmd.Parameters.AddWithValue("@remarks", find6)
            'cmd.Parameters.AddWithValue("@edit", "")
            'cmd.Parameters.AddWithValue("@revi", "")
            'cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            'cmd.Parameters.AddWithValue("@creatby", "IT")
            'cmd.ExecuteNonQuery()
            'MessageBox("Record saved to er_verbalwarning")
            ''insert into er_verbalwarning values(@code,@ltrdate,@misdetials,@action,@supempcode,@reason,@remarks,@edit,@revi,@cont,@creatby,getdate())

        ElseIf DropDownList1.Text = "Writtenwarningletter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_WRITTENWARNING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("wwdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("warningdetails"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@warndate", find1)
            cmd.Parameters.AddWithValue("@warndetails", find2)
            cmd.Parameters.AddWithValue("@supempcode", find3)
            cmd.Parameters.AddWithValue("@creatby", "IT")
            cmd.Parameters.AddWithValue("@edi", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@conts", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_writtenwarning")
            'insert into er_writtenwarning values(@code,@warndate,@warndetails,@supempcode,@creatby,getdate(),@edi,@revi,@conts)

        ElseIf DropDownList1.Text = "Reporting Late For Work" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_LATEFORWORK]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("warningdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("latedate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("timeofwork"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("issuancefrom"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("issuanceto"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("reportactiontakenby"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@vwdate", find1)
            cmd.Parameters.AddWithValue("@latedate", find2)
            cmd.Parameters.AddWithValue("@time", find3)
            cmd.Parameters.AddWithValue("@ifrom", find4)
            cmd.Parameters.AddWithValue("@ito", find5)
            cmd.Parameters.AddWithValue("@action", find6)
            cmd.Parameters.AddWithValue("@secode", find7)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_lateforwork")
            'insert into er_lateforwork values(@ecode,@vwdate,@latedate,@time,@ifrom,@ito,@action,'',@secode,@cby,getdate())

        ElseIf DropDownList1.Text = "Abscond letter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_ABSCOND]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("fromdate"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("todate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("lastworkdate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("notice"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("noofdays"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@fdate", find2)
            cmd.Parameters.AddWithValue("@tdate", find3)
            cmd.Parameters.AddWithValue("@lastdate", find4)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@notice", find5)
            cmd.Parameters.AddWithValue("@days", find6)
            cmd.Parameters.AddWithValue("@scode", find7)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edi", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_abscondletter")
            'insert into er_abscondletter values(@ecode,@fdate,@tdate,@lastdate,@ldate,@notice,@days,'S',@scode,@cby,getdate(),@edi,@revi,@cont)

        ElseIf DropDownList1.Text = "Inquiry/chargeletter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_INQUIRY]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("explanationdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("letterdated"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("titlecharges"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("othercharges"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("inquirydate"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("inquirytime"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("inquiryplace"), TextBox).Text
            find8 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@code", empcode.Text)
            cmd.Parameters.AddWithValue("@explanationdated", find1)
            cmd.Parameters.AddWithValue("@letterdated", find2)
            cmd.Parameters.AddWithValue("@titlecharges", find3)
            cmd.Parameters.AddWithValue("@othercharges", find4)
            cmd.Parameters.AddWithValue("@inquiryhelddate", find5)
            cmd.Parameters.AddWithValue("@itime", find6)
            cmd.Parameters.AddWithValue("@iplace", find7)
            cmd.Parameters.AddWithValue("@scode", find8)
            cmd.Parameters.AddWithValue("@createdby", "IT")
            cmd.Parameters.AddWithValue("@edi", "")
            cmd.Parameters.AddWithValue("@revi", "")
            cmd.Parameters.AddWithValue("@cont", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_inquiry")
            'insert into er_inquiry values (@code,@explanationdated,@letterdated,@titlecharges,@othercharges,@inquiryhelddate,@itime,@iplace,'',@scode,@createdby,getdate(),@edi,@revi,@cont) 

        ElseIf DropDownList1.Text = "Missing from workplace" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_MISSING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("wdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("mitime"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("midate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("timereportwork"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("mactiontaken"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("missuancefrom"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("missuanceto"), TextBox).Text
            find8 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@wdate", find1)
            cmd.Parameters.AddWithValue("@mtime", find2)
            cmd.Parameters.AddWithValue("@mdate", find3)
            cmd.Parameters.AddWithValue("@wtime", find4)
            cmd.Parameters.AddWithValue("@action", find5)
            cmd.Parameters.AddWithValue("@ifrom", find6)
            cmd.Parameters.AddWithValue("@ito", find7)
            cmd.Parameters.AddWithValue("@scode", find8)
            cmd.Parameters.AddWithValue("@cby", "")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_missingworkplace")
            'insert into er_missingworkplace values(@ecode,@wdate,@mtime,@mdate,@wtime,@action,@ifrom,@ito,'',@scode,@cby,getdate())

        ElseIf DropDownList1.Text = "Breach of contract(ABS)" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_BREACHBS]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("inquirydate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("timeandplace"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("afromdate"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("atodate"), TextBox).Text
            find5 = DirectCast(Me.PlaceHolder1.FindControl("firstabsentdate"), TextBox).Text
            find6 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find7 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@idate", find1)
            cmd.Parameters.AddWithValue("@tandp", find2)
            cmd.Parameters.AddWithValue("@fdate", find3)
            cmd.Parameters.AddWithValue("@tdate", find4)
            cmd.Parameters.AddWithValue("@firstday", find5)
            cmd.Parameters.AddWithValue("@ldate", find6)
            cmd.Parameters.AddWithValue("@scode", find7)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.Parameters.AddWithValue("@edit", "")
            cmd.Parameters.AddWithValue("@rev", "")
            cmd.Parameters.AddWithValue("@con", HtmlEditor1.Text)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_breachabsent")
            'insert into er_breachabsent values(@ecode,@idate,@tandp,@fdate,@tdate,@firstday,@ldate,@scode,@cby,getdate(),@edit,@rev,@con)

        ElseIf DropDownList1.Text = "Any Type of Warning Letter" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_DIRECTFINALWARNING]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("vdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("reference"), TextBox).Text
            find3 = DirectCast(Me.PlaceHolder1.FindControl("desmisconduct"), TextBox).Text
            find4 = DirectCast(Me.PlaceHolder1.FindControl("keyinempnoforsignature"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@ref", find2)
            cmd.Parameters.AddWithValue("@desmis", find3)
            cmd.Parameters.AddWithValue("@vdate", find1)
            cmd.Parameters.AddWithValue("@sempcode", find4)
            cmd.Parameters.AddWithValue("@cby", "IT")
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_directfinalwarning")
            'insert into er_directfinalwarning values(@ecode,@ref,@desmis,@vdate,@sempcode,@cby,getdate())

        ElseIf DropDownList1.Text = "Final warning(Over Night)" Then
            cmd = New SqlCommand("[dbo].[HRMIS_ER_FINALWARNING(OVERNIGHT)]", con)
            cmd.CommandType = CommandType.StoredProcedure
            find1 = DirectCast(Me.PlaceHolder1.FindControl("letterdate"), TextBox).Text
            find2 = DirectCast(Me.PlaceHolder1.FindControl("reason"), TextBox).Text
            cmd.Parameters.AddWithValue("@ecode", empcode.Text)
            cmd.Parameters.AddWithValue("@ldate", find1)
            cmd.Parameters.AddWithValue("@reason", find2)
            cmd.ExecuteNonQuery()
            MessageBox("Record saved to er_finalwarninghostel")
            'insert into er_finalwarninghostel  values(@ecode,@ldate,@reason)

        End If
    End Sub
    Protected Sub getDetails()
        '''' Get Explanation
        Dim dsexp As DataSet
        Dim drexp As DataRow
        dsexp = GetExplanation(empcode.Text.Trim)
        If dsexp.Tables(0).Rows.Count <> 0 Then
            drexp = dsexp.Tables(0).Rows(0)
            lblexpl.Text = drexp("expr2").ToString
        Else
            lblexpl.Text = 0
        End If
        '''' Get verbal
        Dim dsv As DataSet
        Dim drv As DataRow
        dsv = Getverbal(empcode.Text.Trim)
        If dsv.Tables(0).Rows.Count <> 0 Then
            drv = dsv.Tables(0).Rows(0)
            lblvw.Text = drv("expr2").ToString
        Else
            lblvw.Text = 0
        End If
        '''' Get written 
        Dim dsw As DataSet
        Dim drw As DataRow
        dsw = Getwritten(empcode.Text.Trim)
        If dsw.Tables(0).Rows.Count <> 0 Then
            drw = dsw.Tables(0).Rows(0)
            lblww.Text = drw("expr2").ToString
        Else
            lblww.Text = 0
        End If

        '''' Get first
        Dim dsf As DataSet
        Dim drf As DataRow
        dsf = Getfirst(empcode.Text.Trim)
        If dsf.Tables(0).Rows.Count <> 0 Then
            drf = dsf.Tables(0).Rows(0)
            lblfw.Text = drf("expr2").ToString
        Else
            lblfw.Text = 0
        End If

        '''' Get final
        Dim dsfi As DataSet
        Dim drfi As DataRow
        dsfi = Getfinal(empcode.Text.Trim)
        If dsfi.Tables(0).Rows.Count <> 0 Then
            drfi = dsfi.Tables(0).Rows(0)
            lblfinw.Text = drfi("expr2").ToString
        Else
            lblfinw.Text = 0
        End If
        '''' Get suspension
        Dim dsfs As DataSet
        Dim drfs As DataRow
        dsfs = Getsuspension(empcode.Text.Trim)
        If dsfs.Tables(0).Rows.Count <> 0 Then
            drfs = dsfs.Tables(0).Rows(0)
            lblsus.Text = drfs("expr2").ToString
        Else
            lblsus.Text = 0
        End If

        '''' Get show cause
        Dim dssc As DataSet
        Dim drsc As DataRow
        dssc = Getshowcase(empcode.Text.Trim)
        If dssc.Tables(0).Rows.Count <> 0 Then
            drsc = dssc.Tables(0).Rows(0)
            lblsc.Text = drsc("expr2").ToString
        Else
            lblsc.Text = 0
        End If
        '''' Get Misconduct reports
        Dim dsr As DataSet
        Dim drr As DataRow
        dsr = GetMisRpt(empcode.Text.Trim)
        If dsr.Tables(0).Rows.Count <> 0 Then
            drr = dsr.Tables(0).Rows(0)
            lblrpt.Text = drr("expr2").ToString
        Else
            lblrpt.Text = 0
        End If

    End Sub
    Function GetExplanation(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_explanation GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "Explanation")
        con.Close()
        Return ds
    End Function
    Function Getverbal(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_verbalwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "varbal")
        con.Close()
        Return ds
    End Function
    Function Getwritten(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_writtenwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "written")
        con.Close()
        Return ds
    End Function
    Function Getfirst(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misfirstwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "first")
        con.Close()
        Return ds
    End Function
    Function Getfinal(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misfinalwarning  GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "final")
        con.Close()
        Return ds
    End Function
    Function Getsuspension(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_suspension GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "suspension")
        con.Close()
        Return ds
    End Function
    Function Getshowcase(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_showcauseletter GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "showcase")
        con.Close()
        Return ds
    End Function
    Function GetMisRpt(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misconductreport GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "report")
        con.Close()
        Return ds
    End Function
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class