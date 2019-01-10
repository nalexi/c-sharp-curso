using ExercicioCurso.Database;
using ExercicioCurso.Interfaces;
using ExercicioCurso.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Repositories
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private SqlCommand comando;

        public void Alterar(Curso curso)
        {
            comando = Conexao.ObterConexao();
            comando.CommandText = @"UPDATE cursos SET
                                    tema = @TEMA,
                                    inscritos = @INSCRITOS,
                                    data_curso = @DATACURSO,
                                    confirmado = @CONFIRMADO,
                                    estado = @ESTADO,
                                    cidade = @CIDADE,
                                    bairro = @BAIRRO,
                                    valor = @VALOR
                                    WHERE id = @ID";

            comando.Parameters.AddWithValue("@ID", curso.Id);
            comando.Parameters.AddWithValue("@TEMA", curso.Tema);
            comando.Parameters.AddWithValue("@INSCRITOS", curso.Inscritos);
            comando.Parameters.AddWithValue("@DATACURSO", curso.DataCurso);
            comando.Parameters.AddWithValue("@CONFIRMADO", curso.Confirmado);
            comando.Parameters.AddWithValue("@ESTADO", curso.Estado);
            comando.Parameters.AddWithValue("@CIDADE", curso.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", curso.Bairro);
            comando.Parameters.AddWithValue("@VALOR", curso.Valor);

            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }

        public void Apagar(int id)
        {
            comando = Conexao.ObterConexao();
            comando.CommandText = @"UPDATE cursos SET registro_ativo = 0 WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }

        public int Inserir(Curso curso)
        {
            comando = Conexao.ObterConexao();            
            comando.CommandText = @"INSERT INTO cursos
                                    (tema, inscritos, data_curso, confirmado, estado, cidade, bairro, valor, registro_ativo)
                                    OUTPUT INSERTED.ID
                                    VALUES (@TEMA, @INSCRITOS, @DATA_CURSO, @CONFIRMADO, @ESTADO, @CIDADE, @BAIRRO, @VALOR, 1)";

            comando.Parameters.AddWithValue("@TEMA", curso.Tema);
            comando.Parameters.AddWithValue("@INSCRITOS", curso.Inscritos);
            comando.Parameters.AddWithValue("@DATA_CURSO", curso.DataCurso);
            comando.Parameters.AddWithValue("@CONFIRMADO", curso.Confirmado);
            comando.Parameters.AddWithValue("@ESTADO", curso.Estado);
            comando.Parameters.AddWithValue("@CIDADE", curso.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", curso.Bairro);
            comando.Parameters.AddWithValue("@VALOR", curso.Valor);

            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            comando.Connection.Close();
            return id;
        }

        public Curso ObterPeloId(int id)
        {
            comando = Conexao.ObterConexao();
            comando.CommandText = @"SELECT * FROM cursos WHERE id=@ID AND registro_ativo = 1";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            Curso curso = null;
            if (table.Rows.Count == 1)
            {
                curso = new Curso();
                DataRow row = table.Rows[0];
                curso.Id = Convert.ToInt32(row["id"].ToString());
                curso.Tema = row["tema"].ToString();
                curso.Inscritos = Convert.ToInt32(row["inscritos"].ToString());
                curso.DataCurso = Convert.ToDateTime(row["data_curso"].ToString());
                curso.Confirmado = Convert.ToBoolean(row["confirmado"].ToString());
                curso.Estado = Convert.ToInt32(row["estado"].ToString());
                curso.Cidade = row["cidade"].ToString();
                curso.Bairro = row["bairro"].ToString();
                curso.Valor = Convert.ToDecimal(row["valor"].ToString());
            }
            comando.Connection.Close();
            return curso == null ? curso : null;

        }

        public List<Curso> ObterTodos(string busca)
        {
            comando = Conexao.ObterConexao();
            comando.CommandText = @"SELECT * FROM cursos WHERE registro_ativo = 1 AND tema LIKE @BUSCA ORDER BY tema";
            busca = "%" + busca + "%";
            comando.Parameters.AddWithValue("@BUSCA", busca);
            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            List<Curso> cursos = new List<Curso>();
            foreach (DataRow row in table.Rows) 
            {
                Curso curso = new Curso();
                curso.Id = Convert.ToInt32(row["id"].ToString());
                curso.Tema = row["tema"].ToString();
                curso.Inscritos = Convert.ToInt32(row["inscritos"].ToString());
                curso.DataCurso = Convert.ToDateTime(row["data_curso"].ToString());
                curso.Confirmado = Convert.ToBoolean(row["confirmado"].ToString());
                curso.Estado = Convert.ToInt32(row["estado"].ToString());
                curso.Cidade = row["cidade"].ToString();
                curso.Bairro = row["bairro"].ToString();
                curso.Valor = Convert.ToDecimal(row["valor"].ToString());
                cursos.Add(curso);
            }
            comando.Connection.Close();
            return cursos;
        }
    }
}