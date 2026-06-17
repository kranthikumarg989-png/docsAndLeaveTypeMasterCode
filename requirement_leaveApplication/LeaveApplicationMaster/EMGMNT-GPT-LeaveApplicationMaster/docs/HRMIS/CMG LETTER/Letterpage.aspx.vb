Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Letterpage
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
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        If DropDownList1.SelectedValue <> "-1" Then
            Dim ds1 As DataSet
            Dim dr1 As DataRow
            Dim Lfields1, Lfieldtype
            Dim labellist As New ArrayList
            Dim strtext, prefix
            Dim o, k
            'MsgBox(DropDownList1.SelectedItem.Text)
            '   strtext = "select field_name ,ltrim(rtrim(field_type)) as field_type,Ltrim(rtrim(prefix)) as prefix  from HRMIS_ER_LETTER_WIZARD where lettername='" & DropDownList1.SelectedItem.Text & "' and status =1"
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
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label2.Visible = True
        Dim strcontent As String
        Dim oldvalue, newvalue
        MyGlobal.Con_Str()

        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        con.Open()
        cmd = New SqlCommand("hrmis_CMG_GetLetterRevNo_preview", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ln", DropDownList1.SelectedValue)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            strcontent = dr("letterlink").ToString()
            Dim fn As String

            fn = "F:\E-Management\CMGLetter\" & strcontent
            Dim filePath As String = fn
            Dim objStreamReader As StreamReader
            objStreamReader = File.OpenText(filePath)
            Dim contents As String = objStreamReader.ReadToEnd()
            HtmlEditor1.Text = contents
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
        ' strtext = "hrmis_CMG_GetLetterRevNo_preview"
        dsabs = GetLetterFields1(strtext)
        Dim llink
        Dim rev

        If dsabs.Tables(0).Rows.Count <> 0 Then
            l = dsabs.Tables(0).Rows.Count
            For m = 0 To l - 1
                drabs = dsabs.Tables(0).Rows(m)
                Lfields = drabs("field_name").ToString
                prefix = drabs("prefix").ToString
                status = drabs("status").ToString
                rev = drabs("Revision").ToString
                llink = drabs("letterlink").ToString
                lbllink.text = llink
                oldvalue = Lfields
                myval = oldvalue
                newvalue = myval.Remove(0, prefix.Length)
                Dim strtexts As String = HtmlEditor1.Text

                If status = 1 Then
                    Dim txtt As TextBox
                    txtt = DirectCast(Me.PlaceHolder1.FindControl(newvalue), TextBox)
                    If HtmlEditor1.Text.Contains(Lfields) = True Then
                        HtmlEditor1.Text = HtmlEditor1.Text.Replace(Lfields, txtt.Text)
                    End If

                    '  txt = strtexts.Replace(Lfields, txtt.Text)
                    ' strtexts = txt
                    'cmd = New SqlCommand("HRMIS_CMG_APP_BANGLADESHI", con)
                    'cmd.CommandType = CommandType.StoredProcedure
                    'cmd.Parameters.AddWithValue("@code", empcode.Text)
                    'cmd.Parameters.AddWithValue("@ltrdate", txtt.Text)
                    'cmd.Parameters.AddWithValue("@efrom", txtt.Text)
                    'cmd.Parameters.AddWithValue("@eto", txtt.Text)
                    'cmd.Parameters.AddWithValue("@wcde", txtt.Text)
                    'cmd.Parameters.AddWithValue("@edit", "")
                    'cmd.Parameters.AddWithValue("@revi", "0")
                    'cmd.Parameters.AddWithValue("@ltrlik", "")
                    'cmd.Parameters.AddWithValue("@creatby", "")
                    'con.Open()
                    'cmd.ExecuteNonQuery()
                    'cmd.Dispose()
                    'con.Close()


                ElseIf status = 0 And newvalue <> "empcode" Then
                    Dim txtt As Label

                    txtt = DirectCast(Me.FindControl(newvalue), Label)
                    '  txt = strtexts.Replace(Lfields, txtt.Text)
                    If HtmlEditor1.Text.Contains(Lfields) = True Then
                        HtmlEditor1.Text = HtmlEditor1.Text.Replace(Lfields, txtt.Text)
                    End If
                    'strtexts = txt
                    'MsgBox(newvalue & txtt.Text & txt)


                ElseIf status = 0 And newvalue = "empcode" Then
                    Dim txtt As TextBox
                    txtt = DirectCast(Me.FindControl(newvalue), TextBox)
                    If HtmlEditor1.Text.Contains(Lfields) = True Then
                        HtmlEditor1.Text = HtmlEditor1.Text.Replace(Lfields, txtt.Text)
                    End If
                    'txt = strtexts.Replace(Lfields, txtt.Text)
                    'strtexts = txt
                    'MsgBox(newvalue & txtt.Text & txt)

                End If
                '  HtmlEditor1.Text = strtexts
            Next
        End If

        Me.HtmlEditor1.HtmlModeEditable = False
        Me.HtmlEditor1.DesignModeEditable = False
       
    End Sub
    Function GetLetterFields(ByVal strtext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("hrmis_CMG_GetLetterRevNo", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@ln", DropDownList1.SelectedValue)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "letter")
        con.Close()
        Return ds
    End Function
    Function GetLetterFields1(ByVal strtext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("hrmis_CMG_GetLetterRevNo_preview", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@ln", DropDownList1.SelectedValue)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "letter")
        con.Close()
        Return ds
    End Function
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        If DropDownList1.Text = "AppointmentLetterforBangladeshi" Then
            Response.Redirect("Letter_pre.aspx")
        Else
            Dim ds1 As DataSet
            Dim dr1 As DataRow
            Dim Lfields1, Lfieldtype
            Dim labellist As New ArrayList
            Dim strtext, prefix
            Dim o, k
            PlaceHolder1.Visible = True
            strtext = "hrmis_CMG_GetLetterRevNo"
            ds1 = GetLetterFields(strtext)
            If ds1.Tables(0).Rows.Count <> 0 Then
                o = ds1.Tables(0).Rows.Count
                'For k = 0 To o - 1
                '    dr1 = ds1.Tables(0).Rows(k)
                '    Lfields1 = dr1("field_name").ToString
                '    Lfieldtype = dr1("field_type").ToString
                '    prefix = dr1("prefix").ToString
                '    labellist.Add(Lfields1)
                'Next
            End If
            CreateDynamicTable(o, 2)
            Label2.Visible = True
        End If

    End Sub
    Private Sub CreateDynamicTable(ByVal Rows As Integer, ByVal columns As Integer)
        Dim ds1 As DataSet
        Dim dr1 As DataRow
        Dim Lfields1, Lfieldtype
        Dim labellist As New ArrayList
        Dim strtext, prefix
        Dim o, k
        ' strtext = "select field_name ,ltrim(rtrim(field_type)) as field_type,Ltrim(rtrim(prefix)) as prefix  from HRMIS_ER_LETTER_WIZARD where lettername='" & DropDownList1.SelectedItem.Text & "' and status =1"
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
                    label.Text = val
                    tc.Controls.Add(label)
                    tc.BackColor = Drawing.Color.Beige
                    tr.Cells.Add(tc)
                    ' ''' if second column then textbox
                ElseIf j = 1 Then
                    Dim txtBox As TextBox = New TextBox()
                    'If Lfieldtype = "Text Area" Then
                    '    txtBox.TextMode = TextBoxMode.MultiLine
                    '    MsgBox(Lfieldtype)
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
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        Dim empcode1
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
    End Sub

   

    Sub method()
        If True Then
            Dim insertCommand As SqlCommand = Nothing

            Dim strConnection As String = "Data Source=NB09;Initial Catalog=hrmis;uid=sa;Pwd="";"
            Dim objConnection As New SqlConnection(strConnection)
            Dim TextBoxValue As String = Nothing
            ' Dim strRoom
            For Each con As Control In PlaceHolder1.Controls
                If TypeOf con Is TextBox Then
                    TextBoxValue = DirectCast(con, TextBox).Text
                    ' For Each conn As Control In PlaceHolder1.Controls
                    objConnection.Open()
                    cmd = New SqlCommand("HRMIS_CMG_APP_BANGLADESHI", objConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@code", empcode.Text)
                    cmd.Parameters.AddWithValue("@ltrdate", TextBoxValue)
                    cmd.Parameters.AddWithValue("@efrom", TextBoxValue)
                    cmd.Parameters.AddWithValue("@eto", TextBoxValue)
                    cmd.Parameters.AddWithValue("@edit", "")
                    cmd.Parameters.AddWithValue("@revi", "")
                    cmd.Parameters.AddWithValue("@creatby", "")
                    cmd.ExecuteNonQuery()
                    objConnection.Close()
                    ' Next
                End If
            Next
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub


 
    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim objSW As StreamWriter
        Dim objFS As FileStream
        Dim s1 = empcode.Text
        Dim fn As String

        fn = lbllink.Text.Remove(lbllink.Text.Length - 5, 5)

        fn = fn + s1 + ".html"
        fn = "F:\E-Management\CMGLetterIssued\" & fn
        objFS = New FileStream(fn, FileMode.Create)
        '' app.activeDocumen.exportFile(ExportFormat.JPG,personName+".JPEG"); 
        objSW = New StreamWriter(objFS)
        objSW.Write(HtmlEditor1.Text)

        MessageBox("Letter Created Successfully")

        Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", "javascript:window.print();", True)
        HtmlEditor1.Text = ""
        objSW.Close()
        objFS.Close()
    End Sub
End Class