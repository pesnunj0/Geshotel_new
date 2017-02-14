
namespace Geshotel.Portal {
    export class HotelesForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.Hoteles';

    }

    export interface HotelesForm {
        Hotel: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        TipoHotelId: Serenity.LookupEditor;
        CategoriaId: Serenity.LookupEditor;
        NombreCorto: Serenity.StringEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        ProvinciaId: Serenity.LookupEditor;
        NacionId: Serenity.LookupEditor;
        Telefono: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        EmailReservas: Serenity.StringEditor;
        EmailVentas: Serenity.StringEditor;
        EmailSmtp: Serenity.StringEditor;
        TextoCancelacion: Serenity.StringEditor;
        CtaManocorriente: Serenity.StringEditor;
        DptoContable: Serenity.StringEditor;
        CtaContableCajas: Serenity.StringEditor;
        CtaContableBanco: Serenity.StringEditor;
        FechaInicioPrograma: Serenity.DateEditor;
        RutaFicheroPolicia: Serenity.StringEditor;
        ContadorFicheroPolicia: Serenity.IntegerEditor;
        IdentificadorFicheroPolicia: Serenity.StringEditor;
        UsuarioIsta: Serenity.StringEditor;
        PasswordIsta: Serenity.StringEditor;
        UrlIsta: Serenity.StringEditor;
        MunicipioIsta: Serenity.StringEditor;
        NumeroRegistroIsta: Serenity.IntegerEditor;
        RutaBavel: Serenity.StringEditor;
        DingusUsuario: Serenity.StringEditor;
        DingusPassword: Serenity.StringEditor;
        DingusHotelCode: Serenity.StringEditor;
        DingusTraductor: Serenity.StringEditor;
        DingusUrl: Serenity.StringEditor;
        CheckinOnLine: Serenity.IntegerEditor;
        MinimoDiasCheckinOnline: Serenity.IntegerEditor;
        ZoomMapa: Serenity.IntegerEditor;
        Lat: Serenity.DecimalEditor;
        Lng: Serenity.DecimalEditor;
        Ancho: Serenity.IntegerEditor;
        Alto: Serenity.IntegerEditor;
        OverbookingLimit: Serenity.DecimalEditor;
    }

    [['Hotel', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.LookupEditor], ['TipoHotelId', () => Serenity.LookupEditor], ['CategoriaId', () => Serenity.LookupEditor], ['NombreCorto', () => Serenity.StringEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['ProvinciaId', () => Serenity.LookupEditor], ['NacionId', () => Serenity.LookupEditor], ['Telefono', () => Serenity.StringEditor], ['Fax', () => Serenity.StringEditor], ['EmailReservas', () => Serenity.StringEditor], ['EmailVentas', () => Serenity.StringEditor], ['EmailSmtp', () => Serenity.StringEditor], ['TextoCancelacion', () => Serenity.StringEditor], ['CtaManocorriente', () => Serenity.StringEditor], ['DptoContable', () => Serenity.StringEditor], ['CtaContableCajas', () => Serenity.StringEditor], ['CtaContableBanco', () => Serenity.StringEditor], ['FechaInicioPrograma', () => Serenity.DateEditor], ['RutaFicheroPolicia', () => Serenity.StringEditor], ['ContadorFicheroPolicia', () => Serenity.IntegerEditor], ['IdentificadorFicheroPolicia', () => Serenity.StringEditor], ['UsuarioIsta', () => Serenity.StringEditor], ['PasswordIsta', () => Serenity.StringEditor], ['UrlIsta', () => Serenity.StringEditor], ['MunicipioIsta', () => Serenity.StringEditor], ['NumeroRegistroIsta', () => Serenity.IntegerEditor], ['RutaBavel', () => Serenity.StringEditor], ['DingusUsuario', () => Serenity.StringEditor], ['DingusPassword', () => Serenity.StringEditor], ['DingusHotelCode', () => Serenity.StringEditor], ['DingusTraductor', () => Serenity.StringEditor], ['DingusUrl', () => Serenity.StringEditor], ['CheckinOnLine', () => Serenity.IntegerEditor], ['MinimoDiasCheckinOnline', () => Serenity.IntegerEditor], ['ZoomMapa', () => Serenity.IntegerEditor], ['Lat', () => Serenity.DecimalEditor], ['Lng', () => Serenity.DecimalEditor], ['Ancho', () => Serenity.IntegerEditor], ['Alto', () => Serenity.IntegerEditor], ['OverbookingLimit', () => Serenity.DecimalEditor]].forEach(x => Object.defineProperty(HotelesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

