<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Agregar_Especialidad.aspx.cs" Inherits="SistemaECU911.views.Administrador.Agregar_Especialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Agregar Especialidad | Sistema Médico
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
            <div class="container" style="background-color: white">
                <br />
                <div class="row">
                    <div class="col-md-3" style="text-align: center">
                        <label class="form-label">NOMBRE DE LA ESPECIALIDAD</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_especialidad" Style="width: 100%; background-color: transparent; text-transform: uppercase" AutoPostBack="true" OnTextChanged="txt_especialidad_TextChanged"></asp:TextBox>
                        <asp:Label ID="lbl_especialidad" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">ESTADO</label>
                        <asp:DropDownList ID="ddl_estado" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="0" Text="SELECCIONE ......"></asp:ListItem>
                            <asp:ListItem Value="A" Text="ACTIVO"></asp:ListItem>
                            <asp:ListItem Value="P" Text="PASIVO"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" ForeColor="Red" ControlToValidate="ddl_estado" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="col-12" style="text-align: center">
                    <asp:Button CssClass="btn btn-warning" ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="Guardar" UseSubmitBehavior="False" ValidationGroup="GroupValidation" />
                    <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" Text="Cancelar" UseSubmitBehavior="False" />
                </div>
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
