/// <reference path="../Cupos/CuposDialog.ts" />

namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosCuposDialog extends CuposDialog {

        constructor() {
            super();
        }

        updateInterface() {
            super.updateInterface();

            Serenity.EditorUtils.setReadOnly(this.form.ClienteId, true);
            Serenity.EditorUtils.setReadOnly(this.form.HotelId, true);
        }
    }
}