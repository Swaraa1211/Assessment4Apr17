using Assessment4Apr17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assessment4Apr17.Controllers
{
    public class EditorController : Controller
    {
        IConfiguration _configuration;
        SqlConnection _connection;


        public EditorController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DBEditorContextConnection"));

        }

        public List<EditorModel> _EditorList = new List<EditorModel>();
        public IActionResult Index()
        {
            _connection.Open();
            string selectQuery = "SELECT * FROM Documents";
            using (SqlCommand cmd = new SqlCommand(selectQuery, _connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EditorModel editor = new EditorModel();


                    editor.DocumentID = (int)reader[0];
                    editor.Author = (string)reader[1];
                    editor.DocumentTitle = (string)reader[2];
                    _EditorList.Add(editor);
                }
                reader.Close();
            }

            ViewBag.EditorList = _EditorList;
            return View(ViewBag);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EditorModel editor)
        {
            _connection.Open();

            editor.Author = Request.Form["Author"];
            editor.DocumentTitle = Request.Form["DocumentTitle"];
            editor.DocumentContent = Request.Form["DocumentContent"];


            string addScheduleQuery = $"INSERT INTO Documents VALUES('{editor.Author}','{editor.DocumentTitle}','{editor.DocumentContent}')";

            try
            {
                using (SqlCommand cmd = new SqlCommand(addScheduleQuery, _connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public EditorModel GetDocument(int id)

        {
            EditorModel editor = new EditorModel();
            //string conn_string = _configuration.GetConnectionString("Text_Editor");
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();

            string query = $"SELECT * FROM Documents where DocumentID={id}";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                editor.Author = (string)reader["Author"];
                editor.DocumentTitle = (string)reader["DocumentTitle"];
                editor.DocumentContent = (string)reader["DocumentContent"];
            }
            reader.Close();
            _connection.Close();
            //appointmentList = db.AppointmentDetails.Where(x=>x.email==current_user_email).ToList();
            return editor;
        }

        public IActionResult Edit(int id)
        {
            return View(GetDocument(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, EditorModel editor)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE_DOCUMENT", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                DateTime current_date = DateTime.Now;
                cmd.Parameters.AddWithValue("@DocumentID", id);
                cmd.Parameters.AddWithValue("@DocumentContent", editor.DocumentContent);

                cmd.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("Index","Editor");
        }
        public IActionResult View(int id)
        {
            //return RedirectToAction("Index");
            return View(GetDocument(id));
        }
    }
}
