
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AgenciasDialog extends Serenity.EntityDialog<AgenciasRow, any> {
        protected getFormKey() { return AgenciasForm.formKey; }
        protected getIdProperty() { return AgenciasRow.idProperty; }
        protected getLocalTextPrefix() { return AgenciasRow.localTextPrefix; }
        protected getNameProperty() { return AgenciasRow.nameProperty; }
        protected getService() { return AgenciasService.baseUrl; }

        protected form = new AgenciasForm(this.idPrefix);

    }
}