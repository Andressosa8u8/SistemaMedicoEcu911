<%@ Page Title="" Language="C#" MasterPageFile="~/views/Doctores/Medico.Master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="SistemaECU911.views.Doctores.Configuracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Configuración Usuario | Sistema Médico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body p-0">
                            <div class="iq-edit-list usr-edit">
                                <ul class="iq-edit-profile d-flex nav nav-pills">
                                    <li class="col-md-6 p-0">
                                        <a class="nav-link active" data-toggle="pill" href="#personal-information">Información Personal
                                        </a>
                                    </li>
                                    <li class="col-md-6 p-0">
                                        <a class="nav-link" data-toggle="pill" href="#chang-pwd">Cambio de Contraseña
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="iq-edit-list-data">
                        <div class="tab-content">
                            <div class="tab-pane fade active show" id="personal-information" role="tabpanel">
                                <div class="card">
                                    <div class="card-body">
                                        <form>
                                            <div class="form-group row align-items-center">
                                                <div class="col-md-12">
                                                    <div class="profile-img-edit">
                                                        <div class="crm-profile-img-edit">
                                                            <img class="crm-profile-pic rounded-circle avatar-100" src="../../resources/assets/images/User.png" alt="profile-pic">
                                                            <div class="crm-p-image bg-primary">
                                                                <i class="las la-pen upload-button"></i>
                                                                <input class="file-upload" type="file" accept="image/*">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=" row align-items-center">
                                                <div class="form-group col-sm-6">
                                                    <label for="txt_priNombre">PRIMER NOMBRE:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_priNombre" style="text-transform:uppercase" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-6">
                                                    <label for="txt_segNombre">SEGUNDO NOMBRE:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_segNombre" style="text-transform:uppercase" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-6">
                                                    <label for="txt_priApellido">PRIMER APELLIDO:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_priApellido" style="text-transform:uppercase" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-6">
                                                    <label for="txt_segApellido">SEGUNDO APELLIDO:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_segApellido" style="text-transform:uppercase" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-6">
                                                    <label for="txt_user">NOMBRE DE USUARIO:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_user" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-6">
                                                    <label for="cname">CORREO INSTITUCIONAL:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_correoInsti" TextMode="Email" runat="server"></asp:TextBox>
                                                </div>                                                                                             
                                                <div class="form-group col-sm-2">
                                                    <label class="d-block">GENERO:</label>
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:CheckBox ID="ckb_Hombre" Enabled="true" runat="server" />
                                                            <label>Hombre</label>
                                                        </div>
                                                        <div class="col">
                                                            <asp:CheckBox ID="ckb_Mujer" Enabled="true" runat="server" />
                                                            <label>Mujer</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group col-sm-2">
                                                    <label for="txt_fechNacimiento">FECHA DE NACIMIENTO:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_fechNacimiento" TextMode="Date" runat="server"></asp:TextBox>
                                                </div>  
                                                <div class="form-group col-sm-2">
                                                    <label for="txt_fechIngreso">TELEFONO:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_telefono" TextMode="Phone" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-6">
                                                    <label for="txt_fechIngreso">DIRECCIÓN DEL DOMICILIO:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_direccion" style="background-color:transparent" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-2">
                                                    <label for="txt_fechIngreso">FECHA DE INGRESO:</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_fechIngreso" TextMode="Date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-sm-7">
                                                    <label>INSTITUCIÓN:</label>
                                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                                        <asp:ListItem>SERVICIO INTEGRADO DE SEGURIDAD ECU 911</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group col-sm-3">
                                                    <label>ZONAL:</label>
                                                    <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">
                                                        <asp:ListItem>PORTOVIEJO - MANTA</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group col-sm-12">
                                                    <label>AREA DE TRABAJO:</label>
                                                    <asp:DropDownList CssClass="form-control" ID="ddl_puestoTrabajo" runat="server">
                                                        <asp:ListItem>DIRECCION ZONAL ADMINISTRATIVA FINANCIERA Y DE ADMINISTRACION DE RECURSOS HUMANOS</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group col-sm-12">
                                                    <label>CARGO:</label>
                                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                                        <asp:ListItem>DIRECTOR NACIONAL DE GESTION DE INFRAESTRUCTURA TECNOLOGICA PARA EMERGENCIA</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>                                                
                                            </div>
                                            <br />
                                            <asp:Button CssClass="btn btn-primary" ID="btn_actualizar" runat="server" Text="Guardar" UseSubmitBehavior="False" ValidationGroup="GroupValidation"/>
                                            <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" runat="server" Text="Cancelar" UseSubmitBehavior="False" />
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="chang-pwd" role="tabpanel">
                                <div class="card">
                                    <div class="card-header d-flex justify-content-between">
                                        <div class="iq-header-title">
                                            <h4 class="card-title">Change Password</h4>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <form>
                                            <div class="form-group">
                                                <label for="cpass">Current Password:</label>
                                                <a href="javascripe:void();" class="float-right">Forgot Password</a>
                                                <input type="Password" class="form-control" id="cpass" value="">
                                            </div>
                                            <div class="form-group">
                                                <label for="npass">New Password:</label>
                                                <input type="Password" class="form-control" id="npass" value="">
                                            </div>
                                            <div class="form-group">
                                                <label for="vpass">Verify Password:</label>
                                                <input type="Password" class="form-control" id="vpass" value="">
                                            </div>
                                            <button type="submit" class="btn btn-primary mr-2">Submit</button>
                                            <button type="reset" class="btn iq-bg-danger">Cancel</button>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
