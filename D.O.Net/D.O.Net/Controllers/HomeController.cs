using D.O.Net.DAL;
using D.O.Net.Entidades;
using D.O.Net.Models;
using D.O.Net.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D.O.Net.Extensions;
using System.Data.Entity;

namespace D.O.Net.Controllers
{
    public class HomeController : BaseController
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            ViewBag.Tags = db.Tag.ToList();
            return View();
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        [HttpPost]
        public ActionResult RegitroUsuario(News model, FormCollection fc)
        {
            
            try
            {
                var idsTags = fc.Get("tag");
                var email = fc.Get("Email");

                if (idsTags == null)
                {
                    return Redirect(Url.Action("Index", "Home") + "#News").WithWarningMessage("Ops, nenhuma categoria selecionada");
                }

                if (email == "")
                {
                    return Redirect(Url.Action("Index", "Home") + "#News").WithWarningMessage("Ops, nenhum e-mail informado");
                }

                //Monta lista de string para interesses
                string[] ids = idsTags.Split(',');

                string interesses = "";

                foreach (string item in ids)
                {
                    int id = int.Parse(item);
                    if (interesses != "")
                    {
                        interesses = interesses + ",";
                    }
                    interesses = interesses + db.Tag.Where(x => x.TagID == id).First().Descricao;
                }

                var usuarioexistente = db.Usuario.Where(x => x.Email == email);

                if(usuarioexistente.Count() == 0)
                {
                    Usuario user = new Usuario();
                    user.Email = email;
                    user.Ativo = true;
                    db.Usuario.Add(user);
                    db.SaveChanges();
                    Interesse interesse = new Interesse();
                    interesse.UsuarioID = user.UsuarioID;
                    interesse.Descricao = interesses;

                    db.Interesse.Add(interesse);
                    db.SaveChanges();

                    EmailBoasVindas(user.Email, interesses);

                    APIDadosAbertos.Result result = APIDadosAbertos.RequisicaoUltimosRegistros(interesses.Split(','));
                    string emailBody = this.RenderPartialViewToString("Email", result);
                    SendEmail.Enviar(user.Email, emailBody, "Diário Oficial Net - Atualizações");
                }
                else
                {
                    var u = usuarioexistente.First();
                    Interesse interesse = db.Interesse.Where(x=>x.UsuarioID == u.UsuarioID).First();
                    interesse.Descricao = interesses;

                    db.Entry(interesse).State = EntityState.Modified;
                    db.SaveChanges();

                    return Redirect(Url.Action("Index", "Home") + "#News").WithSuccessMessage("Você já estava cadastrado! Cadastro atualizado com sucesso");
                }

                return Redirect(Url.Action("Index", "Home") + "#News").WithSuccessMessage("Cadastro realizado com sucesso");
            }
            catch (Exception ex)
            {
                return Redirect(Url.Action("Index", "Home") + "#News").WithErrorMessage("Ops, aconteceu algo errado");
            }


            
        }

        [HttpPost]
        public ActionResult BuscaAvancada(FormCollection fc)
        {
            var responsavel = fc.Get("responsavel");
            var tipodocumento = fc.Get("tipodocumento");
            var titulo = fc.Get("titulo");
            var edicao = fc.Get("edicao");
            var secao = fc.Get("secao");
            var caderno = fc.Get("caderno");

            return Redirect(Url.Action("Index", "Home") + "#busca").WithSuccessMessage("Registros retornados");
        }

        public void EmailBoasVindas(string email, string interesses)
        {
            string subject = "Cadastro realizado com sucesso";
            string body = "Bem vindo, você agora está cadastrado no Diário Oficial Net e receberá atualizações para as seguintes categorias: "+ interesses;
            SendEmail.Enviar(email,body,subject);
        }
    }
}