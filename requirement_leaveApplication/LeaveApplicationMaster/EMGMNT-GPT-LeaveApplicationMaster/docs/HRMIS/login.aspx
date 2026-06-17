<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="E_Management.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


    <head>
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <link rel="icon" href="~/images/icons/favicon.png"/>
        <title>Maruwa Malaysia Sdn Bhd</title>


        <!-- Bootstrap core CSS -->
       <%-- <link href="~Css/bootstrap.min.css" rel="stylesheet"/>--%>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Custom styles for this template -->
        <link href="../Css/style.css" rel="stylesheet"/>
        <link href="../fonts/antonio-exotic/stylesheet.css" rel="stylesheet"/>
        <link rel="stylesheet" href="../Css/lightbox.min.css"/>
        <link href="../Css/responsive.css" rel="stylesheet"/>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../js/lightbox-plus-jquery.min.js" type="text/javascript"></script>
        <script src="../js/instafeed.min.js" type="text/javascript"></script>
        <script src="../js/custom.js" type="text/javascript"></script>
        <script>
        
       $(function () {
    // when the modal is closed
    $('#modal-container').on('hidden.bs.modal', function () {
        // remove the bs.modal data attribute from it
        $(this).removeData('bs.modal');
        // and empty the modal-content element
        $('#modal-container .modal-content').empty();
    });
});
        </script>
         <script type="text/javascript">      
    function openModal() {
   
     $("#btnShowPopup").click();
    }
    
   
</script>
<script type="text/javascript">
  function fun1() {
   debugger();
     $("#LinkButton1").click();
    }
