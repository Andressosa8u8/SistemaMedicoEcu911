<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="Lista_Doctores.aspx.cs" Inherits="SistemaECU911.views.Administrador_Medico.Lista_Doctores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
     Lista Doctores | Sistema Médico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="main-panel" style="width: auto">
        <div class="content-wrapper" style="background-color: white">
            <div class="row">
                <div class="col-12 grid-margin">
                    <div class="card" style="border:none">
                        <div class="card-body">
                            <h4 class="card-title">                                
                                <i class="fa-solid fa-hospital-user"></i>
                                MEDICOS
                            </h4>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="card" style="width: auto;border:none">
                                        <div class="list-group list-group-flush" style="padding: 10px; width:100%" text-align: center">
                                            <div class="container">
                                                <div class="row justify-content-center">
                                                    <div class="col-auto">

                                                        <asp:GridView ID="grvDoctores" OnRowCommand="grvDoctores_RowCommand" AutoGenerateColumns="false" Width="100%" CssClass="table table-hover text-center table-responsive" GridLines="None" runat="server" Style="margin-right: 0px" ShowHeader="false">
                                                            <Columns>                                                                
                                                                <asp:TemplateField HeaderText="NOMBRE COMPLETO">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="prof_NomApe" runat="server" Text='<%#Eval("prof_NomApe")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CEDULA">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="prof_cedula" runat="server" Text='<%#Eval("prof_cedula")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                
                                                                <asp:TemplateField ItemStyle-Width="17" HeaderStyle-Width="17" HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnbEditar" Width="16" Height="16" CommandArgument='<%#Eval("prof_id")%>' CommandName="Editar" runat="server"><i class="fas fa-pen"></i></asp:LinkButton>
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
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
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



    <%--Julian--%>
    <script>
        $(document).ready(function () {
            var dataTable = $('#<%= grvDoctores.ClientID %>').DataTable({
                "columns": [
                    { "data": "prof_NomApe", "title": "NOMBRE COMPLETO" },
                    { "data": "prof_cedula", "title": "CEDULA" },

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
                        title: 'LISTADO DE MEDICOS', // Título del contenido del EXCEL
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
                        title: 'LISTADO DE MEDICOS', // Título del contenido del PDF
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
                        title: 'LISTADO DE MEDICOS', // Título del contenido en IMPRIMIR
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
                    "lengthMenu": 'Show <select>' +
                        '<option value="10">10</option>' +
                        '<option value="25">25</option>' +
                        '<option value="50">50</option>' +
                        '<option value="-1">Todos</option>' +
                        '</select> entries'
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
