using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Model;
using System.Data.SqlClient;

namespace MyStore.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public MyDatabase database;
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";

        public CreateModel(MyDatabase database)
        {
            this.database = database;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
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

            database.Insert(clientInfo);
            Response.Redirect("/Clients/");

        }
    }

}
