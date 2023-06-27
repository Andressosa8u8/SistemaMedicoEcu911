<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Views/Principal.Master" AutoEventWireup="true" CodeBehind="ImagenTest.aspx.cs" Inherits="SistemaECU911.Template.Views.ImagenTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8">
                    <label style="font-size: 13px">CEDULA</label>
                    <asp:TextBox CssClass="required form-control" ID="txt_cedula" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="txt_cedula" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                </div>
                //cambbio
                <div class="col-md-4">
                    <label class="form-label">ESTADO</label>
                    <asp:DropDownList ID="ddl_estado" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server">
                        <asp:ListItem Value="0" Text="SELECCIONE ......"></asp:ListItem>
                        <asp:ListItem Value="A" Text="ACTIVO"></asp:ListItem>
                        <asp:ListItem Value="I" Text="INACTIVO"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_estado" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <asp:FileUpload ID="fuImagen" onchange="MostrarImagen(this);" runat="server" />
            </div>
            <div class="row">
                <asp:Image ID="Image1" Width="150" Height="150" ImageUrl="~/Template/Template Principal/images/Foto_Perfil.png" runat="server" />
            </div>
            <div class="row">
                <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-light" BorderColor="#1B4F72" runat="server" Text="Guardar" ValidationGroup="GroupValidation" UseSubmitBehavior="False" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function MostrarImagen(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
