using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransitionMedicalDocExcelToHis.WebApp
{
    public partial class ExcelToGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (fileUploader.HasFile)
            {
                string folderPath = ConfigurationManager.AppSettings["FolderPath"].ToString();
                string fileName = Path.GetFileName(fileUploader.PostedFile.FileName);
                var filePath = Server.MapPath(folderPath + fileName);
                fileUploader.SaveAs(filePath);
                string extention = Path.GetExtension(fileUploader.PostedFile.FileName);
                InsertToGrid(extention,filePath,rbl.SelectedItem.Text);
            }
        }
       private OleDbConnection OleDbConnectionToExcel(string s, string filePath1, string hasHeader1)
        {
            var connectionString = "";

            switch (s)
            {
                case ".xls":
                    connectionString = ConfigurationManager.ConnectionStrings["Excel2003"].ConnectionString;
                    break;
                case ".xlsx":
                    connectionString = ConfigurationManager.ConnectionStrings["Excel2007"].ConnectionString;
                    break;
            }

            connectionString = string.Format(connectionString, filePath1, hasHeader1);
            string q = "";
            var oleDbConnection = new OleDbConnection(connectionString);
            return oleDbConnection;
        }
        private void InsertToGrid(string extention,string filePath, string hasHeader)
        {
           

            var connection = OleDbConnectionToExcel(extention, filePath, hasHeader);
            connection.Open();
            var dtSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = dtSchema.Rows[0]["TABLE_Name"].ToString();


           OleDbCommand cm = new OleDbCommand();
            cm.CommandText = "SELECT * From [" + sheetName + "]";
            OleDbDataAdapter oda = new OleDbDataAdapter();
            oda.SelectCommand = cm;
            cm.Connection = connection;
            DataTable dt = new DataTable();
            oda.Fill(dt);
            connection.Close();

            //Bind Data to GridView
            GridView1.Caption = Path.GetFileName(filePath);
            GridView1.DataSource = dt;
            GridView1.DataBind();





        }

    }
}