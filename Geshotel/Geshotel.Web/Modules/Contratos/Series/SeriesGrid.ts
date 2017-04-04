
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class SeriesGrid extends Serenity.EntityGrid<SeriesRow, any> {
        protected getColumnsKey() { return 'Contratos.Series'; }
        protected getDialogType() { return SeriesDialog; }
        protected getIdProperty() { return SeriesRow.idProperty; }
        protected getLocalTextPrefix() { return SeriesRow.localTextPrefix; }
        protected getService() { return SeriesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}