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
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nlasa\source\repos\ExercicioCurso\ExercicioCurso\Database\DatabaseExercicioCurso.mdf;Integrated Security=True;Connect Timeout=30";

        public void Alterar(Pessoa pessoa)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE INTO pessoas SET
                                    id = @ID,
                                    tema = @NOME,
                                    inscritos = @CPF,
                                    data = @IDADE,
                                    confirmado = @PAGO,
                                    estado = @CIDADE,
                                    cidade = @EMAIL,
                                    WHERE id = @ID";

            comando.Parameters.AddWithValue("@ID", pessoa.Id);
            comando.Parameters.AddWithValue("@NOME", pessoa.Nome);
            comando.Parameters.AddWithValue("@CPF", pessoa.Cpf);
            comando.Parameters.AddWithValue("@IDADE", pessoa.Idade);
            comando.Parameters.AddWithValue("@PAGO", pessoa.Pago);
            comando.Parameters.AddWithValue("@CIDADE", pessoa.Cidade);
            comando.Parameters.AddWithValue("@EMAIL", pessoa.Email);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE pessoas SET registro_ativo = 0 WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public int Inserir(Pessoa pessoa)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO pessoas
                                    (nome, cpf, idade, pago, cidade, email, registro_ativo)
                                    OUTPUT INSERTED.ID
                                    VALUES (@NOME, @CPF, @IDADE, @PAGO, @CIDADE, @EMAIL, 1)";

            comando.Parameters.AddWithValue("@NOME", pessoa.Nome);
            comando.Parameters.AddWithValue("@CPF", pessoa.Cpf);
            comando.Parameters.AddWithValue("@IDADE", pessoa.Idade);
            comando.Parameters.AddWithValue("@PAGO", pessoa.Pago);
            comando.Parameters.AddWithValue("@CIDADE", pessoa.Cidade);
            comando.Parameters.AddWithValue("@EMAIL", pessoa.Email);

            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            conexao.Close();
            return id;
        }

        public Pessoa ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM pessoas WHERE id=@ID AND registro_ativo = 1";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            if (table.Rows.Count == 1)
            {
                Pessoa pessoa = new Pessoa();
                DataRow row = table.Rows[0];
                pessoa.Id = Convert.ToInt32(row["id"].ToString());
                pessoa.Nome = row["nome"].ToString();
                pessoa.Cpf = row["cpf"].ToString();
                pessoa.Idade = Convert.ToInt16(row["idade"].ToString());
                pessoa.Pago = Convert.ToBoolean(row["pago"].ToString());
                pessoa.Cidade = row["cidade"].ToString();
                pessoa.Email = row["email"].ToString();
                return pessoa; 
            }
            return null;
        }

        public List<Pessoa> ObterTodos(string busca)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM pessoas WHERE registro_ativo = 1 AND nome LIKE @BUSCA ORDER BY nome";
            busca = "%" + busca + "%";

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            List<Pessoa> pessoas = new List<Pessoa>();
            foreach (DataRow row in table.Rows)
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = Convert.ToInt32(row["id"].ToString());
                pessoa.Nome = row["nome"].ToString();
                pessoa.Cpf = row["cpf"].ToString();
                pessoa.Idade = Convert.ToInt16(row["idade"].ToString());
                pessoa.Pago = Convert.ToBoolean(row["pago"].ToString());
                pessoa.Cidade = row["cidade"].ToString();
                pessoa.Email = row["email"].ToString();

                pessoas.Add(pessoa);
            }
            return pessoas;
        }
    }
}