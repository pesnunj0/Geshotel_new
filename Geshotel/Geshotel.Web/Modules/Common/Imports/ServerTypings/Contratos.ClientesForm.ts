

namespace Geshotel.Contratos {
    export class ClientesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Clientes';
    }

    export interface ClientesForm {
        Razon: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        EmpresaId: Serenity.IntegerEditor;
        AgenciaId: Serenity.IntegerEditor;
        ClienteDefecto: Serenity.BooleanEditor;
        GrupoClienteId: Serenity.IntegerEditor;
        TipoDocumentoId: Serenity.StringEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
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
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        ClienteBavel: Serenity.StringEditor;
        DingusExtras: Serenity.BooleanEditor;
    }

    [['ClienteId', () => Serenity.IntegerEditor], ['Razon', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.IntegerEditor], ['AgenciaId', () => Serenity.IntegerEditor], ['ClienteDefecto', () => Serenity.BooleanEditor], ['GrupoClienteId', () => Serenity.IntegerEditor], ['TipoDocumentoId', () => Serenity.StringEditor], ['Nif', () => Serenity.StringEditor], ['FechaDocumento', () => Serenity.DateEditor], ['Direccion', () => Serenity.StringEditor], ['Poblacion', () => Serenity.StringEditor], ['Zip', () => Serenity.StringEditor], ['NacionId', () => Serenity.IntegerEditor], ['ProvinciaId', () => Serenity.IntegerEditor], ['CtaContableAnticipo', () => Serenity.StringEditor], ['CtaContable', () => Serenity.StringEditor], ['DptoContable', () => Serenity.StringEditor], ['CtaDepositos', () => Serenity.StringEditor], ['Telefono', () => Serenity.StringEditor], ['Email', () => Serenity.StringEditor], ['Fax', () => Serenity.StringEditor], ['Contacto', () => Serenity.StringEditor], ['TelefonoContacto', () => Serenity.StringEditor], ['FaxContacto', () => Serenity.StringEditor], ['EmailContacto', () => Serenity.StringEditor], ['CifFra', () => Serenity.StringEditor], ['DireccionFra', () => Serenity.StringEditor], ['PoblacionFra', () => Serenity.StringEditor], ['ZipFra', () => Serenity.StringEditor], ['NacionIdFactura', () => Serenity.IntegerEditor], ['ProvinciaIdFactura', () => Serenity.IntegerEditor], ['ClienteFactura', () => Serenity.BooleanEditor], ['ClienteHuesped', () => Serenity.BooleanEditor], ['PermiteCredito', () => Serenity.BooleanEditor], ['LimiteCredito', () => Serenity.DecimalEditor], ['FacturaAnticipada', () => Serenity.BooleanEditor], ['VencimientoFacturasId', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor], ['FechaModificacion', () => Serenity.DateEditor], ['ClienteBavel', () => Serenity.StringEditor], ['DingusExtras', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(ClientesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}