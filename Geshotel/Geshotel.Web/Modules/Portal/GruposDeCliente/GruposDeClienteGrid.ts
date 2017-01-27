
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class GruposDeClienteGrid extends Serenity.EntityGrid<GruposDeClienteRow, any> {
        protected getColumnsKey() { return 'Portal.GruposDeCliente'; }
        protected getDialogType() { return GruposDeClienteDialog; }
        protected getIdProperty() { return GruposDeClienteRow.idProperty; }
        protected getLocalTextPrefix() { return GruposDeClienteRow.localTextPrefix; }
        protected getService() { return GruposDeClienteService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}