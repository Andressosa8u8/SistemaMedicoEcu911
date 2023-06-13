//Validacion que direcciona a los textbox que estan vacios

<script type="text/javascript">
    function volverInicio() {


            //var camposVacios = document.querySelectorAll('.MsgCampoRequerido');
            //var camposVaciosError = document.querySelectorAll('.error-message');
            var hayCamposVacios = false;


            //camposVaciosError.forEach(function (errorSpan) {
            //    errorSpan.style.display = 'none';
            //});


            //camposVacios.forEach(function (textbox) {
            //    var errorSpanId = textbox.id + 'Error';
            //    var errorSpan = document.getElementById(errorSpanId);

            //    if (textbox.value === '') {
            //        errorSpan.textContent = "Campo requerido";
            //        errorSpan.style.display = 'inline';
            //        hayCamposVacios = true;
            //    }
            //});

            if (hayCamposVacios) {
        window.scrollTo(0, 0);
    return false; // No se dispara el evento OnClick
            }

    // Resto de tu lógica si no hay campos vacíos

    return true; // Se dispara el evento OnClick
        }
</script>