<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Views/Principal.Master" AutoEventWireup="true" CodeBehind="Reintegro.aspx.cs" Inherits="SistemaECU911.Template.Views.Reintegro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    HCL Reintegro | Sistema Médico
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
                                    <img src="../Template Principal/images/ecu911.jpg" Style="width:50%; height:35%" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 20px" ColumnSpan="2">SERVICIO INTEGRADO DE SEGURIDAD SIS ECU 911</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 15px" ColumnSpan="2">GESTIÓN DE SEGURIDAD Y SALUD OCUPACIONAL</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 15px" ColumnSpan="2">HISTORIA CLÍNICA OCUPACIONAL - REINTEGRO</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        A. DATOS DEL ESTABLECIMIENTO - EMPRESA Y USUARIO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="INSTITUCIÓN DEL SISTEMA O NOMBRE DE LA EMPRESA" Style="width: 375px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="RUC" Style="width: 150px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="CIIU" Style="width: 150px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="ESTABLECIMIENTO DE SALUD" Style="width: 250px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="NÚMERO DE HISTORIA CLÍNICA" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="NÚMERO DE ARCHIVO" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_nomEmpresa" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_rucEmp" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_ciiu" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_estableSalud" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase" Text="CONSULTORIO MÉDICO" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_numHClinica" OnTextChanged="txt_numHClinica_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" AutoPostBack="true" onkeypress="return SoloNumeros(event)" oninput="borrarMensaje()"></asp:TextBox>
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
                                    <asp:TextBox runat="server" ID="txt_numArchivo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="PRIMER APELLIDO" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO APELLIDO" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="PRIMER NOMBRE" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO NOMBRE" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="SEXO" Style="width: 75px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="EDAD (AÑOS)" Style="width: 75px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="PUESTO DE TRABAJO (CIUO)" Style="width: 350px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_priApellido" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_segApellido" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_priNombre" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_segNombre" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_sexo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px; width: 155px">
                                    <asp:TextBox runat="server" ID="txt_edad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_puestoTrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="FECHA DEL ÚLTIMO DÍA LABORAL" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="FECHA DE REINGRESO" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="TOTAL (DÍAS)" Style="width: 100px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="CAUSA DE SALIDA" Style="width: 800px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaUltiDiaLaboral" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaReingreso" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_total" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" TextMode="Number"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_causaSalida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        B. MOTIVO DE CONSULTA / CONDICIÓN DE REINTEGRO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox ID="txt_motivoconsultareintegro" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" Text="DESCRIPCION:" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        C. ENFERMEDAD ACTUAL
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox ID="txt_enfermedadactualreintegro" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" Text="DESCRIPCION:" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        D. CONSTANTES VITALES Y ANTROPOMETRÍA 
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="PRESIÓN ARTERIAL (mmHg)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="TEMPERATURA (°C)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="FRECUENCIA CARDIACA (Lat/min)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="SATURACIÓN DE OXÍGENO (O2%)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="FRECUENCIA RESPIRATORIA (fr/min)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="PESO (Kg)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="TALLA (cm)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="ÍNDICE DE MASA CORPORAL (kg/m2)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="PERÍMETRO ABDOMINAL(cm)" Style="background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_preArterial" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_temperatura" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_freCardica" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_satOxigeno" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_freRespiratoria" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_peso" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase" OnTextChanged="txt_peso_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_talla" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase" OnTextChanged="txt_talla_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_indMasCorporal" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_perAbdominal" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        E. EXAMEN FÍSICO REGIONAL
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="REGIONES" Style="width: 1400px; text-align: left; background-color: #cdfecc; font-size: 15px" ColumnSpan="15"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell RowSpan="3" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label1" runat="server" Text="1. Piel"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Cicatrices</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_cicatrices" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_cicatrices" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="3" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label2" runat="server" Text="3. Oído"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. C. auditivo externo</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_auditivoexterno" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_auditivoexterno" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="4" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label82" runat="server" Text="5. Nariz"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Tabique</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_tabique" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_tabique" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label83" runat="server" Text="8. Tórax"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Pulmones</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pulmones" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pulmones" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label84" runat="server" Text="11. Pelvis"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Pelvis</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pelvis" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pelvis" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Tatuajes</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_tatuajes" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_tatuajes" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Pabellón</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pabellon" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pabellon" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Cornetes</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_cornetes" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_cornetes" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Parrilla Costal</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_parrillacostal" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_parrillacostal" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Genitales</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_genitales" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_genitales" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Piel  y Faneras</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pielyfaneras" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pielyfaneras" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Tímpanos</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_timpanos" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_timpanos" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Mucosas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_mucosa" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_mucosa" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label85" runat="server" Text="9. Abdomen"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Vísceras</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_visceras" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_visceras" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="3" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label86" runat="server" Text="12. Extremidades"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Vascular</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_vascular" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_vascular" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell RowSpan="5" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label87" runat="server" Text="2. Ojos"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Párpados</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_parpados" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_parpados" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="5" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label88" runat="server" Text="4. Oro faringe"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Labios</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_labios" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_labios" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Senos paranasales</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_senosparanasales" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_senosparanasales" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Pared abdominal</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_paredabdominal" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_paredabdominal" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Miembros superiores</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_miembrosuperiores" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_miembrosuperiores" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Conjuntivas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_conjuntivas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_conjuntivas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Lengua</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_lengua" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_lengua" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label89" runat="server" Text="6. Cuello"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Tiroides / masas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_tiroides" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_tiroides" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="4" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label90" runat="server" Text="10. Columna"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Flexibilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_flexibilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_flexibilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Miembros inferiores</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_miembrosinferiores" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_miembrosinferiores" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Pupilas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pupilas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pupilas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Faringe</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_faringe" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_faringe" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Movilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_movilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_movilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Desviación</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" RowSpan="2" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_desviacion" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_desviacion" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="4" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label91" runat="server" Text="13. Neurológico"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Fuerza</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_fuerza" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_fuerza" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Córnea</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_cornea" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_cornea" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Amígdalas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_amigdalas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_amigdalas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label92" runat="server" Text="7. Tórax"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Mamas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_mamas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_mamas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Sensibilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_sensibilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_sensibilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">e. Motilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_motilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_motilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">e. Dentadura</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_dentadura" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_dentadura" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Corazón</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_corazon" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_corazon" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Dolor</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_dolor" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_dolor" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Marcha</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_marcha" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_marcha" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="text-align: left; background-color: white; font-size: 11px" ColumnSpan="7">CP = CON EVIDENCIA DE PATOLOGÍA:  MARCAR "X" Y DESCRIBIR EN LA SIGUIENTE SECCIÓN</asp:TableCell>
                                <asp:TableCell Style="text-align: left; background-color: white; font-size: 11px" ColumnSpan="5">SP = SIN EVIDENCIA DE PATOLOGÍA:  MARCAR "X" Y NO DESCRIBIR</asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Reflejos</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_reflejos" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_reflejos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="15" Style="background-color: white">
                                    <asp:TextBox ID="txt_observexamenfisicoregional" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" runat="server" Text="OBSERVACIONES:" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        F. RESULTADOS DE EXÁMENES (IMAGEN, LABORATORIO Y OTROS)
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 400px; background-color: #cdfecc; font-size: 15px">EXAMEN </asp:TableCell>
                                <asp:TableCell Style="width: 150px; background-color: #cdfecc; font-size: 15px">FECHA</asp:TableCell>
                                <asp:TableCell Style="width: 800px; background-color: #cdfecc; font-size: 15px">RESULTADO</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_examen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaexamen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_resultadoexamen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_examen2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaexamen2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_resultadoexamen2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_examen3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaexamen3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_resultadoexamen3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3" Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_observacionexamen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" Text="OBSERVACIONES:" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        G. DIAGNÓSTICO  
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" Style="text-align: end; background-color: #cccdfe; font-size:15px" >PRE= PRESUNTIVO          DEF= DEFINITIVO</asp:TableCell>
                                <asp:TableCell Style="width: 200px; background-color: #cccdfe; font-size: 15px">CIE</asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: #cccdfe; font-size: 15px">PRE</asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: #cccdfe; font-size: 15px">DEF</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 50px; background-color: #cdfecc; font-size: 15px" Text="1"></asp:TableCell>
                                <asp:TableCell Style="width: 1000px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descripdiagnostico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" placeholder="DESCRIPCION" OnTextChanged="txt_descripdiagnostico_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerCie10"
                                        TargetControlID="txt_descripdiagnostico" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_cie" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pre" Checked="false" OnCheckedChanged="ckb_pre_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pre" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_def" Checked="false" OnCheckedChanged="ckb_def_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_def" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 50px; background-color: #cdfecc; font-size: 15px" Text="2"></asp:TableCell>
                                <asp:TableCell Style="width: 1000px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descripdiagnostico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" placeholder="DESCRIPCION" OnTextChanged="txt_descripdiagnostico2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerCie10"
                                        TargetControlID="txt_descripdiagnostico2" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_cie2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pre2" Checked="false" OnCheckedChanged="ckb_pre2_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pre2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_def2" Checked="false" OnCheckedChanged="ckb_def2_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_def2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 50px; background-color: #cdfecc; font-size: 15px" Text="3"></asp:TableCell>
                                <asp:TableCell Style="width: 1000px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descripdiagnostico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" placeholder="DESCRIPCION" OnTextChanged="txt_descripdiagnostico3_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerCie10"
                                        TargetControlID="txt_descripdiagnostico3" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_cie3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pre3" Checked="false" OnCheckedChanged="ckb_pre3_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pre3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_def3" Checked="false" OnCheckedChanged="ckb_def3_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_def3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        H. APTITUD MÉDICA PARA EL TRABAJO  
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">APTO</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_apto" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_apto" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">APTO EN OBSERVACIÓN</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_aptoobservacion" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_aptoobservacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">APTO CON LIMITACIONES</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_aptolimitacion" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_aptolimitacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">NO APTO</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_noapto" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_noapto" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #ccffff; font-size: 15px; text-transform: uppercase">Observación</asp:TableCell>
                                <asp:TableCell ColumnSpan="7" Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_observacionaptitud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #ccffff; font-size: 15px; text-transform: uppercase">Limitación</asp:TableCell>
                                <asp:TableCell ColumnSpan="7" Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_limitacionaptitud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #ccffff; font-size: 15px; text-transform: uppercase">Reubicación</asp:TableCell>
                                <asp:TableCell ColumnSpan="7" Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_reubicacionaptitud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        I. RECOMENDACIONES Y/O TRATAMIENTO
                    </div>
                    <div class="list-group list-group-flush" style="background-color: white">
                        <asp:TextBox ID="txt_descripciontratamientoreintegro" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform:uppercase" runat="server" Text="DESCRIPCION:" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="container">
                    <p align="center">
                        <strong>CERTIFICO QUE LO ANTERIORMENTE EXPRESADO EN RELACIÓN A MI ESTADO DE SALUD ES VERDAD. SE ME HA INFORMADO LAS MEDIDAS PREVENTIVAS
                            A TOMAR PARA DISMINUIR O MITIGAR LOS RIESGOS RELACIONADOS CON MI ACTIVIDAD LABORAL.</strong>
                    </p>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        J. DATOS DEL PROFESIONAL 
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 100px; background-color: #cdfecc; font-size: 15px">FECHA Y HORA</asp:TableCell>
                                <asp:TableCell Style="width: 150px; background-color: white; font-size: 14px">
                                    <%--<asp:Timer ID="timerFechaHora"  OnTick="timerFechaHora_Tick" runat="server" Interval="15000"></asp:Timer>--%>
                                    <asp:TextBox runat="server" BorderStyle="None" ID="txt_fechahora" TextMode="DateTimeLocal" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: #cdfecc; font-size: 15px">NOMBRES Y APELLIDOS</asp:TableCell>
                                <asp:TableCell Style="width: 375px; background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_profesional" CssClass="form-check" Style="width: 100%; text-align:center; border: none; background-color: transparent; text-transform:uppercase" onchange="borrarMensaje();" runat="server"></asp:DropDownList>
                                     <asp:Label ID="lbl_profesional" ForeColor="Red" runat="server"></asp:Label>
<%--                                    <asp:RequiredFieldValidator ID="rfv_profesional" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_profesional" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: #cdfecc; font-size: 15px">CÓDIGO</asp:TableCell>
                                <asp:TableCell Style="width: 125px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" BorderStyle="None" ID="txt_codigoDatProf" Style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: #cdfecc; font-size: 15px">FIRMA Y SELLO</asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: white; font-size: 14px">
                                     <asp:TextBox runat="server" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div align="center">
                    <div class="card" style="width: 400px">
                        <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                            K. FIRMA DEL USUARIO
                        </div>
                        <div class="list-group list-group-flush">
                            <asp:Label ID="Label24" runat="server" Text="" Style="height: 80px"></asp:Label>
                        </div>
                    </div>
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
            var lblProfesional = document.getElementById("<%= lbl_profesional.ClientID %>");

            if (lblNumHClinica) {
                lblNumHClinica.innerHTML = "";
            }
          
            if (lblProfesional) {
                lblProfesional.innerHTML = "";
            }
        }
    </script>



</asp:Content>

