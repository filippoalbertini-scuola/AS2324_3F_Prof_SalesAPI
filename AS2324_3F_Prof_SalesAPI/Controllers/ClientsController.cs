using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SQLite;

namespace AS2324_3F_Prof_SalesAPI.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("GetClients")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataTable))]
        public JsonResult GetClients()
        {
            string strConn = "";
            string file = "C:\\Appl\\Scuola\\AS_2023_2024\\3G\\AS2324_3F_Prof_SalesAPI\\AS2324_3F_Prof_SalesAPI\\Database\\northwindITA.db";

            // connessione al DB in SQL Lite (vedi www.connectionstrings.com)
            strConn = @"Data Source=" + file + ";Pooling=false;Synchronous=Full;";

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

            DataTable? dtbClients = null;
            // popola il DataTable con DataAdapter 
            dtbClients = new DataTable();

            da.Fill(dtbClients);

            conn.Close();

            //return Json(new { output = dtbClients });
            return Json(dtbClients);

        }
    }
}
