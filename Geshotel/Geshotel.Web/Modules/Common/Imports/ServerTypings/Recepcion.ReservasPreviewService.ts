
namespace Geshotel.Recepcion {
    export namespace ReservasPreviewService {
        export const baseUrl = 'Recepcion/ReservasPreview';

        export declare function List(request: ReservasPreviewListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasPreviewItem>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export namespace Methods {
            export declare const List: string;
        }

        ['List'].forEach(x => {
            (<any>ReservasPreviewService)[x] = function (r, s, o) { return Q.serviceRequest(baseUrl + '/' + x, r, s, o); };
            (<any>Methods)[x] = baseUrl + '/' + x;
        });
    }
}

