<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MdlObservacoesNotificacao.ascx.cs" Inherits="Notfy_LinqToSql.Uc.MdlObservacoesNotificacao" %>

<div class="modal fade" id="mdlObservacoesNotificacao" tabindex="-1" role="dialog" data-backdrop="static">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">

            <div class="modal-header" style="background-color: #2E6DA4">
                <h3 style="color: whitesmoke;">Observações</h3>
                <button type="button" class="btn btn-close-white fw-bold" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"></span>X</button>
            </div>

            <div class="modal-body" style="background-color: #E3F2F2">
                <div class="container">
                    <div class="form-group shadow-textarea">
                        <textarea class="form-control" id="text_area_observacoes" rows="5"></textarea>
                    </div>

                    <div class="mt-2">
                        <button type="button" data-dismiss="modal" class="btn btn-primary pull-right">
                            <span>FECHAR</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
