<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="PruebaEncabezado.aspx.cs" Inherits="SistemaECU911.views.Administrador_Medico.PurebaEncabezado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fabric.js/4.4.0/fabric.min.js"></script>
    <!-- Agrega el enlace al archivo CSS de Croppie desde el CDN -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/croppie/2.6.5/croppie.min.css" />

    <!-- Agrega el enlace al archivo JavaScript de Croppie desde el CDN -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/croppie/2.6.5/croppie.min.js"></script>

    <link href="./pintura.css" rel="stylesheet" type="text/css" />


    <style type="text/css">
        canvas {
            border: 4px solid #063456
        }

        .my-editor {
            height: 600px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    SELECCIONE UN NUEVO ENCABEZADO

    <br />
    <br />


    <contenttemplate>

        <asp:FileUpload ID="FileUpload1" runat="server" accept=".pdf, .jpg, .jpeg, .png" onchange="showPreviewImage()" />
        <asp:Button ID="btn_descargarImagen" runat="server" Text="Descargar Imagen" OnClientClick="downloadImage(); return false;" />


        <br />
        <br />

        <asp:Image ID="UploadedImageView" runat="server" Style="max-width: 400px;" />

        <br />
        <br />

        PUEDE EDITAR EL ENCABEZADO EN ESTE APARTADO

         <canvas id="canvas" width="1000" height="400"></canvas>

        <br />
        <br />


    <!-- Show image edit result here -->

        <br />
        <br />

        <asp:Button ID="btn_eliminarImagen" runat="server" Text="Eliminar Imagen" OnClientClick="deleteActiveObject(); return false;" />


        <br />
        <br />

        <asp:Button ID="Button1" runat="server" Text="Guardar Encabezado" OnClick="Button1_Click" />



    </contenttemplate>


</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
    <script type="text/javascript">
        var canvas = new fabric.Canvas('canvas');

        function showPreviewImage() {
            var fileInput = document.getElementById('<%= FileUpload1.ClientID %>');

            if (fileInput.files && fileInput.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = new Image();
                    img.onload = function () {
                        var fabricImage = new fabric.Image(img);
                        canvas.add(fabricImage);
                        canvas.renderAll();
                    }
                    img.src = e.target.result;
                };
                reader.readAsDataURL(fileInput.files[0]);
            }
        }

        function updatePreviewImage(fabricImage) {
            // Convertir la imagen de fabric.js a formato de datos URL
            var imageUrl = fabricImage.toDataURL();

            // Actualizar la propiedad ImageUrl del control de imagen de ASP.NET
            document.getElementById('<%= UploadedImageView.ClientID %>').src = imageUrl;
        }

        function clearCanvas() {
            canvas.clear();
        }

        function downloadImage() {
            const dataURL = canvas.toDataURL("image/png");
            const a = document.createElement("a");
            a.download = "ImagenEncabezado.png";
            a.href = dataURL;
            a.click();
        }

        function deleteActiveObject() {
            var activeObject = canvas.getActiveObject();

            if (activeObject) {
                canvas.remove(activeObject);
                canvas.renderAll();
            }
        }


    </script>

    <script>
        import { appendDefaultEditor } from './pintura.js';

        const editor = appendDefaultEditor('.my-editor', {
            src: 'my-image.jpeg',
        });

        editor.on('process', ({ dest }) => {
            const image = document.querySelector('img');
            image.setAttribute('src', URL.createObjectURL(dest));
        });
    </script>
</asp:Content>

