Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class jobapplicationmalay
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim sqltext, sqltxt, keyinby As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        If IsPostBack = False And Session("first") = "" Then
            datetoday.Text = Date.Now.ToShortDateString
            sqltext = "select max(applicationno)+1 as aplno from jobapplication"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                applno.Text = rdr("aplno")
            End While
            rdr.Close()
            SqlDataSource3.InsertParameters.Add("aplno", applno.Text)
            SqlDataSource3.Insert()
            'messageBox(applno.Text)
            'Session("back") = ""
            SqlDataSource4.InsertParameters.Add("applno", applno.Text)
            SqlDataSource4.InsertParameters.Add("un", " ")
            SqlDataSource4.InsertParameters.Add("ddldesig", "Assistance Store Keeper ")
            SqlDataSource4.InsertParameters.Add("name", " ")
            SqlDataSource4.InsertParameters.Add("address", " ")
            SqlDataSource4.InsertParameters.Add("icold", " ")
            SqlDataSource4.InsertParameters.Add("icnew", " ")
            SqlDataSource4.InsertParameters.Add("iccolor", iccolor.SelectedValue)
            SqlDataSource4.InsertParameters.Add("sex", " ")
            SqlDataSource4.InsertParameters.Add("mobile", " ")
            SqlDataSource4.InsertParameters.Add("phone", " ")
            SqlDataSource4.InsertParameters.Add("blood", " ")
            SqlDataSource4.InsertParameters.Add("nationality", " ")
            SqlDataSource4.InsertParameters.Add("epf", " ")
            SqlDataSource4.InsertParameters.Add("socso", " ")
            SqlDataSource4.InsertParameters.Add("tax", " ")
            SqlDataSource4.InsertParameters.Add("dob", " ")
            SqlDataSource4.InsertParameters.Add("age", " ")
            SqlDataSource4.InsertParameters.Add("lang", " ")
            SqlDataSource4.InsertParameters.Add("race", " ")
            SqlDataSource4.InsertParameters.Add("religion", " ")
            SqlDataSource4.InsertParameters.Add("country", "Afghanistan")
            SqlDataSource4.InsertParameters.Add("marital", " ")
            SqlDataSource4.InsertParameters.Add("relationship", " ")
            SqlDataSource4.InsertParameters.Add("rname", " ")
            SqlDataSource4.InsertParameters.Add("ricold", " ")
            SqlDataSource4.InsertParameters.Add("ricnew", " ")
            SqlDataSource4.InsertParameters.Add("rage", " ")
            SqlDataSource4.InsertParameters.Add("rcompany", " ")
            SqlDataSource4.InsertParameters.Add("roccupation", " ")
            SqlDataSource4.InsertParameters.Add("rphone", " ")
            SqlDataSource4.InsertParameters.Add("hubwife", " ")
            SqlDataSource4.InsertParameters.Add("hubwifeage", " ")
            SqlDataSource4.InsertParameters.Add("hubicold", " ")
            SqlDataSource4.InsertParameters.Add("hubicnew", " ")
            SqlDataSource4.InsertParameters.Add("child1", " ")
            SqlDataSource4.InsertParameters.Add("cage1", " ")
            SqlDataSource4.InsertParameters.Add("child2", " ")
            SqlDataSource4.InsertParameters.Add("cage2", " ")
            SqlDataSource4.InsertParameters.Add("child3", " ")
            SqlDataSource4.InsertParameters.Add("cage3", " ")
            SqlDataSource4.InsertParameters.Add("child4", " ")
            SqlDataSource4.InsertParameters.Add("cage4", " ")
            SqlDataSource4.InsertParameters.Add("child5", " ")
            SqlDataSource4.InsertParameters.Add("cage5", " ")
            SqlDataSource4.Insert()
            sqltext = "update jobapplication_temp set schoolname1=' ',highestpassed1=' ',joined1=' ',left1=' ',schoolname2=' ',highestpassed2=' ',joined2=' ',left2=' ',schoolname3=' ',highestpassed3=' ',joined3=' ',left3=' ',schoolname4=' ',highestpassed4=' ',joined4=' ',left4=' ',sportsactivities=' ',companyname1=' ',cphone1=' ',cdate1=' ',cjobtitle1=' ',cduties1=' ',csalary1=' ',reason1=' ',companyname2=' ',cphone2=' ',cdate2=' ',cjobtitle2=' ',cduties2=' ',csalary2=' ',reason2=' ',companyname3=' ',cphone3=' ',cdate3=' ',cjobtitle3=' ',cduties3=' ',csalary3=' ',reason3=' ',companyname4=' ',cphone4=' ',cdate4=' ',cjobtitle4=' ',cduties4=' ',csalary4=' ',reason4=' ',illness=' ',drugs=' ',smoke=' ',smokeno=' ',glasses=' ',vision=' ',shift=' ',perganant=' ',transport=' ',carbike=' ',dismissed=' ',court=' ',beforeapplied=' ',relatives=' ',friendname=' ',frienddepartment=' ',introduce=' ',vacancies=' ',crossname=' ',crossposition=' ',crosscompany=' ',crossphone=' ',crossaddress=' ',crossname1=' ',crossposition1=' ',crosscompany1=' ',crossphone1=' ',crossaddress1=' ',signature=' ',illnessdesc=' ',dismisseddesc=' ',courtdesc=' ',shirt=' ',trouser=' ',shoe=' '  where applicationno='" & (applno.Text) & "'"
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
        End If
        If IsPostBack = False And Session("first") <> "" Then
            'MsgBox(Session("first"))
            applno.Text = Session("applno")
            datetoday.Text = Date.Now.ToShortDateString
            sqltext = ""
            sqltxt = "select*from jobapplication_temp where applicationno='" & (applno.Text) & "'"
            cmd = New SqlCommand(sqltxt, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                ddldesig.Text = rdr("positionapplied")
                name.Text = rdr("name")
                address.Text = rdr("address")
                icold.Text = rdr("icold")
                icnew.Text = rdr("icnew")
                iccolor.SelectedValue = rdr("iccolour")
                sex.SelectedValue = rdr("sex")
                mobile.Text = rdr("handphone")
                phone.Text = rdr("phone")
                blood.Text = rdr("bloodgroup")
                nationality.Text = rdr("nationality")
                epf.Text = rdr("epfno")
                socso.Text = rdr("socsono")
                tax.Text = rdr("taxno")
                dob.Text = rdr("dob")
                age.Text = rdr("age")
                lang.Text = rdr("languagespoken")
                race.Text = rdr("race")
                religion.Text = rdr("religion")
                country.Text = rdr("country")
                marital.Text = rdr("maritalstatus")
                relationship.Text = rdr("relationship")
                rname.Text = rdr("parentsname")
                ricold.Text = rdr("parentsicold")
                ricnew.Text = rdr("parentsicnew")
                rage.Text = rdr("parentsage")
                rcompany.Text = rdr("company")
                roccupation.Text = rdr("occupation")
                rphone.Text = rdr("parentsphone")
                hubwife.Text = rdr("husbandname")
                hubwifeage.Text = rdr("husbandage")
                hubicold.Text = rdr("husbandicold")
                hubicnew.Text = rdr("husbandicnew")
                child1.Text = rdr("cname1")
                cage1.Text = rdr("cage1")
                child2.Text = rdr("cname2")
                cage2.Text = rdr("cage2")
                child3.Text = rdr("cname3")
                cage3.Text = rdr("cage3")
                child4.Text = rdr("cname4")
                cage4.Text = rdr("cage4")
                child5.Text = rdr("cname5")
                cage5.Text = rdr("cage5")
            End While
            rdr.Close()
        End If
    End Sub
    Protected Sub savenext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savenext.Click
        If Trim(address.Text) = "" Then
            address.Focus()
            MessageBox("Address is must")
            Exit Sub
        End If
        If Trim(mobile.Text) = "" Or IsNumeric(mobile.Text) = False Then
            mobile.Text = ""
            mobile.Focus()
            MessageBox("Enter Number only")
            Exit Sub
        End If
        If Trim(rname.Text) = "" Then
            rname.Focus()
            MessageBox("Enter Relation Name")
            Exit Sub
        End If
        If Trim(marital.SelectedItem.Text) = "Married" Or Trim(marital.SelectedItem.Text) = "Divorced" Then
            If Trim(hubwife.Text) = "" Then
                If Trim(sex.Text) = "Female" Then
                    hubwife.Focus()
                    MessageBox("Enter Husband name")
                    Exit Sub
                Else
                    hubwife.Focus()
                    MessageBox("Enter Wife name")
                    Exit Sub
                End If
            End If
        End If
        If Trim(hubwife.Text) <> "" And Trim(hubwifeage.Text) = "" Then
            If Trim(sex.Text) = "Female" Then
                hubwifeage.Focus()
                MessageBox("Enter Husband Age")
                Exit Sub
            Else
                hubwifeage.Focus()
                MessageBox("Enter Wife Age")
                Exit Sub
            End If
        End If
        Dim un As String = "IT"
        Session("applno") = applno.Text
        sqltext = "update jobapplication_temp set username='" & un & "',positionapplied='" & (ddldesig.Text) & "',name='" & (name.Text) & "',address='" & (address.Text) & "',icold='" & (icold.Text) & "',icnew='" & (icnew.Text) & "',iccolour='" & (iccolor.Text) & "',sex='" & (sex.Text) & "',handphone='" & (mobile.Text) & "',phone='" & (phone.Text) & "',bloodgroup='" & (blood.Text) & "',nationality='" & (nationality.Text) & "',epfno='" & (epf.Text) & "',socsono='" & (socso.Text) & "',taxno='" & (tax.Text) & "',dob='" & (dob.Text) & "',age='" & (age.Text) & "',languagespoken='" & (lang.Text) & "',race='" & (race.Text) & "',religion='" & (religion.Text) & "',country='" & (country.Text) & "',maritalstatus='" & (marital.Text) & "',relationship='" & (relationship.Text) & "',parentsname='" & (rname.Text) & "',parentsicold='" & (ricold.Text) & "',parentsicnew='" & (ricnew.Text) & "',parentsage='" & (rage.Text) & "',company='" & (rcompany.Text) & "',occupation='" & (roccupation.Text) & "',parentsphone='" & (rphone.Text) & "',husbandname='" & (hubwife.Text) & "',husbandage='" & (hubwifeage.Text) & "',husbandicold='" & (hubicold.Text) & "',husbandicnew='" & (hubicnew.Text) & "',cname1='" & (child1.Text) & "',cage1='" & (cage1.Text) & "',cname2='" & (child2.Text) & "',cage2='" & (cage2.Text) & "',cname3='" & (child3.Text) & "',cage3='" & (cage3.Text) & "',cname4='" & (child4.Text) & "',cage4='" & (cage4.Text) & "',cname5='" & (child5.Text) & "',cage5='" & (cage5.Text) & "' where applicationno='" & (applno.Text) & "'"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        Session("reload") = "rl"
        'sqltext = "update jobapplication_temp set schoolname1=' ',highestpassed1=' ',joined1=' ',left1=' ',schoolname2=' ',highestpassed2=' ',joined2=' ',left2=' ',schoolname3=' ',highestpassed3=' ',joined3=' ',left3=' ',schoolname4=' ',highestpassed4=' ',joined4=' ',left4=' ',sportsactivities=' ',companyname1=' ',cphone1=' ',cdate1=' ',cjobtitle1=' ',cduties1=' ',csalary1=' ',reason1=' ',companyname2=' ',cphone2=' ',cdate2=' ',cjobtitle2=' ',cduties2=' ',csalary2=' ',reason2=' ',companyname3=' ',cphone3=' ',cdate3=' ',cjobtitle3=' ',cduties3=' ',csalary3=' ',reason3=' ',companyname4=' ',cphone4=' ',cdate4=' ',cjobtitle4=' ',cduties4=' ',csalary4=' ',reason4=' ',illness=' ',drugs=' ',smoke=' ',smokeno=' ',glasses=' ',vision=' ',shift=' ',perganant=' ',transport=' ',carbike=' ',dismissed=' ',court=' ',beforeapplied=' ',relatives=' ',friendname=' ',frienddepartment=' ',introduce=' ',vacancies=' ',crossname=' ',crossposition=' ',crosscompany=' ',crossphone=' ',crossaddress=' ',crossname1=' ',crossposition1=' ',crosscompany1=' ',crossphone1=' ',crossaddress1=' ',signature=' ',illnessdesc=' ',dismisseddesc=' ',courtdesc=' ',shirt=' ',trouser=' ',shoe=' '  where applicationno='" & (applno.Text) & "'"
        Server.Transfer("jobapplication2.aspx")
    End Sub
    Protected Sub marital_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marital.SelectedIndexChanged
        If Trim(marital.SelectedItem.Text) = "Single" Then
            child1.Text = ""
            cage1.Text = ""
            child2.Text = ""
            cage2.Text = ""
            child3.Text = ""
            cage3.Text = ""
            child4.Text = ""
            cage4.Text = ""
            child5.Text = ""
            cage5.Text = ""
            child1.Visible = False
            cage1.Visible = False
            child2.Visible = False
            cage2.Visible = False
            child3.Visible = False
            cage3.Visible = False
            child4.Visible = False
            cage4.Visible = False
            child5.Visible = False
            cage5.Visible = False
        Else
            child1.Visible = True
            cage1.Visible = True
            child2.Visible = True
            cage2.Visible = True
            child3.Visible = True
            cage3.Visible = True
            child4.Visible = True
            cage4.Visible = True
            child5.Visible = True
            cage5.Visible = True
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class