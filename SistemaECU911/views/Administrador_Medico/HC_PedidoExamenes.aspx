<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="HC_PedidoExamenes.aspx.cs" Inherits="SistemaECU911.Template.Views.PedidoExamenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    HCL Pedido Examenes | Sistema Médico
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
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 15px" ColumnSpan="2">HOJA DE PEDIDO DE EXAMENES</asp:TableCell>
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
                                <asp:TableCell Text="INSTITUCIÓN DEL SISTEMA O NOMBRE DE LA EMPRESA" Style="width: 375px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="RUC" Style="width: 150px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="CIIU" Style="width: 150px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="ESTABLECIMIENTO DE SALUD" Style="width: 250px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="NÚMERO DE HISTORIA CLÍNICA" Style="width: 200px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="NÚMERO DE ARCHIVO" Style="width: 200px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_nombreEmp" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_rucEmp" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_ciiu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_estSalud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" BorderStyle="None" ID="txt_numHClinica" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" OnTextChanged="txt_numHClinica_TextChanged" AutoPostBack="true" onkeypress="return SoloNumeros(event)" oninput="borrarMensaje()"></asp:TextBox>
                                    <asp:Label ID="lbl_numHClinica" ForeColor="Red" runat="server"></asp:Label>
<%--                                    <asp:RequiredFieldValidator ID="rfv_numHClinica" runat="server" ForeColor="Red" ControlToValidate="txt_numHClinica" ErrorMessage="CAMPO OBLIGATORIO"></asp:RequiredFieldValidator>--%>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerNumHClinica"
                                        TargetControlID="txt_numHClinica" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" BorderStyle="None" ID="txt_numArchivo" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="PRIMER APELLIDO" Style="width: 300px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO APELLIDO" Style="width: 300px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="PRIMER NOMBRE" Style="width: 300px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="SEGUNDO NOMBRE" Style="width: 300px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
                                <asp:TableCell Text="EDAD" Style="width: 100px; background-color: #cdfecc; font-size: 15px; text-transform: uppercase"></asp:TableCell>
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
                                <asp:TableCell Style="background-color: white; font-size: 14px; width: 155px">
                                    <asp:TextBox runat="server" ID="txt_edad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <div class="card border-1">
                    <div class="card-body">
                        <div class="row">
                            <div class="col table-responsive" id="HEMATOLOGIA">
                                <b>HEMATOLOGIA</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_bioHematica" Text="&nbsp; &nbsp; Biometrica Hematica" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_hematocrito" Text="&nbsp; &nbsp; Hematocrito" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_hemoglobina" Text="&nbsp; &nbsp; Hemoglobina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_vsg" Text="&nbsp; &nbsp; VSG" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="ELECTROLITOS" style="height: 100%">
                                <b>ELECTROLITOS</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_Na" Text="&nbsp; &nbsp; Na - K - Ci" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_calIonico" Text="&nbsp; &nbsp; Calcio Ionico" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_calTotal" Text="&nbsp; &nbsp; Calcio Total" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_magnesio" Text="&nbsp; &nbsp; Magnesio" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_fosforo" Text="&nbsp; &nbsp; Fosforo" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="TUMORALES">
                                <b>MARCADORES TUMORALES</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_ca125" Text="&nbsp; &nbsp; CA 125" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_he4" Text="&nbsp; &nbsp; HE 4" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_indRoma" Text="&nbsp; &nbsp; Indice Roma" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_afp" Text="&nbsp; &nbsp; AFP" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_cea" Text="&nbsp; &nbsp; CEA" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_ca153" Text="&nbsp; &nbsp; CA 15-3" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_ca199" Text="&nbsp; &nbsp; CA 19-9" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_tiroglobulina" Text="&nbsp; &nbsp; Tiroglobulina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_psa" Text="&nbsp; &nbsp; PSA" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col table-responsive" id="INMUNOHEMATOLOGIA" style="margin-top: -8rem;">
                                <b>INMUNOHEMATOLOGIA</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_cooDirecto" Text="&nbsp; &nbsp; Coombs Directo" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_cooIndirecto" Text="&nbsp; &nbsp; Coombs Indirecto" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_grSanguineo" Text="&nbsp; &nbsp; Grupo Sanguineo y Factor RH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_celulasLE" Text="&nbsp; &nbsp; Celulas L.E." TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="SEROLOGIA" style="margin-top: -7rem;">
                                <b>SEROLOGIA</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_pcrCuantitativo" Text="&nbsp; &nbsp; PCR Cuantitativo" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_frLatex" Text="&nbsp; &nbsp; FR Latex" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_asto" Text="&nbsp; &nbsp; ASTO" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_aglutinaciones" Text="&nbsp; &nbsp; Aglutinaciones" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_vdrl" Text="&nbsp; &nbsp; V.D.R.L" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="MICROBIOLOGIA">
                                <b>MICROBIOLOGIA</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_muestra" Text="&nbsp; &nbsp; Muestra de:" TextAlign="Right" Style="text-transform: uppercase" Checked="false" OnCheckedChanged="ckb_muestra_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <asp:TextBox ID="txt_muestra" CssClass="border-bottom border-dark" Style="border: none; width: 150px; text-transform: uppercase" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_gram" Text="&nbsp; &nbsp; Gram" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_fresco" Text="&nbsp; &nbsp; Fresco" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 2rem; text-transform: uppercase" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_koh" Text="&nbsp; &nbsp; KOH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_culAntibiograma" Text="&nbsp; &nbsp; Cultivo y Antibiograma" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col table-responsive" id="COAGULACION" style="margin-top: -7rem;">
                                <b>COAGULACION</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_plaquetas" Text="&nbsp; &nbsp; Plaquetas" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_fibrinogeno" Text="&nbsp; &nbsp; Fibrinogeno" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_tp" Text="&nbsp; &nbsp; T.P" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_ttp" Text="&nbsp; &nbsp; T.T.P" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_inr" Text="&nbsp; &nbsp; I.N.R" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_tiempCoagulacion" Text="&nbsp; &nbsp; Tiempo de Coagulacion" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_tiempSangria" Text="&nbsp; &nbsp; Tiempo de Sangria" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_antiLupico" Text="&nbsp; &nbsp; Anticoagulante Lupico" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_dimeroD" Text="&nbsp; &nbsp; Dimero D" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="HORMONAS" style="margin-top: -5rem;">
                                <b>HORMONAS</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_lh" Text="&nbsp; &nbsp; LH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_fsh" Text="&nbsp; &nbsp; FSH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_estradiol" Text="&nbsp; &nbsp; Estradiol (E2)" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_progesterona" Text="&nbsp; &nbsp; Progesterona (P4)" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_prolactina" Text="&nbsp; &nbsp; Prolactina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_testosterona" Text="&nbsp; &nbsp; Testosterona" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_dheas" Text="&nbsp; &nbsp; DHEAS" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_cortisol" Text="&nbsp; &nbsp; Cortisol" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_insulina" Text="&nbsp; &nbsp; Insulina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_peptidoC" Text="&nbsp; &nbsp; Peptido C" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_indHoma" Text="&nbsp; &nbsp; Indice HOMA" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_bhcg" Text="&nbsp; &nbsp; BhCG" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_t3" Text="&nbsp; &nbsp; T3" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_fT4" Text="&nbsp; &nbsp; fT4" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_tsh" Text="&nbsp; &nbsp; TSH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_17Progesterona" Text="&nbsp; &nbsp; 17 OH Progesterona" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_hgh" Text="&nbsp; &nbsp; HGH (H. de Crecimiento)" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="ESPECIALES" style="margin-top: 0.5rem;">
                                <b>ESTUDIOS ESPECIALES</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_esperCompleto" Text="&nbsp; &nbsp; Espermatograma completo" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_cristalografia" Text="&nbsp; &nbsp; Cristalografia" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_screenPrenatal" Text="&nbsp; &nbsp; Screening Prenatal" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col table-responsive" id="SANGUINEA" style="margin-top: -15rem;">
                                <b>QUIMICA SANGUINEA</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_gluBasal" Text="&nbsp; &nbsp; Glucosa Basal" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_urea" Text="&nbsp; &nbsp; Urea" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_bum" Text="&nbsp; &nbsp; BUM" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_creatinina" Text="&nbsp; &nbsp; Creatinina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_acUrico" Text="&nbsp; &nbsp; Ac.Urico" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_colesTotal" Text="&nbsp; &nbsp; Colesterol Total" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="row">
                                    <div class="form-check">
                                        <asp:CheckBox ID="ckb_hdlc" Text="&nbsp; &nbsp; HDLc" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0.75rem; text-transform: uppercase" />
                                        <asp:CheckBox ID="ckb_ldlc" Text="&nbsp; &nbsp; LDLc" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 2rem; text-transform: uppercase" />
                                    </div>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_triglicerido" Text="&nbsp; &nbsp; Triglicerido" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_biliTotal" Text="&nbsp; &nbsp; Bilirrubina Total" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_biliDirecta" Text="&nbsp; &nbsp; Bilirrubina Directa" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_biliindirecta" Text="&nbsp; &nbsp; Bilirrubina Indirecta" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_proTotales" Text="&nbsp; &nbsp; Proteinas Totales" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_albumina" Text="&nbsp; &nbsp; Albumina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_globulina" Text="&nbsp; &nbsp; Globulina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_testOsullivan" Text="&nbsp; &nbsp; Test de Osullivan" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_glucosa2h" Text="&nbsp; &nbsp; Glucosa 2h pp" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_curvaTolerancia" Text="&nbsp; &nbsp; Curva de Tolerancia" TextAlign="Right" Style="text-transform: uppercase" Checked="false" OnCheckedChanged="ckb_curvaTolerancia_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <div class="form-check" style="display: flex">
                                        <asp:Label class="form-check-label" for="glu" runat="server" Text="Glucosa:" Style="margin-left: 0.03rem; font-size: 14px"></asp:Label>
                                        <asp:TextBox ID="txt_glucosa" CssClass="border-bottom border-dark" BorderStyle="None" Style="background-color: transparent; width: 50px; text-transform: uppercase" runat="server" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                                        <asp:Label class="form-check-label" for="horas" runat="server" Text="Horas" Style="margin-left: -0.03rem; font-size: 14px"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_hemoGlicosilada" Text="&nbsp; &nbsp; Hemoglobina Glicosilada" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_hierroSerico" Text="&nbsp; &nbsp; Hierro Sérico" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_ferritina" Text="&nbsp; &nbsp; Ferritina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_transferrina" Text="&nbsp; &nbsp; Transferrina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="INMUNOLOGIA" style="margin-top: 0.5rem;">
                                <b>INMUNOLOGIA</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_iProlactina" Text="&nbsp; &nbsp; Prolactina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_antiNucleares" Text="&nbsp; &nbsp; Anti Nucleares (ANA)" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_antiDna" Text="&nbsp; &nbsp; Anti DNA" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="col form-check">
                                    <asp:CheckBox ID="ckb_antiFosfolípidos" Text="&nbsp; &nbsp; Anti Fosfolípidos" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_iggAntiFosfolipidos" Text="&nbsp;IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0.7rem" />
                                    <asp:CheckBox ID="ckb_igmAntiFosfolipidos" Text="&nbsp;IgM" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                    <asp:CheckBox ID="ckb_igaAntiFosfolipidos" Text="&nbsp;IgA" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_antiCardioLipinas" Text="&nbsp; &nbsp; Anti Cardiolipinas" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_iggAntiCardio" Text="&nbsp;IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0.2rem" />
                                    <asp:CheckBox ID="ckb_igmAntiCardio" Text="&nbsp;IgM" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                    <asp:CheckBox ID="ckb_igaAntiCardio" Text="&nbsp;IgA" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_b2Glicoproteína" Text="&nbsp; &nbsp; B2 Glicoproteína" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_iggB2Glico" Text="&nbsp;IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 1rem" />
                                    <asp:CheckBox ID="ckb_igmB2Glico" Text="&nbsp;IgM" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_antiGliadina" Text="&nbsp; &nbsp; Anti Gliadina" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_iggAntiGliadina" Text="&nbsp;IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 2.6rem" />
                                    <asp:CheckBox ID="ckb_igaAntiGliadina" Text="&nbsp;IgA" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 3rem" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_antiAnexiaV" Text="&nbsp; &nbsp; Anti Anexina V" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_iggantiAnexiaV" Text="&nbsp;IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 2.1rem" />
                                    <asp:CheckBox ID="ckb_igmantiAnexiaV" Text="&nbsp;IgM" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_antiTPO" Text="&nbsp; &nbsp; Anti TPO (microsomales)" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_antiTiroglobulina" Text="&nbsp; &nbsp; Anti Tiroglobulina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_antiCCP" Text="&nbsp; &nbsp; Anti CCP" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="ORINA" style="margin-top: -19rem;">
                                <b>ORINA</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_emo" Text="&nbsp; &nbsp; EMO" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_CultAntibiograma" Text="&nbsp; &nbsp; Cultivo y Antibiograma" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_gramGotaFres" Text="&nbsp; &nbsp; Gram gota fresca" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_microalbuminuria" Text="&nbsp; &nbsp; Microalbuminuria" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col table-responsive" id="ENZIMAS" style="margin-top: 1rem;">
                                <b>ENZIMAS</b>
                                <div class="row">
                                    <div class="form-check col" style="margin-left: 0.75rem; text-transform: uppercase">
                                        <asp:CheckBox ID="ckb_tgo" Text="&nbsp; &nbsp; TGO" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    </div>
                                    <div class="form-check col">
                                        <asp:CheckBox ID="ckb_tgp" Text="&nbsp; &nbsp; TGP" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-check col" style="margin-left: 0.75rem; text-transform: uppercase">
                                        <asp:CheckBox ID="ckb_amilasa" Text="&nbsp; &nbsp; Amilasa" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    </div>
                                    <div class="form-check col">
                                        <asp:CheckBox ID="ckb_lipasa" Text="&nbsp; &nbsp; Lipasa" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-check col" style="margin-left: 0.75rem; text-transform: uppercase">
                                        <asp:CheckBox ID="ckb_cpk" Text="&nbsp; &nbsp; CPK" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    </div>
                                    <div class="form-check col">
                                        <asp:CheckBox ID="ckb_cpkMb" Text="&nbsp; &nbsp; CPK-MB" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    </div>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_ldh" Text="&nbsp; &nbsp; LDH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_fosfaAlcalina" Text="&nbsp; &nbsp; Fosfatasa Alcalina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_fosfaAcidaTotal" Text="&nbsp; &nbsp; Fosfatasa Ácida Total" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_fosfaAcidaProstatica" Text="&nbsp; &nbsp; Fosfatasa Ácida Prostática" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="INFECCIOSAS" style="margin-top: -0rem;">
                                <b>INMUNO - INFECCIOSAS</b>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_torch" Text="&nbsp; &nbsp; TORCH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_toxoGondii" Text="&nbsp; &nbsp; Toxoplasma gondii - Test de Avidez" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                </div>

                                <%--<div class="form-check col">
                                    <asp:CheckBox ID="CheckBox1" Text="&nbsp; &nbsp; Anti Anexina V" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                    <asp:CheckBox ID="CheckBox2" Text="&nbsp;IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 2.1rem" />
                                    <asp:CheckBox ID="CheckBox3" Text="&nbsp;IgM" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                </div>--%>

                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_clamyTrachomatis" Text="&nbsp; &nbsp; Clamydia Trachomatis" TextAlign="Right" Style="text-transform: uppercase; font-size: 14px" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_clamyTrachomatisIgG" Text="&nbsp; IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0.5rem" />
                                    <asp:CheckBox ID="ckb_clamyTrachomatisIgM" Text="&nbsp; IgM" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_hav" Text="&nbsp; &nbsp; HAV" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                    <asp:CheckBox ID="ckb_havIiG" Text="&nbsp; IgG" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 9.3rem" />
                                    <asp:CheckBox ID="ckb_havIiM" Text="&nbsp; IgM" TextAlign="Right" Checked="false" runat="server" Style="margin-left: 0rem" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_vih" Text="&nbsp; &nbsp; VIH" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_hbsAg" Text="&nbsp; &nbsp; HbsAg" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_hcv" Text="&nbsp; &nbsp; hcv" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_ftaAbs" Text="&nbsp; &nbsp; FTA - ABS" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="HECES" style="margin-top: -36rem;">
                                <b>HECES</b>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_coproparasitario" Text="&nbsp; &nbsp; Coproparasitario" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_coproSeriado" Text="&nbsp; &nbsp; Coproparasitario Seriado #" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_sangreOculta" Text="&nbsp; &nbsp; Sangre Oculta" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_pmn" Text="&nbsp; &nbsp; PMN" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_rotavirus" Text="&nbsp; &nbsp; Rotavirus" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_helicoPylori" Text="&nbsp; &nbsp; Helicobacter Pylori (Antigeno)" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col table-responsive" id="DROGAS" style="margin-top: 0rem;">
                                <b>DROGAS</b>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_fenobarbital" Text="&nbsp; &nbsp; Fenobarbital" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_teofilina" Text="&nbsp; &nbsp; Teofilina" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                                <div class="form-check col">
                                    <asp:CheckBox ID="ckb_acValproico" Text="&nbsp; &nbsp; Ac.Valproico" TextAlign="Right" Style="text-transform: uppercase" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="col table-responsive" id="OTROS" style="margin-top: 0rem;">
                                <b>OTROS</b>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_otros1" TextAlign="Right" Style="text-transform: uppercase" Checked="false" OnCheckedChanged="ckb_otros1_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <asp:TextBox ID="txt_otros1" CssClass="border-bottom border-dark" Style="border: none; text-transform: uppercase" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_otros2" TextAlign="Right" Style="text-transform: uppercase" Checked="false" OnCheckedChanged="ckb_otros2_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <asp:TextBox ID="txt_otros2" CssClass="border-bottom border-dark" Style="border: none; text-transform: uppercase" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="ckb_otros3" TextAlign="Right" Style="text-transform: uppercase" Checked="false" OnCheckedChanged="ckb_otros3_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <asp:TextBox ID="txt_otros3" CssClass="border-bottom border-dark" Style="border: none; text-transform: uppercase" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col table-responsive" id="FIRMA" style="margin-top: -32rem;">
                                <div class="card" style="width: 300px">
                                    <div class="card-header" align="center">
                                        FIRMA DEL MEDICO    
                                    </div>
                                    <div class="list-group list-group-flush">
                                        <asp:Label ID="Label24" runat="server" Text="" Style="height: 80px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="container" align="center">
                    <asp:Button CssClass="btn btn-warning" ID="btn_guardar" runat="server" Text="Guardar" OnClick="btn_guardar_Click" UseSubmitBehavior="False" />
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
