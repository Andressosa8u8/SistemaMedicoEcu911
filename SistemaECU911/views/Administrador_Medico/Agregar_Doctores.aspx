<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="Agregar_Doctores.aspx.cs" Inherits="SistemaECU911.views.Administrador_Medico.Agregar_Doctores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Agregar Doctor | Sistema Médico
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
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <label class="form-label">CEDULA</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_cedula" Style="width: 100%; background-color: transparent; text-transform: uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="txt_cedula" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-9">
                        <label class="form-label">NOMBRE COMPLETO</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_Nombre" Style="width: 100%; background-color: transparent; text-transform: uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="txt_Nombre" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-5">
                        <label class="form-label">ESPECIALIDAD</label>
                        <asp:DropDownList ID="ddl_especialidad" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_especialidad" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div class="col-md-2">
                        <label class="form-label">ESTADO</label>
                        <asp:DropDownList ID="ddl_estado" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="0" Text="SELECCIONE ......"></asp:ListItem>
                            <asp:ListItem Value="A" Text="ACTIVO"></asp:ListItem>
                            <asp:ListItem Value="I" Text="INACTIVO"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" ForeColor="Red" ControlToValidate="ddl_estado" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="col-12" style="text-align: center">
                        <asp:Button CssClass="btn btn-warning" ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="Guardar" UseSubmitBehavior="False" ValidationGroup="GroupValidation" />
                        <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" Text="Cancelar" UseSubmitBehavior="False" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
