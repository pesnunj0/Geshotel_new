

namespace Geshotel.Portal {
    export class ReservaEstadosForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.ReservaEstados';
    }

    export interface ReservaEstadosForm {
        Estado: Serenity.StringEditor;
        EsErrorFechaini: Serenity.IntegerEditor;
        EsErrorFechafin: Serenity.IntegerEditor;
    }

    [['EstadoReservaId', () => Serenity.IntegerEditor], ['Estado', () => Serenity.StringEditor], ['EsErrorFechaini', () => Serenity.IntegerEditor], ['EsErrorFechafin', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReservaEstadosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}