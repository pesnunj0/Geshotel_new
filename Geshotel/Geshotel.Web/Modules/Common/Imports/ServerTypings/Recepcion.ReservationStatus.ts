
namespace Geshotel.Recepcion {
    export enum ReservationStatus {
        ArrivalPending = 1,
        Cancelled = 2,
        CheckedIn = 3,
        CheckedOut = 4,
        Finished = 5
    }
    Serenity.Decorators.registerEnum(ReservationStatus, 'Geshotel.Recepcion.ReservationStatus');
}

