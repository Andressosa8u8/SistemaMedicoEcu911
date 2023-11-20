<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="HC_Inicial.aspx.cs" Inherits="SistemaECU911.Template.Views.Inicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    HCL Inicial | Sistema Médico
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

    <script type="text/javascript">
        function mostrarSweetAlertSSO1() {
            Swal.fire(
                'warning'
            );
        }
    </script>

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
                        <asp:TableCell Style="font-family: Arial; font-weight: bold; font-size: 15px" ColumnSpan="2">HISTORIA CLÍNICA OCUPACIONAL - INICIAL</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        A. DATOS DEL ESTABLECIMIENTO - EMPRESA Y USUARIO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-responsive table-light text-center" runat="server">
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
                                    <asp:TextBox ID="txt_ciiu" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true" Text="084110701"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_estableSalud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" Text="Consultorio Médico" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_numHClinica" BorderStyle="None" OnTextChanged="txt_numHClinica_TextChanged" AutoPostBack="true" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)" oninput="borrarMensaje()"></asp:TextBox>
                                    <asp:Label ID="lbl_numHClinica" ForeColor="Red" runat="server"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="rfv_numHClinica" runat="server" ForeColor="Red" ControlToValidate="txt_numHClinica" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>--%>
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
                                <asp:TableCell RowSpan="2" Text="PRIMER APELLIDO" Style="width: 165px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="SEGUNDO APELLIDO" Style="width: 175px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="PRIMER NOMBRE" Style="width: 165px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="SEGUNDO NOMBRE" Style="width: 175px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="SEXO" Style="width: 50px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="EDAD (AÑOS)" Style="width: 75px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell ColumnSpan="5" Text="RELIGIÓN" Style="width: 175px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="GRUPO SANGUÍNEO" Style="width: 125px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="LATERALIDAD" Style="width: 200px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 20px; background-color: #cdfecc">
                                    <asp:Label CssClass="in-column" ID="lbl_catolica" runat="server" Text="Católica"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 20px; background-color: #cdfecc">
                                    <asp:Label CssClass="in-column" ID="Label1" runat="server" Text="Evangélica"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 20px; background-color: #cdfecc">
                                    <asp:Label CssClass="in-column" ID="Label2" runat="server" Text="Testigos de Jehová"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 20px; background-color: #cdfecc">
                                    <asp:Label CssClass="in-column" ID="Label3" runat="server" Text="Mormona"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 20px; background-color: #cdfecc">
                                    <asp:Label CssClass="in-column" ID="Label4" runat="server" Text="Otras"></asp:Label>
                                </asp:TableCell>
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
                                <asp:TableCell Style="background-color: white; font-size: 14px; width: 155px">
                                    <asp:TextBox runat="server" ID="txt_edad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_catolica" Checked="false" OnCheckedChanged="ckb_catolica_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_catolica" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_evangelica" Checked="false" OnCheckedChanged="ckb_evangelica_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_evangelica" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_testigo" Checked="false" OnCheckedChanged="ckb_testigo_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_testigo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_mormona" Checked="false" OnCheckedChanged="ckb_mormona_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_mormona" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_otrareligion" Checked="false" OnCheckedChanged="ckb_otrareligion_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_otrareligion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_gruposanguineo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_lateralidad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="5" Text="ORIENTACION SEXUAL" Style="width: 175px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell ColumnSpan="5" Text="IDENTIDAD DE GENERO" Style="width: 175px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell ColumnSpan="4" Text=" DISCAPACIDAD" Style="width: 250px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="FECHA DE INGRESO AL TRABAJO <br /> (DD/MM/AAAA)" Style="width: 100px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="PUESTO DE TRABAJO (CIUO)" Style="width: 250px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                                <asp:TableCell RowSpan="2" Text="ÁREA DE TRABAJO" Style="width: 300px; background-color: #cdfecc; font-size: 15px"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label5" runat="server" Text="Lesbiana"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label6" runat="server" Text="Gay"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label7" runat="server" Text="Bisexual"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label8" runat="server" Text="Heterosexual"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label9" runat="server" Text="No sabe/No responde"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label10" runat="server" Text="Femenino"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label11" runat="server" Text="Masculino"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label12" runat="server" Text="Trans-femenino"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label13" runat="server" Text="Trans-masculino"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 15px; background-color: #cdfecc; font-size: 15px">
                                    <asp:Label CssClass="in-column" ID="Label14" runat="server" Text="No sabe/No responde"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 20px; background-color: #cdfecc">SI</asp:TableCell>
                                <asp:TableCell Style="width: 20px; background-color: #cdfecc">NO</asp:TableCell>
                                <asp:TableCell Style="width: 125px; background-color: #cdfecc">TIPO</asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: #cdfecc">%</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_lesbiana" Checked="false" OnCheckedChanged="cbk_lesbiana_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_lesbiana" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_gay" Checked="false" OnCheckedChanged="cbk_gay_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_gay" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_bisexual" Checked="false" OnCheckedChanged="cbk_bisexual_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_bisexual" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_heterosexual" Checked="false" OnCheckedChanged="cbk_heterosexual_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_heterosexual" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_noRespondeOriSex" Checked="false" OnCheckedChanged="cbk_noRespondeOriSex_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_noRespondeOriSex" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_femenino" Checked="false" OnCheckedChanged="cbk_femenino_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_femenino" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_masculino" Checked="false" OnCheckedChanged="cbk_masculino_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_masculino" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_transfemenino" Checked="false" OnCheckedChanged="cbk_transfemenino_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_transfemenino" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_transmasculino" Checked="false" OnCheckedChanged="cbk_transmasculino_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_transmasculino" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_noRespondeIdeGen" Checked="false" OnCheckedChanged="cbk_noRespondeIdeGen_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_noRespondeIdeGen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_sidiscapacidad" Checked="false" OnCheckedChanged="cbk_sidiscapacidad_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_sidiscapacidad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:CheckBox ID="cbk_nodiscapacidad" Checked="false" OnCheckedChanged="cbk_nodiscapacidad_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="txt_nodiscapacidad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_tipodiscapacidad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_porcentajediscapacidad" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaingresotrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_puestodetrabajociuo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="MultiLine" Rows="4" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_areadetrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" ReadOnly="true"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="ACTIVIDADES RELEVANTES AL PUESTO DE TRABAJO A OCUPAR" Style="width: 1400px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_actividadesrelevantes" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="row">
                        <div class="card-header col" style="margin-left: 0.8rem; background-color: #cccdfe; font-weight: bold">
                            B. MOTIVO DE CONSULTA                                           
                        </div>
                        <div class="card-header col" style="text-align: right; margin-right: 0.8rem; background-color: #cccdfe; font-size: 13px">
                            ANOTAR LA CAUSA DEL PROBLEMA EN LA VERSIÓN DEL INFORMANTE                                          
                        </div>
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox ID="txt_motivoconsultainicial" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" Text="DESCRIPCION:" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold">
                        C. ANTECEDENTES PERSONALES
                    </div>
                    <div class="card-header" style="background-color: #cdfecc; font-size: 15px">
                        ANTECEDENTES CLÍNICOS Y QUIRÚRGICOS
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox runat="server" ID="txt_antCliQuiDescripcion" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" Text="DESCRIPCION:"></asp:TextBox>
                    </div>
                    <div class="card" style="width: auto;">
                        <div class="card-header" style="background-color: #cdfecc; font-size: 15px">
                            ANTECEDENTES GINECO OBSTÉTRICOS
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell RowSpan="2" Style="width: 150px; background-color: #ccffff; font-size: 15px">MENARQUÍA</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 100px; background-color: #ccffff; font-size: 15px">CICLOS</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 100px; background-color: #ccffff; font-size: 15px">FECHA DE ULTIMA MENSTRUACIÓN <br /> DD/MM/AAAA </asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 75px; background-color: #ccffff; font-size: 15px">GESTAS</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 75px; background-color: #ccffff; font-size: 15px">PARTOS</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 75px; background-color: #ccffff; font-size: 15px">CESÁREAS</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 75px; background-color: #ccffff; font-size: 15px">ABORTOS</asp:TableCell>
                            <asp:TableCell ColumnSpan="2" Style="width: 100px; background-color: #ccffff; font-size: 15px">HIJOS</asp:TableCell>
                            <asp:TableCell ColumnSpan="2" Style="width: 125px; background-color: #ccffff; font-size: 15px">VIDA SEXUAL ACTIVA</asp:TableCell>
                            <asp:TableCell ColumnSpan="3" Style="width: 300px; background-color: #ccffff; font-size: 15px">METODO DE PLANIFICACIÓN FAMILIAR</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 100px; background-color: #ccffff; font-size: 15px">VIVOS</asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: #ccffff; font-size: 15px">MUERTOS</asp:TableCell>
                            <asp:TableCell Style="width: 25px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 25px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 30px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 30px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: #ccffff; font-size: 15px">TIPO</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_menarquiaAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_ciclosAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fechUltiMensAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_gestasAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_partosAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_cesareasAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_abortosAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_vivosAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_muertosAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siVidSexAntGinObste" Checked="false" OnCheckedChanged="ckb_siVidSexAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siVidSexAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noVidSexAntGinObste" Checked="false" OnCheckedChanged="ckb_noVidSexAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noVidSexAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siMetPlaniAntGinObste" Checked="false" OnCheckedChanged="ckb_siMetPlaniAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siMetPlaniAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noMetPlaniAntGinObste" Checked="false" OnCheckedChanged="ckb_noMetPlaniAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noMetPlaniAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tipoMetPlaniAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="width: 200px; background-color: #ccffff; font-size: 15px">EXAMENES REALIZADOS</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 125px; background-color: #ccffff; font-size: 15px">TIEMPO <br />(AÑOS)</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: #ccffff; font-size: 15px">RESULTADO</asp:TableCell>
                            <asp:TableCell Style="width: 200px; background-color: #ccffff; font-size: 15px">EXAMENES REALIZADOS</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 125px; background-color: #ccffff; font-size: 15px">TIEMPO <br />(AÑOS)</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: #ccffff; font-size: 15px">RESULTADO</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">PAPANICOLAOU</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siPapaniAntGinObste" Checked="false" OnCheckedChanged="ckb_siPapaniAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siPapaniAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noPapaniAntGinObste" Checked="false" OnCheckedChanged="ckb_noPapaniAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noPapaniAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempoPapaniAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_resultadoPapaniAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 15px">ECO MAMARIO</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siEcoMamaAntGinObste" Checked="false" OnCheckedChanged="ckb_siEcoMamaAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siEcoMamaAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noEcoMamaAntGinObste" Checked="false" OnCheckedChanged="ckb_noEcoMamaAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noEcoMamaAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempoEcoMamaAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_resultadoEcoMamaAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">COLPOSCOPIA</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siColposAntGinObste" Checked="false" OnCheckedChanged="ckb_siColposAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siColposAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noColposAntGinObste" Checked="false" OnCheckedChanged="ckb_noColposAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noColposAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempoColposAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_resultadoColposAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 15px">MAMOGRAFÍA</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siMamograAntGinObste" Checked="false" OnCheckedChanged="ckb_siMamograAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siMamograAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noMamograAntGinObste" Checked="false" OnCheckedChanged="ckb_noMamograAntGinObste_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noMamograAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempoMamograAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_resultadoMamograAntGinObste" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <div class="card" style="width: auto;">
                        <div class="card-header col" style="background-color: #cdfecc; font-size: 15px">
                            ANTECEDENTES REPRODUCTIVOS MASCULINOS
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell RowSpan="2" Style="width: 200px; background-color: #ccffff; font-size: 15px">EXAMENES REALIZADOS</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 50px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 50px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 125px; background-color: #ccffff; font-size: 15px">TIEMPO <br />(AÑOS)</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 250px; background-color: #ccffff; font-size: 15px">RESULTADO</asp:TableCell>
                            <asp:TableCell ColumnSpan="3" Style="width: 450px; background-color: #ccffff; font-size: 15px">MÉTODO DE PLANIFICACIÓN FAMILIAR</asp:TableCell>
                            <asp:TableCell ColumnSpan="2" Style="width: 150px; background-color: #ccffff; font-size: 15px">HIJOS</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 350px; background-color: #ccffff; font-size: 15px">TIPO</asp:TableCell>
                            <asp:TableCell Style="width: 75px; background-color: #ccffff; font-size: 15px">VIVOS</asp:TableCell>
                            <asp:TableCell Style="width: 75px; background-color: #ccffff; font-size: 15px">MUERTOS</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">ANTÍGENO PROSTÁTICO</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siExaRealiAntProstaAntReproMascu" Checked="false" OnCheckedChanged="ckb_siExaRealiAntProstaAntReproMascu_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siExaRealiAntProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noExaRealiAntProstaAntReproMascu" Checked="false" OnCheckedChanged="ckb_noExaRealiAntProstaAntReproMascu_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noExaRealiAntProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempoExaRealiAntProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_resultadoExaRealiAntProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siMetPlaniAntReproMascu" Checked="false" OnCheckedChanged="ckb_siMetPlaniAntReproMascu_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siMetPlaniAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noMetPlaniAntReproMascu" Checked="false" OnCheckedChanged="ckb_noMetPlaniAntReproMascu_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noMetPlaniAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tipo1MetPlaniAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_vivosHijosAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_muertosHijosAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">ECO PROSTÁTICO</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siExaRealiEcoProstaAntReproMascu" Checked="false" OnCheckedChanged="ckb_siExaRealiEcoProstaAntReproMascu_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siExaRealiEcoProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noExaRealiEcoProstaAntReproMascu" Checked="false" OnCheckedChanged="ckb_noExaRealiEcoProstaAntReproMascu_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noExaRealiEcoProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempoExaRealiEcoProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_resultadoExaRealiEcoProstaAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tipo2MetPlaniAntReproMascu" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <div class="card" style="width: auto;">
                        <div class="card-header col" style="background-color: #cdfecc; font-size: 15px">
                            HÁBITOS TÓXICOS 
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="width: 250px; background-color: #ccffff; font-size: 15px">CONSUMOS NOCIVOS</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: #ccffff; font-size: 15px">TIEMPO DE CONSUMO <br />(MESES)</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: #ccffff; font-size: 15px">CANTIDAD</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: #ccffff; font-size: 15px">EX CONSUMIDOR</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: #ccffff; font-size: 15px">TIEMPO DE ABSTINENCIA <br /> (MESES)</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">TABACO</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siConsuNociTabaHabToxi" Checked="false" OnCheckedChanged="ckb_siConsuNociTabaHabToxi_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siConsuNociTabaHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noConsuNociTabaHabToxi" Checked="false" OnCheckedChanged="ckb_noConsuNociTabaHabToxi_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noConsuNociTabaHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemConConsuNociTabaHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_cantiConsuNociTabaHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_exConsumiConsuNociTabaHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemAbstiConsuNociTabaHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">ALCOHOL</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siConsuNociAlcoHabToxi" Checked="false" OnCheckedChanged="ckb_siConsuNociAlcoHabToxi_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siConsuNociAlcoHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noConsuNociAlcoHabToxi" Checked="false" OnCheckedChanged="ckb_noConsuNociAlcoHabToxi_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noConsuNociAlcoHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemConConsuNociAlcoHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_cantiConsuNociAlcoHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_exConsumiConsuNociAlcoHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemAbstiConsuNociAlcoHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">OTRAS DROGAS</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siConsuNociOtrasDroHabToxi" Checked="false" OnCheckedChanged="ckb_siConsuNociOtrasDroHabToxi_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noConsuNociOtrasDroHabToxi" Checked="false" OnCheckedChanged="ckb_noConsuNociOtrasDroHabToxi_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemCon1ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_canti1ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_exConsumi1ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemAbsti1ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_otrasConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="_________________________"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemCon2ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_canti2ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_exConsumi2ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemAbsti2ConsuNociOtrasDroHabToxi" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <div class="card" style="width: auto;">
                        <div class="card-header" style="background-color: #cdfecc; font-size: 15px">
                            ESTILO DE VIDA
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="width: 400px; background-color: #ccffff; font-size: 15px">ESTILO</asp:TableCell>
                            <asp:TableCell Style="width: 75px; background-color: #ccffff; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 75px; background-color: #ccffff; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 400px; background-color: #ccffff; font-size: 15px">¿CUÁL?</asp:TableCell>
                            <asp:TableCell Style="width: 375px; background-color: #ccffff; font-size: 15px">TIEMPO/CANTIDAD</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 15px">ACTIVIDAD FÍSICA</asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siEstVidaActFisiEstVida" Checked="false" OnCheckedChanged="ckb_siEstVidaActFisiEstVida_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siEstVidaActFisiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noEstVidaActFisiEstVida" Checked="false" OnCheckedChanged="ckb_noEstVidaActFisiEstVida_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noEstVidaActFisiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_cualEstVidaActFisiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemCanEstVidaActFisiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell RowSpan="3" Style="background-color: white; font-size: 15px">MEDICACIÓN HABITUAL</asp:TableCell>
                            <asp:TableCell RowSpan="3" Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siEstVidaMedHabiEstVida" Checked="false" OnCheckedChanged="ckb_siEstVidaMedHabiEstVida_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siEstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell RowSpan="3" Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noEstVidaMedHabiEstVida" Checked="false" OnCheckedChanged="ckb_noEstVidaMedHabiEstVida_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noEstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_cual1EstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemCan1EstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_cual2EstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemCan2EstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_cual3EstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiemCan3EstVidaMedHabiEstVida" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        D. ANTECEDENTES DE TRABAJO
                    </div>
                    <div class="card-header" style="background-color: #cdfecc; font-size: 15px">
                        ANTECEDENTES DE EMPLEOS ANTERIORES
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell RowSpan="2" Style="width: 300px; background-color: #cdfecc; font-size: 15px">EMPRESA</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 200px; background-color: #cdfecc; font-size: 15px">PUESTO DE TRABAJO</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 350px; background-color: #cdfecc; font-size: 15px">ACTVIDADES QUE DESEMPEÑA</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 100px; background-color: #cdfecc; font-size: 15px">TIEMPO DE TRABAJO <br />(MESES)</asp:TableCell>
                            <asp:TableCell ColumnSpan="6" Style="width: 150px; background-color: #cdfecc; font-size: 15px">RIESGO</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 400px; background-color: #cdfecc; font-size: 15px">OBSERVACIONES</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 20px; background-color: #cdfecc; font-size: 15px">
                                <asp:Label CssClass="in-column" ID="Label15" runat="server" Text="FÍSICO"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 20px; background-color: #cdfecc; font-size: 15px">
                                <asp:Label CssClass="in-column" ID="Label16" runat="server" Text="MECÁNICO"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 20px; background-color: #cdfecc; font-size: 15px">
                                <asp:Label CssClass="in-column" ID="Label17" runat="server" Text="QUÍMICO"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 20px; background-color: #cdfecc; font-size: 15px">
                                <asp:Label CssClass="in-column" ID="Label18" runat="server" Text="BIÓLOGO"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 20px; background-color: #cdfecc; font-size: 15px">
                                <asp:Label CssClass="in-column" ID="Label19" runat="server" Text="ERGÓNOMICO"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 20px; background-color: #cdfecc; font-size: 15px">
                                <asp:Label CssClass="in-column" ID="Label20" runat="server" Text="PSICOSOCIAL"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_empresa" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestotrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_actdesempeña" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempotrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fisico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fisico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_mecanico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_mecanico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_quimico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_quimico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_biologico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_biologico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ergonomico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ergonomico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_psicosocial" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_psicosocial" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_obseantempleanteriores" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_empresa2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestotrabajo2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_actdesempeña2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempotrabajo2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fisico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fisico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_mecanico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_mecanico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_quimico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_quimico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_biologico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_biologico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ergonomico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ergonomico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_psicosocial2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_psicosocial2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_obseantempleanteriores2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_empresa3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestotrabajo3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_actdesempeña3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempotrabajo3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fisico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fisico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_mecanico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_mecanico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_quimico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_quimico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_biologico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_biologico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ergonomico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ergonomico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_psicosocial3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_psicosocial3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_obseantempleanteriores3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_empresa4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestotrabajo4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_actdesempeña4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_tiempotrabajo4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fisico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fisico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_mecanico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_mecanico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_quimico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_quimico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_biologico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_biologico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ergonomico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ergonomico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_psicosocial4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_psicosocial4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_obseantempleanteriores4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <div class="card" style="width: auto;">
                        <div class="card-header" style="background-color: #cdfecc; font-size: 15px">
                            ACCIDENTES DE TRABAJO (DESCRIPCIÓN)
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="width: 600px; background-color: white; font-size: 15px">FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE: </asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siAccTrabDescrip" Checked="false" OnCheckedChanged="ckb_siAccTrabDescrip_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siAccTrabDescrip" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: white; font-size: 15px">ESPECIFICAR</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_especificar" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="_________________" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noAccTrabDescrip" Checked="false" OnCheckedChanged="ckb_noAccTrabDescrip_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noAccTrabDescrip" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 75px; background-color: white; font-size: 15px">FECHA:</asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fecha" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="9" Style="background-color: white; font-size: 14px">
                                <asp:TextBox ID="txt_observaciones2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" Text="OBSERVACIONES:" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <div class="card" style="width: auto;">
                        <div class="card-header" style="background-color: #cdfecc; font-size: 15px">
                            ENFERMEDADES PROFESIONALES 
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="width: 600px; background-color: white; font-size: 15px">FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE: </asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">SI</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_siprofesional" Checked="false" OnCheckedChanged="ckb_siprofesional_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_siprofesional" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: white; font-size: 15px">ESPECIFICAR</asp:TableCell>
                            <asp:TableCell Style="width: 250px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_espeprofesional" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="_________________" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">NO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noprofesional" Checked="false" OnCheckedChanged="ckb_noprofesional_CheckedChanged" AutoPostBack="true" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noprofesional" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 75px; background-color: white; font-size: 15px">FECHA:</asp:TableCell>
                            <asp:TableCell Style="width: 100px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_fechaprofesional" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="9" Style="background-color: white; font-size: 14px">
                                <asp:TextBox ID="txt_observaciones3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" Text="OBSERVACIONES:" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="row">
                        <div class="card-header col" style="margin-left: 0.8rem; background-color: #cccdfe; font-size: 15px; font-weight: bold">
                            E. ANTECEDENTES FAMILIARES (DETALLAR EL PARENTESCO)                                          
                        </div>
                        <div class="card-header col" style="text-align: right; font-size: 13px; margin-right: 0.8rem; background-color: #cccdfe; font-size: 15px">
                            MARCAR Y DESCRIBIR ABAJO ANOTANDO EL NÚMERO                                          
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">1. ENFERMEDAD CARDIO-VASCULAR</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_enfermedadcardiovascular" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_enfermedadcardiovascular" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">2. ENFERMEDAD METABÓLICA</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_enfermedadmetabolica" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_enfermedadmetabolica" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">3. ENFERMEDAD NEUROLÓGICA</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_enfermedadneurologica" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_enfermedadneurologica" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">4. ENFERMEDAD ONCOLÓGICA</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_enfermedadoncologica" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_enfermedadoncologica" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">5. ENFERMEDAD INFECCIOSA</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_enfermedadinfecciosa" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_enfermedadinfecciosa" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">6. ENFERMEDAD HEREDITARIA/CONGÉNITA</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_enfermedadhereditaria" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_enfermedadhereditaria" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">7. DISCAPACIDADES</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_discapacidades" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_discapacidades" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #cdfecc; font-size: 15px">8. OTROS</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosenfer" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosenfer" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="8" Style="background-color: white; font-size: 14px">
                                <asp:TextBox ID="txt_descripcionantefamiliares" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" runat="server" Text="DESCRIPCION:" TextMode="MultiLine" Rows="6"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        F.  FACTORES DE RIESGOS DEL PUESTO DE TRABAJO ACTUAL                                          
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell RowSpan="2" ColumnSpan="2" Style="background-color: #cdfecc; font-size: 15px">PUESTO DE TRABAJO / ÁREA</asp:TableCell>
                            <asp:TableCell Style="width: 400px; background-color: #cdfecc; font-size: 15px" RowSpan="2">ACTIVIDADES</asp:TableCell>
                            <asp:TableCell Style="width: 400px; background-color: #cdfecc; font-size: 15px" ColumnSpan="10">FÍSICO</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label21" runat="server" Text="Temperaturas altas"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label22" runat="server" Text="Temperaturas bajas"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label23" runat="server" Text="Radiación Ionizante"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label24" runat="server" Text="Radiación No Ionizante"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label25" runat="server" Text="Ruido"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label26" runat="server" Text="Vibración"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label27" runat="server" Text="Iluminación"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label28" runat="server" Text="Ventilación"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label29" runat="server" Text="Fluido eléctrico"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:TextBox ID="txt_otrosFis" Style="background-color: transparent; font-size: 12px; text-transform: uppercase; border: none; height: 250px; text-align: center;"
                                    TextMode="MultiLine" Rows="15" Columns="10" runat="server" Placeholder="Otros"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px; text-transform: uppercase">1. </asp:TableCell>
                            <asp:TableCell Style="width: 400px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo" AutoPostBack="true" OnTextChanged="txt_puestodetrabajo_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act" AutoPostBack="true" OnTextChanged="txt_act_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempaltas" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempaltas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempbajas" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempbajas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_radiacion" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_radiacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noradiacion" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noradiacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ruido" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ruido" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vibracion" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vibracion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_iluminacion" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_iluminacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ventilacion" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ventilacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fluidoelectrico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fluidoelectrico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosFisico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosFisico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px; text-transform: uppercase">2. </asp:TableCell>
                            <asp:TableCell Style="width: 400px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo2" AutoPostBack="true" OnTextChanged="txt_puestodetrabajo2_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act2" AutoPostBack="true" OnTextChanged="txt_act2_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempaltas2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempaltas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempbajas2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempbajas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_radiacion2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_radiacion2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noradiacion2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noradiacion2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ruido2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ruido2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vibracion2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vibracion2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_iluminacion2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_iluminacion2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ventilacion2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ventilacion2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fluidoelectrico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fluidoelectrico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosFisico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosFisico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px; text-transform: uppercase">3. </asp:TableCell>
                            <asp:TableCell Style="width: 400px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo3" AutoPostBack="true" OnTextChanged="txt_puestodetrabajo3_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act3" AutoPostBack="true" OnTextChanged="txt_act3_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempaltas3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempaltas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempbajas3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempbajas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_radiacion3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_radiacion3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noradiacion3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noradiacion3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ruido3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ruido3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vibracion3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vibracion3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_iluminacion3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_iluminacion3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ventilacion3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ventilacion3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fluidoelectrico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fluidoelectrico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosFisico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosFisico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px; text-transform: uppercase">4. </asp:TableCell>
                            <asp:TableCell Style="width: 400px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo4" AutoPostBack="true" OnTextChanged="txt_puestodetrabajo4_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act4" AutoPostBack="true" OnTextChanged="txt_act4_TextChanged" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempaltas4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempaltas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_tempbajas4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_tempbajas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_radiacion4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_radiacion4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_noradiacion4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_noradiacion4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ruido4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ruido4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vibracion4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vibracion4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_iluminacion4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_iluminacion4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_ventilacion4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_ventilacion4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_fluidoelectrico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_fluidoelectrico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosFisico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosFisico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="15" Style="width: 750px; background-color: #cdfecc; font-size: 15px">MECÁNICO</asp:TableCell>
                            <asp:TableCell ColumnSpan="9" Style="width: 700px; background-color: #cdfecc; font-size: 15px">QUÍMICO</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label31" runat="server" Text="Atrapamiento entre máquinas"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label32" runat="server" Text="Atrapamiento entre superficies"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label33" runat="server" Text="Atrapamiento entre objetos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label34" runat="server" Text="Caída de objetos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label35" runat="server" Text="Caídas al mismo nivel"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label36" runat="server" Text="Caídas a diferente nivel"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label37" runat="server" Text="Contacto eléctrico"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label38" runat="server" Text="Contacto con superficies de trabajos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label39" runat="server" Text="Proyección de partículas – fragmentos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label40" runat="server" Text="Proyección de fluidos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label41" runat="server" Text="Pinchazos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label42" runat="server" Text="Cortes"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label43" runat="server" Text="Atropellamientos por vehículos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label44" runat="server" Text="Choques /colisión vehicular"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:TextBox ID="txt_otrosMec" Style="background-color: transparent; font-size: 12px; text-transform: uppercase; border: none; height: 250px; text-align: center;"
                                    TextMode="MultiLine" Rows="15" Columns="10" runat="server" Placeholder="Otros"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label46" runat="server" Text="Sólidos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label47" runat="server" Text="Polvos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label48" runat="server" Text="Humos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label49" runat="server" Text="Líquidos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label50" runat="server" Text="Vapores"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label51" runat="server" Text="Aerosoles"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label52" runat="server" Text="Neblinas"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label53" runat="server" Text="Gaseosos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:TextBox ID="txt_otrosQui" Style="background-color: transparent; font-size: 12px; text-transform: uppercase; border: none; height: 250px; text-align: center;"
                                    TextMode="MultiLine" Rows="15" Columns="10" runat="server" Placeholder="Otros"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapmaquinas" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapmaquinas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapsuperficie" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapsuperficie" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapobjetos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapobjetos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidaobjetos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidaobjetos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidamisnivel" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidamisnivel" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidadifnivel" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidadifnivel" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contaelectrico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contaelectrico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contasuptrabajo" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contasuptrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyparticulas" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyparticulas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyefluidos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyefluidos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_pinchazos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_pinchazos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_cortes" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_cortes" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atroporvehiculos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atroporvehiculos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_choques" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_choques" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosMecanico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosMecanico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_solidos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_solidos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_polvos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_polvos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_humos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_humos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_liquidos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_liquidos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vapores" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vapores" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_aerosoles" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_aerosoles" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_neblinas" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_neblinas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_gaseosos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_gaseosos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosQuimico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosQuimico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapmaquinas2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapmaquinas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapsuperficie2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapsuperficie2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapobjetos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapobjetos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidaobjetos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidaobjetos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidamisnivel2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidamisnivel2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidadifnivel2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidadifnivel2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contaelectrico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contaelectrico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contasuptrabajo2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contasuptrabajo2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyparticulas2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyparticulas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyefluidos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyefluidos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_pinchazos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_pinchazos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_cortes2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_cortes2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atroporvehiculos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atroporvehiculos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_choques2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_choques2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosMecanico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosMecanico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_solidos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_solidos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_polvos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_polvos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_humos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_humos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_liquidos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_liquidos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vapores2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vapores2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_aerosoles2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_aerosoles2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_neblinas2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_neblinas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_gaseosos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_gaseosos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosQuimico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosQuimico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapmaquinas3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapmaquinas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapsuperficie3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapsuperficie3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapobjetos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapobjetos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidaobjetos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidaobjetos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidamisnivel3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidamisnivel3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidadifnivel3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidadifnivel3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contaelectrico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contaelectrico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contasuptrabajo3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contasuptrabajo3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyparticulas3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyparticulas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyefluidos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyefluidos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_pinchazos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_pinchazos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_cortes3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_cortes3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atroporvehiculos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atroporvehiculos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_choques3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_choques3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosMecanico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosMecanico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_solidos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_solidos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_polvos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_polvos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_humos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_humos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_liquidos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_liquidos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vapores3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vapores3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_aerosoles3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_aerosoles3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_neblinas3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_neblinas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_gaseosos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_gaseosos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosQuimico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosQuimico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapmaquinas4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapmaquinas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapsuperficie4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapsuperficie4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atrapobjetos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atrapobjetos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidaobjetos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidaobjetos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidamisnivel4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidamisnivel4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_caidadifnivel4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_caidadifnivel4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contaelectrico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contaelectrico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_contasuptrabajo4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_contasuptrabajo4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyparticulas4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyparticulas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_proyefluidos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_proyefluidos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_pinchazos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_pinchazos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_cortes4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_cortes4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_atroporvehiculos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_atroporvehiculos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_choques4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_choques4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosMecanico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosMecanico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_solidos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_solidos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_polvos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_polvos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_humos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_humos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_liquidos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_liquidos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_vapores4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_vapores4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_aerosoles4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_aerosoles4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_neblinas4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_neblinas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_gaseosos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_gaseosos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosQuimico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="txt_otrosQuimico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell RowSpan="2" ColumnSpan="2" Style="background-color: #cdfecc; font-size: 15px">PUESTO DE TRABAJO / ÁREA</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 350px; background-color: #cdfecc; font-size: 15px">ACTIVIDADES</asp:TableCell>
                            <asp:TableCell ColumnSpan="7" Style="width: 350px; background-color: #cdfecc; font-size: 15px">BIÓLOGO</asp:TableCell>
                            <asp:TableCell ColumnSpan="5" Style="width: 350px; background-color: #cdfecc; font-size: 15px">ERGONÓMICO</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label55" runat="server" Text="Virus"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label56" runat="server" Text="Hongos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label57" runat="server" Text="Bacterias "></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label58" runat="server" Text="Parásitos "></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label59" runat="server" Text="Exposición a vectores"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label60" runat="server" Text="Exposición a animales selváticos "></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:TextBox ID="txt_otrosBio" Style="background-color: transparent; font-size: 12px; text-transform: uppercase; border: none; height: 250px; text-align: center;"
                                    TextMode="MultiLine" Rows="15" Columns="10" runat="server" Placeholder="Otros"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label62" runat="server" Text="Manejo manual de cargas"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label63" runat="server" Text="Movimiento repetitivos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label64" runat="server" Text="Posturas forzadas"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label65" runat="server" Text="Trabajos con PVD"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:TextBox ID="txt_otrosErg" Style="background-color: transparent; font-size: 12px; text-transform: uppercase; border: none; height: 250px; text-align: center;"
                                    TextMode="MultiLine" Rows="15" Columns="10" runat="server" Placeholder="Otros"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">1. </asp:TableCell>
                            <asp:TableCell Style="width: 350px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo21" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act21" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_virus" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_virus" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder=""></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_hongos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_hongos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_bacterias" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_bacterias" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_parasitos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_parasitos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoavectores" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoavectores" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoanimselvaticos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoanimselvaticos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosBiologico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosBiologico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_manmanualcargas" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_manmanualcargas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_movrepetitivo" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_movrepetitivo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_postforzadas" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_postforzadas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_trabajopvd" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_trabajopvd" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosErgonomico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosErgonomico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">2. </asp:TableCell>
                            <asp:TableCell Style="width: 350px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo22" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act22" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_virus2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_virus2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder=""></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_hongos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_hongos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_bacterias2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_bacterias2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_parasitos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_parasitos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoavectores2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoavectores2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoanimselvaticos2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoanimselvaticos2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosBiologico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosBiologico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_manmanualcargas2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_manmanualcargas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_movrepetitivo2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_movrepetitivo2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_postforzadas2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_postforzadas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_trabajopvd2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_trabajopvd2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosErgonomico2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosErgonomico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">3. </asp:TableCell>
                            <asp:TableCell Style="width: 350px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo23" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act23" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_virus3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_virus3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder=""></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_hongos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_hongos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_bacterias3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_bacterias3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_parasitos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_parasitos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoavectores3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoavectores3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoanimselvaticos3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoanimselvaticos3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosBiologico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosBiologico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_manmanualcargas3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_manmanualcargas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_movrepetitivo3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_movrepetitivo3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_postforzadas3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_postforzadas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_trabajopvd3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_trabajopvd3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosErgonomico3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosErgonomico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 15px">4. </asp:TableCell>
                            <asp:TableCell Style="width: 350px; background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_puestodetrabajo24" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_act24" AutoPostBack="true" Enabled="false" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_virus4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_virus4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder=""></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_hongos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_hongos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_bacterias4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_bacterias4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_parasitos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_parasitos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoavectores4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoavectores4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_expoanimselvaticos4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_expoanimselvaticos4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosBiologico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosBiologico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_manmanualcargas4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_manmanualcargas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_movrepetitivo4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_movrepetitivo4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_postforzadas4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_postforzadas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_trabajopvd4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_trabajopvd4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosErgonomico4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosErgonomico4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="13" Style="width: 800px; background-color: #cdfecc; font-size: 15px">PSICOSOCIAL</asp:TableCell>
                            <asp:TableCell RowSpan="2" Style="width: 650px; background-color: #cdfecc; font-size: 15px">MEDIDAS PREVENTIVAS</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label67" runat="server" Text="Monotonía del trabajo "></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label68" runat="server" Text="Sobrecarga laboral"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label69" runat="server" Text="Minuciosidad de la tarea "></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label70" runat="server" Text="Alta responsabilidad"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label71" runat="server" Text="Autonomía  en la toma de decisiones"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label72" runat="server" Text="Supervisión y estilos de dirección deficiente"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label73" runat="server" Text="Conflicto de rol"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label74" runat="server" Text="Falta de Claridad en las funciones"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label75" runat="server" Text="Incorrecta distribución del trabajo"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label76" runat="server" Text="Turnos rotativos"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label77" runat="server" Text="Relaciones interpersonales"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:Label CssClass="in-column" ID="Label78" runat="server" Text="Inestabilidad laboral"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: #cdfecc; font-size: 15px; text-transform: uppercase">
                                <asp:TextBox ID="txt_otrosPsi" Style="background-color: transparent; font-size: 12px; text-transform: uppercase; border: none; height: 250px; text-align: center;"
                                    TextMode="MultiLine" Rows="15" Columns="10" runat="server" Placeholder="Otros"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_montrabajo" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_montrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_sobrecargalaboral" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_sobrecargalaboral" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_minustarea" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_minustarea" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_altarespon" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_altarespon" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_automadesiciones" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_automadesiciones" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_supyestdireficiente" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_supyestdireficiente" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_conflictorol" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_conflictorol" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_faltaclarfunciones" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_faltaclarfunciones" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_incorrdistrabajo" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_incorrdistrabajo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_turnorotat" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_turnorotat" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_relacinterpersonales" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_relacinterpersonales" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_inestalaboral" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_inestalaboral" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosPsicosocial" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosPsicosocial" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_medpreventivas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_montrabajo2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_montrabajo2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_sobrecargalaboral2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_sobrecargalaboral2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_minustarea2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_minustarea2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_altarespon2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_altarespon2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_automadesiciones2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_automadesiciones2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_supyestdireficiente2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_supyestdireficiente2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_conflictorol2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_conflictorol2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_faltaclarfunciones2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_faltaclarfunciones2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_incorrdistrabajo2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_incorrdistrabajo2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_turnorotat2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_turnorotat2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_relacinterpersonales2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_relacinterpersonales2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_inestalaboral2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_inestalaboral2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosPsicosocial2" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosPsicosocial2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_medpreventivas2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_montrabajo3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_montrabajo3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_sobrecargalaboral3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_sobrecargalaboral3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_minustarea3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_minustarea3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_altarespon3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_altarespon3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_automadesiciones3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_automadesiciones3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_supyestdireficiente3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_supyestdireficiente3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_conflictorol3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_conflictorol3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_faltaclarfunciones3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_faltaclarfunciones3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_incorrdistrabajo3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_incorrdistrabajo3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_turnorotat3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_turnorotat3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_relacinterpersonales3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_relacinterpersonales3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_inestalaboral3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_inestalaboral3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosPsicosocial3" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosPsicosocial3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_medpreventivas3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_montrabajo4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_montrabajo4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_sobrecargalaboral4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_sobrecargalaboral4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_minustarea4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_minustarea4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_altarespon4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_altarespon4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_automadesiciones4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_automadesiciones4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_supyestdireficiente4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_supyestdireficiente4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_conflictorol4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_conflictorol4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_faltaclarfunciones4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_faltaclarfunciones4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_incorrdistrabajo4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_incorrdistrabajo4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_turnorotat4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_turnorotat4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_relacinterpersonales4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_relacinterpersonales4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_inestalaboral4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_inestalaboral4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_otrosPsicosocial4" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_otrosPsicosocial4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; font-size: 14px">
                                <asp:TextBox runat="server" ID="txt_medpreventivas4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        G. ACTIVIDADES EXTRA LABORALES                                            
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox ID="txt_descrextralaborales" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" runat="server" Text="DESCRIPCION:" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        H. ENFERMEDAD ACTUAL                                           
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox ID="txt_enfermedadactualinicial" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" Text="DESCRIPCION:" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="row">
                        <div class="card-header col" style="margin-left: 0.8rem; background-color: #cccdfe; font-size: 15px; font-weight: bold">
                            I. REVISIÓN ACTUAL DE ÓRGANOS Y SISTEMAS                                          
                        </div>
                        <div class="card-header col" style="text-align: right; font-size: 11px; margin-right: 0.8rem; background-color: #cccdfe">
                            EN CASO DE EXISTIR PATOLOGÍA  MARCAR CON "X"  Y DESCRIBIR ABAJO COLOCANDO EL NUMERAL                                         
                        </div>
                    </div>
                    <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">1. PIEL - ANEXOS</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_pielanexos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_pielanexos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">3. RESPIRATORIO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_respiratorio" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_respiratorio" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">5. DIGESTIVO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_digestivo" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_digestivo" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">7. MÚSCULO ESQUELÉTICO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_musculosesqueleticos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_musculosesqueleticos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">9. HEMO LINFÁTICO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_hemolinfatico" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_hemolinfatico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="width: 200px; background-color: #ccffff; font-size: 15px">2. ÓRGANOS DE LOS SENTIDOS</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_organossentidos" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_organossentidos" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">4. CARDIO-VASCULAR</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_cardiovascular" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_cardiovascular" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">6. GENITO - URINARIO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_genitourinario" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_genitourinario" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">8. ENDOCRINO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_endocrino" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_endocrino" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                            <asp:TableCell Style="width: 275px; background-color: #ccffff; font-size: 15px">10. NERVIOSO</asp:TableCell>
                            <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                <asp:CheckBox ID="ckb_nervioso" Checked="false" runat="server" />
                                <%--<asp:TextBox runat="server" ID="ckb_nervioso" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="10" Style="background-color: white; font-size: 14px">
                                <asp:TextBox ID="txt_descrorganosysistemas" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" runat="server" Text="DESCRIPCION:" TextMode="MultiLine" Rows="6"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        J. CONSTANTES VITALES Y ANTROPOMETRÍA 
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
                                    <asp:TextBox ID="txt_preArterial" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_temperatura" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_freCardica" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_satOxigeno" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_freRespiratoria" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_peso" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center" OnTextChanged="txt_peso_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_talla" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center" OnTextChanged="txt_talla_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_indMasCorporal" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_perAbdominal" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        K. EXAMEN FÍSICO REGIONAL
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="REGIONES" Style="width: 1400px; text-align: left; background-color: #cdfecc; font-size: 15px" ColumnSpan="15"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell RowSpan="3" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label80" runat="server" Text="1. Piel"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Cicatrices</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_cicatrices" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_cicatrices" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="3" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label81" runat="server" Text="3. Oído"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. C. auditivo externo</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_auditivoexterno" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_auditivoexterno" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="4" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label82" runat="server" Text="5. Nariz"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Tabique</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_tabique" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_tabique" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label83" runat="server" Text="8. Tórax"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Pulmones</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pulmones" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pulmones" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="width: 65px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label84" runat="server" Text="11. Pelvis"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="width: 120px; background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Pelvis</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="width: 60px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pelvis" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pelvis" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Tatuajes</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_tatuajes" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_tatuajes" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Pabellón</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pabellon" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pabellon" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Cornetes</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_cornetes" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_cornetes" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Parrilla Costal</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_parrillacostal" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_parrillacostal" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Genitales</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_genitales" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_genitales" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Piel  y Faneras</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pielyfaneras" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pielyfaneras" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Tímpanos</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_timpanos" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_timpanos" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Mucosas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_mucosa" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_mucosa" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label85" runat="server" Text="9. Abdomen"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Vísceras</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_visceras" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_visceras" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="3" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label86" runat="server" Text="12. Extremidades"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Vascular</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_vascular" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_vascular" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell RowSpan="5" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label87" runat="server" Text="2. Ojos"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Párpados</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_parpados" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_parpados" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="5" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label88" runat="server" Text="4. Oro faringe"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Labios</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_labios" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_labios" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Senos paranasales</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_senosparanasales" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_senosparanasales" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Pared abdominal</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_paredabdominal" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_paredabdominal" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Miembros superiores</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_miembrosuperiores" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_miembrosuperiores" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Conjuntivas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_conjuntivas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_conjuntivas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Lengua</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_lengua" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_lengua" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label89" runat="server" Text="6. Cuello"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Tiroides / masas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_tiroides" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_tiroides" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="4" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label90" runat="server" Text="10. Columna"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Flexibilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_flexibilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_flexibilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Miembros inferiores</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_miembrosinferiores" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_miembrosinferiores" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Pupilas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pupilas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pupilas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Faringe</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_faringe" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_faringe" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Movilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_movilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_movilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Desviación</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" RowSpan="2" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_desviacion" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_desviacion" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="4" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label91" runat="server" Text="13. Neurológico"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Fuerza</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_fuerza" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_fuerza" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Córnea</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_cornea" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_cornea" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Amígdalas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_amigdalas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_amigdalas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell RowSpan="2" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">
                                    <asp:Label CssClass="REI-COLUMN" ID="Label92" runat="server" Text="7. Tórax"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">a. Mamas</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_mamas" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_mamas" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Sensibilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_sensibilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_sensibilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">e. Motilidad</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_motilidad" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_motilidad" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">e. Dentadura</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_dentadura" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_dentadura" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">b. Corazón</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_corazon" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_corazon" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Dolor</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_dolor" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_dolor" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">c. Marcha</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_marcha" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_marcha" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="text-align: left; background-color: white; font-size: 12px" ColumnSpan="12">SI EXISTE EVIDENCIA DE PATOLOGÍA MARCAR CON "X" Y DESCRIBIR EN LA SIGUIENTE SECCIÓN COLOCANDO EL NUMERAL</asp:TableCell>
                                <asp:TableCell CssClass="REI-CONTENT" Style="background-color: #ccffff; font-size: 13px; text-transform: uppercase">d. Reflejos</asp:TableCell>
                                <asp:TableCell CssClass="REI-BOX" Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_reflejos" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_reflejos" BorderStyle="None" style="background-color:transparent; width:100%; text-align:center"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="15" Style="background-color: white">
                                    <asp:TextBox ID="txt_obervexamenfisicoregional" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" runat="server" Text="OBSERVACIONES:" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        L. RESULTADOS DE EXÁMENES GENERALES Y ESPECÍFICOS DE ACUERDO AL RIESGO Y PUESTO DE TRABAJO (IMAGEN, LABORATORIO Y OTROS)
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 400px; background-color: #cdfecc; font-size: 15px">EXAMEN </asp:TableCell>
                                <asp:TableCell Style="width: 150px; background-color: #cdfecc; font-size: 15px">FECHA <br /> dd/mm/aaaa</asp:TableCell>
                                <asp:TableCell Style="width: 800px; background-color: #cdfecc; font-size: 15px">RESULTADOS</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_examen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaexamen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_resultadoexamen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_examen2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaexamen2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_resultadoexamen2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_examen3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaexamen3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_resultadoexamen3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_examen4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_fechaexamen4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="Date" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_resultadoexamen4" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" placeholder="-"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="15" Style="background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_observacionexamen" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" runat="server" Text="OBSERVACIONES:" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        M. DIAGNÓSTICO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" Style="text-align: end; background-color: #cccdfe; font-size: 15px">PRE= PRESUNTIVO          DEF= DEFINITIVO</asp:TableCell>
                                <asp:TableCell Style="width: 200px; background-color: #cccdfe; font-size: 15px">CIE</asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: #cccdfe; font-size: 15px">PRE</asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: #cccdfe; font-size: 15px">DEF</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 50px; background-color: #cdfecc; font-size: 15px" Text="1"></asp:TableCell>
                                <asp:TableCell Style="width: 1000px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descripdiagnostico" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" placeholder="DESCRIPCION" OnTextChanged="txt_descripdiagnostico_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerCie10"
                                        TargetControlID="txt_descripdiagnostico" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_cie" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pre" Checked="false" OnCheckedChanged="ckb_pre_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pre" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_def" Checked="false" OnCheckedChanged="ckb_def_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_def" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 50px; background-color: #cdfecc; font-size: 15px" Text="2"></asp:TableCell>
                                <asp:TableCell Style="width: 1000px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descripdiagnostico2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" placeholder="DESCRIPCION" OnTextChanged="txt_descripdiagnostico2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerCie10"
                                        TargetControlID="txt_descripdiagnostico2" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_cie2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pre2" Checked="false" OnCheckedChanged="ckb_pre2_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pre2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_def2" Checked="false" OnCheckedChanged="ckb_def2_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_def2" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 50px; background-color: #cdfecc; font-size: 15px" Text="3"></asp:TableCell>
                                <asp:TableCell Style="width: 1000px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descripdiagnostico3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" placeholder="DESCRIPCION" OnTextChanged="txt_descripdiagnostico3_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerCie10"
                                        TargetControlID="txt_descripdiagnostico3" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_cie3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_pre3" Checked="false" OnCheckedChanged="ckb_pre3_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_pre3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_def3" Checked="false" OnCheckedChanged="ckb_def3_CheckedChanged" AutoPostBack="true" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_def3" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        N. APTITUD MÉDICA PARA EL TRABAJO  
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">APTO</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_apto" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_apto" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase" placeholder="-"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">APTO EN OBSERVACIÓN</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_aptoobservacion" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_aptoobservacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">APTO CON LIMITACIONES</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_aptolimitacion" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_aptolimitacion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 250px; background-color: #cdfecc; font-size: 15px">NO APTO</asp:TableCell>
                                <asp:TableCell Style="width: 50px; background-color: white; font-size: 14px">
                                    <asp:CheckBox ID="ckb_noapto" Checked="false" runat="server" />
                                    <%--<asp:TextBox runat="server" ID="ckb_noapto" BorderStyle="None" Style="background-color: transparent; width: 100%; text-align: center; text-transform:uppercase"></asp:TextBox>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #ccffff; font-size: 15px">Observación</asp:TableCell>
                                <asp:TableCell ColumnSpan="7" Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_observacionaptitud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #ccffff; font-size: 15px">Limitación</asp:TableCell>
                                <asp:TableCell ColumnSpan="7" Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_limitacionaptitud" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        O. RECOMENDACIONES Y/O TRATAMIENTO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox ID="txt_descripciontratamiento" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" runat="server" Text="DESCRIPCION:" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="container" style="text-align: center; text-transform: uppercase">
                    <p>
                        <strong>"CERTIFICO QUE LO ANTERIORMENTE EXPRESADO EN RELACIÓN A MI ESTADO DE SALUD ES VERDAD. SE ME HA INFORMADO LAS MEDIDAS PREVENTIVAS 
                                           A TOMAR PARA DISMINUIR O MITIGAR LOS RIESGOS RELACIONADOS CON MI ACTIVIDAD LABORAL."</strong>
                    </p>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                        P. DATOS DEL PROFESIONAL 
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered table-light table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 100px; background-color: #cdfecc; font-size: 15px">FECHA Y HORA</asp:TableCell>
                                <asp:TableCell Style="width: 150px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" BorderStyle="None" ID="txt_fechahora" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase" TextMode="DateTimeLocal"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: #cdfecc; font-size: 15px">NOMBRES Y APELLIDOS</asp:TableCell>
                                <asp:TableCell Style="width: 375px; background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_profesional" AutoPostBack="true" OnTextChanged="ddl_profesional_TextChanged" CssClass="form-check" Style="width: 100%; border: none; background-color: transparent; text-align: center; text-transform: uppercase" onchange="borrarMensaje();" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lbl_profesional" ForeColor="Red" runat="server"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="rfv_profesional" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_profesional" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: #cdfecc; font-size: 15px">CÓDIGO</asp:TableCell>
                                <asp:TableCell Style="width: 125px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" BorderStyle="None" ID="txt_codigoDatProf" Enabled="false" AutoPostBack="true" Style="background-color: transparent; width: 100%; text-align: center; text-transform: uppercase"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: #cdfecc; font-size: 15px">FIRMA Y SELLO</asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: white; font-size: 14px">
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div align="center">
                    <div class="card" style="width: 400px">
                        <div class="card-header" style="background-color: #cccdfe; font-size: 15px; font-weight: bold">
                            Q. FIRMA DEL USUARIO
                        </div>
                        <div class="list-group list-group-flush">
                            <asp:Label ID="Label93" runat="server" Text="" Style="height: 80px"></asp:Label>
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
