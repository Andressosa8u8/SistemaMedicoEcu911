<%@ Page Title="" Language="C#" MasterPageFile="~/views/Socio_Economico/Socio_Economico.Master" AutoEventWireup="true" CodeBehind="Cambiar_Contraseña.aspx.cs" Inherits="SistemaECU911.Template.Views_Socio_Economico.Contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Cambio Contraseña | Sistema Médico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="padding: 20px; background-color: white; font-family: Arial">
                <div class="pd-20 card-box mb-30">
                    <div class="login-wrap d-flex align-items-center flex-wrap justify-content-center">
                        <div class="container">
                            <div class="row align-items-center">
                                <div class="col-md-6">
                                    <img src="../Template Principal/images/ChangePassword.png" style="width:400px; height:400px" alt="">                                    
                                </div>
                                <div class="col-md-6" style="padding: 30px">
                                    <h3 class="text-center cm-strong">RESTABLECER LA CONTRASEÑA</h3>
                                    <br />
                                    <h6>Ingrese su contraseña anterior, su nueva contraseña, confirme y actualice</h6>
                                    <br />
                                    <div class="row">
                                        <label for="txt_passAntigua" class="form-label">Contraseña anterior</label>
                                        <asp:TextBox class="form-control form-control-lg" ID="txt_passAntigua" TextMode="Password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txt_passAntigua" ValidationGroup="info" ErrorMessage="La contraseña anterior es requerida"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row">
                                        <label for="txt_passNueva" class="form-label">Nueva contraseña</label>
                                        <asp:TextBox class="form-control form-control-lg" ID="txt_passNueva" TextMode="Password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ControlToValidate="txt_passNueva" ValidationGroup="info" ErrorMessage="La nueva contraseña es requerida"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row">
                                        <label for="txt_passNueva2" class="form-label">Confirmar nueva contraseña</label>
                                        <asp:TextBox class="form-control form-control-lg" ID="txt_passNueva2" TextMode="Password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ControlToValidate="txt_passNueva2" ValidationGroup="info" ErrorMessage="Confirmar la contraseña es requerida"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <div class="row align-items-center">
                                        <center>
                                            <div class="col-md-5">
                                                <div class="mb-0 text-center">
                                                    <asp:Button ID="btn_cambiar" OnClick="btn_cambiar_Click" CssClass="btn btn-primary btn-lg btn-block" ValidationGroup="info" runat="server" Text="Cambiar" UseSubmitBehavior="False" />
                                                </div>
                                            </div>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
