
namespace Geshotel.Recepcion {
    export interface ChangeReservationStatusRequest extends Serenity.ServiceRequest {
        ReservaId?: number;
        NewStatusId?: number;
    }
}

