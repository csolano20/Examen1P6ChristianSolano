using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;


namespace WebApplicationCore.Pages.Puestos
{
    public class GridModel : PageModel
    {
        private readonly IPuestoService puestoService;

        public GridModel(IPuestoService puestoService)
        {
            this.puestoService = puestoService;
        }

        public IEnumerable<Puesto> GridList { get; set; } = new List<Puesto>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await puestoService.Get();
                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;

                }
                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await puestoService.Delete(new()
                {

                    ID = id

                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino Correctamente";
                return Redirect("Grid");


            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

    }
}


