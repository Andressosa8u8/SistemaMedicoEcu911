<%@ Page Title="" Language="C#" MasterPageFile="~/views/Pacientes/Paciente.Master" AutoEventWireup="true" CodeBehind="SocioEconomico.aspx.cs" Inherits="SistemaECU911.Template.Views_Pacientes.SocioEconomico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Ficha Socio Económico | Sistema Médico Paciente
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
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="background-color: white">
                <br />
                <%--Título--%>

                <asp:Table class="table table-bordered text-center" runat="server">
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; width:400px" RowSpan="6">
                                    <img src="~/resources/images/ECU911.png" Style="width:40%; height:25%" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 14px" ColumnSpan="2">GESTION DEL TALENTO HUMANO</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 14px" ColumnSpan="2">GESTION DE BIENESTAR LABORAL Y SALUD OCUPACIONAL</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 14px" ColumnSpan="2">FICHA SOCIOECONOMICA</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-size: 13px">CODIGO
                        </asp:TableCell>
                        <asp:TableCell Style="font-family: Arial; font-size: 13px">VERSION</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="background-color: white; font-family: Arial">
                            <asp:TextBox runat="server" ID="txt_codigoinicio" BorderStyle="None" Style="width: 100%; font-size: 13px; text-align: center" ReadOnly="true">GTH_FOR_21</asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell Style="background-color: white; font-family: Arial">
                            <asp:TextBox runat="server" ID="txt_version" BorderStyle="None" Style="width: 100%; font-size: 13px; text-align: center" ReadOnly="true">2</asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <%--Fecha de Registro--%>

                <div class="list-group list-group-flush">
                    <asp:Table class="table table-bordered table-light" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="text-align: right; font-family: Arial; background-color: white; font-size: 12px">FECHA DE INGRESO:</asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: white">
                                <asp:TextBox runat="server" ID="txt_fecharegistro" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>

                <%--I. DATOS PERSONALES DEL SERVIDOR/A--%>

                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial; font-size: 14px">
                        I. DATOS PERSONALES DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">NOMBRES Y APELLIDOS:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_prinombre" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_segnombre" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_priapellido" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_segapellido" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">CEDULA CIUDADANIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_cedula" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerNumHClinica"
                                        TargetControlID="txt_cedula" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
