namespace Geshotel.Contratos {
    export class TemporadasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Temporadas';

    }

    export interface TemporadasForm {
        Temporada: Serenity.StringEditor;
        EmpresaId: Serenity.IntegerEditor;
        Ano: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
    }

    [['Temporada', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.IntegerEditor], ['Ano', () => Serenity.IntegerEditor], ['FechaDesde', () => Serenity.DateEditor], ['FechaHasta', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(TemporadasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

