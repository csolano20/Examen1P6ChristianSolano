"use strict";
var PuestoGrid;
(function (PuestoGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnclickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Puestos/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    PuestoGrid.OnclickEliminar = OnclickEliminar;
    $("#GridView").DataTable();
})(PuestoGrid || (PuestoGrid = {}));
//# sourceMappingURL=Grid.js.map