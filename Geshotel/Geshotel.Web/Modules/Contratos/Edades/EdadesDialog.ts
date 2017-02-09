
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class EdadesDialog extends Serenity.EntityDialog<EdadesRow, any> {
        protected getFormKey() { return EdadesForm.formKey; }
        protected getIdProperty() { return EdadesRow.idProperty; }
        protected getLocalTextPrefix() { return EdadesRow.localTextPrefix; }
        protected getService() { return EdadesService.baseUrl; }

        protected form = new EdadesForm(this.idPrefix);

    }
}