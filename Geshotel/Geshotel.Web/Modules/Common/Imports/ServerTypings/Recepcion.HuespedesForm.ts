

namespace Geshotel.Recepcion {
    export class HuespedesForm extends Serenity.PrefixedContext {
        static formKey = 'Recepcion.Huespedes';
    }

    export interface HuespedesForm {
        EmpresaId: Serenity.IntegerEditor;
        Nombre: Serenity.StringEditor;
        Apellidos: Serenity.StringEditor;
        TipoDocumentoId: Serenity.StringEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
        SexoId: Serenity.StringEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        NacionId: Serenity.IntegerEditor;
        ProvinciaId: Serenity.IntegerEditor;
        Telefono: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        Foto1: Serenity.StringEditor;
        Foto2: Serenity.StringEditor;
        TarjetaFidelizacion: Serenity.StringEditor;
    }

    [['HuespedId', () => Serenity.IntegerEditor], ['EmpresaId', () => Serenity.IntegerEditor], ['Nombre', () => Serenity.StringEditor], ['Apellidos', () => Serenity.StringEditor], ['TipoDocumentoId', () => Serenity.StringEditor], ['Nif', () => Serenity.StringEditor], ['FechaDocumento', () => Serenity.DateEditor], ['SexoId', () => Serenity.StringEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['NacionId', () => Serenity.IntegerEditor], ['ProvinciaId', () => Serenity.IntegerEditor], ['Telefono', () => Serenity.StringEditor], ['Email', () => Serenity.StringEditor], ['Foto1', () => Serenity.StringEditor], ['Foto2', () => Serenity.StringEditor], ['TarjetaFidelizacion', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(HuespedesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}