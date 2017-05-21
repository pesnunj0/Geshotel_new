
namespace Geshotel.Contratos {
    export class AgenciasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Agencias';

    }

    export interface AgenciasForm {
        Razon: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        GrupoClienteId: Serenity.LookupEditor;
        TipoDocumentoId: Serenity.LookupEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        NacionId: Serenity.LookupEditor;
        ProvinciaId: Serenity.LookupEditor;
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
        CifFra: Serenity.StringEditor;
        DireccionFra: Serenity.StringEditor;
        PoblacionFra: Serenity.StringEditor;
        ZipFra: Serenity.StringEditor;
        NacionIdFactura: Serenity.LookupEditor;
        ProvinciaIdFactura: Serenity.LookupEditor;
        ClienteFactura: Serenity.BooleanEditor;
        PermiteCredito: Serenity.BooleanEditor;
        LimiteCredito: Serenity.DecimalEditor;
        FacturaAnticipada: Serenity.BooleanEditor;
        VencimientoFacturasId: Serenity.IntegerEditor;
        UserId: Serenity.LookupEditor;
        FechaModificacion: Serenity.DateEditor;
        ClienteBavel: Serenity.StringEditor;
    }

    [['Razon', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.LookupEditor], ['GrupoClienteId', () => Serenity.LookupEditor], ['TipoDocumentoId', () => Serenity.LookupEditor], ['Nif', () => Serenity.StringEditor], ['FechaDocumento', () => Serenity.DateEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['NacionId', () => Serenity.LookupEditor], ['ProvinciaId', () => Serenity.LookupEditor], ['CtaContableAnticipo', () => Serenity.StringEditor], ['CtaContable', () => Serenity.StringEditor], ['DptoContable', () => Serenity.StringEditor], ['CtaDepositos', () => Serenity.StringEditor], ['Telefono', () => Serenity.StringEditor], ['Email', () => Serenity.StringEditor], ['Fax', () => Serenity.StringEditor], ['Contacto', () => Serenity.StringEditor], ['TelefonoContacto', () => Serenity.StringEditor], ['FaxContacto', () => Serenity.StringEditor], ['EmailContacto', () => Serenity.StringEditor], ['CifFra', () => Serenity.StringEditor], ['DireccionFra', () => Serenity.StringEditor], ['PoblacionFra', () => Serenity.StringEditor], ['ZipFra', () => Serenity.StringEditor], ['NacionIdFactura', () => Serenity.LookupEditor], ['ProvinciaIdFactura', () => Serenity.LookupEditor], ['ClienteFactura', () => Serenity.BooleanEditor], ['PermiteCredito', () => Serenity.BooleanEditor], ['LimiteCredito', () => Serenity.DecimalEditor], ['FacturaAnticipada', () => Serenity.BooleanEditor], ['VencimientoFacturasId', () => Serenity.IntegerEditor], ['UserId', () => Serenity.LookupEditor], ['FechaModificacion', () => Serenity.DateEditor], ['ClienteBavel', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(AgenciasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

