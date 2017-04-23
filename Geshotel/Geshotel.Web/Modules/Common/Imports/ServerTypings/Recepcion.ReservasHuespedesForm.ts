
namespace Geshotel.Recepcion {
    export class ReservasHuespedesForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.ReservasHuespedes';

    }

    export interface ReservasHuespedesForm {
        ReservaId: Serenity.IntegerEditor;
        Nombre: Serenity.StringEditor;
        Apellidos: Serenity.StringEditor;
        TipoDocumentoId: Serenity.LookupEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
        SexoId: Serenity.LookupEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        NacionId: Serenity.LookupEditor;
        ProvinciaId: Serenity.LookupEditor;
        Telefono: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        HuespedId: Serenity.IntegerEditor;
        FechaLlegada: Serenity.DateEditor;
        FechaSalida: Serenity.DateEditor;
        HabitacionId: Serenity.LookupEditor;
        Edad: Serenity.IntegerEditor;
    }

    [['ReservaId', () => Serenity.IntegerEditor], ['Nombre', () => Serenity.StringEditor], ['Apellidos', () => Serenity.StringEditor], ['TipoDocumentoId', () => Serenity.LookupEditor], ['Nif', () => Serenity.StringEditor], ['FechaDocumento', () => Serenity.DateEditor], ['SexoId', () => Serenity.LookupEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['NacionId', () => Serenity.LookupEditor], ['ProvinciaId', () => Serenity.LookupEditor], ['Telefono', () => Serenity.StringEditor], ['Email', () => Serenity.EmailEditor], ['HuespedId', () => Serenity.IntegerEditor], ['FechaLlegada', () => Serenity.DateEditor], ['FechaSalida', () => Serenity.DateEditor], ['HabitacionId', () => Serenity.LookupEditor], ['Edad', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ReservasHuespedesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

