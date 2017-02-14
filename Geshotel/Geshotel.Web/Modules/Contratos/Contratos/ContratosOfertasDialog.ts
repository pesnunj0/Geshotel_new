/// <reference path="../Ofertas/OfertasDialog.ts" />

namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosOfertasDialog extends OfertasDialog {

        constructor() {
            super();
        }

        updateInterface() {
            super.updateInterface();

            Serenity.EditorUtils.setReadOnly(this.form.ContratoId, true);
        }
    }
}