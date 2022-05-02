$(document).ready(function () {

    url_Notificador = "/Handlers/Notificador.ashx";
    var IdNotificadorParam = ValorParamContexto("id");

    function EventoClick() {

        $("#btn_incluir_notificador").click(function () {
            window.location = "CadastroNotificador.aspx";
        });

        $("#btn_cadastrar_editar_notificador").click(function () {
            CadastrarEditarNotificador();
        });

        $("#btn_listar_notificadores").click(function () {
            window.location = "ListaNotificadores.aspx";
        });

    }

    function CadastrarEditarNotificador() {

        if (!CamposRequeridos("field-req", true)) {
            MsgAlerta("Preencha os campos obrigatórios");
            return;
        }

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

        var acao = "cadastrar-editar-notificador";

        const dados = {
            acao: acao,
            notificadorID: IdNotificadorParam,
            nome: $("#txt_nome").val(),
            telefone: $("#txt_telefone").val(),
            cpf: $("#txt_cpf").val(),
            email: $("#txt_email").val(),
            usuario: $("#txt_usuario").val(),
            senha: $("#txt_senha").val(),
            tipo: $("#tgl_tipo").is(":checked")
        };

        const funcaoSucesso = ret => {

            if (ret.sucesso) {

                if (ret.seriaEdicao) {
                    MsgSucesso();

                    setTimeout(function () {
                        window.location = "ListaNotificadores.aspx?pagina=1";
                    }, 2000);
                } else {
                    MsgSucesso();
                    LimpaCamposInfoGerais();
                }
            }

            else
                MsgErro(ret.msgRp, acao);

        };

        Post(url_Notificador, dados, funcaoSucesso);
    }

    function ListarNotificadores() {

        var template = `<tr style="cursor: default">
               <td>#{Nome}</td>
               <td>#{Email}</td>
               <td>#{Telefone}</td>
               <td>#{Cpf}</td>
               <td>#{Tipo}</td>
               <td>
                   <div>
                       <div class="btnlist" onclick="EditarNotificador(#{ID})" style="cursor: pointer" title="Editar notificador"><i class="fa fa-pencil" aria-hidden="true"></i>    
                       </div>
                   </div>
               </td>
               <td>
                   <div>
                       <div onclick="ExcluirNotificador(#{ID})" style="cursor: pointer" title="Excluir notificador"><i class="fa fa-trash" aria-hidden="true"></i>    
                       </div>
                   </div>
               </td>
            </tr>`;

        const dados = {

        };

        PreencheListagem(dados, 8, "Notificadores", template, url_Notificador);
    }

    EventoClick();
    ListarNotificadores();

    //Máscaras do formulário
    $("#txt_telefone").mask("(00) 00000-0000");
    $("#txt_cpf").mask("000.000.000-00");

});

function EditarNotificador(notificadorID) {
    window.location = "EdicaoNotificador.aspx?id=" + notificadorID;
}

function BuscarDadosNotificador(notificadorID) {

    url_Notificador = "/Handlers/Notificador.ashx";
    var acao = "buscar-dados-notificador";

    Get(url_Notificador, {
        acao,
        notificadorID
    },
        function (ret) {

            if (ret.sucesso) {
                                
                $("#txt_nome").val(ret.nome);
                $("#txt_telefone").val(ret.telefone);
                $("#txt_cpf").val(ret.cpf);
                $("#txt_email").val(ret.email);
                $("#txt_usuario").val(ret.usuario);
                $("#txt_senha").val(ret.senha);
                $("#tgl_tipo").bootstrapToggle(ret.tipo ? "on" : "off");

                $("#titulo_form_notificador").text("EDIÇÃO");
                $("#titulo_btn_form_notificador").text("SALVAR");

            } else {
                MsgErro(ret.msgRp, acao);
            }
        });
}

function ExcluirNotificador(notificadorID) {
    var acao = "excluir-notificador";

    const dados = {
        acao: acao,
        notificadorID: notificadorID
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

    ConfirmarNoty("Tem certeza que deseja excluir este notificador?",
        function ($noty) {
            Post(url_Notificador, dados, funcaoSucesso);
            $noty.close();
        },
        function ($noty) {
            $noty.close();
        });

}