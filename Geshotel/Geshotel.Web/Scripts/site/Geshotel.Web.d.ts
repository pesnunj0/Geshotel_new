﻿declare namespace Geshotel.Portal {
    class UnidadesCalculoDialog extends Serenity.EntityDialog<UnidadesCalculoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: UnidadesCalculoForm;
    }
}
declare namespace Geshotel.Portal {
    class UnidadesCalculoGrid extends Serenity.EntityGrid<UnidadesCalculoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UnidadesCalculoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposUnidadCalculoDialog extends Serenity.EntityDialog<TiposUnidadCalculoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposUnidadCalculoForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposUnidadCalculoGrid extends Serenity.EntityGrid<TiposUnidadCalculoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposUnidadCalculoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposServicioDialog extends Serenity.EntityDialog<TiposServicioRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposServicioForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposServicioGrid extends Serenity.EntityGrid<TiposServicioRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposServicioDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposHuespedDialog extends Serenity.EntityDialog<TiposHuespedRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposHuespedForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposHuespedGrid extends Serenity.EntityGrid<TiposHuespedRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposHuespedDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposHotelDialog extends Serenity.EntityDialog<TiposHotelRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposHotelForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposHotelGrid extends Serenity.EntityGrid<TiposHotelRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposHotelDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposHabitacionDialog extends Serenity.EntityDialog<TiposHabitacionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposHabitacionForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposHabitacionGrid extends Serenity.EntityGrid<TiposHabitacionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposHabitacionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class ServiciosDialog extends Serenity.EntityDialog<ServiciosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ServiciosForm;
    }
}
declare namespace Geshotel.Portal {
    class ServiciosGrid extends Serenity.EntityGrid<ServiciosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServiciosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class ProvinciasDialog extends Serenity.EntityDialog<ProvinciasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ProvinciasForm;
    }
}
declare namespace Geshotel.Portal {
    class ProvinciasGrid extends Serenity.EntityGrid<ProvinciasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ProvinciasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class NacionesDialog extends Serenity.EntityDialog<NacionesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: NacionesForm;
    }
}
declare namespace Geshotel.Portal {
    class NacionesGrid extends Serenity.EntityGrid<NacionesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof NacionesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class MonedasDialog extends Serenity.EntityDialog<MonedasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MonedasForm;
    }
}
declare namespace Geshotel.Portal {
    class MonedasGrid extends Serenity.EntityGrid<MonedasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MonedasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class HotelesDialog extends Serenity.EntityDialog<HotelesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: HotelesForm;
    }
}
declare namespace Geshotel.Portal {
    class HotelesGrid extends Serenity.EntityGrid<HotelesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof HotelesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class GruposHabitacionDialog extends Serenity.EntityDialog<GruposHabitacionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: GruposHabitacionForm;
    }
}
declare namespace Geshotel.Portal {
    class GruposHabitacionGrid extends Serenity.EntityGrid<GruposHabitacionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof GruposHabitacionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class GruposDeServiciosDialog extends Serenity.EntityDialog<GruposDeServiciosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: GruposDeServiciosForm;
    }
}
declare namespace Geshotel.Portal {
    class GruposDeServiciosGrid extends Serenity.EntityGrid<GruposDeServiciosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof GruposDeServiciosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class FormasDePagoDialog extends Serenity.EntityDialog<FormasDePagoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: FormasDePagoForm;
    }
}
declare namespace Geshotel.Portal {
    class FormasDePagoGrid extends Serenity.EntityGrid<FormasDePagoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof FormasDePagoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class EmpresasDialog extends Serenity.EntityDialog<EmpresasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: EmpresasForm;
    }
}
declare namespace Geshotel.Portal {
    class EmpresasGrid extends Serenity.EntityGrid<EmpresasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof EmpresasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class ComunidadesAutonomasDialog extends Serenity.EntityDialog<ComunidadesAutonomasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ComunidadesAutonomasForm;
    }
}
declare namespace Geshotel.Portal {
    class ComunidadesAutonomasGrid extends Serenity.EntityGrid<ComunidadesAutonomasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ComunidadesAutonomasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Portal {
    class CategoriaHotelesDialog extends Serenity.EntityDialog<CategoriaHotelesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CategoriaHotelesForm;
    }
}
declare namespace Geshotel.Portal {
    class CategoriaHotelesGrid extends Serenity.EntityGrid<CategoriaHotelesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof CategoriaHotelesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Organization {
    class ContactDialog extends Serenity.EntityDialog<ContactRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ContactForm;
    }
}
declare namespace Geshotel.Organization {
    class ContactGrid extends Serenity.EntityGrid<ContactRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ContactDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Organization {
    class BusinessUnitDialog extends Serenity.EntityDialog<BusinessUnitRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: BusinessUnitForm;
    }
}
declare namespace Geshotel.Organization {
    class BusinessUnitEditor extends Serenity.LookupEditorBase<BusinessUnitRow, any> {
        constructor(hidden: JQuery);
        protected getLookupKey(): string;
        protected getItemText(item: BusinessUnitRow, lookup: Q.Lookup<BusinessUnitRow>): string;
    }
}
declare namespace Geshotel.Organization {
    class BusinessUnitGrid extends Serenity.EntityGrid<BusinessUnitRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BusinessUnitDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected subDialogDataChange(): void;
        protected usePager(): boolean;
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace Geshotel.Northwind {
    class TerritoryDialog extends Serenity.EntityDialog<TerritoryRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TerritoryForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Geshotel.Northwind {
    class TerritoryGrid extends Serenity.EntityGrid<TerritoryRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Northwind {
    class SupplierDialog extends Serenity.EntityDialog<SupplierRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: SupplierForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Geshotel.Northwind {
    class SupplierGrid extends Serenity.EntityGrid<SupplierRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Northwind {
    class ShipperDialog extends Serenity.EntityDialog<ShipperRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ShipperForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Geshotel.Northwind {
    class ShipperFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace Geshotel.Northwind {
    class ShipperGrid extends Serenity.EntityGrid<ShipperRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Northwind {
    class PhoneEditor extends Serenity.StringEditor {
        constructor(input: JQuery);
        protected formatValue(): void;
        protected getFormattedValue(): string;
        multiple: boolean;
        get_value(): string;
        set_value(value: string): void;
        static validate(phone: string, isMultiple: boolean): string;
        static isValidPhone(phone: string): boolean;
        static formatPhone(phone: any): any;
        static formatMulti(phone: string, format: (s: string) => string): string;
        static isValidMulti(phone: string, check: (s: string) => boolean): boolean;
    }
}
declare namespace Geshotel.Northwind {
    class RegionDialog extends Serenity.EntityDialog<RegionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: RegionForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Geshotel.Northwind {
    class RegionGrid extends Serenity.EntityGrid<RegionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Northwind {
    class ProductDialog extends Serenity.EntityDialog<ProductRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ProductForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Geshotel.Northwind {
    class ProductGrid extends Serenity.EntityGrid<ProductRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private pendingChanges;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
        protected onViewProcessData(response: any): Serenity.ListResponse<ProductRow>;
        /**
         * It would be nice if we could use autonumeric, Serenity editors etc. here, to control input validation,
         * but it's not supported by SlickGrid as we are only allowed to return a string, and should attach
         * no event handlers to rendered cell contents
         */
        private numericInputFormatter(ctx);
        private stringInputFormatter(ctx);
        /**
         * Sorry but you cannot use LookupEditor, e.g. Select2 here, only possible is a SELECT element
         */
        private selectFormatter(ctx, idField, lookup);
        private getEffectiveValue(item, field);
        protected getColumns(): Slick.Column[];
        private inputsChange(e);
        private setSaveButtonState();
        private saveClick();
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Geshotel.Common {
    class GridEditorDialog<TEntity> extends Serenity.EntityDialog<TEntity, any> {
        protected getIdProperty(): string;
        onSave: (options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void) => void;
        onDelete: (options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void) => void;
        destroy(): void;
        protected updateInterface(): void;
        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void): void;
        protected deleteHandler(options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void): void;
    }
}
declare namespace Geshotel.Northwind {
    class OrderDetailDialog extends Common.GridEditorDialog<OrderDetailRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: OrderDetailForm;
        constructor();
    }
}
declare namespace Geshotel.Common {
    class GridEditorBase<TEntity> extends Serenity.EntityGrid<TEntity, any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        protected getIdProperty(): string;
        protected nextId: number;
        constructor(container: JQuery);
        protected id(entity: TEntity): any;
        protected getNextId(): string;
        protected setNewId(entity: TEntity): void;
        protected save(opt: Serenity.ServiceOptions<any>, callback: (r: Serenity.ServiceResponse) => void): void;
        protected deleteEntity(id: number): boolean;
        protected validateEntity(row: TEntity, id: number): boolean;
        protected setEntities(items: TEntity[]): void;
        protected getNewEntity(): TEntity;
        protected getButtons(): Serenity.ToolButton[];
        protected editItem(entityOrId: any): void;
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        value: TEntity[];
        protected getGridCanLoad(): boolean;
        protected usePager(): boolean;
        protected getInitialTitle(): any;
        protected createQuickSearchInput(): void;
    }
}
declare namespace Geshotel.Northwind {
    class OrderDetailsEditor extends Common.GridEditorBase<OrderDetailRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof OrderDetailDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Geshotel.Northwind {
    class FreightFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace Geshotel.Common {
    class BulkServiceAction {
        protected keys: string[];
        protected queue: string[];
        protected queueIndex: number;
        protected progressDialog: BasicProgressDialog;
        protected pendingRequests: number;
        protected completedRequests: number;
        protected errorByKey: Q.Dictionary<Serenity.ServiceError>;
        private successCount;
        private errorCount;
        done: () => void;
        protected createProgressDialog(): void;
        protected getConfirmationFormat(): string;
        protected getConfirmationMessage(targetCount: any): string;
        protected confirm(targetCount: any, action: any): void;
        protected getNothingToProcessMessage(): string;
        protected nothingToProcess(): void;
        protected getParallelRequests(): number;
        protected getBatchSize(): number;
        protected startParallelExecution(): void;
        protected serviceCallCleanup(): void;
        protected executeForBatch(batch: string[]): void;
        protected executeNextBatch(): void;
        protected getAllHadErrorsFormat(): string;
        protected showAllHadErrors(): void;
        protected getSomeHadErrorsFormat(): string;
        protected showSomeHadErrors(): void;
        protected getAllSuccessFormat(): string;
        protected showAllSuccess(): void;
        protected showResults(): void;
        execute(keys: string[]): void;
        get_successCount(): any;
        set_successCount(value: number): void;
        get_errorCount(): any;
        set_errorCount(value: number): void;
    }
}
declare namespace Geshotel.BasicSamples {
    class OrderBulkAction extends Common.BulkServiceAction {
        /**
         * This controls how many service requests will be used in parallel.
         * Determine this number based on how many requests your server
         * might be able to handle, and amount of wait on external resources.
         */
        protected getParallelRequests(): number;
        /**
         * These number of records IDs will be sent to your service in one
         * service call. If your service is designed to handle one record only,
         * set it to 1. But note that, if you have 5000 records, this will
         * result in 5000 service calls / requests.
         */
        protected getBatchSize(): number;
        /**
         * This is where you should call your service.
         * Batch parameter contains the selected order IDs
         * that should be processed in this service call.
         */
        protected executeForBatch(batch: any): void;
    }
}
declare namespace Geshotel.Northwind {
    class OrderDialog extends Serenity.EntityDialog<OrderRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: OrderForm;
        constructor();
        getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
    }
}
declare namespace Geshotel.Northwind {
    class OrderGrid extends Serenity.EntityGrid<OrderRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected shippingStateFilter: Serenity.EnumEditor;
        constructor(container: JQuery);
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected createQuickFilters(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        set_shippingState(value: number): void;
    }
}
declare namespace Geshotel.Northwind {
    class NoteDialog extends Serenity.TemplatedDialog<any> {
        private textEditor;
        constructor();
        protected getTemplate(): string;
        protected getDialogOptions(): JQueryUI.DialogOptions;
        text: string;
        okClick: () => void;
    }
}
declare namespace Geshotel.Northwind {
    class NotesEditor extends Serenity.TemplatedWidget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        private isDirty;
        private items;
        constructor(div: JQuery);
        protected getTemplate(): string;
        protected updateContent(): void;
        protected addClick(): void;
        protected editClick(e: any): void;
        deleteClick(e: any): void;
        value: NoteRow[];
        getEditValue(prop: Serenity.PropertyItem, target: any): void;
        setEditValue(source: any, prop: Serenity.PropertyItem): void;
        get_isDirty(): boolean;
        set_isDirty(value: any): void;
        onChange: () => void;
    }
}
declare namespace Geshotel.Northwind {
    class EmployeeFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
        genderProperty: string;
        initializeColumn(column: Slick.Column): void;
    }
}
declare namespace Geshotel.Northwind {
    class CustomerDialog extends Serenity.EntityDialog<CustomerRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CustomerForm;
        private ordersGrid;
        private loadedState;
        constructor();
        getSaveState(): string;
        loadResponse(data: any): void;
        loadEntity(entity: CustomerRow): void;
        onSaveSuccess(response: any): void;
    }
}
declare namespace Geshotel.Northwind {
    class CustomerEditor extends Serenity.LookupEditorBase<CustomerRow, any> {
        constructor(hidden: JQuery);
        protected getLookupKey(): string;
        protected getItemText(item: any, lookup: any): string;
    }
}
declare namespace Geshotel.Northwind {
    class CustomerGrid extends Serenity.EntityGrid<CustomerRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Northwind {
    class CustomerOrderDialog extends OrderDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Geshotel.Northwind {
    class CustomerOrdersGrid extends OrderGrid {
        protected getDialogType(): typeof CustomerOrderDialog;
        constructor(container: JQuery);
        protected getColumns(): Slick.Column[];
        protected initEntityDialog(itemType: any, dialog: any): void;
        protected addButtonClick(): void;
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _customerID;
        customerID: string;
    }
}
declare namespace Geshotel.Northwind {
    class EmployeeListFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace Geshotel.Northwind {
    class CategoryDialog extends Serenity.EntityDialog<CategoryRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CategoryForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Geshotel.Northwind {
    class CategoryGrid extends Serenity.EntityGrid<CategoryRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Membership {
    class LoginPanel extends Serenity.PropertyPanel<LoginRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Membership {
    class SignUpPanel extends Serenity.PropertyPanel<SignUpRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Membership {
    class ResetPasswordPanel extends Serenity.PropertyPanel<ResetPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Membership {
    class ForgotPasswordPanel extends Serenity.PropertyPanel<ForgotPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Membership {
    class ChangePasswordPanel extends Serenity.PropertyPanel<ChangePasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Meeting {
    class MeetingTypeDialog extends Serenity.EntityDialog<MeetingTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MeetingTypeForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingTypeGrid extends Serenity.EntityGrid<MeetingTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Meeting {
    class MeetingLocationDialog extends Serenity.EntityDialog<MeetingLocationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MeetingLocationForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingLocationGrid extends Serenity.EntityGrid<MeetingLocationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingLocationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Meeting {
    class MeetingDecisionRelevantDialog extends Serenity.EntityDialog<MeetingDecisionRelevantRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: MeetingDecisionRelevantForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingDecisionRelevantGrid extends Serenity.EntityGrid<MeetingDecisionRelevantRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingDecisionRelevantDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Meeting {
    class MeetingDecisionDialog extends Serenity.EntityDialog<MeetingDecisionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MeetingDecisionForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingDecisionGrid extends Serenity.EntityGrid<MeetingDecisionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingDecisionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected addButtonClick(): void;
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _meetingId;
        meetingId: string;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAttendeeDialog extends Common.GridEditorDialog<MeetingAttendeeRow> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected form: MeetingAttendeeForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAttendeeEditor extends Common.GridEditorBase<MeetingAttendeeRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingAttendeeDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        protected getButtons(): any[];
        protected createToolbarExtensions(): void;
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaTypeDialog extends Serenity.EntityDialog<MeetingAgendaTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MeetingAgendaTypeForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaTypeGrid extends Serenity.EntityGrid<MeetingAgendaTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingAgendaTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaRelevantDialog extends Serenity.EntityDialog<MeetingAgendaRelevantRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: MeetingAgendaRelevantForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaRelevantGrid extends Serenity.EntityGrid<MeetingAgendaRelevantRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingAgendaRelevantDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaDialog extends Serenity.EntityDialog<MeetingAgendaRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MeetingAgendaForm;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaGrid extends Serenity.EntityGrid<MeetingAgendaRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingAgendaDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected addButtonClick(): void;
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _meetingId;
        meetingId: string;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingDialog extends Serenity.EntityDialog<MeetingRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MeetingForm;
        private agendaGrid;
        private decisionGrid;
        constructor();
        protected arrange(): void;
        loadEntity(entity: MeetingRow): void;
    }
}
declare namespace Geshotel.Meeting {
    class MeetingGrid extends Serenity.EntityGrid<MeetingRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MeetingDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class LineasDeContratoDialog extends Serenity.EntityDialog<LineasDeContratoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: LineasDeContratoForm;
    }
}
declare namespace Geshotel.Contratos {
    class LineasDeContratoGrid extends Serenity.EntityGrid<LineasDeContratoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LineasDeContratoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class ClientesDialog extends Serenity.EntityDialog<ClientesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ClientesForm;
    }
}
declare namespace Geshotel.Contratos {
    class ClientesGrid extends Serenity.EntityGrid<ClientesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ClientesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.ScriptInitialization {
}
declare namespace Geshotel.Common {
    class UserPreferenceStorage implements Serenity.SettingStorage {
        getItem(key: string): string;
        setItem(key: string, data: string): void;
    }
}
declare var jsPDF: any;
declare namespace Geshotel.Common {
    interface PdfExportOptions {
        grid: Serenity.DataGrid<any, any>;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
        reportTitle?: string;
        titleTop?: number;
        titleFontSize?: number;
        fileName?: string;
        pageNumbers?: boolean;
        columnTitles?: {
            [key: string]: string;
        };
        tableOptions?: jsPDF.AutoTableOptions;
        output?: string;
        autoPrint?: boolean;
    }
    namespace PdfExportHelper {
        function exportToPdf(options: PdfExportOptions): void;
        function createToolButton(options: PdfExportOptions): Serenity.ToolButton;
    }
}
declare var jsPDF: any;
declare namespace Geshotel.Common {
    class ReportDialog extends Serenity.TemplatedDialog<ReportDialogOptions> {
        private report;
        private propertyItems;
        private propertyGrid;
        constructor(options: ReportDialogOptions);
        protected getDialogButtons(): any;
        protected createPropertyGrid(): void;
        protected loadReport(reportKey: string): void;
        protected updateInterface(): void;
        executeReport(target: string, ext: string, download: boolean): void;
        getToolbarButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
    }
    interface ReportDialogOptions {
        reportKey: string;
    }
}
declare namespace Geshotel.Common {
    interface ReportExecuteOptions {
        reportKey: string;
        download?: boolean;
        extension?: 'pdf' | 'htm' | 'html' | 'xlsx' | 'docx';
        getParams?: () => any;
        params?: {
            [key: string]: any;
        };
        target?: string;
    }
    interface ReportButtonOptions extends ReportExecuteOptions {
        title?: string;
        cssClass?: string;
        icon?: string;
    }
    namespace ReportHelper {
        function createToolButton(options: ReportButtonOptions): Serenity.ToolButton;
        function execute(options: ReportExecuteOptions): void;
    }
}
declare var jsPDF: any;
declare namespace Geshotel.Common {
    class ReportPage extends Serenity.Widget<any> {
        private reportKey;
        private propertyItems;
        private propertyGrid;
        constructor(element: JQuery);
        protected updateMatchFlags(text: string): void;
        protected categoryClick(e: any): void;
        protected reportLinkClick(e: any): void;
    }
}
declare namespace Geshotel.Common {
    class EmpresaSelection extends Serenity.Widget<any> {
        constructor(select: JQuery, currentEmpresa: string);
    }
}
declare namespace Geshotel.Common {
    class LanguageSelection extends Serenity.Widget<any> {
        constructor(select: JQuery, currentLanguage: string);
    }
}
declare namespace Geshotel.Common {
    class SidebarSearch extends Serenity.Widget<any> {
        private menuUL;
        constructor(input: JQuery, menuUL: JQuery);
        protected updateMatchFlags(text: string): void;
    }
}
declare namespace Geshotel.Common {
    class ThemeSelection extends Serenity.Widget<any> {
        constructor(select: JQuery);
        protected getCurrentTheme(): string;
    }
}
declare namespace Geshotel.Administration {
}
declare namespace Geshotel.Administration {
    class LanguageForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface LanguageForm {
        LanguageId: Serenity.StringEditor;
        LanguageName: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Administration {
    interface LanguageRow {
        Id?: number;
        LanguageId?: string;
        LanguageName?: string;
    }
    namespace LanguageRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<LanguageRow>;
        namespace Fields {
            const Id: string;
            const LanguageId: string;
            const LanguageName: string;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace LanguageService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Administration {
}
declare namespace Geshotel.Administration {
    class RoleForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface RoleForm {
        RoleName: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Administration {
    interface RolePermissionListRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace Geshotel.Administration {
    interface RolePermissionListResponse extends Serenity.ListResponse<string> {
    }
}
declare namespace Geshotel.Administration {
    interface RolePermissionRow {
        RolePermissionId?: number;
        RoleId?: number;
        PermissionKey?: string;
        RoleRoleName?: string;
    }
    namespace RolePermissionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const RolePermissionId: string;
            const RoleId: string;
            const PermissionKey: string;
            const RoleRoleName: string;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace RolePermissionService {
        const baseUrl: string;
        function Update(request: RolePermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: RolePermissionListRequest, onSuccess?: (response: RolePermissionListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Administration {
    interface RolePermissionUpdateRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: string[];
    }
}
declare namespace Geshotel.Administration {
    interface RoleRow {
        RoleId?: number;
        RoleName?: string;
    }
    namespace RoleRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<RoleRow>;
        namespace Fields {
            const RoleId: string;
            const RoleName: string;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace RoleService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Administration {
    interface TranslationItem {
        Key?: string;
        SourceText?: string;
        TargetText?: string;
        CustomText?: string;
    }
}
declare namespace Geshotel.Administration {
    interface TranslationListRequest extends Serenity.ListRequest {
        SourceLanguageID?: string;
        TargetLanguageID?: string;
    }
}
declare namespace Geshotel.Administration {
    namespace TranslationService {
        const baseUrl: string;
        function List(request: TranslationListRequest, onSuccess?: (response: Serenity.ListResponse<TranslationItem>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: TranslationUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const List: string;
            const Update: string;
        }
    }
}
declare namespace Geshotel.Administration {
    interface TranslationUpdateRequest extends Serenity.ServiceRequest {
        TargetLanguageID?: string;
        Translations?: {
            [key: string]: string;
        };
    }
}
declare namespace Geshotel.Administration {
}
declare namespace Geshotel.Administration {
    class UserCompanyForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface UserCompanyForm {
        EmpresaId: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Administration {
    interface UserCompanyRow {
        UsuarioId?: number;
        EmpresaId?: number;
    }
    namespace UserCompanyRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UsuarioId: any;
            const EmpresaId: any;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace UserCompanyService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<UserCompanyRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserCompanyRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserCompanyRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserCompanyRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Administration {
    class UserForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface UserForm {
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        Email: Serenity.EmailEditor;
        UserImage: Serenity.ImageUploadEditor;
        Password: Serenity.PasswordEditor;
        PasswordConfirm: Serenity.PasswordEditor;
        Source: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Administration {
    interface UserPermissionListRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace Geshotel.Administration {
    interface UserPermissionRow {
        UserPermissionId?: number;
        UserId?: number;
        PermissionKey?: string;
        Granted?: boolean;
        Username?: string;
        User?: string;
    }
    namespace UserPermissionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserPermissionId: string;
            const UserId: string;
            const PermissionKey: string;
            const Granted: string;
            const Username: string;
            const User: string;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace UserPermissionService {
        const baseUrl: string;
        function Update(request: UserPermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<UserPermissionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListRolePermissions(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListPermissionKeys(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const List: string;
            const ListRolePermissions: string;
            const ListPermissionKeys: string;
        }
    }
}
declare namespace Geshotel.Administration {
    interface UserPermissionUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: UserPermissionRow[];
    }
}
declare namespace Geshotel.Administration {
    interface UserRoleListRequest extends Serenity.ServiceRequest {
        UserID?: number;
    }
}
declare namespace Geshotel.Administration {
    interface UserRoleListResponse extends Serenity.ListResponse<number> {
    }
}
declare namespace Geshotel.Administration {
    interface UserRoleRow {
        UserRoleId?: number;
        UserId?: number;
        RoleId?: number;
        Username?: string;
        User?: string;
    }
    namespace UserRoleRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserRoleId: string;
            const UserId: string;
            const RoleId: string;
            const Username: string;
            const User: string;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace UserRoleService {
        const baseUrl: string;
        function Update(request: UserRoleUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserRoleListRequest, onSuccess?: (response: UserRoleListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Administration {
    interface UserRoleUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Roles?: number[];
    }
}
declare namespace Geshotel.Administration {
    interface UserRow {
        UserId?: number;
        Username?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        DisplayName?: string;
        Email?: string;
        UserImage?: string;
        LastDirectoryUpdate?: string;
        IsActive?: number;
        EmpresaId?: number;
        HotelId?: number;
        Empresa?: string;
        HotelName?: string;
        Password?: string;
        PasswordConfirm?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }
    namespace UserRow {
        const idProperty: string;
        const isActiveProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<UserRow>;
        namespace Fields {
            const UserId: string;
            const Username: string;
            const Source: string;
            const PasswordHash: string;
            const PasswordSalt: string;
            const DisplayName: string;
            const Email: string;
            const UserImage: string;
            const LastDirectoryUpdate: string;
            const IsActive: string;
            const EmpresaId: string;
            const HotelId: string;
            const Empresa: string;
            const HotelName: string;
            const Password: string;
            const PasswordConfirm: string;
            const InsertUserId: string;
            const InsertDate: string;
            const UpdateUserId: string;
            const UpdateDate: string;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace UserService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Undelete(request: Serenity.UndeleteRequest, onSuccess?: (response: Serenity.UndeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Undelete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
    namespace BasicSamplesService {
        const baseUrl: string;
        function OrdersByShipper(request: OrdersByShipperRequest, onSuccess?: (response: OrdersByShipperResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function OrderBulkAction(request: OrderBulkActionRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const OrdersByShipper: string;
            const OrderBulkAction: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
    class ChangingLookupTextForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ChangingLookupTextForm {
        ProductID: ChangingLookupTextEditor;
        UnitPrice: Serenity.DecimalEditor;
        Quantity: Serenity.IntegerEditor;
        Discount: Serenity.DecimalEditor;
    }
}
declare namespace Geshotel.BasicSamples {
}
declare namespace Geshotel.BasicSamples {
    interface CustomerGrossSalesListRequest extends Serenity.ListRequest {
        StartDate?: string;
        EndDate?: string;
    }
}
declare namespace Geshotel.BasicSamples {
    interface CustomerGrossSalesRow {
        CustomerId?: string;
        ContactName?: string;
        ProductId?: number;
        ProductName?: string;
        GrossAmount?: number;
    }
    namespace CustomerGrossSalesRow {
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const CustomerId: string;
            const ContactName: string;
            const ProductId: string;
            const ProductName: string;
            const GrossAmount: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
    namespace CustomerGrossSalesService {
        const baseUrl: string;
        function List(request: CustomerGrossSalesListRequest, onSuccess?: (response: Serenity.ListResponse<CustomerGrossSalesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const List: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
}
declare namespace Geshotel.BasicSamples {
    class DragDropSampleForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface DragDropSampleForm {
        Title: Serenity.StringEditor;
    }
}
declare namespace Geshotel.BasicSamples {
    interface DragDropSampleRow {
        Id?: number;
        ParentId?: number;
        Title?: string;
    }
    namespace DragDropSampleRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const Id: string;
            const ParentId: string;
            const Title: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
    namespace DragDropSampleService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<DragDropSampleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DragDropSampleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DragDropSampleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DragDropSampleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
    class FilteredLookupInDetailForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface FilteredLookupInDetailForm {
        CustomerID: Northwind.CustomerEditor;
        OrderDate: Serenity.DateEditor;
        CategoryID: Serenity.LookupEditor;
        DetailList: FilteredLookupDetailEditor;
    }
}
declare namespace Geshotel.BasicSamples {
    class HardcodedValuesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface HardcodedValuesForm {
        SomeValue: HardcodedValuesEditor;
    }
}
declare namespace Geshotel.BasicSamples {
}
declare namespace Geshotel.BasicSamples {
    class LookupFilterByMultipleForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface LookupFilterByMultipleForm {
        ProductName: Serenity.StringEditor;
        ProductImage: Serenity.ImageUploadEditor;
        Discontinued: Serenity.BooleanEditor;
        SupplierID: Serenity.LookupEditor;
        CategoryID: ProduceSeafoodCategoryEditor;
        QuantityPerUnit: Serenity.StringEditor;
        UnitPrice: Serenity.DecimalEditor;
        UnitsInStock: Serenity.IntegerEditor;
        UnitsOnOrder: Serenity.IntegerEditor;
        ReorderLevel: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.BasicSamples {
    interface OrderBulkActionRequest extends Serenity.ServiceRequest {
        OrderIDs?: number[];
    }
}
declare namespace Geshotel.BasicSamples {
    interface OrdersByShipperRequest extends Serenity.ServiceRequest {
    }
}
declare namespace Geshotel.BasicSamples {
    interface OrdersByShipperResponse extends Serenity.ServiceResponse {
        Values?: {
            [key: string]: any;
        }[];
        ShipperKeys?: string[];
        ShipperLabels?: string[];
    }
}
declare namespace Geshotel.BasicSamples {
    class PopulateLinkedDataForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface PopulateLinkedDataForm {
        CustomerID: Northwind.CustomerEditor;
        CustomerContactName: Serenity.StringEditor;
        CustomerContactTitle: Serenity.StringEditor;
        CustomerCity: Serenity.StringEditor;
        CustomerRegion: Serenity.StringEditor;
        CustomerCountry: Serenity.StringEditor;
        CustomerPhone: Serenity.StringEditor;
        CustomerFax: Serenity.StringEditor;
        OrderDate: Serenity.DateEditor;
        RequiredDate: Serenity.DateEditor;
        EmployeeID: Serenity.LookupEditor;
        DetailList: Northwind.OrderDetailsEditor;
    }
}
declare namespace Geshotel.BasicSamples {
    class ProductExcelImportForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ProductExcelImportForm {
        FileName: Serenity.ImageUploadEditor;
    }
}
declare namespace Geshotel.BasicSamples {
    namespace ProductExcelImportService {
        const baseUrl: string;
        function ExcelImport(request: ExcelImportRequest, onSuccess?: (response: ExcelImportResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const ExcelImport: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
    class StaticTextBlockForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface StaticTextBlockForm {
        StaticText: StaticTextBlock;
        SomeInput: Serenity.StringEditor;
        HtmlList: StaticTextBlock;
        FromLocalText: StaticTextBlock;
        DisplayFieldValue: StaticTextBlock;
    }
}
declare namespace Geshotel.BasicSamples {
}
declare namespace Geshotel.BasicSamples {
    interface VSGalleryQAPost {
        PostId?: number;
        PostedOn?: string;
        PostedByName?: string;
        PostedByUserId?: string;
        Message?: string;
    }
}
declare namespace Geshotel.BasicSamples {
    namespace VSGalleryQAService {
        const baseUrl: string;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VSGalleryQAThread>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const List: string;
        }
    }
}
declare namespace Geshotel.BasicSamples {
    interface VSGalleryQAThread {
        ThreadId?: number;
        Title?: string;
        StartedOn?: string;
        StartedByName?: string;
        StartedByUserId?: string;
        LastPostOn?: string;
        PostCount?: number;
        Posts?: VSGalleryQAPost[];
    }
}
declare namespace Geshotel.Common.Pages {
    interface UploadResponse extends Serenity.ServiceResponse {
        TemporaryFile?: string;
        Size?: number;
        IsImage?: boolean;
        Width?: number;
        Height?: number;
    }
}
declare namespace Geshotel.Common {
    interface UserPreferenceRetrieveRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
    }
}
declare namespace Geshotel.Common {
    interface UserPreferenceRetrieveResponse extends Serenity.ServiceResponse {
        Value?: string;
    }
}
declare namespace Geshotel.Common {
    interface UserPreferenceRow {
        UserPreferenceId?: number;
        UserId?: number;
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
    namespace UserPreferenceRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserPreferenceId: string;
            const UserId: string;
            const PreferenceType: string;
            const Name: string;
            const Value: string;
        }
    }
}
declare namespace Geshotel.Common {
    namespace UserPreferenceService {
        const baseUrl: string;
        function Update(request: UserPreferenceUpdateRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: UserPreferenceRetrieveRequest, onSuccess?: (response: UserPreferenceRetrieveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const Retrieve: string;
        }
    }
}
declare namespace Geshotel.Common {
    interface UserPreferenceUpdateRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
}
declare namespace Geshotel.Contratos {
    class AmbitoOfertaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface AmbitoOfertaForm {
        NombreAmbito: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface AmbitoOfertaRow {
        AmbitoOfertaId?: number;
        Ambito?: string;
    }
    namespace AmbitoOfertaRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<AmbitoOfertaRow>;
        namespace Fields {
            const AmbitoOfertaId: string;
            const Ambito: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace AmbitoOfertaService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<AmbitoOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AmbitoOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AmbitoOfertaRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AmbitoOfertaRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
}
declare namespace Geshotel.Contratos {
    class ClientesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ClientesForm {
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
}
declare namespace Geshotel.Contratos {
    interface ClientesRow {
        ClienteId?: number;
        Razon?: string;
        DescCorta?: string;
        EmpresaId?: number;
        AgenciaId?: number;
        ClienteDefecto?: boolean;
        GrupoClienteId?: number;
        TipoDocumentoId?: string;
        Nif?: string;
        FechaDocumento?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        NacionId?: number;
        ProvinciaId?: number;
        CtaContableAnticipo?: string;
        CtaContable?: string;
        DptoContable?: string;
        CtaDepositos?: string;
        Telefono?: string;
        Email?: string;
        Fax?: string;
        Contacto?: string;
        TelefonoContacto?: string;
        FaxContacto?: string;
        EmailContacto?: string;
        CifFra?: string;
        DireccionFra?: string;
        PoblacionFra?: string;
        ZipFra?: string;
        NacionIdFactura?: number;
        ProvinciaIdFactura?: number;
        ClienteFactura?: boolean;
        ClienteHuesped?: boolean;
        PermiteCredito?: boolean;
        LimiteCredito?: number;
        FacturaAnticipada?: boolean;
        VencimientoFacturasId?: number;
        UserId?: number;
        FechaModificacion?: string;
        ClienteBavel?: string;
        DingusExtras?: boolean;
        Empresa?: string;
        Agencia?: string;
        NombreGrupo?: string;
        Documento?: string;
        Nacion?: string;
        Provincia?: string;
        FacturaNacion?: string;
        FacturaProvincia?: string;
    }
    namespace ClientesRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ClientesRow>;
        namespace Fields {
            const ClienteId: string;
            const Razon: string;
            const DescCorta: string;
            const EmpresaId: string;
            const AgenciaId: string;
            const ClienteDefecto: string;
            const GrupoClienteId: string;
            const TipoDocumentoId: string;
            const Nif: string;
            const FechaDocumento: string;
            const Direccion: string;
            const Poblacion: string;
            const Zip: string;
            const NacionId: string;
            const ProvinciaId: string;
            const CtaContableAnticipo: string;
            const CtaContable: string;
            const DptoContable: string;
            const CtaDepositos: string;
            const Telefono: string;
            const Email: string;
            const Fax: string;
            const Contacto: string;
            const TelefonoContacto: string;
            const FaxContacto: string;
            const EmailContacto: string;
            const CifFra: string;
            const DireccionFra: string;
            const PoblacionFra: string;
            const ZipFra: string;
            const NacionIdFactura: string;
            const ProvinciaIdFactura: string;
            const ClienteFactura: string;
            const ClienteHuesped: string;
            const PermiteCredito: string;
            const LimiteCredito: string;
            const FacturaAnticipada: string;
            const VencimientoFacturasId: string;
            const UserId: string;
            const FechaModificacion: string;
            const ClienteBavel: string;
            const DingusExtras: string;
            const Empresa: string;
            const Agencia: string;
            const NombreGrupo: string;
            const Documento: string;
            const Nacion: string;
            const Provincia: string;
            const FacturaNacion: string;
            const FacturaProvincia: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace ClientesService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ClientesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ClientesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ClientesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ClientesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    class FrecuenciaFacturacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface FrecuenciaFacturacionForm {
        DescripcionCorta: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface FrecuenciaFacturacionRow {
        FrecuenciaId?: number;
        DescripcionCorta?: string;
        Descripcion?: string;
    }
    namespace FrecuenciaFacturacionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const FrecuenciaId: string;
            const DescripcionCorta: string;
            const Descripcion: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace FrecuenciaFacturacionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<FrecuenciaFacturacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<FrecuenciaFacturacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<FrecuenciaFacturacionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<FrecuenciaFacturacionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    class GruposDeClienteForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface GruposDeClienteForm {
        NombreGrupo: Serenity.StringEditor;
        EmpresaId: Serenity.IntegerEditor;
        CtaContable: Serenity.StringEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        Huesped: Serenity.IntegerEditor;
        Contratos: Serenity.IntegerEditor;
        Facturar: Serenity.IntegerEditor;
        Agencia: Serenity.IntegerEditor;
        Perfil: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface GruposDeClienteRow {
        GrupoClienteId?: number;
        NombreGrupo?: string;
        Huesped?: boolean;
        Contratos?: boolean;
        Facturar?: boolean;
        Agencia?: boolean;
        Perfil?: number;
    }
    namespace GruposDeClienteRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<GruposDeClienteRow>;
        namespace Fields {
            const GrupoClienteId: string;
            const NombreGrupo: string;
            const Huesped: string;
            const Contratos: string;
            const Facturar: string;
            const Agencia: string;
            const Perfil: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace GruposDeClienteService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<GruposDeClienteRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<GruposDeClienteRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<GruposDeClienteRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<GruposDeClienteRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
}
declare namespace Geshotel.Contratos {
    class LineasDeContratoForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface LineasDeContratoForm {
        ContratoId: Serenity.IntegerEditor;
        Oferta: Serenity.IntegerEditor;
        Desde: Serenity.DateEditor;
        Hasta: Serenity.DateEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.IntegerEditor;
        FrecuenciaId: Serenity.IntegerEditor;
        TipoImputacionId: Serenity.IntegerEditor;
        Importe: Serenity.DecimalEditor;
        N: Serenity.IntegerEditor;
        TipoOfertaId: Serenity.IntegerEditor;
        M: Serenity.DecimalEditor;
        AmbitoOfertaId: Serenity.IntegerEditor;
        Lunes: Serenity.IntegerEditor;
        Martes: Serenity.BooleanEditor;
        Miercoles: Serenity.BooleanEditor;
        Jueves: Serenity.BooleanEditor;
        Viernes: Serenity.BooleanEditor;
        Sabado: Serenity.BooleanEditor;
        Domingo: Serenity.BooleanEditor;
        PagFactura: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface LineasDeContratoRow {
        LineaContratoId?: number;
        ContratoId?: number;
        Oferta?: number;
        Desde?: string;
        Hasta?: string;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FrecuenciaId?: number;
        TipoImputacionId?: number;
        Importe?: number;
        N?: number;
        TipoOfertaId?: number;
        M?: number;
        AmbitoOfertaId?: number;
        Lunes?: number;
        Martes?: boolean;
        Miercoles?: boolean;
        Jueves?: boolean;
        Viernes?: boolean;
        Sabado?: boolean;
        Domingo?: boolean;
        PagFactura?: number;
        UserId?: number;
        FechaModificacion?: string;
        ContratoHotelId?: number;
        ContratoClienteId?: number;
        ContratoFechaContrato?: string;
        ContratoFechaDesde?: string;
        ContratoFechaHasta?: string;
        ContratoContratoIdOriginal?: number;
        ContratoContratoIdSiguiente?: number;
        ContratoNumeroContratoCliente?: string;
        ContratoUserId?: number;
        ContratoFechaModificacion?: string;
        ContratoTemporadaId?: number;
        ContratoImpuestoIncluido?: number;
        ContratoMercadoId?: number;
        ContratoClienteIdPadre?: number;
        ServicioNombreServicio?: string;
        ServicioAbreviatura?: string;
        ServicioTipoServicioId?: number;
        ServicioSwProduccion?: boolean;
        ServicioSwDescuento?: boolean;
        ServicioSwAjustes?: boolean;
        ServicioSwGastos?: boolean;
        ServicioSwPension?: boolean;
        ServicioSwRectificativa?: boolean;
        ServicioTipoUnidadCalculoId?: number;
        ServicioConceptoAceleradorReservasId?: number;
        ServicioCosto?: number;
        ServicioSumaServicioId?: number;
        ServicioRestaServicioId?: number;
        ServicioUserId?: number;
        ServicioFechaModificacion?: string;
        ServicioTipoHab?: number;
        ServicioTipoPension?: number;
        UnidadCalculoUc?: string;
        UnidadCalculoDescripcionUnidadCalculo?: string;
        UnidadCalculoTipoUnidadCalculoId?: number;
        UnidadCalculoPax?: boolean;
        UnidadCalculoServicioId?: number;
        UnidadCalculoUserId?: number;
        UnidadCalculoFechaModificacion?: string;
        TipoOfertaOferta?: string;
        TipoOfertaPermitirMMayorQueN?: number;
        TipoOfertaRejilla?: number;
        TipoOfertaObservaciones?: string;
        TipoOfertaOrdenAplicacion?: number;
    }
    namespace LineasDeContratoRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const LineaContratoId: string;
            const ContratoId: string;
            const Oferta: string;
            const Desde: string;
            const Hasta: string;
            const ServicioId: string;
            const UnidadCalculoId: string;
            const FrecuenciaId: string;
            const TipoImputacionId: string;
            const Importe: string;
            const N: string;
            const TipoOfertaId: string;
            const M: string;
            const AmbitoOfertaId: string;
            const Lunes: string;
            const Martes: string;
            const Miercoles: string;
            const Jueves: string;
            const Viernes: string;
            const Sabado: string;
            const Domingo: string;
            const PagFactura: string;
            const UserId: string;
            const FechaModificacion: string;
            const ContratoHotelId: string;
            const ContratoClienteId: string;
            const ContratoFechaContrato: string;
            const ContratoFechaDesde: string;
            const ContratoFechaHasta: string;
            const ContratoContratoIdOriginal: string;
            const ContratoContratoIdSiguiente: string;
            const ContratoNumeroContratoCliente: string;
            const ContratoUserId: string;
            const ContratoFechaModificacion: string;
            const ContratoTemporadaId: string;
            const ContratoImpuestoIncluido: string;
            const ContratoMercadoId: string;
            const ContratoClienteIdPadre: string;
            const ServicioNombreServicio: string;
            const ServicioAbreviatura: string;
            const ServicioTipoServicioId: string;
            const ServicioSwProduccion: string;
            const ServicioSwDescuento: string;
            const ServicioSwAjustes: string;
            const ServicioSwGastos: string;
            const ServicioSwPension: string;
            const ServicioSwRectificativa: string;
            const ServicioTipoUnidadCalculoId: string;
            const ServicioConceptoAceleradorReservasId: string;
            const ServicioCosto: string;
            const ServicioSumaServicioId: string;
            const ServicioRestaServicioId: string;
            const ServicioUserId: string;
            const ServicioFechaModificacion: string;
            const ServicioTipoHab: string;
            const ServicioTipoPension: string;
            const UnidadCalculoUc: string;
            const UnidadCalculoDescripcionUnidadCalculo: string;
            const UnidadCalculoTipoUnidadCalculoId: string;
            const UnidadCalculoPax: string;
            const UnidadCalculoServicioId: string;
            const UnidadCalculoUserId: string;
            const UnidadCalculoFechaModificacion: string;
            const TipoOfertaOferta: string;
            const TipoOfertaPermitirMMayorQueN: string;
            const TipoOfertaRejilla: string;
            const TipoOfertaObservaciones: string;
            const TipoOfertaOrdenAplicacion: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace LineasDeContratoService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<LineasDeContratoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LineasDeContratoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LineasDeContratoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LineasDeContratoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    class TipoAplicacionOfertaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TipoAplicacionOfertaForm {
        AplicableSegunFechaDe: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface TipoAplicacionOfertaRow {
        TipoAplicacionOfertaId?: string;
        AplicableSegunFechaDe?: string;
    }
    namespace TipoAplicacionOfertaRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TipoAplicacionOfertaRow>;
        namespace Fields {
            const TipoAplicacionOfertaId: string;
            const AplicableSegunFechaDe: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace TipoAplicacionOfertaService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TipoAplicacionOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TipoAplicacionOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TipoAplicacionOfertaRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TipoAplicacionOfertaRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    class TiposCondicionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposCondicionForm {
        Condicion: Serenity.StringEditor;
        Literal: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface TiposCondicionRow {
        TipoCondicionId?: number;
        Condicion?: string;
        Literal?: string;
    }
    namespace TiposCondicionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposCondicionRow>;
        namespace Fields {
            const TipoCondicionId: string;
            const Condicion: string;
            const Literal: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace TiposCondicionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposCondicionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposCondicionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposCondicionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposCondicionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    class TiposDeImputacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposDeImputacionForm {
        Imputacion: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface TiposDeImputacionRow {
        TipoImputacionId?: number;
        Imputacion?: string;
    }
    namespace TiposDeImputacionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposDeImputacionRow>;
        namespace Fields {
            const TipoImputacionId: string;
            const Imputacion: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace TiposDeImputacionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposDeImputacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposDeImputacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposDeImputacionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposDeImputacionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    class TiposDeOfertaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposDeOfertaForm {
        Oferta: Serenity.StringEditor;
        PermitirMMayorQueN: Serenity.IntegerEditor;
        Rejilla: Serenity.IntegerEditor;
        Observaciones: Serenity.StringEditor;
        OrdenAplicacion: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface TiposDeOfertaRow {
        TipoOfertaId?: number;
        Oferta?: string;
        PermitirMMayorQueN?: number;
        Rejilla?: number;
        Observaciones?: string;
        OrdenAplicacion?: number;
    }
    namespace TiposDeOfertaRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposDeOfertaRow>;
        namespace Fields {
            const TipoOfertaId: string;
            const Oferta: string;
            const PermitirMMayorQueN: string;
            const Rejilla: string;
            const Observaciones: string;
            const OrdenAplicacion: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace TiposDeOfertaService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposDeOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposDeOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposDeOfertaRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposDeOfertaRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel {
    interface ExcelImportRequest extends Serenity.ServiceRequest {
        FileName?: string;
    }
}
declare namespace Geshotel {
    interface ExcelImportResponse extends Serenity.ServiceResponse {
        Inserted?: number;
        Updated?: number;
        ErrorList?: string[];
    }
}
declare namespace Geshotel {
    interface GetNextNumberRequest extends Serenity.ServiceRequest {
        Prefix?: string;
        Length?: number;
    }
}
declare namespace Geshotel {
    interface GetNextNumberResponse extends Serenity.ServiceResponse {
        Number?: number;
        Serial?: string;
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingAgendaForm {
        MeetingId: Serenity.IntegerEditor;
        AgendaNumber: Serenity.IntegerEditor;
        Title: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        AgendaTypeId: Serenity.IntegerEditor;
        RequestedByContactId: Serenity.IntegerEditor;
        Images: Serenity.MultipleImageUploadEditor;
        Attachments: Serenity.MultipleImageUploadEditor;
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaRelevantForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingAgendaRelevantForm {
        AgendaId: Serenity.IntegerEditor;
        ContactId: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingAgendaRelevantRow {
        AgendaRelevantId?: number;
        AgendaId?: number;
        ContactId?: number;
        AgendaMeetingId?: number;
        AgendaAgendaNumber?: number;
        AgendaTitle?: string;
        AgendaDescription?: string;
        AgendaAgendaTypeId?: number;
        AgendaRequestedByContactId?: number;
        AgendaImages?: string;
        AgendaAttachments?: string;
        ContactTitle?: string;
        ContactFirstName?: string;
        ContactLastName?: string;
        ContactEmail?: string;
        ContactIdentityNo?: string;
        ContactUserId?: number;
    }
    namespace MeetingAgendaRelevantRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const AgendaRelevantId: string;
            const AgendaId: string;
            const ContactId: string;
            const AgendaMeetingId: string;
            const AgendaAgendaNumber: string;
            const AgendaTitle: string;
            const AgendaDescription: string;
            const AgendaAgendaTypeId: string;
            const AgendaRequestedByContactId: string;
            const AgendaImages: string;
            const AgendaAttachments: string;
            const ContactTitle: string;
            const ContactFirstName: string;
            const ContactLastName: string;
            const ContactEmail: string;
            const ContactIdentityNo: string;
            const ContactUserId: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingAgendaRelevantService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingAgendaRelevantRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingAgendaRelevantRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingAgendaRelevantRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingAgendaRelevantRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingAgendaRow {
        AgendaId?: number;
        MeetingId?: number;
        AgendaNumber?: number;
        Title?: string;
        Description?: string;
        AgendaTypeId?: number;
        RequestedByContactId?: number;
        Images?: string;
        Attachments?: string;
        MeetingMeetingName?: string;
        MeetingMeetingNumber?: string;
        MeetingMeetingGuid?: string;
        MeetingMeetingTypeId?: number;
        MeetingStartDate?: string;
        MeetingEndDate?: string;
        MeetingLocationId?: number;
        MeetingUnitId?: number;
        MeetingOrganizerContactId?: number;
        MeetingReporterContactId?: number;
        MeetingInsertUserId?: number;
        MeetingInsertDate?: string;
        MeetingUpdateUserId?: number;
        MeetingUpdateDate?: string;
        AgendaTypeName?: string;
        RequestedByContactTitle?: string;
        RequestedByContactFirstName?: string;
        RequestedByContactLastName?: string;
        RequestedByContactFullName?: string;
        RequestedByContactEmail?: string;
        RequestedByContactIdentityNo?: string;
        RequestedByContactUserId?: number;
    }
    namespace MeetingAgendaRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const AgendaId: string;
            const MeetingId: string;
            const AgendaNumber: string;
            const Title: string;
            const Description: string;
            const AgendaTypeId: string;
            const RequestedByContactId: string;
            const Images: string;
            const Attachments: string;
            const MeetingMeetingName: string;
            const MeetingMeetingNumber: string;
            const MeetingMeetingGuid: string;
            const MeetingMeetingTypeId: string;
            const MeetingStartDate: string;
            const MeetingEndDate: string;
            const MeetingLocationId: string;
            const MeetingUnitId: string;
            const MeetingOrganizerContactId: string;
            const MeetingReporterContactId: string;
            const MeetingInsertUserId: string;
            const MeetingInsertDate: string;
            const MeetingUpdateUserId: string;
            const MeetingUpdateDate: string;
            const AgendaTypeName: string;
            const RequestedByContactTitle: string;
            const RequestedByContactFirstName: string;
            const RequestedByContactLastName: string;
            const RequestedByContactFullName: string;
            const RequestedByContactEmail: string;
            const RequestedByContactIdentityNo: string;
            const RequestedByContactUserId: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingAgendaService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingAgendaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingAgendaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingAgendaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingAgendaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingAgendaTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingAgendaTypeForm {
        Name: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingAgendaTypeRow {
        AgendaTypeId?: number;
        Name?: string;
    }
    namespace MeetingAgendaTypeRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<MeetingAgendaTypeRow>;
        namespace Fields {
            const AgendaTypeId: string;
            const Name: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingAgendaTypeService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingAgendaTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingAgendaTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingAgendaTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingAgendaTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    enum MeetingAttendanceStatus {
        NotSet = 0,
        Attended = 1,
        Absent = 2,
        AbsentWithPermission = 3,
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingAttendeeForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingAttendeeForm {
        MeetingId: Serenity.IntegerEditor;
        ContactId: Serenity.IntegerEditor;
        AttendeeType: Serenity.EnumEditor;
        AttendanceStatus: Serenity.EnumEditor;
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingAttendeeRow {
        AttendeeId?: number;
        MeetingId?: number;
        ContactId?: number;
        AttendeeType?: MeetingAttendeeType;
        AttendanceStatus?: MeetingAttendanceStatus;
        MeetingMeetingName?: string;
        MeetingMeetingNumber?: string;
        MeetingMeetingGuid?: string;
        MeetingMeetingTypeId?: number;
        MeetingStartDate?: string;
        MeetingEndDate?: string;
        MeetingLocationId?: number;
        MeetingUnitId?: number;
        MeetingOrganizerContactId?: number;
        MeetingReporterContactId?: number;
        MeetingInsertUserId?: number;
        MeetingInsertDate?: string;
        MeetingUpdateUserId?: number;
        MeetingUpdateDate?: string;
        ContactTitle?: string;
        ContactFirstName?: string;
        ContactLastName?: string;
        ContactFullName?: string;
        ContactEmail?: string;
        ContactIdentityNo?: string;
        ContactUserId?: number;
    }
    namespace MeetingAttendeeRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const AttendeeId: string;
            const MeetingId: string;
            const ContactId: string;
            const AttendeeType: string;
            const AttendanceStatus: string;
            const MeetingMeetingName: string;
            const MeetingMeetingNumber: string;
            const MeetingMeetingGuid: string;
            const MeetingMeetingTypeId: string;
            const MeetingStartDate: string;
            const MeetingEndDate: string;
            const MeetingLocationId: string;
            const MeetingUnitId: string;
            const MeetingOrganizerContactId: string;
            const MeetingReporterContactId: string;
            const MeetingInsertUserId: string;
            const MeetingInsertDate: string;
            const MeetingUpdateUserId: string;
            const MeetingUpdateDate: string;
            const ContactTitle: string;
            const ContactFirstName: string;
            const ContactLastName: string;
            const ContactFullName: string;
            const ContactEmail: string;
            const ContactIdentityNo: string;
            const ContactUserId: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    enum MeetingAttendeeType {
        Attendee = 1,
        Guest = 2,
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingDecisionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingDecisionForm {
        MeetingId: Serenity.IntegerEditor;
        AgendaId: Serenity.IntegerEditor;
        Description: Serenity.StringEditor;
        DecisionNumber: Serenity.IntegerEditor;
        ResponsibleContactId: Serenity.IntegerEditor;
        DueDate: Serenity.DateEditor;
        ResolutionStatus: Serenity.IntegerEditor;
        Images: Serenity.StringEditor;
        Attachments: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingDecisionRelevantForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingDecisionRelevantForm {
        DecisionId: Serenity.IntegerEditor;
        ContactId: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingDecisionRelevantRow {
        DecisionRelevantId?: number;
        DecisionId?: number;
        ContactId?: number;
        DecisionMeetingId?: number;
        DecisionAgendaId?: number;
        DecisionDescription?: string;
        DecisionDecisionNumber?: number;
        DecisionResponsibleContactId?: number;
        DecisionDueDate?: string;
        DecisionResolutionStatus?: number;
        DecisionImages?: string;
        DecisionAttachments?: string;
        ContactTitle?: string;
        ContactFirstName?: string;
        ContactLastName?: string;
        ContactEmail?: string;
        ContactIdentityNo?: string;
        ContactUserId?: number;
    }
    namespace MeetingDecisionRelevantRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const DecisionRelevantId: string;
            const DecisionId: string;
            const ContactId: string;
            const DecisionMeetingId: string;
            const DecisionAgendaId: string;
            const DecisionDescription: string;
            const DecisionDecisionNumber: string;
            const DecisionResponsibleContactId: string;
            const DecisionDueDate: string;
            const DecisionResolutionStatus: string;
            const DecisionImages: string;
            const DecisionAttachments: string;
            const ContactTitle: string;
            const ContactFirstName: string;
            const ContactLastName: string;
            const ContactEmail: string;
            const ContactIdentityNo: string;
            const ContactUserId: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingDecisionRelevantService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingDecisionRelevantRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingDecisionRelevantRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingDecisionRelevantRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingDecisionRelevantRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingDecisionRow {
        DecisionId?: number;
        MeetingId?: number;
        AgendaId?: number;
        Description?: string;
        DecisionNumber?: number;
        ResponsibleContactId?: number;
        DueDate?: string;
        ResolutionStatus?: number;
        Images?: string;
        Attachments?: string;
        MeetingMeetingName?: string;
        MeetingMeetingNumber?: string;
        MeetingMeetingGuid?: string;
        MeetingMeetingTypeId?: number;
        MeetingStartDate?: string;
        MeetingEndDate?: string;
        MeetingLocationId?: number;
        MeetingUnitId?: number;
        MeetingOrganizerContactId?: number;
        MeetingReporterContactId?: number;
        MeetingInsertUserId?: number;
        MeetingInsertDate?: string;
        MeetingUpdateUserId?: number;
        MeetingUpdateDate?: string;
        AgendaMeetingId?: number;
        AgendaNumber?: number;
        AgendaTitle?: string;
        AgendaDescription?: string;
        AgendaAgendaTypeId?: number;
        AgendaRequestedByContactId?: number;
        AgendaImages?: string;
        AgendaAttachments?: string;
        DecisionNumberName?: string;
        ResponsibleContactTitle?: string;
        ResponsibleContactFirstName?: string;
        ResponsibleContactLastName?: string;
        ResponsibleContactFullName?: string;
        ResponsibleContactEmail?: string;
        ResponsibleContactIdentityNo?: string;
        ResponsibleContactUserId?: number;
    }
    namespace MeetingDecisionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const DecisionId: string;
            const MeetingId: string;
            const AgendaId: string;
            const Description: string;
            const DecisionNumber: string;
            const ResponsibleContactId: string;
            const DueDate: string;
            const ResolutionStatus: string;
            const Images: string;
            const Attachments: string;
            const MeetingMeetingName: string;
            const MeetingMeetingNumber: string;
            const MeetingMeetingGuid: string;
            const MeetingMeetingTypeId: string;
            const MeetingStartDate: string;
            const MeetingEndDate: string;
            const MeetingLocationId: string;
            const MeetingUnitId: string;
            const MeetingOrganizerContactId: string;
            const MeetingReporterContactId: string;
            const MeetingInsertUserId: string;
            const MeetingInsertDate: string;
            const MeetingUpdateUserId: string;
            const MeetingUpdateDate: string;
            const AgendaMeetingId: string;
            const AgendaNumber: string;
            const AgendaTitle: string;
            const AgendaDescription: string;
            const AgendaAgendaTypeId: string;
            const AgendaRequestedByContactId: string;
            const AgendaImages: string;
            const AgendaAttachments: string;
            const DecisionNumberName: string;
            const ResponsibleContactTitle: string;
            const ResponsibleContactFirstName: string;
            const ResponsibleContactLastName: string;
            const ResponsibleContactFullName: string;
            const ResponsibleContactEmail: string;
            const ResponsibleContactIdentityNo: string;
            const ResponsibleContactUserId: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingDecisionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingDecisionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingDecisionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingDecisionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingDecisionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    class MeetingForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingForm {
        MeetingName: Serenity.StringEditor;
        MeetingTypeId: Serenity.LookupEditor;
        MeetingNumber: Serenity.StringEditor;
        StartDate: Serenity.DateTimeEditor;
        EndDate: Serenity.DateTimeEditor;
        LocationId: Serenity.LookupEditor;
        UnitId: Organization.BusinessUnitEditor;
        OrganizerContactId: Serenity.LookupEditor;
        ReporterContactId: Serenity.LookupEditor;
        AttendeeList: MeetingAttendeeEditor;
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingLocationForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingLocationForm {
        Name: Serenity.StringEditor;
        Address: Serenity.StringEditor;
        Latitude: Serenity.DecimalEditor;
        Longitude: Serenity.DecimalEditor;
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingLocationRow {
        LocationId?: number;
        Name?: string;
        Address?: string;
        Latitude?: number;
        Longitude?: number;
    }
    namespace MeetingLocationRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<MeetingLocationRow>;
        namespace Fields {
            const LocationId: string;
            const Name: string;
            const Address: string;
            const Latitude: string;
            const Longitude: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingLocationService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingLocationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingLocationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingLocationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingLocationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingRow {
        MeetingId?: number;
        MeetingName?: string;
        MeetingNumber?: string;
        MeetingGuid?: string;
        MeetingTypeId?: number;
        StartDate?: string;
        EndDate?: string;
        LocationId?: number;
        UnitId?: number;
        OrganizerContactId?: number;
        ReporterContactId?: number;
        MeetingTypeName?: string;
        LocationName?: string;
        UnitName?: string;
        UnitParentUnitId?: number;
        OrganizerContactTitle?: string;
        OrganizerContactFirstName?: string;
        OrganizerContactLastName?: string;
        OrganizerContactFullName?: string;
        OrganizerContactEmail?: string;
        OrganizerContactIdentityNo?: string;
        OrganizerContactUserId?: number;
        ReporterContactTitle?: string;
        ReporterContactFirstName?: string;
        ReporterContactLastName?: string;
        ReporterContactFullName?: string;
        ReporterContactEmail?: string;
        ReporterContactIdentityNo?: string;
        ReporterContactUserId?: number;
        AttendeeList?: MeetingAttendeeRow[];
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }
    namespace MeetingRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MeetingId: string;
            const MeetingName: string;
            const MeetingNumber: string;
            const MeetingGuid: string;
            const MeetingTypeId: string;
            const StartDate: string;
            const EndDate: string;
            const LocationId: string;
            const UnitId: string;
            const OrganizerContactId: string;
            const ReporterContactId: string;
            const MeetingTypeName: string;
            const LocationName: string;
            const UnitName: string;
            const UnitParentUnitId: string;
            const OrganizerContactTitle: string;
            const OrganizerContactFirstName: string;
            const OrganizerContactLastName: string;
            const OrganizerContactFullName: string;
            const OrganizerContactEmail: string;
            const OrganizerContactIdentityNo: string;
            const OrganizerContactUserId: string;
            const ReporterContactTitle: string;
            const ReporterContactFirstName: string;
            const ReporterContactLastName: string;
            const ReporterContactFullName: string;
            const ReporterContactEmail: string;
            const ReporterContactIdentityNo: string;
            const ReporterContactUserId: string;
            const AttendeeList: string;
            const InsertUserId: string;
            const InsertDate: string;
            const UpdateUserId: string;
            const UpdateDate: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Meeting {
}
declare namespace Geshotel.Meeting {
    class MeetingTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MeetingTypeForm {
        Name: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Meeting {
    interface MeetingTypeRow {
        MeetingTypeId?: number;
        Name?: string;
    }
    namespace MeetingTypeRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<MeetingTypeRow>;
        namespace Fields {
            const MeetingTypeId: string;
            const Name: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingTypeService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MeetingTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MeetingTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MeetingTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MeetingTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Membership {
    class ChangePasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ChangePasswordForm {
        OldPassword: Serenity.PasswordEditor;
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
}
declare namespace Geshotel.Membership {
    interface ChangePasswordRequest extends Serenity.ServiceRequest {
        OldPassword?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace Geshotel.Membership {
    class ForgotPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ForgotPasswordForm {
        Email: Serenity.EmailEditor;
    }
}
declare namespace Geshotel.Membership {
    interface ForgotPasswordRequest extends Serenity.ServiceRequest {
        Email?: string;
    }
}
declare namespace Geshotel.Membership {
    class LoginForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface LoginForm {
        Username: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
    }
}
declare namespace Geshotel.Membership {
    interface LoginRequest extends Serenity.ServiceRequest {
        Username?: string;
        Password?: string;
    }
}
declare namespace Geshotel.Membership {
    class ResetPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ResetPasswordForm {
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
}
declare namespace Geshotel.Membership {
    interface ResetPasswordRequest extends Serenity.ServiceRequest {
        Token?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace Geshotel.Membership {
    class SignUpForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface SignUpForm {
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ConfirmEmail: Serenity.EmailEditor;
        Password: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
}
declare namespace Geshotel.Membership {
    interface SignUpRequest extends Serenity.ServiceRequest {
        DisplayName?: string;
        Email?: string;
        Password?: string;
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    class CategoryForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface CategoryForm {
        CategoryName: Serenity.StringEditor;
        Description: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface CategoryLangRow {
        Id?: number;
        CategoryId?: number;
        LanguageId?: number;
        CategoryName?: string;
        Description?: string;
    }
    namespace CategoryLangRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const Id: string;
            const CategoryId: string;
            const LanguageId: string;
            const CategoryName: string;
            const Description: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace CategoryLangService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<CategoryLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CategoryLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CategoryLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CategoryLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface CategoryRow {
        CategoryID?: number;
        CategoryName?: string;
        Description?: string;
        Picture?: number[];
    }
    namespace CategoryRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<CategoryRow>;
        namespace Fields {
            const CategoryID: string;
            const CategoryName: string;
            const Description: string;
            const Picture: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace CategoryService {
        const baseUrl: string;
        function Create(request: Serenity.SaveWithLocalizationRequest<CategoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveWithLocalizationRequest<CategoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function RetrieveLocalization(request: Serenity.RetrieveLocalizationRequest, onSuccess?: (response: Serenity.RetrieveLocalizationResponse<CategoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CategoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CategoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const RetrieveLocalization: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    interface CustomerCustomerDemoRow {
        ID?: number;
        CustomerID?: string;
        CustomerTypeID?: string;
        CustomerCompanyName?: string;
        CustomerContactName?: string;
        CustomerContactTitle?: string;
        CustomerAddress?: string;
        CustomerCity?: string;
        CustomerRegion?: string;
        CustomerPostalCode?: string;
        CustomerCountry?: string;
        CustomerPhone?: string;
        CustomerFax?: string;
        CustomerTypeCustomerDesc?: string;
    }
    namespace CustomerCustomerDemoRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const ID: string;
            const CustomerID: string;
            const CustomerTypeID: string;
            const CustomerCompanyName: string;
            const CustomerContactName: string;
            const CustomerContactTitle: string;
            const CustomerAddress: string;
            const CustomerCity: string;
            const CustomerRegion: string;
            const CustomerPostalCode: string;
            const CustomerCountry: string;
            const CustomerPhone: string;
            const CustomerFax: string;
            const CustomerTypeCustomerDesc: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface CustomerDemographicRow {
        ID?: number;
        CustomerTypeID?: string;
        CustomerDesc?: string;
    }
    namespace CustomerDemographicRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const ID: string;
            const CustomerTypeID: string;
            const CustomerDesc: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface CustomerDetailsRow {
        Id?: number;
        LastContactDate?: string;
        LastContactedBy?: number;
        Email?: string;
        SendBulletin?: boolean;
        LastContactedByLastName?: string;
        LastContactedByFirstName?: string;
        LastContactedByTitle?: string;
        LastContactedByTitleOfCourtesy?: string;
        LastContactedByBirthDate?: string;
        LastContactedByHireDate?: string;
        LastContactedByAddress?: string;
        LastContactedByCity?: string;
        LastContactedByRegion?: string;
        LastContactedByPostalCode?: string;
        LastContactedByCountry?: string;
        LastContactedByHomePhone?: string;
        LastContactedByExtension?: string;
        LastContactedByPhoto?: number[];
        LastContactedByNotes?: string;
        LastContactedByReportsTo?: number;
        LastContactedByPhotoPath?: string;
    }
    namespace CustomerDetailsRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const Id: string;
            const LastContactDate: string;
            const LastContactedBy: string;
            const Email: string;
            const SendBulletin: string;
            const LastContactedByLastName: string;
            const LastContactedByFirstName: string;
            const LastContactedByTitle: string;
            const LastContactedByTitleOfCourtesy: string;
            const LastContactedByBirthDate: string;
            const LastContactedByHireDate: string;
            const LastContactedByAddress: string;
            const LastContactedByCity: string;
            const LastContactedByRegion: string;
            const LastContactedByPostalCode: string;
            const LastContactedByCountry: string;
            const LastContactedByHomePhone: string;
            const LastContactedByExtension: string;
            const LastContactedByPhoto: string;
            const LastContactedByNotes: string;
            const LastContactedByReportsTo: string;
            const LastContactedByPhotoPath: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    class CustomerForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface CustomerForm {
        CustomerID: Serenity.StringEditor;
        CompanyName: Serenity.StringEditor;
        ContactName: Serenity.StringEditor;
        ContactTitle: Serenity.StringEditor;
        Representatives: Serenity.LookupEditor;
        Address: Serenity.StringEditor;
        City: Serenity.StringEditor;
        Region: Serenity.StringEditor;
        PostalCode: Serenity.StringEditor;
        Country: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        NoteList: NotesEditor;
        LastContactDate: Serenity.DateEditor;
        LastContactedBy: Serenity.LookupEditor;
        Email: Serenity.EmailEditor;
        SendBulletin: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface CustomerRepresentativesRow {
        RepresentativeId?: number;
        CustomerId?: number;
        EmployeeId?: number;
    }
    namespace CustomerRepresentativesRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const RepresentativeId: string;
            const CustomerId: string;
            const EmployeeId: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface CustomerRow {
        ID?: number;
        CustomerID?: string;
        CompanyName?: string;
        ContactName?: string;
        ContactTitle?: string;
        Address?: string;
        City?: string;
        Region?: string;
        PostalCode?: string;
        Country?: string;
        Phone?: string;
        Fax?: string;
        NoteList?: NoteRow[];
        Representatives?: number[];
        LastContactDate?: string;
        LastContactedBy?: number;
        Email?: string;
        SendBulletin?: boolean;
    }
    namespace CustomerRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<CustomerRow>;
        namespace Fields {
            const ID: string;
            const CustomerID: string;
            const CompanyName: string;
            const ContactName: string;
            const ContactTitle: string;
            const Address: string;
            const City: string;
            const Region: string;
            const PostalCode: string;
            const Country: string;
            const Phone: string;
            const Fax: string;
            const NoteList: string;
            const Representatives: string;
            const LastContactDate: string;
            const LastContactedBy: string;
            const Email: string;
            const SendBulletin: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace CustomerService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<CustomerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CustomerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetNextNumber(request: GetNextNumberRequest, onSuccess?: (response: GetNextNumberResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CustomerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CustomerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const GetNextNumber: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface EmployeeRow {
        EmployeeID?: number;
        LastName?: string;
        FirstName?: string;
        FullName?: string;
        Title?: string;
        TitleOfCourtesy?: string;
        BirthDate?: string;
        HireDate?: string;
        Address?: string;
        City?: string;
        Region?: string;
        PostalCode?: string;
        Country?: string;
        HomePhone?: string;
        Extension?: string;
        Photo?: number[];
        Notes?: string;
        ReportsTo?: number;
        PhotoPath?: string;
        ReportsToFullName?: string;
        ReportsToLastName?: string;
        ReportsToFirstName?: string;
        ReportsToTitle?: string;
        ReportsToTitleOfCourtesy?: string;
        ReportsToBirthDate?: string;
        ReportsToHireDate?: string;
        ReportsToAddress?: string;
        ReportsToCity?: string;
        ReportsToRegion?: string;
        ReportsToPostalCode?: string;
        ReportsToCountry?: string;
        ReportsToHomePhone?: string;
        ReportsToExtension?: string;
        ReportsToPhoto?: number[];
        ReportsToNotes?: string;
        ReportsToReportsTo?: number;
        ReportsToPhotoPath?: string;
        Gender?: Gender;
    }
    namespace EmployeeRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<EmployeeRow>;
        namespace Fields {
            const EmployeeID: string;
            const LastName: string;
            const FirstName: string;
            const FullName: string;
            const Title: string;
            const TitleOfCourtesy: string;
            const BirthDate: string;
            const HireDate: string;
            const Address: string;
            const City: string;
            const Region: string;
            const PostalCode: string;
            const Country: string;
            const HomePhone: string;
            const Extension: string;
            const Photo: string;
            const Notes: string;
            const ReportsTo: string;
            const PhotoPath: string;
            const ReportsToFullName: string;
            const ReportsToLastName: string;
            const ReportsToFirstName: string;
            const ReportsToTitle: string;
            const ReportsToTitleOfCourtesy: string;
            const ReportsToBirthDate: string;
            const ReportsToHireDate: string;
            const ReportsToAddress: string;
            const ReportsToCity: string;
            const ReportsToRegion: string;
            const ReportsToPostalCode: string;
            const ReportsToCountry: string;
            const ReportsToHomePhone: string;
            const ReportsToExtension: string;
            const ReportsToPhoto: string;
            const ReportsToNotes: string;
            const ReportsToReportsTo: string;
            const ReportsToPhotoPath: string;
            const Gender: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface EmployeeTerritoryRow {
        EmployeeID?: number;
        TerritoryID?: string;
        EmployeeLastName?: string;
        EmployeeFirstName?: string;
        EmployeeTitle?: string;
        EmployeeTitleOfCourtesy?: string;
        EmployeeBirthDate?: string;
        EmployeeHireDate?: string;
        EmployeeAddress?: string;
        EmployeeCity?: string;
        EmployeeRegion?: string;
        EmployeePostalCode?: string;
        EmployeeCountry?: string;
        EmployeeHomePhone?: string;
        EmployeeExtension?: string;
        EmployeePhoto?: number[];
        EmployeeNotes?: string;
        EmployeeReportsTo?: number;
        EmployeePhotoPath?: string;
        TerritoryTerritoryDescription?: string;
        TerritoryRegionID?: number;
    }
    namespace EmployeeTerritoryRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const EmployeeID: string;
            const TerritoryID: string;
            const EmployeeLastName: string;
            const EmployeeFirstName: string;
            const EmployeeTitle: string;
            const EmployeeTitleOfCourtesy: string;
            const EmployeeBirthDate: string;
            const EmployeeHireDate: string;
            const EmployeeAddress: string;
            const EmployeeCity: string;
            const EmployeeRegion: string;
            const EmployeePostalCode: string;
            const EmployeeCountry: string;
            const EmployeeHomePhone: string;
            const EmployeeExtension: string;
            const EmployeePhoto: string;
            const EmployeeNotes: string;
            const EmployeeReportsTo: string;
            const EmployeePhotoPath: string;
            const TerritoryTerritoryDescription: string;
            const TerritoryRegionID: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    enum Gender {
        Male = 1,
        Female = 2,
    }
}
declare namespace Geshotel.Northwind {
    interface NoteRow {
        NoteId?: number;
        EntityType?: string;
        EntityId?: number;
        Text?: string;
        InsertUserId?: number;
        InsertDate?: string;
        InsertUserDisplayName?: string;
    }
    namespace NoteRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const NoteId: string;
            const EntityType: string;
            const EntityId: string;
            const Text: string;
            const InsertUserId: string;
            const InsertDate: string;
            const InsertUserDisplayName: string;
        }
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    class OrderDetailForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface OrderDetailForm {
        ProductID: Serenity.LookupEditor;
        UnitPrice: Serenity.DecimalEditor;
        Quantity: Serenity.IntegerEditor;
        Discount: Serenity.DecimalEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface OrderDetailRow {
        DetailID?: number;
        OrderID?: number;
        ProductID?: number;
        UnitPrice?: number;
        Quantity?: number;
        Discount?: number;
        OrderCustomerID?: string;
        OrderEmployeeID?: number;
        OrderDate?: string;
        OrderShippedDate?: string;
        OrderShipVia?: number;
        OrderShipCity?: string;
        OrderShipCountry?: string;
        ProductName?: string;
        ProductDiscontinued?: boolean;
        ProductSupplierID?: number;
        ProductQuantityPerUnit?: string;
        ProductUnitPrice?: number;
        LineTotal?: number;
    }
    namespace OrderDetailRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const DetailID: string;
            const OrderID: string;
            const ProductID: string;
            const UnitPrice: string;
            const Quantity: string;
            const Discount: string;
            const OrderCustomerID: string;
            const OrderEmployeeID: string;
            const OrderDate: string;
            const OrderShippedDate: string;
            const OrderShipVia: string;
            const OrderShipCity: string;
            const OrderShipCountry: string;
            const ProductName: string;
            const ProductDiscontinued: string;
            const ProductSupplierID: string;
            const ProductQuantityPerUnit: string;
            const ProductUnitPrice: string;
            const LineTotal: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace OrderDetailService {
        const baseUrl: string;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<OrderDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<OrderDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    class OrderForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface OrderForm {
        CustomerID: CustomerEditor;
        OrderDate: Serenity.DateEditor;
        RequiredDate: Serenity.DateEditor;
        EmployeeID: Serenity.LookupEditor;
        DetailList: OrderDetailsEditor;
        ShippedDate: Serenity.DateEditor;
        ShipVia: Serenity.LookupEditor;
        Freight: Serenity.DecimalEditor;
        ShipName: Serenity.StringEditor;
        ShipAddress: Serenity.StringEditor;
        ShipCity: Serenity.StringEditor;
        ShipRegion: Serenity.StringEditor;
        ShipPostalCode: Serenity.StringEditor;
        ShipCountry: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface OrderListRequest extends Serenity.ListRequest {
        ProductID?: number;
    }
}
declare namespace Geshotel.Northwind {
    interface OrderRow {
        OrderID?: number;
        CustomerID?: string;
        EmployeeID?: number;
        OrderDate?: string;
        RequiredDate?: string;
        ShippedDate?: string;
        ShipVia?: number;
        Freight?: number;
        ShipName?: string;
        ShipAddress?: string;
        ShipCity?: string;
        ShipRegion?: string;
        ShipPostalCode?: string;
        ShipCountry?: string;
        CustomerCompanyName?: string;
        CustomerContactName?: string;
        CustomerContactTitle?: string;
        CustomerCity?: string;
        CustomerRegion?: string;
        CustomerCountry?: string;
        CustomerPhone?: string;
        CustomerFax?: string;
        EmployeeFullName?: string;
        EmployeeGender?: Gender;
        ShipViaCompanyName?: string;
        ShipViaPhone?: string;
        ShippingState?: OrderShippingState;
        DetailList?: OrderDetailRow[];
    }
    namespace OrderRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<OrderRow>;
        namespace Fields {
            const OrderID: string;
            const CustomerID: string;
            const EmployeeID: string;
            const OrderDate: string;
            const RequiredDate: string;
            const ShippedDate: string;
            const ShipVia: string;
            const Freight: string;
            const ShipName: string;
            const ShipAddress: string;
            const ShipCity: string;
            const ShipRegion: string;
            const ShipPostalCode: string;
            const ShipCountry: string;
            const CustomerCompanyName: string;
            const CustomerContactName: string;
            const CustomerContactTitle: string;
            const CustomerCity: string;
            const CustomerRegion: string;
            const CustomerCountry: string;
            const CustomerPhone: string;
            const CustomerFax: string;
            const EmployeeFullName: string;
            const EmployeeGender: string;
            const ShipViaCompanyName: string;
            const ShipViaPhone: string;
            const ShippingState: string;
            const DetailList: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace OrderService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<OrderRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<OrderRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<OrderRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: OrderListRequest, onSuccess?: (response: Serenity.ListResponse<OrderRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    enum OrderShippingState {
        NotShipped = 0,
        Shipped = 1,
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    class ProductForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ProductForm {
        ProductName: Serenity.StringEditor;
        ProductImage: Serenity.ImageUploadEditor;
        Discontinued: Serenity.BooleanEditor;
        SupplierID: Serenity.LookupEditor;
        CategoryID: Serenity.LookupEditor;
        QuantityPerUnit: Serenity.StringEditor;
        UnitPrice: Serenity.DecimalEditor;
        UnitsInStock: Serenity.IntegerEditor;
        UnitsOnOrder: Serenity.IntegerEditor;
        ReorderLevel: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface ProductLangRow {
        Id?: number;
        ProductId?: number;
        LanguageId?: number;
        ProductName?: string;
    }
    namespace ProductLangRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const Id: string;
            const ProductId: string;
            const LanguageId: string;
            const ProductName: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace ProductLangService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ProductLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ProductLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ProductLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ProductLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface ProductLogRow {
        ProductLogID?: number;
        OperationType?: Serenity.CaptureOperationType;
        ChangingUserId?: number;
        ValidFrom?: string;
        ValidUntil?: string;
        ProductID?: number;
        ProductName?: string;
        ProductImage?: string;
        Discontinued?: boolean;
        SupplierID?: number;
        CategoryID?: number;
        QuantityPerUnit?: string;
        UnitPrice?: number;
        UnitsInStock?: number;
        UnitsOnOrder?: number;
        ReorderLevel?: number;
    }
    namespace ProductLogRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const ProductLogID: string;
            const OperationType: string;
            const ChangingUserId: string;
            const ValidFrom: string;
            const ValidUntil: string;
            const ProductID: string;
            const ProductName: string;
            const ProductImage: string;
            const Discontinued: string;
            const SupplierID: string;
            const CategoryID: string;
            const QuantityPerUnit: string;
            const UnitPrice: string;
            const UnitsInStock: string;
            const UnitsOnOrder: string;
            const ReorderLevel: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    interface ProductRow {
        ProductID?: number;
        ProductName?: string;
        ProductImage?: string;
        Discontinued?: boolean;
        SupplierID?: number;
        CategoryID?: number;
        QuantityPerUnit?: string;
        UnitPrice?: number;
        UnitsInStock?: number;
        UnitsOnOrder?: number;
        ReorderLevel?: number;
        SupplierCompanyName?: string;
        SupplierContactName?: string;
        SupplierContactTitle?: string;
        SupplierAddress?: string;
        SupplierCity?: string;
        SupplierRegion?: string;
        SupplierPostalCode?: string;
        SupplierCountry?: string;
        SupplierPhone?: string;
        SupplierFax?: string;
        SupplierHomePage?: string;
        CategoryName?: string;
        CategoryDescription?: string;
        CategoryPicture?: number[];
    }
    namespace ProductRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ProductRow>;
        namespace Fields {
            const ProductID: string;
            const ProductName: string;
            const ProductImage: string;
            const Discontinued: string;
            const SupplierID: string;
            const CategoryID: string;
            const QuantityPerUnit: string;
            const UnitPrice: string;
            const UnitsInStock: string;
            const UnitsOnOrder: string;
            const ReorderLevel: string;
            const SupplierCompanyName: string;
            const SupplierContactName: string;
            const SupplierContactTitle: string;
            const SupplierAddress: string;
            const SupplierCity: string;
            const SupplierRegion: string;
            const SupplierPostalCode: string;
            const SupplierCountry: string;
            const SupplierPhone: string;
            const SupplierFax: string;
            const SupplierHomePage: string;
            const CategoryName: string;
            const CategoryDescription: string;
            const CategoryPicture: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace ProductService {
        const baseUrl: string;
        function Create(request: Serenity.SaveWithLocalizationRequest<ProductRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveWithLocalizationRequest<ProductRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ProductRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function RetrieveLocalization(request: Serenity.RetrieveLocalizationRequest, onSuccess?: (response: Serenity.RetrieveLocalizationResponse<ProductRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ProductRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const RetrieveLocalization: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    class RegionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface RegionForm {
        RegionID: Serenity.IntegerEditor;
        RegionDescription: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface RegionRow {
        RegionID?: number;
        RegionDescription?: string;
    }
    namespace RegionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<RegionRow>;
        namespace Fields {
            const RegionID: string;
            const RegionDescription: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace RegionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<RegionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RegionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RegionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RegionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    interface SalesByCategoryRow {
        CategoryId?: number;
        CategoryName?: string;
        ProductName?: string;
        ProductSales?: number;
    }
    namespace SalesByCategoryRow {
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const CategoryId: string;
            const CategoryName: string;
            const ProductName: string;
            const ProductSales: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace SalesByCategoryService {
        const baseUrl: string;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SalesByCategoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    class ShipperForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ShipperForm {
        CompanyName: Serenity.StringEditor;
        Phone: PhoneEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface ShipperRow {
        ShipperID?: number;
        CompanyName?: string;
        Phone?: string;
    }
    namespace ShipperRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ShipperRow>;
        namespace Fields {
            const ShipperID: string;
            const CompanyName: string;
            const Phone: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace ShipperService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ShipperRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ShipperRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ShipperRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ShipperRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    class SupplierForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface SupplierForm {
        CompanyName: Serenity.StringEditor;
        ContactName: Serenity.StringEditor;
        ContactTitle: Serenity.StringEditor;
        Address: Serenity.StringEditor;
        Region: Serenity.StringEditor;
        PostalCode: Serenity.StringEditor;
        Country: Serenity.StringEditor;
        City: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        HomePage: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface SupplierRow {
        SupplierID?: number;
        CompanyName?: string;
        ContactName?: string;
        ContactTitle?: string;
        Address?: string;
        City?: string;
        Region?: string;
        PostalCode?: string;
        Country?: string;
        Phone?: string;
        Fax?: string;
        HomePage?: string;
    }
    namespace SupplierRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<SupplierRow>;
        namespace Fields {
            const SupplierID: string;
            const CompanyName: string;
            const ContactName: string;
            const ContactTitle: string;
            const Address: string;
            const City: string;
            const Region: string;
            const PostalCode: string;
            const Country: string;
            const Phone: string;
            const Fax: string;
            const HomePage: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace SupplierService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<SupplierRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<SupplierRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SupplierRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SupplierRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Northwind {
}
declare namespace Geshotel.Northwind {
    class TerritoryForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TerritoryForm {
        TerritoryID: Serenity.StringEditor;
        TerritoryDescription: Serenity.StringEditor;
        RegionID: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Northwind {
    interface TerritoryRow {
        ID?: number;
        TerritoryID?: string;
        TerritoryDescription?: string;
        RegionID?: number;
        RegionDescription?: string;
    }
    namespace TerritoryRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TerritoryRow>;
        namespace Fields {
            const ID: string;
            const TerritoryID: string;
            const TerritoryDescription: string;
            const RegionID: string;
            const RegionDescription: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace TerritoryService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TerritoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TerritoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TerritoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TerritoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Organization {
}
declare namespace Geshotel.Organization {
    class BusinessUnitForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface BusinessUnitForm {
        Name: Serenity.StringEditor;
        ParentUnitId: BusinessUnitEditor;
    }
}
declare namespace Geshotel.Organization {
    interface BusinessUnitRow {
        UnitId?: number;
        Name?: string;
        ParentUnitId?: number;
        ParentUnitName?: string;
        ParentUnitParentUnitId?: number;
    }
    namespace BusinessUnitRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<BusinessUnitRow>;
        namespace Fields {
            const UnitId: string;
            const Name: string;
            const ParentUnitId: string;
            const ParentUnitName: string;
            const ParentUnitParentUnitId: string;
        }
    }
}
declare namespace Geshotel.Organization {
    namespace BusinessUnitService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<BusinessUnitRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<BusinessUnitRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BusinessUnitRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BusinessUnitRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Organization {
}
declare namespace Geshotel.Organization {
    class ContactForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ContactForm {
        Title: Serenity.StringEditor;
        FirstName: Serenity.StringEditor;
        LastName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        IdentityNo: Serenity.StringEditor;
        UserId: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Organization {
    interface ContactRow {
        ContactId?: number;
        Title?: string;
        FirstName?: string;
        LastName?: string;
        FullName?: string;
        Email?: string;
        IdentityNo?: string;
        UserId?: number;
        Username?: string;
        UserDisplayName?: string;
        UserEmail?: string;
        UserSource?: string;
        UserPasswordHash?: string;
        UserPasswordSalt?: string;
        UserLastDirectoryUpdate?: string;
        UserUserImage?: string;
        UserInsertDate?: string;
        UserInsertUserId?: number;
        UserUpdateDate?: string;
        UserUpdateUserId?: number;
        UserIsActive?: number;
    }
    namespace ContactRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ContactRow>;
        namespace Fields {
            const ContactId: string;
            const Title: string;
            const FirstName: string;
            const LastName: string;
            const FullName: string;
            const Email: string;
            const IdentityNo: string;
            const UserId: string;
            const Username: string;
            const UserDisplayName: string;
            const UserEmail: string;
            const UserSource: string;
            const UserPasswordHash: string;
            const UserPasswordSalt: string;
            const UserLastDirectoryUpdate: string;
            const UserUserImage: string;
            const UserInsertDate: string;
            const UserInsertUserId: string;
            const UserUpdateDate: string;
            const UserUpdateUserId: string;
            const UserIsActive: string;
        }
    }
}
declare namespace Geshotel.Organization {
    namespace ContactService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ContactRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ContactRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ContactRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ContactRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class CategoriaHotelesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface CategoriaHotelesForm {
        Abreviatura: Serenity.StringEditor;
        Categoria: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface CategoriaHotelesRow {
        CategoriaId?: number;
        Abreviatura?: string;
        Categoria?: string;
    }
    namespace CategoriaHotelesRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<CategoriaHotelesRow>;
        namespace Fields {
            const CategoriaId: string;
            const Abreviatura: string;
            const Categoria: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace CategoriaHotelesService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<CategoriaHotelesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CategoriaHotelesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CategoriaHotelesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CategoriaHotelesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class ComunidadesAutonomasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ComunidadesAutonomasForm {
        ComunidadAutonoma: Serenity.StringEditor;
        NacionId: Serenity.LookupEditor;
        ComunidadAutonomaIsta: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface ComunidadesAutonomasRow {
        ComunidadId?: number;
        NacionId?: number;
        ComunidadAutonoma?: string;
        ComunidadAutonomaIsta?: string;
        Nacion?: string;
        NacionDescCorta?: string;
        NacionMonedaId?: number;
        NacionIdiomaId?: number;
        NacionNumeroIne?: number;
        NacionPaisIsta?: string;
        NacionDefecto?: number;
        NacionNombreReal?: string;
        NacionIdiomaMails?: string;
    }
    namespace ComunidadesAutonomasRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ComunidadesAutonomasRow>;
        namespace Fields {
            const ComunidadId: string;
            const NacionId: string;
            const ComunidadAutonoma: string;
            const ComunidadAutonomaIsta: string;
            const Nacion: string;
            const NacionDescCorta: string;
            const NacionMonedaId: string;
            const NacionIdiomaId: string;
            const NacionNumeroIne: string;
            const NacionPaisIsta: string;
            const NacionDefecto: string;
            const NacionNombreReal: string;
            const NacionIdiomaMails: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace ComunidadesAutonomasService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ComunidadesAutonomasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ComunidadesAutonomasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ComunidadesAutonomasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ComunidadesAutonomasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
    interface ConceptosAceleradorReservasRow {
        ConceptoAceleradorId?: number;
        Concepto?: string;
    }
    namespace ConceptosAceleradorReservasRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ConceptosAceleradorReservasRow>;
        namespace Fields {
            const ConceptoAceleradorId: string;
            const Concepto: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class EmpresasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface EmpresasForm {
        Empresa: Serenity.StringEditor;
        EmpresaContable: Serenity.StringEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        ProvinciaId: Serenity.LookupEditor;
        Telefono: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        Cif: Serenity.StringEditor;
        RutaFicheros: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface EmpresasRow {
        EmpresaId?: number;
        Empresa?: string;
        EmpresaContable?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        ProvinciaId?: number;
        Telefono?: string;
        Fax?: string;
        Cif?: string;
        RutaFicheros?: string;
        Provincia?: string;
        ProvinciaComunidadAutonomaId?: number;
        ProvinciaNacionId?: number;
        ProvinciaProvinciaIsta?: string;
        ProvinciaDefectoIsta?: number;
    }
    namespace EmpresasRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<EmpresasRow>;
        namespace Fields {
            const EmpresaId: string;
            const Empresa: string;
            const EmpresaContable: string;
            const Direccion: string;
            const Poblacion: string;
            const Zip: string;
            const ProvinciaId: string;
            const Telefono: string;
            const Fax: string;
            const Cif: string;
            const RutaFicheros: string;
            const Provincia: string;
            const ProvinciaComunidadAutonomaId: string;
            const ProvinciaNacionId: string;
            const ProvinciaProvinciaIsta: string;
            const ProvinciaDefectoIsta: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace EmpresasService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<EmpresasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<EmpresasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<EmpresasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<EmpresasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
    class EstadosFacturasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface EstadosFacturasForm {
        Descripcion: Serenity.StringEditor;
        EsError: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Portal {
    interface EstadosFacturasRow {
        EstadoFacturaId?: number;
        Descripcion?: string;
        EsError?: number;
    }
    namespace EstadosFacturasRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<EstadosFacturasRow>;
        namespace Fields {
            const EstadoFacturaId: string;
            const Descripcion: string;
            const EsError: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace EstadosFacturasService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<EstadosFacturasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<EstadosFacturasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<EstadosFacturasRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<EstadosFacturasRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class FormasDePagoForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface FormasDePagoForm {
        FormaPago: Serenity.StringEditor;
        Credito: Serenity.BooleanEditor;
        SwEfectivo: Serenity.BooleanEditor;
        SwTarjeta: Serenity.BooleanEditor;
        TarjetaLength: Serenity.StringEditor;
        TarjetaPrefixes: Serenity.StringEditor;
        TarjetaCheckdigit: Serenity.BooleanEditor;
        SwDingus: Serenity.BooleanEditor;
        ProduccionTpv: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Portal {
    interface FormasDePagoRow {
        FormaPagoId?: number;
        FormaPago?: string;
        Credito?: boolean;
        SwEfectivo?: boolean;
        SwTarjeta?: boolean;
        TarjetaLength?: string;
        TarjetaPrefixes?: string;
        TarjetaCheckdigit?: boolean;
        SwDingus?: boolean;
        ProduccionTpv?: boolean;
    }
    namespace FormasDePagoRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<FormasDePagoRow>;
        namespace Fields {
            const FormaPagoId: string;
            const FormaPago: string;
            const Credito: string;
            const SwEfectivo: string;
            const SwTarjeta: string;
            const TarjetaLength: string;
            const TarjetaPrefixes: string;
            const TarjetaCheckdigit: string;
            const SwDingus: string;
            const ProduccionTpv: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace FormasDePagoService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<FormasDePagoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<FormasDePagoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<FormasDePagoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<FormasDePagoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class GruposDeClienteForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface GruposDeClienteForm {
        NombreGrupo: Serenity.StringEditor;
        EmpresaId: Serenity.IntegerEditor;
        CtaContable: Serenity.StringEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        Huesped: Serenity.IntegerEditor;
        Contratos: Serenity.IntegerEditor;
        Facturar: Serenity.IntegerEditor;
        Agencia: Serenity.IntegerEditor;
        Perfil: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Portal {
    interface GruposDeClienteRow {
        GrupoClienteId?: number;
        NombreGrupo?: string;
        EmpresaId?: number;
        CtaContable?: string;
        UserId?: number;
        FechaModificacion?: string;
        Huesped?: number;
        Contratos?: number;
        Facturar?: number;
        Agencia?: number;
        Perfil?: number;
    }
    namespace GruposDeClienteRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<GruposDeClienteRow>;
        namespace Fields {
            const GrupoClienteId: string;
            const NombreGrupo: string;
            const EmpresaId: string;
            const CtaContable: string;
            const UserId: string;
            const FechaModificacion: string;
            const Huesped: string;
            const Contratos: string;
            const Facturar: string;
            const Agencia: string;
            const Perfil: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace GruposDeClienteService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<GruposDeClienteRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<GruposDeClienteRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<GruposDeClienteRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<GruposDeClienteRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class GruposDeServiciosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface GruposDeServiciosForm {
        HotelId: Serenity.IntegerEditor;
        NombreGrupo: Serenity.StringEditor;
        CtaContable: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface GruposDeServiciosRow {
        GrupoServicioId?: number;
        NombreGrupo?: string;
        CtaContable?: string;
    }
    namespace GruposDeServiciosRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<GruposDeServiciosRow>;
        namespace Fields {
            const GrupoServicioId: string;
            const NombreGrupo: string;
            const CtaContable: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace GruposDeServiciosService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<GruposDeServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<GruposDeServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<GruposDeServiciosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<GruposDeServiciosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class GruposHabitacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface GruposHabitacionForm {
        Habitacion: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface GruposHabitacionRow {
        HabitacionId?: number;
        Habitacion?: string;
    }
    namespace GruposHabitacionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<GruposHabitacionRow>;
        namespace Fields {
            const HabitacionId: string;
            const Habitacion: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace GruposHabitacionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<GruposHabitacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<GruposHabitacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<GruposHabitacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<GruposHabitacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class HotelesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface HotelesForm {
        Hotel: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        TipoHotelId: Serenity.LookupEditor;
        CategoriaId: Serenity.LookupEditor;
        NombreCorto: Serenity.StringEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        ProvinciaId: Serenity.LookupEditor;
        NacionId: Serenity.LookupEditor;
        Telefono: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        EmailReservas: Serenity.StringEditor;
        EmailVentas: Serenity.StringEditor;
        EmailSmtp: Serenity.StringEditor;
        TextoCancelacion: Serenity.StringEditor;
        CtaManocorriente: Serenity.StringEditor;
        DptoContable: Serenity.StringEditor;
        CtaContableCajas: Serenity.StringEditor;
        CtaContableBanco: Serenity.StringEditor;
        FechaInicioPrograma: Serenity.DateEditor;
        RutaFicheroPolicia: Serenity.StringEditor;
        ContadorFicheroPolicia: Serenity.IntegerEditor;
        IdentificadorFicheroPolicia: Serenity.StringEditor;
        UsuarioIsta: Serenity.StringEditor;
        PasswordIsta: Serenity.StringEditor;
        UrlIsta: Serenity.StringEditor;
        MunicipioIsta: Serenity.StringEditor;
        NumeroRegistroIsta: Serenity.IntegerEditor;
        RutaBavel: Serenity.StringEditor;
        DingusUsuario: Serenity.StringEditor;
        DingusPassword: Serenity.StringEditor;
        DingusHotelCode: Serenity.StringEditor;
        DingusTraductor: Serenity.StringEditor;
        DingusUrl: Serenity.StringEditor;
        CheckinOnLine: Serenity.IntegerEditor;
        MinimoDiasCheckinOnline: Serenity.IntegerEditor;
        ZoomMapa: Serenity.IntegerEditor;
        Ancho: Serenity.IntegerEditor;
        Alto: Serenity.IntegerEditor;
        OverbookingLimit: Serenity.DecimalEditor;
    }
}
declare namespace Geshotel.Portal {
    interface HotelesRow {
        HotelId?: number;
        Hotel?: string;
        EmpresaId?: number;
        TipoHotelId?: number;
        CategoriaId?: number;
        NombreCorto?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        ProvinciaId?: number;
        NacionId?: number;
        Telefono?: string;
        Fax?: string;
        CtaManocorriente?: string;
        DptoContable?: string;
        CtaContableCajas?: string;
        CtaContableBanco?: string;
        FechaInicioPrograma?: string;
        RutaFicheroPolicia?: string;
        ContadorFicheroPolicia?: number;
        IdentificadorFicheroPolicia?: string;
        EmailReservas?: string;
        EmailVentas?: string;
        EmailSmtp?: string;
        TextoCancelacion?: string;
        UsuarioIsta?: string;
        PasswordIsta?: string;
        UrlIsta?: string;
        MunicipioIsta?: string;
        NumeroRegistroIsta?: number;
        RutaBavel?: string;
        DingusUsuario?: string;
        DingusPassword?: string;
        DingusHotelCode?: string;
        DingusTraductor?: string;
        DingusUrl?: string;
        CheckinOnLine?: number;
        MinimoDiasCheckinOnline?: number;
        ZoomMapa?: number;
        Ancho?: number;
        Alto?: number;
        OverbookingLimit?: number;
        Empresa?: string;
        EmpresaEmpresaContable?: string;
        EmpresaDireccion?: string;
        EmpresaPoblacion?: string;
        EmpresaZip?: string;
        EmpresaProvinciaId?: number;
        EmpresaTelefono?: string;
        EmpresaFax?: string;
        EmpresaCif?: string;
        TipoHotel?: string;
        TipoHotelAbreviatura?: string;
        Categoria?: string;
        CategoriaAbreviatura?: string;
        Provincia?: string;
        Nacion?: string;
        ProvinciaComunidadAutonomaId?: number;
        ProvinciaProvinciaIsta?: string;
        ProvinciaDefectoIsta?: number;
    }
    namespace HotelesRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<HotelesRow>;
        namespace Fields {
            const HotelId: string;
            const Hotel: string;
            const EmpresaId: string;
            const TipoHotelId: string;
            const CategoriaId: string;
            const NombreCorto: string;
            const Direccion: string;
            const Poblacion: string;
            const Zip: string;
            const ProvinciaId: string;
            const NacionId: string;
            const Telefono: string;
            const Fax: string;
            const CtaManocorriente: string;
            const DptoContable: string;
            const CtaContableCajas: string;
            const CtaContableBanco: string;
            const FechaInicioPrograma: string;
            const RutaFicheroPolicia: string;
            const ContadorFicheroPolicia: string;
            const IdentificadorFicheroPolicia: string;
            const EmailReservas: string;
            const EmailVentas: string;
            const EmailSmtp: string;
            const TextoCancelacion: string;
            const UsuarioIsta: string;
            const PasswordIsta: string;
            const UrlIsta: string;
            const MunicipioIsta: string;
            const NumeroRegistroIsta: string;
            const RutaBavel: string;
            const DingusUsuario: string;
            const DingusPassword: string;
            const DingusHotelCode: string;
            const DingusTraductor: string;
            const DingusUrl: string;
            const CheckinOnLine: string;
            const MinimoDiasCheckinOnline: string;
            const ZoomMapa: string;
            const Ancho: string;
            const Alto: string;
            const OverbookingLimit: string;
            const Empresa: string;
            const EmpresaEmpresaContable: string;
            const EmpresaDireccion: string;
            const EmpresaPoblacion: string;
            const EmpresaZip: string;
            const EmpresaProvinciaId: string;
            const EmpresaTelefono: string;
            const EmpresaFax: string;
            const EmpresaCif: string;
            const TipoHotel: string;
            const TipoHotelAbreviatura: string;
            const Categoria: string;
            const CategoriaAbreviatura: string;
            const Provincia: string;
            const Nacion: string;
            const ProvinciaComunidadAutonomaId: string;
            const ProvinciaProvinciaIsta: string;
            const ProvinciaDefectoIsta: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace HotelesService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<HotelesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<HotelesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<HotelesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<HotelesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class MonedasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MonedasForm {
        Descripcion: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        Cambio: Serenity.DecimalEditor;
    }
}
declare namespace Geshotel.Portal {
    interface MonedasRow {
        MonedaId?: number;
        DescCorta?: string;
        Descripcion?: string;
        Cambio?: number;
    }
    namespace MonedasRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<MonedasRow>;
        namespace Fields {
            const MonedaId: string;
            const DescCorta: string;
            const Descripcion: string;
            const Cambio: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace MonedasService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MonedasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MonedasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MonedasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MonedasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class NacionesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface NacionesForm {
        Nacion: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        MonedaId: Serenity.LookupEditor;
        IdiomaId: Serenity.LookupEditor;
        NumeroIne: Serenity.IntegerEditor;
        PaisIsta: Serenity.StringEditor;
        Defecto: Serenity.IntegerEditor;
        NombreReal: Serenity.StringEditor;
        IdiomaMails: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface NacionesRow {
        NacionId?: number;
        Nacion?: string;
        DescCorta?: string;
        MonedaId?: number;
        IdiomaId?: number;
        NumeroIne?: number;
        PaisIsta?: string;
        Defecto?: number;
        NombreReal?: string;
        IdiomaMails?: string;
        MonedaDescripcion?: string;
        MonedaDescCorta?: string;
        MonedaCambio?: number;
        IdiomaLanguageId?: string;
        IdiomaLanguageName?: string;
    }
    namespace NacionesRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<NacionesRow>;
        namespace Fields {
            const NacionId: string;
            const Nacion: string;
            const DescCorta: string;
            const MonedaId: string;
            const IdiomaId: string;
            const NumeroIne: string;
            const PaisIsta: string;
            const Defecto: string;
            const NombreReal: string;
            const IdiomaMails: string;
            const MonedaDescripcion: string;
            const MonedaDescCorta: string;
            const MonedaCambio: string;
            const IdiomaLanguageId: string;
            const IdiomaLanguageName: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace NacionesService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<NacionesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<NacionesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<NacionesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<NacionesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class ProvinciasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ProvinciasForm {
        Provincia: Serenity.StringEditor;
        ComunidadAutonomaId: Serenity.LookupEditor;
        NacionId: Serenity.LookupEditor;
        ProvinciaIsta: Serenity.StringEditor;
        DefectoIsta: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Portal {
    interface ProvinciasRow {
        ProvinciaId?: number;
        Provincia?: string;
        ComunidadAutonomaId?: number;
        NacionId?: number;
        ProvinciaIsta?: string;
        DefectoIsta?: number;
        ComunidadAutonomaNacionId?: number;
        ComunidadAutonoma?: string;
        ComunidadAutonomaComunidadAutonomaIsta?: string;
        Nacion?: string;
        NacionDescCorta?: string;
        NacionMonedaId?: number;
        NacionIdiomaId?: number;
        NacionNumeroIne?: number;
        NacionPaisIsta?: string;
        NacionDefecto?: number;
        NacionNombreReal?: string;
        NacionIdiomaMails?: string;
    }
    namespace ProvinciasRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ProvinciasRow>;
        namespace Fields {
            const ProvinciaId: string;
            const Provincia: string;
            const ComunidadAutonomaId: string;
            const NacionId: string;
            const ProvinciaIsta: string;
            const DefectoIsta: string;
            const ComunidadAutonomaNacionId: string;
            const ComunidadAutonoma: string;
            const ComunidadAutonomaComunidadAutonomaIsta: string;
            const Nacion: string;
            const NacionDescCorta: string;
            const NacionMonedaId: string;
            const NacionIdiomaId: string;
            const NacionNumeroIne: string;
            const NacionPaisIsta: string;
            const NacionDefecto: string;
            const NacionNombreReal: string;
            const NacionIdiomaMails: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace ProvinciasService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ProvinciasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ProvinciasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ProvinciasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ProvinciasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
    class ReservaEstadosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservaEstadosForm {
        Estado: Serenity.StringEditor;
        EsErrorFechaini: Serenity.IntegerEditor;
        EsErrorFechafin: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Portal {
    interface ReservaEstadosRow {
        EstadoReservaId?: number;
        Estado?: string;
        EsErrorFechaini?: number;
        EsErrorFechafin?: number;
    }
    namespace ReservaEstadosRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ReservaEstadosRow>;
        namespace Fields {
            const EstadoReservaId: string;
            const Estado: string;
            const EsErrorFechaini: string;
            const EsErrorFechafin: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace ReservaEstadosService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ReservaEstadosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservaEstadosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservaEstadosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservaEstadosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class ServiciosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ServiciosForm {
        NombreServicio: Serenity.StringEditor;
        Abreviatura: Serenity.StringEditor;
        TipoServicioId: Serenity.LookupEditor;
        TipoUnidadCalculoId: Serenity.LookupEditor;
        SwProduccion: Serenity.BooleanEditor;
        SwDescuento: Serenity.BooleanEditor;
        SwAjustes: Serenity.BooleanEditor;
        SwGastos: Serenity.BooleanEditor;
        SwPension: Serenity.BooleanEditor;
        SwRectificativa: Serenity.BooleanEditor;
        ConceptoAceleradorReservasId: Serenity.LookupEditor;
        SumaServicioId: Serenity.LookupEditor;
        RestaServicioId: Serenity.LookupEditor;
        TipoHab: Serenity.LookupEditor;
        TipoPension: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Portal {
    interface ServiciosRow {
        ServicioId?: number;
        NombreServicio?: string;
        Abreviatura?: string;
        TipoServicioId?: number;
        SwProduccion?: boolean;
        SwDescuento?: boolean;
        SwAjustes?: boolean;
        SwGastos?: boolean;
        SwPension?: boolean;
        SwRectificativa?: boolean;
        TipoUnidadCalculoId?: number;
        ConceptoAceleradorReservasId?: number;
        Costo?: number;
        SumaServicioId?: number;
        RestaServicioId?: number;
        UserId?: number;
        FechaModificacion?: string;
        TipoHab?: number;
        TipoPension?: number;
        TipoServicioNombreTipoServicio?: string;
        Tipo_UC?: string;
        Concepto?: string;
        Suma?: string;
        Resta?: string;
        NombreTipoHab?: string;
        NombreTipoPension?: string;
    }
    namespace ServiciosRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<ServiciosRow>;
        namespace Fields {
            const ServicioId: string;
            const NombreServicio: string;
            const Abreviatura: string;
            const TipoServicioId: string;
            const SwProduccion: string;
            const SwDescuento: string;
            const SwAjustes: string;
            const SwGastos: string;
            const SwPension: string;
            const SwRectificativa: string;
            const TipoUnidadCalculoId: string;
            const ConceptoAceleradorReservasId: string;
            const Costo: string;
            const SumaServicioId: string;
            const RestaServicioId: string;
            const UserId: string;
            const FechaModificacion: string;
            const TipoHab: string;
            const TipoPension: string;
            const TipoServicioNombreTipoServicio: string;
            const Tipo_UC: string;
            const Concepto: string;
            const Suma: string;
            const Resta: string;
            const NombreTipoHab: string;
            const NombreTipoPension: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace ServiciosService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ServiciosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ServiciosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
    interface SexosRow {
        SexoId?: string;
        Sexo?: string;
    }
    namespace SexosRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<SexosRow>;
        namespace Fields {
            const SexoId: string;
            const Sexo: string;
        }
    }
}
declare namespace Geshotel.Portal {
    class TiposDocumentoForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposDocumentoForm {
        Documento: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposDocumentoRow {
        DocumentoId?: string;
        Documento?: string;
    }
    namespace TiposDocumentoRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposDocumentoRow>;
        namespace Fields {
            const DocumentoId: string;
            const Documento: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposDocumentoService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposDocumentoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposDocumentoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposDocumentoRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposDocumentoRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class TiposHabitacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposHabitacionForm {
        DescCorta: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
        GrupoHabitacionId: Serenity.LookupEditor;
        NumeroPersonas: Serenity.IntegerEditor;
        Desvios: Serenity.IntegerEditor;
        NoShow: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposHabitacionRow {
        TipoHabitacionId?: number;
        DescCorta?: string;
        Descripcion?: string;
        GrupoHabitacionId?: number;
        NumeroPersonas?: number;
        Desvios?: number;
        NoShow?: number;
        GrupoHabitacion?: string;
    }
    namespace TiposHabitacionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposHabitacionRow>;
        namespace Fields {
            const TipoHabitacionId: string;
            const DescCorta: string;
            const Descripcion: string;
            const GrupoHabitacionId: string;
            const NumeroPersonas: string;
            const Desvios: string;
            const NoShow: string;
            const GrupoHabitacion: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposHabitacionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposHabitacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposHabitacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposHabitacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposHabitacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class TiposHotelForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposHotelForm {
        TipoHotel: Serenity.StringEditor;
        Abreviatura: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposHotelRow {
        TipoHotelId?: number;
        TipoHotel?: string;
        Abreviatura?: string;
    }
    namespace TiposHotelRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposHotelRow>;
        namespace Fields {
            const TipoHotelId: string;
            const TipoHotel: string;
            const Abreviatura: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposHotelService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposHotelRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposHotelRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposHotelRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposHotelRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class TiposHuespedForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposHuespedForm {
        Descripcion: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        UcId: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposHuespedRow {
        TipoHuespedId?: number;
        Descripcion?: string;
        DescCorta?: string;
        UcId?: number;
        UcDescripcionUnidadCalculo?: string;
    }
    namespace TiposHuespedRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposHuespedRow>;
        namespace Fields {
            const TipoHuespedId: string;
            const Descripcion: string;
            const DescCorta: string;
            const UcId: string;
            const UcDescripcionUnidadCalculo: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposHuespedService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposHuespedRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposHuespedRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposHuespedRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposHuespedRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
    class TiposPensionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposPensionForm {
        TipoPension: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposPensionRow {
        TipoPensionId?: number;
        TipoPension?: string;
    }
    namespace TiposPensionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposPensionRow>;
        namespace Fields {
            const TipoPensionId: string;
            const TipoPension: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposPensionService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposPensionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposPensionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposPensionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposPensionRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class TiposServicioForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposServicioForm {
        NombreTipoServicio: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposServicioRow {
        TipoServicioId?: number;
        NombreTipoServicio?: string;
    }
    namespace TiposServicioRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposServicioRow>;
        namespace Fields {
            const TipoServicioId: string;
            const NombreTipoServicio: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposServicioService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposServicioRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposServicioRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposServicioRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposServicioRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class TiposUnidadCalculoForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposUnidadCalculoForm {
        Uc: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposUnidadCalculoRow {
        UnidadCalculoId?: number;
        Uc?: string;
    }
    namespace TiposUnidadCalculoRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<TiposUnidadCalculoRow>;
        namespace Fields {
            const UnidadCalculoId: string;
            const Uc: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposUnidadCalculoService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TiposUnidadCalculoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposUnidadCalculoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposUnidadCalculoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposUnidadCalculoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class UnidadesCalculoForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface UnidadesCalculoForm {
        Uc: Serenity.StringEditor;
        DescripcionUnidadCalculo: Serenity.StringEditor;
        TipoUnidadCalculoId: Serenity.LookupEditor;
        Pax: Serenity.BooleanEditor;
        ServicioId: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Portal {
    interface UnidadesCalculoRow {
        UnidadCalculoId?: number;
        Uc?: string;
        DescripcionUnidadCalculo?: string;
        TipoUnidadCalculoId?: number;
        Pax?: boolean;
        ServicioId?: number;
        TipoUc?: string;
        ServicioNombreServicio?: string;
    }
    namespace UnidadesCalculoRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<UnidadesCalculoRow>;
        namespace Fields {
            const UnidadCalculoId: string;
            const Uc: string;
            const DescripcionUnidadCalculo: string;
            const TipoUnidadCalculoId: string;
            const Pax: string;
            const ServicioId: string;
            const TipoUc: string;
            const ServicioNombreServicio: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace UnidadesCalculoService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<UnidadesCalculoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UnidadesCalculoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UnidadesCalculoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UnidadesCalculoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Portal {
    interface UsuariosEmpresaRow {
        UserId?: number;
        EmpresaId?: number;
        UserUsername?: string;
        UserDisplayName?: string;
        UserEmail?: string;
        UserSource?: string;
        UserPasswordHash?: string;
        UserPasswordSalt?: string;
        UserInsertDate?: string;
        UserInsertUserId?: number;
        UserUpdateDate?: string;
        UserUpdateUserId?: number;
        UserIsActive?: number;
        UserLastDirectoryUpdate?: string;
        UserUserImage?: string;
    }
    namespace UsuariosEmpresaRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserId: string;
            const EmpresaId: string;
            const UserUsername: string;
            const UserDisplayName: string;
            const UserEmail: string;
            const UserSource: string;
            const UserPasswordHash: string;
            const UserPasswordSalt: string;
            const UserInsertDate: string;
            const UserInsertUserId: string;
            const UserUpdateDate: string;
            const UserUpdateUserId: string;
            const UserIsActive: string;
            const UserLastDirectoryUpdate: string;
            const UserUserImage: string;
        }
    }
}
declare namespace Geshotel {
    interface ScriptUserDefinition {
        Username?: string;
        DisplayName?: string;
        IsAdmin?: boolean;
        Permissions?: {
            [key: string]: boolean;
        };
    }
}
declare namespace Geshotel {
    class BasicProgressDialog extends Serenity.TemplatedDialog<any> {
        constructor();
        cancelled: boolean;
        max: number;
        value: number;
        title: string;
        cancelTitle: string;
        getDialogOptions(): JQueryUI.DialogOptions;
        initDialog(): void;
        getTemplate(): string;
    }
}
declare namespace Geshotel.DialogUtils {
    function pendingChangesConfirmation(element: JQuery, hasPendingChanges: () => boolean): void;
}
declare namespace Geshotel.Common {
    class EnumSelectFormatter implements Slick.Formatter {
        constructor();
        format(ctx: Slick.FormatterContext): string;
        enumKey: string;
        allowClear: boolean;
        emptyItemText: string;
    }
}
declare namespace Geshotel.Common {
    interface ExcelExportOptions {
        grid: Serenity.DataGrid<any, any>;
        service: string;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
    }
    namespace ExcelExportHelper {
        function createToolButton(options: ExcelExportOptions): Serenity.ToolButton;
    }
}
declare namespace Geshotel.LanguageList {
    function getValue(): string[][];
}
declare namespace Geshotel.BasicSamples {
    class VSGalleryQAGrid extends Serenity.EntityGrid<BasicSamples.VSGalleryQAThread, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): any[];
        protected getSlickOptions(): Slick.GridOptions;
        protected getColumns(): Slick.Column[];
        protected getInitialTitle(): any;
    }
}
declare namespace Geshotel.BasicSamples {
    class ViewWithoutIDGrid extends Serenity.EntityGrid<Northwind.SalesByCategoryRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getNameProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private nextId;
        constructor(container: JQuery);
        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<Northwind.SalesByCategoryRow>): Serenity.ListResponse<Northwind.SalesByCategoryRow>;
        protected getButtons(): any[];
    }
}
declare namespace Geshotel.BasicSamples {
    class TreeGrid extends Northwind.OrderGrid {
        private treeMixin;
        constructor(container: JQuery);
        protected usePager(): boolean;
    }
}
declare namespace Geshotel.BasicSamples {
    class CustomerGrossSalesGrid extends Serenity.EntityGrid<CustomerGrossSalesRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getNameProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private nextId;
        constructor(container: JQuery);
        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<Northwind.SalesByCategoryRow>): Serenity.ListResponse<Northwind.SalesByCategoryRow>;
        protected getButtons(): any[];
        protected createSlickGrid(): Slick.Grid;
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Geshotel.BasicSamples {
    class RemovingAddButton extends Northwind.SupplierGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of buttons to be created.
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.BasicSamples {
    class QuickFilterCustomization extends Serenity.EntityGrid<Northwind.OrderRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof Northwind.OrderDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        /**
         * This method is called to get list of quick filters to be created for this grid.
         * By default, it returns quick filter objects corresponding to properties that
         * have a [QuickFilter] attribute at server side OrderColumns.cs
         */
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Geshotel.BasicSamples {
    class ProductExcelImportDialog extends Serenity.PropertyDialog<any, any> {
        private form;
        constructor();
        protected getDialogTitle(): string;
        protected getDialogButtons(): Serenity.DialogButton[];
    }
}
declare namespace Geshotel.BasicSamples {
    class ProductExcelImportGrid extends Northwind.ProductGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of buttons to be created.
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.BasicSamples {
    class InlineImageFormatter implements Slick.Formatter, Serenity.IInitializeColumn {
        format(ctx: Slick.FormatterContext): string;
        initializeColumn(column: Slick.Column): void;
        fileProperty: string;
        thumb: boolean;
    }
}
declare namespace Geshotel.BasicSamples {
    class InlineImageInGrid extends Serenity.EntityGrid<Northwind.ProductRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
    }
}
declare namespace Geshotel.BasicSamples {
    class InlineActionGrid extends Northwind.CustomerGrid {
        constructor(container: JQuery);
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace Geshotel.BasicSamples {
    class InitialValuesForQuickFilters extends Northwind.OrderGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of quick filters to be created for this grid.
         * By default, it returns quick filter objects corresponding to properties that
         * have a [QuickFilter] attribute at server side OrderColumns.cs
         */
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        /**
         * This method is another possible place to modify quick filter widgets.
         * It is where the quick filter widgets are actually created.
         *
         * By default, it calls getQuickFilters() then renders UI for these
         * quick filters.
         *
         * We could use getQuickFilters() method for ShipVia too,
         * but this is for demonstration purposes
         */
        protected createQuickFilters(): void;
    }
}
declare namespace Geshotel.BasicSamples {
    class GroupingAndSummariesInGrid extends Northwind.ProductGrid {
        constructor(container: JQuery);
        protected createSlickGrid(): Slick.Grid;
        protected getColumns(): Slick.Column[];
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
    }
}
declare namespace Geshotel.BasicSamples {
    class GridFilteredByCriteria extends Northwind.ProductGrid {
        constructor(container: JQuery);
        protected onViewSubmit(): boolean;
    }
}
declare namespace Geshotel {
    class SelectableEntityGrid<TItem, TOptions> extends Serenity.EntityGrid<TItem, TOptions> {
        protected getSlickOptions(): Slick.GridOptions;
        protected createSlickGrid(): Slick.Grid;
    }
}
declare namespace Geshotel.BasicSamples {
    class RowSelectionGrid extends SelectableEntityGrid<Northwind.SupplierRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    class DragDropSampleDialog extends Serenity.EntityDialog<DragDropSampleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: DragDropSampleForm;
    }
}
declare namespace Geshotel.BasicSamples {
    class DragDropSampleGrid extends Serenity.EntityGrid<DragDropSampleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DragDropSampleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private dragging;
        constructor(container: JQuery);
        /**
         * This method will determine if item can be moved under a given target
         * An item can't be moved under itself, under one of its children
         */
        private canMoveUnder(item, target);
        /**
         * Gets children list of an item
         */
        private getChildren(item);
        /**
         * Gets all parents of an item
         */
        private getParents(item);
        protected getButtons(): any[];
        protected usePager(): boolean;
    }
}
declare namespace Geshotel.BasicSamples {
    class CustomLinksInGrid extends Northwind.OrderGrid {
        constructor(container: JQuery);
        /**
         * We override getColumns() to change format functions for some columns.
         * You could also write them as formatter classes, and use them at server side
         */
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        /**
         * This method is called for columns with [EditLink] attribute,
         * but only for edit links of this grid's own item type.
         * It is also called by Add Product button with a NULL entityOrId
         * parameter so we should check that entityOrId is a string
         * to be sure it is originating from a link.
         *
         * As we changed format for other columns, this will only be called
         * for links in remaining OrderID column
         */
        protected editItem(entityOrId: any): void;
    }
}
declare namespace Geshotel.BasicSamples {
    class ConditionalFormattingGrid extends Serenity.EntityGrid<Northwind.ProductRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        /**
         * We override getColumns() to be able to add a custom CSS class to UnitPrice
         * We could also add this class in ProductColumns.cs but didn't want to modify
         * it solely for this sample.
         */
        protected getColumns(): Slick.Column[];
        /**
         * This method is called for all rows
         * @param item Data item for current row
         * @param index Index of the row in grid
         */
        protected getItemCssClass(item: Northwind.ProductRow, index: number): string;
    }
}
declare namespace Geshotel.BasicSamples {
    class CancellableBulkActionGrid extends Northwind.OrderGrid {
        private rowSelection;
        constructor(container: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
        protected getColumns(): Slick.Column[];
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace Geshotel {
    /**
     * This is an editor widget but it only displays a text, not edits it.
     *
     */
    class StaticTextBlock extends Serenity.Widget<StaticTextBlockOptions> implements Serenity.ISetEditValue {
        private value;
        constructor(container: JQuery, options: StaticTextBlockOptions);
        private updateElementContent();
        /**
         * By implementing ISetEditValue interface, we allow this editor to display its field value.
         * But only do this when our text content is not explicitly set in options
         */
        setEditValue(source: any, property: Serenity.PropertyItem): void;
    }
    interface StaticTextBlockOptions {
        text: string;
        isHtml: boolean;
        isLocalText: boolean;
        hideLabel: boolean;
    }
}
declare namespace Geshotel.BasicSamples {
    class StaticTextBlockDialog extends Serenity.PropertyDialog<any, any> {
        protected getFormKey(): string;
        protected form: StaticTextBlockForm;
        constructor();
        /**
         * Here we override loadInitialEntity method to set value for "DisplayFieldValue" field.
         * If this was an EntityDialog, your field value would be originating from server side entity.
         */
        protected loadInitialEntity(): void;
        protected getDialogOptions(): JQueryUI.DialogOptions;
    }
}
declare namespace Geshotel.BasicSamples {
    class HardcodedValuesDialog extends Serenity.PropertyDialog<any, any> {
        protected getFormKey(): string;
        protected form: HardcodedValuesForm;
        constructor();
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class HardcodedValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * This is our custom product dialog that uses a different product form
     * (LookupFilterByMultipleForm) with our special category editor.
     */
    class LookupFilterByMultipleDialog extends Northwind.ProductDialog {
        protected getFormKey(): string;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
     */
    class LookupFilterByMultipleGrid extends Northwind.ProductGrid {
        protected getDialogType(): typeof LookupFilterByMultipleDialog;
        constructor(container: JQuery);
        /**
         * This method is called just before List request is sent to service.
         * You have an opportunity here to cancel request or modify it.
         * Here we'll add a custom criteria to list request.
         */
        protected onViewSubmit(): boolean;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * This is our category editor that will show only categories of Produce and
     * Seafood. We are subclassing LookupEditorBase which also LookupEditor
     * derives from.
     *
     * After compiling and transforming templates, this editor type will be
     * available in server side to use in our LookupFilterByMultipleForm,
     * which is a version of ProductForm that uses our custom editor.
     */
    class ProduceSeafoodCategoryEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, Northwind.CategoryRow> {
        constructor(container: JQuery, opt: Serenity.LookupEditorOptions);
        /**
         * Normally LookupEditor requires a lookup key to determine which set of
         * lookup data to show in editor. As our editor will only show category
         * data, we lock it to category lookup key.
         */
        protected getLookupKey(): string;
        /**
         * Here we are filtering by category name but you could filter by any field.
         * Just make sure the fields you filter on has [LookupInclude] attribute on them,
         * otherwise their value will be null in client side as they are not sent back
         * from server in lookup script.
         */
        protected getItems(lookup: Q.Lookup<Northwind.CategoryRow>): Northwind.CategoryRow[];
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Our subclass of Order Details editor with a CategoryID property
     */
    class FilteredLookupDetailEditor extends Northwind.OrderDetailsEditor {
        protected getDialogType(): typeof FilteredLookupOrderDetailDialog;
        constructor(container: JQuery);
        categoryID: number;
        /**
         * This method is called to initialize an edit dialog created by
         * grid editor when Add button or an edit link is clicked
         * We have an opportunity here to pass CategoryID to edit dialog
         */
        protected initEntityDialog(itemType: string, dialog: Serenity.Widget<any>): void;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Basic order dialog with a category selection
     */
    class FilteredLookupInDetailDialog extends Serenity.EntityDialog<Northwind.OrderRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        private form;
        constructor();
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to FilteredLookupInDetailDialog
     */
    class FilteredLookupInDetailGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof FilteredLookupInDetailDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Our subclass of order detail dialog with a CategoryID property
     * that will be used to set CascadeValue of product editor
     */
    class FilteredLookupOrderDetailDialog extends Northwind.OrderDetailDialog {
        constructor();
        /**
         * This method is called just before an entity is loaded to dialog
         * This is also called for new record mode with an empty entity
         */
        protected beforeLoadEntity(entity: any): void;
        categoryID: number;
    }
}
declare namespace Geshotel.BasicSamples {
    class ChangingLookupTextDialog extends Common.GridEditorDialog<Northwind.OrderDetailRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: ChangingLookupTextForm;
        constructor();
        protected updateInterface(): void;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Our custom product editor type
     */
    class ChangingLookupTextEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, Northwind.ProductRow> {
        constructor(container: JQuery, options: Serenity.LookupEditorOptions);
        protected getLookupKey(): string;
        protected getItemText(item: Northwind.ProductRow, lookup: Q.Lookup<Northwind.ProductRow>): string;
    }
}
declare namespace Geshotel.BasicSamples {
    class SerialAutoNumberDialog extends Northwind.CustomerDialog {
        constructor();
        protected afterLoadEntity(): void;
        private getNextNumber();
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of CustomerGrid to override dialog type to SerialAutoNumberDialog
     */
    class SerialAutoNumberGrid extends Northwind.CustomerGrid {
        protected getDialogType(): typeof SerialAutoNumberDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Adding Responsive attribute makes this dialog use full screen in mobile devices.
     */
    class ResponsiveDialog extends Serenity.EntityDialog<Northwind.OrderRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        constructor();
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to ResponsiveDialog
     */
    class ResponsiveGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof ResponsiveDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    class ReadOnlyDialog extends Northwind.SupplierDialog {
        /**
         * This is the method that gets list of tool
         * buttons to be created in a dialog.
         *
         * Here we'll remove save and close button, and
         * apply changes buttons.
         */
        protected getToolbarButtons(): Serenity.ToolButton[];
        /**
         * This method is a good place to update states of
         * interface elements. It is called after dialog
         * is initialized and an entity is loaded into dialog.
         * This is also called in new item mode.
         */
        protected updateInterface(): void;
        /**
         * This method is called when dialog title needs to be updated.
         * Base class returns something like 'Edit xyz' for edit mode,
         * and 'New xyz' for new record mode.
         *
         * But our dialog is readonly, so we should change it to 'View xyz'
         */
        protected getEntityTitle(): string;
        /**
         * This method is actually the one that calls getEntityTitle()
         * and updates the dialog title. We could do it here too...
         */
        protected updateTitle(): void;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * A readonly grid that launches ReadOnlyDialog
     */
    class ReadOnlyGrid extends Northwind.SupplierGrid {
        protected getDialogType(): typeof ReadOnlyDialog;
        constructor(container: JQuery);
        /**
         * Removing add button from grid using its css class
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.BasicSamples {
    class PopulateLinkedDataDialog extends Serenity.EntityDialog<Northwind.OrderRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: PopulateLinkedDataForm;
        constructor();
        private setCustomerDetails(details);
        /**
         * This dialog will have CSS class "s-PopulateLinkedDataDialog"
         * We are changing it here to "s-OrderDialog", to make it use default OrderDialog styles
         * This has no effect other than looks on populate linked data demonstration
         */
        protected getCssClass(): string;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * A subclass of OrderGrid that launches PopulateLinkedDataDialog
     */
    class PopulateLinkedDataGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof PopulateLinkedDataDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Our custom order dialog subclass that will have a tab to display and edit selected customer details.
     * With single toolbar for all forms
     */
    class OtherFormInTabOneBarDialog extends Northwind.OrderDialog {
        private customerPropertyGrid;
        private customerForm;
        private customerValidator;
        private selfChange;
        constructor();
        getCustomerID(): number;
        loadEntity(entity: Northwind.OrderRow): void;
        protected saveCustomer(callback: (response: Serenity.SaveResponse) => void, onSuccess?: (response: Serenity.SaveResponse) => void): boolean;
        protected saveOrder(callback: (response: Serenity.SaveResponse) => void): void;
        protected saveAll(callback: (response: Serenity.SaveResponse) => void): void;
        protected save(callback: (response: Serenity.SaveResponse) => void): void;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to OtherFormInTabOneBarDialog
     */
    class OtherFormInTabOneBarGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof OtherFormInTabOneBarDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Our custom order dialog subclass that will have a tab to display and edit selected customer details.
     */
    class OtherFormInTabDialog extends Northwind.OrderDialog {
        private customerPropertyGrid;
        private customerForm;
        private customerValidator;
        constructor();
        getCustomerID(): number;
        loadEntity(entity: Northwind.OrderRow): void;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to OtherFormInTabDialog
     */
    class OtherFormInTabGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof OtherFormInTabDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Styling for columns is done with CSS in site.basicsamples.less file.
     * When comparing this to MultiColumnDialog sample, you may notice that
     * this version requires much less JS and CSS code.
     */
    class MultiColumnResponsiveDialog extends Northwind.OrderDialog {
        constructor();
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to MultiColumnResponsiveDialog
     */
    class MultiColumnResponsiveGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof MultiColumnResponsiveDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    class GetInsertedRecordIdDialog extends Northwind.CategoryDialog {
        /**
         * This method is called after the save request to service
         * is completed succesfully. This can be an insert or update.
         *
         * @param response Response that is returned from server
         */
        protected onSaveSuccess(response: Serenity.SaveResponse): void;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of CategoryGrid to override dialog type to GetInsertedRecordIdDialog
     */
    class GetInsertedRecordIdGrid extends Northwind.CategoryGrid {
        protected getDialogType(): typeof GetInsertedRecordIdDialog;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * A version of order dialog converted to a panel by adding Serenity.Decorators.panel decorator.
     */
    class EntityDialogAsPanel extends Northwind.OrderDialog {
        constructor();
    }
}
declare namespace Geshotel.BasicSamples.DialogBoxes {
    function initializePage(): void;
}
declare namespace Geshotel.BasicSamples {
    class DefaultValuesInNewGrid extends Northwind.OrderGrid {
        constructor(container: JQuery);
        /**
         * This method is called when New Item button is clicked.
         * By default, it calls EditItem with an empty entity.
         * This is a good place to fill in default values for New Item button.
         */
        protected addButtonClick(): void;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.BasicSamples {
    class CloneableEntityDialog extends Northwind.ProductDialog {
        protected updateInterface(): void;
        /**
         * Overriding this method is optional to customize cloned entity
         */
        protected getCloningEntity(): Northwind.ProductRow;
    }
}
declare namespace Geshotel.BasicSamples {
    /**
     * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
     */
    class CloneableEntityGrid extends Northwind.ProductGrid {
        protected getDialogType(): typeof CloneableEntityDialog;
        constructor(container: JQuery);
    }
}
declare var Morris: any;
declare namespace Geshotel.BasicSamples {
    class ChartInDialog extends Serenity.TemplatedDialog<any> {
        private areaChart;
        static initializePage(): void;
        protected onDialogOpen(): void;
        protected arrange(): void;
        protected getTemplate(): string;
        protected getDialogOptions(): JQueryUI.DialogOptions;
    }
}
declare namespace Geshotel.Administration {
    class RoleCheckEditor extends Serenity.CheckTreeEditor<Serenity.CheckTreeItem<any>, any> {
        private searchText;
        constructor(div: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): any[];
        protected getTreeItems(): Serenity.CheckTreeItem<any>[];
        protected onViewFilter(item: any): boolean;
    }
}
declare namespace Geshotel.Administration {
    class UserRoleDialog extends Serenity.TemplatedDialog<UserRoleDialogOptions> {
        private permissions;
        constructor(opt: UserRoleDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserRoleDialogOptions {
        userID: number;
        username: string;
    }
}
declare namespace Geshotel.Administration {
    class PermissionCheckEditor extends Serenity.DataGrid<PermissionCheckItem, PermissionCheckEditorOptions> {
        protected getIdProperty(): string;
        private searchText;
        private byParentKey;
        private rolePermissions;
        constructor(container: JQuery, opt: PermissionCheckEditorOptions);
        private getItemGrantRevokeClass(item, grant);
        private getItemEffectiveClass(item);
        protected getColumns(): Slick.Column[];
        setItems(items: PermissionCheckItem[]): void;
        protected onViewSubmit(): boolean;
        protected onViewFilter(item: PermissionCheckItem): boolean;
        private matchContains(item);
        private getDescendants(item, excludeGroups);
        protected onClick(e: any, row: any, cell: any): void;
        private getParentKey(key);
        protected getButtons(): Serenity.ToolButton[];
        protected createToolbarExtensions(): void;
        private getSortedGroupAndPermissionKeys(titleByKey);
        get_value(): UserPermissionRow[];
        set_value(value: UserPermissionRow[]): void;
        get_rolePermissions(): string[];
        set_rolePermissions(value: string[]): void;
    }
    interface PermissionCheckEditorOptions {
        showRevoke?: boolean;
    }
    interface PermissionCheckItem {
        ParentKey?: string;
        Key?: string;
        Title?: string;
        IsGroup?: boolean;
        GrantRevoke?: boolean;
    }
}
declare namespace Geshotel.Administration {
    class UserPermissionDialog extends Serenity.TemplatedDialog<UserPermissionDialogOptions> {
        private permissions;
        constructor(opt: UserPermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserPermissionDialogOptions {
        userID?: number;
        username?: string;
    }
}
declare namespace Geshotel.Administration {
    class EmpresasListFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace Geshotel.Administration {
    class UserDialog extends Serenity.EntityDialog<UserRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: UserForm;
        constructor();
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
        protected afterLoadEntity(): void;
    }
}
declare namespace Geshotel.Administration {
    class UserGrid extends Serenity.EntityGrid<UserRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDialog;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
    }
}
declare namespace Geshotel.Authorization {
    let userDefinition: ScriptUserDefinition;
    function hasPermission(permissionKey: string): boolean;
}
declare namespace Geshotel.Administration {
    class TranslationGrid extends Serenity.EntityGrid<TranslationItem, any> {
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private hasChanges;
        private searchText;
        private sourceLanguage;
        private targetLanguage;
        private targetLanguageKey;
        constructor(container: JQuery);
        protected onClick(e: JQueryEventObject, row: number, cell: number): any;
        protected getColumns(): Slick.Column[];
        protected createToolbarExtensions(): void;
        protected saveChanges(language: string): RSVP.Promise<any>;
        protected onViewSubmit(): boolean;
        protected getButtons(): Serenity.ToolButton[];
        protected createQuickSearchInput(): void;
        protected onViewFilter(item: TranslationItem): boolean;
        protected usePager(): boolean;
    }
}
declare namespace Geshotel.Administration {
    class RolePermissionDialog extends Serenity.TemplatedDialog<RolePermissionDialogOptions> {
        private permissions;
        constructor(opt: RolePermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface RolePermissionDialogOptions {
        roleID?: number;
        title?: string;
    }
}
declare namespace Geshotel.Administration {
    class RoleDialog extends Serenity.EntityDialog<RoleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: RoleForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
    }
}
declare namespace Geshotel.Administration {
    class RoleGrid extends Serenity.EntityGrid<RoleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof RoleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
    }
}
declare namespace Geshotel.Administration {
    class LanguageDialog extends Serenity.EntityDialog<LanguageRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: LanguageForm;
    }
}
declare namespace Geshotel.Administration {
    class LanguageGrid extends Serenity.EntityGrid<LanguageRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LanguageDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
    }
}