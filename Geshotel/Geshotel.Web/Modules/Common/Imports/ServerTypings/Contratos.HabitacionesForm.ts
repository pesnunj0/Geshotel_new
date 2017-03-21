
namespace Geshotel.Contratos {
    export class HabitacionesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Habitaciones';

    }

    export interface HabitacionesForm {
        HotelId: Serenity.LookupEditor;
        NumeroHabitacion: Serenity.StringEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        Extension: Serenity.IntegerEditor;
        Observaciones: Serenity.StringEditor;
        SituacionId: Serenity.LookupEditor;
        FechaInicio: Serenity.DateEditor;
        EstadoTelefono: Serenity.IntegerEditor;
        EstadoProcesado: Serenity.IntegerEditor;
        HabitacionIsta: Serenity.StringEditor;
        ZonaLimpiezaId: Serenity.IntegerEditor;
        Lat: Serenity.DecimalEditor;
        Lng: Serenity.DecimalEditor;
        PrimaryImage: Serenity.StringEditor;
        Galleryimages: Serenity.StringEditor;
        Planta: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }

    [['HotelId', () => Serenity.LookupEditor], ['NumeroHabitacion', () => Serenity.StringEditor], ['TipoHabitacionId', () => Serenity.LookupEditor], ['Extension', () => Serenity.IntegerEditor], ['Observaciones', () => Serenity.StringEditor], ['SituacionId', () => Serenity.LookupEditor], ['FechaInicio', () => Serenity.DateEditor], ['EstadoTelefono', () => Serenity.IntegerEditor], ['EstadoProcesado', () => Serenity.IntegerEditor], ['HabitacionIsta', () => Serenity.StringEditor], ['ZonaLimpiezaId', () => Serenity.IntegerEditor], ['Lat', () => Serenity.DecimalEditor], ['Lng', () => Serenity.DecimalEditor], ['PrimaryImage', () => Serenity.StringEditor], ['Galleryimages', () => Serenity.StringEditor], ['Planta', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(HabitacionesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

