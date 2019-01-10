using ExercicioCurso.Interfaces;
using ExercicioCurso.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Repositories  
{

    public class InscricaoRepositorio : IInscricaoRepositorio
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nlasa\source\repos\ExercicioCurso\ExercicioCurso\Database\DatabaseExercicioCurso.mdf;Integrated Security=True;Connect Timeout=30";

        public void Alterar(Inscricao inscricao)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE inscricoes SET
                                    nome = @NOME
                                    WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", inscricao.Nome);
            comando.Parameters.AddWithValue("@ID", inscricao.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
            
        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE inscricoes SET registro_ativo = 0 WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public int Inserir(Inscricao inscricao)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO inscricoes (nome, registro_ativo)
                                    OUTPUT INSERTED.ID
                                    VALUES (@NOME, 1)";
            comando.Parameters.AddWithValue("@NOME", inscricao.Nome);

            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            conexao.Close();
            return id;
        }

        public Inscricao ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText =  @"SELECT * FROM inscricoes WHERE id = @ID AND registro_ativo = 1";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            if (table.Rows.Count == 1)
            {
                Inscricao inscricao = new Inscricao();
                DataRow row = table.Rows[0];
                inscricao.Id = Convert.ToInt32(row["id"].ToString());
                inscricao.Nome = row["nome"].ToString();
                return inscricao;
            }
            return null;

        }

        public List<Inscricao> ObterTodos(string busca)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM inscricoes WHERE registro_ativo = 1 AND nome LIKE @BUSCA ORDER BY nome";
            busca = "%" + busca + "%";
            comando.Parameters.AddWithValue("@BUSCA", busca);

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            List<Inscricao> inscricoes = new List<Inscricao>();
            foreach (DataRow row in table.Rows)
            {
                Inscricao inscricao = new Inscricao();
                inscricao.Id = Convert.ToInt32(row["id"].ToString());
                inscricao.Nome = row["nome"].ToString();
                inscricoes.Add(inscricao);
            }
            return inscricoes;
        }
    }
}