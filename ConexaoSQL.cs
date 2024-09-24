using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ConexaoSQL
    {
        private string connectionString;
        private SqlConnection conexao;

        public ConexaoSQL(string server, string database, string usuario, string senha)
        {
            connectionString = $"Server={server};Database={database};User Id={usuario};Password={senha};";
            conexao = new SqlConnection(connectionString);
        }

        public void AbrirConexao()
        {
            try
            {
                if (conexao.State != ConnectionState.Open)
                {
                    conexao.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao abrir a conexão: " + ex.Message);
            }
        }

        public void FecharConexao()
        {
            try
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fechar a conexão: " + ex.Message);
            }
        }

        public SqlConnection ObterConexao()
        {
            return conexao;
        }

        public DataTable ExecutarConsulta(string query)
        {
            try
            {
                AbrirConexao();
                SqlCommand comando = new SqlCommand(query, conexao);
                SqlDataReader reader = comando.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExecutarProcedure(string procedureName, SqlParameter[] parametros)
        {
            try
            {
                AbrirConexao();
                SqlCommand comando = new SqlCommand(procedureName, conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddRange(parametros);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a stored procedure: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public int ExecutarAtualizacao(string query, SqlParameter[] parametros)
        {
            try
            {
                AbrirConexao();
                SqlCommand comando = new SqlCommand(query, conexao);
                comando.Parameters.AddRange(parametros);
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a atualização: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}