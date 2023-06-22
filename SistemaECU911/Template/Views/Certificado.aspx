<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Views/Principal.Master" AutoEventWireup="true" CodeBehind="Certificado.aspx.cs" Inherits="SistemaECU911.Template.Views.Certificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    HCL Certificado | Sistema Médico
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
                        <asp:TableCell Style="font-family: Arial; width: 400px" RowSpan="4">
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
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 15px" ColumnSpan="2">HISTORIA CLÍNICA OCUPACIONAL - CERTIFICADO</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <div class="list-group list-group-flush">
                    <asp:Table class="table table-bordered table-light" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="text-align: right; font-family: Arial; background-color: #cccdfe; font-size: 15px">FECHA Y HORA</asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: white">
                                <%--<asp:Timer ID="timerFechaHora"  OnTick="timerFechaHora_Tick" runat="server" Interval="15000"></asp:Timer>--%>
                                <asp:TextBox runat="server" ID="txt_fechahora" BorderStyle="None" Style="background-color: transparent; width: 100%; font-family: Arial; font-size: 15px; text-align: center; text-transform: uppercase" TextMode="DateTimeLocal"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
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
                                    <asp:TextBox runat="server" ID="txt_nomEmpresa" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_rucEmp" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_ciiu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_estableSalud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" Text="Consultorio Médico" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_numHClinica" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" OnTextChanged="txt_numHistoCli_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_numHClinica" runat="server" ForeColor="Red" ControlToValidate="txt_numHClinica" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
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
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="PRIMER APELLIDO" Style="width: 225px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO APELLIDO" Style="width: 225px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="PRIMER NOMBRE" Style="width: 225px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO NOMBRE" Style="width: 225px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="SEXO" Style="width: 100px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="PUESTO DE TRABAJO (CIUO)" Style="width: 350px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
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
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        B. DATOS GENERALES 
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="FECHA DE EMISIÓN:" Style="width: 350px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Style="width: 1000px; background-color: white; font-size: 14px" ColumnSpan="8">
                                    <asp:TextBox runat="server" ID="txt_fechaEmision" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="EVALUACIÓN:" Style="width: 350px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Text="INGRESO" Style="width: 150px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_ingreso" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_ingreso" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="PERIÓDICO" Style="width: 150px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_periodico" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_periodico" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="REINTEGRO" Style="width: 150px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_reintegro" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_reintegro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="RETIRO" Style="width: 150px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_retiro" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_retiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        C. APTITUD MÉDICA LABORAL
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="5" Text="Después de la valoración médica ocupacional se certifica que la persona en mención, es calificada como:" Style="text-align: left; background-color: white; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell ColumnSpan="3" Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_valoraMedicaOcupacional" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">APTO</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_apto" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_apto" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">APTO EN OBSERVACIÓN</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_aptoObservacion" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_aptoObservacion" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">APTO CON LIMITACIONES</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_aptoLimitaciones" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_aptoLimitaciones" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">NO APTO</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_noApto" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_noApto" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="8" Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_detaObservaAptiMedLaboral" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="4" Text="DETALLE DE OBSERVACIONES:"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        D.  EVALUACIÓN MÉDICA DE RETIRO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="El usuario se realizó la evaluación médica de retiro" Style="width: 850px; text-align: left; background-color: white; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="SI" Style="width: 100px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_siEvaMedRetiro" Checked="false" OnCheckedChanged="ckb_siEvaMedRetiro_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_siEvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="NO" Style="width: 100px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_noEvaMedRetiro" Checked="false" OnCheckedChanged="ckb_noEvaMedRetiro_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_noEvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: white; font-size: 14px" BorderColor="Transparent"></asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px" BorderColor="Transparent"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Condición del diagnóstico" Style="text-align: left; background-color: white; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="Presuntiva" Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_presuntivaCondiDiag" Checked="false" OnCheckedChanged="ckb_presuntivaCondiDiag_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_presuntivaEvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="Definitiva" Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_definitivaCondiDiag" Checked="false" OnCheckedChanged="ckb_definitivaCondiDiag_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_definitivaEvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="No aplica" Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_noAplicaCondiDiag" Checked="false" OnCheckedChanged="ckb_noAplicaCondiDiag_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_noAplicaEvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="La condición de salud esta relacionada con el trabajo" Style="width: 750px; text-align: left; background-color: white; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="SI" Style="width: 75px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_siCondiSalud" Checked="false" OnCheckedChanged="ckb_siCondiSalud_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_si2EvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="NO" Style="width: 75px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_noCondiSalud" Checked="false" OnCheckedChanged="ckb_noCondiSalud_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_no2EvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Text="No aplica" Style="width: 75px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_noAplicaCondiSalud" Checked="false" OnCheckedChanged="ckb_noAplicaCondiSalud_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_noAplica2EvaMedRetiro" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        E. RECOMENDACIONES 
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox runat="server" ID="txt_descripRecomendaciones" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" Text="DESCRIPCION:"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="container" style="font-family: Arial; text-align: center; text-transform: uppercase">
                    <p align="center">
                        <strong>"Con este documento certifico que el trabajador se ha sometido a la evaluación médica requerida para 
                            (el ingreso /la ejecución/ el reintegro y retiro) al puesto laboral y se ha informado sobre los riesgos relacionados 
                            con el trabajo emitiendo recomendaciones relacionadas con su estado de salud."</strong>
                    </p>
                </div>
                <div style="font-family: Arial; text-transform: uppercase">
                    <p align="left">
                        <strong>La presente certificación se expide con base en la historia ocupacional del usuario (a), la cual tiene carácter 
                            de confidencial.</strong>
                    </p>
                </div>
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        F. DATOS DEL PROFESIONAL DE SALUD
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 200px; background-color: #cdfecc; font-size: 15px">NOMBRES Y APELLIDOS</asp:TableCell>
                                <asp:TableCell Style="width: 400px; background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_profesional" CssClass="form-check" Style="width: 100%; text-transform: uppercase; border: none; background-color: transparent; text-align: center" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv_profesional" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_profesional" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 150px; background-color: #cdfecc; font-size: 15px">CÓDIGO</asp:TableCell>
                                <asp:TableCell Style="width: 200px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_codigo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 150px; background-color: #cdfecc; font-size: 15px">FIRMA Y SELLO</asp:TableCell>
                                <asp:TableCell Style="width: 200px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" BorderStyle="None" style="background-color: transparent; width: 100%; text-align:center; text-transform:uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div align="center">
                    <div class="card" style="width: 400px">
                        <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                            G. FIRMA DEL USUARIO    
                        </div>
                        <div class="list-group list-group-flush">
                            <asp:Label ID="Label24" runat="server" Text="" Style="height: 80px"></asp:Label>
                        </div>
                    </div>
                </div>
                <br />
                <div class="container" align="center">
                    <asp:Button CssClass="btn btn-warning" ID="btn_guardar" runat="server" Text="Guardar" OnClick="btn_guardacertificado_Click" UseSubmitBehavior="False" ValidationGroup="GroupValidation" />
                    <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelacertificado_Click" UseSubmitBehavior="False" />
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
</asp:Content>