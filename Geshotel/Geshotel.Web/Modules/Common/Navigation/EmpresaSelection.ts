namespace Geshotel.Common {
    export class EmpresaSelection extends Serenity.Widget<any> {
        constructor(select: JQuery, currentEmpresa: string) {
            super(select);

            currentEmpresa = Q.coalesce(currentEmpresa, '1');

            this.change(e => {
                $.cookie('EmpresaPreference', select.val(), {
                    path: Q.Config.applicationPath,
                    expires: 365
                });
                window.location.reload(true);
            });

            Q.getLookupAsync<Portal.EmpresasRow>('Portal.Empresas').then(x => {
                if (!Q.any(x.items, z => z.EmpresaId.toString() === currentEmpresa)) {
                    var idx = currentEmpresa.lastIndexOf('-');
                    if (idx >= 0) {
                        currentEmpresa = currentEmpresa.substr(0, idx);
                        if (!Q.any(x.items, y => y.EmpresaId.toString() === currentEmpresa)) {
                            currentEmpresa = '1';
                        }
                    }
                    else {
                        currentEmpresa = '1';
                    }
                }

                for (var l of x.items) {
                    Q.addOption(select, l.EmpresaId.toString(), l.Empresa);
                }

                select.val(currentEmpresa);
            });
        }
    }
}