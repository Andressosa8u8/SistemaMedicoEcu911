<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Views_Pacientes/PrincipalPaciente.Master" AutoEventWireup="true" CodeBehind="CambioContraseña.aspx.cs" Inherits="SistemaECU911.Template.Views_Pacientes.CambioContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Cambio de Constraseña | Sistema Medico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="2000"></asp:Timer>
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
                                    <img src="../Template Principal/images/ChangePassword.png" style="width: 400px; height:400px" alt="Cambio de Contraseña" />
                                </div>
                                <div class="col-md-6" style="padding: 30px">
                                    <h3 class="text-center cm-strong">RESTABLECER LA CONTASEÑA</h3>
                                    <br />
                                    <div class="row">
                                        <label for="txt_passAntigua" class="col-form-label">Contraseña Anterior</label>
                                        <asp:TextBox CssClass="form-control form-control-lg" ID="txt_passAntigua" TextMode="Password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txt_passAntigua" ValidationGroup="info" ErrorMessage="La contraseña anterior es requerida"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row">
                                        <label for="txt_passNueva" class="col-form-label">Contraseña Anterior</label>
                                        <asp:TextBox CssClass="form-control form-control-lg" ID="txt_passNueva" TextMode="Password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="txt_passNueva" ValidationGroup="info" ErrorMessage="La nueva contraseña es requerida"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row">
                                        <label for="txt_passNueva2" class="col-form-label">Contraseña Anterior</label>
                                        <asp:TextBox CssClass="form-control form-control-lg" ID="txt_passNueva2" TextMode="Password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ControlToValidate="txt_passNueva2" ValidationGroup="info" ErrorMessage="Confirmar la contraseña es requerida"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <div class="row align-items-center">
                                        <center>
                                            <div class="col-md-5">
                                                <div class="mb-0 text-center">
                                                    <asp:Button ID="btn_cambiar" OnClick="btn_cambiar_Click" CssClass="btn btn-primary btn-lg btn-block" ValidationGroup="info" runat="server" Text="Cambiar" />
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
