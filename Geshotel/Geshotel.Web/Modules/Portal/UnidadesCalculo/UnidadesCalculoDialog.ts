
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class UnidadesCalculoDialog extends Serenity.EntityDialog<UnidadesCalculoRow, any> {
        protected getFormKey() { return UnidadesCalculoForm.formKey; }
        protected getIdProperty() { return UnidadesCalculoRow.idProperty; }
        protected getLocalTextPrefix() { return UnidadesCalculoRow.localTextPrefix; }
        protected getNameProperty() { return UnidadesCalculoRow.nameProperty; }
        protected getService() { return UnidadesCalculoService.baseUrl; }

        protected form = new UnidadesCalculoForm(this.idPrefix);

    }
}