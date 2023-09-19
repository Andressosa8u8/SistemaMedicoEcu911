<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperarContraseña.aspx.cs" Inherits="SistemaECU911.autentificacion.recuperarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>ECU 911</title>

    <link rel="stylesheet" href="../resources/vendors/iconfonts/font-awesome/css/all.min.css" />
    <link rel="stylesheet" href="../resources/vendors/css/vendor.bundle.base.css" />
    <link rel="stylesheet" href="../resources/vendors/css/vendor.bundle.addons.css" />
    <link rel="stylesheet" href="../resources/css/style.css" />

    <%--Enlaces Extras--%>
    <link rel="stylesheet" href="../../resources/vendors/font-awesome-pro-v6-6/css/all.min.css" />
    <link rel="stylesheet" href="../../resources/vendors/bootstrap-5.3.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../resources/css/Style_Prueba.css" />
    <link rel="stylesheet" href="../resources/css/style-andres.css" />
    <link rel="shortcut icon" href="http://www.urbanui.com/" />
</head>
<body>
    <div class="container-scroller">
        <div class="container-fluid page-body-wrapper full-page-wrapper">
            <div class="content-wrapper d-flex align-items-stretch auth auth-img-bg">
                <div class="row flex-grow">
                    <div class="col-lg-6 d-flex align-items-center justify-content-center">
                        <div class="auth-form-transparent text-left p-3">
                            <div class="brand-logo">
                                <img src="../resources/images/LogoECU.png" style="width:100%; height:100px" alt="logo" />
                            </div>
                            <div class="login-title">
                                <h2 class="text-black">Has olvidado tu contraseña</h2>
                            </div>
                            <form class="pt-3" runat="server">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <h6>Ingrese su correo electrónico para restablecer su contraseña</h6>
                                            <div class="input-group">
                                                <div class="input-group-prepend bg-transparent">
                                                    <span class="input-group-text bg-transparent border-right-0">
                                                        <i class="fa-solid fa-envelope"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="txt_email" autocomplete="off" TextMode="Email" class="form-control form-control-lg border-left-0" placeholder="Correo Electrónico" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row align-items-center">
                                            <div class="col-5">
                                                <div class="input-group mb-0">
                                                    <asp:Button ID="btn_enviar" style="background-color: lightskyblue; border: none"  class="btn text-black btn-block btn-primary btn-lg font-weight-medium auth-form-btn" type="submit" runat="server" Text="ENVIAR" OnClick="btn_enviar_Click" />
                                                </div>
                                            </div>
                                            <div class="col-2">
                                                <div class="font-16 weight-600 text-center" data-color="#707373">O</div>
                                            </div>
                                            <div class="col-5">
                                                <div class="input-group mb-0">
                                                    <a class="btn btn-outline-primary btn-lg btn-block" href="../index.aspx">ACCESO</a>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </form>
                        </div>
                    </div>
                    <div class="col-lg-6 login-half-bg d-flex flex-row" style="background-image:url('../resources/images/auth/img2.jpg'); background-size: cover">
                        <p class="text-black font-weight-medium text-center flex-grow align-self-end">Copyright &copy; 2021  Todos los derechos reservados.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../resources/vendors/js/vendor.bundle.base.js"></script>
    <script src="../resources/vendors/js/vendor.bundle.addons.js"></script>
    <script src="../resources/js/off-canvas.js"></script>
    <script src="../resources/js/hoverable-collapse.js"></script>
    <script src="../resources/js/misc.js"></script>
    <script src="../resources/js/settings.js"></script>
    <script src="../resources/js/todolist.js"></script>
</body>
</html>
