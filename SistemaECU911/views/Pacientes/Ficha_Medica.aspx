<%@ Page Title="" Language="C#" MasterPageFile="~/views/Pacientes/Paciente.Master" AutoEventWireup="true" CodeBehind="Ficha_Medica.aspx.cs" Inherits="SistemaECU911.Template.Views_Pacientes.FichaMedica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Ficha Médica | Sistema Médico Paciente
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="dvText" class="container" style="background-color: white">
                <br />
                <div class="container">
                    <div class="text-center" style="font-size: 25px; font-weight: bold; font-family: Arial">
                        FICHA MÉDICA
                    </div>
                </div>
                <br />
                <div align="center">
                    <img src="../Template Principal/images/Foto_Perfil.png" alt="logo" style="width: 100px; height: 100px" />
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <div class="container">
                            <asp:Table class="table table-bordered table-responsive text-center" Style="width: 100%; text-transform: uppercase" runat="server" align="left">
                                <asp:TableRow Style="text-align: center">
                                    <asp:TableCell Text="ESTABLECIMIENTO DE SALUD" Style="width: 280px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                    <asp:TableCell Text="PRIMER NOMBRE" Style="width: 150px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                    <asp:TableCell Text="SEGUNDO NOMBRE" Style="width: 150px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                    <asp:TableCell Text="PRIMER APELLIDO" Style="width: 150px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                    <asp:TableCell Text="SEGUNDO APELLIDO" Style="width: 150px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                    <asp:TableCell Text="SEXO" Style="width: 50px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                    <asp:TableCell Text="EDAD" Style="width: 155px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                    <asp:TableCell Text="N° HISTORIA CLÍNICA" Style="width: 160px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_nomEmpresa" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_priNombre" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_segNombre" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_priApellido" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_segApellido" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_sexo" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_edad" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="background-color: white; font-size: 14px">
                                        <asp:TextBox runat="server" ID="txt_numHClinica" BorderStyle="None" Style="width: 100%; text-transform:uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>
                <br />
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        1. MOTIVO DE CONSULTA
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered table-responsive text-center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="MOTIVO DE CONSULTA" Style="width: 950px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="MOTIVO DE CONSULTA (según acompañante)" Style="width: 350px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_moConsulta" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_segAcompa" BorderStyle="None" Style="width: 100%" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        2. ANTECEDENTES PERSONALES
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered table-responsive text-center" runat="server">
                            <asp:TableRow Style="text-align: center">
                                <asp:TableCell Text="TIPO DE ANTECEDENTE" Style="width: 400px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="ANTECEDENTE" Style="width: 700px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="DESCRIPCIÓN" Style="width: 200px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:DropDownList ID="ddl_tipoAntPer" CssClass="form-check" Style="width: 100%; text-transform: uppercase; border: none; background-color: transparent; font-size: 14px" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Enfermedad Cardio_Vascular</asp:ListItem>
                                        <asp:ListItem Value="2">Enfermedad Metabólica</asp:ListItem>
                                        <asp:ListItem Value="3">Enfermedad Neurológica</asp:ListItem>
                                        <asp:ListItem Value="4">Enfermedad Oncólogica</asp:ListItem>
                                        <asp:ListItem Value="5">Enfermedad Infecciosa</asp:ListItem>
                                        <asp:ListItem Value="6">Enfermedad Hereditaria/Congónita</asp:ListItem>
                                        <asp:ListItem Value="7">Discapacidades</asp:ListItem>
                                        <asp:ListItem Value="8">Otros</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_antePersonales" BorderStyle="None" Style="width: 100%; text-transform: uppercase; font-size: 14px" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_antePerDescripcion" BorderStyle="None" Style="width: 100%; text-transform: uppercase; font-size: 14px" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        3. ANTECEDENTES FAMILIARES
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered table-responsive text-center" runat="server">
                            <asp:TableRow Style="text-align: center">
                                <asp:TableCell Text="TIPO DE ANTECEDENTE" Style="width: 400px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="ANTECEDENTE" Style="width: 700px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="DESCRIPCIÓN" Style="width: 200px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:DropDownList ID="ddl_tipoAntFam" CssClass="form-check" Style="width: 100%; text-transform: uppercase; border: none; background-color: transparent; font-size: 14px" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Enfermedad Cardio_Vascular</asp:ListItem>
                                        <asp:ListItem Value="2">Enfermedad Metabólica</asp:ListItem>
                                        <asp:ListItem Value="3">Enfermedad Neurológica</asp:ListItem>
                                        <asp:ListItem Value="4">Enfermedad Oncólogica</asp:ListItem>
                                        <asp:ListItem Value="5">Enfermedad Infecciosa</asp:ListItem>
                                        <asp:ListItem Value="6">Enfermedad Hereditaria/Congónita</asp:ListItem>
                                        <asp:ListItem Value="7">Discapacidades</asp:ListItem>
                                        <asp:ListItem Value="8">Otros</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_anteFamiliares" BorderStyle="None" Style="width: 100%; text-transform: uppercase; font-size: 14px" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_anteFamDescripcion" BorderStyle="None" Style="width: 100%; text-transform: uppercase; font-size: 14px" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        4. ENFERMEDAD ACTUAL
                    </div>
                    <div class="list-group list-group-flush" style="height: auto; width: auto">
                        <asp:TextBox runat="server" ID="txt_enfeActual" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight:bold; font-family:Arial">
                        5. REVISIÓN DE ÓRGANOS Y SISTEMAS
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px">
                        <asp:Table class="table table-bordered table-responsive" runat="server">
                            <asp:TableRow Style="text-align: center; background-color: #DAFEF9">
                                <asp:TableCell Text="ÓRGANOS  Y SISTEMAS" Style="width: 350px; background-color: #cdfecc; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Text="EVIDENCIA PATOLÓGICA" Style="width: 350px; background-color: #cdfecc; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Text="DESCRIPCIÓN" Style="width: 600px; background-color: #cdfecc; font-size: 15px; font-family:Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Órganos de los Sentidos" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_orgSistemas" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descOrgSistemas" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Respiratorio" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_respiratorio" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descRespiratorio" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Cardio Vascular" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_carVascular" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descCarVascular" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Digestivo" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_digestivo" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descDigestivo" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Genital" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_genital" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descGenital" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Urinario" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_urinario" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descUrinario" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Muscular" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_muscular" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descMuscular" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Esquelético" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_esqueletico" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descEsqueletico" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Nervioso" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_nervioso" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descNervioso" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Endocrino" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_endocrino" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descEndocrino" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Hemo Linfático" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_hemoLinfatico" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descHemoLinfatico" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="Tegumentario (Piel y Faneras)" Style="background-color: #ccffff; font-size: 15px; font-family:Arial"></asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_tegumentario" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; background-color: transparent" Enabled="false" runat="server">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                        <asp:ListItem Value="1">Con Patologia</asp:ListItem>
                                        <asp:ListItem Value="2">Sin Patologia</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descTegumentario" BorderStyle="None" Style="width: 100%; text-transform:uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card card-responsive" style="width: auto">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        6. SIGNOS VITALES Y ANTROPOMÉTRICOS 
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; width: auto">
                        <div class="container" style="padding-top: 10px">
                            <asp:Table CssClass="table table-bordered table-responsive" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Presión Arterial (mmHg)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_presArterial" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Temperatura (°C)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_temperatura" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Frecuencia Cardiaca (Lat/min)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_frecCardiaca" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Saturación de Oxígeno (O2%)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_satOxigeno" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Frecuencia Respiratoria (fr/min)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_frecRespiratoria" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Peso (Kg)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_peso" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" OnTextChanged="txt_peso_TextChanged" AutoPostBack="true" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Talla (cm)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_talla" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" OnTextChanged="txt_talla_TextChanged" AutoPostBack="true" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Indice de Masa Corporal (kg/m2)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_indMasCorporal" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" ReadOnly="true"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell Style="width: 600px; font-size: 15px; font-family: Arial" Text="Perímetro Abdominal (cm)"></asp:TableCell>
                                    <asp:TableCell Style="width: 100px; font-size: 14px">
                                        <asp:TextBox ID="txt_perAbdominal" runat="server" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>
                <br />
                <div class="card card-responsive" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        7. EXAMEN FÍSICO
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered table-responsive" Style="text-align: center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="EXAMEN/REGIÓN ANATÓMICA" Style="width: 300px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="EVIDENCIA PATOLÓGICA" Style="width: 300px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="DESCRIPCIÓN" Style="width: 700px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_region" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                    <%--<asp:DropDownList ID="ddl_region" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; font-size: 14px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_region_SelectedIndexChanged"></asp:DropDownList>--%>
                                    <%--<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="ddl_tipoAntPer" InitialValue="0" runat="server" ForeColor="Red" />--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tipoRegion" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                    <%--<asp:DropDownList ID="ddl_tipoRegion" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; font-size: 14px" runat="server"></asp:DropDownList>--%>
                                    <%--<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="ddl_tipoAntPer" InitialValue="0" runat="server" ForeColor="Red" />--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_exafisdescripcion" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_region2" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                    <%--<asp:DropDownList ID="ddl_region" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; font-size: 14px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_region_SelectedIndexChanged"></asp:DropDownList>--%>
                                    <%--<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="ddl_tipoAntPer" InitialValue="0" runat="server" ForeColor="Red" />--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white">
                                    <asp:TextBox runat="server" ID="txt_tipoRegion2" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                    <%--<asp:DropDownList ID="ddl_tipoRegion" CssClass="form-check" Style="width: 100%; text-transform:uppercase; border: none; font-size: 14px" runat="server"></asp:DropDownList>--%>
                                    <%--<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="ddl_tipoAntPer" InitialValue="0" runat="server" ForeColor="Red" />--%>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_exafisdescripcion2" BorderStyle="None" Style="width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        8. DIAGNÓSTICOS
                    </div>
                    <div class="list-group list-group-flush" style="padding: 10px; text-align: center">
                        <asp:Table class="table table-bordered table-responsive" Style="text-align: center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="DIAGNÓSTICOS" Style="width: 500px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="CÓDIGO" Style="width: 100px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="TIPO" Style="width: 100px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="CONDICIÓN" Style="width: 100px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="CRONOLOGÍA" Style="width: 100px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="DESCRIPCIÓN" Style="width: 225px; background-color: #cdfecc; font-family: Arial; font-size: 15px; font-family: Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 250px; background-color: white; font-size: 14px">
                                    <%--<asp:DropDownList ID="ddl_diagnosticosDiagnostico" CssClass="form-control select2" data-toggle="select2" runat="server">
                                    </asp:DropDownList>--%>
                                    <asp:TextBox runat="server" ID="txt_diagnosticosDiagnostico" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 75px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_codigoDiagnostico" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="true"></asp:TextBox>
                                    <%--<asp:DropDownList ID="ddl_codigoDiagnostico" CssClass="form-control select2" data-toggle="select2" runat="server" OnSelectedIndexChanged="ddl_codigoDiagnostico_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>--%>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ControlToValidate="ddl_codDiagnostico" ValidationGroup="info" ErrorMessage="El codigo es requerido"></asp:RequiredFieldValidator>--%>
                                    <%--<asp:TextBox runat="server" ID="txt_codigoDiagnostico" BorderStyle="None" Style="width: 100%; text-transform:uppercase; text-align: center"></asp:TextBox>--%>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 100px; background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_tipoDiagnostico" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_condicionDiagnostico" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_cronologiaDiagnostico" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="background-color: white; font-size: 14px">
                                    <asp:TextBox runat="server" ID="txt_descripcionDiagnostico" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        9. PLAN DE TRATAMIENTO
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox runat="server" ID="txt_tratamiento" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        10. EVOLUCIÓN
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox runat="server" ID="txt_evolucion" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="card-header" style="background-color: #cccdfe; font-weight: bold; font-family: Arial">
                        11. PRESCRIPCIONES
                    </div>
                    <div class="list-group list-group-flush">
                        <asp:TextBox runat="server" ID="txt_prescipciones" BorderStyle="None" Style="background-color: transparent; width: 100%; text-transform: uppercase" TextMode="MultiLine" Rows="4" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="card" style="width: auto;">
                    <div class="list-group list-group-flush" style="padding: 10px">
                        <asp:Table class="table table-bordered table-responsive text-center" Style="text-align: center" runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="FECHA Y HORA" Style="background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="ESPECIALIDAD" Style="background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="NOMBRE DEL PROFESIONAL" Style="background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="CÓDIGO" Style="background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                                <asp:TableCell Text="FIRMA" Style="width: 150px; background-color: #cdfecc; font-size: 15px; font-family: Arial"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="width: 200px; background-color: white; font-size: 14px">
                                    <%--<asp:Timer ID="timerFechaHora"  OnTick="timerFechaHora_Tick" runat="server" Interval="15000"></asp:Timer>--%>
                                    <asp:TextBox runat="server" ID="txt_fechahora" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" TextMode="DateTimeLocal" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 400px; background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_especialidad" CssClass="form-check" Style="width: 100%; text-transform: uppercase; border: none; background-color: transparent" Enabled="false" runat="server"></asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 400px; background-color: white; font-size: 14px">
                                    <asp:DropDownList ID="ddl_profesional" CssClass="form-check" Style="width: 100%; text-transform: uppercase; border: none; background-color: transparent" Enabled="false" runat="server"></asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 200px; background-color: white; font-size: 14px">
                                    <asp:TextBox ID="txt_codigo" runat="server" BorderStyle="None" Style="width: 100%; text-transform: uppercase; text-align: center" ReadOnly="True"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell Style="width: 150px; background-color: white; font-size: 14px"></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <br />
                <div class="container" align="center">
                    <asp:Button CssClass="btn btn-info" ID="btn_imprimir" runat="server" Text="Imprimir" OnClick="btn_imprimir_Click" UseSubmitBehavior="False" />
                    <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" UseSubmitBehavior="False" />                    
                </div>
                <br />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_imprimir" />
            <%--<asp:PostBackTrigger ControlID="timerFechaHora"/>--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
