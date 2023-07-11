<%@ Page Title="" Language="C#" MasterPageFile="~/views/Pacientes/Paciente.Master" AutoEventWireup="true" CodeBehind="SSO.aspx.cs" Inherits="SistemaECU911.Template.Views_Pacientes.SSO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    SSO2 | Sistema Médico Paciente
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="background-color: white">
                <br />

                <%--Título--%>

                <div class="container">
                    <div class="text-center" style="font-size: 15px; font-family: Arial">
                        <h6>GESTIÓN DE TALENTO HUMANO</h6>
                        <h6>GESTIÓN DE BIENESTAR LABORAL Y SALUD OCUPACIONAL</h6>
                        <h6>FICHA SOCIOECONÓMICA</h6>
                    </div>
                </div>
                <br />

                <%--Código y Versión--%>

                <div class="list-group list-group-flush">
                    <asp:Table class="table table-bordered table-light" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Style="text-align: center; border: ridge; font-family: Arial">
                                <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                                    CÓDIGO
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Style="text-align: center; border: ridge; font-family: Arial">
                                <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                                    VERSIÓN
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Style="background-color: white; border: ridge; font-family: Arial">
                                <asp:TextBox runat="server" ID="txt_codigoinicio" BorderStyle="None" Style="width: 100%; text-align: center" placeholder="GTH_FOR_21"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell Style="background-color: white; border: ridge; font-family: Arial">
                                <asp:TextBox runat="server" ID="txt_version" BorderStyle="None" Style="width: 100%; text-align: center" placeholder="1"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />

                <%--I. DATOS PERSONALES DEL SERVIDOR/A--%>
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        I. DATOS PERSONALES DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="4" RowSpan="2">NOMBRES Y APELLIDOS</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="2">GENERO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">ESTADO CIVIL</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">CÉDULA</asp:TableCell>                                
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">H</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">M</asp:TableCell>                              
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox1" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox3" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox4" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox5" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox2" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="txt_cedula" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                    <%--<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="ObtenerNumHClinica"
                                        TargetControlID="txt_cedula" CompletionListCssClass="CompletionList"
                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                        CompletionListItemCssClass="CompletionListItem">
                                    </ajaxToolkit:AutoCompleteExtender>--%>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px">MODALIDAD DE VINCULACIÓN</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 300px">LEY ORGÁNICA DEL SECTOR PÚBLICO (LOSEP)</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_modalidadlosep" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 200px">CÓDIGO DE TRABAJO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_codigotrabajoModalidad" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px">NIVEL DE EDUCACIÓN</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial;">PRIMARIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_primaria" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial;">SECUNDARIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_secundaria" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial;">SUPERIOR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_superior" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial;">ESPECIALIZACIÓN</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_especializacion" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial;">DIPLOMADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_diplomado" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial;">MAESTRÍA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_maestria" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial;">DOCTORADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 50px">
                                    <asp:CheckBox ID="cb_doctorado" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">AUTOIDENTIFICACIÓN ÉTNICA</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">LUGAR Y FECHA DE NACIMIENTO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="2">CONTACTOS DEL SERVIDOR/A</asp:TableCell>                               
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="3">
                                    <asp:TextBox runat="server" ID="TextBox6" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="3">
                                    <asp:TextBox runat="server" ID="TextBox7" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:100px">CELULAR</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox8" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">TELF CONVENCIONAL</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox11" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">MAIL</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox14" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial"  ColumnSpan="2">INSTRUCCIÓN FORMAL</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">DEPARTAMENTO /ÁREA</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">CARGO INSTITUCIONAL </asp:TableCell>                               
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">PROFESIÓN</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox22" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="3">
                                    <asp:TextBox runat="server" ID="TextBox25" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="3">
                                    <asp:TextBox runat="server" ID="TextBox17" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">OCASIÓN</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox23" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 250px">PERSONA PARA CONTACTO DE EMERGENCIA</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 150px">NOMBRES Y APELLIDOS</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 300px">
                                    <asp:TextBox runat="server" ID="txt_emernomyape" BorderStyle="None" BackColor="white" Style="width: 100%"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">PARENTESCO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emeparentesco" BorderStyle="None" BackColor="white" Style="width: 100%"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">TELÉFONO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emetelefono" BorderStyle="None" BackColor="white" Style="width: 100%"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px" RowSpan="2">DIRECCIÓN DEL FAMILIAR:</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">CALLE PRINCIPAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_emecalleprincipal" BorderStyle="None" BackColor="white" Style="width: 100%"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">Nº DEL DOMICILIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emenumdomicilio" BorderStyle="None" BackColor="white" Style="width: 100%"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">CALLE SECUNDARIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left; width: 100px">
                                    <asp:TextBox runat="server" ID="txt_emecallesecun" BorderStyle="None" BackColor="white" Style="width: 100%"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">REFERENCIA PARA UBICAR EL DOMICILIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 100px; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_emerefubicardomicilio" BorderStyle="None" BackColor="white" Style="width: 100%"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:350px">¿DESTINA ALGÚN DINERO PARA EL AHORRO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dineroahorrosi" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_dineroahorrono" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 100px">¿TIENE VEHÍCULO PROPIO?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vehiculosi" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_vehiculono" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 50px">¿USA RECORRIDO INSTITUCIONAL?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 20px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_recorridosi" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 20px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_recorridono" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 20px">NO EXISTE</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="cb_recorridonoexiste" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </div>
                </div>
                <br />

                <%--II. DATOS DE SALUD DEL SERVIDOR/A--%>
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        II. DATOS DE SALUD DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 500px">¿POSEE ALGUNA ENFERMEDAD ANTES DE INGRESAR AL SIS ECU 911?</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: left">
                                    <asp:TextBox runat="server" ID="txt_poseeenfermedadingresarEcu" BorderStyle="None" Style="width: 100%; background-color: transparent" placeholder="Detalle por favor:"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:600px">¿SE ENCUENTRA EN ESTADO DE GESTACIÓN?  (ADJUNTAR CERTIFICADO MÉDICO)    </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px">SI</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="CheckBox54" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width: 30px">NO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; width: 20px">
                                    <asp:CheckBox ID="CheckBox55" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">TIPO DE SANGRE</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">ENFERMEDAD DE IMPORTANCIA O CATASTRÓFICA</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">CIRUGIAS QUE HAYA PADECIDO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="9">DATOS DE DISCAPACIDAD </asp:TableCell>                                
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox21" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox24" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox26" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">SI</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox5" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">TIPO</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox27" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">OBSERVACIÓN</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="4">
                                    <asp:TextBox runat="server" ID="TextBox28" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">¿DONANTE?</asp:TableCell> 
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">NO</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox3" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">%</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox41" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">SUSTITUTO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">SI</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox6" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">NO</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox4" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:300px">EN CASO DE EMERGENCIA CON QUIEN PUEDO COMUNICARME</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox29" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">PARENTESCO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:150px">
                                    <asp:TextBox runat="server" ID="TextBox39" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="2">TELÉFONO</asp:TableCell> 
                                <asp:TableCell Style="background-color: white; text-align: center; width:150px">
                                    <asp:TextBox runat="server" ID="TextBox40" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:150px">OBSERVACIONES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox30" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--III. COMPOSICIÓN FAMILIAR DEL SERVIDOR/A--%>
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        III. COMPOSICIÓN FAMILIAR DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">Nº</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">NOMBRE Y APELLIDO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">PARENTESCO</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">SEXO</asp:TableCell>  
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">FECHA N</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">ESTADO CIVIL</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">INSTRUCCION</asp:TableCell> 
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">OCUPACIÓN </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">DISCAPACIDAD</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center; width:40px">
                                    <asp:TableCell>1</asp:TableCell>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox32" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox33" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox34" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox35" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox36" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox44" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox45" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox46" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow> 
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center; width:40px">
                                    <asp:TableCell>2</asp:TableCell>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox31" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox37" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox38" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox42" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox43" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox47" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox48" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox49" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow> 
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center; width:40px">
                                    <asp:TableCell>3</asp:TableCell>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox50" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox51" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox52" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox53" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox54" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox55" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox56" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center; width:100px">
                                    <asp:TextBox runat="server" ID="TextBox57" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow> 
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:150px">OBSERVACIONES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox58" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--IV. SITUACIÓN SOCIOFAMILIAR SERVIDOR/A--%>
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        IV. SITUACIÓN SOCIOFAMILIAR SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">FAMILIAR</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="2">¿COMO ES SU RELACIÓN INTRAFAMILIAR?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center:">
                                    <asp:CheckBox ID="CheckBox7" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox8" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox9" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox10" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="2">¿COMO ES LA RELACIÓN CON SU PAREJA?</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">MUY BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox11" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">BUENA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox12" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">REGULAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox13" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">MALA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox14" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:100px">¿POR QUÉ?</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="9">
                                    <asp:TextBox runat="server" ID="TextBox9" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">TIPO DE FAMILIA</asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">FAMILIA</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox19" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">NUCLEAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox15" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">INCOMPLETO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox16" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">REORGANIZADO</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox17" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">CIRCUNSTANCIAL</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox18" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial; width:150px">OBSERVACIONES</asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox140" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--V. SITUACIÓN ECONÓMICA DEL SERVIDOR/A--%>
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        V. SITUACIÓN ECONÓMICA DEL SERVIDOR/A
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered table-light" runat="server">
                            <asp:TableRow>
                                <asp:TableCell RowSpan="11" Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="INGRESOS Y EGRESOS" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="3">
                                    <asp:Label Text="NÚMERO DE MIEMBROS ECONOMICAMENTE ACTIVOS" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox10" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell ColumnSpan="4" Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="SITUACIÓN LABORAL DEL CONYUGUE:" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="TOTAL INGRESOS MENSUALES PROYECTADOS" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="AYUDA PADRES/FAMILIARES" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="OTROS INGRESOS" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell ColumnSpan="3" Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="TOTAL EGRESOS MENSUALES PROYECTADOS" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox13" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox15" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox16" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Alimentación " runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox18" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="9">
                                    <asp:TextBox runat="server" ID="TextBox19" BorderStyle="None" Style="width: 100%; background-color: transparent" placeholder="$"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox20" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox59" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox60" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Vivienda " runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox61" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox62" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox63" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox66" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Educación " runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox69" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox70" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox71" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox72" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Servicios Básicos" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox73" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox75" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox76" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox77" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Salud " runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox78" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox80" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox81" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox82" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Movilización " runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox83" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox85" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox86" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox87" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Deudas " runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox88" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox90" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox91" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox92" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Otros (Pensiones, Varios)" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox93" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox95" BorderStyle="None" Style="width: 100%; background-color: transparent" placeholder="$"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox96" BorderStyle="None" Style="width: 100%; background-color: transparent" placeholder="$"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="Total" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox97" BorderStyle="None" Style="width: 100%; background-color: transparent" placeholder="$"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table class="table table-bordered table-light" runat="server">
                            <asp:TableRow>
                                <asp:TableCell RowSpan="7" Style="background-color: #cdfecc; color: black; font-family: Arial; width:200px">
                                    <asp:Label Text="DESCRIPCION DE BIENES MUEBLE E INMUEBLES" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial; width:170px">
                                    <asp:Label Text="BIEN" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial; width:170px">
                                    <asp:Label Text="VALOR" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell ColumnSpan="2" Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DETALLE" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="CASA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox12" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial; width:125px">
                                    <asp:Label Text="DIRECCIÓN" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox64" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DEPARATAMENTO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox65" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DIRECCIÓN" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox67" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="VEHICULO/CARRO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox68" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DETALLE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox74" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="TERRENO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox79" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="SECTOR" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox84" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="NEGOCIO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox89" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DETALLE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox94" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="MUEBLES Y ENSERES" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox98" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DETALLE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:TextBox runat="server" ID="TextBox99" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
        
                        <asp:Table class="table table-bordered table-light" runat="server">
                            <asp:TableRow>
                                <asp:TableCell RowSpan="8" Style="background-color: #cdfecc; color: black; font-family: Arial; width:200px">
                                    <asp:Label Text="CARACTERISTICAS DE LA VIVIENDA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DESCRIPCION" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="UNIFAMILIAR" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox20" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="MULTIFAMILIAR" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox21" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="2">
                                    <asp:Label Text="OTRO ESPECIFIQUE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox100" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">
                                    <asp:Label Text="TENENCIA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="PROPIEDAD SIN DEUDA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox22" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="ARRENDADA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox23" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DE FAMILIA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox24" runat="server" />
                                </asp:TableCell>                                
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">
                                    <asp:Label Text="OTRO ESPECIFIQUE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox101" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow> 
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="HIPOTECADA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox25" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="PRESTADA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox26" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="ANTICRESES" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox27" runat="server" />
                                </asp:TableCell>                                
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">
                                    <asp:Label Text="TIPO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="CASA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox28" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="SUIT" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox29" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="MEDIAGUA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox30" runat="server" />
                                </asp:TableCell>                                
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">
                                    <asp:Label Text="OTRO ESPECIFIQUE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox102" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow> 
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="DEPARTAMENTO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox31" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="PIEZA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox32" runat="server" />
                                </asp:TableCell>                               
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="3">
                                    <asp:Label Text="DISTRIBUCIÓN" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="HABITACIÓN" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox33" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="SALA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox34" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="BAÑO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox35" runat="server" />
                                </asp:TableCell>                                
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="3">
                                    <asp:Label Text="OTRO ESPECIFIQUE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="3">
                                    <asp:TextBox runat="server" ID="TextBox103" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow> 
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="GARAJE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox36" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="COMEDOR" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox37" runat="server" />
                                </asp:TableCell> 
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="COCINA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox38" runat="server" />
                                </asp:TableCell> 
                            </asp:TableRow>
                            <asp:TableRow> 
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="PATIO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox39" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="BODEGA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox40" runat="server" />
                                </asp:TableCell> 
                            </asp:TableRow>
                            
                        </asp:Table>

                        <asp:Table class="table table-bordered table-light" runat="server">
                            <asp:TableRow>
                                <asp:TableCell RowSpan="2" Style="background-color: #cdfecc; color: black; font-family: Arial; width:200px">
                                    <asp:Label Text="SERVICIOS DISPONIBLES" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="LUZ" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox41" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial; width:125px">
                                    <asp:Label Text="ALCANTARILLADO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox42" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="TV CABLE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox43" runat="server" />
                                </asp:TableCell>                                
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">
                                    <asp:Label Text="OTROS" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox115" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="AGUA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox44" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="TELÉFONO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox45" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="INTERNET" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox46" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table class="table table-bordered table-light" runat="server">
                            <asp:TableRow>
                                <asp:TableCell RowSpan="4" Style="background-color: #cdfecc; color: black; font-family: Arial; width:200px">
                                    <asp:Label Text="CARACTERISTICAS DEL LUGAR DE RESIDENCIA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="UBICACIÓN" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="URBANA" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox47" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial; width:125px">
                                    <asp:Label Text="RURAL" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox48" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">
                                    <asp:Label Text="RIESGO DELINCUENCIAL" runat="server"></asp:Label>
                                </asp:TableCell>                               
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="ALTO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox49" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="MEDIO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox53" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" RowSpan="2">
                                    <asp:Label Text="OTRO ESPECIFIQUE" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center" RowSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox104" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="ACCESO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="FÁCIL" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox50" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial; width:125px">
                                    <asp:Label Text="DIFÍCIL" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox51" runat="server" />
                                </asp:TableCell>                              
                                <asp:TableCell  Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="BAJO" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; text-align: center">
                                    <asp:CheckBox ID="CheckBox52" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial" ColumnSpan="12">
                                    <asp:Label Text="¿CÓMO SE MOVILIZA DESDE SU VIVIENDA AL LUGAR DE TRABAJO?" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; text-align: center" ColumnSpan="12">
                                    <asp:TextBox runat="server" ID="TextBox105" BorderStyle="None" Style="width: 100%; background-color: transparent"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--VI. POSIBLES PROBLEMAS EN LA FAMILIA O EN UNO DE SUS MIEMBROS--%>
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        VI. POSIBLES PROBLEMAS EN LA FAMILIA O EN UNO DE SUS MIEMBROS
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">
                                    <asp:Label Text="PROBLEMAS DETECTADOS" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">DESINTEGRACIÓN FAMILIAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox122" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">HACINAMIENTO</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox123" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">ENFERMEDADES</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox124" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">VIOLENCIA INTRA FAMILIAR</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox120" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">DIVORCIO</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox125" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">OTRO ESPECIFIQUE</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox126" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">DESEMPLEO</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox127" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">DISCAPACIDAD</asp:TableCell>
                                <asp:TableCell Style="background-color: white" ColumnSpan="3">
                                    <asp:TextBox runat="server" ID="TextBox128" BorderStyle="None" Style="width: 100%" BackColor="white" placeholder="Especifique el %"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">ADICCIONES</asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="TextBox129" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">RECONSTRUCIÓN FAMILIAR </asp:TableCell>
                                <asp:TableCell Style="background-color: white" ColumnSpan="3">
                                    <asp:TextBox runat="server" ID="TextBox130" BorderStyle="None" Style="width: 100%" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table class="table table-bordered text-left" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: #cdfecc; color: black; font-family: Arial">Observaciones y Recomendaciones</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_informacionadicional" BorderStyle="None" Style="width: 100%;" BackColor="white" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />

                <%--ENTREVISTA POR Y SERVIDOR/A ENTREVISTADO--%>

                    <div class="list-group list-group-flush">
                        <asp:Table class="table table-bordered text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Style="border: ridge; font-family: Arial">
                                <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                                    ENTREVISTADO POR:
                                </div>
                                </asp:TableCell>
                                <asp:TableCell Style="border: ridge; font-family: Arial">
                                <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                                    SERVIDOR/A ENTREVISTADO 
                                </div>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; border: ridge; font-family: Arial">
                                <asp:Label Text="JUDITH CARVAJAL" runat="server"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; border: ridge; font-family: Arial" RowSpan="2">
                                    <asp:TextBox runat="server" ID="TextBox106" BorderStyle="None" Style="width: 100%;" BackColor="white"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; border: ridge; font-family: Arial">
                                <asp:Label Text="TRABAJADORA SOCIAL" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                <br />


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
