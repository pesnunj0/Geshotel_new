
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AmbitoOfertaDialog extends Serenity.EntityDialog<AmbitoOfertaRow, any> {
        protected getFormKey() { return AmbitoOfertaForm.formKey; }
        protected getIdProperty() { return AmbitoOfertaRow.idProperty; }
        protected getLocalTextPrefix() { return AmbitoOfertaRow.localTextPrefix; }
        protected getNameProperty() { return AmbitoOfertaRow.nameProperty; }
        protected getService() { return AmbitoOfertaService.baseUrl; }

        protected form = new AmbitoOfertaForm(this.idPrefix);

    }
}