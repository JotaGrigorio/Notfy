<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormNotificacao.ascx.cs" Inherits="Notfy_LinqToSql.Uc.FormNotificacao" %>

<div class="form-body">
    <div class="mt-1 mb-5">
        <h3><span id="titulo_form_notificacao"></span> DE NOTIFICAÇÃO</h3>
    </div>

    <div class="form-horizontal">
        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-3">Notificador</label>
                <div class="col-md-9">
                    <select id="sel_notificadores" class="form-control field-req"></select>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-3">Notificando</label>
                <div class="col-md-9">
                    <select id="sel_notificandos" class="form-control field-req"></select>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-3">Endereço</label>
                <div class="col-md-9">
                    <select id="sel_enderecos" class="form-control field-req"></select>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <label class="form-label col-md-3">Matrícula</label>
                <div class="col-md-9">
                    <input type="text" id="txt_matricula_imovel" class="form-control field-req" placeholder="Digite o número da matrícula do imóvel" maxlength="10" />
                </div>
            </div>
        </div>

        <div id="notificacao_controle" class="inicia-invisivel">
            <div class="form-group">
                <div class="row">
                    <label class="form-label col-md-3">Tentativa 1</label>
                    <div class="col-md-9">
                        <input type="date" id="txt_tentativa_1" class="form-control" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <label class="form-label col-md-3">Tentativa 2</label>
                    <div class="col-md-9">
                        <input type="date" id="txt_tentativa_2" class="form-control" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <label class="form-label col-md-3">Tentativa 3</label>
                    <div class="col-md-9">
                        <input type="date" id="txt_tentativa_3" class="form-control" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <label class="form-label col-md-3">Concluído</label>
                    <div class="col-md-9">
                        <select id="sel_concluido" class="form-control field-req">
                            <option value="0">Em aberto</option>
                            <option value="1">Não</option>
                            <option value="2">Sim</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-9">
                    <button type="button" class="btn btn-primary" id="btn_observacoes">
                        OBSERVAÇÕES&nbsp
                        <i class="fa fa-book"></i>
                    </button>
                </div>
            </div>
        </div>

        <div class="mt-3">
            <button type="button" id="btn_cadastrar_editar_notificacao" class="btn btn-primary pull-right">
                <span id="titulo_btn_form_notificacao"></span>
            </button>
        </div>
    </div>
</div>
