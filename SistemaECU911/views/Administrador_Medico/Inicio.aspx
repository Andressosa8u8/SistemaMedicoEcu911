<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SistemaECU911.Template.Views.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Inicio | Sistema Médico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="main-panel" style="width: auto">
        <div class="content-wrapper" style="background-color:white">
            <div class="row">
                <div class="col-12 grid-margin">
                    <div class="card card-statistics">
                        <div class="card-body">
                            <div class="d-flex flex-column flex-md-row align-items-center justify-content-between">
                                <div class="statistics-item">
                                    <p>
                                        <i class="fas fa-clipboard-list mr-2"></i>
                                        PACIENTES INACTIVOS
                                    </p>
                                    <asp:Label ID="totalInactivos" CssClass="h2" runat="server" Text=""></asp:Label>
                                    <br />
                                </div>
                                <div class="statistics-item">
                                    <p>
                                        <i class="fas fa-user-injured mr-2"></i>
                                        PACIENTES ACTIVOS
                                    </p>
                                    <asp:Label ID="totalPacientes" CssClass="h2" runat="server" Text=""></asp:Label>
                                    <br />
                                </div>
                                <div class="statistics-item">
                                    <p>
                                        <i class="fas fa-user-friends mr-2"></i>
                                        PACIENTES ECU
                                    </p>
                                    <asp:Label ID="totalEcu" CssClass="h2" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="statistics-item">
                                    <p>
                                        <i class="fas fa-user-nurse mr-2"></i>
                                        PACIENTES ARTICULADOS
                                    </p>
                                    <asp:Label ID="totalArticulados" CssClass="h2" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
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
</asp:Content>
