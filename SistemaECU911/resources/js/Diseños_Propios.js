/*Julian*/

$(document).ready(function () {
    var dataTable = $('#<%= grvPacientes.ClientID %>').DataTable({
        "columns": [
            { "data": "Per_cedula", "title": "CÉDULA" },
            { "data": "Per_priNombre", "title": "PRIMER NOMBRE" },
            { "data": "Per_segNombre", "title": "SEGUNDO NOMBRE" },
            { "data": "Per_priApellido", "title": "PRIMER APELLIDO" },
            { "data": "Per_segApellido", "title": "SEGUNDO APELLIDO" },
            { "data": "Per_genero", "title": "GÉNERO" },

            null // Columna de EDICIÓN sin datos específicos
        ],
        dom: '<"top"lfB>rtip',
        buttons: [
            {
                extend: 'excel',
                text: '',
                className: 'btn btn-secondary',
                init: function (api, node, config) {
                    $(node).append('<i class="fas fa-file-excel fa-lg"></i>');
                },
                title: 'LISTADO DE PACIENTES', // Título del contenido del EXCEL
                action: function (e, dt, node, config) {
                    var filename = prompt('Ingrese el nombre del archivo Excel', '');
                    if (filename !== null && filename !== '') {
                        config.filename = filename;
                        $.fn.dataTable.ext.buttons.excelHtml5.action.call(this, e, dt, node, config);
                    }
                }
            },
            {
                extend: 'pdf',
                text: '',
                className: 'btn btn-secondary',
                init: function (api, node, config) {
                    $(node).append('<i class="fas fa-file-pdf fa-lg"></i>');
                },
                title: 'LISTADO DE PACIENTES', // Título del contenido del PDF
                action: function (e, dt, node, config) {
                    var filename = prompt('Ingrese el nombre del archivo PDF', '');
                    if (filename !== null && filename !== '') {
                        config.filename = filename;
                        $.fn.dataTable.ext.buttons.pdfHtml5.action.call(this, e, dt, node, config);
                    }
                }
            },
            {
                title: 'LISTADO DE PACIENTES', // Título del contenido en IMPRIMIR
                extend: 'print',
                text: '',
                className: 'btn btn-secondary',
                init: function (api, node, config) {
                    $(node).append('<i class="fas fa-print fa-lg"></i>');
                }
            }
        ],
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
        "language": {
            "lengthMenu": 'Show <select>' +
                '<option value="10">10</option>' +
                '<option value="25">25</option>' +
                '<option value="50">50</option>' +
                '<option value="-1">Todos</option>' +
                '</select> entries'
        },
        "initComplete": function (settings, json) {
            var table = this.api();
            var lengthMenuContainer = $(table.table().container()).find('.dataTables_length');
            var searchContainer = $(table.table().container()).find('.dataTables_filter');
            var buttonsContainer = $('<div class="float-right ml-2"></div>');

            lengthMenuContainer.addClass('d-inline-block');
            lengthMenuContainer.find('label').addClass('mr-2 mb-0');
            lengthMenuContainer.find('select').addClass('custom-length-select');

            searchContainer.addClass('d-inline-block').addClass('mr-2');

            table.buttons().container().appendTo(buttonsContainer);
            $('.top').prepend(buttonsContainer);
        },
        "drawCallback": function (settings) {
            var table = this.api();
            var lengthSelect = $(table.table().container()).find('.custom-length-select');
            lengthSelect.val(table.page.len());
        }
    });
});


/*Antoni*/

var objetoLista;
var arraydepartamento = [];
var arraynumeroPersonas = [];

jQuery.ajax({
    url: 'Inicio.aspx/ListaNPersonas',
    type: "POST",
    dataType: "JSON",
    contentType: "application/json; charset=utf8-8",
    success: function (data) {
        objetoLista = data.d

        console.log(objetoLista);

        for (var i = 0; i < objetoLista.length; i++) {


            //console.log(objetoLista[i][0])
            //console.log(objetoLista[i][1])                    
            arraydepartamento.push(objetoLista[i][0])
            arraynumeroPersonas.push(objetoLista[i][1])
        }

        //

        const ctx = document.getElementById('myChart');

        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: arraydepartamento,
                datasets: [{
                    label: 'Departamentos',
                    data: arraynumeroPersonas,
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });

        //
    },
    error: function (error) {
        console.log(error)
    }
});