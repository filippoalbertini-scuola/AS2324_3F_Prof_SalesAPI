using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SQLite;

namespace AS2324_3F_Prof_SalesAPI.Controllers
{
    public class ClientsController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        string strConn = "";

        public ClientsController(IWebHostEnvironment webHostEnvironment)
        {
            // https://stackoverflow.com/questions/49398965/what-is-the-equivalent-of-server-mappath-in-asp-net-core
            _webHostEnvironment = webHostEnvironment;

            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            string file = "";

            file = Path.Combine(contentRootPath, "Database", "northwindITA.db");

            // connessione al DB in SQL Lite (vedi www.connectionstrings.com)
            strConn = @"Data Source=" + file + ";Pooling=false;Synchronous=Full;";
        }

        [HttpGet("GetClients")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataTable))]
        public JsonResult GetClients()
        {
            DataTable? dtbClients = null;

            try
            {

                // apro la connessione al database
                SQLiteConnection conn = new SQLiteConnection(strConn);
                conn.Open();

                // carico il data table clienti

                // prepara la QUERY
                string query = "";

                query = "";
                query = query + "SELECT ";
                query = query + "   IdCliente, NomeSocieta, Indirizzo ";
                query = query + "FROM ";
                query = query + "   Clienti ";

                // crea DataAdapter
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);


                // popola il DataTable con DataAdapter 
                dtbClients = new DataTable();

                da.Fill(dtbClients);

                conn.Close();

            }
            catch (Exception ex)
            {

                // there is an error !
                Console.WriteLine(ex.Message);

                return Json(new { status = "KO", output = ex.Message });
            }


            return Json(new { status ="OK",output = dtbClients });

        }
    }
}
