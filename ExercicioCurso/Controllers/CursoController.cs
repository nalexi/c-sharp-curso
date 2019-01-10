using ExercicioCurso.Helpers;
using ExercicioCurso.Models;
using ExercicioCurso.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioCurso.Controllers
{
    public class CursoController : Controller
    {
        private readonly CursoRepositorio repositorio;

        public CursoController()
        {
            repositorio = new CursoRepositorio();
        }

        [HttpGet]
        public ActionResult Index(string busca = "")
        {
            List<Curso> cursos = repositorio.ObterTodos(busca);
            ViewBag.Cursos = cursos;

            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(Curso curso)
        {
            /*
             * Curso curso = new Curso();
            curso.Tema = tema;
            curso.Inscritos = inscritos;
            curso.DataCurso = datacurso;
            curso.Confirmado = confirmado;
            curso.Estado = estado;
            curso.Cidade = cidade;
            curso.Bairro = bairro;
            curso.Valor = valor;*/
            curso.RegistroAtivo = true;
            int id = repositorio.Inserir(curso);
            return Redirect("/curso");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Curso curso = repositorio.ObterPeloId(id);
            List<Estado> estados = EstadoHelper.Estados;
            ViewBag.Estados = estados;
            ViewBag.Curso = curso;
            return View();
        }

        [HttpPost]
        //public ActionResult Update(int id, string tema, int inscritos, DateTime datacurso, bool confirmado, int estado, string cidade, string bairro, decimal valor)
        public ActionResult Update(Curso curso)
        {
            Curso cursoOriginal = repositorio.ObterPeloId(curso.Id);

            cursoOriginal.Tema = curso.Tema;
            cursoOriginal.Inscritos = curso.Inscritos;
            cursoOriginal.DataCurso = curso.DataCurso;
            cursoOriginal.Confirmado = curso.Confirmado;
            cursoOriginal.Estado = curso.Estado;
            cursoOriginal.Cidade = curso.Cidade;
            cursoOriginal.Bairro = curso.Bairro;
            cursoOriginal.Valor = curso.Valor;

            repositorio.Alterar(cursoOriginal);
            return RedirectToAction("Editar", new { id = cursoOriginal.Id });
        }
    }

    public class Estado
    {
        public string Nome;
        public int Codigo;

        public Estado(string nome, int codigo)
        {
            this.Nome = nome;
            this.Codigo = codigo;
        }
    }
}