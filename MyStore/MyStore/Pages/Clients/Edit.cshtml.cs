using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Model;

namespace MyStore.Pages.Clients
{
    public class EditModel : PageModel
    {
        public MyDatabase database;
        public string errorMessage = "";
        public ClientInfo clientInfo = new ClientInfo();

        public EditModel(MyDatabase database)
        {
            this.database = database;
        }
        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                clientInfo = database.Get(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost() {
            var id = Int32.Parse(Request.Query["id"]);

            clientInfo.Name = Request.Form["Name"];
            clientInfo.Email = Request.Form["Email"];
            clientInfo.Phone = Request.Form["Phone"];
            clientInfo.Address = Request.Form["Address"];

            if (clientInfo.Name.Length == 0
                    || clientInfo.Email.Length == 0
                    || clientInfo.Phone.Length == 0
                    || clientInfo.Address.Length == 0)
            {
                errorMessage = "All Fields are Mendatory";
                return;
            }

            try
            {
                database.Update(id, clientInfo);
                Response.Redirect("/Clients/");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return;
        }
    }
}
