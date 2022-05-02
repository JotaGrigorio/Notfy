<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormNotificador.ascx.cs" Inherits="Notfy_LinqToSql.Pgs.FormNotificador" %>

<div class="form-body">
    <div class="mt-1 mb-5">
        <h3><span id="titulo_form_notificador"></span> DE NOTIFICADOR</h3>
    </div>

    <div class="form-horizontal">
        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-2">Nome</label>
                <div class="col-md-10">
                    <input type="text" id="txt_nome" class="form-control field-req" placeholder="Digite o nome" maxlength="200" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-2">Telefone</label>
                <div class="col-md-10">
                    <input type="text" id="txt_telefone" class="form-control field-req" placeholder="(00) 00000-0000" maxlength="22" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-2">CPF</label>
                <div class="col-md-10">
                    <input type="text" id="txt_cpf" class="form-control field-req" placeholder="000.000.000-00" maxlength="20" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-2">Email</label>
                <div class="col-md-10">
                    <input type="text" id="txt_email" class="form-control field-req" placeholder="Digite o email" maxlength="200" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-2">Usuário</label>
                <div class="col-md-10">
                    <input type="text" id="txt_usuario" class="form-control field-req" placeholder="Digite o usuário" maxlength="200" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-2">Senha</label>
                <div class="col-md-10">
                    <input type="password" id="txt_senha" class="form-control field-req" placeholder="Digite a senha" maxlength="50" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-2">Tipo</label>
                <div class="col-md-10">
                    <input id="tgl_tipo" type="checkbox" data-toggle="toggle" data-size="small" data-on="Administrador" data-off="Comum" />
                </div>
            </div>
        </div>

        <div class="mt-3">
            <button type="button" id="btn_cadastrar_editar_notificador" class="btn btn-primary pull-right">
                <span id="titulo_btn_form_notificador"></span>
            </button>
        </div>
    </div>
</div>
