namespace Geshotel.Administration {
    @Serenity.Decorators.registerFormatter()
    export class EmpresasListFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext) {
            let idList = ctx.value as number[];
            if (!idList || !idList.length)
                return "";

            let byId = Geshotel.Portal.EmpresasRow.getLookup().itemById;

            return idList.map(x => {
                let g = byId[x];
                if (!g)
                    return x.toString();

                return Q.htmlEncode(g.Empresa);
            }).join(", ");
        }
    }
}
