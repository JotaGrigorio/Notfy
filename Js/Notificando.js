$(document).ready(function () {

    url_Notificando = "/Handlers/Notificando.ashx";
    IdEnderecoParam = 0;
    IdNotificandoParam = ValorParamContexto("id");

    function EventoClick() {

        $("#btn_incluir_notificando").click(function () {
            window.location = "CadastroNotificando.aspx";

        });

        $("#btn_cadastrar_editar_notificando").click(function () {
            CadastrarEditarNotificando(false);
        });

        $("#btn_listar_notificandos").click(function () {
            window.location = "ListaNotificandos.aspx";
        });

        $("#btn_enderecos").click(function () {
            $("#mdlEnderecosNotificando").modal("show");


            TipoPagina();

            if (IdNotificandoParam == 0) {
                $(".form").removeClass("inicia-invisivel-form");
                $("#titulo_btn_inserir_endereco").text("INSERIR");
            }

            if (tipoPagina == "EdicaoNotificando") {
                $(".form").addClass("inicia-invisivel-form");
                $("#divTbEnderecosNotificando").removeClass("inicia-invisivel-table");
                $("#btn_inserir_novo_endereco").show();
            }

            ListarEnderecosNotificando(IdNotificandoParam);
        });

        $("#btn_inserir_endereco").click(function () {
            CadastrarEditarNotificando(true);
        });

        $("#btn_inserir_novo_endereco").click(function () {
            $("#titulo_btn_inserir_endereco").text("INSERIR");
            $(".form").removeClass("inicia-invisivel-form");
            LimpaCamposEndereco();
            IdEnderecoParam = 0;
        });

        $("#txt_cep").on("keydown", function (e) {
            if (e.keyCode == 13) {
                PesquisarCep();
            }
        });

        $("#btn_pesquisar_cep").click(function () {
            PesquisarCep();
        });
        
    }

    function CadastrarEditarNotificando(seriaInsercaoEndereco = false) {
        
        TipoPagina();

        //Cadastro
        //Edicao
        if ((tipoPagina != "EdicaoNotificando" && IdNotificandoParam > 0 && !seriaInsercaoEndereco) ||
            (tipoPagina == "EdicaoNotificando" && IdNotificandoParam > 0 && !seriaInsercaoEndereco)) {
            $("#txt_logradouro").removeClass("field-req");
            $("#txt_numero").removeClass("field-req");
            $("#txt_bairro").removeClass("field-req");
            $("#txt_cep").removeClass("field-req");
            $("#txt_cidade").removeClass("field-req");
            $("#txt_estado").removeClass("field-req");
        }

        if (!CamposRequeridos("field-req", true)) {
            MsgAlerta("Preencha os campos obrigatórios");
            return;
        }

        if (!seriaInsercaoEndereco) {
            if (!ValidaCpf($("#txt_cpf").val())) {
                MsgAlerta("CPF inválido");
                $("#txt_cpf").focus();
                return;
            }

            if (!ValidaEmail($("#txt_email").val())) {
                MsgAlerta("Email inválido");
                $("#txt_email").focus();
                return;
            }
        }
        
        var acao = "cadastrar-editar-notificando";
        
        const dados = {
            acao: acao,
            notificandoID: IdNotificandoParam,
            enderecoID: IdEnderecoParam,
            nome: $("#txt_nome").val(),
            telefone: $("#txt_telefone").val(),
            cpf: $("#txt_cpf").val(),
            email: $("#txt_email").val(),

            logradouro: $("#txt_logradouro").val(),
            numero: $("#txt_numero").val(),
            bairro: $("#txt_bairro").val(),
            complemento: $("#txt_complemento").val(),
            cep: $("#txt_cep").val(),
            cidade: $("#txt_cidade").val(),
            estado: $("#txt_estado").val(),

            seriaInsercaoEndereco: seriaInsercaoEndereco
        };

        const funcaoSucesso = ret => {

            IdNotificandoParam = ret.novoNotificandoId;

            if (ret.sucesso) {

                MsgSucesso();
                $("#divTbEnderecosNotificando").removeClass("inicia-invisivel-table");

                if (ret.seriaEdicao && tipoPagina == "EdicaoNotificando" && seriaInsercaoEndereco) {
                    alert("1")
                    $(".form").addClass("inicia-invisivel-form");
                    LimpaCamposEndereco();
                    ListarEnderecosNotificando(IdNotificandoParam);
                }
                else if (ret.seriaEdicao && tipoPagina == "EdicaoNotificando" && !seriaInsercaoEndereco) {
                    alert("2")
                    setTimeout(function () {
                        window.location = "ListaNotificandos.aspx?pagina=1";
                    }, 2000);
                }
                else if (seriaInsercaoEndereco) {
                    alert("3")
                    window.LimpaCamposEndereco();
                    window.ListarEnderecosNotificando(ret.novoNotificandoId);
                }
                else {
                    alert("4")
                    setTimeout(function () {
                        document.location.reload(true);
                    }, 2000);

                }
            }

            else
                MsgErro(ret.msgRp, acao);

        };

        Post(url_Notificando, dados, funcaoSucesso);
    }

    function ListarNotificandos() {
       
        var template = `<tr style="cursor: default">
               <td>#{Nome}</td>
               <td>#{Email}</td>
               <td>#{Telefone}</td>
               <td>#{Cpf}</td>
               <td>
                   <div>
                       <div class="btnlist" onclick="AbrirMdlEnderecosNotificando(#{ID})" style="cursor: pointer" title="Visualizar endereços"><i class="fa fa-eye" aria-hidden="true"></i>    
                       </div>
                   </div>
               </td>
               <td>
                   <div>
                       <div class="btnlist" onclick="EditarNotificando(#{ID})" style="cursor: pointer" title="Editar notificando"><i class="fa fa-pencil" aria-hidden="true"></i>    
                       </div>
                   </div>
               </td>
               <td>
                   <div>
                       <div onclick="ExcluirNotificando(#{ID})" style="cursor: pointer" title="Excluir notificando"><i class="fa fa-trash" aria-hidden="true"></i>    
                       </div>
                   </div>
               </td>
            </tr>`;

        const dados = {

        };

        PreencheListagem(dados, 8, "Notificandos", template, url_Notificando);
    }

    EventoClick();
    $("#btn_inserir_novo_endereco").hide();
    ListarNotificandos();

    //Máscaras do formulário
    $("#txt_telefone").mask("(00) 00000-0000");
    $("#txt_cpf").mask("000.000.000-00");
    $("#txt_cep").mask("00000-000");

});

