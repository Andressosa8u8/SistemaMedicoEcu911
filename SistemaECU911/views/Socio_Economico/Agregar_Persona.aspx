<%@ Page Title="" Language="C#" MasterPageFile="~/views/Socio_Economico/Socio_Economico.Master" AutoEventWireup="true" CodeBehind="Agregar_Persona.aspx.cs" Inherits="SistemaECU911.Template.Views_Socio_Economico.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Registro de Personas | Socio Económico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
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
                <div class="row">
                    <div class="col-md-2">
                        <label class="form-label">CEDULA</label>
                        <asp:TextBox class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txt_cedula_TextChanged" ID="txt_cedula" Style="width: 100%; background-color: transparent; text-transform: uppercase"></asp:TextBox>
                        <asp:Label ID="lbl_cedula" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <label class="form-label">PRIMER NOMBRE</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_priNombre" Style="width: 100%; background-color: transparent; text-transform: uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_numHClinica" runat="server" ForeColor="Red" ControlToValidate="txt_priNombre" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">SEGUNDO NOMBRE</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_segNombre" Style="width: 100%; background-color: transparent; text-transform: uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txt_segNombre" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <label class="form-label">PRIMER APELLIDO</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_priApellido" Style="width: 100%; background-color: transparent; text-transform: uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txt_priApellido" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">SEGUNDO APELLIDO</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_segApellido" Style="width: 100%; background-color: transparent; text-transform: uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txt_segApellido" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <label class="form-label">FECHA DE NACIMIENTO</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_fechaNacimiento" Style="width: 100%; background-color: transparent; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="txt_fechaNacimiento" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">GÉNERO</label>
                        <asp:DropDownList ID="ddl_genero" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server">
                            <asp:ListItem Value="0" Text="Seleccione...."></asp:ListItem>
                            <asp:ListItem Text="M"></asp:ListItem>
                            <asp:ListItem Text="F"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_genero" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">INSTITUCIÓN</label>
                        <asp:DropDownList ID="ddl_zonal" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_zonal" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <label class="form-label">CENTRO</label>
                        <asp:DropDownList ID="ddl_centro" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_centro" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <label class="form-label">FECHA DE INGRESO AL TRABAJO</label>
                        <asp:TextBox class="form-control" runat="server" ID="txt_fechaIngresoTrabajo" Style="width: 100%; background-color: transparent; text-transform: uppercase" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txt_fechaIngresoTrabajo" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-9">
                        <label class="form-label">PUESTO DE TRABAJO</label>
                        <asp:DropDownList ID="ddl_puestoTrabajo" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server">
                            <asp:ListItem Value="0" Text="Seleccione...."></asp:ListItem>
                            <asp:ListItem Text="CENTRO OPERATIVO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="COORDINACION GENERAL ADMINISTRATIVA FINANCIERA"></asp:ListItem>
                            <asp:ListItem Text="COORDINACION GENERAL DE PLANIFICACION Y GESTION ESTRATEGICA"></asp:ListItem>
                            <asp:ListItem Text="COORDINACION ZONAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ADMINISTRATIVA"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ASESORIA JURIDICA"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION DE ADMINISTRACION DE RECURSOS HUMANOS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION DE COMUNICACION SOCIAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION DE GESTION DEL CAMBIO DE CULTURA ORGANIZATIVA"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION DE GESTION DOCUMENTAL Y ARCHIVO"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION DE PLANIFICACION E INVERSION"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION DE SEGUIMIENTO DE PLANES PROGRAMAS Y PROYECTOS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION DE SERVICIOS PROCESOS Y CALIDAD"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION FINANCIERA"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION GENERAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION NACIONAL ACADEMICO PARA EMERGENCIAS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION NACIONAL DE ANALISIS DE DATOS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION NACIONAL DE COORDINACION INTERINSTITUCIONAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION NACIONAL DE GESTION DE INFRAESTRUCTURA TECNOLOGICA PARA EMERGENCIAS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION NACIONAL DE OPERACIONES"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION NACIONAL DE PROYECTOS E INNOVACION TECNOLOGICA"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION NACIONAL REGULATORIO EN EMERGENCIAS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ZONAL ADMINISTRATIVA FINANCIERA Y DE ADMINISTRACION DE RECURSOS HUMANOS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ZONAL DE ASESORIA JURIDICA"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ZONAL DE COMUNICACION SOCIAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ZONAL DE ESTADISTICAS"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ZONAL DE OPERACIONES"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ZONAL DE PLANIFICACION Y GESTION ESTRATEGICA"></asp:ListItem>
                            <asp:ListItem Text="DIRECCION ZONAL DE TECNOLOGIA Y SOPORTE"></asp:ListItem>
                            <asp:ListItem Text="GESTION LOCAL ADMINISTRATIVA FINANCIERA Y DE ADMINISTRACION DE RECURSOS HUMANOS"></asp:ListItem>
                            <asp:ListItem Text="GESTION LOCAL DE ASESORIA JURIDICA"></asp:ListItem>
                            <asp:ListItem Text="GESTION LOCAL DE COMUNICACION SOCIAL"></asp:ListItem>
                            <asp:ListItem Text="GESTION LOCAL DE ESTADISTICA"></asp:ListItem>
                            <asp:ListItem Text="GESTION LOCAL DE OPERACIONES"></asp:ListItem>
                            <asp:ListItem Text="GESTION LOCAL DE PLANIFICACION Y GESTION ESTRATEGICA"></asp:ListItem>
                            <asp:ListItem Text="GESTION LOCAL DE SOPORTE TECNOLOGICO"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECCION GENERAL"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECCION TECNICA DE DOCTRINA"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECCION TECNICA DE OPERACIONES SIS"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECCION TECNICA DE TECNOLOGIA E INNOVACION"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_puestoTrabajo" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-7">
                        <label class="form-label">CARGO OCUPACIONAL</label>
                        <asp:DropDownList ID="ddl_cargo" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server">
                            <asp:ListItem Value="0" Text="Seleccione...."></asp:ListItem>
                            <asp:ListItem Text="ANALISTA ACADEMICO PARA EMERGENCIAS NACIONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE ADQUISICIONES II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE ADQUISICIONES ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE ASESORIA JURIDICA ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE CALIDAD I"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE CAMBIO DE CULTURA ORGANIZATIVA II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE COMUNICACION INTERNA Y EXTERNA II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE COMUNICACION LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE CONTABILIDAD ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE COORDINACION INTERINSTITUCIONAL NACIONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE ESTADISTICA LOCAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE ESTADISTICA ZONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE GESTION ADMINISTRATIVA Y FINANCIERA LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE GESTION DOCUMENTAL Y ARCHIVO I"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE INFRAESTRUCTURA TECNOLOGICA NACIONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE OPERACIONES LOCAL I"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE OPERACIONES LOCAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE OPERACIONES NACIONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE OPERACIONES ZONAL I"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE OPERACIONES ZONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PAGINA WEB Y REDES SOCIALES II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PATROCINIO Y NORMATIVA II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PLANIFICACION E INVERSION II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PLANIFICACION Y GESTION ESTRATEGICA LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PLANIFICACION Y GESTION ESTRATEGICA ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PRESUPUESTO Y NOMINA II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PROCESOS II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE PROYECTOS E INNOVACION TECNOLOGICA NACIONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE RECURSOS HUMANOS II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE RECURSOS HUMANOS LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE RECURSOS HUMANOS ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE SERVICIOS INSTITUCIONALES LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE SOPORTE LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE SOPORTE ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE TECNOLOGIA LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE TECNOLOGIA PARA EMERGENCIAS NACIONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE TECNOLOGIA ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE TESORERIA I"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE TESORERIA ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE VIDEO Y LLAMADAS DE EMERGENCIAS ZONAL II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE VINCULACION CON LA COMUNIDAD II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA DE VINCULACION CON LA COMUNIDAD ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA GEOESTADISCO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA GEOESTADISTICO II"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA GEOESTADISTICO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA GEOESTADISTICO ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA JURIDICO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ANALISTA REGULATORIO EN EMERGENCIAS NACIONAL II"></asp:ListItem>
                            <asp:ListItem Text="ASESOR 2"></asp:ListItem>
                            <asp:ListItem Text="ASESOR 4"></asp:ListItem>
                            <asp:ListItem Text="ASISTENTE TECNICO ADMINISTRATIVO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ASISTENTE TECNICO DE ASESORIA JURIDICA"></asp:ListItem>
                            <asp:ListItem Text="ASISTENTE TECNICO DE COMUNICACION SOCIAL"></asp:ListItem>
                            <asp:ListItem Text="ASISTENTE TECNICO DE CONTABILIDAD"></asp:ListItem>
                            <asp:ListItem Text="ASISTENTE TECNICO DE PRESUPUESTO Y NOMINA"></asp:ListItem>
                            <asp:ListItem Text="ASISTENTE TECNICO DE TESORERIA"></asp:ListItem>
                            <asp:ListItem Text="ASISTENTE TECNICO DE TRANSPORTE"></asp:ListItem>
                            <asp:ListItem Text="AUXILIAR DE SERVICIOS"></asp:ListItem>
                            <asp:ListItem Text="AUXILIAR DE SERVICIOS GENERALES"></asp:ListItem>
                            <asp:ListItem Text="AUXILIAR DE SERVICIOS GENERALES LOCAL"></asp:ListItem>
                            <asp:ListItem Text="CHOFER"></asp:ListItem>
                            <asp:ListItem Text="CHOFER BUS"></asp:ListItem>
                            <asp:ListItem Text="CHOFER DE VEHICULO LIVIANO"></asp:ListItem>
                            <asp:ListItem Text="CHOFER DE VEHICULOS PESADOS"></asp:ListItem>
                            <asp:ListItem Text="CHOFER/CONDUCTOR"></asp:ListItem>
                            <asp:ListItem Text="CONDUCTOR"></asp:ListItem>
                            <asp:ListItem Text="CONDUCTOR ADMINISTRATIVO"></asp:ListItem>
                            <asp:ListItem Text="CONDUCTOR DE VEHICULO LIVIANO"></asp:ListItem>
                            <asp:ListItem Text="CONDUCTOR DE VEHICULOS LIVIANOS"></asp:ListItem>
                            <asp:ListItem Text="CONDUCTOR LOCAL"></asp:ListItem>
                            <asp:ListItem Text="CONTADOR GENERAL"></asp:ListItem>
                            <asp:ListItem Text="COORDINADOR GENERAL ADMINISTRATIVO FINANCIERO"></asp:ListItem>
                            <asp:ListItem Text="COORDINADOR GENERAL DE PLANIFICACION Y GESTION ESTRATEGICA"></asp:ListItem>
                            <asp:ListItem Text="COORDINADOR ZONAL"></asp:ListItem>
                            <asp:ListItem Text="COORDINADORA DE DESPACHO INSTITUCIONAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR ADMINISTRATIVO"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR DE COMUNICACION SOCIAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR DE GESTION DOCUMENTAL Y ARCHIVO"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR DE PLANIFICACION E INVERSION"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR DE SEGUIMIENTO DE PLANES, PROGRAMAS Y PROYECTOS"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR FINANCIERO"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR GENERAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR NACIONAL ACADEMICO PARA EMERGENCIAS"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR NACIONAL DE ANALISIS DE DATOS"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR NACIONAL DE COORDINACION INTERINSTITUCIONAL"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR NACIONAL DE GESTION DE INFRAESTRUCTURA TECNOLOGICA PARA EMERGENCIA"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR NACIONAL DE OPERACIONES"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR NACIONAL DE PROYECTOS E INNOVACION TECNOLOGICA"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR NACIONAL REGULATORIO EN EMERGENCIAS"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR ZONAL DE ESTADISTICA"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR ZONAL DE OPERACIONES"></asp:ListItem>
                            <asp:ListItem Text="DIRECTOR ZONAL DE TECNOLOGIA Y SOPORTE"></asp:ListItem>
                            <asp:ListItem Text="DIRECTORA DE ADMINISTRACION DE RECURSOS HUMANOS"></asp:ListItem>
                            <asp:ListItem Text="DIRECTORA DE ASESORIA JURIDICA"></asp:ListItem>
                            <asp:ListItem Text="DIRECTORA ZONAL DE OPERACIONES"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA ACADEMICO PARA EMERGENCIAS NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE ACTIVOS"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE ADQUISICIONES"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE ADQUISICIONES ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE ANALISIS DE DATOS NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE CALIDAD"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE COMUNICACION INTERNA Y EXTERNA"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE COMUNICACION SOCIAL ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE CONSULTAS JURIDICAS Y CONTRATACION PUBLICA"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE COORDINACION INTERINSTITUCIONAL NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE ESTADISTICA ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE GESTION DOCUMENTAL Y ARCHIVO"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE INFRAESTRUCTURA TECNOLOGICA NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE OPERACIONES LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE OPERACIONES ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE PAGINA WEB Y REDES SOCIALES"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE PATROCINIO Y NORMATIVA"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE PLANIFICACION E INVERSION"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE PRESUPUESTO Y NOMINA"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE PROCESOS"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE PROYECTOS E INNOVACION TECNOLOGICA NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE RECURSOS HUMANOS"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE RECURSOS HUMANOS ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE SEGUIMIENTO DE PLANES, PROGRAMAS Y PROYECTOS"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE SEGURIDAD Y SALUD OCUPACIONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE SEGURIDAD Y SALUD OCUPACIONAL ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE SERVICIOS INSTITUCIONALES"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE SERVICIOS INSTITUCIONALES ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE SOPORTE TECNOLOGICO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE TECNOLOGIA PARA EMERGENCIAS NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE TECNOLOGIA Y SOPORTE ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA DE VINCULACION CON LA COMUNIDAD"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA FINANCIERO ZONAL"></asp:ListItem>
                            <asp:ListItem Text="ESPECIALISTA REGULATORIO EN EMERGENCIAS NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="EVALUADOR DE OPERACIONES LOCAL"></asp:ListItem>
                            <asp:ListItem Text="EVALUADOR DE OPERACIONES ZONAL"></asp:ListItem>
                            <asp:ListItem Text="GUARDALMACEN LOCAL"></asp:ListItem>
                            <asp:ListItem Text="GUARDALMACEN NACIONAL"></asp:ListItem>
                            <asp:ListItem Text="GUARDALMACEN ZONAL"></asp:ListItem>
                            <asp:ListItem Text="JEFE DE CENTRO OPERATIVO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="MEDICO"></asp:ListItem>
                            <asp:ListItem Text="OFICINISTA ZONAL"></asp:ListItem>
                            <asp:ListItem Text="OPERADOR DE CCTV"></asp:ListItem>
                            <asp:ListItem Text="OPERADOR DE RADIO"></asp:ListItem>
                            <asp:ListItem Text="OPERADOR DE VIDEO LLAMADAS DE EMERGENCIAS LOCAL"></asp:ListItem>
                            <asp:ListItem Text="OPERADOR DE VIDEO LLAMADAS DE EMERGENCIAS ZONAL"></asp:ListItem>
                            <asp:ListItem Text="RECEPCIONISTA"></asp:ListItem>
                            <asp:ListItem Text="SECRETARIA"></asp:ListItem>
                            <asp:ListItem Text="SECRETARIA LOCAL"></asp:ListItem>
                            <asp:ListItem Text="SECRETARIA ZONAL"></asp:ListItem>
                            <asp:ListItem Text="SECRETARIA/O"></asp:ListItem>
                            <asp:ListItem Text="SECRETARIO"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECTOR GENERAL"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECTOR TECNICO DE DOCTRINA"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECTOR TECNICO DE OPERACIONES SIS"></asp:ListItem>
                            <asp:ListItem Text="SUBDIRECTOR TECNICO DE TECNOLOGIA E INNOVACION"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE ACTIVOS"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE CONTROL CCTV"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE GESTION DOCUMENTAL Y ARCHIVO"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE INFRAESTRUCTURA CIVIL Y MANTENIMIENTO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE MANTENIMIENTO"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE MANTENIMIENTO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE RECURSOS HUMANOS"></asp:ListItem>
                            <asp:ListItem Text="TECNICO DE SERVICIOS INSTITUCIONALES ZONAL"></asp:ListItem>
                            <asp:ListItem Text="TECNICO EN MANTENIMIENTO"></asp:ListItem>
                            <asp:ListItem Text="TECNICO FINANCIERO ZONAL"></asp:ListItem>
                            <asp:ListItem Text="TESORERO"></asp:ListItem>
                            <asp:ListItem Text="TRABAJADOR/A SOCIAL ZONAL"></asp:ListItem>
                            <asp:ListItem Text="TRABAJADORA SOCIAL NACIONAL"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_cargo" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <label class="form-label">AREA DE TRABAJO</label>
                        <asp:DropDownList ID="ddl_area" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server">
                            <asp:ListItem Value="0" Text="Seleccione...."></asp:ListItem>
                            <asp:ListItem Text="ADMINISTATIVO FINANCIERO Y RECURSOS HUMANOS"></asp:ListItem>
                            <asp:ListItem Text="APOYO"></asp:ListItem>
                            <asp:ListItem Text="ASESORIA JURIDICA"></asp:ListItem>
                            <asp:ListItem Text="CENTRO OPERATIVO LOCAL"></asp:ListItem>
                            <asp:ListItem Text="COMUNICACION"></asp:ListItem>
                            <asp:ListItem Text="DOCTRINA"></asp:ListItem>
                            <asp:ListItem Text="ESTADISTICA"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE APOYO - BABAHOYO"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE APOYO - SAMBORONDON"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE APOYO - GALAPAGOS"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE OPERACIONES - BABAHOYO"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE OPERACIONES - SAMBORONDON"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE OPERACIONES - GALAPAGOS"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE TECNOLOGIA - BABAHOYO"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE TECNOLOGIA - SAMBORONDON"></asp:ListItem>
                            <asp:ListItem Text="GESTION DE TECNOLOGIA - GALAPAGOS"></asp:ListItem>
                            <asp:ListItem Text="JURIDICO"></asp:ListItem>
                            <asp:ListItem Text="OPERACIONES"></asp:ListItem>
                            <asp:ListItem Text="PLANIFICACION"></asp:ListItem>
                            <asp:ListItem Text="TECNOLOGIA"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_area" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">ESTADO</label>
                        <asp:DropDownList ID="ddl_estado" CssClass="form-control" Style="width: 100%; text-transform: uppercase; background-color: transparent; font-size: 14px" runat="server">
                            <asp:ListItem Value="0" Text="SELECCIONE ......"></asp:ListItem>
                            <asp:ListItem Value="AP" Text="ACTIVO"></asp:ListItem>
                            <asp:ListItem Value="PP" Text="PASIVO"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" InitialValue="0" ControlToValidate="ddl_estado" ErrorMessage="CAMPO OBLIGATORIO" ValidationGroup="GroupValidation"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="col-12" style="text-align: center">
                    <asp:Button CssClass="btn btn-warning" ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="Guardar" UseSubmitBehavior="False" ValidationGroup="GroupValidation" />
                    <asp:Button CssClass="btn btn-danger" ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" Text="Cancelar" UseSubmitBehavior="False" />
                </div>
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
