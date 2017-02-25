
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposDeTarjetaDialog extends Serenity.EntityDialog<TiposDeTarjetaRow, any> {
        protected getFormKey() { return TiposDeTarjetaForm.formKey; }
        protected getIdProperty() { return TiposDeTarjetaRow.idProperty; }
        protected getLocalTextPrefix() { return TiposDeTarjetaRow.localTextPrefix; }
        protected getNameProperty() { return TiposDeTarjetaRow.nameProperty; }
        protected getService() { return TiposDeTarjetaService.baseUrl; }

        protected form = new TiposDeTarjetaForm(this.idPrefix);

    }
}