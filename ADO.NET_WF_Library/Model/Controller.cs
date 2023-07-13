using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET_WF_Library.Model
{

  public  class Controller
    {
        public SqlConnection connection = null;
        public SqlDataAdapter adapter = null;

        int pageSize = 100;
        int currentPage = 0;
        public Controller() 
        {


            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;
            adapter = new SqlDataAdapter();


        }

        public void SelectAll()
        {
            adapter.SelectCommand = new SqlCommand(GetSelectSql(), connection);
            
        }
        public void SearchByName(string Name)
        {
            adapter.SelectCommand = new SqlCommand(GetSearchByName(Name), connection);
        }
        public void SearchByAuthorSurname(string Surname)
        {
            adapter.SelectCommand = new SqlCommand(GetSearchByAuthor(Surname), connection);
        }
        public void SearchByAuthorCategory(string Category)
        {
            adapter.SelectCommand= new SqlCommand(GetSearchByCategory(Category), connection);
        }





        public string GetSelectSql()
        {
            return $"SELECT* FROM Books ORDER BY Id OFFSET({currentPage}*{pageSize})" +
                $"ROW FETCH NEXT {pageSize} ROWS ONLY";
        }

        public string GetSearchByName(string Name)
        {

            return $"SELECT* FROM Books  WHERE Name = '{Name}'";

        }

        public string GetSearchByAuthor(string AuthorSurname)
        {

            return $"SELECT* FROM Books JOIN Authors ON Books.Id_Author =  Authors.Id Where Authors.LastName ='{AuthorSurname}'";

        }

        public string GetSearchByCategory(string Category) 
        {
        return $"SELECT* FROM Books JOIN Categories ON Books.Id_Category =  Categories.Id Where Categories.name ='{Category}'";
        }



    }
}
