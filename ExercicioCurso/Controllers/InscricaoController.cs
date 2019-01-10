using ExercicioCurso.Models;
using ExercicioCurso.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioCurso.Controllers
{
    public class InscricaoController : Controller
    {
        [HttpGet]
        public ActionResult Index(string busca = "")
        {
            InscricaoRepositorio repositorio = new InscricaoRepositorio();
            List<Inscricao> inscricoes = repositorio.ObterTodos(busca);
            ViewBag.Inscricoes = inscricoes;
            return View();
        }
        
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(string nome)
        {
            Inscricao inscricao = new Inscricao();
            inscricao.Nome = nome;

            InscricaoRepositorio repositorio = new InscricaoRepositorio();
            int id = repositorio.Inserir(inscricao);

            return Redirect("/inscricao");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            InscricaoRepositorio repositorio = new InscricaoRepositorio();
            repositorio.Apagar(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            InscricaoRepositorio repositorio = new InscricaoRepositorio();
            Inscricao inscricao = repositorio.ObterPeloId(id);

            ViewBag.Inscricao = inscricao;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, string nome)
        {
            InscricaoRepositorio repositorio = new InscricaoRepositorio();
            Inscricao inscricao = repositorio.ObterPeloId(id);
            inscricao.Nome = nome;

            repositorio.Alterar(inscricao);
            return RedirectToAction("Editar", new { id = inscricao.Id });
        }
    }
}