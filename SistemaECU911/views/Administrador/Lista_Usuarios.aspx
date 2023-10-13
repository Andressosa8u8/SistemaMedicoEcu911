<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Lista_Usuarios.aspx.cs" Inherits="SistemaECU911.views.Administrador.Control_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Lista de Usuarios Activos| Administrador Sistema Médico 
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
                    <i class="fa-solid fa-users"></i>
                    USUARIOS ACTIVOS
                </h4>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card" style="width: auto;">
                            <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                                <div class="container">
                                    <div class="row justify-content-center">
                                        <div class="col-auto">

                                            <asp:GridView ID="grvPacientes" OnRowCommand="grvPacientes_RowCommand" AutoGenerateColumns="false" Width="100%" CssClass="table table-hover text-center table-responsive" GridLines="None" runat="server" ShowHeader="false">
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
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <link rel="stylesheet" type="text/css" href="styles.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.css">
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.6/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.6/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.6/js/buttons.print.min.js"></script>
    <script src=" https://cdn.datatables.net/buttons/2.4.1/js/buttons.colVis.min.js"></script>

    <script>
        $(document).ready(function () {
            var dataTable = $('#<%= grvPacientes.ClientID %>').DataTable({
                "columns": [
                    { "data": "Per_cedula", "title": "CÉDULA" },
                    { "data": "Per_priNombre", "title": "PRIMER NOMBRE" },
                    { "data": "Per_segNombre", "title": "SEGUNDO NOMBRE" },
                    { "data": "Per_priApellido", "title": "PRIMER APELLIDO" },
                    { "data": "Per_segApellido", "title": "SEGUNDO APELLIDO" },
                    { "data": "Per_genero", "title": "GÉNERO" },

                    null // Columna de EDICIÓN sin datos específicos
                ],
                dom: '<"top"lfB>rtip',
                buttons: [
                    {
                        extend: 'colvis', // Agrega el botón de visibilidad
                        text: '',
                        className: 'btn btn-secondary',
                        init: function (api, node, config) {
                            $(node).html('<i class="fas fa-eye fa-lg" style="color:#212f97;"></i>');
                        }
                    },
                    {
                        extend: 'excel',
                        text: '',
                        className: 'btn btn-secondary',
                        init: function (api, node, config) {
                            $(node).append('<i class="fas fa-file-excel fa-lg"></i>');
                        },
                        title: 'LISTADO DE PACIENTES', // Título del contenido del EXCEL
                        exportOptions: {
                            columns: ':visible' // Exporta solo las columnas visibles
                        },
                        action: function (e, dt, node, config) {
                            var filename = prompt('Ingrese el nombre del archivo Excel', '');
                            if (filename !== null && filename !== '') {
                                config.filename = filename;
                                $.fn.dataTable.ext.buttons.excelHtml5.action.call(this, e, dt, node, config);
                            }
                        }
                    },
                    {
                        extend: 'pdf',
                        text: '',
                        className: 'btn btn-secondary',
                        init: function (api, node, config) {
                            $(node).append('<i class="fas fa-file-pdf fa-lg"></i>');
                        },
                        title: 'LISTADO DE PACIENTES', // Título del contenido del PDF
                        exportOptions: {
                            columns: ':visible' // Exporta solo las columnas visibles
                        },
                        action: function (e, dt, node, config) {
                            var filename = prompt('Ingrese el nombre del archivo PDF', '');
                            if (filename !== null && filename !== '') {
                                config.filename = filename;
                                $.fn.dataTable.ext.buttons.pdfHtml5.action.call(this, e, dt, node, config);
                            }
                        }
                    },
                    {
                        title: 'LISTADO DE PACIENTES', // Título del contenido en IMPRIMIR
                        exportOptions: {
                            columns: ':visible' // Exporta solo las columnas visibles
                        },
                        extend: 'print',
                        text: '',
                        className: 'btn btn-secondary',
                        init: function (api, node, config) {
                            $(node).append('<i class="fas fa-print fa-lg"></i>');
                        }
                    }
                ],
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                "language": {
                    "lengthMenu": 'Mostrar <select>' +
                        '<option value="10">10</option>' +
                        '<option value="25">25</option>' +
                        '<option value="50">50</option>' +
                        '<option value="-1">Todos</option>' +
                        '</select>'
                },
                "initComplete": function (settings, json) {
                    var table = this.api();
                    var lengthMenuContainer = $(table.table().container()).find('.dataTables_length');
                    var searchContainer = $(table.table().container()).find('.dataTables_filter');
                    var buttonsContainer = $('<div class="float-right ml-2"></div>');

                    lengthMenuContainer.addClass('d-inline-block');
                    lengthMenuContainer.find('label').addClass('mr-2 mb-0');
                    lengthMenuContainer.find('select').addClass('custom-length-select');

                    searchContainer.addClass('d-inline-block').addClass('mr-2');

                    table.buttons().container().appendTo(buttonsContainer);
                    $('.top').prepend(buttonsContainer);
                },
                "drawCallback": function (settings) {
                    var table = this.api();
                    var lengthSelect = $(table.table().container()).find('.custom-length-select');
                    lengthSelect.val(table.page.len());
                }
            });
        });
    </script>

    <style>
        .btn-secondary .fas.fa-file-excel {
            color: green;
        }

        .btn-secondary .fas.fa-file-pdf {
            color: red;
        }

        .fa-lg {
            font-size: 20px;
        }

        .btn-secondary .fas.fa-print {
            color: black
        }
    </style>
</asp:Content>