<%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtcedula" runat="server" ErrorMessage="!Este campo es obligatorio!" ControlToValidate="txt_cedula" ForeColor="Red" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">AREA A LA QUE PERTENECE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_areatrabajo" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">CARGO INSTITUCIONAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_cargoinstitucional" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">MODALIDAD DE VINCULACION:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">LEY ORGANICA DEL SECTOR PUBLICO (LOSEP)</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_modalidadvinculacionlosep" AutoPostBack="true" Enabled="false" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">CODIGO DE TRABAJO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_modalidadvinculacioncodigotrabajo" AutoPostBack="true" Enabled="false" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; width: 300px">FECHA DE INGRESO AL SISTEMA ECU 911:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; font-family:Arial; font-size: 12px">
                                    <asp:TextBox runat="server" ID="txt_fechaingresoalsisecu" BorderStyle="None" BackColor="white" TextMode="Date" ReadOnly="true" Style="font-family: Arial; font-size: 12px "></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">ESTADO CIVIL:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SOLTERO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_soltero" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CASADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_casado" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIUDO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_viudo" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">UNION LIBRE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_unionlibre" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DIVORCIADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_divorciado" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">GENERO:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">MASCULINO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_genmasculino" AutoPostBack="true" runat="server" Enabled="false" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">FEMENINO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_genfemenino" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">TIPO DE SANGRE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_tipodesangre" BorderStyle="None" BackColor="white" Style="font-family: Arial; font-size: 12px; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">¿ES DONANTE?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_donantesi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_donanteno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">TELEFONO CONVENCIONAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_telconvecional" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">TELEFONO CELULAR:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_telcelular" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">EMAIL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_email" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">LUGAR DE NACIMIENTO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_lugarnacimiento" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">FECHA DE NACIMIENTO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento" BorderStyle="None" BackColor="white" TextMode="Date" ReadOnly="true" Style="font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">EDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_edad" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">NIVEL DE EDUCACION:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">PRIMARIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_primaria" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">SECUNDARIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_secundaria" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">SUPERIOR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_superior" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">ESPECIALIZACION</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_especializacion" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">DIPLOMADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_diplomado" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">MAESTRIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_maestria" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">AUTOIDENTIFICACION ETNICA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BLANCO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_blanco" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MESTIZO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_mestizo" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">AFRODESCENDIENTE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_afro" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">INDIGENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_indigena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MONTUBIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_montubio" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">DIRECCION DEL DOMICILIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">PROVINCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_provincia" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">CANTON:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_canton" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">PARROQUIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_parroquia" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">BARRIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_barrio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 75px; font-size: 12px">CALLE PRINCIPAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_calleprincipal" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">Nº:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_mumerodecasa" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CALLE SECUNDARIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_callesecundaria" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">REFERENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_refubicardomicilio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 75px; font-size: 12px">SECTOR DONDE VIVE:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">NORTE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_norte" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CENTRO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_centro" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SUR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sur" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">VALLE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_valle" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">VALLE DE LOS CHILLOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_valledeloschillos" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 90px; font-size: 12px">TIPO DE VIVIENDA EN LA QUE RECIDE:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">CASA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_casa" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">DEPARTAMENTO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_departamento" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">OTRO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_tipoviviendaotro" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" Placeholder="Indique cuál" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 70px; font-size: 12px">RIESGO DELINCUENCIAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">ALTO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_riesgoalto" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">MEDIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_riesgomedio" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">BAJO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_riesgobajo" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">CONTACTO DE EMERGENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">NOMBRE Y APELLIDO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 300px">
                                    <asp:TextBox runat="server" ID="txt_emernomyape" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">PARENTESCO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emeparentesco" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">TELEFONO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emetelefono" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CALLE PRINCIPAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_emecalleprincipal" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">Nº DEL DOMICILIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emenumdomicilio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CALLE SECUNDARIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_emecallesecun" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REFERENCIA PARA UBICAR EL DOMICILIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emerefubicardomicilio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>                       
                    </div>
                </div>
                <br />

                <%--II. SITUACIÓN MÉDICA Y DE SALUD DEL SERVIDOR/A--%>

                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold;  font-family: Arial; font-size: 14px">
                        II. SITUACIÓN MÉDICA Y DE SALUD DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 400px; font-size: 12px">¿POSEE ALGUNA ENFERMEDAD PRE-EXISTENTE?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sienfermedad" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_noenfermedad" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_poseeenfermedadprexistente" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" placeholder="INDIQUE LA ENFERMEDAD QUE PADECE" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿POSEE ALGUNA DISCAPACIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_discapacidadsi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_discapacidadno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">TIPO DE DISCAPACIDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tipodiscapacidad" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">PORCENTAJE DE DISCAPACIDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 60px">
                                    <asp:TextBox runat="server" ID="txt_porcentajediscapacidad" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px;" BackColor="white" Placeholder="%" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">Nº DE CARNET OTORGADO POR EL MSP o CONADIS:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_numcarnetconadis" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">FECHA DE CADUCIDAD DEL CARNET:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_fechacaducidadcarnet" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿SE ENCUENTRA EN ESTADO DE GESTACION?  (ADJUNTAR CERTIFICADO MEDICO)    </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_gestaciónsi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_gestaciónno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">TIEMPO DE GESTACION:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_gestacióntiempo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">FECHA TENTATIVA DE PARTO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_fechatentativaparto" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">¿SE ENCUENTRA EN PERIODO DE LACTANCIA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lactaciasi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lactaciano" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 350px; font-size: 12px">FECHA DE CULMINACION DE PERIODO DE LACTANCIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_fechaculmicacionlactancia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 350px; font-size: 12px">¿POSEE ALGUNA ENFERMEDAD CRONICA Y/O CATASTROFICA? (ADJUNTAR CERTIFICADO MEDICO)</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_catastroficasi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_catastroficano" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">NOMBRE DE LA ENFERMEDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_cualcatastrofica" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 450px; font-size: 12px">¿POSEE ALGUNA ENFERMEDAD RAR O HUERFANA, SEGUN EL ENTE RECTOR QUE LO DETERMINE? (ADJUNTAR CERTIFICADO MEDICO)</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_enfermedadrarasi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_enfermedadrarano" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">NOMBRE DE LA ENFERMEDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_enfermedadraracual" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSUME ALCOHOL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_alcoholsi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_alcoholno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell ID="tbc_causa" Style="background-color: #cdfecc; color: black; font-family: Arial; width: 125px; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell ID="txt_causa" Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_causaconsumoalcohol" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿HACE CUANTO TIEMPO CONSUME?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tiempoconsumoalcohol" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSUME TABACO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tabacosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tabacono" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 125px; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_frecuenciaconsumotabaco" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿HACE CUANTO TIEMPO CONSUME?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tiempoconsumotabaco" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSUME ALGUNA SUSTANCIA PSICOTROPICA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sustanciapsicotropicasi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sustanciapsicotropicano" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 125px; font-size: 12px">TIPO DE SUSTANCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_sustanciapsicotropicatipo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 160px; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_sustanciapsicotropicafrecuencia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">PROBLEMAS RELACIONADOS CON EL CONSUMO DE ALCOHOL O SUSTANCIAS PSICOTROPICAS</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">FAMILIARES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_familiares" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">LABORAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_laborales" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">ECONOMICOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_economicos" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SALUD</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_salud" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">LEGALES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_legales" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--III. SITUACIÓN ECONÓMICA DEL SERVIDOR/A--%>

                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial; font-size: 14px">
                        III. SITUACIÓN ECONÓMICA DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 500px; font-size: 12px">NÚMERO DE MIEMBROS ECONOMICAMENTE ACTIVOS CON LOS QUE VIVE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_miembroactivoseconomicamente" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SITUACIÓN LABORAL DEL CONYUGUE</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_situacionlaboralconyugue" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <div class="row">
                            <div class="col-sm-9">
                                <asp:Table class="table table-bordered table-light" runat="server">                              
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" ColumnSpan="2">TOTAL INGRESOS MENSUALES PROYECTADOS</asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">AYUDA</asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTROS</asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" ColumnSpan="3">TOTAL EGRESOS</asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ALIMENTACION</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_alimentación" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIVIENDA</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_vivienda" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EDUCACION</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_educación" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SERVICIOS BASICOS</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_serviciosbasicos" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SALUD</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_salud" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos6" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda6" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros6" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MOVILIZACION</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_movilización" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos7" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda7" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros7" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DEUDAS</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_deudas" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos8" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda8" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros8" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTROS</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otrospensiones" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                            <div class="col-sm-3">
                                <asp:Table class="table table-bordered table-light" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" ColumnSpan="2">DESCRIPCIÓN DE LOS BIENES</asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BIEN</asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VALOR</asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CASA</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_biencasa" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DEPARTAMENTO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_biendepartamento" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VEHICULO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienvehiculo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TERRENO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienterreno" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NEGOCIO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienegocio" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUEBLES Y ENSERES</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienmueblesyenseres" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align:center" ReadOnly="true"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                        </div>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 350px; font-size: 12px">¿DESTINA ALGUN DINERO PARA EL AHORRO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dineroahorrosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dineroahorrono" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>                        
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; text-align: left">CARACTERÍSTICAS DE LA VIVIENDA</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DESCRIPCION:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">UNIFAMILIAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_unifamiliar" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MULTIFAMILIAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_multifamiliar" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_otrodescripcionviviendafamilia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">TENENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PROPIA SIN DEUDA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_propiasindeuda" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ARRENDADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_arrendada" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DE FAMILIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_defamilia" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white" RowSpan="2">
                                    <asp:TextBox runat="server" ID="txt_otratenencia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">HIPOTECADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_hipotecada" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PRESTADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_prestada" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ANTICRESIS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_anticreces" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIPO:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CASA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipocasa" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SUIT</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tiposuit" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MEDIAGUA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipomediagua" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DEPARTAMENTO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipodepartamento" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PIEZA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipopieza" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_otrotipodecasa" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">DISTRIBUCION:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">HABITACION</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_habitacion" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_sala" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BAÑO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_baño" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">GARAGE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_garage" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white" RowSpan="2">
                                    <asp:TextBox runat="server" ID="txt_otradistribucioncasa" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">COMEDOR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_comedor" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">COCINA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_cocina" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PATIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_patio" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BODEGA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_bodega" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">¿DISPONE VEHICULO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vehiculosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vehiculono" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿HACE USO DEL RECORRIDO INSTITUCIONAL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 20px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_recorridosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 20px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_recorridono" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--IV. INFORMACIÓN GENERAL DEL SERVIDOR/A--%>

                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial; font-size: 14px">
                        IV. INFORMACIÓN GENERAL DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">COMPOSICIÓN FAMILIAR DEL SERVIDOR/A, TRABAJADOR/A CON LOS QUE CONVIVE DE FORMA PERMANENTE EN EL MISMO LUGAR</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">APELLIDOS Y NOMBRES</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 200px">PARENTESCO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 150px">FECHA DE NACIMIENTO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 150px">EDAD</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento1" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento2" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento3" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento4" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento5" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 175px; font-size: 12px">¿TIENE EN SU NUCLEO FAMILIAR ALGUNA PERSONA CON DISCAPACIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nucleodiscapacidadsi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nucleodiscapacidadno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 175px; font-size: 12px">¿SE ENCUENTRA A CARGO DE ESTA PERSONA CON DISCAPACIDAD? CALIFICADA POR EL MSP o CONADIS</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliardiacapacitadosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliardiacapacitadono" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">APELLIDOS Y NOMBRES</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 150px">FECHA DE CADUCIDAD DEL CARNET</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 150px">TIPO DE DISCAPACIDAD</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 100px">PORCENTAJE</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 100px">PARENTESCO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 150px">FECHA DE NACIMIENTO</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadonomape1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechacaducidadcarnet1" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadotipodiscapacidad1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoporcentajediscapacidad1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoparentesco1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechanacimiento1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadonomape2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechacaducidadcarnet2" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadotipodiscapacidad2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoporcentajediscapacidad2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoparentesco2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align:center" BackColor="white" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechanacimiento2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 550px; font-size: 12px">¿SE ENCUENTRA REGISTRADA LA DEPENDENCIA DEL FAMILIAR EN EL MINISTERIO DE TRABAJO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dependenciaministeriotrabajosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dependenciaministeriotrabajono" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIEMPO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_dependenciaministeriotrabajotiempo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">Nº CARNET MINISTERIO DE TRABAJO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_numcarnetMSP" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 550px; font-size: 12px">¿SE ENCUENTRA A CARGO DE UN FAMILIAR CON ENFERMEDAD CATASTROICA O RARA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliarenfermedadrarasi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliarenfermedadrarano" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIEMPO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_acargofamiliarenfermedadraratiempo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIPO DE ENFERMEDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_familiarenfermedadraratipo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--V. ACTIVIDADES QUE  REALIZA EN TIEMPO LIBRE EL SERVIDOR/A--%>

                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial; font-size: 14px">
                        V. ACTIVIDADES QUE REALIZA EN TIEMPO LIBRE EL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">HOGAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_hogar" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PASEOS FAMILIARES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_paseosfamiliares" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ESTUDIOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_estudios" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ACTIVIDADES ARTISTICAS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_actividadesartisticas" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTROS:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_otraactividad" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" placeholder="Indique cual" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 350px; font-size: 12px">¿REALIZA ALGUNA ACTIVIDAD ECONOMICA ADICIONAL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_actividadeconomicasi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_actividadeconomicano" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 300px">DETALLE LA ACTIVIDAD QUE REALIZA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_actividadeconomicadetalle" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 250px">TIEMPO QUE DESTINA A LA ACTIVIDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_actividadeconomicatiempodestina" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 300px">¿HACE CUANTO REALIZA LA ACTIVIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_actividadeconomicatiemporealiza" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿REALIZA ALGUNA ACTIVIDAD DEPORTIVA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_deportesi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_deporteno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DETALLE LA ACTIVIDAD QUE REALIZA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_especifiquedeporte" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_frecuenciadeporte" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿DESDE QUE EDAD PRACTICA ESTA ACTIVIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_edadpracticadeporte" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿HA SUFRIDO ALGUNA LESION?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lesionsi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lesionno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIPO DE LESION:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tipolesion" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EDAD A LA QUE SUFRIO LA LESION:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_edadlesion" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿RECIBIO ALGUN TRATAMIENTO O REHABILITACION?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tratamientosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tratamientono" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--VI. INFORMACIÓN PARA USO DE BIENESTAR LABORAL DEL SERVIDOR/A--%>

                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial; font-size: 14px">
                        VI. INFORMACIÓN PARA USO DE BIENESTAR LABORAL DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIPO DE FAMILIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NUCLEAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nuclear" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">AMPLIADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_ampliada" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MONOPARENTAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_monoparental" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIVE SOLO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vivesolo" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIVE CON AMIGOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_viveconamigos" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">FAMILIA SIN HIJOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_familiasinhijos" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EVALUACION DEL NIVEL DE RELACION FAMILIAR:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarmuybuena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarbuena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarregular" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarmala" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_relacionfamiliarporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EVALUACION DEL NIVEL DE RELACION DE PAREJA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejamuybuena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejabuena"  AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejaregular" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejamala" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_relacionparejaporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EVALUACION DEL NIVEL DE RELACION CON LOS HIJOS:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosmuybuena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosbuena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosregular" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosmala" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_relacionconhijosporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">PROBLEMAS FAMILIARES:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ECONOMICOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_economico" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">COMUNICACION</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_comunicacion" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CONYUGALES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_conyugales" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CRIANZA DE HIJOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_crianzadehijos" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ADICCIONES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_adicciones" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA FISICA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_fisica" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA PSICOLOGICA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_psicologica" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA VERBAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_verbal" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA SEXUAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sexual" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OBSERVACIONES</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_observacionesfamiliares" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">¿CADA MIEMBRO DE LA FAMILIA CUMPLE CON SU ROL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_rolfamiliarsi" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_rolfamiliarno" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NIVEL DE SALUD DE LA FAMILIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarmuybuena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarbuena" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarregular" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarmala" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_nivelsaludfamiliarporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSIDERA QUE SU FAMILIA ES?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">FUNCIONAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_funcional" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">DISFUNCIONAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_disfuncional" AutoPostBack="true" runat="server" Enabled="false"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OBSERVACIONES</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_observacionesgenerales" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ALGUNA INFORMACION ADICIONAL QUE LA INSTITUCION DEBA CONOCER</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_informacionadicional" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">
                                    <strong> 
                                        <i>CERTIFICO QUE LA INFORMACION AQUI SUMINISTRADA ES VERAZ, REAL, COMPLETA Y PODRA SER VERIFICADA EN EL MOMENTO QUE LA INSTITUCION CREA NECESARIO.</i> 
                                    </strong> 
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <div align="center">
                            <div style="width: 200px">
                                <asp:Table class="table table-bordered table-light text-center" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black">SI</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:CheckBox ID="cb_certificosi" AutoPostBack="true" runat="server" Enabled="false"/>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black">NO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:CheckBox ID="cb_certificono" AutoPostBack="true" runat="server" Enabled="false"/>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                        </div>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">
                                    <i>ESTA INFORMACION ES SOLICITADA CON EL FIN DE ACTUALIZAR NUESTROS REGISTROS SOCIOECONOMICOS Y DE BIENESTAR LABORAL DE LOS SERVIDORES DEL SERVICIO INTEGRADO DE SEGURIDAD ECU 911.</i>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px"> <strong>GRACIAS POR SU COLABORACIÓN</strong> </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px"> <strong>FIRMA DEL SERVIDOR/A, TRABAJADOR/A</strong> </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_firmadelservidor" BorderStyle="None" Style="width: 100%" BackColor="white" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>     
                        </asp:Table>
                        <%--<asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px"> <strong>GEOREFERECIA DE LA VIVIENDA</strong> </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:Label ID="Label1" runat="server" Style="font-family: Arial; font-size: 12px; font-family: Arial; font-size: 12px; text-align: center" Text="SELECCIONE UNA IMAGEN (CROQUIS), DONDE SE MUESTRE LA UBICACION DE SU DOMICILIO DE MANERA CLARA."></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:FileUpload ID="FileUploadImageGeo" runat="server" CssClass="container" Style="font-family: Arial; font-size: 12px" OnLoad="FileUploadImageGeo_Load" ToolTip="SELECCIONE UN ARCHIVO"/>
                                    <asp:Button CssClass="btn btn-info" ID="btn_mostrarimagen" OnClick="btn_mostrarimagen_Click" runat="server" Text="Mostrar Imagen Adjuntada" Style="font-family: Arial; font-size: 12px" UseSubmitBehavior="False" ToolTip="Mostrar imagen elegida" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:Image ID="Image1" runat="server" Style="width:500px; height:500px" />
                                    <%--<asp:Image ID="imagen" runat="server" ImageUrl='<%# "~/Template/Images/" + Eval("Socio_economico_imagen_geolocalizacion") %>' />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>--%>

                        <div class="container" align="center">
                            <asp:Button CssClass="btn btn-info" ID="btn_imprimir"  OnClick="btn_imprimir_Click" runat="server" Text="IMPRIMIR" Style="font-family: Arial; font-size: 12px" UseSubmitBehavior="False" />
                            <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" OnClick="btn_cancelar_Click" runat="server" Text="CANCELAR" Style="font-family: Arial; font-size: 12px" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_imprimir"/>
            <%--<asp:PostBackTrigger ControlID="btn_mostrarimagen"/>--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
