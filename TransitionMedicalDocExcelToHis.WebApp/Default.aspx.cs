using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace TransitionMedicalDocExcelToHis.WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                var fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                var extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                var folderPath = ConfigurationManager.AppSettings["FolderPath"];
                var filePath = Server.MapPath(folderPath + fileName);
                FileUpload1.SaveAs(filePath);

                importToGridView(filePath, extension, rbHDR.SelectedItem.Text);
            }
        }

        private void importToGridView(string filePath, string extention, string hasHeader)
        {
            string connectionString = "";
            switch (extention)
            {
                case ".xls":
                    connectionString = ConfigurationManager.ConnectionStrings["Excel2003"].ConnectionString;
                    break;
                case ".xlsx":
                    connectionString = ConfigurationManager.ConnectionStrings["Excel2007"].ConnectionString;
                    break;
            }
            connectionString = string.Format(connectionString, filePath,hasHeader);
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            OleDbCommand dbCommand = new OleDbCommand();
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter();
            DataTable dataTable = new DataTable();
            dbCommand.Connection = dbConnection;
            dbConnection.Open();
            DataTable dtSchema;
            dtSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = dtSchema.Rows[0]["Table_Name"].ToString();
            dbConnection.Close();
            dbConnection.Open();
            dbCommand.CommandText = "select * from [" + sheetName + "]";
            dbDataAdapter.SelectCommand = dbCommand;
            dbDataAdapter.Fill(dataTable);
            dbConnection.Close();
            gridview1.Caption = Path.GetFileName(filePath);
            gridview1.DataSource = dataTable;
            gridview1.DataBind();

        }
    }
}