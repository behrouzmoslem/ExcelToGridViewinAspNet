using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace TransitionMedicalDocExcelToHis.WebApp
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (fileUploader.HasFile)
            {
                string fileName = Path.GetFileName(fileUploader.PostedFile.FileName);
                string folderPath = ConfigurationManager.AppSettings["FolderPath"].ToString();
                string filePath = Server.MapPath(folderPath + fileName);
                fileUploader.SaveAs(filePath);
                string extension = Path.GetExtension(fileUploader.PostedFile.FileName);
                grid1.DataSource = ReadyDataOnExcel(extension, filePath);
                grid1.DataBind();
            }
        }

        private DataTable ReadyDataOnExcel(string extension, string filePath)
        {
            var connectionString = CreateConnection(extension, filePath, rbl.SelectedItem.Text);

            var shemaName = GetSchemaName(connectionString);


            return GetData(connectionString, shemaName);
        }

        private DataTable GetData(string connectionString, string shemaName)
        {
            using (var oleDb = new OleDbConnection(connectionString))
            {
                OleDbCommand oleDbCommand = new OleDbCommand
                {
                    CommandText = "Select * from [" + shemaName + "]",
                    Connection = oleDb
                };
                var oleDbDataAdapter = new OleDbDataAdapter { SelectCommand = oleDbCommand };
                var dataTable = new DataTable();
                oleDbDataAdapter.Fill(dataTable);
                return dataTable;

            }
        }

        private static string GetSchemaName(string connectionString)
        {
            using (OleDbConnection connection = new
                OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                if (schemaTable != null)
                {
                    return schemaTable.Rows[0]["TABLE_Name"].ToString();
                }
                return "";
            }
        }

        private string CreateConnection(string extension, string filePath, string hasHeader)
        {
            var connectionString = "";
            switch (extension)
            {
                case ".xls":
                    connectionString = ConfigurationManager.ConnectionStrings["Excel2003"].ConnectionString;
                    break;
                case ".xlsx":
                    connectionString = ConfigurationManager.ConnectionStrings["Excel2007"].ConnectionString;
                    break;
            }


            connectionString = string.Format(connectionString, filePath, hasHeader);
            return connectionString;
        }
    }
}