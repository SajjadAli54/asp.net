using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Model;

namespace MyStore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public MyDatabase database;
        public List<ClientInfo> listClients;

        public IndexModel(MyDatabase database)
        {
            this.database = database;
        }

        public void OnGet()
        {
                listClients = database.GetAll();
        }
    }

    
}
