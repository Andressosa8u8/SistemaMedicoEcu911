//Funcion para validar que solo ingresen numeros en campos numericos

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