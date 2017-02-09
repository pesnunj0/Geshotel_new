
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ContratosEdadesDialog extends Serenity.EntityDialog<ContratosEdadesRow, any> {
        protected getFormKey() { return ContratosEdadesForm.formKey; }
        protected getIdProperty() { return ContratosEdadesRow.idProperty; }
        protected getLocalTextPrefix() { return ContratosEdadesRow.localTextPrefix; }
        protected getService() { return ContratosEdadesService.baseUrl; }

        protected form = new ContratosEdadesForm(this.idPrefix);

    }
}