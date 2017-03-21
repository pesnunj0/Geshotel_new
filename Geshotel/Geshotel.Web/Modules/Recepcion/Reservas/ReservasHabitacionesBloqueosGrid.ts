namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ReservasHabitacionesBloqueosGrid extends Serenity.EntityGrid<HabitacionesBloqueosGrid, any> {
        protected getDialogType() { return ReservasHabitacionesBloqueosDialog; }
        protected getColumnsKey() { return 'Recepcion.ReservasHabitacionesBloqueos'; }
        protected getIdProperty() { return HabitacionesBloqueosRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesBloqueosRow.localTextPrefix; }
        protected getService() { return HabitacionesBloqueosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected initEntityDialog(itemType, dialog) {
            super.initEntityDialog(itemType, dialog);
            Serenity.SubDialogHelper.cascade(dialog, this.element.closest('.ui-dialog'));
        }

        protected addButtonClick() {
            // Javascript is case sensitive, so contratoID didn't work here.
            // To get intellisense, use a TS cast like below <LineasRow>
            this.editItem(<HabitacionesBloqueosRow>{
                ReservaId: this.reservaID,
                TipoBloqueoId : 1
            });
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Contratos/Lineas/ListExcel',
                separator: true
            }));

            buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
           return this.reservaID != null;
            
        }

        private _reservaID: number;
        private _tipoBloqueoID: number;

        get tipoBloqueoID() {
            return 1;
        }

        get reservaID() {
            return this._reservaID;
        }

        set reservaID(value: number) {
            if (this._reservaID !== value) {
                this._reservaID = value;
                this.setEquality(HabitacionesBloqueosRow.Fields.ReservaId, value);
                this.refresh();
            }
        }
        set tipoBloqueoID(value: number) {
            this._tipoBloqueoID = 1;
            this.setEquality(HabitacionesBloqueosRow.Fields.TipoBloqueoId, 1);
            this.refresh();
        }
    }
}




