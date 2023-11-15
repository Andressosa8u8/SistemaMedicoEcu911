<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SistemaECU911.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>ECU 911</title>
    <link rel="icon" type="image/png" href="resources/images/ECU911.png" />
    <link rel="stylesheet" href="resources/vendors/iconfonts/font-awesome/css/all.min.css" />
    <link rel="stylesheet" href="resources/vendors/iconfonts/font-awesome-6.1.1/css/all.min.css" />
    <link rel="stylesheet" href="resources/vendors/css/vendor.bundle.base.css" />   
    <link rel="stylesheet" href="resources/vendors/css/vendor.bundle.addons.css" />
    <link rel="stylesheet" href="resources/css/style.css" />
    <link rel="stylesheet" href="resources/css/Style_Prueba.css" />
    <link rel="stylesheet" href="resources/css/style-andres.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
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
                                <img src="resources/images/LogoECU.png" style="width: 100%; height: 100px" />
                            </div>
                            <h3>Bienvenido al Sistema!</h3>
                            <h6 class="font-weight-light">Un gusto verte de nuevo!</h6>
                            <form class="pt-3" runat="server">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <asp:Label ID="lbl_user" for="exampleInputEmail" runat="server" Text="Usuario"></asp:Label>
                                            <div class="input-group">
                                                <div class="input-group-prepend bg-transparent">
                                                    <span class="input-group-text bg-transparent border-right-0">
                                                        <i class="fa fa-user text-secondary"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="txt_user" type="text" class="form-control form-control-lg border-left-0" placeholder="Nombre de usuario" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="form-group">
                                            <asp:Label ID="lbl_pass" for="exampleInputPassword" runat="server" Text="Contraseña"></asp:Label>
                                            <div class="input-group">
                                                <div class="input-group-prepend bg-transparent">
                                                    <span class="input-group-text bg-transparent border-right-0">
                                                        <i class="fa fa-lock text-secondary"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="txt_pass" type="password" class="form-control form-control-lg border-left-0" placeholder="Contraseña" runat="server"></asp:TextBox>
                                            </div>
                                        </div>--%>


                                        <div class="form-group">
                                            <asp:Label ID="lbl_pass" for="exampleInputPassword" runat="server" Text="Contraseña"></asp:Label>
                                            <div class="input-group">
                                                <div class="input-group-prepend bg-transparent">
                                                    <span class="input-group-text bg-transparent border-right-0">
                                                        <i class="fa fa-lock text-secondary"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="txt_pass" type="password" class="form-control form-control-lg border-left-0" placeholder="Contraseña" runat="server"></asp:TextBox>
                                                <div class="input-group-append" style="cursor: pointer;" onclick="mostrarOcultarContraseña()">
                                                    <span class="input-group-text bg-transparent border-left-0">
                                                        <i class="fa fa-eye text-secondary" id="eyeIcon"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="my-2 d-flex justify-content-between align-items-center">
                                            <a href="autentificacion/recuperarContraseña.aspx" class="auth-link text-black">Olvidaste tu contraseña?</a>
                                        </div>
                                        <div class="my-3">
                                            <asp:Button ID="btn_ingresar" Style="background-color: lightskyblue" class="btn btn-block btn-lg font-weight-medium auth-form-btn" type="submit" runat="server" Text="INGRESAR" OnClick="btn_ingresar_Click" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </form>
                        </div>
                    </div>
                    <div class="col-lg-6 login-half-bg d-flex flex-row" style="background-image: url('resources/images/auth/img2.jpg'); background-size: cover">
                        <p class="text-black font-weight-medium text-center flex-grow align-self-end">Copyright &copy; 2023  Todos los derechos reservados.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="resources/vendors/js/vendor.bundle.base.js"></script>
    <script src="resources/vendors/js/vendor.bundle.addons.js"></script>
    <script src="resources/js/off-canvas.js"></script>
    <script src="resources/js/hoverable-collapse.js"></script>
    <script src="resources/js/misc.js"></script>
    <script src="resources/js/settings.js"></script>
    <script src="resources/js/todolist.js"></script>

    <script type="text/javascript">
        var contraseñaVisible = false;

        function mostrarOcultarContraseña() {
            var txtPass = document.getElementById('<%= txt_pass.ClientID %>');
            var eyeIcon = document.getElementById('eyeIcon');

            if (contraseñaVisible) {
                txtPass.type = 'password'; // Ocultar la contraseña
                eyeIcon.classList.remove('fa-eye-slash');
                eyeIcon.classList.add('fa-eye');
            } else {
                txtPass.type = 'text'; // Mostrar la contraseña
                eyeIcon.classList.remove('fa-eye');
                eyeIcon.classList.add('fa-eye-slash');
            }

            contraseñaVisible = !contraseñaVisible;
        }
    </script>

</body>
</html>
