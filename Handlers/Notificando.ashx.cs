using Notfy_LinqToSql.Classes;
using System;
using System.Linq;
using System.Web;

namespace Notfy_LinqToSql.Handlers
{
    public class NotificandoHandler : IHttpHandler
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
                case "cadastrar-editar-notificando":
                    {
                        try
                        {
                            var notificandoID = context.Request["notificandoID"];
                            var enderecoID = context.Request["enderecoID"];
                            var nome = context.Request["nome"];
                            var telefone = context.Request["telefone"];
                            var cpf = context.Request["cpf"];
                            var email = context.Request["email"];
                            var logradouro = context.Request["logradouro"];
                            var numero = context.Request["numero"];
                            var bairro = context.Request["bairro"];
                            var complemento = context.Request["complemento"];
                            var cep = context.Request["cep"];
                            var cidade = context.Request["cidade"];
                            var estado = context.Request["estado"];
                            var seriaInsercaoEndereco = context.Request["seriaInsercaoEndereco"];
                            var seriaEdicao = false;
                            var novoNotificandoId = 0;

                            //Update
                            if (!string.IsNullOrEmpty(notificandoID)) 
                            {
                                if (!bool.Parse(seriaInsercaoEndereco))
                                {
                                    var notificandoInfo = db.Notificandos.SingleOrDefault(o => o.ID == int.Parse(notificandoID));
                                    notificandoInfo.Nome = nome;
                                    notificandoInfo.Telefone = telefone;
                                    notificandoInfo.CPF = cpf;
                                    notificandoInfo.Email = email;
                                }
                                
                                if (int.Parse(enderecoID) > 0 && bool.Parse(seriaInsercaoEndereco))
                                {
                                    var enderecoInfo = db.Enderecos.SingleOrDefault(o => o.ID == int.Parse(enderecoID));
                                    enderecoInfo.Logradouro = logradouro;
                                    enderecoInfo.Numero = numero;
                                    enderecoInfo.Bairro = bairro;
                                    enderecoInfo.Complemento = complemento;
                                    enderecoInfo.Cep = cep;
                                    enderecoInfo.Cidade = cidade;
                                    enderecoInfo.Estado = estado;
                                }
                                else if (bool.Parse(seriaInsercaoEndereco))
                                {
                                    var endereco = new Endereco()
                                    {
                                        Logradouro = logradouro,
                                        Numero = numero,
                                        Bairro = bairro,
                                        Complemento = complemento,
                                        Cep = cep,
                                        Cidade = cidade,
                                        Estado = estado,
                                        Status = true,
                                        NotificandoID = int.Parse(notificandoID)
                                    };
                                    db.Enderecos.InsertOnSubmit(endereco);
                                }

                                novoNotificandoId = int.Parse(notificandoID);
                                seriaEdicao = true;
                            }
                            //Insert
                            else
                            {
                                var novoNotificando = new Notificando()
                                {
                                    Nome = nome,
                                    Telefone = telefone,
                                    CPF = cpf,
                                    Email = email,
                                    Status = true

                                };
                                db.Notificandos.InsertOnSubmit(novoNotificando);
                                db.SubmitChanges();

                                var endereco = new Endereco()
                                {
                                    Logradouro = logradouro,
                                    Numero = numero,
                                    Bairro = bairro,
                                    Complemento = complemento,
                                    Cep = cep,
                                    Cidade = cidade,
                                    Estado = estado,
                                    Status = true,
                                    NotificandoID = novoNotificando.ID
                                };
                                db.Enderecos.InsertOnSubmit(endereco);

                                novoNotificandoId = novoNotificando.ID;
                            }

                            db.SubmitChanges();

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                seriaEdicao,
                                seriaInsercaoEndereco,
                                novoNotificandoId
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

                case "lista-notificandos":

                    var deixe = int.Parse(context.Request["deixe"]);
                    var tome = int.Parse(context.Request["tome"]);

                    {
                        try
                        {
                            var lista = db.Notificandos.Where(o => o.Status)
                               .ToList()
                               .Select(o => new
                               {
                                   o.ID,
                                   Nome = o.Nome,
                                   Cpf = o.CPF,
                                   Telefone = o.Telefone,
                                   Email = o.Email
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

                case "combo-notificandos":

                    {
                        try
                        {
                            var lista = db.Notificandos.Where(o => o.Status)
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

                case "combo-enderecos":

                    {
                        var notificandoID = context.Request["notificandoID"];

                        try
                        {
                            var lista = db.Enderecos.Where(o => o.Status && o.NotificandoID == int.Parse(notificandoID))
                               .ToList()
                               .Select(o => new
                               {
                                   o.ID,
                                   Endereco = o.Logradouro + ", " + o.Numero + ", " + o.Bairro + ", " + o.Cidade + " - " + o.Estado
                               })
                               .OrderBy(o => o.Endereco).ToList();

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

                case "buscar-dados-notificando":
                    {
                        try
                        {
                            var notificandoID = context.Request["notificandoID"];
                            var notificandoInfo = db.Notificandos.SingleOrDefault(o => o.ID == int.Parse(notificandoID));

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                notificandoID = notificandoInfo.ID,
                                nome = notificandoInfo.Nome,
                                telefone = notificandoInfo.Telefone,
                                cpf = notificandoInfo.CPF,
                                email = notificandoInfo.Email
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

                case "excluir-notificando":
                    {
                        try
                        {
                            var notificandoID = context.Request["notificandoID"];
                            var notificandoInfo = db.Notificandos.SingleOrDefault(o => o.ID == int.Parse(notificandoID));

                            notificandoInfo.Status = false;
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

                case "lista-enderecosnotificando":

                    var notificandoId = context.Request["notificandoID"];

                    if (String.IsNullOrEmpty(notificandoId))
                        notificandoId = "0";

                    deixe = int.Parse(context.Request["deixe"]);
                    tome = int.Parse(context.Request["tome"]);

                    {
                        try
                        {
                            var lista = db.Enderecos.Where(o => o.NotificandoID == int.Parse(notificandoId) && o.Status)
                               .ToList()
                               .Select(o => new
                               {
                                   NotificandoID = notificandoId,
                                   EnderecoID = o.ID,
                                   Logradouro = o.Logradouro.Length > 20 ? o.Logradouro.Substring(0, 20) + "..." : o.Logradouro,
                                   LogradouroCompleto = o.Logradouro,
                                   Numero = o.Numero,
                                   Bairro = o.Bairro.Length > 15 ? o.Bairro.Substring(0, 15) + "..." : o.Bairro,
                                   BairroCompleto = o.Bairro,
                                   Complemento = o.Complemento.Length > 9 ? o.Complemento.Substring(0, 6) + "..." : o.Complemento,
                                   ComplementoCompleto = o.Complemento,
                                   Cep = o.Cep,
                                   Cidade = o.Cidade.Length > 15 ? o.Cidade.Substring(0, 15) + "..." : o.Cidade,
                                   CidadeCompleto = o.Cidade,
                                   Estado = o.Estado
                               })
                               .OrderBy(o => o.Estado).ThenBy(o => o.Cidade).ToList();

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

                case "buscar-dados-endereco":
                    {
                        try
                        {
                            var notificandoID = context.Request["notificandoID"];
                            var enderecoID = context.Request["enderecoID"];
                            var enderecoInfo = db.Enderecos.SingleOrDefault(o => o.ID == int.Parse(enderecoID));

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                notificandoID = int.Parse(notificandoID),
                                enderecoID,
                                logradouro = enderecoInfo.Logradouro,
                                numero = enderecoInfo.Numero,
                                bairro = enderecoInfo.Bairro,
                                complemento = enderecoInfo.Complemento,
                                cep = enderecoInfo.Cep,
                                cidade = enderecoInfo.Cidade,
                                estado = enderecoInfo.Estado
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

                case "excluir-endereco-notificando":
                    {
                        try
                        {
                            var notificandoID = context.Request["notificandoID"];
                            var enderecoID = context.Request["enderecoID"];
                            var enderecoInfo = db.Enderecos.SingleOrDefault(o => o.ID == int.Parse(enderecoID));

                            var qtdeEnderecos = db.Enderecos.Where(o => o.NotificandoID == int.Parse(notificandoID) && o.Status).Count();

                            if (qtdeEnderecos <= 1)
                            {
                                MetodosWeb.Serializar(context, new
                                {
                                    sucesso = false,
                                    msgRp = "É necessário existir ao menos um endereço"
                                });

                                return;
                            }

                            enderecoInfo.Status = false;
                            db.SubmitChanges();

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                notificandoID
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

                case "pesquisar-cep":
                    {
                        try
                        {
                            var cep = context.Request["cep"];

                            var respostaCep = MetodosWeb.PesquisarCepOnline(cep);

                            MetodosWeb.Serializar(context, new
                            {
                                sucesso = true,
                                
                                logradouro = respostaCep.logradouro,
                                bairro = respostaCep.bairro,
                                complemento = respostaCep.complemento,
                                cidade = respostaCep.localidade,
                                estado = respostaCep.uf,
                                erro = respostaCep.erro
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
