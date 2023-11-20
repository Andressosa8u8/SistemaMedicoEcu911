<%@ Page Title="" Language="C#" MasterPageFile="~/views/Administrador_Medico/Medico.Master" AutoEventWireup="true" CodeBehind="Certificado_Covid.aspx.cs" Inherits="SistemaECU911.Template.Views.Certificado_Covid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Certificado Covid 19 | Sistema Médico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1474px;
        }

        .auto-style2 {
            width: 101%;
        }
    </style>
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
            <div class="container">
                <div class="card">
                    <div class="card-body">
                        <h2 class="text-center">CERTIFICADO COVID 19</h2>
                        <hr />
                        <h3 class="text-center">Datos Paciente</h3>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <label style="font-size: 13px">Numero de Cedula</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_cedula" OnTextChanged="txt_cedula_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="txt_cedula" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                    MinimumPrefixLength="1" ServiceMethod="ObtenerNumHClinica"
                                    TargetControlID="txt_cedula" CompletionListCssClass="CompletionList"
                                    CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                    CompletionListItemCssClass="CompletionListItem">
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label style="font-size: 13px">Primer Nombre</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_priNombre" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="txt_priNombre" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label style="font-size: 13px">Segundo Nombre</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_segNombre" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="txt_segNombre" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label style="font-size: 13px">Primer Apellido</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_priApellido" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ControlToValidate="txt_priApellido" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label style="font-size: 13px">Segundo Apellido</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_segApellido" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ControlToValidate="txt_segApellido" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label style="font-size: 13px">Cargo</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_Cargo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ControlToValidate="txt_Cargo" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label style="font-size: 13px">Institución</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_Institución" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ControlToValidate="txt_Institución" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label style="font-size: 13px">Domicilio</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_Domicilio" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txt_Domicilio" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label style="font-size: 13px">Telefono</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_Telefono" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="txt_Telefono" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="card">
                    <div class="card-body">
                        <h3 class="text-center">DATOS COVID 19</h3>
                        <br />
                        <div class="form-group">
                            <label style="font-size: 13px">Razon de la atención</label>
                            <asp:TextBox CssClass="required form-control" ID="txt_Atencion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txt_Atencion" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label style="font-size: 13px">Tipo de Contingencia</label>
                                <asp:DropDownList CssClass="required form-control" ID="ddl_tipoContingencia" runat="server">
                                    <asp:ListItem Value="0">Seleccione ----------</asp:ListItem>
                                    <asp:ListItem Value="1">Enfermedad General</asp:ListItem>
                                    <asp:ListItem Value="2">Enfermedad Ocupacional</asp:ListItem>
                                    <asp:ListItem Value="3">Gineco Obstetricia</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_tipoContingencia" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9">
                                <label style="font-size: 13px">Diagnóstico</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_diagnostico" OnTextChanged="txt_diagnostico_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txt_diagnostico" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10" DelimiterCharacters="" Enabled="True"
                                    MinimumPrefixLength="1" ServiceMethod="ObtenerCie10"
                                    TargetControlID="txt_diagnostico" CompletionListCssClass="CompletionList"
                                    CompletionListHighlightedItemCssClass="CompletionListHighlightedItem"
                                    CompletionListItemCssClass="CompletionListItem">
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <div class="col-md-3">
                                <label style="font-size: 13px">CIE 10</label>
                                <asp:TextBox CssClass="required form-control" ID="txt_cie" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txt_cie" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="container">
                            <div class="row">
                                <div class="col">
                                    <label style="font-size: 13px">Teletrabajo:</label>
                                </div>
                                <div class="col">
                                    <asp:CheckBox ID="ckb_teletrabajo" Checked="false" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="font-size: 13px">Enfermedad:</label>
                                </div>
                                <div class="col">
                                    <asp:CheckBox ID="ckb_enfermedad" Checked="false" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label style="font-size: 13px">Reposo:</label>
                                </div>
                                <div class="col">
                                    <asp:CheckBox ID="ckb_reposo" Checked="false" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="font-size: 13px">Presenta Sintomas:</label>
                                </div>
                                <div class="col">
                                    <asp:CheckBox ID="ckb_sintomas" Checked="false" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="card">
                    <div class="card-body">
                        <h3 class="text-center">SINTOMAS Y RECOMENDACIONES</h3>
                        <br />
                        <div class="row">
                            <center>
                                <div class="col-md-8">
                                    <label style="font-size: 13px">Descripción de Sintomatología: </label>
                                    <asp:TextBox CssClass="required form-control" ID="txt_sintomatologia" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txt_sintomatologia" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                                </div>
                            </center>
                        </div>
                        <div class="row">
                            <center>
                                <div class="col-md-9">
                                    <label style="font-size: 13px">Recomendaciones</label>
                                    <asp:TextBox CssClass="required form-control" ID="txt_recomendacion" align="center" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" ControlToValidate="txt_recomendacion" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                                </div>
                            </center>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="btnCertificado" OnClick="btnCertificado_Click" CssClass="btn btn-light" BorderColor="#1B4F72" runat="server" Text="Generar Certificado" ValidationGroup="GroupValidation" UseSubmitBehavior="False" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCertificado" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
