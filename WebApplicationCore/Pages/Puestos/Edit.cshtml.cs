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
    public class EditModel : PageModel
    {
        private readonly IPuestoService puestoService;

        public EditModel(IPuestoService puestoService)
        {
            this.puestoService = puestoService;
        }

        [BindProperty]
        public Puesto Entity { get; set; } = new Puesto();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {
                    Entity = await puestoService.GetById(new() { ID = id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (Entity.ID.HasValue)
                {
                    //Actualizar 
                    var result = await puestoService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualiz� correctamente";
                }
                else
                {
                    //Nuevo 
                    var result = await puestoService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agreg� correctamente";

                }

                return RedirectToPage("Grid");
            }



            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}