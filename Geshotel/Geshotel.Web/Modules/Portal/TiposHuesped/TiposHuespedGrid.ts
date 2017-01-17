
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposHuespedGrid extends Serenity.EntityGrid<TiposHuespedRow, any> {
        protected getColumnsKey() { return 'Portal.TiposHuesped'; }
        protected getDialogType() { return TiposHuespedDialog; }
        protected getIdProperty() { return TiposHuespedRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHuespedRow.localTextPrefix; }
        protected getService() { return TiposHuespedService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}