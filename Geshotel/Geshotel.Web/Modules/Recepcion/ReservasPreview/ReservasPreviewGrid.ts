﻿/*
    Este es un Grid un tantos especial, ya que pertenece a un tab de reservas y por lo tanto, será llamado con numero de reserva
    Además, se elimina el AddButton.
    Totalizamos Importe y Agrupamos por Fecha
    Miramos si el campo error = 1 y ponemos la fila en rojo.
    Finalmente ponemos un custom link, el link sobre contratoId nos llevará a ver el contrato segun ContratoId
    Javier Nuñez Abril 2017
*/
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ReservasPreviewGrid extends Serenity.EntityGrid<ReservasPreviewItem, any> {
        protected getColumnsKey() { return "Recepcion.ReservasPreview"; }
        protected getIdProperty()  { return "Key"; } 
        protected getLocalTextPrefix() { return "Recepcion.ReservasPreview"; }
        protected getService() { return ReservasPreviewService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        // Esta la utilizaremos para totalizar Precio
        protected createSlickGrid() {
            var grid = super.createSlickGrid();

            // need to register this plugin for grouping or you'll have errors
            grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());
            // Sumamos la columna Importe
            this.view.setSummaryOptions({
                aggregators: [
                    new Slick.Aggregators.Sum('Importe')
                ]
            });
            // Agrupamos por día
            this.view.setGrouping(
                [{
                    getter: 'Fecha'
                }])
            return grid;
        }

        protected getSlickOptions() {
            var opt = super.getSlickOptions();
            opt.showFooterRow = true;
            return opt;
        }


        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
            return this.reservaID != null;
        }
        // Esta hace que no se pagine. Importante si se totaliza
        protected usePager() {
            return false;
        }

        private _reservaID: number;

        get reservaID() {
            return this._reservaID;
        }

        set reservaID(value: number) {
            if (this._reservaID !== value) {
                this._reservaID = value;
                //this.setEquality(ReservasContratosRow.Fields.ReservaId, value);
                this.refresh();
            }
        }

        protected onViewSubmit() {
            if (!super.onViewSubmit())
                return false;

            (this.view.params as ReservasPreviewListRequest).ReservaId = this._reservaID;

            return true;
        }

        protected getButtons(): Serenity.ToolButton[] {

            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }
        /**
* This method is called for all rows
* @param item Data item for current row
* @param index Index of the row in grid
*/
        protected getItemCssClass(item: Recepcion.ReservasPreviewItem, index: number): string {

            let klass: string = "";
            if (item.Error == 1 && item.DescTipo == null)
                klass += " con-errores";
            else
                klass += " sin-errores";

            return Q.trimToNull(klass);
        }
    }
}