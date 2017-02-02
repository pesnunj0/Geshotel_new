
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class ReleasesGrid extends Serenity.EntityGrid<ReleasesRow, any> {
        protected getColumnsKey() { return 'Contratos.Releases'; }
        protected getDialogType() { return ReleasesDialog; }
        protected getIdProperty() { return ReleasesRow.idProperty; }
        protected getLocalTextPrefix() { return ReleasesRow.localTextPrefix; }
        protected getService() { return ReleasesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}