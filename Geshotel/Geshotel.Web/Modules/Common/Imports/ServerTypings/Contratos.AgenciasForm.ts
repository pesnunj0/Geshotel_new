namespace Geshotel.Contratos {
    export class AgenciasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Agencias';

    }

    export interface AgenciasForm {
        Razon: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        Nombre: Serenity.StringEditor;
        Apellidos: Serenity.StringEditor;
        EmpresaId: Serenity.IntegerEditor;
        AgenciaId: Serenity.IntegerEditor;
        MercadoId: Serenity.IntegerEditor;
        ClienteDefecto: Serenity.BooleanEditor;
        GrupoClienteId: Serenity.IntegerEditor;
        TipoDocumentoId: Serenity.StringEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
        SexoId: Serenity.StringEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        NacionId: Serenity.IntegerEditor;
        ProvinciaId: Serenity.IntegerEditor;
        CtaContableAnticipo: Serenity.StringEditor;
        CtaContable: Serenity.StringEditor;
        DptoContable: Serenity.StringEditor;
        CtaDepositos: Serenity.StringEditor;
        Telefono: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        Contacto: Serenity.StringEditor;
        TelefonoContacto: Serenity.StringEditor;
        FaxContacto: Serenity.StringEditor;
        EmailContacto: Serenity.StringEditor;
        AceptaLopd: Serenity.DateEditor;
        CifFra: Serenity.StringEditor;
        DireccionFra: Serenity.StringEditor;
        PoblacionFra: Serenity.StringEditor;
        ZipFra: Serenity.StringEditor;
        NacionIdFactura: Serenity.IntegerEditor;
        ProvinciaIdFactura: Serenity.IntegerEditor;
        ClienteFactura: Serenity.BooleanEditor;
        ClienteHuesped: Serenity.BooleanEditor;
        PermiteCredito: Serenity.BooleanEditor;
        LimiteCredito: Serenity.DecimalEditor;
        FacturaAnticipada: Serenity.BooleanEditor;
        VencimientoFacturasId: Serenity.IntegerEditor;
        FechaNacimiento: Serenity.DateEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        ClienteBavel: Serenity.StringEditor;
        Foto1: Serenity.StringEditor;
        Foto2: Serenity.StringEditor;
        DingusExtras: Serenity.BooleanEditor;
        IdClubhd: Serenity.StringEditor;
    }

    [['Razon', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['Nombre', () => Serenity.StringEditor], ['Apellidos', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.IntegerEditor], ['AgenciaId', () => Serenity.IntegerEditor], ['MercadoId', () => Serenity.IntegerEditor], ['ClienteDefecto', () => Serenity.BooleanEditor], ['GrupoClienteId', () => Serenity.IntegerEditor], ['TipoDocumentoId', () => Serenity.StringEditor], ['Nif', () => Serenity.StringEditor], ['FechaDocumento', () => Serenity.DateEditor], ['SexoId', () => Serenity.StringEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['NacionId', () => Serenity.IntegerEditor], ['ProvinciaId', () => Serenity.IntegerEditor], ['CtaContableAnticipo', () => Serenity.StringEditor], ['CtaContable', () => Serenity.StringEditor], ['DptoContable', () => Serenity.StringEditor], ['CtaDepositos', () => Serenity.StringEditor], ['Telefono', () => Serenity.StringEditor], ['Email', () => Serenity.StringEditor], ['Fax', () => Serenity.StringEditor], ['Contacto', () => Serenity.StringEditor], ['TelefonoContacto', () => Serenity.StringEditor], ['FaxContacto', () => Serenity.StringEditor], ['EmailContacto', () => Serenity.StringEditor], ['AceptaLopd', () => Serenity.DateEditor], ['CifFra', () => Serenity.StringEditor], ['DireccionFra', () => Serenity.StringEditor], ['PoblacionFra', () => Serenity.StringEditor], ['ZipFra', () => Serenity.StringEditor], ['NacionIdFactura', () => Serenity.IntegerEditor], ['ProvinciaIdFactura', () => Serenity.IntegerEditor], ['ClienteFactura', () => Serenity.BooleanEditor], ['ClienteHuesped', () => Serenity.BooleanEditor], ['PermiteCredito', () => Serenity.BooleanEditor], ['LimiteCredito', () => Serenity.DecimalEditor], ['FacturaAnticipada', () => Serenity.BooleanEditor], ['VencimientoFacturasId', () => Serenity.IntegerEditor], ['FechaNacimiento', () => Serenity.DateEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor], ['ClienteBavel', () => Serenity.StringEditor], ['Foto1', () => Serenity.StringEditor], ['Foto2', () => Serenity.StringEditor], ['DingusExtras', () => Serenity.BooleanEditor], ['IdClubhd', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(AgenciasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

