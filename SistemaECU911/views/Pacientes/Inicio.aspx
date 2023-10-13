<%@ Page Title="" Language="C#" MasterPageFile="~/views/Pacientes/Paciente.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SistemaECU911.Template.Views_Pacientes.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Inicio | Sistema Médico Paciente
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-panel" style="width: auto">
                <div class="content-wrapper">
                    <div class="row">
                        <div class="col-12 grid-margin">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">
                                        <i class="fa-solid fa-hospital-user"></i>
                                        FICHAS MÉDICAS
                                    </h4>
                                    <div class="card" style="width: auto;">
                                        <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                                            <div class="container">
                                                <div class="row justify-content-center">
                                                    <div class="col-auto">

                                                        <asp:GridView ID="grvHClinica" OnRowCommand="grvHClinica_RowCommand" AutoGenerateColumns="false" Width="100%" CssClass="table table-hover text-center table-responsive" GridLines="None" runat="server" Style="margin-right: 0px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="CEDULA">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Per_cedula" runat="server" Text='<%#Eval("Per_cedula")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="NOMBRE DEL PROFESIONAL">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="prof_NomApe" runat="server" Text='<%#Eval("prof_NomApe")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FECHA DE REGISTRO">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="fechaHoraGuardado" runat="server" Text='<%#Eval("fechaHoraGuardado")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="17" HeaderStyle-Width="17" HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblVisualizar" Width="16" Height="16" CommandArgument='<%#Eval("idFichaMedica")%>' CommandName="Visualizar" runat="server"><i class="fa-solid fa-eye"></i></asp:LinkButton>
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
                                </div>
                            </div>



                            <%--                            HISTORIA SOCIO ECONÓMICO--%>



                           <%-- <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">
                                        <i class="fa-solid fa-hospital-user"></i>
                                        HISTORIA SOCIO ECONÓMICO
                                    </h4>
                                    <div class="card" style="width: auto;">
                                        <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                                            <div class="container">
                                                <div class="row justify-content-center">
                                                    <div class="col-auto">

                                                        <asp:GridView ID="grvPacientesSocioEconomico" OnRowCommand="grvPacientesSocioEconomico_RowCommand" AutoGenerateColumns="false" Width="100%" CssClass="table table-hover text-center table-responsive" GridLines="None" runat="server" Style="margin-right: 0px" ShowHeader="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="CEDULA">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Per_cedula" runat="server" Text='<%#Eval("Per_cedula")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="NOMBRE">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Per_priNombre" runat="server" Text='<%#Eval("Per_priNombre")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="APELLIDO">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Per_priApellido" runat="server" Text='<%#Eval("Per_priApellido")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FECHA GUARDADO">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Socio_economico_fechaHoraGuardado" runat="server" Text='<%#Eval("Socio_economico_fechaHoraGuardado")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FECHA MODIFICACION">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Socio_economico_fechaHoraModificacion" runat="server" Text='<%#Eval("Socio_economico_fechaHoraModificacion")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="17" HeaderStyle-Width="17" HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnbEditar" Width="16" Height="16" CommandArgument='<%#Eval("Socio_economico_id")%>' CommandName="Visualizar" runat="server"><i class="fa-solid fa-eye"></i></asp:LinkButton>
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
                                </div>
                            </div>--%>


                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">



    <script>
        $('document').ready(function () {
            $('#<%=grvHClinica.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
