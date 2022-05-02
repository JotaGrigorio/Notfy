function Post(url, data, success) {
    $.ajax({ url: url, data: data, dataType: "JSON", type: "POST", success: success, cache: false });
};

function Get(url, data, success) {

    $.ajax({ url: url, data: data, dataType: "JSON", success: success, cache: false });
};

function PreencheListagem(objetoAjax, numr, nomeGeral, paramTemplate, urlParam) {
    const trimIndent = texto => texto.split('\n').map(s => s.trim()).join('');
    const template = trimIndent(paramTemplate);

    var tb = "tb" + nomeGeral,
        tmp = "tmp" + nomeGeral,
        pg = "pg" + nomeGeral;

    var corpoTb = $("#" + tb + " tbody");
    var headerTb = $("#" + tb + " thead");
    var totalTh = $("#" + tb).children("thead").children("tr").children("th.th-geral").length;

    var templateSemRegistro = '<tr>';

    for (var i = 0; i < totalTh; i++) {
        templateSemRegistro += '<td>-</td>';
    }

    templateSemRegistro += "</tr>";
    corpoTb.html(templateSemRegistro);

    $.template("tmp{0}".format(nomeGeral), template.replace(/#{/g, "${"));

    var htmlHeader = objetoAjax.header;
    var pgAtual = 1;

    objetoAjax.acao = "Lista-" + nomeGeral;
    objetoAjax.tome = numr;
    objetoAjax.deixe = 0;


    //Preenchimento tabela
    Get(urlParam, objetoAjax, function (ret) {

        var sucesso = ret.sucesso;

        if (isNaN(ret.cnt))
            ret.cnt = 0;

        if (isNaN(sucesso))
            sucesso = true;

        if ((ret.cnt === 0) || (!sucesso) || (ret.lista == undefined)) {
            corpoTb.html(templateSemRegistro);
        } else {

            if (htmlHeader)
                headerTb.html(htmlHeader);

            corpoTb.html($.tmpl(tmp, ret.lista));
        }

        //Paginação
        //Se a quantidade de registros na tabela é menor ou igual a quantidade estipulada por página "numr" escondo a div do paginador.
        if (ret.cnt <= numr) {
            $("#" + pg).hide();
        } else {
            $("#" + pg).show();
        }

        $("#" + pg).show().smartpaginator({
            totalrecords: parseInt(ret.cnt),
            recordsperpage: numr,
            datacontainer: tb,
            initval: pgAtual,
            onchange: function (index) {
                $("html, body").scrollTop(0);
             
                var deixe = numr * (index > 0 ? index - 1 : 0);             
                objetoAjax.deixe = deixe;

                Get(urlParam, objetoAjax, function (ret2) {
                    corpoTb.html($.tmpl(tmp, ret2.lista));
                    $("#" + pg).show();
                });

            }
        });

    });
}

//Mensagens
function Alerta(msg, tipoParam, fixoParam) {
    var tipo = tipoParam.toLowerCase(),
        fixo = $.type(fixoParam) === "boolean" ? fixoParam : $.type(tipo) === "boolean" ? tipo : undefined,
        id = "msg-sistema-{0}".format(tipo);

    $("body").append('<div style=" width: 45%; text-align: center; margin: 0; position: fixed; top: -13px; left: 20%; right: 0px; z-index: 99999;" id="{0}"></div>'.format(id));

    id = "#" + id;

    $(id).html(('<br /><div class="alert alert-{1} alert-dismissible" role="alert"></button>' +
        '<div id="txtErro"> {0} </div></div>').format(msg, tipo));

    if (!fixo) {
        setTimeout(function () {
            $(id).slideUp().remove();
        }, 4000);
    }
    $(id).slideDown("fast");

}

function MsgSucesso(mensagem) {
    if (!mensagem)
        mensagem = "Operação realizada com sucesso";

    Alerta(mensagem, "success");
}

function MsgAlerta(mensagem) {
    Alerta("<b>" + mensagem + "</b>", "warning");
}

function MsgErro(mensagem, acao) {
    var classeErro = "danger";

    if (acao) {
        Alerta("Ocorreu um erro.", classeErro);
        //MensagemConsole("Ação....: " + acao);
        //MensagemConsole("Mensagem: " + mensagem);
    } else {
        Alerta(mensagem, classeErro);
    }
}

//String.Format
String.prototype.format =
    function () {
        var r, args = arguments;

        return this.replace(/{([0-9]|1[0-9]|2[0-9]|3[0-9]|40)}/g, function (a) {
            r = args[parseInt(OnlyNumber(a))];
            if (r != undefined)
                return r;
            throw "Undefined position: " + parseInt(OnlyNumber(a));
        });
    };

function OnlyNumber(s) {
    if (s != undefined && IsString(s))
        return s.replace(/\D/g, "");
    throw "Parse error: String contain non numeric characters " + s;
};

function IsString(s) {
    return ({}.toString).call(s) === "[object String]";
};


//Campos Requeridos
function CamposRequeridos(classe, consideraCampoInvisivel, msgIdentCamposNecessarios) {
    var ok = true;

    //consideraCampoInvisivel - Esse campo é necessário para campos em outras abas que eram desconsiderado por estar invisiveis mas são necessários para um botão final de tela por exemplo.    

    if (classe == undefined || typeof classe != "string") {
        classe = "field-req";
        consideraCampoInvisivel = false;
        msgIdentCamposNecessarios = "";
    } else {
        if (consideraCampoInvisivel == undefined || typeof consideraCampoInvisivel != "boolean")
            consideraCampoInvisivel = false;

        if (msgIdentCamposNecessarios == undefined)
            msgIdentCamposNecessarios = "";
    }

    $(".{0}".format(classe)).each(function (ind, inp) {
        // basta 1 false para ter que dar a mensagem, então tenho que descosiderar os trues.        
        if (!CampoRequerido(inp.id, classe, consideraCampoInvisivel))
            ok = false;
    });

    if (!ok)
        MsgErro("Preencha os campos obrigatórios. {0}".format(msgIdentCamposNecessarios));

    return ok;
}

function CampoRequerido(idInput, classe, paramConsideraCampoInvisivel) {
    var input = $("#" + idInput);
    if (
        ((!input.val()) ||
            (input.val() == undefined) ||
            (input.hasClass("field-decimal") && (ToDecimal(input.val()) <= 0)) ||
            (input.hasClass("field-int") && (parseInt(input.val()) <= 0)) ||
            (input.hasClass("field-enum") && (parseInt(input.val()) <= 0)) ||
            (input.hasClass("field-int-rh") && (parseInt(input.val()) < 0)) ||
            (input.hasClass(classe) && (parseInt(input.val()) <= 0)) //Uso este caso eu queira verificar apenas um <select>
        )

        && (input.is(":visible") || paramConsideraCampoInvisivel)

        && ((!classe) || input.hasClass(classe))

    ) {
        input.css("border", "solid 1px #9400d3");

        return false;

    }
    else {
        input.css("border", "1px solid #d5d5d5");
        return true;
    }

}

function ValorParamContexto(param) {
    var parametrosUrl = window.location.search.replace("?", "").split("&"),
        valor = "";

    $.each(parametrosUrl, function (i, parametro) {
        var paramFinal = parametro.split("=");

        if (paramFinal[0] === param.toString()) {
            valor = paramFinal[1];
            return;
        }
    });

    var regex = new RegExp("\\+", "ig");
    valor = decodeURIComponent(valor);
    valor = valor.replace(regex, " ");

    return valor;
}

function ConfirmarNoty(texto, callbackConfirma, callbackCancelar, botaoConfirma, botaoCancelar) {

    botaoConfirma = botaoConfirma === undefined ? "Sim" : botaoConfirma;
    botaoCancelar = botaoCancelar === undefined ? "Não" : botaoCancelar;

    noty({
        layout: 'center',
        text: texto,
        modal: true,
        maxVisible: 1,
        closeWith: ['button'],
        animation: {
            open: { height: "toggle" },
            close: { height: "toggle" },
            easing: "swing",
            speed: 0
        },
        buttons: [{
            addClass: 'btn btn-danger',
            text: botaoCancelar,
            onClick: typeof callbackCancelar == "function" ? callbackCancelar :
                function ($noty) {
                    $noty.close();
                }
        }, {
            addClass: 'btn btn-blue',
            text: botaoConfirma,
            onClick: typeof callbackConfirma == "function" ? callbackConfirma :
                function ($noty) {
                    $noty.close();
                }
        }]
    });
}

//Validações
function ValidaCpf(cpf) {
    cpf = RetiraMascara(cpf);

    if (cpf.length !== 11)
        return false;
    if (["00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"].indexOf(cpf) !== -1)
        return false;

    var soma = 0,
        i, rev;

    for (i = 0; i < 9; i++) {
        soma += parseInt(cpf.charAt(i)) * (10 - i);
    }

    rev = 11 - (soma % 11);

    if (rev === 10 || rev === 11) {
        rev = 0;
    }

    if (rev !== parseInt(cpf.charAt(9))) {
        return false;
    }

    soma = 0;

    for (i = 0; i < 10; i++) {
        soma += parseInt(cpf.charAt(i)) * (11 - i);
    }

    rev = 11 - (soma % 11);

    if (rev === 10 || rev === 11)
        rev = 0;

    if (rev !== parseInt(cpf.charAt(10))) {
        return false;
    }

    return true;
};

function ValidaEmail(paramEmail) {
    if (!paramEmail)
        return true;

    paramEmail = paramEmail.toLowerCase();

    if (/[áàâãªéèêíìîóòôõº°úùûüç&=+^?<>!#$%:;]/.test(paramEmail))
        return false;

    var procurandoArroba = paramEmail.match(/@/g);

    if (procurandoArroba && procurandoArroba.length !== 1)
        return false;

    if ((paramEmail.indexOf("[") !== -1) ||
        (paramEmail.indexOf("]") !== -1) ||
        (paramEmail.indexOf("(") !== -1) ||
        (paramEmail.indexOf(")") !== -1) ||
        (paramEmail.indexOf("{") !== -1) ||
        (paramEmail.indexOf("}") !== -1) ||
        (paramEmail.indexOf("/") !== -1) ||
        (paramEmail.indexOf("\\") !== -1) ||
        (paramEmail.indexOf("|") !== -1))
        return false;

    var regex = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;;
    return regex.test(paramEmail);

}

function RetiraMascara(paramValor) {

    if (!paramValor)
        return "";

    var exp = /\-|\.|\/|\(|\)| /g;
    return paramValor.toString().replace(exp, "");
}

function LimpaCamposInfoGerais() {
    $("#txt_nome").val("");
    $("#txt_telefone").val("");
    $("#txt_cpf").val("");
    $("#txt_email").val("");
    $("#txt_usuario").val("");
    $("#txt_senha").val("");
    $("#tgl_tipo").bootstrapToggle("off");
}

function LimpaCamposEndereco() {
    $("#txt_logradouro").val("");
    $("#txt_numero").val("");
    $("#txt_bairro").val("");
    $("#txt_complemento").val("");
    $("#txt_cep").val("");
    $("#txt_cidade").val("");
    $("#txt_estado").val("");
}
