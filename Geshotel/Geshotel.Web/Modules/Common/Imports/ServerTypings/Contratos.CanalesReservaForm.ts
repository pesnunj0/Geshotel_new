
namespace Geshotel.Contratos {
    export class CanalesReservaForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.CanalesReserva';

    }

    export interface CanalesReservaForm {
        EmpresaId: Serenity.LookupEditor;
        NombreCanal: Serenity.StringEditor;
    }

    [['EmpresaId', () => Serenity.LookupEditor], ['NombreCanal', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(CanalesReservaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

