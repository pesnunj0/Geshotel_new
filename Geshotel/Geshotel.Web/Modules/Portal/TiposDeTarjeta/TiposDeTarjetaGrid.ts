
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposDeTarjetaGrid extends Serenity.EntityGrid<TiposDeTarjetaRow, any> {
        protected getColumnsKey() { return 'Portal.TiposDeTarjeta'; }
        protected getDialogType() { return TiposDeTarjetaDialog; }
        protected getIdProperty() { return TiposDeTarjetaRow.idProperty; }
        protected getLocalTextPrefix() { return TiposDeTarjetaRow.localTextPrefix; }
        protected getService() { return TiposDeTarjetaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}