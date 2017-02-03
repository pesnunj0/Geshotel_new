
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class MercadosGrid extends Serenity.EntityGrid<MercadosRow, any> {
        protected getColumnsKey() { return 'Contratos.Mercados'; }
        protected getDialogType() { return MercadosDialog; }
        protected getIdProperty() { return MercadosRow.idProperty; }
        protected getLocalTextPrefix() { return MercadosRow.localTextPrefix; }
        protected getService() { return MercadosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}