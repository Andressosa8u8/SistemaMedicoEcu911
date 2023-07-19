<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="HC_Evolucion.aspx.cs" Inherits="SistemaECU911.Template.Views.Evolucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    HCL Evolución | Sistema Médico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />

    <style type="text/css">
        .CompletionList {
            padding: 5px 0;
            margin: 2px 0 0;
            height: 100px;
            overflow: auto;
            position: absolute;
            border: 1px solid #ccc;
            border: 1px solid rgba(0, 0, 0, 0.2);
            *border-right-width: 2px;
            *border-bottom-width: 2px;
            -webkit-border-radius: 6px;
            -moz-border-radius: 6px;
            border-radius: 6px;
            -webkit-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
            -moz-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
            box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
            -webkit-background-clip: padding-box;
            -moz-background-clip: padding;
            background-clip: padding-box;
            background-color: White;
            cursor: pointer;
        }

        .CompletionListItem {
            display: block;
            padding: 3px 20px;
            clear: both;
            font-weight: normal;
            line-height: 20px;
            color: #333333;
            white-space: nowrap;
        }


        .CompletionListHighlightedItem {
            color: #ffffff;
            padding: 3px 20px;
            text-decoration: none;
            background-color: #0081c2;
            background-repeat: repeat-x;
            outline: 0;
            background-image: linear-gradient(to bottom, #0088cc, #0077b3);
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="background-color: white; font-family: Arial">
                <br />
                <%--Título--%>
                <asp:Table class="table table-bordered text-center" runat="server">
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; width:400px" RowSpan="4">
                                    <img src="~/resources/images/ECU911.png" Style="width:50%; height:35%" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 20px" ColumnSpan="2">SERVICIO INTEGRADO DE SEGURIDAD SIS ECU 911</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 15px" ColumnSpan="2">GESTIÓN DE SEGURIDAD Y SALUD OCUPACIONAL</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 15px" ColumnSpan="2">HOJA DE EVOLUCION</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <div class="list-group list-group-flush">
                    <asp:Table class="table table-bordered table-light" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="text-align: right; font-family: Arial; background-color: #cccdfe; font-size:15px">FECHA Y HORA</asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: white">
                                <%--<asp:Timer ID="timerFechaHora"  OnTick="timerFechaHora_Tick" runat="server" Interval="15000"></asp:Timer>--%>
                                <asp:TextBox runat="server" ID="txt_fechahora" BorderStyle="None" Style="background-color: transparent; width: 100%; font-family: Arial; font-size: 15px; text-align:center; text-transform:uppercase" TextMode="DateTimeLocal"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        A. DATOS DEL ESTABLECIMIENTO - EMPRESA Y USUARIO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="INSTITUCIÓN DEL SISTEMA O NOMBRE DE LA EMPRESA" Style="width: 375px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="RUC" Style="width: 150px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="CIIU" Style="width: 150px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="ESTABLECIMIENTO DE SALUD" Style="width: 250px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="NÚMERO DE HISTORIA CLÍNICA" Style="width: 200px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="NÚMERO DE ARCHIVO" Style="width: 200px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox ID="txt_nomEmpresa" runat="server" BorderStyle="None" style="background-color:transparent; width:100%; text-align: center; text-transform:uppercase" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox ID="txt_rucEmp" runat="server" BorderStyle="None" style="background-color:transparent; width:100%; text-align: center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox ID="txt_ciiu" runat="server" BorderStyle="None" style="background-color:transparent; width:100%; text-align: center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox ID="txt_estableSalud" runat="server" BorderStyle="None" style="background-color:transparent; width:100%; text-align: center; text-transform:uppercase" Text="Consultorio Médico" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_numHClinica" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" OnTextChanged="txt_numHClinica_TextChanged" AutoPostBack="true" onkeypress="return SoloNumeros(event)" oninput="borrarMensaje()"></asp:TextBox>
                                    <asp:Label ID="lbl_numHClinica" ForeColor="Red" runat="server"></asp:Label>
<%--                                    <asp:RequiredFieldValidator ID="rfv_numHClinica" runat="server" ForeColor="Red" ControlToValidate="txt_numHClinica" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>--%>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerNumHClinica"
                                        TargetControlID="txt_numHClinica" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_numArchivo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered table-light text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="PRIMER APELLIDO" Style="width: 225px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO APELLIDO" Style="width: 225px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="PRIMER NOMBRE" Style="width: 225px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO NOMBRE" Style="width: 225px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="SEXO" Style="width: 100px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="PUESTO DE TRABAJO (CIUO)" Style="width: 350px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_priApellido" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_segApellido" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_priNombre" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_segNombre" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_sexo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_puestoTrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: 100%;">
                    <div class="row">
                        <div class="card-header col" style="text-align: center; text-transform: uppercase; margin-left: 0.8rem; background-color: #cccdfe; font-weight: bold">
                            B. EVOLUCIÓN                                          
                        </div>
                        <div class="card-header col" style="text-align: center; text-transform: uppercase; margin-right: 0.8rem; background-color: #cccdfe; font-weight: bold">
                            C. PRESCRIPCIONES                                         
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table=responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Text="FECHA" Style="width: 100px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                            <asp:TableCell Text="HORA" Style="width: 75px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                            <asp:TableCell Text="NOTAS DE EVOLUCION" Style="width: 450px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                            <asp:TableCell Text="FARMACOTERAPIA INDICACIONES PARA ENFERMERIA Y OTRAS PERSONAS" Style="width: 300px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                            <asp:TableCell Text="ADMINISTRACIÓN FARMACOS Y OTROS" Style="width: 200px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha1" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora1" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas1" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia1" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion1" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha5" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora5" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas5" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia5" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion5" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha6" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora6" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas6" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia6" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion6" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha7" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora7" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas7" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia7" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion7" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha8" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora8" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas8" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia8" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion8" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha9" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora9" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas9" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia9" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion9" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha10" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora10" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas10" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia10" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion10" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha11" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora11" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas11" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia11" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion11" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha12" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora12" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas12" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia12" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion12" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha13" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora13" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas13" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia13" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion13" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha14" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora14" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas14" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia14" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion14" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha15" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_hora15" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Time"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_notas15" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_farmacoterapia15" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_administracion15" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="container" align="center">
                    <asp:Button CssClass="btn btn-warning" ID="btn_guardar" runat="server" Text="Guardar" OnClick="btn_guardar_Click" UseSubmitBehavior="False" ValidationGroup="GroupValidation" />
                    <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" UseSubmitBehavior="False" />
                    <asp:Button CssClass="btn btn-info" ID="btn_imprimir" runat="server" Text="Imprimir" OnClick="btn_imprimir_Click" UseSubmitBehavior="False" />
                </div>
                <br />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_imprimir" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>

    <script type="text/javascript">
        function SoloNumeros(e) {
            // Verificar el código de la tecla presionada
            var key = e.which || e.keyCode;
            if (key < 48 || key > 57) {
                // Si el código de la tecla no está en el rango de dígitos (0-9), se cancela el evento
                e.preventDefault();
                return false;
            }
        }
    </script>

    <script>
        function borrarMensaje() {
            var lblNumHClinica = document.getElementById("<%= lbl_numHClinica.ClientID %>");

            if (lblNumHClinica) {
                lblNumHClinica.innerHTML = "";
            }

        }
    </script>

</asp:Content>
