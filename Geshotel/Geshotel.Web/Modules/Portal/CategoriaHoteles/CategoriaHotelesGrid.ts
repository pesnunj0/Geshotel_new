
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class CategoriaHotelesGrid extends Serenity.EntityGrid<CategoriaHotelesRow, any> {
        protected getColumnsKey() { return 'Portal.CategoriaHoteles'; }
        protected getDialogType() { return CategoriaHotelesDialog; }
        protected getIdProperty() { return CategoriaHotelesRow.idProperty; }
        protected getLocalTextPrefix() { return CategoriaHotelesRow.localTextPrefix; }
        protected getService() { return CategoriaHotelesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}