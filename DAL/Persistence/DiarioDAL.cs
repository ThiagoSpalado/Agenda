using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public class DiarioDAL : DAL
    {
        public bool Salvar(Diario d)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("SalvarDia", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@Diario", d.Diary);
                Cmd.Parameters.AddWithValue("@Data", d.Data.Replace("00:00:00", ""));

                return Cmd.ExecuteNonQuery() > 0;                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Editar(Diario d)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("AlterarDia", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@Diario", d.Diary);
                Cmd.Parameters.AddWithValue("@Data", d.Data.Replace("00:00:00", ""));

                return Cmd.ExecuteNonQuery() > 0;                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public string Buscar(Diario d)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("BuscarDia", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@Data", d.Data.Replace("00:00:00", ""));

                Dr = Cmd.ExecuteReader();

                List<Diario> dados = new List<Diario>();

                while (Dr.Read())
                {
                    d.Diary = Dr.GetString(0);
                    dados.Add(d);
                }

                return d.Diary;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
