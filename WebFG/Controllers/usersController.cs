using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFG.Models;

namespace WebFG.Controllers
{
    [RoutePrefix("api/users")]
    public class usersController : ApiController
    {
        [Route("Cadastro")]
        public HttpResponseMessage Cadastrar(Estudantes estudantes)
        {
            try
            {
                using (var context = new FGDatabaseApi())
                {
                    context.Database.CreateIfNotExists();
                    context.Estudantes.Add(estudantes);
                    context.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK,"Cadastro Efetuado com sucesso");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro" + ex.ToString());

            }
        }
        [Route("Deletar")]
        public HttpResponseMessage Deletar(int id)
        {
            try
            {
                using (var context = new FGDatabaseApi())
                {
                    var query = context.Estudantes.FirstOrDefault(x => x.id == id);
                    context.Estudantes.Remove(query);
                    context.Entry(query).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK,"Usuário deletado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERRO");
            }
        }
        [Route("Listar")]
        [HttpGet]
        public HttpResponseMessage Listar()
        {
            try
            {
                using (var context = new FGDatabaseApi())
                {
                    var query = context.Estudantes.Select(x => new { x.Nome, x.Sobrenome, x.Idade, x.Email });
                    var result = query.ToList();

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }
        [Route("Editar")]
        [HttpPost]
        public HttpResponseMessage Editar(EstudantesGet estudantes)
        {
            try
            {
                using (var context = new FGDatabaseApi())
                {
                    var query = context.Estudantes.Where(x => x.id == estudantes.id).FirstOrDefault();
                    query.Nome = estudantes.Nome;
                    query.Sobrenome = estudantes.Sobrenome;
                    query.Idade = estudantes.Idade;
                    query.Email = estudantes.Email;
                    context.Entry(query).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "Dados foram alterados com sucesso");

                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERRO");

            }
        }
    }
}
