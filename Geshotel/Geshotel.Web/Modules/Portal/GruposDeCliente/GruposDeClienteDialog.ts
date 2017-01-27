
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class GruposDeClienteDialog extends Serenity.EntityDialog<GruposDeClienteRow, any> {
        protected getFormKey() { return GruposDeClienteForm.formKey; }
        protected getIdProperty() { return GruposDeClienteRow.idProperty; }
        protected getLocalTextPrefix() { return GruposDeClienteRow.localTextPrefix; }
        protected getNameProperty() { return GruposDeClienteRow.nameProperty; }
        protected getService() { return GruposDeClienteService.baseUrl; }

        protected form = new GruposDeClienteForm(this.idPrefix);

    }
}