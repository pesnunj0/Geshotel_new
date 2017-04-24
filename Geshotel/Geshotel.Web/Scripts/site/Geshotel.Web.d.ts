/// <reference types="jqueryui" />
/// <reference types="jquery" />
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
declare namespace Geshotel.Authorization {
    let userDefinition: ScriptUserDefinition;
    function hasPermission(permissionKey: string): boolean;
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
declare namespace Geshotel.LanguageList {
    function getValue(): string[][];
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
        const idProperty = "Id";
        const nameProperty = "LanguageName";
        const localTextPrefix = "Administration.Language";
        const lookupKey = "Administration.Languaje";
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
        const baseUrl = "Administration/Language";
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
        const idProperty = "RolePermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.RolePermission";
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
        const baseUrl = "Administration/RolePermission";
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
        const idProperty = "RoleId";
        const nameProperty = "RoleName";
        const localTextPrefix = "Administration.Role";
        const lookupKey = "Administration.Role";
        function getLookup(): Q.Lookup<RoleRow>;
        namespace Fields {
            const RoleId: string;
            const RoleName: string;
        }
    }
}
declare namespace Geshotel.Administration {
    namespace RoleService {
        const baseUrl = "Administration/Role";
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
        const baseUrl = "Administration/Translation";
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
        const idProperty = "UserPermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.UserPermission";
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
        const baseUrl = "Administration/UserPermission";
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
        const idProperty = "UserRoleId";
        const localTextPrefix = "Administration.UserRole";
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
        const baseUrl = "Administration/UserRole";
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
        const idProperty = "UserId";
        const isActiveProperty = "IsActive";
        const nameProperty = "Username";
        const localTextPrefix = "Administration.User";
        const lookupKey = "Administration.User";
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
        const baseUrl = "Administration/User";
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
        const idProperty = "UserPreferenceId";
        const nameProperty = "Name";
        const localTextPrefix = "Common.UserPreference";
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
        const baseUrl = "Common/UserPreference";
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
}
declare namespace Geshotel.Contratos {
    class AgenciasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface AgenciasForm {
        Razon: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        GrupoClienteId: Serenity.LookupEditor;
        TipoDocumentoId: Serenity.LookupEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
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
        UserId: Serenity.LookupEditor;
        FechaModificacion: Serenity.DateEditor;
        ClienteBavel: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface AgenciasRow {
        ClienteId?: number;
        Razon?: string;
        DescCorta?: string;
        EmpresaId?: number;
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
        TipoDocumento?: string;
        Nacion?: string;
        Provincia?: string;
        FacturaNacion?: string;
        FacturaProvincia?: string;
        UserName?: string;
    }
    namespace AgenciasRow {
        const idProperty = "ClienteId";
        const nameProperty = "Razon";
        const localTextPrefix = "Contratos.Agencias";
        const lookupKey = "Contratos.Agencias";
        function getLookup(): Q.Lookup<AgenciasRow>;
        namespace Fields {
            const ClienteId: string;
            const Razon: string;
            const DescCorta: string;
            const EmpresaId: string;
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
            const TipoDocumento: string;
            const Nacion: string;
            const Provincia: string;
            const FacturaNacion: string;
            const FacturaProvincia: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace AgenciasService {
        const baseUrl = "Contratos/Agencias";
        function Create(request: Serenity.SaveRequest<AgenciasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AgenciasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AgenciasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AgenciasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class CajasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface CajasForm {
        HotelId: Serenity.LookupEditor;
        NombreCaja: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        CierreDia: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface CajasRow {
        CajaId?: number;
        HotelId?: number;
        NombreCaja?: string;
        DescCorta?: string;
        CierreDia?: boolean;
        CtaContable?: string;
        DptoContable?: string;
        UserId?: number;
        FechaModificacion?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        UserName?: string;
    }
    namespace CajasRow {
        const idProperty = "CajaId";
        const nameProperty = "NombreCaja";
        const localTextPrefix = "Contratos.Cajas";
        const lookupKey = "Contratos.Cajas";
        function getLookup(): Q.Lookup<CajasRow>;
        namespace Fields {
            const CajaId: string;
            const HotelId: string;
            const NombreCaja: string;
            const DescCorta: string;
            const CierreDia: string;
            const CtaContable: string;
            const DptoContable: string;
            const UserId: string;
            const FechaModificacion: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace CajasService {
        const baseUrl = "Contratos/Cajas";
        function Create(request: Serenity.SaveRequest<CajasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CajasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CajasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CajasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class CanalesReservaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface CanalesReservaForm {
        EmpresaId: Serenity.LookupEditor;
        NombreCanal: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface CanalesReservaRow {
        CanalReservaId?: number;
        EmpresaId?: number;
        NombreCanal?: string;
        Empresa?: string;
    }
    namespace CanalesReservaRow {
        const idProperty = "CanalReservaId";
        const nameProperty = "NombreCanal";
        const localTextPrefix = "Contratos.CanalesReserva";
        const lookupKey = "Contratos.CanalesReserva";
        function getLookup(): Q.Lookup<CanalesReservaRow>;
        namespace Fields {
            const CanalReservaId: string;
            const EmpresaId: string;
            const NombreCanal: string;
            const Empresa: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace CanalesReservaService {
        const baseUrl = "Contratos/CanalesReserva";
        function Create(request: Serenity.SaveRequest<CanalesReservaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CanalesReservaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CanalesReservaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CanalesReservaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
        Email: Serenity.EmailEditor;
        Fax: Serenity.StringEditor;
        Contacto: Serenity.StringEditor;
        TelefonoContacto: Serenity.StringEditor;
        FaxContacto: Serenity.StringEditor;
        EmailContacto: Serenity.EmailEditor;
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
        TipoDocumento?: string;
        Nacion?: string;
        Provincia?: string;
        FacturaNacion?: string;
        FacturaProvincia?: string;
        UserName?: string;
    }
    namespace ClientesRow {
        const idProperty = "ClienteId";
        const nameProperty = "Razon";
        const localTextPrefix = "Contratos.Clientes";
        const lookupKey = "Contratos.ClientesAgencia";
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
            const TipoDocumento: string;
            const Nacion: string;
            const Provincia: string;
            const FacturaNacion: string;
            const FacturaProvincia: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace ClientesService {
        const baseUrl = "Contratos/Clientes";
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
}
declare namespace Geshotel.Contratos {
    class ContadoresForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ContadoresForm {
        EmpresaId: Serenity.IntegerEditor;
        SerieId: Serenity.IntegerEditor;
        Ano: Serenity.IntegerEditor;
        Contador: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface ContadoresRow {
        ContadorId?: number;
        EmpresaId?: number;
        SerieId?: number;
        Ano?: number;
        Contador?: number;
    }
    namespace ContadoresRow {
        const idProperty = "ContadorId";
        const localTextPrefix = "Contratos.Contadores";
        namespace Fields {
            const ContadorId: string;
            const EmpresaId: string;
            const SerieId: string;
            const Ano: string;
            const Contador: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace ContadoresService {
        const baseUrl = "Contratos/Contadores";
        function Create(request: Serenity.SaveRequest<ContadoresRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ContadoresRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ContadoresRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ContadoresRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class ContratosEdadesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ContratosEdadesForm {
        TipoHuespedId: Serenity.IntegerEditor;
        EdadMinima: Serenity.IntegerEditor;
        EdadMaxima: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface ContratosEdadesRow {
        ContratoId?: number;
        TipoHuespedId?: number;
        EdadMinima?: number;
        EdadMaxima?: number;
        UserId?: number;
    }
    namespace ContratosEdadesRow {
        const idProperty = "ContratoId";
        const localTextPrefix = "Contratos.ContratosEdades";
        namespace Fields {
            const ContratoId: any;
            const TipoHuespedId: any;
            const EdadMinima: any;
            const EdadMaxima: any;
            const UserId: any;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace ContratosEdadesService {
        const baseUrl = "Contratos/ContratosEdades";
        function Create(request: Serenity.SaveRequest<ContratosEdadesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ContratosEdadesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ContratosEdadesRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ContratosEdadesRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
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
    class ContratosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ContratosForm {
        HotelId: Serenity.LookupEditor;
        ClienteId: Serenity.LookupEditor;
        FechaContrato: Serenity.DateEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        NumeroContratoCliente: Serenity.StringEditor;
        TemporadaId: Serenity.LookupEditor;
        ImpuestoIncluido: Serenity.BooleanEditor;
        MercadoId: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface ContratosRow {
        ContratoId?: number;
        HotelId?: number;
        ClienteId?: number;
        FechaContrato?: string;
        FechaDesde?: string;
        FechaHasta?: string;
        NumeroContratoCliente?: string;
        UserId?: number;
        FechaModificacion?: string;
        TemporadaId?: number;
        ImpuestoIncluido?: boolean;
        MercadoId?: number;
        HotelName?: string;
        Touroperador?: string;
        EmpresaId?: number;
        Empresa?: string;
        Mercado?: string;
        Temporada?: string;
        UserName?: string;
    }
    namespace ContratosRow {
        const idProperty = "ContratoId";
        const nameProperty = "Touroperador";
        const localTextPrefix = "Contratos.Contratos";
        const lookupKey = "Contratos.Contratos]";
        function getLookup(): Q.Lookup<ContratosRow>;
        namespace Fields {
            const ContratoId: string;
            const HotelId: string;
            const ClienteId: string;
            const FechaContrato: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const NumeroContratoCliente: string;
            const UserId: string;
            const FechaModificacion: string;
            const TemporadaId: string;
            const ImpuestoIncluido: string;
            const MercadoId: string;
            const HotelName: string;
            const Touroperador: string;
            const EmpresaId: string;
            const Empresa: string;
            const Mercado: string;
            const Temporada: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace ContratosService {
        const baseUrl = "Contratos/Contratos";
        function Create(request: Serenity.SaveRequest<ContratosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ContratosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ContratosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ContratosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class CuposForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface CuposForm {
        ClienteId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        Cupo: Serenity.IntegerEditor;
        Garantia: Serenity.DecimalEditor;
        ReservaAutomatica: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface CuposRow {
        CupoId?: number;
        ClienteId?: number;
        HotelId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        TipoHabitacionId?: number;
        Garantia?: number;
        ReservaAutomatica?: boolean;
        Cupo?: number;
        UserId?: number;
        FechaModificacion?: string;
        ClienteRazon?: string;
        ClienteDescCorta?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        TipoHabitacionDescCorta?: string;
        TipoHabitacionDescripcion?: string;
        UserName?: string;
    }
    namespace CuposRow {
        const idProperty = "CupoId";
        const localTextPrefix = "Contratos.Cupos";
        const lookupKey = "Contratos.Cupos";
        function getLookup(): Q.Lookup<CuposRow>;
        namespace Fields {
            const CupoId: string;
            const ClienteId: string;
            const HotelId: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const TipoHabitacionId: string;
            const Garantia: string;
            const ReservaAutomatica: string;
            const Cupo: string;
            const UserId: string;
            const FechaModificacion: string;
            const ClienteRazon: string;
            const ClienteDescCorta: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
            const TipoHabitacionDescCorta: string;
            const TipoHabitacionDescripcion: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace CuposService {
        const baseUrl = "Contratos/Cupos";
        function Create(request: Serenity.SaveRequest<CuposRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CuposRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CuposRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CuposRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class EdadesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface EdadesForm {
        HotelId: Serenity.LookupEditor;
        ClienteId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoHuespedId: Serenity.LookupEditor;
        EdadMinima: Serenity.IntegerEditor;
        EdadMaxima: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface EdadesRow {
        EdadesId?: number;
        HotelId?: number;
        ClienteId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        TipoHuespedId?: number;
        EdadMinima?: number;
        EdadMaxima?: number;
        UserId?: number;
        FechaModificacion?: string;
        HotelName?: string;
        Touroperador?: string;
        EmpresaId?: number;
        Empresa?: string;
        UserName?: string;
        TipoHuesped?: string;
    }
    namespace EdadesRow {
        const idProperty = "EdadesId";
        const nameProperty = "Touroperador";
        const localTextPrefix = "Contratos.ContratosEdades";
        namespace Fields {
            const EdadesId: string;
            const HotelId: string;
            const ClienteId: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const TipoHuespedId: string;
            const EdadMinima: string;
            const EdadMaxima: string;
            const UserId: string;
            const FechaModificacion: string;
            const HotelName: string;
            const Touroperador: string;
            const EmpresaId: string;
            const Empresa: string;
            const UserName: string;
            const TipoHuesped: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace EdadesService {
        const baseUrl = "Contratos/Edades";
        function Create(request: Serenity.SaveRequest<EdadesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<EdadesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<EdadesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<EdadesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class HabitacionesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface HabitacionesForm {
        HotelId: Serenity.LookupEditor;
        NumeroHabitacion: Serenity.StringEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        Extension: Serenity.IntegerEditor;
        Observaciones: Serenity.StringEditor;
        SituacionId: Serenity.LookupEditor;
        FechaInicio: Serenity.DateEditor;
        EstadoTelefono: Serenity.IntegerEditor;
        EstadoProcesado: Serenity.IntegerEditor;
        HabitacionIsta: Serenity.StringEditor;
        ZonaLimpiezaId: Serenity.IntegerEditor;
        Lat: Serenity.DecimalEditor;
        Lng: Serenity.DecimalEditor;
        PrimaryImage: Serenity.StringEditor;
        Galleryimages: Serenity.StringEditor;
        Planta: Serenity.IntegerEditor;
        UserId: Serenity.LookupEditor;
        FechaModificacion: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface HabitacionesRow {
        HabitacionId?: number;
        HotelId?: number;
        NumeroHabitacion?: string;
        TipoHabitacionId?: number;
        Extension?: number;
        Observaciones?: string;
        SituacionId?: number;
        FechaInicio?: string;
        EstadoTelefono?: number;
        EstadoProcesado?: number;
        HabitacionIsta?: string;
        ZonaLimpiezaId?: number;
        Lat?: number;
        Lng?: number;
        PrimaryImage?: string;
        Galleryimages?: string;
        Planta?: number;
        UserId?: number;
        FechaModificacion?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        UserName?: string;
        TipoHabitacionDescCorta?: string;
        TipoHabitacionName?: string;
        Situacion?: string;
        ZonaLimpiezaNombreZona?: string;
    }
    namespace HabitacionesRow {
        const idProperty = "HabitacionId";
        const nameProperty = "NumeroHabitacion";
        const localTextPrefix = "Contratos.Habitaciones";
        const lookupKey = "Contratos.Habitaciones";
        function getLookup(): Q.Lookup<HabitacionesRow>;
        namespace Fields {
            const HabitacionId: string;
            const HotelId: string;
            const NumeroHabitacion: string;
            const TipoHabitacionId: string;
            const Extension: string;
            const Observaciones: string;
            const SituacionId: string;
            const FechaInicio: string;
            const EstadoTelefono: string;
            const EstadoProcesado: string;
            const HabitacionIsta: string;
            const ZonaLimpiezaId: string;
            const Lat: string;
            const Lng: string;
            const PrimaryImage: string;
            const Galleryimages: string;
            const Planta: string;
            const UserId: string;
            const FechaModificacion: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
            const UserName: string;
            const TipoHabitacionDescCorta: string;
            const TipoHabitacionName: string;
            const Situacion: string;
            const ZonaLimpiezaNombreZona: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace HabitacionesService {
        const baseUrl = "Contratos/Habitaciones";
        function Create(request: Serenity.SaveRequest<HabitacionesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<HabitacionesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<HabitacionesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<HabitacionesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class LineasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface LineasForm {
        ContratoId: Serenity.IntegerEditor;
        HotelId: Serenity.LookupEditor;
        Desde: Serenity.DateEditor;
        Hasta: Serenity.DateEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        FrecuenciaId: Serenity.LookupEditor;
        TipoImputacionId: Serenity.LookupEditor;
        Importe: Serenity.DecimalEditor;
        Lunes: Serenity.BooleanEditor;
        Martes: Serenity.BooleanEditor;
        Miercoles: Serenity.BooleanEditor;
        Jueves: Serenity.BooleanEditor;
        Viernes: Serenity.BooleanEditor;
        Sabado: Serenity.BooleanEditor;
        Domingo: Serenity.BooleanEditor;
        PagFactura: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface LineasRow {
        LineaContratoId?: number;
        ContratoId?: number;
        Oferta?: boolean;
        Desde?: string;
        Hasta?: string;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FrecuenciaId?: number;
        TipoImputacionId?: number;
        Importe?: number;
        TipoServicioId?: number;
        Lunes?: boolean;
        Martes?: boolean;
        Miercoles?: boolean;
        Jueves?: boolean;
        Viernes?: boolean;
        Sabado?: boolean;
        Domingo?: boolean;
        PagFactura?: number;
        UserId?: number;
        FechaModificacion?: string;
        Servicio?: string;
        DescripcionUnidadCalculo?: string;
        Frecuencia?: string;
        Imputacion?: string;
        UserName?: string;
        TipoServicio?: string;
        HotelId?: number;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
    }
    namespace LineasRow {
        const idProperty = "LineaContratoId";
        const localTextPrefix = "Contratos.Lineas";
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
            const TipoServicioId: string;
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
            const Servicio: string;
            const DescripcionUnidadCalculo: string;
            const Frecuencia: string;
            const Imputacion: string;
            const UserName: string;
            const TipoServicio: string;
            const HotelId: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace LineasService {
        const baseUrl = "Contratos/Lineas";
        function Create(request: Serenity.SaveRequest<LineasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LineasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LineasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LineasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class MercadosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MercadosForm {
        Mercado: Serenity.StringEditor;
        HotelId: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface MercadosRow {
        MercadoId?: number;
        Mercado?: string;
        EmpresaId?: number;
        HotelId?: number;
        Empresa?: string;
        HotelName?: string;
    }
    namespace MercadosRow {
        const idProperty = "MercadoId";
        const nameProperty = "Mercado";
        const localTextPrefix = "Contratos.Mercados";
        const lookupKey = "Contratos.Mercados";
        function getLookup(): Q.Lookup<MercadosRow>;
        namespace Fields {
            const MercadoId: string;
            const Mercado: string;
            const EmpresaId: string;
            const HotelId: string;
            const Empresa: string;
            const HotelName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace MercadosService {
        const baseUrl = "Contratos/Mercados";
        function Create(request: Serenity.SaveRequest<MercadosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MercadosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MercadosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MercadosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class OfertasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface OfertasForm {
        ContratoId: Serenity.IntegerEditor;
        Texto: Serenity.StringEditor;
        AplicableAuto: Serenity.BooleanEditor;
        ImpuestoIncluido: Serenity.BooleanEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        TipoAplicacionOfertaId: Serenity.LookupEditor;
        OrdenAplicacion: Serenity.IntegerEditor;
        FechaReservaDesde: Serenity.DateEditor;
        FechaReservaHasta: Serenity.DateEditor;
        EstanciaMinimaDias: Serenity.IntegerEditor;
        EstanciaMaximaDias: Serenity.IntegerEditor;
        DiasDeAntelacion: Serenity.IntegerEditor;
        CupoOferta: Serenity.IntegerEditor;
        TipoServicioId: Serenity.LookupEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        ServicioLigadoId: Serenity.LookupEditor;
        TipoImputacionId: Serenity.LookupEditor;
        AmbitoOfertaId: Serenity.LookupEditor;
        TipoOfertaId: Serenity.LookupEditor;
        N: Serenity.IntegerEditor;
        M: Serenity.DecimalEditor;
    }
}
declare namespace Geshotel.Contratos {
}
declare namespace Geshotel.Contratos {
    class OfertasRejillasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface OfertasRejillasForm {
        OfertaId: Serenity.IntegerEditor;
        N: Serenity.IntegerEditor;
        TipoCondicionId: Serenity.IntegerEditor;
        TipoAplicacion: Serenity.IntegerEditor;
        M: Serenity.DecimalEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface OfertasRejillasRow {
        RejillaId?: number;
        OfertaId?: number;
        N?: number;
        TipoCondicionId?: number;
        TipoAplicacion?: number;
        M?: number;
    }
    namespace OfertasRejillasRow {
        const idProperty = "RejillaId";
        const localTextPrefix = "Contratos.OfertasRejillas";
        namespace Fields {
            const RejillaId: string;
            const OfertaId: string;
            const N: string;
            const TipoCondicionId: string;
            const TipoAplicacion: string;
            const M: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace OfertasRejillasService {
        const baseUrl = "Contratos/OfertasRejillas";
        function Create(request: Serenity.SaveRequest<OfertasRejillasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<OfertasRejillasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<OfertasRejillasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<OfertasRejillasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    interface OfertasRow {
        OfertaId?: number;
        Texto?: string;
        ContratoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        TipoAplicacionOfertaId?: string;
        AplicableAuto?: boolean;
        FechaReservaDesde?: string;
        FechaReservaHasta?: string;
        EstanciaMinimaDias?: number;
        EstanciaMaximaDias?: number;
        DiasDeAntelacion?: number;
        TipoServicioId?: number;
        ServicioId?: number;
        UnidadCalculoId?: number;
        ServicioLigadoId?: number;
        CupoOferta?: number;
        Precio?: number;
        N?: number;
        TipoOfertaId?: number;
        M?: number;
        AmbitoOfertaId?: number;
        UserId?: number;
        FechaModificacion?: string;
        ImpuestoIncluido?: boolean;
        TipoImputacionId?: number;
        OrdenAplicacion?: number;
        AmbitoOfertaName?: string;
        TipoOfertaName?: string;
        TipoServicioName?: string;
        ServicioName?: string;
        ServicioLigadoName?: string;
        UnidadCalculoName?: string;
        UserName?: string;
        TipoAplicacionOfertaName?: string;
        TipoImputacionName?: string;
    }
    namespace OfertasRow {
        const idProperty = "OfertaId";
        const nameProperty = "Texto";
        const localTextPrefix = "Contratos.Ofertas";
        namespace Fields {
            const OfertaId: string;
            const Texto: string;
            const ContratoId: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const TipoAplicacionOfertaId: string;
            const AplicableAuto: string;
            const FechaReservaDesde: string;
            const FechaReservaHasta: string;
            const EstanciaMinimaDias: string;
            const EstanciaMaximaDias: string;
            const DiasDeAntelacion: string;
            const TipoServicioId: string;
            const ServicioId: string;
            const UnidadCalculoId: string;
            const ServicioLigadoId: string;
            const CupoOferta: string;
            const Precio: string;
            const N: string;
            const TipoOfertaId: string;
            const M: string;
            const AmbitoOfertaId: string;
            const UserId: string;
            const FechaModificacion: string;
            const ImpuestoIncluido: string;
            const TipoImputacionId: string;
            const OrdenAplicacion: string;
            const AmbitoOfertaName: string;
            const TipoOfertaName: string;
            const TipoServicioName: string;
            const ServicioName: string;
            const ServicioLigadoName: string;
            const UnidadCalculoName: string;
            const UserName: string;
            const TipoAplicacionOfertaName: string;
            const TipoImputacionName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace OfertasService {
        const baseUrl = "Contratos/Ofertas";
        function Create(request: Serenity.SaveRequest<OfertasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<OfertasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<OfertasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<OfertasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class ReleasesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReleasesForm {
        ClienteId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.StringEditor;
        Dias: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface ReleasesRow {
        ReleaseId?: number;
        ClienteId?: number;
        HotelId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        Dias?: number;
        UserId?: number;
        FechaModificacion?: string;
        ClienteRazon?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        UserName?: string;
    }
    namespace ReleasesRow {
        const idProperty = "ReleaseId";
        const nameProperty = "Observaciones";
        const localTextPrefix = "Contratos.Releases";
        namespace Fields {
            const ReleaseId: string;
            const ClienteId: string;
            const HotelId: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const Observaciones: string;
            const Dias: string;
            const UserId: string;
            const FechaModificacion: string;
            const ClienteRazon: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace ReleasesService {
        const baseUrl = "Contratos/Releases";
        function Create(request: Serenity.SaveRequest<ReleasesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReleasesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReleasesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReleasesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class SeriesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface SeriesForm {
        EmpresaId: Serenity.LookupEditor;
        Descripcion: Serenity.StringEditor;
        Abreviatura: Serenity.StringEditor;
        Manocorriente: Serenity.BooleanEditor;
        Visible: Serenity.BooleanEditor;
        Factura: Serenity.BooleanEditor;
        Deposito: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface SeriesRow {
        SerieId?: number;
        EmpresaId?: number;
        Descripcion?: string;
        Abreviatura?: string;
        Manocorriente?: boolean;
        Visible?: boolean;
        Factura?: boolean;
        Deposito?: boolean;
        ServicioId?: number;
        ImpuestoId?: number;
        Voxel?: number;
        UserId?: number;
        FechaModificacion?: string;
        Empresa?: string;
        UserName?: string;
    }
    namespace SeriesRow {
        const idProperty = "SerieId";
        const nameProperty = "Descripcion";
        const localTextPrefix = "Contratos.Series";
        namespace Fields {
            const SerieId: string;
            const EmpresaId: string;
            const Descripcion: string;
            const Abreviatura: string;
            const Manocorriente: string;
            const Visible: string;
            const Factura: string;
            const Deposito: string;
            const ServicioId: string;
            const ImpuestoId: string;
            const Voxel: string;
            const UserId: string;
            const FechaModificacion: string;
            const Empresa: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace SeriesService {
        const baseUrl = "Contratos/Series";
        function Create(request: Serenity.SaveRequest<SeriesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<SeriesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SeriesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SeriesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class ServiciosHotelForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ServiciosHotelForm {
        ServicioId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        ImpuestoId: Serenity.LookupEditor;
        Costo: Serenity.DecimalEditor;
        CtaContable: Serenity.StringEditor;
        DptoContable: Serenity.StringEditor;
        PermiteCredito: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface ServiciosHotelRow {
        ServicioHotelId?: number;
        ServicioId?: number;
        HotelId?: number;
        ImpuestoId?: number;
        Costo?: number;
        CtaContable?: string;
        DptoContable?: string;
        PermiteCredito?: boolean;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        NombreServicio?: string;
        ServicioTipoServicioId?: number;
        ConceptoAceleradorReservasId?: number;
        SwPension?: boolean;
        Impuesto?: string;
    }
    namespace ServiciosHotelRow {
        const idProperty = "ServicioHotelId";
        const nameProperty = "NombreServicio";
        const localTextPrefix = "Contratos.ServiciosHotel";
        const lookupKey = "Contratos.ServiciosHotel";
        function getLookup(): Q.Lookup<ServiciosHotelRow>;
        namespace Fields {
            const ServicioHotelId: string;
            const ServicioId: string;
            const HotelId: string;
            const ImpuestoId: string;
            const Costo: string;
            const CtaContable: string;
            const DptoContable: string;
            const PermiteCredito: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
            const NombreServicio: string;
            const ServicioTipoServicioId: string;
            const ConceptoAceleradorReservasId: string;
            const SwPension: string;
            const Impuesto: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace ServiciosHotelService {
        const baseUrl = "Contratos/ServiciosHotel";
        function Create(request: Serenity.SaveRequest<ServiciosHotelRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ServiciosHotelRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ServiciosHotelRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ServiciosHotelRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class TemporadasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TemporadasForm {
        Temporada: Serenity.StringEditor;
        HotelId: Serenity.LookupEditor;
        Ano: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface TemporadasRow {
        TemporadaId?: number;
        Temporada?: string;
        HotelId?: number;
        EmpresaId?: number;
        Ano?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        HotelName?: string;
        Empresa?: string;
    }
    namespace TemporadasRow {
        const idProperty = "TemporadaId";
        const nameProperty = "Temporada";
        const localTextPrefix = "Contratos.Temporadas";
        const lookupKey = "Contratos.Temporadas";
        function getLookup(): Q.Lookup<TemporadasRow>;
        namespace Fields {
            const TemporadaId: string;
            const Temporada: string;
            const HotelId: string;
            const EmpresaId: string;
            const Ano: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const HotelName: string;
            const Empresa: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace TemporadasService {
        const baseUrl = "Contratos/Temporadas";
        function Create(request: Serenity.SaveRequest<TemporadasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TemporadasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TemporadasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TemporadasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class TiposHabitacionHotelForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposHabitacionHotelForm {
        EmpresaId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        ServicioId: Serenity.LookupEditor;
    }
}
declare namespace Geshotel.Contratos {
    interface TiposHabitacionHotelRow {
        TipoHabitacionHotelId?: number;
        HotelId?: number;
        TipoHabitacionId?: number;
        ServicioId?: number;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        TipoHabitacionName?: string;
        ServicioName?: string;
    }
    namespace TiposHabitacionHotelRow {
        const idProperty = "TipoHabitacionHotelId";
        const nameProperty = "TipoHabitacionName";
        const localTextPrefix = "Contratos.TiposHabitacionHotel";
        const lookupKey = "Contratos.TiposHabitacionHotel";
        function getLookup(): Q.Lookup<TiposHabitacionHotelRow>;
        namespace Fields {
            const TipoHabitacionHotelId: string;
            const HotelId: string;
            const TipoHabitacionId: string;
            const ServicioId: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
            const TipoHabitacionName: string;
            const ServicioName: string;
        }
    }
}
declare namespace Geshotel.Contratos {
    namespace TiposHabitacionHotelService {
        const baseUrl = "Contratos/TiposHabitacionHotel";
        function Create(request: Serenity.SaveRequest<TiposHabitacionHotelRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposHabitacionHotelRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposHabitacionHotelRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposHabitacionHotelRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Default {
    class ReservasHabitacionesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasHabitacionesForm {
        HabitacionId: Serenity.IntegerEditor;
        TipoBloqueoId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.StringEditor;
        ReservaId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Default {
    interface ReservasHabitacionesRow {
        HabitacionBloqueoId?: number;
        HabitacionId?: number;
        TipoBloqueoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        ReservaId?: number;
        UserId?: number;
        FechaModificacion?: string;
        HabitacionHotelId?: number;
        HabitacionNumeroHabitacion?: string;
        HabitacionTipoHabitacionId?: number;
        HabitacionExtension?: number;
        HabitacionObservaciones?: string;
        HabitacionSituacionId?: number;
        HabitacionFechaInicio?: string;
        HabitacionEstadoTelefono?: number;
        HabitacionEstadoProcesado?: number;
        HabitacionHabitacionIsta?: string;
        HabitacionZonaLimpiezaId?: number;
        HabitacionLat?: number;
        HabitacionLng?: number;
        HabitacionPrimaryImage?: string;
        HabitacionGalleryimages?: string;
        HabitacionPlanta?: number;
        HabitacionUserId?: number;
        HabitacionFechaModificacion?: string;
    }
    namespace ReservasHabitacionesRow {
        const idProperty = "HabitacionBloqueoId";
        const nameProperty = "Observaciones";
        const localTextPrefix = "Default.ReservasHabitaciones";
        namespace Fields {
            const HabitacionBloqueoId: any;
            const HabitacionId: any;
            const TipoBloqueoId: any;
            const FechaDesde: any;
            const FechaHasta: any;
            const Observaciones: any;
            const ReservaId: any;
            const UserId: any;
            const FechaModificacion: any;
            const HabitacionHotelId: string;
            const HabitacionNumeroHabitacion: string;
            const HabitacionTipoHabitacionId: string;
            const HabitacionExtension: string;
            const HabitacionObservaciones: string;
            const HabitacionSituacionId: string;
            const HabitacionFechaInicio: string;
            const HabitacionEstadoTelefono: string;
            const HabitacionEstadoProcesado: string;
            const HabitacionHabitacionIsta: string;
            const HabitacionZonaLimpiezaId: string;
            const HabitacionLat: string;
            const HabitacionLng: string;
            const HabitacionPrimaryImage: string;
            const HabitacionGalleryimages: string;
            const HabitacionPlanta: string;
            const HabitacionUserId: string;
            const HabitacionFechaModificacion: string;
        }
    }
}
declare namespace Geshotel.Default {
    namespace ReservasHabitacionesService {
        const baseUrl = "Default/ReservasHabitaciones";
        function Create(request: Serenity.SaveRequest<ReservasHabitacionesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasHabitacionesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasHabitacionesRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasHabitacionesRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
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
        const idProperty = "AgendaRelevantId";
        const localTextPrefix = "Meeting.MeetingAgendaRelevant";
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
        const baseUrl = "Meeting/MeetingAgendaRelevant";
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
        const idProperty = "AgendaId";
        const nameProperty = "Title";
        const localTextPrefix = "Meeting.MeetingAgenda";
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
        const baseUrl = "Meeting/MeetingAgenda";
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
        const idProperty = "AgendaTypeId";
        const nameProperty = "Name";
        const localTextPrefix = "Meeting.MeetingAgendaType";
        const lookupKey = "Meeting.MeetingAgendaType";
        function getLookup(): Q.Lookup<MeetingAgendaTypeRow>;
        namespace Fields {
            const AgendaTypeId: string;
            const Name: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingAgendaTypeService {
        const baseUrl = "Meeting/MeetingAgendaType";
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
        const idProperty = "AttendeeId";
        const localTextPrefix = "Meeting.MeetingAttendee";
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
        const idProperty = "DecisionRelevantId";
        const localTextPrefix = "Meeting.MeetingDecisionRelevant";
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
        const baseUrl = "Meeting/MeetingDecisionRelevant";
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
        const idProperty = "DecisionId";
        const nameProperty = "Description";
        const localTextPrefix = "Meeting.MeetingDecision";
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
        const baseUrl = "Meeting/MeetingDecision";
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
        const idProperty = "LocationId";
        const nameProperty = "Name";
        const localTextPrefix = "Meeting.MeetingLocation";
        const lookupKey = "Meeting.MeetingLocation";
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
        const baseUrl = "Meeting/MeetingLocation";
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
        const idProperty = "MeetingId";
        const nameProperty = "MeetingName";
        const localTextPrefix = "Meeting.Meeting";
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
        const baseUrl = "Meeting/Meeting";
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
        const idProperty = "MeetingTypeId";
        const nameProperty = "Name";
        const localTextPrefix = "Meeting.MeetingType";
        const lookupKey = "Meeting.MeetingType";
        function getLookup(): Q.Lookup<MeetingTypeRow>;
        namespace Fields {
            const MeetingTypeId: string;
            const Name: string;
        }
    }
}
declare namespace Geshotel.Meeting {
    namespace MeetingTypeService {
        const baseUrl = "Meeting/MeetingType";
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
        const idProperty = "Id";
        const nameProperty = "CategoryName";
        const localTextPrefix = "Northwind.CategoryLang";
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
        const baseUrl = "Northwind/CategoryLang";
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
        const idProperty = "CategoryID";
        const nameProperty = "CategoryName";
        const localTextPrefix = "Northwind.Category";
        const lookupKey = "Northwind.Category";
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
        const baseUrl = "Northwind/Category";
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
        const idProperty = "ID";
        const nameProperty = "CustomerID";
        const localTextPrefix = "Northwind.CustomerCustomerDemo";
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
        const idProperty = "ID";
        const nameProperty = "CustomerTypeID";
        const localTextPrefix = "Northwind.CustomerDemographic";
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
        const idProperty = "Id";
        const nameProperty = "Email";
        const localTextPrefix = "Northwind.CustomerDetails";
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
        const idProperty = "RepresentativeId";
        const localTextPrefix = "CustomerRepresentatives";
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
        const idProperty = "ID";
        const nameProperty = "CompanyName";
        const localTextPrefix = "Northwind.Customer";
        const lookupKey = "Northwind.Customer";
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
        const baseUrl = "Northwind/Customer";
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
        const idProperty = "EmployeeID";
        const nameProperty = "FullName";
        const localTextPrefix = "Northwind.Employee";
        const lookupKey = "Northwind.Employee";
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
        const idProperty = "EmployeeID";
        const nameProperty = "TerritoryID";
        const localTextPrefix = "Northwind.EmployeeTerritory";
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
        const idProperty = "NoteId";
        const nameProperty = "EntityType";
        const localTextPrefix = "Northwind.Note";
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
        const idProperty = "DetailID";
        const localTextPrefix = "Northwind.OrderDetail";
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
        const baseUrl = "Northwind/OrderDetail";
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
        const idProperty = "OrderID";
        const nameProperty = "CustomerID";
        const localTextPrefix = "Northwind.Order";
        const lookupKey = "Northwind.OrderShipCity";
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
        const baseUrl = "Northwind/Order";
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
        const idProperty = "Id";
        const nameProperty = "ProductName";
        const localTextPrefix = "Northwind.ProductLang";
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
        const baseUrl = "Northwind/ProductLang";
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
        const idProperty = "ProductLogID";
        const localTextPrefix = "Northwind.ProductLog";
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
        const idProperty = "ProductID";
        const nameProperty = "ProductName";
        const localTextPrefix = "Northwind.Product";
        const lookupKey = "Northwind.Product";
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
        const baseUrl = "Northwind/Product";
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
        const idProperty = "RegionID";
        const nameProperty = "RegionDescription";
        const localTextPrefix = "Northwind.Region";
        const lookupKey = "Northwind.Region";
        function getLookup(): Q.Lookup<RegionRow>;
        namespace Fields {
            const RegionID: string;
            const RegionDescription: string;
        }
    }
}
declare namespace Geshotel.Northwind {
    namespace RegionService {
        const baseUrl = "Northwind/Region";
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
        const nameProperty = "CategoryName";
        const localTextPrefix = "Northwind.SalesByCategory";
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
        const baseUrl = "Northwind/SalesByCategory";
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
        const idProperty = "ShipperID";
        const nameProperty = "CompanyName";
        const localTextPrefix = "Northwind.Shipper";
        const lookupKey = "Northwind.Shipper";
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
        const baseUrl = "Northwind/Shipper";
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
        const idProperty = "SupplierID";
        const nameProperty = "CompanyName";
        const localTextPrefix = "Northwind.Supplier";
        const lookupKey = "Northwind.Supplier";
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
        const baseUrl = "Northwind/Supplier";
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
        const idProperty = "ID";
        const nameProperty = "TerritoryID";
        const localTextPrefix = "Northwind.Territory";
        const lookupKey = "Northwind.Territory";
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
        const baseUrl = "Northwind/Territory";
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
        const idProperty = "UnitId";
        const nameProperty = "Name";
        const localTextPrefix = "Organization.BusinessUnit";
        const lookupKey = "Organization.BusinessUnit";
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
        const baseUrl = "Organization/BusinessUnit";
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
        const idProperty = "ContactId";
        const nameProperty = "FullName";
        const localTextPrefix = "Organization.Contact";
        const lookupKey = "Organization.Contact";
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
        const baseUrl = "Organization/Contact";
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
    class AmbitoOfertaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface AmbitoOfertaForm {
        Nombre: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface AmbitoOfertaRow {
        AmbitoOfertaId?: number;
        Nombre?: string;
    }
    namespace AmbitoOfertaRow {
        const idProperty = "AmbitoOfertaId";
        const nameProperty = "Nombre";
        const localTextPrefix = "Portal.AmbitoOferta";
        const lookupKey = "Portal.AmbitoOferta";
        function getLookup(): Q.Lookup<AmbitoOfertaRow>;
        namespace Fields {
            const AmbitoOfertaId: string;
            const Nombre: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace AmbitoOfertaService {
        const baseUrl = "Portal/AmbitoOferta";
        function Create(request: Serenity.SaveRequest<AmbitoOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AmbitoOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AmbitoOfertaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AmbitoOfertaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
        const idProperty = "CategoriaId";
        const nameProperty = "Categoria";
        const localTextPrefix = "Portal.CategoriaHoteles";
        const lookupKey = "Portal.CategoriaHoteles";
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
        const baseUrl = "Portal/CategoriaHoteles";
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
        const idProperty = "ComunidadId";
        const nameProperty = "ComunidadAutonoma";
        const localTextPrefix = "Portal.ComunidadesAutonomas";
        const lookupKey = "Portal.ComunidadesAutonomas";
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
        const baseUrl = "Portal/ComunidadesAutonomas";
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
        const idProperty = "ConceptoAceleradorId";
        const nameProperty = "Concepto";
        const localTextPrefix = "Portal.ConceptosAceleradorReservas";
        const lookupKey = "Portal.ConceptosAceleradorReservas";
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
        const idProperty = "EmpresaId";
        const nameProperty = "Empresa";
        const localTextPrefix = "Portal.Empresas";
        const lookupKey = "Portal.Empresas";
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
        const baseUrl = "Portal/Empresas";
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
    interface EstadosFacturasRow {
        EstadoFacturaId?: number;
        Descripcion?: string;
        EsError?: number;
    }
    namespace EstadosFacturasRow {
        const idProperty = "EstadoFacturaId";
        const nameProperty = "Descripcion";
        const localTextPrefix = "Portal.EstadosFacturas";
        const lookupKey = "Portal.EstadosFactura";
        function getLookup(): Q.Lookup<EstadosFacturasRow>;
        namespace Fields {
            const EstadoFacturaId: string;
            const Descripcion: string;
            const EsError: string;
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
        const idProperty = "FormaPagoId";
        const nameProperty = "FormaPago";
        const localTextPrefix = "Portal.FormasDePago";
        const lookupKey = "Portal.FromasDePago";
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
        const baseUrl = "Portal/FormasDePago";
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
    class FrecuenciaFacturacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface FrecuenciaFacturacionForm {
        DescripcionCorta: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface FrecuenciaFacturacionRow {
        FrecuenciaId?: number;
        DescripcionCorta?: string;
        Descripcion?: string;
    }
    namespace FrecuenciaFacturacionRow {
        const idProperty = "FrecuenciaId";
        const nameProperty = "Descripcion";
        const localTextPrefix = "Portal.FrecuenciaFacturacion";
        const lookupKey = "Portal.FrecuenciaFacturacion";
        function getLookup(): Q.Lookup<FrecuenciaFacturacionRow>;
        namespace Fields {
            const FrecuenciaId: string;
            const DescripcionCorta: string;
            const Descripcion: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace FrecuenciaFacturacionService {
        const baseUrl = "Portal/FrecuenciaFacturacion";
        function Create(request: Serenity.SaveRequest<FrecuenciaFacturacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<FrecuenciaFacturacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<FrecuenciaFacturacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<FrecuenciaFacturacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
        Huesped: Serenity.BooleanEditor;
        Contratos: Serenity.BooleanEditor;
        Facturar: Serenity.BooleanEditor;
        Agencia: Serenity.BooleanEditor;
        Perfil: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Portal {
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
        const idProperty = "GrupoClienteId";
        const nameProperty = "NombreGrupo";
        const localTextPrefix = "Portal.GruposDeCliente";
        const lookupKey = "Portal.GruposDeCliente";
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
declare namespace Geshotel.Portal {
    namespace GruposDeClienteService {
        const baseUrl = "Portal/GruposDeCliente";
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
        const idProperty = "GrupoServicioId";
        const nameProperty = "NombreGrupo";
        const localTextPrefix = "Portal.GruposDeServicios";
        const lookupKey = "Portal.GruposDeServicio";
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
        const baseUrl = "Portal/GruposDeServicios";
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
        const idProperty = "HabitacionId";
        const nameProperty = "Habitacion";
        const localTextPrefix = "Portal.GruposHabitacion";
        const lookupKey = "Portal.GruposHabitacion";
        function getLookup(): Q.Lookup<GruposHabitacionRow>;
        namespace Fields {
            const HabitacionId: string;
            const Habitacion: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace GruposHabitacionService {
        const baseUrl = "Portal/GruposHabitacion";
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
    class HabitacionesSituacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface HabitacionesSituacionForm {
        Descriptivo: Serenity.StringEditor;
        Editable: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Portal {
    interface HabitacionesSituacionRow {
        SituacionId?: number;
        Situacion?: string;
    }
    namespace HabitacionesSituacionRow {
        const idProperty = "SituacionId";
        const nameProperty = "Situacion";
        const localTextPrefix = "Portal.HabitacionesSituacion";
        const lookupKey = "Portal.HabitacionesSituacion";
        function getLookup(): Q.Lookup<HabitacionesSituacionRow>;
        namespace Fields {
            const SituacionId: string;
            const Situacion: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace HabitacionesSituacionService {
        const baseUrl = "Portal/HabitacionesSituacion";
        function Create(request: Serenity.SaveRequest<HabitacionesSituacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<HabitacionesSituacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<HabitacionesSituacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<HabitacionesSituacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
        Lat: Serenity.DecimalEditor;
        Lng: Serenity.DecimalEditor;
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
        Lat?: number;
        Lng?: number;
        Ancho?: number;
        Alto?: number;
        OverbookingLimit?: number;
        Empresa?: string;
        TipoHotel?: string;
        TipoHotelAbreviatura?: string;
        Categoria?: string;
        CategoriaAbreviatura?: string;
        Provincia?: string;
        Nacion?: string;
        ProvinciaComunidadAutonomaId?: number;
        ProvinciaProvinciaIsta?: string;
        ProvinciaDefectoIsta?: number;
        FechaHotel?: string;
    }
    namespace HotelesRow {
        const idProperty = "HotelId";
        const nameProperty = "Hotel";
        const localTextPrefix = "Portal.Hoteles";
        const lookupKey = "Portal.Hoteles";
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
            const Lat: string;
            const Lng: string;
            const Ancho: string;
            const Alto: string;
            const OverbookingLimit: string;
            const Empresa: string;
            const TipoHotel: string;
            const TipoHotelAbreviatura: string;
            const Categoria: string;
            const CategoriaAbreviatura: string;
            const Provincia: string;
            const Nacion: string;
            const ProvinciaComunidadAutonomaId: string;
            const ProvinciaProvinciaIsta: string;
            const ProvinciaDefectoIsta: string;
            const FechaHotel: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace HotelesService {
        const baseUrl = "Portal/Hoteles";
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
    class ImpuestosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ImpuestosForm {
        EmpresaId: Serenity.LookupEditor;
        Impuesto: Serenity.StringEditor;
        Porcentaje: Serenity.DecimalEditor;
        CtaContable: Serenity.StringEditor;
        ActivoGeshotel: Serenity.BooleanEditor;
        UserId: Serenity.LookupEditor;
        FechaActualizacion: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Portal {
    interface ImpuestosRow {
        ImpuestoId?: number;
        EmpresaId?: number;
        Impuesto?: string;
        Porcentaje?: number;
        CtaContable?: string;
        ActivoGeshotel?: boolean;
        UserId?: number;
        FechaModificacion?: string;
        UserName?: string;
        Empresa?: string;
    }
    namespace ImpuestosRow {
        const idProperty = "ImpuestoId";
        const nameProperty = "Impuesto";
        const localTextPrefix = "Portal.Impuestos";
        const lookupKey = "Portal.Impuestos";
        function getLookup(): Q.Lookup<ImpuestosRow>;
        namespace Fields {
            const ImpuestoId: string;
            const EmpresaId: string;
            const Impuesto: string;
            const Porcentaje: string;
            const CtaContable: string;
            const ActivoGeshotel: string;
            const UserId: string;
            const FechaModificacion: string;
            const UserName: string;
            const Empresa: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace ImpuestosService {
        const baseUrl = "Portal/Impuestos";
        function Create(request: Serenity.SaveRequest<ImpuestosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ImpuestosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ImpuestosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ImpuestosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
        const idProperty = "MonedaId";
        const nameProperty = "Descripcion";
        const localTextPrefix = "Portal.Monedas";
        const lookupKey = "Portal.Monedas";
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
        const baseUrl = "Portal/Monedas";
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
        const idProperty = "NacionId";
        const nameProperty = "Nacion";
        const localTextPrefix = "Portal.Naciones";
        const lookupKey = "Portal.Naciones";
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
        const baseUrl = "Portal/Naciones";
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
        const idProperty = "ProvinciaId";
        const nameProperty = "Provincia";
        const localTextPrefix = "Portal.Provincias";
        const lookupKey = "Portal.Provincias";
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
        const baseUrl = "Portal/Provincias";
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
    interface ReservaEstadosRow {
        EstadoReservaId?: number;
        Estado?: string;
        EsErrorFechaini?: number;
        EsErrorFechafin?: number;
    }
    namespace ReservaEstadosRow {
        const idProperty = "EstadoReservaId";
        const nameProperty = "Estado";
        const localTextPrefix = "Portal.ReservaEstados";
        const lookupKey = "Portal.ReservaEstados";
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
        const idProperty = "ServicioId";
        const nameProperty = "NombreServicio";
        const localTextPrefix = "Portal.Servicios";
        const lookupKey = "Portal.Servicios";
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
        const baseUrl = "Portal/Servicios";
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
        const idProperty = "SexoId";
        const nameProperty = "SexoId";
        const localTextPrefix = "Portal.Sexos";
        const lookupKey = "Portal.Sexos";
        function getLookup(): Q.Lookup<SexosRow>;
        namespace Fields {
            const SexoId: string;
            const Sexo: string;
        }
    }
}
declare namespace Geshotel.Portal {
}
declare namespace Geshotel.Portal {
    class TipoAplicacionOfertaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TipoAplicacionOfertaForm {
        AplicableSegunFechaDe: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TipoAplicacionOfertaRow {
        TipoAplicacionOfertaId?: string;
        AplicableSegunFechaDe?: string;
    }
    namespace TipoAplicacionOfertaRow {
        const idProperty = "TipoAplicacionOfertaId";
        const nameProperty = "AplicableSegunFechaDe";
        const localTextPrefix = "Portal.TipoAplicacionOferta";
        const lookupKey = "Portal.TipoAplicacionOferta";
        function getLookup(): Q.Lookup<TipoAplicacionOfertaRow>;
        namespace Fields {
            const TipoAplicacionOfertaId: string;
            const AplicableSegunFechaDe: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TipoAplicacionOfertaService {
        const baseUrl = "Portal/TipoAplicacionOferta";
        function Create(request: Serenity.SaveRequest<TipoAplicacionOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TipoAplicacionOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TipoAplicacionOfertaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TipoAplicacionOfertaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class TiposBloqueoForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposBloqueoForm {
        Descriptivo: Serenity.StringEditor;
        Editable: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposBloqueoRow {
        TipoBloqueoId?: number;
        Descriptivo?: string;
        Editable?: boolean;
    }
    namespace TiposBloqueoRow {
        const idProperty = "TipoBloqueoId";
        const nameProperty = "Descriptivo";
        const localTextPrefix = "Portal.TiposBloqueo";
        const lookupKey = "Portal.TiposBloqueo";
        function getLookup(): Q.Lookup<TiposBloqueoRow>;
        namespace Fields {
            const TipoBloqueoId: string;
            const Descriptivo: string;
            const Editable: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposBloqueoService {
        const baseUrl = "Portal/TiposBloqueo";
        function Create(request: Serenity.SaveRequest<TiposBloqueoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposBloqueoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposBloqueoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposBloqueoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class TiposCondicionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposCondicionForm {
        Condicion: Serenity.StringEditor;
        Literal: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposCondicionRow {
        TipoCondicionId?: number;
        Condicion?: string;
        Literal?: string;
    }
    namespace TiposCondicionRow {
        const idProperty = "TipoCondicionId";
        const nameProperty = "Condicion";
        const localTextPrefix = "Portal.TiposCondicion";
        const lookupKey = "Portal.TiposCondicion";
        function getLookup(): Q.Lookup<TiposCondicionRow>;
        namespace Fields {
            const TipoCondicionId: string;
            const Condicion: string;
            const Literal: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposCondicionService {
        const baseUrl = "Portal/TiposCondicion";
        function Create(request: Serenity.SaveRequest<TiposCondicionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposCondicionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposCondicionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposCondicionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class TiposDeImputacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposDeImputacionForm {
        Imputacion: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposDeImputacionRow {
        TipoImputacionId?: number;
        Imputacion?: string;
    }
    namespace TiposDeImputacionRow {
        const idProperty = "TipoImputacionId";
        const nameProperty = "Imputacion";
        const localTextPrefix = "Portal.TiposDeImputacion";
        const lookupKey = "Portal.TiposDeImputacion";
        function getLookup(): Q.Lookup<TiposDeImputacionRow>;
        namespace Fields {
            const TipoImputacionId: string;
            const Imputacion: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposDeImputacionService {
        const baseUrl = "Portal/TiposDeImputacion";
        function Create(request: Serenity.SaveRequest<TiposDeImputacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposDeImputacionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposDeImputacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposDeImputacionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
declare namespace Geshotel.Portal {
    interface TiposDeOfertaRow {
        TipoOfertaId?: number;
        Oferta?: string;
        PermitirMMayorQueN?: number;
        Rejilla?: number;
        Observaciones?: string;
        OrdenAplicacion?: number;
    }
    namespace TiposDeOfertaRow {
        const idProperty = "TipoOfertaId";
        const nameProperty = "Oferta";
        const localTextPrefix = "Portal.TiposDeOferta";
        const lookupKey = "Portal.TiposDeOferta";
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
declare namespace Geshotel.Portal {
    namespace TiposDeOfertaService {
        const baseUrl = "Portal/TiposDeOferta";
        function Create(request: Serenity.SaveRequest<TiposDeOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposDeOfertaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposDeOfertaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposDeOfertaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    class TiposDeTarjetaForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TiposDeTarjetaForm {
        TipoTarjeta: Serenity.StringEditor;
        TarjetaLength: Serenity.StringEditor;
        TarjetaPrefixes: Serenity.StringEditor;
        TarjetaCheckdigit: Serenity.BooleanEditor;
    }
}
declare namespace Geshotel.Portal {
    interface TiposDeTarjetaRow {
        TipoTarjetaId?: number;
        TipoTarjeta?: string;
        TarjetaLength?: string;
        TarjetaPrefixes?: string;
        TarjetaCheckdigit?: boolean;
    }
    namespace TiposDeTarjetaRow {
        const idProperty = "TipoTarjetaId";
        const nameProperty = "TipoTarjeta";
        const localTextPrefix = "Portal.TiposDeTarjeta";
        const lookupKey = "Portal.TiposDeTarjeta";
        function getLookup(): Q.Lookup<TiposDeTarjetaRow>;
        namespace Fields {
            const TipoTarjetaId: string;
            const TipoTarjeta: string;
            const TarjetaLength: string;
            const TarjetaPrefixes: string;
            const TarjetaCheckdigit: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposDeTarjetaService {
        const baseUrl = "Portal/TiposDeTarjeta";
        function Create(request: Serenity.SaveRequest<TiposDeTarjetaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TiposDeTarjetaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TiposDeTarjetaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TiposDeTarjetaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
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
    interface TiposDocumentoRow {
        DocumentoId?: string;
        Documento?: string;
    }
    namespace TiposDocumentoRow {
        const idProperty = "DocumentoId";
        const nameProperty = "Documento";
        const localTextPrefix = "Portal.TiposDocumento";
        const lookupKey = "Portal.TiposDocumento";
        function getLookup(): Q.Lookup<TiposDocumentoRow>;
        namespace Fields {
            const DocumentoId: string;
            const Documento: string;
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
        const idProperty = "TipoHabitacionId";
        const nameProperty = "Descripcion";
        const localTextPrefix = "Portal.TiposHabitacion";
        const lookupKey = "Portal.TiposHabitacion";
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
        const baseUrl = "Portal/TiposHabitacion";
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
        const idProperty = "TipoHotelId";
        const nameProperty = "TipoHotel";
        const localTextPrefix = "Portal.TiposHotel";
        const lookupKey = "Portal.TiposHotel";
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
        const baseUrl = "Portal/TiposHotel";
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
        const idProperty = "TipoHuespedId";
        const nameProperty = "Descripcion";
        const localTextPrefix = "Portal.TiposHuesped";
        const lookupKey = "Portal.TiposHuesped";
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
        const baseUrl = "Portal/TiposHuesped";
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
    interface TiposPensionRow {
        TipoPensionId?: number;
        TipoPension?: string;
    }
    namespace TiposPensionRow {
        const idProperty = "TipoPensionId";
        const nameProperty = "TipoPension";
        const localTextPrefix = "Portal.TiposPension";
        const lookupKey = "Portal.TiposPension";
        function getLookup(): Q.Lookup<TiposPensionRow>;
        namespace Fields {
            const TipoPensionId: string;
            const TipoPension: string;
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
        const idProperty = "TipoServicioId";
        const nameProperty = "NombreTipoServicio";
        const localTextPrefix = "Portal.TiposServicio";
        const lookupKey = "Portal.TiposServicio";
        function getLookup(): Q.Lookup<TiposServicioRow>;
        namespace Fields {
            const TipoServicioId: string;
            const NombreTipoServicio: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposServicioService {
        const baseUrl = "Portal/TiposServicio";
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
        const idProperty = "UnidadCalculoId";
        const nameProperty = "Uc";
        const localTextPrefix = "Portal.TiposUnidadCalculo";
        const lookupKey = "Portal.TiposUnidadCalculo";
        function getLookup(): Q.Lookup<TiposUnidadCalculoRow>;
        namespace Fields {
            const UnidadCalculoId: string;
            const Uc: string;
        }
    }
}
declare namespace Geshotel.Portal {
    namespace TiposUnidadCalculoService {
        const baseUrl = "Portal/TiposUnidadCalculo";
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
        const idProperty = "UnidadCalculoId";
        const nameProperty = "DescripcionUnidadCalculo";
        const localTextPrefix = "Portal.UnidadesCalculo";
        const lookupKey = "Portal.UnidadesCalculo";
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
        const baseUrl = "Portal/UnidadesCalculo";
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
declare namespace Geshotel.Prtal {
    class FrecuenciaFacturacionForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface FrecuenciaFacturacionForm {
        DescripcionCorta: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Prtal {
    interface FrecuenciaFacturacionRow {
        FrecuenciaId?: number;
        DescripcionCorta?: string;
        Descripcion?: string;
    }
    namespace FrecuenciaFacturacionRow {
        const idProperty = "FrecuenciaId";
        const nameProperty = "DescripcionCorta";
        const localTextPrefix = "Prtal.FrecuenciaFacturacion";
        namespace Fields {
            const FrecuenciaId: any;
            const DescripcionCorta: any;
            const Descripcion: any;
        }
    }
}
declare namespace Geshotel.Prtal {
    namespace FrecuenciaFacturacionService {
        const baseUrl = "Prtal/FrecuenciaFacturacion";
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
declare namespace Geshotel.Recepcion {
    interface ChangeReservationStatusRequest extends Serenity.ServiceRequest {
        ReservaId?: number;
        NewStatusId?: number;
    }
}
declare namespace Geshotel.Recepcion {
    interface ChangeReservationStatusResponse extends Serenity.ServiceResponse {
    }
}
declare namespace Geshotel.Recepcion {
    interface CheckInRequest extends Serenity.ServiceRequest {
        ReservaId?: number;
    }
}
declare namespace Geshotel.Recepcion {
    interface CheckInResponse extends Serenity.ServiceResponse {
    }
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
    class HabitacionesBloqueosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface HabitacionesBloqueosForm {
        HabitacionId: Serenity.LookupEditor;
        TipoBloqueoId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.TextAreaEditor;
        ReservaId: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface HabitacionesBloqueosRow {
        HabitacionBloqueoId?: number;
        HabitacionId?: number;
        TipoBloqueoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        ReservaId?: number;
        UserId?: number;
        FechaModificacion?: string;
        HotelId?: number;
        EmpresaId?: number;
        HabitacionNumeroHabitacion?: string;
        HabitacionTipoHabitacionId?: number;
        DescCorta?: string;
        UserName?: string;
    }
    namespace HabitacionesBloqueosRow {
        const idProperty = "HabitacionBloqueoId";
        const nameProperty = "HabitacionNumeroHabitacion";
        const localTextPrefix = "Recepcion.HabitacionesBloqueos";
        namespace Fields {
            const HabitacionBloqueoId: string;
            const HabitacionId: string;
            const TipoBloqueoId: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const Observaciones: string;
            const ReservaId: string;
            const UserId: string;
            const FechaModificacion: string;
            const HotelId: string;
            const EmpresaId: string;
            const HabitacionNumeroHabitacion: string;
            const HabitacionTipoHabitacionId: string;
            const DescCorta: string;
            const UserName: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace HabitacionesBloqueosService {
        const baseUrl = "Recepcion/HabitacionesBloqueos";
        function Create(request: Serenity.SaveRequest<HabitacionesBloqueosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<HabitacionesBloqueosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<HabitacionesBloqueosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<HabitacionesBloqueosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    class HabitacionesRForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface HabitacionesRForm {
        HabitacionId: Serenity.IntegerEditor;
        TipoBloqueoId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Observaciones: Serenity.StringEditor;
        ReservaId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface HabitacionesRRow {
        HabitacionBloqueoId?: number;
        HabitacionId?: number;
        TipoBloqueoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        ReservaId?: number;
        UserId?: number;
        FechaModificacion?: string;
        HabitacionHotelId?: number;
        HabitacionNumeroHabitacion?: string;
        HabitacionTipoHabitacionId?: number;
        HabitacionExtension?: number;
        HabitacionObservaciones?: string;
        HabitacionSituacionId?: number;
        HabitacionFechaInicio?: string;
        HabitacionEstadoTelefono?: number;
        HabitacionEstadoProcesado?: number;
        HabitacionHabitacionIsta?: string;
        HabitacionZonaLimpiezaId?: number;
        HabitacionLat?: number;
        HabitacionLng?: number;
        HabitacionPrimaryImage?: string;
        HabitacionGalleryimages?: string;
        HabitacionPlanta?: number;
        HabitacionUserId?: number;
        HabitacionFechaModificacion?: string;
    }
    namespace HabitacionesRRow {
        const idProperty = "HabitacionBloqueoId";
        const nameProperty = "Observaciones";
        const localTextPrefix = "Recepcion.HabitacionesR";
        namespace Fields {
            const HabitacionBloqueoId: any;
            const HabitacionId: any;
            const TipoBloqueoId: any;
            const FechaDesde: any;
            const FechaHasta: any;
            const Observaciones: any;
            const ReservaId: any;
            const UserId: any;
            const FechaModificacion: any;
            const HabitacionHotelId: string;
            const HabitacionNumeroHabitacion: string;
            const HabitacionTipoHabitacionId: string;
            const HabitacionExtension: string;
            const HabitacionObservaciones: string;
            const HabitacionSituacionId: string;
            const HabitacionFechaInicio: string;
            const HabitacionEstadoTelefono: string;
            const HabitacionEstadoProcesado: string;
            const HabitacionHabitacionIsta: string;
            const HabitacionZonaLimpiezaId: string;
            const HabitacionLat: string;
            const HabitacionLng: string;
            const HabitacionPrimaryImage: string;
            const HabitacionGalleryimages: string;
            const HabitacionPlanta: string;
            const HabitacionUserId: string;
            const HabitacionFechaModificacion: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace HabitacionesRService {
        const baseUrl = "Recepcion/HabitacionesR";
        function Create(request: Serenity.SaveRequest<HabitacionesRRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<HabitacionesRRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<HabitacionesRRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<HabitacionesRRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
    class HuespedesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface HuespedesForm {
        EmpresaId: Serenity.LookupEditor;
        Nombre: Serenity.StringEditor;
        Apellidos: Serenity.StringEditor;
        TipoDocumentoId: Serenity.LookupEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
        SexoId: Serenity.LookupEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        NacionId: Serenity.LookupEditor;
        ProvinciaId: Serenity.LookupEditor;
        Telefono: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        Foto1: Serenity.StringEditor;
        Foto2: Serenity.StringEditor;
        ReservaId: Serenity.IntegerEditor;
        TarjetaFidelizacion: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface HuespedesRow {
        HuespedId?: number;
        EmpresaId?: number;
        Nombre?: string;
        Apellidos?: string;
        NombreCompleto?: string;
        TipoDocumentoId?: string;
        Nif?: string;
        FechaDocumento?: string;
        FechaNacimiento?: string;
        SexoId?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        NacionId?: number;
        ProvinciaId?: number;
        Telefono?: string;
        Email?: string;
        Foto1?: string;
        Foto2?: string;
        TarjetaFidelizacion?: string;
        Empresa?: string;
        TipoDocumento?: string;
        Nacion?: string;
        NacionDescCorta?: string;
        Provincia?: string;
        ReservaId?: number;
    }
    namespace HuespedesRow {
        const idProperty = "HuespedId";
        const nameProperty = "Nombre";
        const localTextPrefix = "Recepcion.Huespedes";
        namespace Fields {
            const HuespedId: string;
            const EmpresaId: string;
            const Nombre: string;
            const Apellidos: string;
            const NombreCompleto: string;
            const TipoDocumentoId: string;
            const Nif: string;
            const FechaDocumento: string;
            const FechaNacimiento: string;
            const SexoId: string;
            const Direccion: string;
            const Poblacion: string;
            const Zip: string;
            const NacionId: string;
            const ProvinciaId: string;
            const Telefono: string;
            const Email: string;
            const Foto1: string;
            const Foto2: string;
            const TarjetaFidelizacion: string;
            const Empresa: string;
            const TipoDocumento: string;
            const Nacion: string;
            const NacionDescCorta: string;
            const Provincia: string;
            const ReservaId: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace HuespedesService {
        const baseUrl = "Recepcion/Huespedes";
        function Create(request: Serenity.SaveRequest<HuespedesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<HuespedesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<HuespedesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<HuespedesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
    class ReservasContratosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasContratosForm {
        ReservaId: Serenity.IntegerEditor;
        ContratoId: Serenity.IntegerEditor;
        Directo: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface ReservasContratosRow {
        ReservaContratoId?: number;
        ReservaId?: number;
        ContratoId?: number;
        Directo?: boolean;
        FechaDesde?: string;
        FechaHasta?: string;
        ClienteId?: number;
        ClienteName?: string;
    }
    namespace ReservasContratosRow {
        const idProperty = "ReservaContratoId";
        const localTextPrefix = "Recepcion.ReservasContratos";
        namespace Fields {
            const ReservaContratoId: string;
            const ReservaId: string;
            const ContratoId: string;
            const Directo: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const ClienteId: string;
            const ClienteName: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace ReservasContratosService {
        const baseUrl = "Recepcion/ReservasContratos";
        function Create(request: Serenity.SaveRequest<ReservasContratosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasContratosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasContratosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasContratosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
    class ReservasDescuentosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasDescuentosForm {
        ReservaId: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
        TipoDescuentoId: Serenity.IntegerEditor;
        Tipo: Serenity.StringEditor;
        Descuento: Serenity.DecimalEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface ReservasDescuentosRow {
        ReservaDescuentoId?: number;
        ReservaId?: number;
        ServicioId?: number;
        TipoDescuentoId?: number;
        Tipo?: string;
        Descuento?: number;
        UserId?: number;
        FechaModificacion?: string;
        ReservaFechaCreacion?: string;
        ReservaHotelId?: number;
        ReservaEstadoReservaId?: number;
        ReservaClienteId?: number;
        ReservaCanalReservaId?: number;
        ReservaClienteIdFactura?: number;
        ReservaFechaReserva?: string;
        ReservaNombreReserva?: string;
        ReservaFechaPrevistaLlegada?: string;
        ReservaFechaPrevistaSalida?: string;
        ReservaHoraPrevistaLlegada?: string;
        ReservaHoraPrevistaSalida?: string;
        ReservaObservacionesLlegada?: string;
        ReservaObservacionesSalida?: string;
        ReservaObservacionesCliente?: string;
        ReservaObservaciones?: string;
        ReservaFechaLlegada?: string;
        ReservaFechaSalida?: string;
        ReservaBonoReferencia?: string;
        ReservaBonoOnline?: string;
        ReservaBloquearTarifa?: number;
        ReservaPermiteDevolucion?: number;
        ReservaTipoTarjetaId?: number;
        ReservaTarjetaCredito?: string;
        ReservaCaducidad?: string;
        ReservaCodSeguridad?: string;
        ReservaContratoTtoo?: string;
        ReservaCodigoOferta?: string;
        ReservaValor?: number;
        ReservaValorValidado?: number;
        ReservaFechaValidacion?: string;
        ReservaUsuarioValidacion?: number;
        ReservaParoventasCheck?: number;
        ReservaCuposCheck?: number;
        ReservaReleaseCheck?: number;
        ReservaReservaDingus?: number[];
        ReservaDingusImpuestosIncluidos?: number;
        ReservaDingusComision?: number;
        ReservaReservaDingusTipo?: number;
        ReservaFechaAnulacion?: string;
        ReservaUserId?: number;
        ReservaFechaModificacion?: string;
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
        TipoDescuentoDescuento?: string;
        TipoDescripcion?: string;
    }
    namespace ReservasDescuentosRow {
        const idProperty = "ReservaDescuentoId";
        const nameProperty = "Tipo";
        const localTextPrefix = "Recepcion.ReservasDescuentos";
        namespace Fields {
            const ReservaDescuentoId: string;
            const ReservaId: string;
            const ServicioId: string;
            const TipoDescuentoId: string;
            const Tipo: string;
            const Descuento: string;
            const UserId: string;
            const FechaModificacion: string;
            const ReservaFechaCreacion: string;
            const ReservaHotelId: string;
            const ReservaEstadoReservaId: string;
            const ReservaClienteId: string;
            const ReservaCanalReservaId: string;
            const ReservaClienteIdFactura: string;
            const ReservaFechaReserva: string;
            const ReservaNombreReserva: string;
            const ReservaFechaPrevistaLlegada: string;
            const ReservaFechaPrevistaSalida: string;
            const ReservaHoraPrevistaLlegada: string;
            const ReservaHoraPrevistaSalida: string;
            const ReservaObservacionesLlegada: string;
            const ReservaObservacionesSalida: string;
            const ReservaObservacionesCliente: string;
            const ReservaObservaciones: string;
            const ReservaFechaLlegada: string;
            const ReservaFechaSalida: string;
            const ReservaBonoReferencia: string;
            const ReservaBonoOnline: string;
            const ReservaBloquearTarifa: string;
            const ReservaPermiteDevolucion: string;
            const ReservaTipoTarjetaId: string;
            const ReservaTarjetaCredito: string;
            const ReservaCaducidad: string;
            const ReservaCodSeguridad: string;
            const ReservaContratoTtoo: string;
            const ReservaCodigoOferta: string;
            const ReservaValor: string;
            const ReservaValorValidado: string;
            const ReservaFechaValidacion: string;
            const ReservaUsuarioValidacion: string;
            const ReservaParoventasCheck: string;
            const ReservaCuposCheck: string;
            const ReservaReleaseCheck: string;
            const ReservaReservaDingus: string;
            const ReservaDingusImpuestosIncluidos: string;
            const ReservaDingusComision: string;
            const ReservaReservaDingusTipo: string;
            const ReservaFechaAnulacion: string;
            const ReservaUserId: string;
            const ReservaFechaModificacion: string;
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
            const TipoDescuentoDescuento: string;
            const TipoDescripcion: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace ReservasDescuentosService {
        const baseUrl = "Recepcion/ReservasDescuentos";
        function Create(request: Serenity.SaveRequest<ReservasDescuentosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasDescuentosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasDescuentosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasDescuentosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasForm {
        EmpresaId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        EstadoReservaId: Serenity.LookupEditor;
        ClienteId: Serenity.LookupEditor;
        ClienteIdFactura: Serenity.LookupEditor;
        NombreReserva: Serenity.StringEditor;
        TipoHabitacionId: Serenity.LookupEditor;
        PensionId: Serenity.LookupEditor;
        Adultos: Serenity.IntegerEditor;
        Child50: Serenity.IntegerEditor;
        ChildFree: Serenity.IntegerEditor;
        Bebes: Serenity.IntegerEditor;
        BonoReferencia: Serenity.StringEditor;
        BonoOnline: Serenity.StringEditor;
        CanalReservaId: Serenity.LookupEditor;
        CodigoOferta: Serenity.StringEditor;
        BloquearTarifa: Serenity.BooleanEditor;
        PermiteDevolucion: Serenity.BooleanEditor;
        Vip: Serenity.BooleanEditor;
        Valor: Serenity.DecimalEditor;
        FechaReserva: Serenity.DateEditor;
        FechaCreacion: Serenity.DateEditor;
        FechaPrevistaLlegada: Serenity.DateTimeEditor;
        FechaPrevistaSalida: Serenity.DateTimeEditor;
        FechaLlegada: Serenity.DateEditor;
        FechaSalida: Serenity.DateEditor;
        ObservacionesLlegada: Serenity.TextAreaEditor;
        ObservacionesSalida: Serenity.TextAreaEditor;
        Observaciones: Serenity.TextAreaEditor;
        ObservacionesCliente: Serenity.TextAreaEditor;
        TipoTarjetaId: Serenity.LookupEditor;
        TarjetaCredito: Serenity.StringEditor;
        Caducidad: Serenity.StringEditor;
        CodSeguridad: Serenity.StringEditor;
    }
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
    class ReservasHuespedesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasHuespedesForm {
        ReservaId: Serenity.IntegerEditor;
        Nombre: Serenity.StringEditor;
        Apellidos: Serenity.StringEditor;
        TipoDocumentoId: Serenity.LookupEditor;
        Nif: Serenity.StringEditor;
        FechaDocumento: Serenity.DateEditor;
        SexoId: Serenity.LookupEditor;
        Direccion: Serenity.StringEditor;
        Poblacion: Serenity.StringEditor;
        Zip: Serenity.StringEditor;
        NacionId: Serenity.LookupEditor;
        ProvinciaId: Serenity.LookupEditor;
        Telefono: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        HuespedId: Serenity.IntegerEditor;
        FechaLlegada: Serenity.DateEditor;
        FechaSalida: Serenity.DateEditor;
        HabitacionId: Serenity.LookupEditor;
        Edad: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface ReservasHuespedesRow {
        ReservasHuespedesId?: number;
        ReservaId?: number;
        HuespedId?: number;
        FechaLlegada?: string;
        FechaSalida?: string;
        HabitacionId?: number;
        Edad?: number;
        ReservaHotelId?: number;
        ReservaEstadoReservaId?: number;
        ReservaFechaPrevistaLlegada?: string;
        ReservaFechaPrevistaSalida?: string;
        Nombre?: string;
        Apellidos?: string;
        NombreCompleto?: string;
        TipoDocumentoId?: string;
        TipoDocumento?: string;
        FechaDocumento?: string;
        Nif?: string;
        FechaNacimiento?: string;
        Direccion?: string;
        Poblacion?: string;
        ProvinciaId?: number;
        Provincia?: string;
        NacionId?: number;
        Nacion?: string;
        Telefono?: string;
        Email?: string;
        TarjetaFidelizacion?: string;
        NumeroHabitacion?: string;
        SexoId?: string;
        HotelId?: number;
        EmpresaId?: number;
    }
    namespace ReservasHuespedesRow {
        const idProperty = "ReservasHuespedesId";
        const localTextPrefix = "Recepcion.ReservasHuespedes";
        namespace Fields {
            const ReservasHuespedesId: string;
            const ReservaId: string;
            const HuespedId: string;
            const FechaLlegada: string;
            const FechaSalida: string;
            const HabitacionId: string;
            const Edad: string;
            const ReservaHotelId: string;
            const ReservaEstadoReservaId: string;
            const ReservaFechaPrevistaLlegada: string;
            const ReservaFechaPrevistaSalida: string;
            const Nombre: string;
            const Apellidos: string;
            const NombreCompleto: string;
            const TipoDocumentoId: string;
            const TipoDocumento: string;
            const FechaDocumento: string;
            const Nif: string;
            const FechaNacimiento: string;
            const Direccion: string;
            const Poblacion: string;
            const ProvinciaId: string;
            const Provincia: string;
            const NacionId: string;
            const Nacion: string;
            const Telefono: string;
            const Email: string;
            const TarjetaFidelizacion: string;
            const NumeroHabitacion: string;
            const SexoId: string;
            const HotelId: string;
            const EmpresaId: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace ReservasHuespedesService {
        const baseUrl = "Recepcion/ReservasHuespedes";
        function Create(request: Serenity.SaveRequest<ReservasHuespedesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasHuespedesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasHuespedesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasHuespedesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
    class ReservasOfertasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasOfertasForm {
        ReservaId: Serenity.IntegerEditor;
        OfertaId: Serenity.IntegerEditor;
        Tipo: Serenity.StringEditor;
        Activa: Serenity.IntegerEditor;
        OfertaUsada: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface ReservasOfertasRow {
        ReservaOfertaId?: number;
        ReservaId?: number;
        OfertaId?: number;
        Tipo?: string;
        Activa?: boolean;
        OfertaUsada?: boolean;
        UnidadCalculoId?: number;
        Texto?: string;
        N?: number;
        TipoOfertaId?: number;
        M?: number;
        TipoOfertaName?: string;
        UnidadCalculoName?: string;
    }
    namespace ReservasOfertasRow {
        const idProperty = "ReservaOfertaId";
        const nameProperty = "Tipo";
        const localTextPrefix = "Recepcion.ReservasOfertas";
        namespace Fields {
            const ReservaOfertaId: string;
            const ReservaId: string;
            const OfertaId: string;
            const Tipo: string;
            const Activa: string;
            const OfertaUsada: string;
            const UnidadCalculoId: string;
            const Texto: string;
            const N: string;
            const TipoOfertaId: string;
            const M: string;
            const TipoOfertaName: string;
            const UnidadCalculoName: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace ReservasOfertasService {
        const baseUrl = "Recepcion/ReservasOfertas";
        function Create(request: Serenity.SaveRequest<ReservasOfertasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasOfertasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasOfertasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasOfertasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    interface ReservasRow {
        ReservaId?: number;
        FechaCreacion?: string;
        HotelId?: number;
        EstadoReservaId?: number;
        ClienteId?: number;
        CanalReservaId?: number;
        ClienteIdFactura?: number;
        FechaReserva?: string;
        NombreReserva?: string;
        TipoHabitacionId?: number;
        PensionId?: number;
        Adultos?: number;
        Child50?: number;
        ChildFree?: number;
        Bebes?: number;
        Pax?: number;
        Vip?: boolean;
        FechaPrevistaLlegada?: string;
        FechaPrevistaSalida?: string;
        ObservacionesLlegada?: string;
        ObservacionesSalida?: string;
        ObservacionesCliente?: string;
        Observaciones?: string;
        FechaLlegada?: string;
        FechaSalida?: string;
        BonoReferencia?: string;
        BonoOnline?: string;
        BloquearTarifa?: boolean;
        PermiteDevolucion?: boolean;
        TipoTarjetaId?: number;
        TarjetaCredito?: string;
        Caducidad?: string;
        CodSeguridad?: string;
        ContratoTtoo?: string;
        CodigoOferta?: string;
        Valor?: number;
        ValorValidado?: number;
        FechaValidacion?: string;
        UsuarioValidacion?: number;
        ParoventasCheck?: boolean;
        CuposCheck?: boolean;
        ReleaseCheck?: boolean;
        ReservaDingus?: number[];
        DingusImpuestosIncluidos?: boolean;
        DingusComision?: number;
        ReservaDingusTipo?: number;
        FechaAnulacion?: string;
        UserId?: number;
        FechaModificacion?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        EstadoReserva?: string;
        TipoTarjeta?: string;
        ClienteRazon?: string;
        CanalReserva?: string;
        ClienteIdFacturaRazon?: string;
        TipoHabitacion?: string;
        Pension?: string;
        Username?: string;
        ValidationUsername?: string;
        ReservaName?: string;
    }
    namespace ReservasRow {
        const idProperty = "ReservaId";
        const nameProperty = "ReservaName";
        const localTextPrefix = "Recepcion.Reservas";
        namespace Fields {
            const ReservaId: string;
            const FechaCreacion: string;
            const HotelId: string;
            const EstadoReservaId: string;
            const ClienteId: string;
            const CanalReservaId: string;
            const ClienteIdFactura: string;
            const FechaReserva: string;
            const NombreReserva: string;
            const TipoHabitacionId: string;
            const PensionId: string;
            const Adultos: string;
            const Child50: string;
            const ChildFree: string;
            const Bebes: string;
            const Pax: string;
            const Vip: string;
            const FechaPrevistaLlegada: string;
            const FechaPrevistaSalida: string;
            const ObservacionesLlegada: string;
            const ObservacionesSalida: string;
            const ObservacionesCliente: string;
            const Observaciones: string;
            const FechaLlegada: string;
            const FechaSalida: string;
            const BonoReferencia: string;
            const BonoOnline: string;
            const BloquearTarifa: string;
            const PermiteDevolucion: string;
            const TipoTarjetaId: string;
            const TarjetaCredito: string;
            const Caducidad: string;
            const CodSeguridad: string;
            const ContratoTtoo: string;
            const CodigoOferta: string;
            const Valor: string;
            const ValorValidado: string;
            const FechaValidacion: string;
            const UsuarioValidacion: string;
            const ParoventasCheck: string;
            const CuposCheck: string;
            const ReleaseCheck: string;
            const ReservaDingus: string;
            const DingusImpuestosIncluidos: string;
            const DingusComision: string;
            const ReservaDingusTipo: string;
            const FechaAnulacion: string;
            const UserId: string;
            const FechaModificacion: string;
            const HotelName: string;
            const EmpresaId: string;
            const Empresa: string;
            const EstadoReserva: string;
            const TipoTarjeta: string;
            const ClienteRazon: string;
            const CanalReserva: string;
            const ClienteIdFacturaRazon: string;
            const TipoHabitacion: string;
            const Pension: string;
            const Username: string;
            const ValidationUsername: string;
            const ReservaName: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace ReservasService {
        const baseUrl = "Recepcion/Reservas";
        function Create(request: Serenity.SaveRequest<ReservasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ChangeReservationStatus(request: ChangeReservationStatusRequest, onSuccess?: (response: ChangeReservationStatusResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function CheckIn(request: CheckInRequest, onSuccess?: (response: CheckInResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
            const ChangeReservationStatus: string;
            const CheckIn: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
}
declare namespace Geshotel.Recepcion {
    class ReservasServiciosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasServiciosForm {
        ReservaId: Serenity.IntegerEditor;
        ServicioId: Serenity.LookupEditor;
        UnidadCalculoId: Serenity.LookupEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Cantidad: Serenity.DecimalEditor;
        FlagContrato: Serenity.IntegerEditor;
        PrecioServicio: Serenity.DecimalEditor;
        ServicioExtra: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Recepcion {
    interface ReservasServiciosRow {
        ServicioReservaId?: number;
        ReservaId?: number;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Cantidad?: number;
        UserId?: number;
        FechaModificacion?: string;
        FlagContrato?: number;
        PrecioServicio?: number;
        ServicioExtra?: number;
        ServicioNombreServicio?: string;
        UnidadCalculo?: string;
        Username?: string;
    }
    namespace ReservasServiciosRow {
        const idProperty = "ServicioReservaId";
        const localTextPrefix = "Recepcion.ReservasServicios";
        namespace Fields {
            const ServicioReservaId: string;
            const ReservaId: string;
            const ServicioId: string;
            const UnidadCalculoId: string;
            const FechaDesde: string;
            const FechaHasta: string;
            const Cantidad: string;
            const UserId: string;
            const FechaModificacion: string;
            const FlagContrato: string;
            const PrecioServicio: string;
            const ServicioExtra: string;
            const ServicioNombreServicio: string;
            const UnidadCalculo: string;
            const Username: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    namespace ReservasServiciosService {
        const baseUrl = "Recepcion/ReservasServicios";
        function Create(request: Serenity.SaveRequest<ReservasServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasServiciosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasServiciosRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Recepcion {
    enum ReservationStatus {
        WithErrors = 0,
        ArrivalPending = 1,
        Cancelled = 2,
        CheckedIn = 3,
        PreCheckedOut = 4,
        CheckedOut = 5,
        NoShow = 6,
    }
}
declare namespace Geshotel.Reservas {
    class ReservasContratosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasContratosForm {
        ReservaId: Serenity.IntegerEditor;
        ContratoId: Serenity.IntegerEditor;
        Directo: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Reservas {
    interface ReservasContratosRow {
        ReservaContratoId?: number;
        ReservaId?: number;
        ContratoId?: number;
        Directo?: number;
    }
    namespace ReservasContratosRow {
        const idProperty = "ReservaContratoId";
        const localTextPrefix = "Reservas.ReservasContratos";
        namespace Fields {
            const ReservaContratoId: any;
            const ReservaId: any;
            const ContratoId: any;
            const Directo: any;
        }
    }
}
declare namespace Geshotel.Reservas {
    namespace ReservasContratosService {
        const baseUrl = "Reservas/ReservasContratos";
        function Create(request: Serenity.SaveRequest<ReservasContratosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasContratosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasContratosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasContratosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Reservas {
    class ReservasDescuentosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasDescuentosForm {
        ReservaId: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
        TipoDescuentoId: Serenity.IntegerEditor;
        Tipo: Serenity.StringEditor;
        Descuento: Serenity.DecimalEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
    }
}
declare namespace Geshotel.Reservas {
    interface ReservasDescuentosRow {
        ReservaDescuentoId?: number;
        ReservaId?: number;
        ServicioId?: number;
        TipoDescuentoId?: number;
        Tipo?: string;
        Descuento?: number;
        UserId?: number;
        FechaModificacion?: string;
        ReservaFechaCreacion?: string;
        ReservaHotelId?: number;
        ReservaEstadoReservaId?: number;
        ReservaClienteId?: number;
        ReservaCanalReservaId?: number;
        ReservaClienteIdFactura?: number;
        ReservaFechaReserva?: string;
        ReservaNombreReserva?: string;
        ReservaFechaPrevistaLlegada?: string;
        ReservaFechaPrevistaSalida?: string;
        ReservaHoraPrevistaLlegada?: string;
        ReservaHoraPrevistaSalida?: string;
        ReservaObservacionesLlegada?: string;
        ReservaObservacionesSalida?: string;
        ReservaObservacionesCliente?: string;
        ReservaObservaciones?: string;
        ReservaFechaLlegada?: string;
        ReservaFechaSalida?: string;
        ReservaBonoReferencia?: string;
        ReservaBonoOnline?: string;
        ReservaBloquearTarifa?: number;
        ReservaPermiteDevolucion?: number;
        ReservaTipoTarjetaId?: number;
        ReservaTarjetaCredito?: string;
        ReservaCaducidad?: string;
        ReservaCodSeguridad?: string;
        ReservaContratoTtoo?: string;
        ReservaCodigoOferta?: string;
        ReservaValor?: number;
        ReservaValorValidado?: number;
        ReservaFechaValidacion?: string;
        ReservaUsuarioValidacion?: number;
        ReservaParoventasCheck?: number;
        ReservaCuposCheck?: number;
        ReservaReleaseCheck?: number;
        ReservaReservaDingus?: number[];
        ReservaDingusImpuestosIncluidos?: number;
        ReservaDingusComision?: number;
        ReservaReservaDingusTipo?: number;
        ReservaFechaAnulacion?: string;
        ReservaUserId?: number;
        ReservaFechaModificacion?: string;
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
        TipoDescuentoDescuento?: string;
        TipoDescripcion?: string;
    }
    namespace ReservasDescuentosRow {
        const idProperty = "ReservaDescuentoId";
        const nameProperty = "Tipo";
        const localTextPrefix = "Reservas.ReservasDescuentos";
        namespace Fields {
            const ReservaDescuentoId: any;
            const ReservaId: any;
            const ServicioId: any;
            const TipoDescuentoId: any;
            const Tipo: any;
            const Descuento: any;
            const UserId: any;
            const FechaModificacion: any;
            const ReservaFechaCreacion: string;
            const ReservaHotelId: string;
            const ReservaEstadoReservaId: string;
            const ReservaClienteId: string;
            const ReservaCanalReservaId: string;
            const ReservaClienteIdFactura: string;
            const ReservaFechaReserva: string;
            const ReservaNombreReserva: string;
            const ReservaFechaPrevistaLlegada: string;
            const ReservaFechaPrevistaSalida: string;
            const ReservaHoraPrevistaLlegada: string;
            const ReservaHoraPrevistaSalida: string;
            const ReservaObservacionesLlegada: string;
            const ReservaObservacionesSalida: string;
            const ReservaObservacionesCliente: string;
            const ReservaObservaciones: string;
            const ReservaFechaLlegada: string;
            const ReservaFechaSalida: string;
            const ReservaBonoReferencia: string;
            const ReservaBonoOnline: string;
            const ReservaBloquearTarifa: string;
            const ReservaPermiteDevolucion: string;
            const ReservaTipoTarjetaId: string;
            const ReservaTarjetaCredito: string;
            const ReservaCaducidad: string;
            const ReservaCodSeguridad: string;
            const ReservaContratoTtoo: string;
            const ReservaCodigoOferta: string;
            const ReservaValor: string;
            const ReservaValorValidado: string;
            const ReservaFechaValidacion: string;
            const ReservaUsuarioValidacion: string;
            const ReservaParoventasCheck: string;
            const ReservaCuposCheck: string;
            const ReservaReleaseCheck: string;
            const ReservaReservaDingus: string;
            const ReservaDingusImpuestosIncluidos: string;
            const ReservaDingusComision: string;
            const ReservaReservaDingusTipo: string;
            const ReservaFechaAnulacion: string;
            const ReservaUserId: string;
            const ReservaFechaModificacion: string;
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
            const TipoDescuentoDescuento: string;
            const TipoDescripcion: string;
        }
    }
}
declare namespace Geshotel.Reservas {
    namespace ReservasDescuentosService {
        const baseUrl = "Reservas/ReservasDescuentos";
        function Create(request: Serenity.SaveRequest<ReservasDescuentosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasDescuentosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasDescuentosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasDescuentosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Reservas {
    class ReservasHuespedesForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasHuespedesForm {
        ReservaId: Serenity.IntegerEditor;
        ClienteId: Serenity.IntegerEditor;
        FechaLlegada: Serenity.DateEditor;
        FechaSalida: Serenity.DateEditor;
        HabitacionId: Serenity.IntegerEditor;
        TipoHuespedId: Serenity.IntegerEditor;
        Edad: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Reservas {
    interface ReservasHuespedesRow {
        ReservasHuespedesId?: number;
        ReservaId?: number;
        ClienteId?: number;
        FechaLlegada?: string;
        FechaSalida?: string;
        HabitacionId?: number;
        TipoHuespedId?: number;
        Edad?: number;
        ReservaFechaCreacion?: string;
        ReservaHotelId?: number;
        ReservaEstadoReservaId?: number;
        ReservaClienteId?: number;
        ReservaCanalReservaId?: number;
        ReservaClienteIdFactura?: number;
        ReservaFechaReserva?: string;
        ReservaNombreReserva?: string;
        ReservaFechaPrevistaLlegada?: string;
        ReservaFechaPrevistaSalida?: string;
        ReservaHoraPrevistaLlegada?: string;
        ReservaHoraPrevistaSalida?: string;
        ReservaObservacionesLlegada?: string;
        ReservaObservacionesSalida?: string;
        ReservaObservacionesCliente?: string;
        ReservaObservaciones?: string;
        ReservaFechaLlegada?: string;
        ReservaFechaSalida?: string;
        ReservaBonoReferencia?: string;
        ReservaBonoOnline?: string;
        ReservaBloquearTarifa?: number;
        ReservaPermiteDevolucion?: number;
        ReservaTipoTarjetaId?: number;
        ReservaTarjetaCredito?: string;
        ReservaCaducidad?: string;
        ReservaCodSeguridad?: string;
        ReservaContratoTtoo?: string;
        ReservaCodigoOferta?: string;
        ReservaValor?: number;
        ReservaValorValidado?: number;
        ReservaFechaValidacion?: string;
        ReservaUsuarioValidacion?: number;
        ReservaParoventasCheck?: number;
        ReservaCuposCheck?: number;
        ReservaReleaseCheck?: number;
        ReservaReservaDingus?: number[];
        ReservaDingusImpuestosIncluidos?: number;
        ReservaDingusComision?: number;
        ReservaReservaDingusTipo?: number;
        ReservaFechaAnulacion?: string;
        ReservaUserId?: number;
        ReservaFechaModificacion?: string;
    }
    namespace ReservasHuespedesRow {
        const idProperty = "ReservasHuespedesId";
        const localTextPrefix = "Reservas.ReservasHuespedes";
        namespace Fields {
            const ReservasHuespedesId: any;
            const ReservaId: any;
            const ClienteId: any;
            const FechaLlegada: any;
            const FechaSalida: any;
            const HabitacionId: any;
            const TipoHuespedId: any;
            const Edad: any;
            const ReservaFechaCreacion: string;
            const ReservaHotelId: string;
            const ReservaEstadoReservaId: string;
            const ReservaClienteId: string;
            const ReservaCanalReservaId: string;
            const ReservaClienteIdFactura: string;
            const ReservaFechaReserva: string;
            const ReservaNombreReserva: string;
            const ReservaFechaPrevistaLlegada: string;
            const ReservaFechaPrevistaSalida: string;
            const ReservaHoraPrevistaLlegada: string;
            const ReservaHoraPrevistaSalida: string;
            const ReservaObservacionesLlegada: string;
            const ReservaObservacionesSalida: string;
            const ReservaObservacionesCliente: string;
            const ReservaObservaciones: string;
            const ReservaFechaLlegada: string;
            const ReservaFechaSalida: string;
            const ReservaBonoReferencia: string;
            const ReservaBonoOnline: string;
            const ReservaBloquearTarifa: string;
            const ReservaPermiteDevolucion: string;
            const ReservaTipoTarjetaId: string;
            const ReservaTarjetaCredito: string;
            const ReservaCaducidad: string;
            const ReservaCodSeguridad: string;
            const ReservaContratoTtoo: string;
            const ReservaCodigoOferta: string;
            const ReservaValor: string;
            const ReservaValorValidado: string;
            const ReservaFechaValidacion: string;
            const ReservaUsuarioValidacion: string;
            const ReservaParoventasCheck: string;
            const ReservaCuposCheck: string;
            const ReservaReleaseCheck: string;
            const ReservaReservaDingus: string;
            const ReservaDingusImpuestosIncluidos: string;
            const ReservaDingusComision: string;
            const ReservaReservaDingusTipo: string;
            const ReservaFechaAnulacion: string;
            const ReservaUserId: string;
            const ReservaFechaModificacion: string;
        }
    }
}
declare namespace Geshotel.Reservas {
    namespace ReservasHuespedesService {
        const baseUrl = "Reservas/ReservasHuespedes";
        function Create(request: Serenity.SaveRequest<ReservasHuespedesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasHuespedesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasHuespedesRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasHuespedesRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.Reservas {
    class ReservasOfertasForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasOfertasForm {
        ReservaId: Serenity.IntegerEditor;
        OfertaId: Serenity.IntegerEditor;
        Tipo: Serenity.StringEditor;
        Activa: Serenity.IntegerEditor;
        OfertaUsada: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.Reservas {
    interface ReservasOfertasRow {
        ReservaOfertaId?: number;
        ReservaId?: number;
        OfertaId?: number;
        Tipo?: string;
        Activa?: number;
        OfertaUsada?: number;
    }
    namespace ReservasOfertasRow {
        const idProperty = "ReservaOfertaId";
        const nameProperty = "Tipo";
        const localTextPrefix = "Reservas.ReservasOfertas";
        namespace Fields {
            const ReservaOfertaId: any;
            const ReservaId: any;
            const OfertaId: any;
            const Tipo: any;
            const Activa: any;
            const OfertaUsada: any;
        }
    }
}
declare namespace Geshotel.Reservas {
    namespace ReservasOfertasService {
        const baseUrl = "Reservas/ReservasOfertas";
        function Create(request: Serenity.SaveRequest<ReservasOfertasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasOfertasRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasOfertasRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasOfertasRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Geshotel.reservas {
    class ReservasServiciosForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ReservasServiciosForm {
        ReservaId: Serenity.IntegerEditor;
        ServicioId: Serenity.IntegerEditor;
        UnidadCalculoId: Serenity.IntegerEditor;
        FechaDesde: Serenity.DateEditor;
        FechaHasta: Serenity.DateEditor;
        Cantidad: Serenity.DecimalEditor;
        UserId: Serenity.IntegerEditor;
        FechaModificacion: Serenity.DateEditor;
        FlagContrato: Serenity.IntegerEditor;
        PrecioServicio: Serenity.DecimalEditor;
        ServicioExtra: Serenity.IntegerEditor;
    }
}
declare namespace Geshotel.reservas {
    interface ReservasServiciosRow {
        ServicioReservaId?: number;
        ReservaId?: number;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Cantidad?: number;
        UserId?: number;
        FechaModificacion?: string;
        FlagContrato?: number;
        PrecioServicio?: number;
        ServicioExtra?: number;
        ReservaFechaCreacion?: string;
        ReservaHotelId?: number;
        ReservaEstadoReservaId?: number;
        ReservaClienteId?: number;
        ReservaCanalReservaId?: number;
        ReservaClienteIdFactura?: number;
        ReservaFechaReserva?: string;
        ReservaNombreReserva?: string;
        ReservaFechaPrevistaLlegada?: string;
        ReservaFechaPrevistaSalida?: string;
        ReservaHoraPrevistaLlegada?: string;
        ReservaHoraPrevistaSalida?: string;
        ReservaObservacionesLlegada?: string;
        ReservaObservacionesSalida?: string;
        ReservaObservacionesCliente?: string;
        ReservaObservaciones?: string;
        ReservaFechaLlegada?: string;
        ReservaFechaSalida?: string;
        ReservaBonoReferencia?: string;
        ReservaBonoOnline?: string;
        ReservaBloquearTarifa?: number;
        ReservaPermiteDevolucion?: number;
        ReservaTipoTarjetaId?: number;
        ReservaTarjetaCredito?: string;
        ReservaCaducidad?: string;
        ReservaCodSeguridad?: string;
        ReservaContratoTtoo?: string;
        ReservaCodigoOferta?: string;
        ReservaValor?: number;
        ReservaValorValidado?: number;
        ReservaFechaValidacion?: string;
        ReservaUsuarioValidacion?: number;
        ReservaParoventasCheck?: number;
        ReservaCuposCheck?: number;
        ReservaReleaseCheck?: number;
        ReservaReservaDingus?: number[];
        ReservaDingusImpuestosIncluidos?: number;
        ReservaDingusComision?: number;
        ReservaReservaDingusTipo?: number;
        ReservaFechaAnulacion?: string;
        ReservaUserId?: number;
        ReservaFechaModificacion?: string;
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
        UserUsername?: string;
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
        UserEmpresaId?: number;
        UserHotelId?: number;
    }
    namespace ReservasServiciosRow {
        const idProperty = "ServicioReservaId";
        const localTextPrefix = "reservas.ReservasServicios";
        namespace Fields {
            const ServicioReservaId: any;
            const ReservaId: any;
            const ServicioId: any;
            const UnidadCalculoId: any;
            const FechaDesde: any;
            const FechaHasta: any;
            const Cantidad: any;
            const UserId: any;
            const FechaModificacion: any;
            const FlagContrato: any;
            const PrecioServicio: any;
            const ServicioExtra: any;
            const ReservaFechaCreacion: string;
            const ReservaHotelId: string;
            const ReservaEstadoReservaId: string;
            const ReservaClienteId: string;
            const ReservaCanalReservaId: string;
            const ReservaClienteIdFactura: string;
            const ReservaFechaReserva: string;
            const ReservaNombreReserva: string;
            const ReservaFechaPrevistaLlegada: string;
            const ReservaFechaPrevistaSalida: string;
            const ReservaHoraPrevistaLlegada: string;
            const ReservaHoraPrevistaSalida: string;
            const ReservaObservacionesLlegada: string;
            const ReservaObservacionesSalida: string;
            const ReservaObservacionesCliente: string;
            const ReservaObservaciones: string;
            const ReservaFechaLlegada: string;
            const ReservaFechaSalida: string;
            const ReservaBonoReferencia: string;
            const ReservaBonoOnline: string;
            const ReservaBloquearTarifa: string;
            const ReservaPermiteDevolucion: string;
            const ReservaTipoTarjetaId: string;
            const ReservaTarjetaCredito: string;
            const ReservaCaducidad: string;
            const ReservaCodSeguridad: string;
            const ReservaContratoTtoo: string;
            const ReservaCodigoOferta: string;
            const ReservaValor: string;
            const ReservaValorValidado: string;
            const ReservaFechaValidacion: string;
            const ReservaUsuarioValidacion: string;
            const ReservaParoventasCheck: string;
            const ReservaCuposCheck: string;
            const ReservaReleaseCheck: string;
            const ReservaReservaDingus: string;
            const ReservaDingusImpuestosIncluidos: string;
            const ReservaDingusComision: string;
            const ReservaReservaDingusTipo: string;
            const ReservaFechaAnulacion: string;
            const ReservaUserId: string;
            const ReservaFechaModificacion: string;
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
            const UserUsername: string;
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
            const UserEmpresaId: string;
            const UserHotelId: string;
        }
    }
}
declare namespace Geshotel.reservas {
    namespace ReservasServiciosService {
        const baseUrl = "reservas/ReservasServicios";
        function Create(request: Serenity.SaveRequest<ReservasServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReservasServiciosRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReservasServiciosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReservasServiciosRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
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
    interface ScriptUserDefinition {
        Username?: string;
        DisplayName?: string;
        IsAdmin?: boolean;
        Permissions?: {
            [key: string]: boolean;
        };
        EmpresaId?: number;
        HotelId?: number;
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
declare namespace Geshotel.ScriptInitialization {
}
declare namespace Geshotel.Common {
    class UserPreferenceStorage implements Serenity.SettingStorage {
        getItem(key: string): string;
        setItem(key: string, data: string): void;
    }
}
declare namespace Geshotel.Contratos {
    class AgenciasDialog extends Serenity.EntityDialog<AgenciasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AgenciasForm;
    }
}
declare namespace Geshotel.Contratos {
    class AgenciasGrid extends Serenity.EntityGrid<AgenciasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AgenciasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class CajasDialog extends Serenity.EntityDialog<CajasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CajasForm;
    }
}
declare namespace Geshotel.Contratos {
    class CajasGrid extends Serenity.EntityGrid<CajasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof CajasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class CanalesReservaDialog extends Serenity.EntityDialog<CanalesReservaRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CanalesReservaForm;
    }
}
declare namespace Geshotel.Contratos {
    class CanalesReservaGrid extends Serenity.EntityGrid<CanalesReservaRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof CanalesReservaDialog;
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
declare namespace Geshotel.Contratos {
    class ContadoresDialog extends Serenity.EntityDialog<ContadoresRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: ContadoresForm;
    }
}
declare namespace Geshotel.Contratos {
    class ContadoresGrid extends Serenity.EntityGrid<ContadoresRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ContadoresDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class CuposDialog extends Serenity.EntityDialog<CuposRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: CuposForm;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosCuposDialog extends CuposDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosCuposGrid extends Serenity.EntityGrid<CuposGrid, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDialogType(): typeof ContratosCuposDialog;
        constructor(container: JQuery);
        protected addButtonClick(): void;
        getButtons(): Serenity.ToolButton[];
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        protected onViewSubmit(): boolean;
        private _hotelID;
        hotelID: number;
        private _clienteID;
        clienteID: number;
        private _fechaDesde;
        fechaDesde: string;
        private _fechaHasta;
        fechaHasta: string;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosDialog extends Serenity.EntityDialog<ContratosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ContratosForm;
        private lineasGrid;
        private cuposGrid;
        private ofertasGrid;
        private releasesGrid;
        private edadesGrid;
        constructor();
        protected afterLoadEntity(): void;
    }
}
declare namespace Geshotel.Contratos {
    class EdadesDialog extends Serenity.EntityDialog<EdadesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: EdadesForm;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosEdadesDialog extends EdadesDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosEdadesGrid extends Serenity.EntityGrid<EdadesGrid, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDialogType(): typeof ContratosEdadesDialog;
        constructor(container: JQuery);
        protected addButtonClick(): void;
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        protected onViewSubmit(): boolean;
        private _hotelID;
        hotelID: number;
        private _clienteID;
        clienteID: number;
        private _fechaDesde;
        fechaDesde: string;
        private _fechaHasta;
        fechaHasta: string;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosGrid extends Serenity.EntityGrid<ContratosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ContratosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Contratos {
    class LineasDialog extends Serenity.EntityDialog<LineasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: LineasForm;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosLineasDialog extends LineasDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosLineasGrid extends Serenity.EntityGrid<LineasGrid, any> {
        protected getDialogType(): typeof ContratosLineasDialog;
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected initEntityDialog(itemType: any, dialog: any): void;
        protected addButtonClick(): void;
        getButtons(): Serenity.ToolButton[];
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _contratoID;
        private _hotelID;
        contratoID: number;
        hotelID: number;
    }
}
declare namespace Geshotel.Contratos {
    class OfertasDialog extends Serenity.EntityDialog<OfertasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: OfertasForm;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosOfertasDialog extends OfertasDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosOfertasGrid extends Serenity.EntityGrid<OfertasGrid, any> {
        protected getDialogType(): typeof ContratosOfertasDialog;
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected initEntityDialog(itemType: any, dialog: any): void;
        protected addButtonClick(): void;
        getButtons(): Serenity.ToolButton[];
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _contratoID;
        contratoID: number;
    }
}
declare namespace Geshotel.Contratos {
    class ReleasesDialog extends Serenity.EntityDialog<ReleasesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ReleasesForm;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosReleasesDialog extends ReleasesDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Geshotel.Contratos {
    class ContratosReleasesGrid extends Serenity.EntityGrid<ReleasesGrid, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDialogType(): typeof ContratosReleasesDialog;
        constructor(container: JQuery);
        protected addButtonClick(): void;
        getButtons(): Serenity.ToolButton[];
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        protected onViewSubmit(): boolean;
        private _hotelID;
        hotelID: number;
        private _clienteID;
        clienteID: number;
        private _fechaDesde;
        fechaDesde: string;
        private _fechaHasta;
        fechaHasta: string;
    }
}
declare namespace Geshotel.Contratos {
    class CuposGrid extends Serenity.EntityGrid<CuposRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof CuposDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Contratos {
    class EdadesGrid extends Serenity.EntityGrid<EdadesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof EdadesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class HabitacionesDialog extends Serenity.EntityDialog<HabitacionesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: HabitacionesForm;
    }
}
declare namespace Geshotel.Contratos {
    class HabitacionesGrid extends Serenity.EntityGrid<HabitacionesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof HabitacionesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class LineasGrid extends Serenity.EntityGrid<LineasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LineasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class MercadosDialog extends Serenity.EntityDialog<MercadosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MercadosForm;
    }
}
declare namespace Geshotel.Contratos {
    class MercadosGrid extends Serenity.EntityGrid<MercadosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MercadosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class OfertasGrid extends Serenity.EntityGrid<OfertasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof OfertasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class OfertasRejillasDialog extends Serenity.EntityDialog<OfertasRejillasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: OfertasRejillasForm;
    }
}
declare namespace Geshotel.Contratos {
    class OfertasRejillasGrid extends Serenity.EntityGrid<OfertasRejillasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof OfertasRejillasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class ReleasesGrid extends Serenity.EntityGrid<ReleasesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReleasesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class SeriesDialog extends Serenity.EntityDialog<SeriesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: SeriesForm;
    }
}
declare namespace Geshotel.Contratos {
    class SeriesGrid extends Serenity.EntityGrid<SeriesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof SeriesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class ServiciosHotelDialog extends Serenity.EntityDialog<ServiciosHotelRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ServiciosHotelForm;
    }
}
declare namespace Geshotel.Contratos {
    class ServiciosHotelGrid extends Serenity.EntityGrid<ServiciosHotelRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServiciosHotelDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class TemporadasDialog extends Serenity.EntityDialog<TemporadasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TemporadasForm;
    }
}
declare namespace Geshotel.Contratos {
    class TemporadasGrid extends Serenity.EntityGrid<TemporadasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TemporadasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Contratos {
    class TiposHabitacionHotelDialog extends Serenity.EntityDialog<TiposHabitacionHotelRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TiposHabitacionHotelForm;
        protected updateInterface(): void;
        loadEntity(entity: TiposHabitacionHotelRow): void;
    }
}
declare namespace Geshotel.Contratos {
    class TiposHabitacionHotelGrid extends Serenity.EntityGrid<TiposHabitacionHotelRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposHabitacionHotelDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
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
declare namespace Geshotel.Membership {
    class ChangePasswordPanel extends Serenity.PropertyPanel<ChangePasswordRequest, any> {
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
    class LoginPanel extends Serenity.PropertyPanel<LoginRequest, any> {
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
    class SignUpPanel extends Serenity.PropertyPanel<SignUpRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
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
    class CustomerOrderDialog extends OrderDialog {
        constructor();
        updateInterface(): void;
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
    class EmployeeFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
        genderProperty: string;
        initializeColumn(column: Slick.Column): void;
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
    class FreightFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
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
declare namespace Geshotel.Portal {
    class AmbitoOfertaDialog extends Serenity.EntityDialog<AmbitoOfertaRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AmbitoOfertaForm;
    }
}
declare namespace Geshotel.Portal {
    class AmbitoOfertaGrid extends Serenity.EntityGrid<AmbitoOfertaRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AmbitoOfertaDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
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
    class FrecuenciaFacturacionDialog extends Serenity.EntityDialog<FrecuenciaFacturacionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: FrecuenciaFacturacionForm;
    }
}
declare namespace Geshotel.Portal {
    class FrecuenciaFacturacionGrid extends Serenity.EntityGrid<FrecuenciaFacturacionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof FrecuenciaFacturacionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class GruposDeClienteDialog extends Serenity.EntityDialog<GruposDeClienteRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: GruposDeClienteForm;
    }
}
declare namespace Geshotel.Portal {
    class GruposDeClienteGrid extends Serenity.EntityGrid<GruposDeClienteRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof GruposDeClienteDialog;
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
    class HabitacionesSituacionDialog extends Serenity.EntityDialog<HabitacionesSituacionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: HabitacionesSituacionForm;
    }
}
declare namespace Geshotel.Portal {
    class HabitacionesSituacionGrid extends Serenity.EntityGrid<HabitacionesSituacionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof HabitacionesSituacionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
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
    class ImpuestosDialog extends Serenity.EntityDialog<ImpuestosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ImpuestosForm;
    }
}
declare namespace Geshotel.Portal {
    class ImpuestosGrid extends Serenity.EntityGrid<ImpuestosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ImpuestosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
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
    class TipoAplicacionOfertaDialog extends Serenity.EntityDialog<TipoAplicacionOfertaRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TipoAplicacionOfertaForm;
    }
}
declare namespace Geshotel.Portal {
    class TipoAplicacionOfertaGrid extends Serenity.EntityGrid<TipoAplicacionOfertaRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TipoAplicacionOfertaDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposBloqueoDialog extends Serenity.EntityDialog<TiposBloqueoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposBloqueoForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposBloqueoGrid extends Serenity.EntityGrid<TiposBloqueoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposBloqueoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposCondicionDialog extends Serenity.EntityDialog<TiposCondicionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposCondicionForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposCondicionGrid extends Serenity.EntityGrid<TiposCondicionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposCondicionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposDeImputacionDialog extends Serenity.EntityDialog<TiposDeImputacionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposDeImputacionForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposDeImputacionGrid extends Serenity.EntityGrid<TiposDeImputacionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposDeImputacionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposDeOfertaDialog extends Serenity.EntityDialog<TiposDeOfertaRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposDeOfertaForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposDeOfertaGrid extends Serenity.EntityGrid<TiposDeOfertaRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposDeOfertaDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Portal {
    class TiposDeTarjetaDialog extends Serenity.EntityDialog<TiposDeTarjetaRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TiposDeTarjetaForm;
    }
}
declare namespace Geshotel.Portal {
    class TiposDeTarjetaGrid extends Serenity.EntityGrid<TiposDeTarjetaRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TiposDeTarjetaDialog;
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
/*********************************************************************************************************************************
Cambiamos el css si el estado de la reserva es con errores, la ponemos en rojo " out-of-stock"
Si está pendiente de entrar o de salir la pondremos en Naranja (estado = 2 y llegada = hoy o estado =3 o 4 y salida = hoy)
Gris si estado =1 o si estado= 5. Normal el resto.
!!!! IMPORTANTE !!!!  Ir a site.recepcion.less y crear los estilos. Si no, no rula
Javier Núñez : ABRIL 2017
**********************************************************************************************************************************/
declare namespace Geshotel.Recepcion {
    class ReservasGrid extends Serenity.EntityGrid<ReservasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReservasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
        /**
 * This method is called for all rows
 * @param item Data item for current row
 * @param index Index of the row in grid
 */
        protected getItemCssClass(item: Recepcion.ReservasRow, index: number): string;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
/************************************************************************************************************************************************************
Arrivals List
What I try to do is the following:

1.- Filter Reservations with status = ArrivalPending and FechaPervistaLLegada = FechaHotel. As I do not know how to get it, i use currentdate instead
2.- Select Reservations end user wants to checkIn and Add a button to do it

Javier Núñez : APRIL 2017
*************************************************************************************************************************************************************/
declare namespace Geshotel.Recepcion {
    class ArrivalsGrid extends Recepcion.ReservasGrid {
        private rowSelection;
        constructor(container: JQuery);
        protected createToolbarExtensions(): void;
        getInitialTitle(): string;
        getButtons(): {
            title: string;
            cssClass: string;
            icon: string;
            onClick: () => void;
        }[];
        protected getColumns(): Slick.Column[];
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Geshotel.Recepcion {
    class CheckInAction extends Common.BulkServiceAction {
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
declare namespace Geshotel.Recepcion {
    class HabitacionesBloqueosDialog extends Serenity.EntityDialog<HabitacionesBloqueosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: HabitacionesBloqueosForm;
    }
}
declare namespace Geshotel.Recepcion {
    class HabitacionesBloqueosGrid extends Serenity.EntityGrid<HabitacionesBloqueosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof HabitacionesBloqueosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Recepcion {
    class HuespedesDialog extends Serenity.EntityDialog<HuespedesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: HuespedesForm;
    }
}
declare namespace Geshotel.Recepcion {
    class HuespedesGrid extends Serenity.EntityGrid<HuespedesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof HuespedesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasDialog extends Serenity.EntityDialog<ReservasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ReservasForm;
        private HabitacionesBloqueosGrid;
        private ReservasServiciosGrid;
        private ReservasHuespedesGrid;
        private ReservasContratosGrid;
        private ReservasDescuentosGrid;
        private ReservasOfertasGrid;
        constructor();
        protected afterLoadEntity(): void;
        protected onSaveSuccess(response: Serenity.SaveResponse): void;
        protected updateInterface(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasHabitacionesBloqueosDialog extends HabitacionesBloqueosDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasHabitacionesBloqueosGrid extends Serenity.EntityGrid<HabitacionesBloqueosGrid, any> {
        protected getDialogType(): typeof ReservasHabitacionesBloqueosDialog;
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected initEntityDialog(itemType: any, dialog: any): void;
        protected addButtonClick(): void;
        getButtons(): Serenity.ToolButton[];
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _reservaID;
        private _tipoBloqueoID;
        tipoBloqueoID: number;
        reservaID: number;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasContratosGrid extends Serenity.EntityGrid<ReservasContratosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReservasContratosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _reservaID;
        reservaID: number;
        /**
  * This method is called to get list of buttons to be created.
  */
        protected getButtons(): Serenity.ToolButton[];
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace Geshotel.Recepcion {
    class RemovingReservasContratosAddButton extends Recepcion.ReservasContratosGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of buttons to be created.
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasContratosDialog extends Serenity.EntityDialog<ReservasContratosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: ReservasContratosForm;
        updateInterface(): void;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasDescuentosDialog extends Serenity.EntityDialog<ReservasDescuentosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ReservasDescuentosForm;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasDescuentosGrid extends Serenity.EntityGrid<ReservasDescuentosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReservasDescuentosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _reservaID;
        reservaID: number;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasHuespedesDialog extends Serenity.EntityDialog<ReservasHuespedesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: ReservasHuespedesForm;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasHuespedesGrid extends Serenity.EntityGrid<ReservasHuespedesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReservasHuespedesDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected initEntityDialog(itemType: any, dialog: any): void;
        protected addButtonClick(): void;
        getButtons(): Serenity.ToolButton[];
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _reservaID;
        private _empresaID;
        reservaID: number;
        empresaID: number;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasOfertasGrid extends Serenity.EntityGrid<ReservasOfertasRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReservasOfertasDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _reservaID;
        reservaID: number;
        /**
  * This method is called to get list of buttons to be created.
  */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Recepcion {
    class RemovingReservasOfertasAddButton extends Recepcion.ReservasOfertasGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of buttons to be created.
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasOfertasDialog extends Serenity.EntityDialog<ReservasOfertasRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ReservasOfertasForm;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasServiciosDialog extends Serenity.EntityDialog<ReservasServiciosRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: ReservasServiciosForm;
    }
}
declare namespace Geshotel.Recepcion {
    class ReservasServiciosGrid extends Serenity.EntityGrid<ReservasServiciosRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReservasServiciosDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getInitialTitle(): any;
        protected addButtonClick(): void;
        protected getGridCanLoad(): boolean;
        private _reservaID;
        private _flagcontrato;
        flagcontrato: number;
        reservaID: number;
    }
}
