<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="Lista_Cantidad_Puesto_Trabajo.aspx.cs" Inherits="SistemaECU911.views.Administrador_Medico.Lista_Cantidad_Puesto_Trabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Cantidad-Puesto-Trabajo | Sistema Médico
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
                    <div class="card" style="border: none">
                        <div class="card-body">
                            <h4 class="card-title">
                                <%--<i class="fas fa-envelope"></i>--%>
                                <i class="fa-solid fa-hospital-user"></i>
                                CANTIDAD DE PENSONAS POR PUESTO DE TRABAJO
                            </h4>
                        </div>
                    </div>

                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="card" style="width: auto; border: none">
                        <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                            <div class="container">

                                <div class="row justify-content-center">

                                    <div class="col-auto">
                                        <div class="row">

                                            <div class="col-md-6">
                                                <label class="form-label">CENTRO</label>
                                                <asp:DropDownList ID="ddl_centro" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server">
                                                    <asp:ListItem Value="0" Text="Seleccione...."></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="ECU 911 QUITO"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="ECU 911 CUENCA"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="ECU 911 PORTOVIEJO"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="ECU 911 MACHALA"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="ECU 911 IBARRA"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="ECU 911 AMBATO"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="ECU 911 ESMERALDAS"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="ECU 911 TULCAN"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="ECU 911 NUEVA LOJA"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="ECU 911 SANTO DOMINGO "></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="ECU 911 RIOBAMBA"></asp:ListItem>
                                                    <asp:ListItem Value="13" Text="ECU 911 LOJA"></asp:ListItem>
                                                    <asp:ListItem Value="14" Text="ECU 911 BABAHOYO"></asp:ListItem>
                                                    <asp:ListItem Value="15" Text="ECU 911 MACAS"></asp:ListItem>
                                                    <asp:ListItem Value="16" Text="ECU 911 SAN CRISTOBAL"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="ECU 911 SAMBORONDON"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_centro" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4">
                                                <label class="form-label">CALCULAR</label>
                                                <asp:Button ID="btn_calcular" CssClass="btn btn-primary w-100" runat="server" Text="Calcular" OnClick="btn_calcular_Click" ValidationGroup="GroupValidation" />
                                            </div>
                                        </div>
                                        <asp:GridView ID="grvDatos" AutoGenerateColumns="false" Width="100%" CssClass="table table-hover text-center table-responsive" GridLines="None" runat="server" Style="margin-right: 0px" ShowHeader="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="PUESTO TRABAJO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="PUESTOTRABAJO" runat="server" Text='<%#Eval("Per_puestoTrabajos")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CENTRO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="CENTRO" runat="server" Text='<%#Eval("cent_ids")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CANTIDAD">
                                                    <ItemTemplate>
                                                        <asp:Label ID="CANTIDAD" runat="server" Text='<%#Eval("valor")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" ShowHeader="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ID" runat="server" Text='<%#Eval("per_ids")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
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

    <!--asdasdads-->

    <script>
        $(document).ready(function () {
            var dataTable = $('#<%= grvDatos.ClientID %>').DataTable({
                "columns": [
                    { "data": "Per_puestoTrabajos", "title": "PUESTO TRABAJO" },
                    { "data": "cent_ids", "title": "CENTRO" },
                    { "data": "valor", "title": "CANTIDAD" },
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
                        title: 'CANTIDAD DE PENSONAS POR PUESTO DE TRABAJO', // Título del contenido del EXCEL
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
                        title: 'CANTIDAD DE PENSONAS POR PUESTO DE TRABAJO', // Título del contenido del PDF
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
                        title: 'CANTIDAD DE PENSONAS POR PUESTO DE TRABAJO', // Título del contenido en IMPRIMIR
                        extend: 'print',
                        text: '',
                        exportOptions: {
                            columns: ':visible' // Exporta solo las columnas visibles
                        },
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
