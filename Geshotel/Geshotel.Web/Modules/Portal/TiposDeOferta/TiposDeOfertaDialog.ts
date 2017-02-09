
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposDeOfertaDialog extends Serenity.EntityDialog<TiposDeOfertaRow, any> {
        protected getFormKey() { return TiposDeOfertaForm.formKey; }
        protected getIdProperty() { return TiposDeOfertaRow.idProperty; }
        protected getLocalTextPrefix() { return TiposDeOfertaRow.localTextPrefix; }
        protected getNameProperty() { return TiposDeOfertaRow.nameProperty; }
        protected getService() { return TiposDeOfertaService.baseUrl; }

        protected form = new TiposDeOfertaForm(this.idPrefix);

    }
}