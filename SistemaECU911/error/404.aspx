<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="SistemaECU911.error._404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <title>Error 404</title>
    <link rel="icon" type="image/png" href="../resources/images/ECU911.png" />
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../resources/vendors/css/core.css" />
    <link rel="stylesheet" type="text/css" href="../resources/vendors/css/icon-font.min.css" />
    <link rel="stylesheet" type="text/css" href="../resources/vendors/css/style.css" />
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-119386393-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-119386393-1');
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="error-page d-flex align-items-center flex-wrap justify-content-center pd-20">
            <div class="pd-10">
                <div class="error-page-wrap text-center">
                    <h1>400</h1>
                    <h3>Error: 404 ¡PÁGINA NO ENCONTRADA!</h3>
                    <p>Parece que estás tratando de encontrar el inicio de sesion</p>
                    <div class="pt-20 mx-auto max-width-200">
                        <asp:LinkButton ID="lbl404" CssClass="btn btn-primary btn-block btn-lg" OnClick="lbl404_Click" runat="server">Volver al Inicio</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../resources/vendors/js/core.js"></script>
    <script src="../resources/vendors/js/script.min.js"></script>
    <script src="../resources/vendors/js/process.js"></script>
    <script src="../resources/vendors/js/layout-settings.js"></script>
</body>
</html>