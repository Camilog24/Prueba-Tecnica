let datatable;
$(document).ready(function () {
    CargarTabla();
});

function CargarTabla() {
    datatable = $('#TablaDatos').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar page _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        "ajax": {
            "url": "/Admin/Bodega/ObtenerTodos"
        },
        "columns": [
            { "data": "Nombres", "width": "30%" },
            { "data": "Apellidos", "width": "15%" },
            { "data": "TipoIdentificacion", "width": "15%" },
            { "data": "NoIdentificacion", "width": "15%" },
            { "data": "Email", "width": "15%" },
            { "data": "FechaCreacion", "width": "15%" },
            
        ]
    })
}
function confirmar() {
    return confirm("¿Esta seguro de eliminar el empleado?")
}