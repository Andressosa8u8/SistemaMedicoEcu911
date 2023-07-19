<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Control_Usuarios.aspx.cs" Inherits="SistemaECU911.views.Administrador.Control_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Control de Usuarios | Administrador Sistema Médico 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="col-12 grid-margin">
        <div class="card">
            <div class="card-body">
                <h4 class="card-title">
                    <%--<i class="fas fa-envelope"></i>--%>
                    <i class="fa-solid fa-hospital-user"></i>
                    PACIENTES
                </h4>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card" style="width: auto;">
                            <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                                <div class="container">
                                    <div class="row justify-content-center">
                                        <div class="col-auto">

                                            <asp:GridView ID="grvPacientes" OnRowCommand="grvPacientes_RowCommand" AutoGenerateColumns="false" Width="100%" CssClass="table table-hover text-center table-responsive" GridLines="None" runat="server" Style="margin-right: 0px" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="CEDULA">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Per_cedula" runat="server" Text='<%#Eval("Per_cedula")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PRIMER NOMBRE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Per_priNombre" runat="server" Text='<%#Eval("Per_priNombre")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SEGUNDO NOMBRE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Per_segNombre" runat="server" Text='<%#Eval("Per_segNombre")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PRIMER APELLIDO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Per_priApellido" runat="server" Text='<%#Eval("Per_priApellido")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SEGUNDO APELLIDO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Per_segApellido" runat="server" Text='<%#Eval("Per_segApellido")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GÉNERO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Per_genero" runat="server" Text='<%#Eval("Per_genero")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="17" HeaderStyle-Width="17" HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnbEditar" Width="16" Height="16" CommandArgument='<%#Eval("Per_id")%>' CommandName="Editar" runat="server"><i class="fas fa-pen"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="17px" />
                                                        <ItemStyle Width="17px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
