
namespace Geshotel.Contratos {
    export class ServiciosHotelForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.ServiciosHotel';

    }

    export interface ServiciosHotelForm {
        ServicioId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        ImpuestoId: Serenity.LookupEditor;
        Costo: Serenity.DecimalEditor;
        CtaContable: Serenity.StringEditor;
        DptoContable: Serenity.StringEditor;
        PermiteCredito: Serenity.BooleanEditor;
    }

    [['ServicioId', () => Serenity.LookupEditor], ['HotelId', () => Serenity.LookupEditor], ['ImpuestoId', () => Serenity.LookupEditor], ['Costo', () => Serenity.DecimalEditor], ['CtaContable', () => Serenity.StringEditor], ['DptoContable', () => Serenity.StringEditor], ['PermiteCredito', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(ServiciosHotelForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

