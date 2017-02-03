
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class TemporadasGrid extends Serenity.EntityGrid<TemporadasRow, any> {
        protected getColumnsKey() { return 'Contratos.Temporadas'; }
        protected getDialogType() { return TemporadasDialog; }
        protected getIdProperty() { return TemporadasRow.idProperty; }
        protected getLocalTextPrefix() { return TemporadasRow.localTextPrefix; }
        protected getService() { return TemporadasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}