
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


        constructor() {
            super();

            this.HabitacionesBloqueosGrid = new ReservasHabitacionesBloqueosGrid(this.byId("HabitacionesBloqueosGrid"));
            this.ReservasServiciosGrid = new ReservasServiciosGrid(this.byId("ReservasServiciosGrid"));
            this.ReservasHuespedesGrid = new ReservasHuespedesGrid(this.byId("ReservasHuespedesGrid"));
            this.tabs.on('tabsactivate', (e, i) => {
                this.arrange();
            });
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.HabitacionesBloqueosGrid.reservaID = this.entityId;
            this.HabitacionesBloqueosGrid.tipoBloqueoID = 1;
        }

        protected onSaveSuccess(response: Serenity.SaveResponse): void {

            // check that this is an insert
            if (this.isNew) {
                Q.notifySuccess("Just inserted a Reservation with ID: " + response.EntityId +" Let's Proceed To call function & Reload");

                // Here I should call ClasesGeshotel.Geshotelk on server side.
                
  
          
                // let's load inserted record using Retrieve service
                Recepcion.ReservasService.Retrieve(<any>{
                    EntityId: response.EntityId
                }, resp => {
                    Q.notifyInfo("Looks like you added a new Reservation To: " + resp.Entity.NombreReserva);
                });
            }
        }

        protected updateInterface() {
            super.updateInterface();
        
            var fechaHotel = this.entity.HotelId == null ? null : Portal.HotelesRow.getLookup().itemById[this.entity.HotelId].FechaHotel;
            // Let's try to hide DeleteButton if EstadoReservaId != 0
            // This one seems not working perhaps deleteButton is not yet created
            //this.deleteButton.toggle(this.entity.EstadoReservaId != 0);

            // *********************************************************
            // I only allow to remove a reservation if it has errors
            // otherwise the user has to cancel
            // *********************************************************
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
                this.isNew() || this.entity.EstadoReservaId != 2 || fechaHotel > this.entity.FechaPrevistaLlegada);

            this.toolbar.findButton('check-in-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1);

            this.toolbar.findButton('pre-check-out-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 3 || fechaHotel != this.entity.FechaPrevistaSalida);

            this.toolbar.findButton('no-show-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1 || fechaHotel != this.entity.FechaPrevistaLlegada);
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: 'Cancel',
                cssClass: 'cancel-button',
                icon: 'fa-times text-red',
                onClick: () => {
                    Q.confirm(
                        "Are u sure?",
                        () => {
                            Q.notifySuccess("You clicked YES. Let's proceed!");
                        },
                        {
                            onNo: () => {
                                Q.notifyInfo("You clicked NO. We'll do Nothing?");
                            },
                            onCancel: () => {
                                Q.notifyError("You clicked X. So you were wrong");
                            }
                        });
                }
            });

            buttons.push({
                title: 'Undo Cancel',
                cssClass: 'undo-cancel-button',
                icon: 'fa-times text-red',
                onClick: () => {
                    Q.confirm(
                        "Are u sure?",
                        () => {
                            Q.notifySuccess("You clicked YES. Let's proceed!");
                        },
                        {
                            onNo: () => {
                                Q.notifyInfo("You clicked NO. We'll do Nothing?");
                            },
                            onCancel: () => {
                                Q.notifyError("You clicked X. So you were wrong");
                            }
                        });
                }
            });

            buttons.push({
                title: 'Checkin',
                cssClass: 'check-in-button',
                icon: 'fa-chevron-circle-right text-green',
                onClick: () => {
                    Q.confirm(
                        "Are u sure?",
                        () => {
                            Q.notifySuccess("You clicked YES. Let's proceed!");
                        },
                        {
                            onNo: () => {
                                Q.notifyInfo("You clicked NO. We'll do Nothing?");
                            },
                            onCancel: () => {
                                Q.notifyError("You clicked X. So you were wrong");
                            }
                        });
                }
            });

            buttons.push({
                title: 'Pre Checkout',
                cssClass: 'pre-check-out-button',
                icon: 'fa-chevron-circle-left text-blue',
                onClick: () => {
                    Q.confirm(
                        "Are u sure?",
                        () => {
                            Q.notifySuccess("You clicked YES. Let's proceed!");
                        },
                        {
                            onNo: () => {
                                Q.notifyInfo("You clicked NO. We'll do Nothing?");
                            },
                            onCancel: () => {
                                Q.notifyError("You clicked X. So you were wrong");
                            }
                        });
                }
            });

            buttons.push({
                title: 'No Show',
                cssClass: 'no-show-button',
                icon: 'fa-hand-o-down text-maroon',
                onClick: () => {
                    Q.confirm(
                        "Are u sure?",
                        () => {
                            Q.notifySuccess("You clicked YES. Let's proceed!");
                        },
                        {
                            onNo: () => {
                                Q.notifyInfo("You clicked NO. We'll do Nothing?");
                            },
                            onCancel: () => {
                                Q.notifyError("You clicked X. So you were wrong");
                            }
                        });
                }
            });

            return buttons;
        }
    }
}