</script>
        
  
    </head>
    <body>
     <form id="form2" runat="server">
        <div id="page">
        
          
            <header class="header-container">
                <div class="container">
                    <div class="top-row">
                        <div class="row">
                            <div class="col-md-2 col-sm-6 col-xs-6">
                                <div id="logo">
                                    <!--<a href="home.html"><img src="images/logo.png" alt="logo"></a>-->

                                    <a href="Default.aspx"> <img alt="image" class="img-responsive" src="../images/icons/logo.jpg"/></a>
                                </div>                       
                            </div>
                            <div class="col-sm-6 visible-sm">
                                <div class="text-right"><button type="button" class="book-now-btn1" id="Button2" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Login</button></div>
                            </div>
                            <div class="col-md-8 col-sm-12 col-xs-12 remove-padd">
                                <nav class="navbar navbar-default">
                                    <div class="navbar-header page-scroll">
                                        <button data-target=".navbar-ex1-collapse" data-toggle="collapse" class="navbar-toggle" type="button">
                                            <span class="sr-only">Toggle navigation</span>
                                            <span class="icon-bar"></span>
                                            <span class="icon-bar"></span>
                                            <span class="icon-bar"></span>
                                        </button>

                                    </div>
                                    <div class="collapse navigation navbar-collapse navbar-ex1-collapse remove-space">
                                        <ul class="list-unstyled nav1 cl-effect-10">
                                           <%-- <li><a  data-hover="Home" class="active"><span>Home</span></a></li>
                                            <li><a data-hover="About"  href="#"><span>About</span></a></li>--%>
                                          
                                            <li><a id="A1" data-hover="Leave Application" runat="server" onserverclick="LinkButton1_Click"  ><span>Leave Application</span></a></li>
                                            <li><a id="A2" data-hover="Gate Pass"  runat="server" onserverclick="LinkButton2_Click" ><span>Gate Pass</span></a></li>
                                            <li><a id="A3" data-hover="Clinic Pass" runat="server" onserverclick="LinkButton3_Click" ><span>Clinic Pass</span></a></li>
                                            <li><a id="A4" data-hover="EMP Handbook" target="new" runat="server"  href="http://mmsbsql1/form/it/safety/MM-IN-A-9001-P01-03 R0 Employee Handbook.mht" ><span>EMP Handbook</span></a></li>
                                        </ul>

                                    </div>
                                </nav>
                            </div>
                            <div class="col-md-2  col-sm-4 col-xs-12 hidden-sm">
                                <%--<a href="mhtml:http://mmsbsql1/form/it/safety/Employee_Handbook.mht!employee_handbook_files/frame.htm">--%><div class="text-right"><button type="button" class="book-now-btn1" id="btnShowPopup" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Login</button></div>
                               
                              <%-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Login</button>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </header>


            <!--end-->
            <div id="myCarousel1" class="carousel slide" data-ride="carousel"> 
                <!-- Indicators -->

                <ol class="carousel-indicators">
                    <li data-target="#myCarousel1" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel1" data-slide-to="1"></li>
                    <li data-target="#myCarousel1" data-slide-to="2"></li>
                    <li data-target="#myCarousel1" data-slide-to="3"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="item active"> <img src="../images/banner.png" style="width:100%; height: 280px" alt="First slide">
                        <div class="carousel-caption">
                            <h1>SUBSTRATE<br></h1>
                        </div>
                    </div>
                    <div class="item"> <img src="../images/banner2.png" style="width:100%; height: 280px" alt="Second slide">
                        <div class="carousel-caption">
                            <h1>TPH</h1>
                        </div>
                    </div>
                    <div class="item"> <img src="../images/banner3.png" style="width:100%; height: 280px" alt="Third slide">
                        <div class="carousel-caption">
                            <h1>CERAMIC VALVE</h1>
                        </div>
                    </div>
                    <div class="item"> <img src="../images/banner3.png" style="width:100%; height: 280px" alt="Third slide">
                        <div class="carousel-caption">
                            <h1>FERRITE MAGNET</h1>
                        </div>
                    </div>

                </div>
                <a class="left carousel-control" href="#myCarousel1" data-slide="prev"> <img src="../images/icons/left-arrow.png" onmouseover="this.src = '../images/icons/left-arrow-hover.png'" onmouseout="this.src = '../images/icons/left-arrow.png'" alt="left"/></a>
                <a class="right carousel-control" href="#myCarousel1" data-slide="next"><img src="../images/icons/right-arrow.png" onmouseover="this.src = '../images/icons/right-arrow-hover.png'" onmouseout="this.src = '../images/icons/right-arrow.png'" alt="left"/></a>

            </div>
            <div class="clearfix"></div>

            <!--service block--->
            <section class="service-block">
                <div class="container">
                    <div class="row">
                        <div class="col-md-3 col-sm-3 col-xs-6 width-50">
                            <div class="service-details text-center">
                                <div class="service-image">
                                   <a runat=server  onserverclick="LinkButton1_Click"><img alt="image" class="img-responsive" src="../images/icons/leave.png"/></a>
                                </div>
                                <br />
                                  <br />  <br />
                                  <br />
                                <a></a><asp:LinkButton ID="LinkButton1" runat="server"  style="font-size:x-large" CausesValidation="False" >Leave Application</asp:LinkButton>
                               <%-- <h4><a target="Onewin" href="http://mmsbsql1/emgmt/hrmis/login.aspx">Leave Application</a></h4>--%>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-6 width-50">
                            <div class="service-details text-center">
                                <div class="service-image">
                                    <a runat=server  onserverclick="LinkButton2_Click"><img alt="image" class="img-responsive" src="../images/icons/gatepass.png"/></a>
                                </div>
                                 <br />
                                  <br />  <br />
                                  <br />
                                <a></a><asp:LinkButton ID="LinkButton2" runat="server"  style="font-size:x-large" CausesValidation="False" >Gate Pass</asp:LinkButton>
                             
                              <%--  <h4><a target="Onewin" href="http://mmsbsql1/emgmt/hrmis/login.aspx">Gate Pass</a></h4>--%>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-6 mt-25">
                            <div class="service-details text-center">
                                <div class="service-image">
                                   <a runat=server  onserverclick="LinkButton3_Click"><img alt="image" class="img-responsive" src="../images/icons/clinic.png"/></a>
                                </div>
                                  <br />
                                  <br />  <br />
                                  <br />
                                <a></a><asp:LinkButton ID="LinkButton3" runat="server"  style="font-size:x-large" CausesValidation="False" >Clinic Pass</asp:LinkButton>
                             
                                <%--<h4><a target="Onewin" href="http://mmsbsql1/emgmt/hrmis/login.aspx">Clinic Pass</a></h4>--%>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-6 mt-25">
                            <div class="service-details text-center">
                                <div class="service-image">
                                   <a href="http://mmsbsql1/form/it/safety/MM-IN-A-9001-P01-03 R0 Employee Handbook.mht" target="new"><img alt="image" class="img-responsive" src="../images/icons/emhb.png"/></a>
                                </div>
                                 <br />
                                  <br />  <br />
                                  <br />
                                <asp:LinkButton ID="LinkButton4" runat="server" target="new" href="http://mmsbsql1/form/it/safety/MM-IN-A-9001-P01-03 R0 Employee Handbook.mht" style="font-size:x-large" CausesValidation="False" >Emp Handbook(Eng)</asp:LinkButton>
                             
                               <%-- <h4><a target="Onewin" href="mhtml:http://mmsbsql1/form/it/safety/Employee_Handbook.mht!employee_handbook_files/frame.htm">Employee Manual</a></h4>--%>
                            </div>
                        </div>
                    </div>
                </div>
				
            </section>

          
            
            <!-----blog slider----->
            <!--blog trainer block-->
            <section class="blog-block-slider">
                <div class="blog-block-slider-fix-image">
                    <div id="myCarousel2" class="carousel slide" data-ride="carousel">
                        <div class="container">
                            <!-- Wrapper for slides -->
                            <ol class="carousel-indicators">
                                <li data-target="#myCarousel2" data-slide-to="0" class="active"></li>
                                <li data-target="#myCarousel2" data-slide-to="1"></li>
                                <li data-target="#myCarousel2" data-slide-to="2"></li>
                            </ol>
                            <div class="carousel-inner" role="listbox">
                                <div class="item active">
                                    <div class="blog-box">
                                        <p>We exist in this business to provide value to our customers to make their business success via excellent service and high quality.</p>
                                    </div>
                                    <div class="blog-view-box">
                                        <div class="media">
                                            <div class="media-left">
                                                <img src="../images/client1.png" class="media-object">
                                            </div>
                                            <div class="media-body">
                                                <h3 class="media-heading blog-title">Maruwa</h3>
                                                <h5 class="blog-rev">Vision</h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="blog-box">
                                        <p>On Time Delivery/ Keep Our Promise to Our Customers / High Quality / To build and maintain our trust.</p>
                                    </div>
                                    <div class="blog-view-box">
                                        <div class="media">
                                            <div class="media-left">
                                                <img src="../images/client2.png" class="media-object">
                                            </div>
                                            <div class="media-body">
                                                <h3 class="media-heading blog-title">Maruwa</h3>
                                                <h5 class="blog-rev">Mission</h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="blog-box">
                                        <p>Honesty, Integrity and Discipline in all aspects of our business •Respect and Concern for the Individual.</p>
                                    </div>
                                    <div class="blog-view-box">
                                        <div class="media">
                                            <div class="media-left">
                                                <img src="../images/client3.png" class="media-object">
                                            </div>
                                            <div class="media-body">
                                                <h3 class="media-heading blog-title">Maruwa</h3>
                                                <h5 class="blog-rev">Core Values</h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </section>
	
            <!---footer--->
            <footer>
                <div class="container">
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-xs-12 width-set-50">
                            <div class="footer-details">
                                <h4>Get in touch</h4>
                                <ul class="list-unstyled footer-contact-list">
                                    <li>
                                        <i class="fa fa-map-marker fa-lg"></i>
                                        <p>Lot 2,3,4,27,28,30 & 31, <br> Batu Berendam FTZ,</p>
										<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phase 3, Industrial Estate,,</p>
                                    </li>
                                    <li>
                                        <i class="fa fa-phone fa-lg"></i>
                                        <p><a href="tel:2883302"> 2883302</a></p>
                                    </li>
                                    <li>
                                        <i class="fa fa-envelope-o fa-lg"></i>
                                        <p><a href="mailto:hr@maruwa.com.my"> hr@maruwa.com.my</a></p>
                                    </li>
                                </ul>
                              
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6 col-xs-12 width-50 width-set-50">
                            <div class="footer-details">
                                <h4>explore</h4>
                                <ul class="list-unstyled footer-links">
                                    <li class="active"><a>Home</a></li>
                                   
                                    <li><a id="A5" runat="server" onserverclick="LinkButton1_Click" >Leave Application</a></li>
                                    <li><a id="A6" runat="server" onserverclick="LinkButton2_Click" >Gate Pass</a></li>
                                    <li><a id="A7" runat="server" onserverclick="LinkButton3_Click" >Clinic Pass</a></li>
                                  
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="footer-details">
                                <h4>Manuals</h4>
                                <div class="row">
                                    <ul class="list-unstyled footer-links">
                                    <li class="active"><a  href="http://mmsbsql1/form/it/safety/MM-IN-A-9001-P01-03 R0 Employee Handbook.mht" target ="new">Emp Handbook (English)</a></li>
                                    <li><a href="http://mmsbsql1/form/it/safety/Employee_Handbook_M.mht" target ="new">Employee Handbook (Malay)</a></li>
                                    <li><a href="http://mmsbsql1/form/it/safety/safety compliance hand book2018.2.mht" target ="new">Safety Handbook (English)</a></li>
                                    <li><a href="http://mmsbsql1/form/it/safety/buku panduan pematuhan keselamatan rev 4.mht" target ="new">Safety Handbook (Malay)</a></li>                                                                    
                                </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="copyright">
                        <!--Do not remove Backlink from footer of the template. To remove it you can purchase the Backlink !-->
                        &copy; 2018 All right reserved. Designed by <a href="http://www.maruwa.com.my/" target="new">Maruwa Malaysia Sdn Bhd</a>
                    </div>

                </div>
            </footer>
        &nbsp; &nbsp; &nbsp;
        <!--back to top--->
            <a style="display: none;" href="javascript:void(0);" class="scrollTop back-to-top" id="back-to-top">
                <span><i aria-hidden="true" class="fa fa-angle-up fa-lg"></i></span>
                <span>Top</span>
            </a>

        </div>
             
        
        
        
        
        
        
        
  <div class="modal fade" id="exampleModal" tabindex="-1" data-backdrop="static" data-keyboard="false"  role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">  <div class="modal-dialog modal-dialog-centered" role="document">    <div class="modal-content" style="width: 60%;">      <div class="modal-header text-center" >        <h4 class="modal-title w-100 font-weight-bold">Sign in</h4>       <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">          <span aria-hidden="true">&times;</span>        </button>--%>      </div>            <div class="modal-body mx-3">               <div class="md-form mb-5">            <label  class="col-form-label">UserID:</label>           <asp:TextBox  class="form-control" runat="server"  Text="" id="TxtUserId"></asp:TextBox>          </div>          <div class="md-form mb-5">            <label  class="col-form-label">Password:</label>            <asp:TextBox id="TxtPwd" TextMode="Password" Text=""   class="form-control" runat="server" ></asp:TextBox>          </div>                       <div class="md-form mb-5">           <asp:Label id="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>          </div>              </div>      <div class="modal-footer" >        <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">C</button>--%>        <asp:Button id="BtnLogin"  runat="server" OnClick="BtnLogin_Click"  class="book-now-btn1"   text="Login" ></asp:Button>        <asp:Button id="Button1" runat="server"  class="book-now-btn1" data-dismiss="modal"   text="Cancel" ></asp:Button>            </div>   
    </div>  </div></div>
        
     
        
       </form>  
        
    </body>
    
    
    
      


</html>
