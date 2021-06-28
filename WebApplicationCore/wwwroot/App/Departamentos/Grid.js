"use strict";
var DepartamentoGrid;
(function (DepartamentoGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnclickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Departamentos/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    DepartamentoGrid.OnclickEliminar = OnclickEliminar;
    $("#GridView").DataTable();
})(DepartamentoGrid || (DepartamentoGrid = {}));
//# sourceMappingURL=Grid.js.map