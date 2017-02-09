
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class FrecuenciaFacturacionGrid extends Serenity.EntityGrid<FrecuenciaFacturacionRow, any> {
        protected getColumnsKey() { return 'Portal.FrecuenciaFacturacion'; }
        protected getDialogType() { return FrecuenciaFacturacionDialog; }
        protected getIdProperty() { return FrecuenciaFacturacionRow.idProperty; }
        protected getLocalTextPrefix() { return FrecuenciaFacturacionRow.localTextPrefix; }
        protected getService() { return FrecuenciaFacturacionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}