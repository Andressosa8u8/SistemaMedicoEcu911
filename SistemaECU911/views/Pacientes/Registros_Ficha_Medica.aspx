<%@ Page Title="" Language="C#" MasterPageFile="~/views/Pacientes/Paciente.Master" AutoEventWireup="true" CodeBehind="Registros_Ficha_Medica.aspx.cs" Inherits="SistemaECU911.Template.Views_Pacientes.PacientesFichaMedica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Personas Ficha Médica | Sistema Médico Paciente
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="background-color: white">
                <br />
                <div class="container">
                    <div class="card text-center">
                        <div class="card-header">
                            LISTADO DE FICHAS MEDICAS
                        </div>
                    </div>
                </div>
                <hr />
                <div class="card" style="width: auto;">
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <div class="container">
                            <div class="row justify-content-center">
                                <div class="col-auto">

                                    <asp:GridView ID="grvPacientes" AutoGenerateColumns="false" Width="100%" CssClass="table table-hover text-center table-responsive" GridLines="None" runat="server" Style="margin-right: 0px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="Per_Id" runat="server" Text='<%#Eval("Per_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Historia Clinica / Cedula">
                                                <ItemTemplate>
                                                    <asp:Label ID="Per_CedulaHisCli" runat="server" Text='<%#Eval("Per_Cedula")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="Per_Nombre" runat="server" Text='<%#Eval("Per_priNombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="Per_priApellido" runat="server" Text='<%#Eval("Per_priApellido")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Nacimiento">
                                                <ItemTemplate>
                                                    <asp:Label ID="Per_priFechaNaci" runat="server" Text='<%#Eval("Per_fechNacimiento")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Genero">
                                                <ItemTemplate>
                                                    <asp:Label ID="Per_priGenero" runat="server" Text='<%#Eval("Per_genero")%>'></asp:Label>
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
                <br>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
    <script>
        $('document').ready(function () {
            $('#<%=grvPacientes.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                //scrollCollapse: true,
                //autoWidth: false,
                //responsive: true,
                //columnDefs: [{
                //targets: "datatable-nosort",
                //orderable: false,
                //}],
                //"lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                //"language": {
                //"info": "Mostrando _START_-_END_ de _TOTAL_ Registros",
                //"zeroRecords": "No se encontró nada - lo siento",
                //"lengthMenu": "Mostrar _MENU_ Registros por página",
                //"emptyTable": "No hay datos disponibles en la tabla",
                //"search": "Buscar:",
                //searchPlaceholder: "Buscar",
                //paginate: {
                //next: '<i class="ion-chevron-right"></i>',
                //previous: '<i class="ion-chevron-left"></i>'
                //}
                //},
            });
        });
    </script>
</asp:Content>
