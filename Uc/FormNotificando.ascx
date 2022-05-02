<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormNotificando.ascx.cs" Inherits="Notfy_LinqToSql.Pgs.FormNotificando" %>

<div class="form-body">
    <div class="mt-1 mb-5">
        <h3><span id="titulo_form_notificando"></span> DE NOTIFICANDO</h3>
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
                <div class="col-md-2"></div>
                <div class="col-md-9">
                    <button type="button" class="btn btn-primary" id="btn_enderecos">
                        ENDEREÇOS&nbsp
                        <i class="fa fa-address-book"></i>
                    </button>
                </div>
            </div>
        </div>

        <div class="mt-3">
            <button type="button" id="btn_cadastrar_editar_notificando" class="btn btn-primary pull-right">
                <span id="titulo_btn_form_notificando"></span>
            </button>
        </div>
    </div>
</div>
