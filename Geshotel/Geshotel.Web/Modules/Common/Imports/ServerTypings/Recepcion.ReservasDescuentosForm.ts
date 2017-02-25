
namespace Geshotel.Recepcion {
    export class ReservasDescuentosForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.ReservasDescuentos';

    }

    export interface ReservasDescuentosForm {
        ReservaId: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
        TipoDescuentoId: Serenity.IntegerEditor;
        Tipo: Serenity.StringEditor;
        Descuento: Serenity.DecimalEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['ReservaId', () => Serenity.IntegerEditor], ['ServicioId', () => Serenity.IntegerEditor], ['TipoDescuentoId', () => Serenity.IntegerEditor], ['Tipo', () => Serenity.StringEditor], ['Descuento', () => Serenity.DecimalEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(ReservasDescuentosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

