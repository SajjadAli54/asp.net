using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Model;

namespace MyStore.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        public MyDatabase database;

        public DeleteModel(MyDatabase database)
        {
            this.database = database;
        }
        public void OnGet()
        {
            var id = Request.Query["id"];
            database.Delete(Int32.Parse(id));

            Response.Redirect("/Clients/");
        }
    }
}
