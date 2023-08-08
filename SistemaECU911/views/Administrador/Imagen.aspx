<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Imagen.aspx.cs" Inherits="SistemaECU911.views.Administrador.Imagen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:Image ID="imgPreview" ImageUrl="~/resources/images/User.jpg" runat="server" Width="175" Height="200" />
    <br />
    <br />
    <asp:FileUpload ID="FileUploadProfilePic" runat="server" onchange="showPreviewImage()" />
    <br />
    <br />
    <asp:Button ID="btnUpload" runat="server" Text="Cargar Imagen" OnClick="btnUpload_Click" />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
    <script type="text/javascript">
        function showPreviewImage() {
            var fileInput = document.getElementById('<%= FileUploadProfilePic.ClientID %>');
            var previewImage = document.getElementById('<%= imgPreview.ClientID %>');

            if (fileInput.files && fileInput.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    previewImage.src = e.target.result;
                    previewImage.style.display = "block";
                };
                reader.readAsDataURL(fileInput.files[0]);
            } else {
                previewImage.style.display = "none";
            }
        }
    </script>
</asp:Content>

