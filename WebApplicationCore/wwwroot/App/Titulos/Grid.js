"use strict";
var TituloGrid;
(function (TituloGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnclickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Titulos/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    TituloGrid.OnclickEliminar = OnclickEliminar;
    $("#GridView").DataTable();
})(TituloGrid || (TituloGrid = {}));
//# sourceMappingURL=Grid.js.map