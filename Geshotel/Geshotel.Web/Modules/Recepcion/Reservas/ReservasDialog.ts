
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()

    export class ReservasDialog extends Serenity.EntityDialog<ReservasRow, any> {
        protected getFormKey() { return ReservasForm.formKey; }
        protected getIdProperty() { return ReservasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasRow.localTextPrefix; }
        protected getNameProperty() { return ReservasRow.nameProperty; }
        protected getService() { return ReservasService.baseUrl; }

        protected form = new ReservasForm(this.idPrefix);

        private HabitacionesBloqueosGrid: ReservasHabitacionesBloqueosGrid;
        private ReservasServiciosGrid: ReservasServiciosGrid;
        private ReservasHuespedesGrid: ReservasHuespedesGrid;
        private ReservasContratosGrid: ReservasContratosGrid;
        private ReservasDescuentosGrid: ReservasDescuentosGrid;
        private ReservasOfertasGrid: ReservasOfertasGrid;
        private ReservasPreviewGrid: ReservasPreviewGrid;
        private ReservasExtrasGrid: ReservasExtrasGrid;
//        private ReservasFacturasGrid: ReservasFacturasGrid;


        constructor() {
            super();

            this.HabitacionesBloqueosGrid = new ReservasHabitacionesBloqueosGrid(this.byId("HabitacionesBloqueosGrid"));
            this.ReservasServiciosGrid = new ReservasServiciosGrid(this.byId("ReservasServiciosGrid"));
            this.ReservasHuespedesGrid = new ReservasHuespedesGrid(this.byId("ReservasHuespedesGrid"));
            this.ReservasContratosGrid = new ReservasContratosGrid(this.byId("ReservasContratosGrid"));
            this.ReservasOfertasGrid = new ReservasOfertasGrid(this.byId("ReservasOfertasGrid"));
            this.ReservasDescuentosGrid = new ReservasDescuentosGrid(this.byId("ReservasDescuentosGrid"));
            this.ReservasPreviewGrid = new ReservasPreviewGrid(this.byId("ReservasPreviewGrid"));
            this.ReservasExtrasGrid = new ReservasExtrasGrid(this.byId("ReservasExtrasGrid"));
         //   this.ReservasFacturasGrid = new ReservasFacturasGrid(this.byId("ReservasFacturasGrid"));

            this.form.EmpresaId.change(e => this.ReservasHuespedesGrid.empresaID = Q.toId(this.form.EmpresaId));
            this.tabs.on('tabsactivate', (e, i) => {
                this.arrange();
            });
        }

        protected afterLoadEntity() {

            super.afterLoadEntity();

            this.HabitacionesBloqueosGrid.reservaID = this.entityId;
            this.HabitacionesBloqueosGrid.tipoBloqueoID = 1;
            this.ReservasServiciosGrid.reservaID = this.entityId;
            this.ReservasServiciosGrid.flagcontrato = 1;
            this.ReservasContratosGrid.reservaID = this.entityId;
            this.ReservasOfertasGrid.reservaID = this.entityId;
            this.ReservasHuespedesGrid.reservaID = this.entityId;
            this.ReservasHuespedesGrid.empresaID = this.entity.EmpresaId;
            this.ReservasDescuentosGrid.reservaID = this.entityId;
            this.ReservasPreviewGrid.reservaID = this.entityId;
            this.ReservasExtrasGrid.reservaID = this.entityId;
        }

        protected onSaveSuccess(response: Serenity.SaveResponse): void {

            // check that this is an insert
            if (this.isNew) {
                Q.notifySuccess("New Reservation with ID: " + response.EntityId + " Let's Proceed To Check, Calculate import & Reload");
                Recepcion.ReservasService.Retrieve(<any>{
                    EntityId: response.EntityId
                }, resp => {
                    Q.notifyInfo("Looks like you added a new Reservation To: " + resp.Entity.NombreReserva);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasServiciosGrid.element);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasContratosGrid.element);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasOfertasGrid.element);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasPreviewGrid.element);
                });
            } else {
                Q.notifySuccess("Just Modified Reservation with ID: " + response.EntityId + " Let's Proceed To Check, recalculate  & Reload");
                // let's load inserted record using Retrieve service
                Recepcion.ReservasService.Retrieve(<any>{
                    EntityId: response.EntityId
                }, resp => {
                    Q.notifyInfo("Looks like you Updated Reservation To: " + resp.Entity.NombreReserva);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasServiciosGrid.element);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasContratosGrid.element);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasOfertasGrid.element);
                    Serenity.SubDialogHelper.triggerDataChange(this.ReservasPreviewGrid.element);
                });
            }
        }

        protected updateInterface() {
            super.updateInterface();
        
            var fechaHotel = this.entity.HotelId == null ? null : Portal.HotelesRow.getLookup().itemById[this.entity.HotelId].FechaHotel;
            // Let's try to hide DeleteButton if EstadoReservaId != 0
            // This one seems not working perhaps deleteButton is not yet created
            //this.deleteButton.toggle(this.entity.EstadoReservaId != 0);

            // ****************************************************************
            // I only allow to remove a reservation if it has errors
            // otherwise the user has to change to status cancelled
            // ****************************************************************
            if (this.entity.EstadoReservaId != 0)
                this.deleteButton.hide();

            // Reservation with status pre-checkOut or Checked-Out
            // Can´t be changed
            if (this.entity.EstadoReservaId > 3) {
                this.applyChangesButton.hide();
                this.saveAndCloseButton.hide();
            }

            this.toolbar.findButton('cancel-button').toggle(this.entity.EstadoReservaId != 2);
            this.toolbar.findButton('cancel-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1);
            this.toolbar.findButton('undo-cancel-button').toggle(this.entity.EstadoReservaId == 2);
            this.toolbar.findButton('undo-cancel-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 2 || Q.formatDate(fechaHotel, 'yyyy-MM-dd') > Q.formatDate(this.entity.FechaPrevistaLlegada, 'yyyy-MM-dd'));

            this.toolbar.findButton('check-in-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1 || Q.formatDate(fechaHotel, 'yyyy-MM-dd') != Q.formatDate(this.entity.FechaPrevistaLlegada, 'yyyy-MM-dd'));
            this.toolbar.findButton('pre-check-out-button').toggle(this.entity.EstadoReservaId < 3);
            this.toolbar.findButton('pre-check-out-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 3 || Q.formatDate(fechaHotel, 'yyyy-MM-dd') != Q.formatDate(this.entity.FechaPrevistaSalida, 'yyyy-MM-dd'));

            this.toolbar.findButton('checked-out-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 4 || Q.formatDate(fechaHotel, 'yyyy-MM-dd') != Q.formatDate(this.entity.FechaPrevistaSalida, 'yyyy-MM-dd'));

            this.toolbar.findButton('no-show-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1 || Q.formatDate(fechaHotel, 'yyyy-MM-dd') != Q.formatDate(this.entity.FechaPrevistaLlegada, 'yyyy-MM-dd'));
        }
        
        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: 'Cancel',
                cssClass: 'cancel-button',
                icon: 'fa-times text-red',
                onClick: () => {
                    Q.confirm("Are u sure?", () => {
                        ReservasService.ChangeReservationStatus({
                            ReservaId: this.entityId,
                            NewStatusId: ReservationStatus.Cancelled

                        }, response => {
                            Q.notifySuccess("Reservation Cancelled successfully");
                            this.reloadById();
                            Serenity.SubDialogHelper.triggerDataChange(this);
                            //Serenity.SubDialogHelper.triggerDataChange(this.ReservasServiciosGrid.element);
                            //Serenity.SubDialogHelper.triggerDataChange(this.ReservasContratosGrid.element);
                            //Serenity.SubDialogHelper.triggerDataChange(this.ReservasOfertasGrid.element);
                            //Serenity.SubDialogHelper.triggerDataChange(this.ReservasPreviewGrid.element);
                        });
                    });
                }
            });

            buttons.push({
                title: 'Undo Cancel',
                cssClass: 'undo-cancel-button',
                icon: 'fa-times text-red',
                onClick: () => {
                    Q.confirm("Are u sure?", () => {
                        ReservasService.ChangeReservationStatus({
                            ReservaId: this.entityId,
                            NewStatusId: ReservationStatus.ArrivalPending

                        }, response => {
                            Q.notifySuccess("Reservation in Status Arrival Pending successfully");
                            this.reloadById();
                            Serenity.SubDialogHelper.triggerDataChange(this);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasServiciosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasContratosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasOfertasGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasPreviewGrid.element);
                        });
                    });
                }
            });

            buttons.push({
                title: 'CheckIn',
                cssClass: 'check-in-button',
                icon: 'fa-chevron-circle-right text-green',
                onClick: () => {
                    Q.confirm("Are u sure?", () => {
                        ReservasService.ChangeReservationStatus({
                            ReservaId: this.entityId,
                            NewStatusId: ReservationStatus.CheckedIn

                        }, response => {
                            Q.notifySuccess("Reservation Checked In successfully");
                            this.reloadById();
                            Serenity.SubDialogHelper.triggerDataChange(this);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasServiciosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasContratosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasOfertasGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasPreviewGrid.element);
                        });
                    });
                }
            });

            buttons.push({
                title: 'Pre CheckOut',
                cssClass: 'pre-check-out-button',
                icon: 'fa-chevron-circle-left text-orange',
                onClick: () => {
                    Q.confirm("Are u sure?", () => {
                        ReservasService.ChangeReservationStatus({
                            ReservaId: this.entityId,
                            NewStatusId: ReservationStatus.PreCheckedOut

                        }, response => {
                            Q.notifySuccess("Reservation in Status Pre Check Out successfully");
                            this.reloadById();

                            Serenity.SubDialogHelper.triggerDataChange(this);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasServiciosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasContratosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasOfertasGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasPreviewGrid.element);
                        });
                    });
                }
            });
            buttons.push({
                title: 'CheckedOut',
                cssClass: 'checked-out-button',
                icon: 'icon-plane text-green',
                onClick: () => {
                    Q.confirm("Are u sure?", () => {
                        ReservasService.ChangeReservationStatus({
                            ReservaId: this.entityId,
                            NewStatusId: ReservationStatus.CheckedOut

                        }, response => {
                            Q.notifySuccess("Reservation in Status Checked Out successfully");
                            this.reloadById();
                            Serenity.SubDialogHelper.triggerDataChange(this);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasServiciosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasContratosGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasOfertasGrid.element);
                            Serenity.SubDialogHelper.triggerDataChange(this.ReservasPreviewGrid.element);
                        });
                    });
                }
            });
            buttons.push({
                title: 'No Show',
                cssClass: 'no-show-button',
                icon: 'fa-hand-o-down text-maroon',
                onClick: () => {
                    Q.confirm("Are u sure?", () => {
                        ReservasService.ChangeReservationStatus({
                            ReservaId: this.entityId,
                            NewStatusId: ReservationStatus.NoShow

                        }, response => {
                            Q.notifySuccess("Reservation in Status No Show successfully");
                            this.reloadById();
                            Serenity.SubDialogHelper.triggerDataChange(this);
                        });
                    });
                }
            });

            return buttons;
        }
    }
}