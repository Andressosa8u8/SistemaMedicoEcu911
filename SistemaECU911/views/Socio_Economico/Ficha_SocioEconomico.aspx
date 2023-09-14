<%@ Page Title="" Language="C#" MasterPageFile="~/views/Socio_Economico/Socio_Economico.Master" AutoEventWireup="true" CodeBehind="Ficha_SocioEconomico.aspx.cs" Inherits="SistemaECU911.Template.Views_Socio_Economico.SocioEconomico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Ficha Socio Económico | Socio Económico
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
            <div class="container" style="background-color: white">
                <br />
                <%--Título--%>

                <asp:Table class="table table-bordered text-center" runat="server">
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; width: 400px" RowSpan="6">
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
                                    <asp:TextBox runat="server" ID="txt_cedula" OnTextChanged="txt_cedula_TextChanged" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerNumHClinica"
                                        TargetControlID="txt_cedula" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtcedula" runat="server" ErrorMessage="!Este campo es obligatorio!" ControlToValidate="txt_cedula" ForeColor="Red" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
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
                                    <asp:CheckBox ID="cb_modalidadvinculacionlosep" OnCheckedChanged="cb_modalidadvinculacionlosep_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">CODIGO DE TRABAJO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_modalidadvinculacioncodigotrabajo" OnCheckedChanged="cb_modalidadvinculacioncodigotrabajo_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; width: 300px">FECHA DE INGRESO AL SISTEMA ECU 911:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; font-family: Arial; font-size: 12px">
                                    <asp:TextBox runat="server" ID="txt_fechaingresoalsisecu" BorderStyle="None" BackColor="white" TextMode="Date" ReadOnly="true" Style="font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">ESTADO CIVIL:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SOLTERO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_soltero" OnCheckedChanged="cb_soltero_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CASADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_casado" OnCheckedChanged="cb_casado_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIUDO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_viudo" OnCheckedChanged="cb_viudo_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">UNION LIBRE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_unionlibre" OnCheckedChanged="cb_unionlibre_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DIVORCIADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_divorciado" OnCheckedChanged="cb_divorciado_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">GENERO:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">MASCULINO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_genmasculino" OnCheckedChanged="cb_genmasculino_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">FEMENINO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_genfemenino" OnCheckedChanged="cb_genfemenino_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">TIPO DE SANGRE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_tipodesangre" BorderStyle="None" BackColor="white" Style="font-family: Arial; font-size: 12px; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">¿ES DONANTE?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_donantesi" OnCheckedChanged="cb_donantesi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_donanteno" OnCheckedChanged="cb_donanteno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">TELEFONO CONVENCIONAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_telconvecional" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">TELEFONO CELULAR:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_telcelular" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">EMAIL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_email" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">LUGAR DE NACIMIENTO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_lugarnacimiento" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
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
                                    <asp:CheckBox ID="cb_primaria" OnCheckedChanged="cb_primaria_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">SECUNDARIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_secundaria" OnCheckedChanged="cb_secundaria_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">SUPERIOR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_superior" OnCheckedChanged="cb_superior_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">ESPECIALIZACION</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_especializacion" OnCheckedChanged="cb_especializacion_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">DIPLOMADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_diplomado" OnCheckedChanged="cb_diplomado_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">MESTRIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_maestria" OnCheckedChanged="cb_maestria_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">AUTOIDENTIFICACION ETNICA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BLANCO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_blanco" OnCheckedChanged="cb_blanco_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MESTIZO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_mestizo" OnCheckedChanged="cb_mestizo_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">AFRODESCENDIENTE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_afro" OnCheckedChanged="cb_afro_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">INDIGENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_indigena" OnCheckedChanged="cb_indigena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MONTUBIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_montubio" OnCheckedChanged="cb_montubio_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">DIRECCION DEL DOMICILIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">PROVINCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_provincia" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">CANTON:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_canton" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">PARROQUIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_parroquia" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">BARRIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_barrio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 75px; font-size: 12px">CALLE PRINCIPAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_calleprincipal" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">Nº:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_mumerodecasa" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CALLE SECUNDARIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_callesecundaria" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">REFERENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_refubicardomicilio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 75px; font-size: 12px">SECTOR DONDE VIVE:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">NORTE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_norte" OnCheckedChanged="cb_norte_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CENTRO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_centro" OnCheckedChanged="cb_centro_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SUR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sur" OnCheckedChanged="cb_sur_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">VALLE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_valle" OnCheckedChanged="cb_valle_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">VALLE DE LOS CHILLOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_valledeloschillos" OnCheckedChanged="cb_valledeloschillos_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 90px; font-size: 12px">TIPO DE VIVIENDA EN LA QUE RECIDE:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">CASA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_casa" OnCheckedChanged="cb_casa_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">DEPARTAMENTO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_departamento" OnCheckedChanged="cb_departamento_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">OTRO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_tipoviviendaotro" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px" Placeholder="Indique cuál"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 70px; font-size: 12px">RIESGO DELINCUENCIAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">ALTO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_riesgoalto" OnCheckedChanged="cb_riesgoalto_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">MEDIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_riesgomedio" OnCheckedChanged="cb_riesgomedio_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 25px; font-size: 12px">BAJO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_riesgobajo" OnCheckedChanged="cb_riesgobajo_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">CONTACTO DE EMERGENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">NOMBRE Y APELLIDO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 300px">
                                    <asp:TextBox runat="server" ID="txt_emernomyape" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">PARENTESCO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emeparentesco" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">TELEFONO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emetelefono" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CALLE PRINCIPAL:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_emecalleprincipal" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">Nº DEL DOMICILIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emenumdomicilio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">CALLE SECUNDARIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_emecallesecun" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REFERENCIA PARA UBICAR EL DOMICILIO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emerefubicardomicilio" BorderStyle="None" BackColor="white" Style="width: 100%; font-family: Arial; font-size: 12px"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--II. SITUACIÓN MÉDICA Y DE SALUD DEL SERVIDOR/A--%>

                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial; font-size: 14px">
                        II. SITUACIÓN MÉDICA Y DE SALUD DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 400px; font-size: 12px">¿POSEE ALGUNA ENFERMEDAD PRE-EXISTENTE?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sienfermedad" OnCheckedChanged="cb_sienfermedad_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_noenfermedad" OnCheckedChanged="cb_noenfermedad_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_poseeenfermedadprexistente" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" placeholder="INDIQUE LA ENFERMEDAD QUE PADECE"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿POSEE ALGUNA DISCAPACIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_discapacidadsi" OnCheckedChanged="cb_discapacidadsi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_discapacidadno" OnCheckedChanged="cb_discapacidadno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">TIPO DE DISCAPACIDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tipodiscapacidad" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">PORCENTAJE DE DISCAPACIDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 60px">
                                    <asp:TextBox runat="server" ID="txt_porcentajediscapacidad" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px;" BackColor="white" Placeholder="%"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">Nº DE CARNET OTORGADO POR EL MSP o CONADIS:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_numcarnetconadis" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">FECHA DE CADUCIDAD DEL CARNET:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_fechacaducidadcarnet" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿SE ENCUENTRA EN ESTADO DE GESTACION?  (ADJUNTAR CERTIFICADO MEDICO)    </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_gestaciónsi" OnCheckedChanged="cb_gestaciónsi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_gestaciónno" OnCheckedChanged="cb_gestaciónno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">TIEMPO DE GESTACION:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_gestacióntiempo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">FECHA TENTATIVA DE PARTO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_fechatentativaparto" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">¿SE ENCUENTRA EN PERIODO DE LACTANCIA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lactaciasi" OnCheckedChanged="cb_lactaciasi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lactaciano" OnCheckedChanged="cb_lactaciano_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 350px; font-size: 12px">FECHA DE CULMINACION DE PERIODO DE LACTANCIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_fechaculmicacionlactancia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 350px; font-size: 12px">¿POSEE ALGUNA ENFERMEDAD CRONICA Y/O CATASTROFICA? (ADJUNTAR CERTIFICADO MEDICO)</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_catastroficasi" OnCheckedChanged="cb_catastroficasi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_catastroficano" OnCheckedChanged="cb_catastroficano_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">NOMBRE DE LA ENFERMEDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_cualcatastrofica" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 450px; font-size: 12px">¿POSEE ALGUNA ENFERMEDAD RAR O HUERFANA, SEGUN EL ENTE RECTOR QUE LO DETERMINE? (ADJUNTAR CERTIFICADO MEDICO)</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_enfermedadrarasi" OnCheckedChanged="cb_enfermedadrarasi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_enfermedadrarano" OnCheckedChanged="cb_enfermedadrarano_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">NOMBRE DE LA ENFERMEDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_enfermedadraracual" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSUME ALCOHOL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_alcoholsi" OnCheckedChanged="cb_alcoholsi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_alcoholno" OnCheckedChanged="cb_alcoholno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell ID="tbc_causa" Style="background-color: #cdfecc; color: black; font-family: Arial; width: 125px; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell ID="txt_causa" Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_causaconsumoalcohol" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿HACE CUANTO TIEMPO CONSUME?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tiempoconsumoalcohol" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSUME TABACO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tabacosi" OnCheckedChanged="cb_tabacosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tabacono" OnCheckedChanged="cb_tabacono_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 125px; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_frecuenciaconsumotabaco" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">¿HACE CUANTO TIEMPO CONSUME?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tiempoconsumotabaco" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSUME ALGUNA SUSTANCIA PSICOTROPICA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sustanciapsicotropicasi" OnCheckedChanged="cb_sustanciapsicotropicasi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sustanciapsicotropicano" OnCheckedChanged="cb_sustanciapsicotropicano_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 125px; font-size: 12px">TIPO DE SUSTANCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_sustanciapsicotropicatipo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 160px; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_sustanciapsicotropicafrecuencia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px; font-size: 12px">PROBLEMAS RELACIONADOS CON EL CONSUMO DE ALCOHOL O SUSTANCIAS PSICOTROPICAS</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">FAMILIARES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_familiares" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">LABORAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_laborales" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">ECONOMICOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_economicos" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SALUD</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_salud" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">LEGALES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_legales" runat="server" />
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
                                    <asp:TextBox runat="server" ID="txt_miembroactivoseconomicamente" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SITUACIÓN LABORAL DEL CONYUGUE</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_situacionlaboralconyugue" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
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
                                            <asp:TextBox runat="server" ID="txt_totalingresos1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ALIMENTACION</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_alimentación" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIVIENDA</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_vivienda" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EDUCACION</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_educación" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SERVICIOS BASICOS</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_serviciosbasicos" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SALUD</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_salud" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos6" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda6" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros6" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MOVILIZACION</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_movilización" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos7" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda7" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros7" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DEUDAS</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_deudas" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: white" ColumnSpan="2">
                                            <asp:TextBox runat="server" ID="txt_totalingresos8" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_ayuda8" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otros8" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTROS</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_otrospensiones" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
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
                                            <asp:TextBox runat="server" ID="txt_biencasa" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DEPARTAMENTO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_biendepartamento" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VEHICULO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienvehiculo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TERRENO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienterreno" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NEGOCIO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienegocio" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUEBLES Y ENSERES</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:TextBox runat="server" ID="txt_bienmueblesyenseres" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent; text-align: center"></asp:TextBox>
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
                                    <asp:CheckBox ID="cb_dineroahorrosi" OnCheckedChanged="cb_dineroahorrosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dineroahorrono" OnCheckedChanged="cb_dineroahorrono_CheckedChanged" AutoPostBack="true" runat="server" />
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
                                    <asp:CheckBox ID="cb_unifamiliar" OnCheckedChanged="cb_unifamiliar_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MULTIFAMILIAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_multifamiliar" OnCheckedChanged="cb_multifamiliar_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_otrodescripcionviviendafamilia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">TENENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PROPIA SIN DEUDA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_propiasindeuda" OnCheckedChanged="cb_propiasindeuda_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ARRENDADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_arrendada" OnCheckedChanged="cb_arrendada_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DE FAMILIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_defamilia" OnCheckedChanged="cb_defamilia_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white" RowSpan="2">
                                    <asp:TextBox runat="server" ID="txt_otratenencia" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">HIPOTECADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_hipotecada" OnCheckedChanged="cb_hipotecada_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PRESTADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_prestada" OnCheckedChanged="cb_prestada_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ANTICRESIS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_anticreces" OnCheckedChanged="cb_anticreces_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIPO:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CASA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipocasa" OnCheckedChanged="cb_tipocasa_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SUIT</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tiposuit" OnCheckedChanged="cb_tiposuit_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MEDIAGUA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipomediagua" OnCheckedChanged="cb_tipomediagua_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DEPARTAMENTO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipodepartamento" OnCheckedChanged="cb_tipodepartamento_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PIEZA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_tipopieza" OnCheckedChanged="cb_tipopieza_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_otrotipodecasa" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">DISTRIBUCION:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">HABITACION</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_habitacion" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_sala" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BAÑO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_baño" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">GARAGE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_garage" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">OTRO ESPECIFIQUE:</asp:TableCell>
                                <asp:TableCell Style="background-color: white" RowSpan="2">
                                    <asp:TextBox runat="server" ID="txt_otradistribucioncasa" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">COMEDOR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_comedor" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">COCINA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_cocina" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PATIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_patio" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BODEGA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_bodega" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px; font-size: 12px">¿DISPONE VEHICULO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vehiculosi" OnCheckedChanged="cb_vehiculosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vehiculono" OnCheckedChanged="cb_vehiculono_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿HACE USO DEL RECORRIDO INSTITUCIONAL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 20px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_recorridosi" OnCheckedChanged="cb_recorridosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 20px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_recorridono" OnCheckedChanged="cb_recorridono_CheckedChanged" AutoPostBack="true" runat="server" />
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
                                    <asp:TextBox runat="server" ID="txt_nomapellidos1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento1" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento2" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento3" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad3" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento4" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad4" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_nomapellidos5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_parentesco5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_fechanacimiento5" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_edad5" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 175px; font-size: 12px">¿TIENE EN SU NUCLEO FAMILIAR ALGUNA PERSONA CON DISCAPACIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nucleodiscapacidadsi" OnCheckedChanged="cb_nucleodiscapacidadsi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nucleodiscapacidadno" OnCheckedChanged="cb_nucleodiscapacidadno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 175px; font-size: 12px">¿SE ENCUENTRA A CARGO DE ESTA PERSONA CON DISCAPACIDAD? CALIFICADA POR EL MSP o CONADIS</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliardiacapacitadosi" OnCheckedChanged="cb_acargofamiliardiacapacitadosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliardiacapacitadono" OnCheckedChanged="cb_acargofamiliardiacapacitadono_CheckedChanged" AutoPostBack="true" runat="server" />
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
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadonomape1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechacaducidadcarnet1" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadotipodiscapacidad1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoporcentajediscapacidad1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoparentesco1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechanacimiento1" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadonomape2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechacaducidadcarnet2" BorderStyle="None" Style="width: 100%; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadotipodiscapacidad2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoporcentajediscapacidad2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadoparentesco2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; color: black">
                                    <asp:TextBox runat="server" ID="txt_familiardiscapacitadofechanacimiento2" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 550px; font-size: 12px">¿SE ENCUENTRA REGISTRADA LA DEPENDENCIA DEL FAMILIAR EN EL MINISTERIO DE TRABAJO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dependenciaministeriotrabajosi" OnCheckedChanged="cb_dependenciaministeriotrabajosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dependenciaministeriotrabajono" OnCheckedChanged="cb_dependenciaministeriotrabajono_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">Tiempo:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_dependenciaministeriotrabajotiempo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">Nº CARNET MINISTERIO DE TRABAJO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_numcarnetMSP" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 550px; font-size: 12px">¿SE ENCUENTRA A CARGO DE UN FAMILIAR CON ENFERMEDAD CATASTROICA O RARA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliarenfermedadrarasi" OnCheckedChanged="cb_acargofamiliarenfermedadrarasi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_acargofamiliarenfermedadrarano" OnCheckedChanged="cb_acargofamiliarenfermedadrarano_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIEMPO:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_acargofamiliarenfermedadraratiempo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIPO DE ENFERMEDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_familiarenfermedadraratipo" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
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
                                    <asp:CheckBox ID="cb_hogar" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">PASEOS FAMILIARES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_paseosfamiliares" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ESTUDIOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_estudios" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ACTIVIDADES ARTISTICAS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_actividadesartisticas" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OTROS:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_otraactividad" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent" placeholder="Indique cual"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 350px; font-size: 12px">¿REALIZA ALGUNA ACTIVIDAD ECONOMICA ADICIONAL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_actividadeconomicasi" OnCheckedChanged="cb_actividadeconomicasi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_actividadeconomicano" OnCheckedChanged="cb_actividadeconomicano_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 300px">DETALLE LA ACTIVIDAD QUE REALIZA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_actividadeconomicadetalle" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 250px">TIEMPO QUE DESTINA A LA ACTIVIDAD:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_actividadeconomicatiempodestina" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px; width: 300px">¿HACE CUANTO REALIZA LA ACTIVIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_actividadeconomicatiemporealiza" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿REALIZA ALGUNA ACTIVIDAD DEPORTIVA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_deportesi" OnCheckedChanged="cb_deportesi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_deporteno" OnCheckedChanged="cb_deporteno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">DETALLE LA ACTIVIDAD QUE REALIZA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_especifiquedeporte" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">FRECUENCIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_frecuenciadeporte" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿DESDE QUE EDAD PRACTICA ESTA ACTIVIDAD?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_edadpracticadeporte" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿HA SUFRIDO ALGUNA LESION?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lesionsi" OnCheckedChanged="cb_lesionsi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_lesionno" OnCheckedChanged="cb_lesionno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">TIPO DE LESION:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tipolesion" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EDAD A LA QUE SUFRIO LA LESION:</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_edadlesion" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿RECIBIO ALGUN TRATAMIENTO O REHABILITACION?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tratamientosi" OnCheckedChanged="cb_tratamientosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_tratamientono" OnCheckedChanged="cb_tratamientono_CheckedChanged" AutoPostBack="true" runat="server" />
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
                                    <asp:CheckBox ID="cb_nuclear" OnCheckedChanged="cb_nuclear_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">AMPLIADA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_ampliada" OnCheckedChanged="cb_ampliada_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MONOPARENTAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_monoparental" OnCheckedChanged="cb_monoparental_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIVE SOLO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vivesolo" OnCheckedChanged="cb_vivesolo_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIVE CON AMIGOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_viveconamigos" OnCheckedChanged="cb_viveconamigos_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">FAMILIA SIN HIJOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_familiasinhijos" OnCheckedChanged="cb_familiasinhijos_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EVALUACION DEL NIVEL DE RELACION FAMILIAR:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarmuybuena" OnCheckedChanged="cb_relacionfamiliarmuybuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarbuena" OnCheckedChanged="cb_relacionfamiliarbuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarregular" OnCheckedChanged="cb_relacionfamiliarregular_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionfamiliarmala" OnCheckedChanged="cb_relacionfamiliarmala_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_relacionfamiliarporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EVALUACION DEL NIVEL DE RELACION DE PAREJA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejamuybuena" OnCheckedChanged="cb_relacionparejamuybuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejabuena" OnCheckedChanged="cb_relacionparejabuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejaregular" OnCheckedChanged="cb_relacionparejaregular_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionparejamala" OnCheckedChanged="cb_relacionparejamala_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_relacionparejaporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">EVALUACION DEL NIVEL DE RELACION CON LOS HIJOS:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosmuybuena" OnCheckedChanged="cb_relacionconhijosmuybuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosbuena" OnCheckedChanged="cb_relacionconhijosbuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosregular" OnCheckedChanged="cb_relacionconhijosregular_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_relacionconhijosmala" OnCheckedChanged="cb_relacionconhijosmala_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_relacionconhijosporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px" RowSpan="2">PROBLEMAS FAMILIARES:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ECONOMICOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_economico" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">COMUNICACION</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_comunicacion" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CONYUGALES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_conyugales" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">CRIANZA DE HIJOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_crianzadehijos" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ADICCIONES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_adicciones" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA FISICA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_fisica" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA PSICOLOGICA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_psicologica" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA VERBAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_verbal" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">VIOLENCIA SEXUAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_sexual" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OBSERVACIONES</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_observacionesfamiliares" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px; font-size: 12px">¿CADA MIEMBRO DE LA FAMILIA CUMPLE CON SU ROL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_rolfamiliarsi" OnCheckedChanged="cb_rolfamiliarsi_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px; font-size: 12px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_rolfamiliarno" OnCheckedChanged="cb_rolfamiliarno_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">NIVEL DE SALUD DE LA FAMILIA:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MUY BUENO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarmuybuena" OnCheckedChanged="cb_nivelsaludfamiliarmuybuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">BUENO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarbuena" OnCheckedChanged="cb_nivelsaludfamiliarbuena_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarregular" OnCheckedChanged="cb_nivelsaludfamiliarregular_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">MALO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_nivelsaludfamiliarmala" OnCheckedChanged="cb_nivelsaludfamiliarmala_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">¿POR QUE?</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_nivelsaludfamiliarporque" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px; font-size: 12px">¿CONSIDERA QUE SU FAMILIA ES?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">FUNCIONAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_funcional" OnCheckedChanged="cb_funcional_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px; font-size: 12px">DISFUNCIONAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_disfuncional" OnCheckedChanged="cb_disfuncional_CheckedChanged" AutoPostBack="true" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">OBSERVACIONES</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_observacionesgenerales" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; font-size: 12px">ALGUNA INFORMACION ADICIONAL QUE LA INSTITUCION DEBA CONOCER</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_informacionadicional" BorderStyle="None" Style="width: 100%; font-family: Arial; font-size: 12px; font-family: Arial; font-size: 12px; text-align: center" BackColor="white" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                                            <asp:CheckBox ID="cb_certificosi" OnCheckedChanged="cb_certificosi_CheckedChanged" AutoPostBack="true" runat="server" />
                                        </asp:TableCell>
                                        <asp:TableCell Style="background-color: #cdfecc; color: black">NO</asp:TableCell>
                                        <asp:TableCell Style="background-color: white">
                                            <asp:CheckBox ID="cb_certificono" OnCheckedChanged="cb_certificono_CheckedChanged" AutoPostBack="true" runat="server" />
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

                        <br />
                        <div class="row">
                            <div align="center">
                                <asp:FileUpload ID="FileUploadProfilePic" runat="server" onchange="showPreviewImage()" />
                            </div>
                        </div>
                        <div class="row">
                            <div align="center">
                                <asp:Image ID="imgPreview" ImageUrl="~/resources/images/croquis.png" runat="server" Width="600" Height="600" />
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="container" align="center">
                            <asp:Button CssClass="btn btn-success" ID="btn_guardar" OnClick="btn_guardar_Click" runat="server" Text="GUARDAR" Style="font-family: Arial; font-size: 12px" UseSubmitBehavior="False" ValidationGroup="GroupValidation" />
                            <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" OnClick="btn_cancelar_Click" runat="server" Text="CANCELAR" Style="font-family: Arial; font-size: 12px" UseSubmitBehavior="False" />
                            <asp:Button CssClass="btn btn-info" ID="btn_imprimir" OnClick="btn_imprimir_Click" runat="server" Text="IMPRIMIR" Style="font-family: Arial; font-size: 12px" UseSubmitBehavior="False" />
                        </div>
                    </div>
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
    <script type="text/javascript">
        function showPreviewImage() {
            var fileInput = document.getElementById('<%= FileUploadProfilePic.ClientID %>');
        var previewImage = document.getElementById('<%= imgPreview.ClientID %>');

            if (fileInput.files && fileInput.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    previewImage.src = e.target.result;
                    previewImage.style.display = "block";
                };
                reader.readAsDataURL(fileInput.files[0]);
            } else {
                previewImage.style.display = "none";
            }
        }
    </script>
</asp:Content>
