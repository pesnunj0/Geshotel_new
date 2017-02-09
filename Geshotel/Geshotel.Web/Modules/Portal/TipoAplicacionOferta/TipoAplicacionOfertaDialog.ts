
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TipoAplicacionOfertaDialog extends Serenity.EntityDialog<TipoAplicacionOfertaRow, any> {
        protected getFormKey() { return TipoAplicacionOfertaForm.formKey; }
        protected getIdProperty() { return TipoAplicacionOfertaRow.idProperty; }
        protected getLocalTextPrefix() { return TipoAplicacionOfertaRow.localTextPrefix; }
        protected getNameProperty() { return TipoAplicacionOfertaRow.nameProperty; }
        protected getService() { return TipoAplicacionOfertaService.baseUrl; }

        protected form = new TipoAplicacionOfertaForm(this.idPrefix);

    }
}