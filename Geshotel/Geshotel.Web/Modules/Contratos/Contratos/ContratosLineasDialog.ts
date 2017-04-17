/// <reference path="../Lineas/LineasDialog.ts" />

namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosLineasDialog extends LineasDialog {

        constructor() {
            super();
        }

        updateInterface() {
            super.updateInterface();

            Serenity.EditorUtils.setReadOnly(this.form.ContratoId, true);
            Serenity.EditorUtils.setReadOnly(this.form.HotelId, true);
        }
    }
}