function EditarNotificando(notificandoID) {
    window.location = "EdicaoNotificando.aspx?id=" + notificandoID;
    $("#divTbEnderecosNotificando").removeClass("inicia-invisivel-table");
    BuscarDadosNotificando(notificandoID);
}

function BuscarDadosNotificando(notificandoID) {

    url_Notificando = "/Handlers/Notificando.ashx";
    var acao = "buscar-dados-notificando";

    Get(url_Notificando, {
        acao,
        notificandoID
    },
        function (ret) {

            if (ret.sucesso) {

                IdNotificandoParam = ret.notificandoID;
                
                $("#txt_nome").val(ret.nome);
                $("#txt_telefone").val(ret.telefone);
                $("#txt_cpf").val(ret.cpf);
                $("#txt_email").val(ret.email);

                $("#titulo_form_notificando").text("EDIÇÃO");
                $("#titulo_btn_form_notificando").text("SALVAR");
                $("#titulo_btn_inserir_endereco").text("SALVAR");

            } else {
                MsgErro(ret.msgRp, acao);
            }
        });
}

function ExcluirNotificando(notificandoID) {
    var acao = "excluir-notificando";

    const dados = {
        acao: acao,
        notificandoID: notificandoID
    };

    const funcaoSucesso = ret => {

        if (ret.sucesso) {
            MsgSucesso();

            setTimeout(function () {
                document.location.reload(true);
            }, 2000);

        }
        else
            MsgErro(ret.msgRp, acao);
    };

    ConfirmarNoty("Tem certeza que deseja excluir este notificando?",
        function ($noty) {
            Post(url_Notificando, dados, funcaoSucesso);
            $noty.close();
        },
        function ($noty) {
            $noty.close();
        });

}

function AbrirMdlEnderecosNotificando(notificandoID) {
    BuscarDadosNotificando(notificandoID);
    $("#mdlEnderecosNotificando").modal("show");
    $(".form").addClass("inicia-invisivel-form");
    $("#divTbEnderecosNotificando").removeClass("inicia-invisivel-table");
    ListarEnderecosNotificando(notificandoID);
}

