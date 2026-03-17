using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using modle;

namespace ViewModel
{
    public abstract   class BaseDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +System.Windows.Forms.Application.StartupPath  + @"\DB.mdf"";Integrated Security=True;Connect Timeout=30";      
        protected SqlConnection connection;   
        public SqlCommand command;        
        protected SqlDataReader reader;
        public int LastId;


        public abstract BaseEntity NewEntity();
        public abstract BaseEntity CreateModel(BaseEntity entity);

       

        public BaseDB()
        {
            
            connection = new SqlConnection(connectionString);

            command = new SqlCommand();
         
            command.Connection = connection;
        }


        public List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();

            try
            {
                command.Connection = this.connection;
                connection.Open();
                reader = command.ExecuteReader();
                command.CommandText = "Select @@Identity";
              
              


                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    
                    
                    list.Add(CreateModel(entity));
                    //האם אפשר לקצר?  
                    //list.Add(CreatModel(NewEntity()));


                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.Write(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();

                }
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return list;
        }
        public bool SaveChanges( string sqlStr)
        {
          
            int record = 0;
           
           command.CommandText = sqlStr;
            try
            {

                command.Connection = this.connection;
                this.connection.Open();
                record = command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                LastId = Convert.ToInt32( command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + command.CommandText);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            

              if (record==0)
                return false;
             return true;
        }

        
        

    }
}
    