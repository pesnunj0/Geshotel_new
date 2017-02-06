namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosLineasGrid extends Serenity.EntityGrid<LineasGrid, any> {
        protected getColumnsKey() { return 'Contratos.Lineas'; }
        protected getIdProperty() { return LineasRow.idProperty; }
        protected getLocalTextPrefix() { return LineasRow.localTextPrefix; }
        protected getService() { return LineasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected addButtonClick() {
            this.editItem({ ContratoID: this.contratoID });
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
            return this.contratoID != null;
            //return super.getGridCanLoad() && !!this.contratoID;
        }

        private _contratoID: string;

        get contratoID() {
            return this._contratoID;
        }

        set contratoID(value: string) {
            if (this._contratoID !== value) {
                this._contratoID = value;
                this.setEquality(LineasRow.Fields.ContratoId, value);
                this.refresh();
            }
        }
    }
}




