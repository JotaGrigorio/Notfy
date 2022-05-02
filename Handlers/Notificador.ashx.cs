using Notfy_LinqToSql.Classes;
using System;
using System.Linq;
using System.Web;

namespace Notfy_LinqToSql.Handlers
{
    public class NotificadorHandler : IHttpHandler
    {
        private readonly NotfyDataContext db = new NotfyDataContext();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            if (context.Request["acao"] == null)
                return;

            var acao = context.Request["acao"].ToLower();

            switch (acao)
            {
                case "cadastrar-editar-notificador":
                    {
                        try
                        {
                            var notificadorID = context.Request["notificadorID"];
                            var nome = context.Request["nome"];
                            var telefone = context.Request["telefone"];
                            var cpf = context.Request["cpf"];
                            var email = context.Request["email"];
                            var usuario = context.Request["usuario"];
                            var senha = context.Request["senha"];
                            var tipo = context.Request["tipo"];
                            var seriaEdicao = false;
                                                       
                            if (!string.IsNullOrEmpty(notificadorID))
                            {
                                var notificardorInfo = db.Notificadors.SingleOrDefault(o => o.ID == int.Parse(notificadorID));

                                notificardorInfo.Nome = nome;
                                notificardorInfo.Telefone = telefone;
                                notificardorInfo.CPF = cpf;
                                notificardorInfo.Email = email;
                                notificardorInfo.Usuario = usuario;
                                notificardorInfo.Senha = senha;
                                notificardorInfo.Tipo = bool.Parse(tipo);
                                seriaEdicao = true;
                            }
                            else
                            {
                                var notificador = new Notificador()
                                {
                                    Nome = nome,
                                    Telefone = telefone,
                                    CPF = cpf,
                                    Email = email,
                                    Usuario = usuario,
                                    Senha = senha,
                                    Tipo = bool.Parse(tipo),
                                    Status = true                                   
                            };

                                db.Notificadors.InsertOnSubmit(notificador);
                            }

                            db.SubmitChanges();

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                seriaEdicao
                            });
                        }
                        catch (Exception ex)
                        {
                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = false,
                                msgRp = ex.Message
                            });
                        }
                    }
                    break;

                case "lista-notificadores":

                    var deixe = int.Parse(context.Request["deixe"]);
                    var tome = int.Parse(context.Request["tome"]);

                    {
                        try
                        {
                            var lista = db.Notificadors.Where(o => o.Status)
                               .ToList()
                               .Select(o => new
                               {
                                   o.ID,
                                   Nome = o.Nome,
                                   Cpf = o.CPF,
                                   Telefone = o.Telefone,
                                   Email = o.Email,
                                   Tipo = o.Tipo == true ? "Administrador" : "Comum"

                               })
                               .OrderBy(o => o.Nome).ThenBy(o => o.Email).ToList();

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                lista = lista.Skip(deixe).Take(tome),
                                cnt = lista.Count

                            });
                        }
                        catch (Exception ex)
                        {
                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = false,
                                msgRp = ex.Message
                            });
                        }
                    }
                    break;

                case "combo-notificadores":
                                        
                    {
                        try
                        {
                            var lista = db.Notificadors.Where(o => o.Status)
                               .ToList()
                               .Select(o => new
                               {
                                   o.ID,
                                   o.Nome                                 
                               })
                               .OrderBy(o => o.Nome).ToList();

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                lista
                            });
                        }
                        catch (Exception ex)
                        {
                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = false,
                                msgRp = ex.Message
                            });
                        }
                    }
                    break;

                case "buscar-dados-notificador":
                    {
                        try
                        {
                            var notificadorID = context.Request["notificadorID"];
                            var notificadorInfo = db.Notificadors.Single(o => o.ID == int.Parse(notificadorID));

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                nome = notificadorInfo.Nome,
                                telefone = notificadorInfo.Telefone,
                                cpf = notificadorInfo.CPF,
                                email = notificadorInfo.Email,
                                usuario = notificadorInfo.Usuario,
                                senha = notificadorInfo.Senha,
                                tipo = notificadorInfo.Tipo
                            });
                        }
                        catch (Exception ex)
                        {
                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = false,
                                msgRp = ex.Message
                            });
                        }
                    }
                    break;

                case "excluir-notificador":
                    {
                        try
                        {
                            var notificadorID = context.Request["notificadorID"];
                            var notificadorInfo = db.Notificadors.SingleOrDefault(o => o.ID == int.Parse(notificadorID));

                            notificadorInfo.Status = false;
                            db.SubmitChanges();

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                            });
                        }
                        catch (Exception ex)
                        {
                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = false,
                                msgRp = ex.Message
                            });
                        }
                    }
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
