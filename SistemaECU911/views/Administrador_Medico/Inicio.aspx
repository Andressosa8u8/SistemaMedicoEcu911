<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SistemaECU911.Template.Views.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Inicio | Sistema Médico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="main-panel" style="width: auto">
        <div class="content-wrapper" style="background-color: white">
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


                <div class="row">
                    <center>
                        <div class="col-md-9">

                            <h4 align="center">REVISIÓN DE ÓRGANOS Y SISTEMAS</h4>
                            <canvas id="crt_organosySistemas" width="400"></canvas>
                        </div>
                    </center>
                </div>


                <div>
                    <div class="row align-items-center" style="vertical-align: middle">
                        <div class="col-md-8">
                            <h4 align="center">TIPOS DE ENFERMEDADES PERSONALES</h4>
                            <canvas id="crt_tiposdeEnfermedades" width="400"></canvas>
                        </div>

                        <div class="col-md-4">
                            <ul>
                                <li>
                                    <asp:Label ID="lbl_sinAntecedente" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_cardioVascular" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_metabolica" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_neurologia" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_oncologica" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_infecciosa" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_herediCongonita" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_discapacidad" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="lbl_otros" runat="server"></asp:Label>
                                </li>
                            </ul>                           
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>



    <script>
        var objetoLista;
        var arraynumeroPerOrgConPatolo = [];
        var arraynumeroPerOrgSinPatologia = [];
        var arraynumeroPerRespiConPatolo = [];
        var arraynumeroPerRespiSinPatologia = [];
        var arraynumeroPerCardioVascuConPatolo = [];
        var arraynumeroPerCardioVascuSinPatologia = [];
        var arraynumeroPerDigesConPatolo = [];
        var arraynumeroPerDigesSinPatologia = [];
        var arraynumeroPerGenitConPatolo = [];
        var arraynumeroPerGenitSinPatologia = [];
        var arraynumeroPerUrinConPatolo = [];
        var arraynumeroPerUrinSinPatologia = [];
        var arraynumeroPerMuscuConPatolo = [];
        var arraynumeroPerMuscuSinPatologia = [];
        var arraynumeroPerEsqueConPatolo = [];
        var arraynumeroPerEsqueSinPatologia = [];
        var arraynumeroPerNerviConPatolo = [];
        var arraynumeroPerNerviSinPatologia = [];
        var arraynumeroPerEndocConPatolo = [];
        var arraynumeroPerEndocSinPatologia = [];
        var arraynumeroPerHemoLinfaticoConPatolo = [];
        var arraynumeroPerHemoLinfaticoSinPatologia = [];
        var arraynumeroPerTegumenConPatolo = [];
        var arraynumeroPerTegumenSinPatologia = [];

        jQuery.ajax({
            url: 'Inicio.aspx/RevOrganosSistemas',
            type: "POST",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                objetoLista = data.d;

                console.log(objetoLista);

                for (var i = 0; i < objetoLista.length; i++) {
                    arraynumeroPerOrgConPatolo.push(objetoLista[i][0]);
                    arraynumeroPerOrgSinPatologia.push(objetoLista[i][1]);
                    arraynumeroPerRespiConPatolo.push(objetoLista[i][2]);
                    arraynumeroPerRespiSinPatologia.push(objetoLista[i][3]);
                    arraynumeroPerCardioVascuConPatolo.push(objetoLista[i][4]);
                    arraynumeroPerCardioVascuSinPatologia.push(objetoLista[i][5]);
                    arraynumeroPerDigesConPatolo.push(objetoLista[i][6]);
                    arraynumeroPerDigesSinPatologia.push(objetoLista[i][7]);
                    arraynumeroPerGenitConPatolo.push(objetoLista[i][8]);
                    arraynumeroPerGenitSinPatologia.push(objetoLista[i][9]);
                    arraynumeroPerUrinConPatolo.push(objetoLista[i][10]);
                    arraynumeroPerUrinSinPatologia.push(objetoLista[i][11]);
                    arraynumeroPerMuscuConPatolo.push(objetoLista[i][12]);
                    arraynumeroPerMuscuSinPatologia.push(objetoLista[i][13]);
                    arraynumeroPerEsqueConPatolo.push(objetoLista[i][14]);
                    arraynumeroPerEsqueSinPatologia.push(objetoLista[i][15]);
                    arraynumeroPerNerviConPatolo.push(objetoLista[i][16]);
                    arraynumeroPerNerviSinPatologia.push(objetoLista[i][17]);
                    arraynumeroPerEndocConPatolo.push(objetoLista[i][18]);
                    arraynumeroPerEndocSinPatologia.push(objetoLista[i][19]);
                    arraynumeroPerHemoLinfaticoConPatolo.push(objetoLista[i][20]);
                    arraynumeroPerHemoLinfaticoSinPatologia.push(objetoLista[i][21]);
                    arraynumeroPerTegumenConPatolo.push(objetoLista[i][22]);
                    arraynumeroPerTegumenSinPatologia.push(objetoLista[i][23]);
                }

                const $grafica = document.querySelector("#crt_organosySistemas");
                const etiquetas = ["ÓRGANOS / SENTIDOS", "RESPIRATORIO", "CARDIO VASCULAR", "DIGESTIVO", "GENITAL", "URINARIO", "MUSCULAR",
                    "ESQUELÉTICO", "NERVIOSO", "ENDOCRINO", "HEMO LINFÁTICO", "TEGUMENTARIO"];

                const datosConPatologia = {
                    label: "CON PATOLOGÍA",
                    data: [
                        arraynumeroPerOrgConPatolo[0],
                        arraynumeroPerRespiConPatolo[0],
                        arraynumeroPerCardioVascuConPatolo[0],
                        arraynumeroPerDigesConPatolo[0],
                        arraynumeroPerGenitConPatolo[0],
                        arraynumeroPerUrinConPatolo[0],
                        arraynumeroPerMuscuConPatolo[0],
                        arraynumeroPerEsqueConPatolo[0],
                        arraynumeroPerNerviConPatolo[0],
                        arraynumeroPerEndocConPatolo[0],
                        arraynumeroPerHemoLinfaticoConPatolo[0],
                        arraynumeroPerTegumenConPatolo[0]
                    ],
                    backgroundColor: 'rgba(255, 0, 0, 0.5)', // Rojo con transparencia
                    borderColor: 'rgba(255, 0, 0, 1)', // Rojo sin transparencia
                    borderWidth: 1
                };

                const datosSinPatologia = {
                    label: "SIN PATOLOGÍA",
                    data: [
                        arraynumeroPerOrgSinPatologia[0],
                        arraynumeroPerRespiSinPatologia[0],
                        arraynumeroPerCardioVascuSinPatologia[0],
                        arraynumeroPerDigesSinPatologia[0],
                        arraynumeroPerGenitSinPatologia[0],
                        arraynumeroPerUrinSinPatologia[0],
                        arraynumeroPerMuscuSinPatologia[0],
                        arraynumeroPerEsqueSinPatologia[0],
                        arraynumeroPerNerviSinPatologia[0],
                        arraynumeroPerEndocSinPatologia[0],
                        arraynumeroPerHemoLinfaticoSinPatologia[0],
                        arraynumeroPerTegumenSinPatologia[0]
                    ],
                    backgroundColor: 'rgba(0, 123, 255, 0.5)',
                    borderColor: 'rgba(0, 123, 255, 1)',
                    borderWidth: 1
                };

                new Chart($grafica, {
                    type: 'bar',
                    data: {
                        labels: etiquetas,
                        datasets: [
                            datosConPatologia,
                            datosSinPatologia
                        ]
                    },
                    options: {

                        title: {
                            display: true,
                            text: 'ÓRGANOS Y SISTEMAS'
                        },

                    }
                });
            },
            error: function (error) {
                console.log(error);
            }
        });
    </script>

    <%------------------------------Tipo de Enfermedad------------------------------%>

  <script>
      var objetoLista1;
      var arraynumeroPerSeleccioneAntecePerson = [];
      var arraynumeroPerEnferCardiVascuAntecePerson = [];
      var arraynumeroPerEnferMetabAntecePerson = [];
      var arraynumeroPerEnferNeuroAntecePerson = [];
      var arraynumeroPerEnferOncolAntecePerson = [];
      var arraynumeroPerEnferInfecAntecePerson = [];
      var arraynumeroPerEnferHered_CongóAntecePerson = [];
      var arraynumeroPerDiscaAntecePerson = [];
      var arraynumeroPerOtrosAntecePerson = [];

      jQuery.ajax({
          url: 'Inicio.aspx/AntPersonales',
          type: "POST",
          dataType: "JSON",
          contentType: "application/json; charset=utf-8",
          success: function (data) {
              objetoLista = data.d;

              console.log(objetoLista);

              for (var i = 0; i < objetoLista.length; i++) {
                  arraynumeroPerSeleccioneAntecePerson.push(objetoLista[i][0]);
                  arraynumeroPerEnferCardiVascuAntecePerson.push(objetoLista[i][1]);
                  arraynumeroPerEnferMetabAntecePerson.push(objetoLista[i][2]);
                  arraynumeroPerEnferNeuroAntecePerson.push(objetoLista[i][3]);
                  arraynumeroPerEnferOncolAntecePerson.push(objetoLista[i][4]);
                  arraynumeroPerEnferInfecAntecePerson.push(objetoLista[i][5]);
                  arraynumeroPerEnferHered_CongóAntecePerson.push(objetoLista[i][6]);
                  arraynumeroPerDiscaAntecePerson.push(objetoLista[i][7]);
                  arraynumeroPerOtrosAntecePerson.push(objetoLista[i][8]);
              }

              const $grafica = document.querySelector("#crt_tiposdeEnfermedades");
              const etiquetas = ["SIN ANTECEDENTES", "ENF CARDIOVASCULAR", "ENF METABÓLICA", "ENF NEUROLÓGICA",
                  "ENF ONCOLÓGICA", "ENF INFECCIOSA", "ENF HEREDITARIA CONGÓNITA", "DISCAPACIDAD", "OTROS"];

              const datosAntecedentesPersonales = {
                  labels: etiquetas,
                  datasets: [{
                      label: ["SIN ANTECEDENTES", "ENF CARDIOVASCULAR", "ENF METABÓLICA", "ENF NEUROLÓGICA",
                          "ENF ONCOLÓGICA", "ENF INFECCIOSA", "ENF HEREDITARIA CONGÓNITA", "DISCAPACIDAD", "OTROS"],
                      data: [
                          arraynumeroPerSeleccioneAntecePerson[0],
                          arraynumeroPerEnferCardiVascuAntecePerson[0],
                          arraynumeroPerEnferMetabAntecePerson[0],
                          arraynumeroPerEnferNeuroAntecePerson[0],
                          arraynumeroPerEnferOncolAntecePerson[0],
                          arraynumeroPerEnferInfecAntecePerson[0],
                          arraynumeroPerEnferHered_CongóAntecePerson[0],
                          arraynumeroPerDiscaAntecePerson[0],
                          arraynumeroPerOtrosAntecePerson[0]
                      ],
                      backgroundColor: [
                          "#FF6384",
                          "#63FF84",
                          "#84FF63",
                          "#8463FF",
                          "#6384FF",
                          "#FF8F00",
                          "#00FF8F",
                          "#8FFF00",
                          "#FF6384"
                      ],
                      borderWidth: 1
                  }]
              };

              new Chart($grafica, {
                  type: 'bar',
                  data: datosAntecedentesPersonales,
                  options: {
                      title: {
                          display: true,
                          text: 'ANTECEDENTES PERSONALES'
                      },
                      tooltips: {
                          enabled: true
                      }
                  }
              });
          },
          error: function (error) {
              console.log(error);
          }
      });
  </script>

    <%-- ------------------------------------------------------------------------------------------------------------------------------------ --%>
</asp:Content>
