$(document).ready(function () {

    url_Notificacao = "/Handlers/Notificacao.ashx";
        
    function EventoClick() {

        $("#btn_observacoes").click(function () {
            $("#mdlObservacoesNotificacao").modal("show");
        });

        //$("#btn_incluir_notificador").click(function () {
        //    window.location = "CadastroNotificador.aspx";
        //});

        $("#btn_cadastrar_editar_notificacao").click(function () {
            CadastrarEditarNotificacao();
        });

        //$("#btn_listar_notificadores").click(function () {
        //    window.location = "ListaNotificadores.aspx";
        //});

    }

    function EventoChange() {

        $("#sel_notificandos").change(function () {
            ComboEnderecos();
        });

    }

    function CadastrarEditarNotificacao() {

        if (!CamposRequeridos("field-req", true)) {
            MsgAlerta("Preencha os campos obrigatórios");
            return;
        }

        var acao = "cadastrar-editar-notificacao";

        const dados = {
            acao: acao,
            notificacaoID: IdNotificacaoParam,
            notificadorID: $("#sel_notificadores").val(),
            notificandoID: $("#sel_notificandos").val(),
            enderecoID: $("#sel_enderecos").val(),
            matricula: $("#txt_matricula_imovel").val(),
            observacoes: $("#text_area_observacoes").val()
        };

        const funcaoSucesso = ret => {

            if (ret.sucesso) {

                if (ret.seriaEdicao) {
                    MsgSucesso();

                    //setTimeout(function () {
                    //    window.location = "ListaNotificadores.aspx?pagina=1";
                    //}, 2000);
                } else {
                    MsgSucesso();
                    
                    setTimeout(function () {
                        document.location.reload(true);
                    }, 2000);

                    //LimpaCamposInfoGerais();
                }
            }

            else
                MsgErro(ret.msgRp, acao);

        };

        Post(url_Notificacao, dados, funcaoSucesso);
    }

    //function ListarNotificadores() {

    //    var template = `<tr style="cursor: default">
    //           <td>#{Nome}</td>
    //           <td>#{Email}</td>
    //           <td>#{Telefone}</td>
    //           <td>#{Cpf}</td>
    //           <td>#{Tipo}</td>
    //           <td>
    //               <div>
    //                   <div class="btnlist" onclick="EditarNotificador(#{ID})" style="cursor: pointer" title="Editar notificador"><i class="fa fa-pencil" aria-hidden="true"></i>    
    //                   </div>
    //               </div>
    //           </td>
    //           <td>
    //               <div>
    //                   <div onclick="ExcluirNotificador(#{ID})" style="cursor: pointer" title="Excluir notificador"><i class="fa fa-trash" aria-hidden="true"></i>    
    //                   </div>
    //               </div>
    //           </td>
    //        </tr>`;

    //    const dados = {

    //    };

    //    PreencheListagem(dados, 8, "Notificadores", template, url_Notificador);
    //}

    EventoClick();
    EventoChange();
    ComboNotificadores();
    ComboNotificandos();
    ComboEnderecos();
    
    ////Máscaras do formulário
    //$("#txt_telefone").mask("(00) 00000-0000");
    //$("#txt_cpf").mask("000.000.000-00");

});

//function EditarNotificador(notificadorID) {
//    window.location = "EdicaoNotificador.aspx?id=" + notificadorID;
//}

//function BuscarDadosNotificador(notificadorID) {

//    url_Notificador = "/Handlers/Notificador.ashx";
//    var acao = "buscar-dados-notificador";

//    Get(url_Notificador, {
//        acao,
//        notificadorID
//    },
//        function (ret) {

//            if (ret.sucesso) {
                                
//                $("#txt_nome").val(ret.nome);
//                $("#txt_telefone").val(ret.telefone);
//                $("#txt_cpf").val(ret.cpf);
//                $("#txt_email").val(ret.email);
//                $("#txt_usuario").val(ret.usuario);
//                $("#txt_senha").val(ret.senha);
//                $("#tgl_tipo").bootstrapToggle(ret.tipo ? "on" : "off");

//                $("#titulo_form_notificador").text("EDIÇÃO");
//                $("#titulo_btn_form_notificador").text("SALVAR");

//            } else {
//                MsgErro(ret.msgRp, acao);
//            }
//        });
//}

//function ExcluirNotificador(notificadorID) {
//    var acao = "excluir-notificador";

//    const dados = {
//        acao: acao,
//        notificadorID: notificadorID
//    };

//    const funcaoSucesso = ret => {

//        if (ret.sucesso) {
//            MsgSucesso();

//            setTimeout(function () {
//                document.location.reload(true);
//            }, 2000);

//        }
//        else
//            MsgErro(ret.msgRp, acao);
//    };

//    ConfirmarNoty("Tem certeza que deseja excluir este notificador?",
//        function ($noty) {
//            Post(url_Notificador, dados, funcaoSucesso);
//            $noty.close();
//        },
//        function ($noty) {
//            $noty.close();
//        });

//}

function ComboNotificadores() {
    url_Notificador = "/Handlers/Notificador.ashx";
    var acao = "combo-notificadores";

    Get(url_Notificador, {
        acao
    },
        function (ret) {

            if (ret.sucesso) {

                if (ret.lista !== undefined && ret.lista.length > 0) {
                    var lista = '<option value="0">Selecione</option>';
                    $.each(ret.lista, function (i, item) {
                        lista += "<option value={0}>{1}</option>".format(item.ID, item.Nome);
                    });
                    $("#sel_notificadores").html(lista);
                    //$("#sel_notificadores").val(ret.notificador);
                } 

            } else {
                MsgErro(ret.msgRp);
            }
        });
}

function ComboNotificandos() {
    url_Notificando = "/Handlers/Notificando.ashx";
    var acao = "combo-notificandos";
    
    Get(url_Notificando, {
        acao
    },
        function (ret) {

            if (ret.sucesso) {

                if (ret.lista !== undefined && ret.lista.length > 0) {
                    var lista = '<option value="0">Selecione</option>';
                    $.each(ret.lista, function (i, item) {
                        lista += "<option value={0}>{1}</option>".format(item.ID, item.Nome);
                    });
                    $("#sel_notificandos").html(lista);
                    //$("#sel_notificadores").val(ret.notificador);
                }

            } else {
                MsgErro(ret.msgRp);
            }
        });
}

function ComboEnderecos() {
    url_Notificando = "/Handlers/Notificando.ashx";

    var acao = "combo-enderecos";
    var notificandoID = $("#sel_notificandos").val() != null ? $("#sel_notificandos").val() : 0;

    Get(url_Notificando, {
        acao,
        notificandoID
    },
        function (ret) {

            if (ret.sucesso) {

                if (ret.lista !== undefined && ret.lista.length > 0) {
                    var lista = '<option value="0">Selecione</option>';

                    $.each(ret.lista, function (i, item) {
                        lista += "<option value={0}>{1}</option>".format(item.ID, item.Endereco);
                    });

                    $("#sel_enderecos").html(lista);
                    $("#sel_enderecos").attr("disabled", false);
                    $("#sel_enderecos").removeAttr("title");

                } else {
                    var lista = '<option value="0">Selecione</option>';

                    $("#sel_enderecos").html(lista);
                    $("#sel_enderecos").attr("disabled", true);
                    $("#sel_enderecos").attr("title", "É necessário primeiro selecionar um notificando");

                }

            } else {
                MsgErro(ret.msgRp);
            }
        });
}