function ListarEnderecosNotificando(notificandoID) {

    var template = `<tr style="cursor: default">
               <td title="#{LogradouroCompleto}">#{Logradouro}</td>
               <td>#{Numero}</td>
               <td title="#{BairroCompleto}">#{Bairro}</td>
               <td title="#{ComplementoCompleto}">#{Complemento}</td>
               <td>#{Cep}</td>
               <td title="#{CidadeCompleto} - #{Estado}">#{Cidade} - #{Estado}</td>
               <td>
                   <div>
                       <div class="btnlist" onclick="EditarEnderecoNotificando(#{NotificandoID},#{EnderecoID})" style="cursor: pointer" title="Editar endereço notificando"><i class="fa fa-pencil" aria-hidden="true"></i>    
                       </div>
                   </div>
               </td>
               <td>
                   <div>
                       <div onclick="ExcluirEnderecoNotificando(#{NotificandoID},#{EnderecoID})" style="cursor: pointer" title="Excluir endereço notificando"><i class="fa fa-trash" aria-hidden="true"></i>    
                       </div>
                   </div>
               </td>
            </tr>`;

    const dados = {
        notificandoId: notificandoID
    };

    PreencheListagem(dados, 3, "EnderecosNotificando", template, url_Notificando);
}

function EditarEnderecoNotificando(notificandoID, enderecoID) {

    url_Notificando = "/Handlers/Notificando.ashx";
    var acao = "buscar-dados-endereco";

    $(".form").removeClass("inicia-invisivel-form");
    $("#titulo_btn_inserir_endereco").text("SALVAR");

    Get(url_Notificando, {
        acao,
        notificandoID,
        enderecoID
    },
        function (ret) {

            if (ret.sucesso) {
                IdEnderecoParam = ret.enderecoID;
                IdNotificandoParam = ret.notificandoID;
                
                $("#txt_logradouro").val(ret.logradouro);
                $("#txt_numero").val(ret.numero);
                $("#txt_bairro").val(ret.bairro);
                $("#txt_complemento").val(ret.complemento);
                $("#txt_cep").val(ret.cep);
                $("#txt_cidade").val(ret.cidade);
                $("#txt_estado").val(ret.estado);

                $("#titulo_form_notificando").text("EDIÇÃO");
                $("#titulo_btn_form_notificando").text("SALVAR");

            } else {
                MsgErro(ret.msgRp, acao);
            }
        });
}

function ExcluirEnderecoNotificando(notificandoID, enderecoID) {
    var acao = "excluir-endereco-notificando";

    const dados = {
        acao: acao,
        notificandoID: notificandoID,
        enderecoID: enderecoID
    };

    const funcaoSucesso = ret => {

        if (ret.sucesso) {
            MsgSucesso();

            ListarEnderecosNotificando(ret.notificandoID);
        }
        else
            MsgErro(ret.msgRp);
    };

    ConfirmarNoty("Tem certeza que deseja excluir este endereço?",
        function ($noty) {
            Post(url_Notificando, dados, funcaoSucesso);
            $noty.close();
        },
        function ($noty) {
            $noty.close();
        });

}

function TipoPagina() {

    var urlPagina = window.location.href;
    var indexUltimaBarra = urlPagina.lastIndexOf("/");

    if (indexUltimaBarra > 0 && urlPagina.length - 1 != indexUltimaBarra) {
        var url = urlPagina.substring(indexUltimaBarra + 1);
        tipoPagina = url.substr(0, 17);
    }
    else
        return 0;
}

function PesquisarCep() {

    if (!CamposRequeridos("field-req-cep", true)) {
        MsgAlerta("Preencha os campos obrigatórios");
        return;
    }

    url_Notificando = "/Handlers/Notificando.ashx";
    var acao = "pesquisar-cep";

    Get(url_Notificando, {
        acao,
        cep: $("#txt_cep").val()
    },
        function (ret) {

            if (ret.sucesso) {

                if (ret.erro) {
                    MsgAlerta("CEP não encontrado!");
                    $("#txt_logradouro").val("");
                    $("#txt_bairro").val("");
                    $("#txt_complemento").val("");
                    $("#txt_cidade").val("");
                    $("#txt_estado").val("");
                } else {
                    $("#txt_logradouro").val(ret.logradouro);
                    $("#txt_bairro").val(ret.bairro);
                    $("#txt_complemento").val(ret.complemento);
                    $("#txt_cidade").val(ret.cidade);
                    $("#txt_estado").val(ret.estado);
                    $("#txt_numero").focus();
                }

            } else {
                MsgErro(ret.msgRp, acao);
            }
        });
}