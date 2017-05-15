namespace Geshotel.Recepcion {
    export enum ReservationStatus {
        WithErrors = 0,
        ArrivalPending = 1,
        Cancelled = 2,
        CheckedIn = 3,
        PreCheckedOut = 4,
        CheckedOut = 5,
        NoShow = 6
    }
    Serenity.Decorators.registerEnum(ReservationStatus, 'Geshotel.Recepcion.ReservationStatus');
}

