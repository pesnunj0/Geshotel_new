
namespace Geshotel.Contratos {
    export class ClientesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Clientes';

    }

    export interface ClientesForm {
        Razon: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        AgenciaId: Serenity.LookupEditor;
        ClienteDefecto: Serenity.BooleanEditor;
        GrupoClienteId: Serenity.LookupEditor;
        TipoDocumentoId: Serenity.LookupEditor;
        Nif: Serenity.StringEditor;
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
        Email: Serenity.EmailEditor;
        Fax: Serenity.StringEditor;
        Contacto: Serenity.StringEditor;
        TelefonoContacto: Serenity.StringEditor;
        FaxContacto: Serenity.StringEditor;
        EmailContacto: Serenity.EmailEditor;
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
        ClienteBavel: Serenity.StringEditor;
        DingusExtras: Serenity.BooleanEditor;
    }

    [['Razon', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.LookupEditor], ['AgenciaId', () => Serenity.LookupEditor], ['ClienteDefecto', () => Serenity.BooleanEditor], ['GrupoClienteId', () => Serenity.LookupEditor], ['TipoDocumentoId', () => Serenity.LookupEditor], ['Nif', () => Serenity.StringEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['NacionId', () => Serenity.LookupEditor], ['ProvinciaId', () => Serenity.LookupEditor], ['CtaContableAnticipo', () => Serenity.StringEditor], ['CtaContable', () => Serenity.StringEditor], ['DptoContable', () => Serenity.StringEditor], ['CtaDepositos', () => Serenity.StringEditor], ['Telefono', () => Serenity.StringEditor], ['Email', () => Serenity.EmailEditor], ['Fax', () => Serenity.StringEditor], ['Contacto', () => Serenity.StringEditor], ['TelefonoContacto', () => Serenity.StringEditor], ['FaxContacto', () => Serenity.StringEditor], ['EmailContacto', () => Serenity.EmailEditor], ['CifFra', () => Serenity.StringEditor], ['DireccionFra', () => Serenity.StringEditor], ['PoblacionFra', () => Serenity.StringEditor], ['ZipFra', () => Serenity.StringEditor], ['NacionIdFactura', () => Serenity.LookupEditor], ['ProvinciaIdFactura', () => Serenity.LookupEditor], ['ClienteFactura', () => Serenity.BooleanEditor], ['PermiteCredito', () => Serenity.BooleanEditor], ['LimiteCredito', () => Serenity.DecimalEditor], ['FacturaAnticipada', () => Serenity.BooleanEditor], ['VencimientoFacturasId', () => Serenity.IntegerEditor], ['ClienteBavel', () => Serenity.StringEditor], ['DingusExtras', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(ClientesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

