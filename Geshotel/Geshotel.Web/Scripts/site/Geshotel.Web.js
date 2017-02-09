var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var LanguageDialog = (function (_super) {
            __extends(LanguageDialog, _super);
            function LanguageDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Administration.LanguageForm(_this.idPrefix);
                return _this;
            }
            LanguageDialog.prototype.getFormKey = function () { return Administration.LanguageForm.formKey; };
            LanguageDialog.prototype.getIdProperty = function () { return Administration.LanguageRow.idProperty; };
            LanguageDialog.prototype.getLocalTextPrefix = function () { return Administration.LanguageRow.localTextPrefix; };
            LanguageDialog.prototype.getNameProperty = function () { return Administration.LanguageRow.nameProperty; };
            LanguageDialog.prototype.getService = function () { return Administration.LanguageService.baseUrl; };
            return LanguageDialog;
        }(Serenity.EntityDialog));
        LanguageDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], LanguageDialog);
        Administration.LanguageDialog = LanguageDialog;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var LanguageGrid = (function (_super) {
            __extends(LanguageGrid, _super);
            function LanguageGrid(container) {
                return _super.call(this, container) || this;
            }
            LanguageGrid.prototype.getColumnsKey = function () { return "Administration.Language"; };
            LanguageGrid.prototype.getDialogType = function () { return Administration.LanguageDialog; };
            LanguageGrid.prototype.getIdProperty = function () { return Administration.LanguageRow.idProperty; };
            LanguageGrid.prototype.getLocalTextPrefix = function () { return Administration.LanguageRow.localTextPrefix; };
            LanguageGrid.prototype.getService = function () { return Administration.LanguageService.baseUrl; };
            LanguageGrid.prototype.getDefaultSortBy = function () {
                return [Administration.LanguageRow.Fields.LanguageName];
            };
            return LanguageGrid;
        }(Serenity.EntityGrid));
        LanguageGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], LanguageGrid);
        Administration.LanguageGrid = LanguageGrid;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RoleDialog = (function (_super) {
            __extends(RoleDialog, _super);
            function RoleDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Administration.RoleForm(_this.idPrefix);
                return _this;
            }
            RoleDialog.prototype.getFormKey = function () { return Administration.RoleForm.formKey; };
            RoleDialog.prototype.getIdProperty = function () { return Administration.RoleRow.idProperty; };
            RoleDialog.prototype.getLocalTextPrefix = function () { return Administration.RoleRow.localTextPrefix; };
            RoleDialog.prototype.getNameProperty = function () { return Administration.RoleRow.nameProperty; };
            RoleDialog.prototype.getService = function () { return Administration.RoleService.baseUrl; };
            RoleDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getToolbarButtons.call(this);
                buttons.push({
                    title: Q.text('Site.RolePermissionDialog.EditButton'),
                    cssClass: 'edit-permissions-button',
                    icon: 'icon-lock-open text-green',
                    onClick: function () {
                        new Administration.RolePermissionDialog({
                            roleID: _this.entity.RoleId,
                            title: _this.entity.RoleName
                        }).dialogOpen();
                    }
                });
                return buttons;
            };
            RoleDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.toolbar.findButton("edit-permissions-button").toggleClass("disabled", this.isNewOrDeleted());
            };
            return RoleDialog;
        }(Serenity.EntityDialog));
        RoleDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], RoleDialog);
        Administration.RoleDialog = RoleDialog;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RoleGrid = (function (_super) {
            __extends(RoleGrid, _super);
            function RoleGrid(container) {
                return _super.call(this, container) || this;
            }
            RoleGrid.prototype.getColumnsKey = function () { return "Administration.Role"; };
            RoleGrid.prototype.getDialogType = function () { return Administration.RoleDialog; };
            RoleGrid.prototype.getIdProperty = function () { return Administration.RoleRow.idProperty; };
            RoleGrid.prototype.getLocalTextPrefix = function () { return Administration.RoleRow.localTextPrefix; };
            RoleGrid.prototype.getService = function () { return Administration.RoleService.baseUrl; };
            RoleGrid.prototype.getDefaultSortBy = function () {
                return [Administration.RoleRow.Fields.RoleName];
            };
            return RoleGrid;
        }(Serenity.EntityGrid));
        RoleGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], RoleGrid);
        Administration.RoleGrid = RoleGrid;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RolePermissionDialog = (function (_super) {
            __extends(RolePermissionDialog, _super);
            function RolePermissionDialog(opt) {
                var _this = _super.call(this, opt) || this;
                _this.permissions = new Administration.PermissionCheckEditor(_this.byId('Permissions'), {
                    showRevoke: false
                });
                Administration.RolePermissionService.List({
                    RoleID: _this.options.roleID,
                    Module: null,
                    Submodule: null
                }, function (response) {
                    _this.permissions.set_value(response.Entities.map(function (x) { return ({ PermissionKey: x }); }));
                });
                return _this;
            }
            RolePermissionDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [
                    {
                        text: Q.text('Dialogs.OkButton'),
                        click: function (e) {
                            Administration.RolePermissionService.Update({
                                RoleID: _this.options.roleID,
                                Permissions: _this.permissions.get_value().map(function (x) { return x.PermissionKey; }),
                                Module: null,
                                Submodule: null
                            }, function (response) {
                                _this.dialogClose();
                                window.setTimeout(function () { return Q.notifySuccess(Q.text('Site.RolePermissionDialog.SaveSuccess')); }, 0);
                            });
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }
                ];
                opt.title = Q.format(Q.text('Site.RolePermissionDialog.DialogTitle'), this.options.title);
                return opt;
            };
            RolePermissionDialog.prototype.getTemplate = function () {
                return '<div id="~_Permissions"></div>';
            };
            return RolePermissionDialog;
        }(Serenity.TemplatedDialog));
        RolePermissionDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], RolePermissionDialog);
        Administration.RolePermissionDialog = RolePermissionDialog;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var TranslationGrid = (function (_super) {
            __extends(TranslationGrid, _super);
            function TranslationGrid(container) {
                var _this = _super.call(this, container) || this;
                _this.element.on('keyup.' + _this.uniqueName + ' change.' + _this.uniqueName, 'input.custom-text', function (e) {
                    var value = Q.trimToNull($(e.target).val());
                    if (value === '') {
                        value = null;
                    }
                    _this.view.getItemById($(e.target).data('key')).CustomText = value;
                    _this.hasChanges = true;
                });
                return _this;
            }
            TranslationGrid.prototype.getIdProperty = function () { return "Key"; };
            TranslationGrid.prototype.getLocalTextPrefix = function () { return "Administration.Translation"; };
            TranslationGrid.prototype.getService = function () { return Administration.TranslationService.baseUrl; };
            TranslationGrid.prototype.onClick = function (e, row, cell) {
                var _this = this;
                _super.prototype.onClick.call(this, e, row, cell);
                if (e.isDefaultPrevented()) {
                    return;
                }
                var item = this.itemAt(row);
                var done;
                if ($(e.target).hasClass('source-text')) {
                    e.preventDefault();
                    done = function () {
                        item.CustomText = item.SourceText;
                        _this.view.updateItem(item.Key, item);
                        _this.hasChanges = true;
                    };
                    if (Q.isTrimmedEmpty(item.CustomText) ||
                        (Q.trimToEmpty(item.CustomText) === Q.trimToEmpty(item.SourceText))) {
                        done();
                        return;
                    }
                    Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done);
                    return;
                }
                if ($(e.target).hasClass('target-text')) {
                    e.preventDefault();
                    done = function () {
                        item.CustomText = item.TargetText;
                        _this.view.updateItem(item.Key, item);
                        _this.hasChanges = true;
                    };
                    if (Q.isTrimmedEmpty(item.CustomText) ||
                        (Q.trimToEmpty(item.CustomText) === Q.trimToEmpty(item.TargetText))) {
                        done();
                        return;
                    }
                    Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done);
                    return;
                }
            };
            TranslationGrid.prototype.getColumns = function () {
                var columns = [];
                columns.push({ field: 'Key', width: 300, sortable: false });
                columns.push({
                    field: 'SourceText',
                    width: 300,
                    sortable: false,
                    format: function (ctx) {
                        return Q.outerHtml($('<a/>')
                            .addClass('source-text')
                            .text(ctx.value || ''));
                    }
                });
                columns.push({
                    field: 'CustomText',
                    width: 300,
                    sortable: false,
                    format: function (ctx) { return Q.outerHtml($('<input/>')
                        .addClass('custom-text')
                        .attr('value', ctx.value)
                        .attr('type', 'text')
                        .attr('data-key', ctx.item.Key)); }
                });
                columns.push({
                    field: 'TargetText',
                    width: 300,
                    sortable: false,
                    format: function (ctx) { return Q.outerHtml($('<a/>')
                        .addClass('target-text')
                        .text(ctx.value || '')); }
                });
                return columns;
            };
            TranslationGrid.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                var opt = {
                    lookupKey: 'Administration.Language'
                };
                this.sourceLanguage = Serenity.Widget.create({
                    type: Serenity.LookupEditor,
                    element: function (el) { return el.appendTo(_this.toolbar.element).attr('placeholder', '--- ' +
                        Q.text('Db.Administration.Translation.SourceLanguage') + ' ---'); },
                    options: opt
                });
                this.sourceLanguage.changeSelect2(function (e) {
                    if (_this.hasChanges) {
                        _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); });
                    }
                    else {
                        _this.refresh();
                    }
                });
                this.targetLanguage = Serenity.Widget.create({
                    type: Serenity.LookupEditor,
                    element: function (el) { return el.appendTo(_this.toolbar.element).attr('placeholder', '--- ' +
                        Q.text('Db.Administration.Translation.TargetLanguage') + ' ---'); },
                    options: opt
                });
                this.targetLanguage.changeSelect2(function (e) {
                    if (_this.hasChanges) {
                        _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); });
                    }
                    else {
                        _this.refresh();
                    }
                });
            };
            TranslationGrid.prototype.saveChanges = function (language) {
                var _this = this;
                var translations = {};
                for (var _i = 0, _a = this.getItems(); _i < _a.length; _i++) {
                    var item = _a[_i];
                    translations[item.Key] = item.CustomText;
                }
                return RSVP.resolve(Administration.TranslationService.Update({
                    TargetLanguageID: language,
                    Translations: translations
                })).then(function () {
                    _this.hasChanges = false;
                    language = Q.trimToNull(language) || 'invariant';
                    Q.notifySuccess('User translations in "' + language +
                        '" language are saved to "user.texts.' +
                        language + '.json" ' + 'file under "~/App_Data/texts/"', '');
                });
            };
            TranslationGrid.prototype.onViewSubmit = function () {
                var request = this.view.params;
                request.SourceLanguageID = this.sourceLanguage.value;
                this.targetLanguageKey = this.targetLanguage.value || '';
                request.TargetLanguageID = this.targetLanguageKey;
                this.hasChanges = false;
                return _super.prototype.onViewSubmit.call(this);
            };
            TranslationGrid.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: Q.text('Db.Administration.Translation.SaveChangesButton'),
                        onClick: function (e) { return _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); }); },
                        cssClass: 'apply-changes-button'
                    }];
            };
            TranslationGrid.prototype.createQuickSearchInput = function () {
                var _this = this;
                Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, searchText) {
                    _this.searchText = searchText;
                    _this.view.setItems(_this.view.getItems(), true);
                });
            };
            TranslationGrid.prototype.onViewFilter = function (item) {
                if (!_super.prototype.onViewFilter.call(this, item)) {
                    return false;
                }
                if (!this.searchText) {
                    return true;
                }
                var sd = Select2.util.stripDiacritics;
                var searching = sd(this.searchText).toLowerCase();
                function match(str) {
                    if (!str)
                        return false;
                    return str.toLowerCase().indexOf(searching) >= 0;
                }
                return Q.isEmptyOrNull(searching) || match(item.Key) || match(item.SourceText) ||
                    match(item.TargetText) || match(item.CustomText);
            };
            TranslationGrid.prototype.usePager = function () {
                return false;
            };
            return TranslationGrid;
        }(Serenity.EntityGrid));
        TranslationGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TranslationGrid);
        Administration.TranslationGrid = TranslationGrid;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Authorization;
    (function (Authorization) {
        Object.defineProperty(Authorization, 'userDefinition', {
            get: function () {
                return Q.getRemoteData('UserData');
            }
        });
        function hasPermission(permissionKey) {
            var ud = Authorization.userDefinition;
            return ud.Username === 'admin' || !!ud.Permissions[permissionKey];
        }
        Authorization.hasPermission = hasPermission;
    })(Authorization = Geshotel.Authorization || (Geshotel.Authorization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var EmpresasListFormatter = (function () {
            function EmpresasListFormatter() {
            }
            EmpresasListFormatter.prototype.format = function (ctx) {
                var idList = ctx.value;
                if (!idList || !idList.length)
                    return "";
                var byId = Geshotel.Portal.EmpresasRow.getLookup().itemById;
                return idList.map(function (x) {
                    var g = byId[x];
                    if (!g)
                        return x.toString();
                    return Q.htmlEncode(g.Empresa);
                }).join(", ");
            };
            return EmpresasListFormatter;
        }());
        EmpresasListFormatter = __decorate([
            Serenity.Decorators.registerFormatter()
        ], EmpresasListFormatter);
        Administration.EmpresasListFormatter = EmpresasListFormatter;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserDialog = (function (_super) {
            __extends(UserDialog, _super);
            function UserDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Administration.UserForm(_this.idPrefix);
                _this.form.Password.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.Password.value.length < 7)
                        return "Password must be at least 7 characters!";
                });
                _this.form.PasswordConfirm.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.Password.value != _this.form.PasswordConfirm.value)
                        return "The passwords entered doesn't match!";
                });
                return _this;
            }
            UserDialog.prototype.getFormKey = function () { return Administration.UserForm.formKey; };
            UserDialog.prototype.getIdProperty = function () { return Administration.UserRow.idProperty; };
            UserDialog.prototype.getIsActiveProperty = function () { return Administration.UserRow.isActiveProperty; };
            UserDialog.prototype.getLocalTextPrefix = function () { return Administration.UserRow.localTextPrefix; };
            UserDialog.prototype.getNameProperty = function () { return Administration.UserRow.nameProperty; };
            UserDialog.prototype.getService = function () { return Administration.UserService.baseUrl; };
            UserDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getToolbarButtons.call(this);
                buttons.push({
                    title: Q.text('Site.UserDialog.EditRolesButton'),
                    cssClass: 'edit-roles-button',
                    icon: 'icon-people text-blue',
                    onClick: function () {
                        new Administration.UserRoleDialog({
                            userID: _this.entity.UserId,
                            username: _this.entity.Username
                        }).dialogOpen();
                    }
                });
                buttons.push({
                    title: Q.text('Site.UserDialog.EditPermissionsButton'),
                    cssClass: 'edit-permissions-button',
                    icon: 'icon-lock-open text-green',
                    onClick: function () {
                        new Administration.UserPermissionDialog({
                            userID: _this.entity.UserId,
                            username: _this.entity.Username
                        }).dialogOpen();
                    }
                });
                return buttons;
            };
            UserDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.toolbar.findButton('edit-roles-button').toggleClass('disabled', this.isNewOrDeleted());
                this.toolbar.findButton("edit-permissions-button").toggleClass("disabled", this.isNewOrDeleted());
            };
            UserDialog.prototype.afterLoadEntity = function () {
                _super.prototype.afterLoadEntity.call(this);
                // these fields are only required in new record mode
                this.form.Password.element.toggleClass('required', this.isNew())
                    .closest('.field').find('sup').toggle(this.isNew());
                this.form.PasswordConfirm.element.toggleClass('required', this.isNew())
                    .closest('.field').find('sup').toggle(this.isNew());
            };
            return UserDialog;
        }(Serenity.EntityDialog));
        UserDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], UserDialog);
        Administration.UserDialog = UserDialog;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserGrid = (function (_super) {
            __extends(UserGrid, _super);
            function UserGrid(container) {
                return _super.call(this, container) || this;
            }
            UserGrid.prototype.getColumnsKey = function () { return "Administration.User"; };
            UserGrid.prototype.getDialogType = function () { return Administration.UserDialog; };
            UserGrid.prototype.getIdProperty = function () { return Administration.UserRow.idProperty; };
            UserGrid.prototype.getIsActiveProperty = function () { return Administration.UserRow.isActiveProperty; };
            UserGrid.prototype.getLocalTextPrefix = function () { return Administration.UserRow.localTextPrefix; };
            UserGrid.prototype.getService = function () { return Administration.UserService.baseUrl; };
            UserGrid.prototype.getDefaultSortBy = function () {
                return [Administration.UserRow.Fields.Username];
            };
            return UserGrid;
        }(Serenity.EntityGrid));
        UserGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], UserGrid);
        Administration.UserGrid = UserGrid;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var PermissionCheckEditor = (function (_super) {
            __extends(PermissionCheckEditor, _super);
            function PermissionCheckEditor(container, opt) {
                var _this = _super.call(this, container, opt) || this;
                _this.rolePermissions = {};
                var titleByKey = {};
                var permissionKeys = _this.getSortedGroupAndPermissionKeys(titleByKey);
                var items = permissionKeys.map(function (key) { return ({
                    Key: key,
                    ParentKey: _this.getParentKey(key),
                    Title: titleByKey[key],
                    GrantRevoke: null,
                    IsGroup: key.charAt(key.length - 1) === ':'
                }); });
                _this.byParentKey = Q.toGrouping(items, function (x) { return x.ParentKey; });
                _this.setItems(items);
                return _this;
            }
            PermissionCheckEditor.prototype.getIdProperty = function () { return "Key"; };
            PermissionCheckEditor.prototype.getItemGrantRevokeClass = function (item, grant) {
                if (!item.IsGroup) {
                    return ((item.GrantRevoke === grant) ? ' checked' : '');
                }
                var desc = this.getDescendants(item, true);
                var granted = desc.filter(function (x) { return x.GrantRevoke === grant; });
                if (!granted.length) {
                    return '';
                }
                if (desc.length === granted.length) {
                    return 'checked';
                }
                return 'checked partial';
            };
            PermissionCheckEditor.prototype.getItemEffectiveClass = function (item) {
                var _this = this;
                if (item.IsGroup) {
                    var desc = this.getDescendants(item, true);
                    var grantCount = Q.count(desc, function (x) { return x.GrantRevoke === true ||
                        (x.GrantRevoke == null && _this.rolePermissions[x.Key]); });
                    if (grantCount === desc.length || desc.length === 0) {
                        return 'allow';
                    }
                    if (grantCount === 0) {
                        return 'deny';
                    }
                    return 'partial';
                }
                var granted = item.GrantRevoke === true ||
                    (item.GrantRevoke == null && this.rolePermissions[item.Key]);
                return (granted ? ' allow' : ' deny');
            };
            PermissionCheckEditor.prototype.getColumns = function () {
                var _this = this;
                var columns = [{
                        name: Q.text('Site.UserPermissionDialog.Permission'),
                        field: 'Title',
                        format: Serenity.SlickFormatting.treeToggle(function () { return _this.view; }, function (x) { return x.Key; }, function (ctx) {
                            var item = ctx.item;
                            var klass = _this.getItemEffectiveClass(item);
                            return '<span class="effective-permission ' + klass + '">' + Q.htmlEncode(ctx.value) + '</span>';
                        }),
                        width: 495,
                        sortable: false
                    }, {
                        name: Q.text('Site.UserPermissionDialog.Grant'), field: 'Grant',
                        format: function (ctx) {
                            var item1 = ctx.item;
                            var klass1 = _this.getItemGrantRevokeClass(item1, true);
                            return "<span class='check-box grant no-float " + klass1 + "'></span>";
                        },
                        width: 65,
                        sortable: false,
                        headerCssClass: 'align-center',
                        cssClass: 'align-center'
                    }];
                if (this.options.showRevoke) {
                    columns.push({
                        name: Q.text('Site.UserPermissionDialog.Revoke'), field: 'Revoke',
                        format: function (ctx) {
                            var item2 = ctx.item;
                            var klass2 = _this.getItemGrantRevokeClass(item2, false);
                            return '<span class="check-box revoke no-float ' + klass2 + '"></span>';
                        },
                        width: 65,
                        sortable: false,
                        headerCssClass: 'align-center',
                        cssClass: 'align-center'
                    });
                }
                return columns;
            };
            PermissionCheckEditor.prototype.setItems = function (items) {
                Serenity.SlickTreeHelper.setIndents(items, function (x) { return x.Key; }, function (x) { return x.ParentKey; }, false);
                this.view.setItems(items, true);
            };
            PermissionCheckEditor.prototype.onViewSubmit = function () {
                return false;
            };
            PermissionCheckEditor.prototype.onViewFilter = function (item) {
                var _this = this;
                if (!_super.prototype.onViewFilter.call(this, item)) {
                    return false;
                }
                if (!Serenity.SlickTreeHelper.filterById(item, this.view, function (x) { return x.ParentKey; }))
                    return false;
                if (this.searchText) {
                    return this.matchContains(item) || item.IsGroup && Q.any(this.getDescendants(item, false), function (x) { return _this.matchContains(x); });
                }
                return true;
            };
            PermissionCheckEditor.prototype.matchContains = function (item) {
                return Select2.util.stripDiacritics(item.Title || '').toLowerCase().indexOf(this.searchText) >= 0;
            };
            PermissionCheckEditor.prototype.getDescendants = function (item, excludeGroups) {
                var result = [];
                var stack = [item];
                while (stack.length > 0) {
                    var i = stack.pop();
                    var children = this.byParentKey[i.Key];
                    if (!children)
                        continue;
                    for (var _i = 0, children_1 = children; _i < children_1.length; _i++) {
                        var child = children_1[_i];
                        if (!excludeGroups || !child.IsGroup) {
                            result.push(child);
                        }
                        stack.push(child);
                    }
                }
                return result;
            };
            PermissionCheckEditor.prototype.onClick = function (e, row, cell) {
                _super.prototype.onClick.call(this, e, row, cell);
                if (!e.isDefaultPrevented()) {
                    Serenity.SlickTreeHelper.toggleClick(e, row, cell, this.view, function (x) { return x.Key; });
                }
                if (e.isDefaultPrevented()) {
                    return;
                }
                var target = $(e.target);
                var grant = target.hasClass('grant');
                if (grant || target.hasClass('revoke')) {
                    e.preventDefault();
                    var item = this.itemAt(row);
                    var checkedOrPartial = target.hasClass('checked') || target.hasClass('partial');
                    if (checkedOrPartial) {
                        grant = null;
                    }
                    else {
                        grant = grant !== checkedOrPartial;
                    }
                    if (item.IsGroup) {
                        for (var _i = 0, _a = this.getDescendants(item, true); _i < _a.length; _i++) {
                            var d = _a[_i];
                            d.GrantRevoke = grant;
                        }
                    }
                    else
                        item.GrantRevoke = grant;
                    this.slickGrid.invalidate();
                }
            };
            PermissionCheckEditor.prototype.getParentKey = function (key) {
                if (key.charAt(key.length - 1) === ':') {
                    key = key.substr(0, key.length - 1);
                }
                var idx = key.lastIndexOf(':');
                if (idx >= 0) {
                    return key.substr(0, idx + 1);
                }
                return null;
            };
            PermissionCheckEditor.prototype.getButtons = function () {
                return [];
            };
            PermissionCheckEditor.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, text) {
                    _this.searchText = Select2.util.stripDiacritics(Q.trimToNull(text) || '').toLowerCase();
                    _this.view.setItems(_this.view.getItems(), true);
                });
            };
            PermissionCheckEditor.prototype.getSortedGroupAndPermissionKeys = function (titleByKey) {
                var keys = Q.getRemoteData('Administration.PermissionKeys').Entities;
                var titleWithGroup = {};
                for (var _i = 0, keys_1 = keys; _i < keys_1.length; _i++) {
                    var k = keys_1[_i];
                    var s = k;
                    if (!s) {
                        continue;
                    }
                    if (s.charAt(s.length - 1) == ':') {
                        s = s.substr(0, s.length - 1);
                        if (s.length === 0) {
                            continue;
                        }
                    }
                    if (titleByKey[s]) {
                        continue;
                    }
                    titleByKey[s] = Q.coalesce(Q.tryGetText('Permission.' + s), s);
                    var parts = s.split(':');
                    var group = '';
                    var groupTitle = '';
                    for (var i = 0; i < parts.length - 1; i++) {
                        group = group + parts[i] + ':';
                        var txt = Q.tryGetText('Permission.' + group);
                        if (txt == null) {
                            txt = parts[i];
                        }
                        titleByKey[group] = txt;
                        groupTitle = groupTitle + titleByKey[group] + ':';
                        titleWithGroup[group] = groupTitle;
                    }
                    titleWithGroup[s] = groupTitle + titleByKey[s];
                }
                keys = Object.keys(titleByKey);
                keys = keys.sort(function (x, y) { return Q.turkishLocaleCompare(titleWithGroup[x], titleWithGroup[y]); });
                return keys;
            };
            PermissionCheckEditor.prototype.get_value = function () {
                var result = [];
                for (var _i = 0, _a = this.view.getItems(); _i < _a.length; _i++) {
                    var item = _a[_i];
                    if (item.GrantRevoke != null && item.Key.charAt(item.Key.length - 1) != ':') {
                        result.push({ PermissionKey: item.Key, Granted: item.GrantRevoke });
                    }
                }
                return result;
            };
            PermissionCheckEditor.prototype.set_value = function (value) {
                for (var _i = 0, _a = this.view.getItems(); _i < _a.length; _i++) {
                    var item = _a[_i];
                    item.GrantRevoke = null;
                }
                if (value != null) {
                    for (var _b = 0, value_1 = value; _b < value_1.length; _b++) {
                        var row = value_1[_b];
                        var r = this.view.getItemById(row.PermissionKey);
                        if (r) {
                            r.GrantRevoke = Q.coalesce(row.Granted, true);
                        }
                    }
                }
                this.setItems(this.getItems());
            };
            PermissionCheckEditor.prototype.get_rolePermissions = function () {
                return Object.keys(this.rolePermissions);
            };
            PermissionCheckEditor.prototype.set_rolePermissions = function (value) {
                this.rolePermissions = {};
                if (value) {
                    for (var _i = 0, value_2 = value; _i < value_2.length; _i++) {
                        var k = value_2[_i];
                        this.rolePermissions[k] = true;
                    }
                }
                this.setItems(this.getItems());
            };
            return PermissionCheckEditor;
        }(Serenity.DataGrid));
        PermissionCheckEditor = __decorate([
            Serenity.Decorators.registerEditor([Serenity.IGetEditValue, Serenity.ISetEditValue])
        ], PermissionCheckEditor);
        Administration.PermissionCheckEditor = PermissionCheckEditor;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserPermissionDialog = (function (_super) {
            __extends(UserPermissionDialog, _super);
            function UserPermissionDialog(opt) {
                var _this = _super.call(this, opt) || this;
                _this.permissions = new Administration.PermissionCheckEditor(_this.byId('Permissions'), {
                    showRevoke: true
                });
                Administration.UserPermissionService.List({
                    UserID: _this.options.userID,
                    Module: null,
                    Submodule: null
                }, function (response) {
                    _this.permissions.set_value(response.Entities);
                });
                Administration.UserPermissionService.ListRolePermissions({
                    UserID: _this.options.userID,
                    Module: null,
                    Submodule: null,
                }, function (response) {
                    _this.permissions.set_rolePermissions(response.Entities);
                });
                return _this;
            }
            UserPermissionDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [
                    {
                        text: Q.text('Dialogs.OkButton'),
                        click: function (e) {
                            Administration.UserPermissionService.Update({
                                UserID: _this.options.userID,
                                Permissions: _this.permissions.get_value(),
                                Module: null,
                                Submodule: null
                            }, function (response) {
                                _this.dialogClose();
                                window.setTimeout(function () { return Q.notifySuccess(Q.text('Site.UserPermissionDialog.SaveSuccess')); }, 0);
                            });
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }
                ];
                opt.title = Q.format(Q.text('Site.UserPermissionDialog.DialogTitle'), this.options.username);
                return opt;
            };
            UserPermissionDialog.prototype.getTemplate = function () {
                return '<div id="~_Permissions"></div>';
            };
            return UserPermissionDialog;
        }(Serenity.TemplatedDialog));
        UserPermissionDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], UserPermissionDialog);
        Administration.UserPermissionDialog = UserPermissionDialog;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RoleCheckEditor = (function (_super) {
            __extends(RoleCheckEditor, _super);
            function RoleCheckEditor(div) {
                return _super.call(this, div) || this;
            }
            RoleCheckEditor.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, text) {
                    _this.searchText = Select2.util.stripDiacritics(text || '').toUpperCase();
                    _this.view.setItems(_this.view.getItems(), true);
                });
            };
            RoleCheckEditor.prototype.getButtons = function () {
                return [];
            };
            RoleCheckEditor.prototype.getTreeItems = function () {
                return Administration.RoleRow.getLookup().items.map(function (role) { return ({
                    id: role.RoleId.toString(),
                    text: role.RoleName
                }); });
            };
            RoleCheckEditor.prototype.onViewFilter = function (item) {
                return _super.prototype.onViewFilter.call(this, item) &&
                    (Q.isEmptyOrNull(this.searchText) ||
                        Select2.util.stripDiacritics(item.text || '')
                            .toUpperCase().indexOf(this.searchText) >= 0);
            };
            return RoleCheckEditor;
        }(Serenity.CheckTreeEditor));
        RoleCheckEditor = __decorate([
            Serenity.Decorators.registerEditor()
        ], RoleCheckEditor);
        Administration.RoleCheckEditor = RoleCheckEditor;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserRoleDialog = (function (_super) {
            __extends(UserRoleDialog, _super);
            function UserRoleDialog(opt) {
                var _this = _super.call(this, opt) || this;
                _this.permissions = new Administration.RoleCheckEditor(_this.byId('Roles'));
                Administration.UserRoleService.List({
                    UserID: _this.options.userID
                }, function (response) {
                    _this.permissions.value = response.Entities.map(function (x) { return x.toString(); });
                });
                return _this;
            }
            UserRoleDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [{
                        text: Q.text('Dialogs.OkButton'),
                        click: function () {
                            Q.serviceRequest('Administration/UserRole/Update', {
                                UserID: _this.options.userID,
                                Roles: _this.permissions.value.map(function (x) { return parseInt(x, 10); })
                            }, function (response) {
                                _this.dialogClose();
                                Q.notifySuccess(Q.text('Site.UserRoleDialog.SaveSuccess'));
                            });
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }];
                opt.title = Q.format(Q.text('Site.UserRoleDialog.DialogTitle'), this.options.username);
                return opt;
            };
            UserRoleDialog.prototype.getTemplate = function () {
                return "<div id='~_Roles'></div>";
            };
            return UserRoleDialog;
        }(Serenity.TemplatedDialog));
        UserRoleDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], UserRoleDialog);
        Administration.UserRoleDialog = UserRoleDialog;
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var BasicProgressDialog = (function (_super) {
        __extends(BasicProgressDialog, _super);
        function BasicProgressDialog() {
            var _this = _super.call(this) || this;
            _this.byId('ProgressBar').progressbar({
                max: 100,
                value: 0,
                change: function (e, v) {
                    _this.byId('ProgressLabel').text(_this.value + ' / ' + _this.max);
                }
            });
            return _this;
        }
        Object.defineProperty(BasicProgressDialog.prototype, "max", {
            get: function () {
                return this.byId('ProgressBar').progressbar().progressbar('option', 'max');
            },
            set: function (value) {
                this.byId('ProgressBar').progressbar().progressbar('option', 'max', value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(BasicProgressDialog.prototype, "value", {
            get: function () {
                return this.byId('ProgressBar').progressbar('value');
            },
            set: function (value) {
                this.byId('ProgressBar').progressbar().progressbar('value', value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(BasicProgressDialog.prototype, "title", {
            get: function () {
                return this.element.dialog().dialog('option', 'title');
            },
            set: function (value) {
                this.element.dialog().dialog('option', 'title', value);
            },
            enumerable: true,
            configurable: true
        });
        BasicProgressDialog.prototype.getDialogOptions = function () {
            var _this = this;
            var opt = _super.prototype.getDialogOptions.call(this);
            opt.title = Q.text('Site.BasicProgressDialog.PleaseWait');
            opt.width = 600;
            opt.buttons = [{
                    text: Q.text('Dialogs.CancelButton'),
                    click: function () {
                        _this.cancelled = true;
                        _this.element.closest('.ui-dialog')
                            .find('.ui-dialog-buttonpane .ui-button')
                            .attr('disabled', 'disabled')
                            .css('opacity', '0.5');
                        _this.element.dialog('option', 'title', Q.trimToNull(_this.cancelTitle) ||
                            Q.text('Site.BasicProgressDialog.CancelTitle'));
                    }
                }];
            return opt;
        };
        BasicProgressDialog.prototype.initDialog = function () {
            _super.prototype.initDialog.call(this);
            this.element.closest('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
        };
        BasicProgressDialog.prototype.getTemplate = function () {
            return ("<div class='s-DialogContent s-BasicProgressDialogContent'>" +
                "<div id='~_StatusText' class='status-text' ></div>" +
                "<div id='~_ProgressBar' class='progress-bar'>" +
                "<div id='~_ProgressLabel' class='progress-label' ></div>" +
                "</div>" +
                "</div>");
        };
        return BasicProgressDialog;
    }(Serenity.TemplatedDialog));
    Geshotel.BasicProgressDialog = BasicProgressDialog;
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var BulkServiceAction = (function () {
            function BulkServiceAction() {
            }
            BulkServiceAction.prototype.createProgressDialog = function () {
                this.progressDialog = new Geshotel.BasicProgressDialog();
                this.progressDialog.dialogOpen();
                this.progressDialog.max = this.keys.length;
                this.progressDialog.value = 0;
            };
            BulkServiceAction.prototype.getConfirmationFormat = function () {
                return Q.text('Site.BulkServiceAction.ConfirmationFormat');
            };
            BulkServiceAction.prototype.getConfirmationMessage = function (targetCount) {
                return Q.format(this.getConfirmationFormat(), targetCount);
            };
            BulkServiceAction.prototype.confirm = function (targetCount, action) {
                Q.confirm(this.getConfirmationMessage(targetCount), action);
            };
            BulkServiceAction.prototype.getNothingToProcessMessage = function () {
                return Q.text('Site.BulkServiceAction.NothingToProcess');
            };
            BulkServiceAction.prototype.nothingToProcess = function () {
                Q.notifyError(this.getNothingToProcessMessage());
            };
            BulkServiceAction.prototype.getParallelRequests = function () {
                return 1;
            };
            BulkServiceAction.prototype.getBatchSize = function () {
                return 1;
            };
            BulkServiceAction.prototype.startParallelExecution = function () {
                this.createProgressDialog();
                this.successCount = 0;
                this.errorCount = 0;
                this.pendingRequests = 0;
                this.completedRequests = 0;
                this.errorCount = 0;
                this.errorByKey = {};
                this.queue = this.keys.slice();
                this.queueIndex = 0;
                var parallelRequests = this.getParallelRequests();
                while (parallelRequests-- > 0) {
                    this.executeNextBatch();
                }
            };
            BulkServiceAction.prototype.serviceCallCleanup = function () {
                this.pendingRequests--;
                this.completedRequests++;
                var title = Q.text((this.progressDialog.cancelled ?
                    'Site.BasicProgressDialog.CancelTitle' : 'Site.BasicProgressDialog.PleaseWait'));
                title += ' (';
                if (this.successCount > 0) {
                    title += Q.format(Q.text('Site.BulkServiceAction.SuccessCount'), this.successCount);
                }
                if (this.errorCount > 0) {
                    if (this.successCount > 0) {
                        title += ', ';
                    }
                    title += Q.format(Q.text('Site.BulkServiceAction.ErrorCount'), this.errorCount);
                }
                this.progressDialog.title = title + ')';
                this.progressDialog.value = this.successCount + this.errorCount;
                if (!this.progressDialog.cancelled && this.progressDialog.value < this.keys.length) {
                    this.executeNextBatch();
                }
                else if (this.pendingRequests === 0) {
                    this.progressDialog.dialogClose();
                    this.showResults();
                    if (this.done) {
                        this.done();
                        this.done = null;
                    }
                }
            };
            BulkServiceAction.prototype.executeForBatch = function (batch) {
            };
            BulkServiceAction.prototype.executeNextBatch = function () {
                var batchSize = this.getBatchSize();
                var batch = [];
                while (true) {
                    if (batch.length >= batchSize) {
                        break;
                    }
                    if (this.queueIndex >= this.queue.length) {
                        break;
                    }
                    batch.push(this.queue[this.queueIndex++]);
                }
                if (batch.length > 0) {
                    this.pendingRequests++;
                    this.executeForBatch(batch);
                }
            };
            BulkServiceAction.prototype.getAllHadErrorsFormat = function () {
                return Q.text('Site.BulkServiceAction.AllHadErrorsFormat');
            };
            BulkServiceAction.prototype.showAllHadErrors = function () {
                Q.notifyError(Q.format(this.getAllHadErrorsFormat(), this.errorCount));
            };
            BulkServiceAction.prototype.getSomeHadErrorsFormat = function () {
                return Q.text('Site.BulkServiceAction.SomeHadErrorsFormat');
            };
            BulkServiceAction.prototype.showSomeHadErrors = function () {
                Q.notifyWarning(Q.format(this.getSomeHadErrorsFormat(), this.successCount, this.errorCount));
            };
            BulkServiceAction.prototype.getAllSuccessFormat = function () {
                return Q.text('Site.BulkServiceAction.AllSuccessFormat');
            };
            BulkServiceAction.prototype.showAllSuccess = function () {
                Q.notifySuccess(Q.format(this.getAllSuccessFormat(), this.successCount));
            };
            BulkServiceAction.prototype.showResults = function () {
                if (this.errorCount === 0 && this.successCount === 0) {
                    this.nothingToProcess();
                    return;
                }
                if (this.errorCount > 0 && this.successCount === 0) {
                    this.showAllHadErrors();
                    return;
                }
                if (this.errorCount > 0) {
                    this.showSomeHadErrors();
                    return;
                }
                this.showAllSuccess();
            };
            BulkServiceAction.prototype.execute = function (keys) {
                var _this = this;
                this.keys = keys;
                if (this.keys.length === 0) {
                    this.nothingToProcess();
                    return;
                }
                this.confirm(this.keys.length, function () { return _this.startParallelExecution(); });
            };
            BulkServiceAction.prototype.get_successCount = function () {
                return this.successCount;
            };
            BulkServiceAction.prototype.set_successCount = function (value) {
                this.successCount = value;
            };
            BulkServiceAction.prototype.get_errorCount = function () {
                return this.errorCount;
            };
            BulkServiceAction.prototype.set_errorCount = function (value) {
                this.errorCount = value;
            };
            return BulkServiceAction;
        }());
        Common.BulkServiceAction = BulkServiceAction;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var DialogUtils;
    (function (DialogUtils) {
        function pendingChangesConfirmation(element, hasPendingChanges) {
            element.bind('dialogbeforeclose', function (e) {
                if (!Serenity.WX.hasOriginalEvent(e) || !hasPendingChanges()) {
                    return;
                }
                e.preventDefault();
                Q.confirm('You have pending changes. Save them?', function () { return element.find('div.save-and-close-button').click(); }, {
                    onNo: function () {
                        element.dialog().dialog('close');
                    }
                });
            });
        }
        DialogUtils.pendingChangesConfirmation = pendingChangesConfirmation;
    })(DialogUtils = Geshotel.DialogUtils || (Geshotel.DialogUtils = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var EnumSelectFormatter = (function () {
            function EnumSelectFormatter() {
                this.allowClear = true;
            }
            EnumSelectFormatter.prototype.format = function (ctx) {
                var enumType = Serenity.EnumTypeRegistry.get(this.enumKey);
                var sb = "<select>";
                if (this.allowClear) {
                    sb += '<option value="">';
                    sb += Q.htmlEncode(this.emptyItemText || Q.text("Controls.SelectEditor.EmptyItemText"));
                    sb += '</option>';
                }
                for (var _i = 0, _a = Object.keys(enumType).filter(function (v) { return !isNaN(parseInt(v, 10)); }); _i < _a.length; _i++) {
                    var x = _a[_i];
                    sb += '<option value="' + x + '"';
                    if (x == ctx.value)
                        sb += " selected";
                    var name = enumType[x];
                    sb += ">";
                    sb += Q.htmlEncode(Q.tryGetText("Enums." + this.enumKey + "." + name) || name);
                    sb += "</option>";
                }
                sb += "</select>";
                return sb;
            };
            return EnumSelectFormatter;
        }());
        __decorate([
            Serenity.Decorators.option()
        ], EnumSelectFormatter.prototype, "enumKey", void 0);
        __decorate([
            Serenity.Decorators.option()
        ], EnumSelectFormatter.prototype, "allowClear", void 0);
        __decorate([
            Serenity.Decorators.option()
        ], EnumSelectFormatter.prototype, "emptyItemText", void 0);
        EnumSelectFormatter = __decorate([
            Serenity.Decorators.registerFormatter()
        ], EnumSelectFormatter);
        Common.EnumSelectFormatter = EnumSelectFormatter;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var ExcelExportHelper;
        (function (ExcelExportHelper) {
            function createToolButton(options) {
                return {
                    hint: Q.coalesce(options.title, 'Excel'),
                    title: Q.coalesce(options.hint, ''),
                    cssClass: 'export-xlsx-button',
                    onClick: function () {
                        if (!options.onViewSubmit()) {
                            return;
                        }
                        var grid = options.grid;
                        var request = Q.deepClone(grid.getView().params);
                        request.Take = 0;
                        request.Skip = 0;
                        var sortBy = grid.getView().sortBy;
                        if (sortBy) {
                            request.Sort = sortBy;
                        }
                        request.IncludeColumns = [];
                        var columns = grid.getGrid().getColumns();
                        for (var _i = 0, columns_1 = columns; _i < columns_1.length; _i++) {
                            var column = columns_1[_i];
                            request.IncludeColumns.push(column.id || column.field);
                        }
                        Q.postToService({ service: options.service, request: request, target: '_blank' });
                    },
                    separator: options.separator
                };
            }
            ExcelExportHelper.createToolButton = createToolButton;
        })(ExcelExportHelper = Common.ExcelExportHelper || (Common.ExcelExportHelper = {}));
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var GridEditorBase = (function (_super) {
            __extends(GridEditorBase, _super);
            function GridEditorBase(container) {
                var _this = _super.call(this, container) || this;
                _this.nextId = 1;
                return _this;
            }
            GridEditorBase.prototype.getIdProperty = function () { return "__id"; };
            GridEditorBase.prototype.id = function (entity) {
                return entity[this.getIdProperty()];
            };
            GridEditorBase.prototype.getNextId = function () {
                return "`" + this.nextId++;
            };
            GridEditorBase.prototype.setNewId = function (entity) {
                entity[this.getIdProperty()] = this.getNextId();
            };
            GridEditorBase.prototype.save = function (opt, callback) {
                var _this = this;
                var request = opt.request;
                var row = Q.deepClone(request.Entity);
                var id = this.id(row);
                if (id == null) {
                    row[this.getIdProperty()] = this.getNextId();
                }
                if (!this.validateEntity(row, id)) {
                    return;
                }
                var items = this.view.getItems().slice();
                if (id == null) {
                    items.push(row);
                }
                else {
                    var index = Q.indexOf(items, function (x) { return _this.id(x) === id; });
                    items[index] = Q.deepClone({}, items[index], row);
                }
                this.setEntities(items);
                callback({});
            };
            GridEditorBase.prototype.deleteEntity = function (id) {
                this.view.deleteItem(id);
                return true;
            };
            GridEditorBase.prototype.validateEntity = function (row, id) {
                return true;
            };
            GridEditorBase.prototype.setEntities = function (items) {
                this.view.setItems(items, true);
            };
            GridEditorBase.prototype.getNewEntity = function () {
                return {};
            };
            GridEditorBase.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: this.getAddButtonCaption(),
                        cssClass: 'add-button',
                        onClick: function () {
                            _this.createEntityDialog(_this.getItemType(), function (dlg) {
                                var dialog = dlg;
                                dialog.onSave = function (opt, callback) { return _this.save(opt, callback); };
                                dialog.loadEntityAndOpenDialog(_this.getNewEntity());
                            });
                        }
                    }];
            };
            GridEditorBase.prototype.editItem = function (entityOrId) {
                var _this = this;
                var id = entityOrId;
                var item = this.view.getItemById(id);
                this.createEntityDialog(this.getItemType(), function (dlg) {
                    var dialog = dlg;
                    dialog.onDelete = function (opt, callback) {
                        if (!_this.deleteEntity(id)) {
                            return;
                        }
                        callback({});
                    };
                    dialog.onSave = function (opt, callback) { return _this.save(opt, callback); };
                    dialog.loadEntityAndOpenDialog(item);
                });
                ;
            };
            GridEditorBase.prototype.getEditValue = function (property, target) {
                target[property.name] = this.value;
            };
            GridEditorBase.prototype.setEditValue = function (source, property) {
                this.value = source[property.name];
            };
            Object.defineProperty(GridEditorBase.prototype, "value", {
                get: function () {
                    var p = this.getIdProperty();
                    return this.view.getItems().map(function (x) {
                        var y = Q.deepClone(x);
                        var id = y[p];
                        if (id && id.toString().charAt(0) == '`')
                            delete y[p];
                        return y;
                    });
                },
                set: function (value) {
                    var _this = this;
                    var p = this.getIdProperty();
                    this.view.setItems((value || []).map(function (x) {
                        var y = Q.deepClone(x);
                        if (y[p] == null)
                            y[p] = "`" + _this.getNextId();
                        return y;
                    }), true);
                },
                enumerable: true,
                configurable: true
            });
            GridEditorBase.prototype.getGridCanLoad = function () {
                return false;
            };
            GridEditorBase.prototype.usePager = function () {
                return false;
            };
            GridEditorBase.prototype.getInitialTitle = function () {
                return null;
            };
            GridEditorBase.prototype.createQuickSearchInput = function () {
            };
            return GridEditorBase;
        }(Serenity.EntityGrid));
        GridEditorBase = __decorate([
            Serenity.Decorators.registerClass([Serenity.IGetEditValue, Serenity.ISetEditValue]),
            Serenity.Decorators.editor(),
            Serenity.Decorators.element("<div/>")
        ], GridEditorBase);
        Common.GridEditorBase = GridEditorBase;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var GridEditorDialog = (function (_super) {
            __extends(GridEditorDialog, _super);
            function GridEditorDialog() {
                return _super.apply(this, arguments) || this;
            }
            GridEditorDialog.prototype.getIdProperty = function () { return "__id"; };
            GridEditorDialog.prototype.destroy = function () {
                this.onSave = null;
                this.onDelete = null;
                _super.prototype.destroy.call(this);
            };
            GridEditorDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                // apply changes button doesn't work properly with in-memory grids yet
                if (this.applyChangesButton) {
                    this.applyChangesButton.hide();
                }
            };
            GridEditorDialog.prototype.saveHandler = function (options, callback) {
                this.onSave && this.onSave(options, callback);
            };
            GridEditorDialog.prototype.deleteHandler = function (options, callback) {
                this.onDelete && this.onDelete(options, callback);
            };
            return GridEditorDialog;
        }(Serenity.EntityDialog));
        GridEditorDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], GridEditorDialog);
        Common.GridEditorDialog = GridEditorDialog;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var LanguageList;
    (function (LanguageList) {
        function getValue() {
            var result = [];
            for (var _i = 0, _a = Geshotel.Administration.LanguageRow.getLookup().items; _i < _a.length; _i++) {
                var k = _a[_i];
                if (k.LanguageId !== 'en') {
                    result.push([k.Id.toString(), k.LanguageName]);
                }
            }
            return result;
        }
        LanguageList.getValue = getValue;
    })(LanguageList = Geshotel.LanguageList || (Geshotel.LanguageList = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var LanguageForm = (function (_super) {
            __extends(LanguageForm, _super);
            function LanguageForm() {
                return _super.apply(this, arguments) || this;
            }
            return LanguageForm;
        }(Serenity.PrefixedContext));
        LanguageForm.formKey = 'Administration.Language';
        Administration.LanguageForm = LanguageForm;
        [['LanguageId', function () { return Serenity.StringEditor; }], ['LanguageName', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(LanguageForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var LanguageRow;
        (function (LanguageRow) {
            LanguageRow.idProperty = 'Id';
            LanguageRow.nameProperty = 'LanguageName';
            LanguageRow.localTextPrefix = 'Administration.Language';
            LanguageRow.lookupKey = 'Administration.Languaje';
            function getLookup() {
                return Q.getLookup('Administration.Languaje');
            }
            LanguageRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = LanguageRow.Fields || (LanguageRow.Fields = {}));
            ['Id', 'LanguageId', 'LanguageName'].forEach(function (x) { return Fields[x] = x; });
        })(LanguageRow = Administration.LanguageRow || (Administration.LanguageRow = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var LanguageService;
        (function (LanguageService) {
            LanguageService.baseUrl = 'Administration/Language';
            var Methods;
            (function (Methods) {
            })(Methods = LanguageService.Methods || (LanguageService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                LanguageService[x] = function (r, s, o) { return Q.serviceRequest(LanguageService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = LanguageService.baseUrl + '/' + x;
            });
        })(LanguageService = Administration.LanguageService || (Administration.LanguageService = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RoleForm = (function (_super) {
            __extends(RoleForm, _super);
            function RoleForm() {
                return _super.apply(this, arguments) || this;
            }
            return RoleForm;
        }(Serenity.PrefixedContext));
        RoleForm.formKey = 'Administration.Role';
        Administration.RoleForm = RoleForm;
        [['RoleName', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(RoleForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RolePermissionRow;
        (function (RolePermissionRow) {
            RolePermissionRow.idProperty = 'RolePermissionId';
            RolePermissionRow.nameProperty = 'PermissionKey';
            RolePermissionRow.localTextPrefix = 'Administration.RolePermission';
            var Fields;
            (function (Fields) {
            })(Fields = RolePermissionRow.Fields || (RolePermissionRow.Fields = {}));
            ['RolePermissionId', 'RoleId', 'PermissionKey', 'RoleRoleName'].forEach(function (x) { return Fields[x] = x; });
        })(RolePermissionRow = Administration.RolePermissionRow || (Administration.RolePermissionRow = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RolePermissionService;
        (function (RolePermissionService) {
            RolePermissionService.baseUrl = 'Administration/RolePermission';
            var Methods;
            (function (Methods) {
            })(Methods = RolePermissionService.Methods || (RolePermissionService.Methods = {}));
            ['Update', 'List'].forEach(function (x) {
                RolePermissionService[x] = function (r, s, o) { return Q.serviceRequest(RolePermissionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = RolePermissionService.baseUrl + '/' + x;
            });
        })(RolePermissionService = Administration.RolePermissionService || (Administration.RolePermissionService = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RoleRow;
        (function (RoleRow) {
            RoleRow.idProperty = 'RoleId';
            RoleRow.nameProperty = 'RoleName';
            RoleRow.localTextPrefix = 'Administration.Role';
            RoleRow.lookupKey = 'Administration.Role';
            function getLookup() {
                return Q.getLookup('Administration.Role');
            }
            RoleRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = RoleRow.Fields || (RoleRow.Fields = {}));
            ['RoleId', 'RoleName'].forEach(function (x) { return Fields[x] = x; });
        })(RoleRow = Administration.RoleRow || (Administration.RoleRow = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var RoleService;
        (function (RoleService) {
            RoleService.baseUrl = 'Administration/Role';
            var Methods;
            (function (Methods) {
            })(Methods = RoleService.Methods || (RoleService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                RoleService[x] = function (r, s, o) { return Q.serviceRequest(RoleService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = RoleService.baseUrl + '/' + x;
            });
        })(RoleService = Administration.RoleService || (Administration.RoleService = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var TranslationService;
        (function (TranslationService) {
            TranslationService.baseUrl = 'Administration/Translation';
            var Methods;
            (function (Methods) {
            })(Methods = TranslationService.Methods || (TranslationService.Methods = {}));
            ['List', 'Update'].forEach(function (x) {
                TranslationService[x] = function (r, s, o) { return Q.serviceRequest(TranslationService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TranslationService.baseUrl + '/' + x;
            });
        })(TranslationService = Administration.TranslationService || (Administration.TranslationService = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserForm = (function (_super) {
            __extends(UserForm, _super);
            function UserForm() {
                return _super.apply(this, arguments) || this;
            }
            return UserForm;
        }(Serenity.PrefixedContext));
        UserForm.formKey = 'Administration.User';
        Administration.UserForm = UserForm;
        [['Username', function () { return Serenity.StringEditor; }], ['DisplayName', function () { return Serenity.StringEditor; }], ['EmpresaId', function () { return Serenity.LookupEditor; }], ['HotelId', function () { return Serenity.LookupEditor; }], ['Email', function () { return Serenity.EmailEditor; }], ['UserImage', function () { return Serenity.ImageUploadEditor; }], ['Password', function () { return Serenity.PasswordEditor; }], ['PasswordConfirm', function () { return Serenity.PasswordEditor; }], ['Source', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(UserForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserPermissionRow;
        (function (UserPermissionRow) {
            UserPermissionRow.idProperty = 'UserPermissionId';
            UserPermissionRow.nameProperty = 'PermissionKey';
            UserPermissionRow.localTextPrefix = 'Administration.UserPermission';
            var Fields;
            (function (Fields) {
            })(Fields = UserPermissionRow.Fields || (UserPermissionRow.Fields = {}));
            ['UserPermissionId', 'UserId', 'PermissionKey', 'Granted', 'Username', 'User'].forEach(function (x) { return Fields[x] = x; });
        })(UserPermissionRow = Administration.UserPermissionRow || (Administration.UserPermissionRow = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserPermissionService;
        (function (UserPermissionService) {
            UserPermissionService.baseUrl = 'Administration/UserPermission';
            var Methods;
            (function (Methods) {
            })(Methods = UserPermissionService.Methods || (UserPermissionService.Methods = {}));
            ['Update', 'List', 'ListRolePermissions', 'ListPermissionKeys'].forEach(function (x) {
                UserPermissionService[x] = function (r, s, o) { return Q.serviceRequest(UserPermissionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = UserPermissionService.baseUrl + '/' + x;
            });
        })(UserPermissionService = Administration.UserPermissionService || (Administration.UserPermissionService = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserRoleRow;
        (function (UserRoleRow) {
            UserRoleRow.idProperty = 'UserRoleId';
            UserRoleRow.localTextPrefix = 'Administration.UserRole';
            var Fields;
            (function (Fields) {
            })(Fields = UserRoleRow.Fields || (UserRoleRow.Fields = {}));
            ['UserRoleId', 'UserId', 'RoleId', 'Username', 'User'].forEach(function (x) { return Fields[x] = x; });
        })(UserRoleRow = Administration.UserRoleRow || (Administration.UserRoleRow = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserRoleService;
        (function (UserRoleService) {
            UserRoleService.baseUrl = 'Administration/UserRole';
            var Methods;
            (function (Methods) {
            })(Methods = UserRoleService.Methods || (UserRoleService.Methods = {}));
            ['Update', 'List'].forEach(function (x) {
                UserRoleService[x] = function (r, s, o) { return Q.serviceRequest(UserRoleService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = UserRoleService.baseUrl + '/' + x;
            });
        })(UserRoleService = Administration.UserRoleService || (Administration.UserRoleService = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserRow;
        (function (UserRow) {
            UserRow.idProperty = 'UserId';
            UserRow.isActiveProperty = 'IsActive';
            UserRow.nameProperty = 'Username';
            UserRow.localTextPrefix = 'Administration.User';
            UserRow.lookupKey = 'Administration.User';
            function getLookup() {
                return Q.getLookup('Administration.User');
            }
            UserRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = UserRow.Fields || (UserRow.Fields = {}));
            ['UserId', 'Username', 'Source', 'PasswordHash', 'PasswordSalt', 'DisplayName', 'Email', 'UserImage', 'LastDirectoryUpdate', 'IsActive', 'EmpresaId', 'HotelId', 'Empresa', 'HotelName', 'Password', 'PasswordConfirm', 'InsertUserId', 'InsertDate', 'UpdateUserId', 'UpdateDate'].forEach(function (x) { return Fields[x] = x; });
        })(UserRow = Administration.UserRow || (Administration.UserRow = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Administration;
    (function (Administration) {
        var UserService;
        (function (UserService) {
            UserService.baseUrl = 'Administration/User';
            var Methods;
            (function (Methods) {
            })(Methods = UserService.Methods || (UserService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Undelete', 'Retrieve', 'List'].forEach(function (x) {
                UserService[x] = function (r, s, o) { return Q.serviceRequest(UserService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = UserService.baseUrl + '/' + x;
            });
        })(UserService = Administration.UserService || (Administration.UserService = {}));
    })(Administration = Geshotel.Administration || (Geshotel.Administration = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var UserPreferenceRow;
        (function (UserPreferenceRow) {
            UserPreferenceRow.idProperty = 'UserPreferenceId';
            UserPreferenceRow.nameProperty = 'Name';
            UserPreferenceRow.localTextPrefix = 'Common.UserPreference';
            var Fields;
            (function (Fields) {
            })(Fields = UserPreferenceRow.Fields || (UserPreferenceRow.Fields = {}));
            ['UserPreferenceId', 'UserId', 'PreferenceType', 'Name', 'Value'].forEach(function (x) { return Fields[x] = x; });
        })(UserPreferenceRow = Common.UserPreferenceRow || (Common.UserPreferenceRow = {}));
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var UserPreferenceService;
        (function (UserPreferenceService) {
            UserPreferenceService.baseUrl = 'Common/UserPreference';
            var Methods;
            (function (Methods) {
            })(Methods = UserPreferenceService.Methods || (UserPreferenceService.Methods = {}));
            ['Update', 'Retrieve'].forEach(function (x) {
                UserPreferenceService[x] = function (r, s, o) { return Q.serviceRequest(UserPreferenceService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = UserPreferenceService.baseUrl + '/' + x;
            });
        })(UserPreferenceService = Common.UserPreferenceService || (Common.UserPreferenceService = {}));
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var AgenciasForm = (function (_super) {
            __extends(AgenciasForm, _super);
            function AgenciasForm() {
                return _super.apply(this, arguments) || this;
            }
            return AgenciasForm;
        }(Serenity.PrefixedContext));
        AgenciasForm.formKey = 'Contratos.Agencias';
        Contratos.AgenciasForm = AgenciasForm;
        [['Razon', function () { return Serenity.StringEditor; }], ['DescCorta', function () { return Serenity.StringEditor; }], ['Nombre', function () { return Serenity.StringEditor; }], ['Apellidos', function () { return Serenity.StringEditor; }], ['EmpresaId', function () { return Serenity.IntegerEditor; }], ['AgenciaId', function () { return Serenity.IntegerEditor; }], ['MercadoId', function () { return Serenity.IntegerEditor; }], ['ClienteDefecto', function () { return Serenity.BooleanEditor; }], ['GrupoClienteId', function () { return Serenity.IntegerEditor; }], ['TipoDocumentoId', function () { return Serenity.StringEditor; }], ['Nif', function () { return Serenity.StringEditor; }], ['FechaDocumento', function () { return Serenity.DateEditor; }], ['SexoId', function () { return Serenity.StringEditor; }], ['Direccion', function () { return Serenity.StringEditor; }], ['Poblacion', function () { return Serenity.StringEditor; }], ['Zip', function () { return Serenity.StringEditor; }], ['NacionId', function () { return Serenity.IntegerEditor; }], ['ProvinciaId', function () { return Serenity.IntegerEditor; }], ['CtaContableAnticipo', function () { return Serenity.StringEditor; }], ['CtaContable', function () { return Serenity.StringEditor; }], ['DptoContable', function () { return Serenity.StringEditor; }], ['CtaDepositos', function () { return Serenity.StringEditor; }], ['Telefono', function () { return Serenity.StringEditor; }], ['Email', function () { return Serenity.StringEditor; }], ['Fax', function () { return Serenity.StringEditor; }], ['Contacto', function () { return Serenity.StringEditor; }], ['TelefonoContacto', function () { return Serenity.StringEditor; }], ['FaxContacto', function () { return Serenity.StringEditor; }], ['EmailContacto', function () { return Serenity.StringEditor; }], ['AceptaLopd', function () { return Serenity.DateEditor; }], ['CifFra', function () { return Serenity.StringEditor; }], ['DireccionFra', function () { return Serenity.StringEditor; }], ['PoblacionFra', function () { return Serenity.StringEditor; }], ['ZipFra', function () { return Serenity.StringEditor; }], ['NacionIdFactura', function () { return Serenity.IntegerEditor; }], ['ProvinciaIdFactura', function () { return Serenity.IntegerEditor; }], ['ClienteFactura', function () { return Serenity.BooleanEditor; }], ['ClienteHuesped', function () { return Serenity.BooleanEditor; }], ['PermiteCredito', function () { return Serenity.BooleanEditor; }], ['LimiteCredito', function () { return Serenity.DecimalEditor; }], ['FacturaAnticipada', function () { return Serenity.BooleanEditor; }], ['VencimientoFacturasId', function () { return Serenity.IntegerEditor; }], ['FechaNacimiento', function () { return Serenity.DateEditor; }], ['UserId', function () { return Serenity.IntegerEditor; }], ['FechaModificacion', function () { return Serenity.DateEditor; }], ['ClienteBavel', function () { return Serenity.StringEditor; }], ['Foto1', function () { return Serenity.StringEditor; }], ['Foto2', function () { return Serenity.StringEditor; }], ['DingusExtras', function () { return Serenity.BooleanEditor; }], ['IdClubhd', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(AgenciasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var AgenciasRow;
        (function (AgenciasRow) {
            AgenciasRow.idProperty = 'ClienteId';
            AgenciasRow.nameProperty = 'Razon';
            AgenciasRow.localTextPrefix = 'Contratos.Agencias';
            AgenciasRow.lookupKey = 'Contratos.Agencias';
            function getLookup() {
                return Q.getLookup('Contratos.Agencias');
            }
            AgenciasRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = AgenciasRow.Fields || (AgenciasRow.Fields = {}));
            ['ClienteId', 'Razon', 'DescCorta', 'Nombre', 'Apellidos', 'EmpresaId', 'AgenciaId', 'MercadoId', 'ClienteDefecto', 'GrupoClienteId', 'TipoDocumentoId', 'Nif', 'FechaDocumento', 'SexoId', 'Direccion', 'Poblacion', 'Zip', 'NacionId', 'ProvinciaId', 'CtaContableAnticipo', 'CtaContable', 'DptoContable', 'CtaDepositos', 'Telefono', 'Email', 'Fax', 'Contacto', 'TelefonoContacto', 'FaxContacto', 'EmailContacto', 'AceptaLopd', 'CifFra', 'DireccionFra', 'PoblacionFra', 'ZipFra', 'NacionIdFactura', 'ProvinciaIdFactura', 'ClienteFactura', 'ClienteHuesped', 'PermiteCredito', 'LimiteCredito', 'FacturaAnticipada', 'VencimientoFacturasId', 'FechaNacimiento', 'UserId', 'FechaModificacion', 'ClienteBavel', 'Foto1', 'Foto2', 'DingusExtras', 'IdClubhd'].forEach(function (x) { return Fields[x] = x; });
        })(AgenciasRow = Contratos.AgenciasRow || (Contratos.AgenciasRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var AgenciasService;
        (function (AgenciasService) {
            AgenciasService.baseUrl = 'Contratos/Agencias';
            var Methods;
            (function (Methods) {
            })(Methods = AgenciasService.Methods || (AgenciasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                AgenciasService[x] = function (r, s, o) { return Q.serviceRequest(AgenciasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = AgenciasService.baseUrl + '/' + x;
            });
        })(AgenciasService = Contratos.AgenciasService || (Contratos.AgenciasService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var AmbitoOfertaRow;
        (function (AmbitoOfertaRow) {
            AmbitoOfertaRow.idProperty = 'AmbitoOfertaId';
            AmbitoOfertaRow.nameProperty = 'Ambito';
            AmbitoOfertaRow.localTextPrefix = 'Contratos.AmbitoOferta';
            AmbitoOfertaRow.lookupKey = 'Contratos.AmbitoOferta';
            function getLookup() {
                return Q.getLookup('Contratos.AmbitoOferta');
            }
            AmbitoOfertaRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = AmbitoOfertaRow.Fields || (AmbitoOfertaRow.Fields = {}));
            ['AmbitoOfertaId', 'Ambito'].forEach(function (x) { return Fields[x] = x; });
        })(AmbitoOfertaRow = Contratos.AmbitoOfertaRow || (Contratos.AmbitoOfertaRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ClientesForm = (function (_super) {
            __extends(ClientesForm, _super);
            function ClientesForm() {
                return _super.apply(this, arguments) || this;
            }
            return ClientesForm;
        }(Serenity.PrefixedContext));
        ClientesForm.formKey = 'Contratos.Clientes';
        Contratos.ClientesForm = ClientesForm;
        [['Razon', function () { return Serenity.StringEditor; }], ['DescCorta', function () { return Serenity.StringEditor; }], ['EmpresaId', function () { return Serenity.LookupEditor; }], ['AgenciaId', function () { return Serenity.LookupEditor; }], ['ClienteDefecto', function () { return Serenity.BooleanEditor; }], ['GrupoClienteId', function () { return Serenity.LookupEditor; }], ['TipoDocumentoId', function () { return Serenity.LookupEditor; }], ['Nif', function () { return Serenity.StringEditor; }], ['Direccion', function () { return Serenity.StringEditor; }], ['Poblacion', function () { return Serenity.StringEditor; }], ['Zip', function () { return Serenity.StringEditor; }], ['NacionId', function () { return Serenity.LookupEditor; }], ['ProvinciaId', function () { return Serenity.LookupEditor; }], ['CtaContableAnticipo', function () { return Serenity.StringEditor; }], ['CtaContable', function () { return Serenity.StringEditor; }], ['DptoContable', function () { return Serenity.StringEditor; }], ['CtaDepositos', function () { return Serenity.StringEditor; }], ['Telefono', function () { return Serenity.StringEditor; }], ['Email', function () { return Serenity.EmailEditor; }], ['Fax', function () { return Serenity.StringEditor; }], ['Contacto', function () { return Serenity.StringEditor; }], ['TelefonoContacto', function () { return Serenity.StringEditor; }], ['FaxContacto', function () { return Serenity.StringEditor; }], ['EmailContacto', function () { return Serenity.EmailEditor; }], ['CifFra', function () { return Serenity.StringEditor; }], ['DireccionFra', function () { return Serenity.StringEditor; }], ['PoblacionFra', function () { return Serenity.StringEditor; }], ['ZipFra', function () { return Serenity.StringEditor; }], ['NacionIdFactura', function () { return Serenity.LookupEditor; }], ['ProvinciaIdFactura', function () { return Serenity.LookupEditor; }], ['ClienteFactura', function () { return Serenity.BooleanEditor; }], ['PermiteCredito', function () { return Serenity.BooleanEditor; }], ['LimiteCredito', function () { return Serenity.DecimalEditor; }], ['FacturaAnticipada', function () { return Serenity.BooleanEditor; }], ['VencimientoFacturasId', function () { return Serenity.IntegerEditor; }], ['ClienteBavel', function () { return Serenity.StringEditor; }], ['DingusExtras', function () { return Serenity.BooleanEditor; }]].forEach(function (x) { return Object.defineProperty(ClientesForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ClientesRow;
        (function (ClientesRow) {
            ClientesRow.idProperty = 'ClienteId';
            ClientesRow.nameProperty = 'Razon';
            ClientesRow.localTextPrefix = 'Contratos.Clientes';
            ClientesRow.lookupKey = 'Contratos.Clientes';
            function getLookup() {
                return Q.getLookup('Contratos.Clientes');
            }
            ClientesRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ClientesRow.Fields || (ClientesRow.Fields = {}));
            ['ClienteId', 'Razon', 'DescCorta', 'EmpresaId', 'AgenciaId', 'ClienteDefecto', 'GrupoClienteId', 'TipoDocumentoId', 'Nif', 'FechaDocumento', 'Direccion', 'Poblacion', 'Zip', 'NacionId', 'ProvinciaId', 'CtaContableAnticipo', 'CtaContable', 'DptoContable', 'CtaDepositos', 'Telefono', 'Email', 'Fax', 'Contacto', 'TelefonoContacto', 'FaxContacto', 'EmailContacto', 'CifFra', 'DireccionFra', 'PoblacionFra', 'ZipFra', 'NacionIdFactura', 'ProvinciaIdFactura', 'ClienteFactura', 'ClienteHuesped', 'PermiteCredito', 'LimiteCredito', 'FacturaAnticipada', 'VencimientoFacturasId', 'UserId', 'FechaModificacion', 'ClienteBavel', 'DingusExtras', 'Empresa', 'Agencia', 'TipoDocumento', 'Nacion', 'Provincia', 'FacturaNacion', 'FacturaProvincia'].forEach(function (x) { return Fields[x] = x; });
        })(ClientesRow = Contratos.ClientesRow || (Contratos.ClientesRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ClientesService;
        (function (ClientesService) {
            ClientesService.baseUrl = 'Contratos/Clientes';
            var Methods;
            (function (Methods) {
            })(Methods = ClientesService.Methods || (ClientesService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ClientesService[x] = function (r, s, o) { return Q.serviceRequest(ClientesService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ClientesService.baseUrl + '/' + x;
            });
        })(ClientesService = Contratos.ClientesService || (Contratos.ClientesService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosEdadesForm = (function (_super) {
            __extends(ContratosEdadesForm, _super);
            function ContratosEdadesForm() {
                return _super.apply(this, arguments) || this;
            }
            return ContratosEdadesForm;
        }(Serenity.PrefixedContext));
        ContratosEdadesForm.formKey = 'Contratos.ContratosEdades';
        Contratos.ContratosEdadesForm = ContratosEdadesForm;
        [['ContratoId', function () { return Serenity.IntegerEditor; }], ['TipoHuespedId', function () { return Serenity.IntegerEditor; }], ['EdadMinima', function () { return Serenity.IntegerEditor; }], ['EdadMaxima', function () { return Serenity.IntegerEditor; }], ['UserId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(ContratosEdadesForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosEdadesRow;
        (function (ContratosEdadesRow) {
            ContratosEdadesRow.idProperty = 'ContratoId';
            ContratosEdadesRow.localTextPrefix = 'Contratos.ContratosEdades';
            var Fields;
            (function (Fields) {
            })(Fields = ContratosEdadesRow.Fields || (ContratosEdadesRow.Fields = {}));
            ['ContratoId', 'TipoHuespedId', 'EdadMinima', 'EdadMaxima', 'UserId'].forEach(function (x) { return Fields[x] = x; });
        })(ContratosEdadesRow = Contratos.ContratosEdadesRow || (Contratos.ContratosEdadesRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosEdadesService;
        (function (ContratosEdadesService) {
            ContratosEdadesService.baseUrl = 'Contratos/ContratosEdades';
            var Methods;
            (function (Methods) {
            })(Methods = ContratosEdadesService.Methods || (ContratosEdadesService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ContratosEdadesService[x] = function (r, s, o) { return Q.serviceRequest(ContratosEdadesService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ContratosEdadesService.baseUrl + '/' + x;
            });
        })(ContratosEdadesService = Contratos.ContratosEdadesService || (Contratos.ContratosEdadesService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosForm = (function (_super) {
            __extends(ContratosForm, _super);
            function ContratosForm() {
                return _super.apply(this, arguments) || this;
            }
            return ContratosForm;
        }(Serenity.PrefixedContext));
        ContratosForm.formKey = 'Contratos.Contratos';
        Contratos.ContratosForm = ContratosForm;
        [['HotelId', function () { return Serenity.LookupEditor; }], ['ClienteId', function () { return Serenity.LookupEditor; }], ['FechaContrato', function () { return Serenity.DateEditor; }], ['FechaDesde', function () { return Serenity.DateEditor; }], ['FechaHasta', function () { return Serenity.DateEditor; }], ['NumeroContratoCliente', function () { return Serenity.StringEditor; }], ['UserId', function () { return Serenity.IntegerEditor; }], ['FechaModificacion', function () { return Serenity.DateEditor; }], ['TemporadaId', function () { return Serenity.IntegerEditor; }], ['ImpuestoIncluido', function () { return Serenity.BooleanEditor; }], ['MercadoId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(ContratosForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosRow;
        (function (ContratosRow) {
            ContratosRow.idProperty = 'ContratoId';
            ContratosRow.nameProperty = 'NumeroContratoCliente';
            ContratosRow.localTextPrefix = 'Contratos.Contratos';
            var Fields;
            (function (Fields) {
            })(Fields = ContratosRow.Fields || (ContratosRow.Fields = {}));
            ['ContratoId', 'HotelId', 'ClienteId', 'FechaContrato', 'FechaDesde', 'FechaHasta', 'NumeroContratoCliente', 'UserId', 'FechaModificacion', 'TemporadaId', 'ImpuestoIncluido', 'MercadoId', 'HotelName', 'ClienteName'].forEach(function (x) { return Fields[x] = x; });
        })(ContratosRow = Contratos.ContratosRow || (Contratos.ContratosRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosService;
        (function (ContratosService) {
            ContratosService.baseUrl = 'Contratos/Contratos';
            var Methods;
            (function (Methods) {
            })(Methods = ContratosService.Methods || (ContratosService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ContratosService[x] = function (r, s, o) { return Q.serviceRequest(ContratosService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ContratosService.baseUrl + '/' + x;
            });
        })(ContratosService = Contratos.ContratosService || (Contratos.ContratosService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var CuposForm = (function (_super) {
            __extends(CuposForm, _super);
            function CuposForm() {
                return _super.apply(this, arguments) || this;
            }
            return CuposForm;
        }(Serenity.PrefixedContext));
        CuposForm.formKey = 'Contratos.Cupos';
        Contratos.CuposForm = CuposForm;
        [['ClienteId', function () { return Serenity.IntegerEditor; }], ['HotelId', function () { return Serenity.IntegerEditor; }], ['FechaDesde', function () { return Serenity.DateEditor; }], ['FechaHasta', function () { return Serenity.DateEditor; }], ['TipoHabitacionId', function () { return Serenity.IntegerEditor; }], ['Garantia', function () { return Serenity.DecimalEditor; }], ['ReservaAutomatica', function () { return Serenity.StringEditor; }], ['UserId', function () { return Serenity.IntegerEditor; }], ['FechaModificacion', function () { return Serenity.DateEditor; }]].forEach(function (x) { return Object.defineProperty(CuposForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var CuposRow;
        (function (CuposRow) {
            CuposRow.idProperty = 'CupoId';
            CuposRow.localTextPrefix = 'Contratos.Cupos';
            var Fields;
            (function (Fields) {
            })(Fields = CuposRow.Fields || (CuposRow.Fields = {}));
            ['CupoId', 'ClienteId', 'HotelId', 'FechaDesde', 'FechaHasta', 'TipoHabitacionId', 'Garantia', 'ReservaAutomatica', 'UserId', 'FechaModificacion', 'ClienteRazon', 'ClienteDescCorta', 'ClienteNombre', 'ClienteApellidos', 'ClienteEmpresaId', 'ClienteAgenciaId', 'ClienteMercadoId', 'ClienteClienteDefecto', 'ClienteGrupoClienteId', 'ClienteTipoDocumentoId', 'ClienteNif', 'ClienteFechaDocumento', 'ClienteSexoId', 'ClienteDireccion', 'ClientePoblacion', 'ClienteZip', 'ClienteNacionId', 'ClienteProvinciaId', 'ClienteCtaContableAnticipo', 'ClienteCtaContable', 'ClienteDptoContable', 'ClienteCtaDepositos', 'ClienteTelefono', 'ClienteEmail', 'ClienteFax', 'ClienteContacto', 'ClienteTelefonoContacto', 'ClienteFaxContacto', 'ClienteEmailContacto', 'ClienteAceptaLopd', 'ClienteCifFra', 'ClienteDireccionFra', 'ClientePoblacionFra', 'ClienteZipFra', 'ClienteNacionIdFactura', 'ClienteProvinciaIdFactura', 'ClienteClienteFactura', 'ClienteClienteHuesped', 'ClientePermiteCredito', 'ClienteLimiteCredito', 'ClienteFacturaAnticipada', 'ClienteVencimientoFacturasId', 'ClienteFechaNacimiento', 'ClienteUserId', 'ClienteFechaModificacion', 'ClienteClienteBavel', 'ClienteFoto1', 'ClienteFoto2', 'ClienteDingusExtras', 'ClienteIdClubhd', 'Hotel', 'HotelEmpresaId', 'HotelTipoHotelId', 'HotelCategoriaId', 'HotelNombreCorto', 'HotelDireccion', 'HotelPoblacion', 'HotelZip', 'HotelProvinciaId', 'HotelNacionId', 'HotelTelefono', 'HotelFax', 'HotelCtaManocorriente', 'HotelDptoContable', 'HotelCtaContableCajas', 'HotelCtaContableBanco', 'HotelFechaInicioPrograma', 'HotelRutaFicheroPolicia', 'HotelContadorFicheroPolicia', 'HotelIdentificadorFicheroPolicia', 'HotelEmailReservas', 'HotelEmailVentas', 'HotelEmailSmtp', 'HotelTextoCancelacion', 'HotelUsuarioIsta', 'HotelPasswordIsta', 'HotelUrlIsta', 'HotelMunicipioIsta', 'HotelNumeroRegistroIsta', 'HotelRutaBavel', 'HotelDingusUsuario', 'HotelDingusPassword', 'HotelDingusHotelCode', 'HotelDingusTraductor', 'HotelDingusUrl', 'HotelCheckinOnLine', 'HotelMinimoDiasCheckinOnline', 'HotelZoomMapa', 'HotelLat', 'HotelLng', 'HotelAncho', 'HotelAlto', 'HotelOverbookingLimit', 'TipoHabitacionDescCorta', 'TipoHabitacionDescripcion', 'TipoHabitacionGrupoHabitacionId', 'TipoHabitacionNumeroPersonas', 'TipoHabitacionDesvios', 'TipoHabitacionNoShow'].forEach(function (x) { return Fields[x] = x; });
        })(CuposRow = Contratos.CuposRow || (Contratos.CuposRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var CuposService;
        (function (CuposService) {
            CuposService.baseUrl = 'Contratos/Cupos';
            var Methods;
            (function (Methods) {
            })(Methods = CuposService.Methods || (CuposService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                CuposService[x] = function (r, s, o) { return Q.serviceRequest(CuposService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = CuposService.baseUrl + '/' + x;
            });
        })(CuposService = Contratos.CuposService || (Contratos.CuposService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var EdadesForm = (function (_super) {
            __extends(EdadesForm, _super);
            function EdadesForm() {
                return _super.apply(this, arguments) || this;
            }
            return EdadesForm;
        }(Serenity.PrefixedContext));
        EdadesForm.formKey = 'Contratos.Edades';
        Contratos.EdadesForm = EdadesForm;
        [['TipoHuespedId', function () { return Serenity.IntegerEditor; }], ['EdadMinima', function () { return Serenity.IntegerEditor; }], ['EdadMaxima', function () { return Serenity.IntegerEditor; }], ['UserId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(EdadesForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var EdadesRow;
        (function (EdadesRow) {
            EdadesRow.idProperty = 'ContratoId';
            EdadesRow.localTextPrefix = 'Contratos.Edades';
            var Fields;
            (function (Fields) {
            })(Fields = EdadesRow.Fields || (EdadesRow.Fields = {}));
            ['ContratoId', 'TipoHuespedId', 'EdadMinima', 'EdadMaxima', 'UserId'].forEach(function (x) { return Fields[x] = x; });
        })(EdadesRow = Contratos.EdadesRow || (Contratos.EdadesRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var EdadesService;
        (function (EdadesService) {
            EdadesService.baseUrl = 'Contratos/Edades';
            var Methods;
            (function (Methods) {
            })(Methods = EdadesService.Methods || (EdadesService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                EdadesService[x] = function (r, s, o) { return Q.serviceRequest(EdadesService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = EdadesService.baseUrl + '/' + x;
            });
        })(EdadesService = Contratos.EdadesService || (Contratos.EdadesService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var FrecuenciaFacturacionRow;
        (function (FrecuenciaFacturacionRow) {
            FrecuenciaFacturacionRow.idProperty = 'FrecuenciaId';
            FrecuenciaFacturacionRow.nameProperty = 'Descripcion';
            FrecuenciaFacturacionRow.localTextPrefix = 'Contratos.FrecuenciaFacturacion';
            FrecuenciaFacturacionRow.lookupKey = 'Contratos.FrecuenciaFacturacion';
            function getLookup() {
                return Q.getLookup('Contratos.FrecuenciaFacturacion');
            }
            FrecuenciaFacturacionRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = FrecuenciaFacturacionRow.Fields || (FrecuenciaFacturacionRow.Fields = {}));
            ['FrecuenciaId', 'DescripcionCorta', 'Descripcion'].forEach(function (x) { return Fields[x] = x; });
        })(FrecuenciaFacturacionRow = Contratos.FrecuenciaFacturacionRow || (Contratos.FrecuenciaFacturacionRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var LineasForm = (function (_super) {
            __extends(LineasForm, _super);
            function LineasForm() {
                return _super.apply(this, arguments) || this;
            }
            return LineasForm;
        }(Serenity.PrefixedContext));
        LineasForm.formKey = 'Contratos.Lineas';
        Contratos.LineasForm = LineasForm;
        [['ContratoId', function () { return Serenity.IntegerEditor; }], ['Oferta', function () { return Serenity.BooleanEditor; }], ['Desde', function () { return Serenity.DateEditor; }], ['Hasta', function () { return Serenity.DateEditor; }], ['ServicioId', function () { return Serenity.LookupEditor; }], ['UnidadCalculoId', function () { return Serenity.LookupEditor; }], ['FrecuenciaId', function () { return Serenity.LookupEditor; }], ['TipoImputacionId', function () { return Serenity.LookupEditor; }], ['Importe', function () { return Serenity.DecimalEditor; }], ['N', function () { return Serenity.IntegerEditor; }], ['TipoOfertaId', function () { return Serenity.IntegerEditor; }], ['M', function () { return Serenity.DecimalEditor; }], ['AmbitoOfertaId', function () { return Serenity.IntegerEditor; }], ['Lunes', function () { return Serenity.BooleanEditor; }], ['Martes', function () { return Serenity.BooleanEditor; }], ['Miercoles', function () { return Serenity.BooleanEditor; }], ['Jueves', function () { return Serenity.BooleanEditor; }], ['Viernes', function () { return Serenity.BooleanEditor; }], ['Sabado', function () { return Serenity.BooleanEditor; }], ['Domingo', function () { return Serenity.BooleanEditor; }], ['PagFactura', function () { return Serenity.IntegerEditor; }], ['UserId', function () { return Serenity.LookupEditor; }], ['FechaModificacion', function () { return Serenity.DateEditor; }]].forEach(function (x) { return Object.defineProperty(LineasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var LineasRow;
        (function (LineasRow) {
            LineasRow.idProperty = 'LineaContratoId';
            LineasRow.localTextPrefix = 'Contratos.Lineas';
            var Fields;
            (function (Fields) {
            })(Fields = LineasRow.Fields || (LineasRow.Fields = {}));
            ['LineaContratoId', 'ContratoId', 'Oferta', 'Desde', 'Hasta', 'ServicioId', 'UnidadCalculoId', 'FrecuenciaId', 'TipoImputacionId', 'Importe', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo', 'PagFactura', 'UserId', 'FechaModificacion', 'Servicio', 'UnidadCalculo', 'Frecuencia', 'Imputacion', 'Usuario'].forEach(function (x) { return Fields[x] = x; });
        })(LineasRow = Contratos.LineasRow || (Contratos.LineasRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var LineasService;
        (function (LineasService) {
            LineasService.baseUrl = 'Contratos/Lineas';
            var Methods;
            (function (Methods) {
            })(Methods = LineasService.Methods || (LineasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                LineasService[x] = function (r, s, o) { return Q.serviceRequest(LineasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = LineasService.baseUrl + '/' + x;
            });
        })(LineasService = Contratos.LineasService || (Contratos.LineasService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var MercadosForm = (function (_super) {
            __extends(MercadosForm, _super);
            function MercadosForm() {
                return _super.apply(this, arguments) || this;
            }
            return MercadosForm;
        }(Serenity.PrefixedContext));
        MercadosForm.formKey = 'Contratos.Mercados';
        Contratos.MercadosForm = MercadosForm;
        [['Mercado', function () { return Serenity.StringEditor; }], ['EmpresaId', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(MercadosForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var MercadosRow;
        (function (MercadosRow) {
            MercadosRow.idProperty = 'MercadoId';
            MercadosRow.nameProperty = 'Mercado';
            MercadosRow.localTextPrefix = 'Contratos.Mercados';
            MercadosRow.lookupKey = 'Contratos.Mercados';
            function getLookup() {
                return Q.getLookup('Contratos.Mercados');
            }
            MercadosRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = MercadosRow.Fields || (MercadosRow.Fields = {}));
            ['MercadoId', 'Mercado', 'EmpresaId', 'Empresa', 'EmpresaEmpresaContable', 'EmpresaDireccion', 'EmpresaPoblacion', 'EmpresaZip', 'EmpresaProvinciaId', 'EmpresaTelefono', 'EmpresaFax', 'EmpresaCif', 'EmpresaRutaFicheros'].forEach(function (x) { return Fields[x] = x; });
        })(MercadosRow = Contratos.MercadosRow || (Contratos.MercadosRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var MercadosService;
        (function (MercadosService) {
            MercadosService.baseUrl = 'Contratos/Mercados';
            var Methods;
            (function (Methods) {
            })(Methods = MercadosService.Methods || (MercadosService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MercadosService[x] = function (r, s, o) { return Q.serviceRequest(MercadosService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MercadosService.baseUrl + '/' + x;
            });
        })(MercadosService = Contratos.MercadosService || (Contratos.MercadosService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasForm = (function (_super) {
            __extends(OfertasForm, _super);
            function OfertasForm() {
                return _super.apply(this, arguments) || this;
            }
            return OfertasForm;
        }(Serenity.PrefixedContext));
        OfertasForm.formKey = 'Contratos.Ofertas';
        Contratos.OfertasForm = OfertasForm;
        [['Texto', function () { return Serenity.StringEditor; }], ['ContratoId', function () { return Serenity.IntegerEditor; }], ['FechaDesde', function () { return Serenity.DateEditor; }], ['FechaHasta', function () { return Serenity.DateEditor; }], ['TipoAplicacionOfertaId', function () { return Serenity.StringEditor; }], ['AplicableAuto', function () { return Serenity.BooleanEditor; }], ['FechaReservaDesde', function () { return Serenity.DateEditor; }], ['FechaReservaHasta', function () { return Serenity.DateEditor; }], ['EstanciaMinimaDias', function () { return Serenity.IntegerEditor; }], ['EstanciaMaximaDias', function () { return Serenity.IntegerEditor; }], ['DiasDeAntelacion', function () { return Serenity.IntegerEditor; }], ['TipoServicioId', function () { return Serenity.IntegerEditor; }], ['ServicioId', function () { return Serenity.IntegerEditor; }], ['UnidadCalculoId', function () { return Serenity.IntegerEditor; }], ['ServicioLigadoId', function () { return Serenity.IntegerEditor; }], ['CupoOferta', function () { return Serenity.IntegerEditor; }], ['Precio', function () { return Serenity.DecimalEditor; }], ['N', function () { return Serenity.DecimalEditor; }], ['TipoOfertaId', function () { return Serenity.IntegerEditor; }], ['M', function () { return Serenity.DecimalEditor; }], ['AmbitoOfertaId', function () { return Serenity.IntegerEditor; }], ['UserId', function () { return Serenity.IntegerEditor; }], ['FechaModificacion', function () { return Serenity.DateEditor; }], ['ImpuestoIncluido', function () { return Serenity.BooleanEditor; }], ['TipoImputacionId', function () { return Serenity.IntegerEditor; }], ['OrdenAplicacion', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(OfertasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasRejillasForm = (function (_super) {
            __extends(OfertasRejillasForm, _super);
            function OfertasRejillasForm() {
                return _super.apply(this, arguments) || this;
            }
            return OfertasRejillasForm;
        }(Serenity.PrefixedContext));
        OfertasRejillasForm.formKey = 'Contratos.OfertasRejillas';
        Contratos.OfertasRejillasForm = OfertasRejillasForm;
        [['OfertaId', function () { return Serenity.IntegerEditor; }], ['N', function () { return Serenity.IntegerEditor; }], ['TipoCondicionId', function () { return Serenity.IntegerEditor; }], ['TipoAplicacion', function () { return Serenity.IntegerEditor; }], ['M', function () { return Serenity.DecimalEditor; }]].forEach(function (x) { return Object.defineProperty(OfertasRejillasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasRejillasRow;
        (function (OfertasRejillasRow) {
            OfertasRejillasRow.idProperty = 'RejillaId';
            OfertasRejillasRow.localTextPrefix = 'Contratos.OfertasRejillas';
            var Fields;
            (function (Fields) {
            })(Fields = OfertasRejillasRow.Fields || (OfertasRejillasRow.Fields = {}));
            ['RejillaId', 'OfertaId', 'N', 'TipoCondicionId', 'TipoAplicacion', 'M'].forEach(function (x) { return Fields[x] = x; });
        })(OfertasRejillasRow = Contratos.OfertasRejillasRow || (Contratos.OfertasRejillasRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasRejillasService;
        (function (OfertasRejillasService) {
            OfertasRejillasService.baseUrl = 'Contratos/OfertasRejillas';
            var Methods;
            (function (Methods) {
            })(Methods = OfertasRejillasService.Methods || (OfertasRejillasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                OfertasRejillasService[x] = function (r, s, o) { return Q.serviceRequest(OfertasRejillasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = OfertasRejillasService.baseUrl + '/' + x;
            });
        })(OfertasRejillasService = Contratos.OfertasRejillasService || (Contratos.OfertasRejillasService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasRow;
        (function (OfertasRow) {
            OfertasRow.idProperty = 'OfertaId';
            OfertasRow.nameProperty = 'Texto';
            OfertasRow.localTextPrefix = 'Contratos.Ofertas';
            var Fields;
            (function (Fields) {
            })(Fields = OfertasRow.Fields || (OfertasRow.Fields = {}));
            ['OfertaId', 'Texto', 'ContratoId', 'FechaDesde', 'FechaHasta', 'TipoAplicacionOfertaId', 'AplicableAuto', 'FechaReservaDesde', 'FechaReservaHasta', 'EstanciaMinimaDias', 'EstanciaMaximaDias', 'DiasDeAntelacion', 'TipoServicioId', 'ServicioId', 'UnidadCalculoId', 'ServicioLigadoId', 'CupoOferta', 'Precio', 'N', 'TipoOfertaId', 'M', 'AmbitoOfertaId', 'UserId', 'FechaModificacion', 'ImpuestoIncluido', 'TipoImputacionId', 'OrdenAplicacion'].forEach(function (x) { return Fields[x] = x; });
        })(OfertasRow = Contratos.OfertasRow || (Contratos.OfertasRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasService;
        (function (OfertasService) {
            OfertasService.baseUrl = 'Contratos/Ofertas';
            var Methods;
            (function (Methods) {
            })(Methods = OfertasService.Methods || (OfertasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                OfertasService[x] = function (r, s, o) { return Q.serviceRequest(OfertasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = OfertasService.baseUrl + '/' + x;
            });
        })(OfertasService = Contratos.OfertasService || (Contratos.OfertasService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ReleasesForm = (function (_super) {
            __extends(ReleasesForm, _super);
            function ReleasesForm() {
                return _super.apply(this, arguments) || this;
            }
            return ReleasesForm;
        }(Serenity.PrefixedContext));
        ReleasesForm.formKey = 'Contratos.Releases';
        Contratos.ReleasesForm = ReleasesForm;
        [['ClienteId', function () { return Serenity.IntegerEditor; }], ['HotelId', function () { return Serenity.IntegerEditor; }], ['FechaDesde', function () { return Serenity.DateEditor; }], ['FechaHasta', function () { return Serenity.DateEditor; }], ['Observaciones', function () { return Serenity.StringEditor; }], ['Dias', function () { return Serenity.IntegerEditor; }], ['UserId', function () { return Serenity.IntegerEditor; }], ['FechaModificacion', function () { return Serenity.DateEditor; }]].forEach(function (x) { return Object.defineProperty(ReleasesForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ReleasesRow;
        (function (ReleasesRow) {
            ReleasesRow.idProperty = 'ReleaseId';
            ReleasesRow.nameProperty = 'Observaciones';
            ReleasesRow.localTextPrefix = 'Contratos.Releases';
            var Fields;
            (function (Fields) {
            })(Fields = ReleasesRow.Fields || (ReleasesRow.Fields = {}));
            ['ReleaseId', 'ClienteId', 'HotelId', 'FechaDesde', 'FechaHasta', 'Observaciones', 'Dias', 'UserId', 'FechaModificacion', 'ClienteRazon', 'ClienteDescCorta', 'ClienteNombre', 'ClienteApellidos', 'ClienteEmpresaId', 'ClienteAgenciaId', 'ClienteMercadoId', 'ClienteClienteDefecto', 'ClienteGrupoClienteId', 'ClienteTipoDocumentoId', 'ClienteNif', 'ClienteFechaDocumento', 'ClienteSexoId', 'ClienteDireccion', 'ClientePoblacion', 'ClienteZip', 'ClienteNacionId', 'ClienteProvinciaId', 'ClienteCtaContableAnticipo', 'ClienteCtaContable', 'ClienteDptoContable', 'ClienteCtaDepositos', 'ClienteTelefono', 'ClienteEmail', 'ClienteFax', 'ClienteContacto', 'ClienteTelefonoContacto', 'ClienteFaxContacto', 'ClienteEmailContacto', 'ClienteAceptaLopd', 'ClienteCifFra', 'ClienteDireccionFra', 'ClientePoblacionFra', 'ClienteZipFra', 'ClienteNacionIdFactura', 'ClienteProvinciaIdFactura', 'ClienteClienteFactura', 'ClienteClienteHuesped', 'ClientePermiteCredito', 'ClienteLimiteCredito', 'ClienteFacturaAnticipada', 'ClienteVencimientoFacturasId', 'ClienteFechaNacimiento', 'ClienteUserId', 'ClienteFechaModificacion', 'ClienteClienteBavel', 'ClienteFoto1', 'ClienteFoto2', 'ClienteDingusExtras', 'ClienteIdClubhd', 'Hotel', 'HotelEmpresaId', 'HotelTipoHotelId', 'HotelCategoriaId', 'HotelNombreCorto', 'HotelDireccion', 'HotelPoblacion', 'HotelZip', 'HotelProvinciaId', 'HotelNacionId', 'HotelTelefono', 'HotelFax', 'HotelCtaManocorriente', 'HotelDptoContable', 'HotelCtaContableCajas', 'HotelCtaContableBanco', 'HotelFechaInicioPrograma', 'HotelRutaFicheroPolicia', 'HotelContadorFicheroPolicia', 'HotelIdentificadorFicheroPolicia', 'HotelEmailReservas', 'HotelEmailVentas', 'HotelEmailSmtp', 'HotelTextoCancelacion', 'HotelUsuarioIsta', 'HotelPasswordIsta', 'HotelUrlIsta', 'HotelMunicipioIsta', 'HotelNumeroRegistroIsta', 'HotelRutaBavel', 'HotelDingusUsuario', 'HotelDingusPassword', 'HotelDingusHotelCode', 'HotelDingusTraductor', 'HotelDingusUrl', 'HotelCheckinOnLine', 'HotelMinimoDiasCheckinOnline', 'HotelZoomMapa', 'HotelLat', 'HotelLng', 'HotelAncho', 'HotelAlto', 'HotelOverbookingLimit'].forEach(function (x) { return Fields[x] = x; });
        })(ReleasesRow = Contratos.ReleasesRow || (Contratos.ReleasesRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ReleasesService;
        (function (ReleasesService) {
            ReleasesService.baseUrl = 'Contratos/Releases';
            var Methods;
            (function (Methods) {
            })(Methods = ReleasesService.Methods || (ReleasesService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ReleasesService[x] = function (r, s, o) { return Q.serviceRequest(ReleasesService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ReleasesService.baseUrl + '/' + x;
            });
        })(ReleasesService = Contratos.ReleasesService || (Contratos.ReleasesService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TemporadasForm = (function (_super) {
            __extends(TemporadasForm, _super);
            function TemporadasForm() {
                return _super.apply(this, arguments) || this;
            }
            return TemporadasForm;
        }(Serenity.PrefixedContext));
        TemporadasForm.formKey = 'Contratos.Temporadas';
        Contratos.TemporadasForm = TemporadasForm;
        [['Temporada', function () { return Serenity.StringEditor; }], ['EmpresaId', function () { return Serenity.IntegerEditor; }], ['Ano', function () { return Serenity.IntegerEditor; }], ['FechaDesde', function () { return Serenity.DateEditor; }], ['FechaHasta', function () { return Serenity.DateEditor; }]].forEach(function (x) { return Object.defineProperty(TemporadasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TemporadasRow;
        (function (TemporadasRow) {
            TemporadasRow.idProperty = 'TemporadaId';
            TemporadasRow.nameProperty = 'Temporada';
            TemporadasRow.localTextPrefix = 'Contratos.Temporadas';
            var Fields;
            (function (Fields) {
            })(Fields = TemporadasRow.Fields || (TemporadasRow.Fields = {}));
            ['TemporadaId', 'Temporada', 'EmpresaId', 'Ano', 'FechaDesde', 'FechaHasta', 'Empresa', 'EmpresaEmpresaContable', 'EmpresaDireccion', 'EmpresaPoblacion', 'EmpresaZip', 'EmpresaProvinciaId', 'EmpresaTelefono', 'EmpresaFax', 'EmpresaCif', 'EmpresaRutaFicheros'].forEach(function (x) { return Fields[x] = x; });
        })(TemporadasRow = Contratos.TemporadasRow || (Contratos.TemporadasRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TemporadasService;
        (function (TemporadasService) {
            TemporadasService.baseUrl = 'Contratos/Temporadas';
            var Methods;
            (function (Methods) {
            })(Methods = TemporadasService.Methods || (TemporadasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TemporadasService[x] = function (r, s, o) { return Q.serviceRequest(TemporadasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TemporadasService.baseUrl + '/' + x;
            });
        })(TemporadasService = Contratos.TemporadasService || (Contratos.TemporadasService = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TipoAplicacionOfertaRow;
        (function (TipoAplicacionOfertaRow) {
            TipoAplicacionOfertaRow.idProperty = 'TipoAplicacionOfertaId';
            TipoAplicacionOfertaRow.nameProperty = 'AplicableSegunFechaDe';
            TipoAplicacionOfertaRow.localTextPrefix = 'Contratos.TipoAplicacionOferta';
            TipoAplicacionOfertaRow.lookupKey = 'Contratos.TipoAplicacionOferta';
            function getLookup() {
                return Q.getLookup('Contratos.TipoAplicacionOferta');
            }
            TipoAplicacionOfertaRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TipoAplicacionOfertaRow.Fields || (TipoAplicacionOfertaRow.Fields = {}));
            ['TipoAplicacionOfertaId', 'AplicableSegunFechaDe'].forEach(function (x) { return Fields[x] = x; });
        })(TipoAplicacionOfertaRow = Contratos.TipoAplicacionOfertaRow || (Contratos.TipoAplicacionOfertaRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TiposCondicionRow;
        (function (TiposCondicionRow) {
            TiposCondicionRow.idProperty = 'TipoCondicionId';
            TiposCondicionRow.nameProperty = 'Literal';
            TiposCondicionRow.localTextPrefix = 'Contratos.TiposCondicion';
            TiposCondicionRow.lookupKey = 'Contratos.TiposCondicion';
            function getLookup() {
                return Q.getLookup('Contratos.TiposCondicion');
            }
            TiposCondicionRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposCondicionRow.Fields || (TiposCondicionRow.Fields = {}));
            ['TipoCondicionId', 'Condicion', 'Literal'].forEach(function (x) { return Fields[x] = x; });
        })(TiposCondicionRow = Contratos.TiposCondicionRow || (Contratos.TiposCondicionRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TiposDeImputacionRow;
        (function (TiposDeImputacionRow) {
            TiposDeImputacionRow.idProperty = 'TipoImputacionId';
            TiposDeImputacionRow.nameProperty = 'Imputacion';
            TiposDeImputacionRow.localTextPrefix = 'Contratos.TiposDeImputacion';
            TiposDeImputacionRow.lookupKey = 'Contratos.TiposDeImputacion';
            function getLookup() {
                return Q.getLookup('Contratos.TiposDeImputacion');
            }
            TiposDeImputacionRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposDeImputacionRow.Fields || (TiposDeImputacionRow.Fields = {}));
            ['TipoImputacionId', 'Imputacion'].forEach(function (x) { return Fields[x] = x; });
        })(TiposDeImputacionRow = Contratos.TiposDeImputacionRow || (Contratos.TiposDeImputacionRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TiposDeOfertaRow;
        (function (TiposDeOfertaRow) {
            TiposDeOfertaRow.idProperty = 'TipoOfertaId';
            TiposDeOfertaRow.nameProperty = 'Oferta';
            TiposDeOfertaRow.localTextPrefix = 'Contratos.TiposDeOferta';
            TiposDeOfertaRow.lookupKey = 'Contratos.TiposDeOferta';
            function getLookup() {
                return Q.getLookup('Contratos.TiposDeOferta');
            }
            TiposDeOfertaRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposDeOfertaRow.Fields || (TiposDeOfertaRow.Fields = {}));
            ['TipoOfertaId', 'Oferta', 'PermitirMMayorQueN', 'Rejilla', 'Observaciones', 'OrdenAplicacion'].forEach(function (x) { return Fields[x] = x; });
        })(TiposDeOfertaRow = Contratos.TiposDeOfertaRow || (Contratos.TiposDeOfertaRow = {}));
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaForm = (function (_super) {
            __extends(MeetingAgendaForm, _super);
            function MeetingAgendaForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingAgendaForm;
        }(Serenity.PrefixedContext));
        MeetingAgendaForm.formKey = 'Meeting.MeetingAgenda';
        Meeting.MeetingAgendaForm = MeetingAgendaForm;
        [['MeetingId', function () { return Serenity.IntegerEditor; }], ['AgendaNumber', function () { return Serenity.IntegerEditor; }], ['Title', function () { return Serenity.StringEditor; }], ['Description', function () { return Serenity.StringEditor; }], ['AgendaTypeId', function () { return Serenity.IntegerEditor; }], ['RequestedByContactId', function () { return Serenity.IntegerEditor; }], ['Images', function () { return Serenity.MultipleImageUploadEditor; }], ['Attachments', function () { return Serenity.MultipleImageUploadEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingAgendaForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaRelevantForm = (function (_super) {
            __extends(MeetingAgendaRelevantForm, _super);
            function MeetingAgendaRelevantForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingAgendaRelevantForm;
        }(Serenity.PrefixedContext));
        MeetingAgendaRelevantForm.formKey = 'Meeting.MeetingAgendaRelevant';
        Meeting.MeetingAgendaRelevantForm = MeetingAgendaRelevantForm;
        [['AgendaId', function () { return Serenity.IntegerEditor; }], ['ContactId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingAgendaRelevantForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaRelevantRow;
        (function (MeetingAgendaRelevantRow) {
            MeetingAgendaRelevantRow.idProperty = 'AgendaRelevantId';
            MeetingAgendaRelevantRow.localTextPrefix = 'Meeting.MeetingAgendaRelevant';
            var Fields;
            (function (Fields) {
            })(Fields = MeetingAgendaRelevantRow.Fields || (MeetingAgendaRelevantRow.Fields = {}));
            ['AgendaRelevantId', 'AgendaId', 'ContactId', 'AgendaMeetingId', 'AgendaAgendaNumber', 'AgendaTitle', 'AgendaDescription', 'AgendaAgendaTypeId', 'AgendaRequestedByContactId', 'AgendaImages', 'AgendaAttachments', 'ContactTitle', 'ContactFirstName', 'ContactLastName', 'ContactEmail', 'ContactIdentityNo', 'ContactUserId'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingAgendaRelevantRow = Meeting.MeetingAgendaRelevantRow || (Meeting.MeetingAgendaRelevantRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaRelevantService;
        (function (MeetingAgendaRelevantService) {
            MeetingAgendaRelevantService.baseUrl = 'Meeting/MeetingAgendaRelevant';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingAgendaRelevantService.Methods || (MeetingAgendaRelevantService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingAgendaRelevantService[x] = function (r, s, o) { return Q.serviceRequest(MeetingAgendaRelevantService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingAgendaRelevantService.baseUrl + '/' + x;
            });
        })(MeetingAgendaRelevantService = Meeting.MeetingAgendaRelevantService || (Meeting.MeetingAgendaRelevantService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaRow;
        (function (MeetingAgendaRow) {
            MeetingAgendaRow.idProperty = 'AgendaId';
            MeetingAgendaRow.nameProperty = 'Title';
            MeetingAgendaRow.localTextPrefix = 'Meeting.MeetingAgenda';
            var Fields;
            (function (Fields) {
            })(Fields = MeetingAgendaRow.Fields || (MeetingAgendaRow.Fields = {}));
            ['AgendaId', 'MeetingId', 'AgendaNumber', 'Title', 'Description', 'AgendaTypeId', 'RequestedByContactId', 'Images', 'Attachments', 'MeetingMeetingName', 'MeetingMeetingNumber', 'MeetingMeetingGuid', 'MeetingMeetingTypeId', 'MeetingStartDate', 'MeetingEndDate', 'MeetingLocationId', 'MeetingUnitId', 'MeetingOrganizerContactId', 'MeetingReporterContactId', 'MeetingInsertUserId', 'MeetingInsertDate', 'MeetingUpdateUserId', 'MeetingUpdateDate', 'AgendaTypeName', 'RequestedByContactTitle', 'RequestedByContactFirstName', 'RequestedByContactLastName', 'RequestedByContactFullName', 'RequestedByContactEmail', 'RequestedByContactIdentityNo', 'RequestedByContactUserId'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingAgendaRow = Meeting.MeetingAgendaRow || (Meeting.MeetingAgendaRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaService;
        (function (MeetingAgendaService) {
            MeetingAgendaService.baseUrl = 'Meeting/MeetingAgenda';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingAgendaService.Methods || (MeetingAgendaService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingAgendaService[x] = function (r, s, o) { return Q.serviceRequest(MeetingAgendaService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingAgendaService.baseUrl + '/' + x;
            });
        })(MeetingAgendaService = Meeting.MeetingAgendaService || (Meeting.MeetingAgendaService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaTypeForm = (function (_super) {
            __extends(MeetingAgendaTypeForm, _super);
            function MeetingAgendaTypeForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingAgendaTypeForm;
        }(Serenity.PrefixedContext));
        MeetingAgendaTypeForm.formKey = 'Meeting.MeetingAgendaType';
        Meeting.MeetingAgendaTypeForm = MeetingAgendaTypeForm;
        [['Name', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingAgendaTypeForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaTypeRow;
        (function (MeetingAgendaTypeRow) {
            MeetingAgendaTypeRow.idProperty = 'AgendaTypeId';
            MeetingAgendaTypeRow.nameProperty = 'Name';
            MeetingAgendaTypeRow.localTextPrefix = 'Meeting.MeetingAgendaType';
            MeetingAgendaTypeRow.lookupKey = 'Meeting.MeetingAgendaType';
            function getLookup() {
                return Q.getLookup('Meeting.MeetingAgendaType');
            }
            MeetingAgendaTypeRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = MeetingAgendaTypeRow.Fields || (MeetingAgendaTypeRow.Fields = {}));
            ['AgendaTypeId', 'Name'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingAgendaTypeRow = Meeting.MeetingAgendaTypeRow || (Meeting.MeetingAgendaTypeRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaTypeService;
        (function (MeetingAgendaTypeService) {
            MeetingAgendaTypeService.baseUrl = 'Meeting/MeetingAgendaType';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingAgendaTypeService.Methods || (MeetingAgendaTypeService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingAgendaTypeService[x] = function (r, s, o) { return Q.serviceRequest(MeetingAgendaTypeService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingAgendaTypeService.baseUrl + '/' + x;
            });
        })(MeetingAgendaTypeService = Meeting.MeetingAgendaTypeService || (Meeting.MeetingAgendaTypeService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAttendanceStatus;
        (function (MeetingAttendanceStatus) {
            MeetingAttendanceStatus[MeetingAttendanceStatus["NotSet"] = 0] = "NotSet";
            MeetingAttendanceStatus[MeetingAttendanceStatus["Attended"] = 1] = "Attended";
            MeetingAttendanceStatus[MeetingAttendanceStatus["Absent"] = 2] = "Absent";
            MeetingAttendanceStatus[MeetingAttendanceStatus["AbsentWithPermission"] = 3] = "AbsentWithPermission";
        })(MeetingAttendanceStatus = Meeting.MeetingAttendanceStatus || (Meeting.MeetingAttendanceStatus = {}));
        Serenity.Decorators.registerEnum(MeetingAttendanceStatus, 'Meeting.MeetingAttendanceStatus');
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAttendeeForm = (function (_super) {
            __extends(MeetingAttendeeForm, _super);
            function MeetingAttendeeForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingAttendeeForm;
        }(Serenity.PrefixedContext));
        MeetingAttendeeForm.formKey = 'Meeting.MeetingAttendee';
        Meeting.MeetingAttendeeForm = MeetingAttendeeForm;
        [['MeetingId', function () { return Serenity.IntegerEditor; }], ['ContactId', function () { return Serenity.IntegerEditor; }], ['AttendeeType', function () { return Serenity.EnumEditor; }], ['AttendanceStatus', function () { return Serenity.EnumEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingAttendeeForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAttendeeRow;
        (function (MeetingAttendeeRow) {
            MeetingAttendeeRow.idProperty = 'AttendeeId';
            MeetingAttendeeRow.localTextPrefix = 'Meeting.MeetingAttendee';
            var Fields;
            (function (Fields) {
            })(Fields = MeetingAttendeeRow.Fields || (MeetingAttendeeRow.Fields = {}));
            ['AttendeeId', 'MeetingId', 'ContactId', 'AttendeeType', 'AttendanceStatus', 'MeetingMeetingName', 'MeetingMeetingNumber', 'MeetingMeetingGuid', 'MeetingMeetingTypeId', 'MeetingStartDate', 'MeetingEndDate', 'MeetingLocationId', 'MeetingUnitId', 'MeetingOrganizerContactId', 'MeetingReporterContactId', 'MeetingInsertUserId', 'MeetingInsertDate', 'MeetingUpdateUserId', 'MeetingUpdateDate', 'ContactTitle', 'ContactFirstName', 'ContactLastName', 'ContactFullName', 'ContactEmail', 'ContactIdentityNo', 'ContactUserId'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingAttendeeRow = Meeting.MeetingAttendeeRow || (Meeting.MeetingAttendeeRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAttendeeType;
        (function (MeetingAttendeeType) {
            MeetingAttendeeType[MeetingAttendeeType["Attendee"] = 1] = "Attendee";
            MeetingAttendeeType[MeetingAttendeeType["Guest"] = 2] = "Guest";
        })(MeetingAttendeeType = Meeting.MeetingAttendeeType || (Meeting.MeetingAttendeeType = {}));
        Serenity.Decorators.registerEnum(MeetingAttendeeType, 'Meeting.MeetingAttendeeType');
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionForm = (function (_super) {
            __extends(MeetingDecisionForm, _super);
            function MeetingDecisionForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingDecisionForm;
        }(Serenity.PrefixedContext));
        MeetingDecisionForm.formKey = 'Meeting.MeetingDecision';
        Meeting.MeetingDecisionForm = MeetingDecisionForm;
        [['MeetingId', function () { return Serenity.IntegerEditor; }], ['AgendaId', function () { return Serenity.IntegerEditor; }], ['Description', function () { return Serenity.StringEditor; }], ['DecisionNumber', function () { return Serenity.IntegerEditor; }], ['ResponsibleContactId', function () { return Serenity.IntegerEditor; }], ['DueDate', function () { return Serenity.DateEditor; }], ['ResolutionStatus', function () { return Serenity.IntegerEditor; }], ['Images', function () { return Serenity.StringEditor; }], ['Attachments', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingDecisionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionRelevantForm = (function (_super) {
            __extends(MeetingDecisionRelevantForm, _super);
            function MeetingDecisionRelevantForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingDecisionRelevantForm;
        }(Serenity.PrefixedContext));
        MeetingDecisionRelevantForm.formKey = 'Meeting.MeetingDecisionRelevant';
        Meeting.MeetingDecisionRelevantForm = MeetingDecisionRelevantForm;
        [['DecisionId', function () { return Serenity.IntegerEditor; }], ['ContactId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingDecisionRelevantForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionRelevantRow;
        (function (MeetingDecisionRelevantRow) {
            MeetingDecisionRelevantRow.idProperty = 'DecisionRelevantId';
            MeetingDecisionRelevantRow.localTextPrefix = 'Meeting.MeetingDecisionRelevant';
            var Fields;
            (function (Fields) {
            })(Fields = MeetingDecisionRelevantRow.Fields || (MeetingDecisionRelevantRow.Fields = {}));
            ['DecisionRelevantId', 'DecisionId', 'ContactId', 'DecisionMeetingId', 'DecisionAgendaId', 'DecisionDescription', 'DecisionDecisionNumber', 'DecisionResponsibleContactId', 'DecisionDueDate', 'DecisionResolutionStatus', 'DecisionImages', 'DecisionAttachments', 'ContactTitle', 'ContactFirstName', 'ContactLastName', 'ContactEmail', 'ContactIdentityNo', 'ContactUserId'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingDecisionRelevantRow = Meeting.MeetingDecisionRelevantRow || (Meeting.MeetingDecisionRelevantRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionRelevantService;
        (function (MeetingDecisionRelevantService) {
            MeetingDecisionRelevantService.baseUrl = 'Meeting/MeetingDecisionRelevant';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingDecisionRelevantService.Methods || (MeetingDecisionRelevantService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingDecisionRelevantService[x] = function (r, s, o) { return Q.serviceRequest(MeetingDecisionRelevantService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingDecisionRelevantService.baseUrl + '/' + x;
            });
        })(MeetingDecisionRelevantService = Meeting.MeetingDecisionRelevantService || (Meeting.MeetingDecisionRelevantService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionRow;
        (function (MeetingDecisionRow) {
            MeetingDecisionRow.idProperty = 'DecisionId';
            MeetingDecisionRow.nameProperty = 'Description';
            MeetingDecisionRow.localTextPrefix = 'Meeting.MeetingDecision';
            var Fields;
            (function (Fields) {
            })(Fields = MeetingDecisionRow.Fields || (MeetingDecisionRow.Fields = {}));
            ['DecisionId', 'MeetingId', 'AgendaId', 'Description', 'DecisionNumber', 'ResponsibleContactId', 'DueDate', 'ResolutionStatus', 'Images', 'Attachments', 'MeetingMeetingName', 'MeetingMeetingNumber', 'MeetingMeetingGuid', 'MeetingMeetingTypeId', 'MeetingStartDate', 'MeetingEndDate', 'MeetingLocationId', 'MeetingUnitId', 'MeetingOrganizerContactId', 'MeetingReporterContactId', 'MeetingInsertUserId', 'MeetingInsertDate', 'MeetingUpdateUserId', 'MeetingUpdateDate', 'AgendaMeetingId', 'AgendaNumber', 'AgendaTitle', 'AgendaDescription', 'AgendaAgendaTypeId', 'AgendaRequestedByContactId', 'AgendaImages', 'AgendaAttachments', 'DecisionNumberName', 'ResponsibleContactTitle', 'ResponsibleContactFirstName', 'ResponsibleContactLastName', 'ResponsibleContactFullName', 'ResponsibleContactEmail', 'ResponsibleContactIdentityNo', 'ResponsibleContactUserId'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingDecisionRow = Meeting.MeetingDecisionRow || (Meeting.MeetingDecisionRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionService;
        (function (MeetingDecisionService) {
            MeetingDecisionService.baseUrl = 'Meeting/MeetingDecision';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingDecisionService.Methods || (MeetingDecisionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingDecisionService[x] = function (r, s, o) { return Q.serviceRequest(MeetingDecisionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingDecisionService.baseUrl + '/' + x;
            });
        })(MeetingDecisionService = Meeting.MeetingDecisionService || (Meeting.MeetingDecisionService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingForm = (function (_super) {
            __extends(MeetingForm, _super);
            function MeetingForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingForm;
        }(Serenity.PrefixedContext));
        MeetingForm.formKey = 'Meeting.Meeting';
        Meeting.MeetingForm = MeetingForm;
        [['MeetingName', function () { return Serenity.StringEditor; }], ['MeetingTypeId', function () { return Serenity.LookupEditor; }], ['MeetingNumber', function () { return Serenity.StringEditor; }], ['StartDate', function () { return Serenity.DateTimeEditor; }], ['EndDate', function () { return Serenity.DateTimeEditor; }], ['LocationId', function () { return Serenity.LookupEditor; }], ['UnitId', function () { return Geshotel.Organization.BusinessUnitEditor; }], ['OrganizerContactId', function () { return Serenity.LookupEditor; }], ['ReporterContactId', function () { return Serenity.LookupEditor; }], ['AttendeeList', function () { return Meeting.MeetingAttendeeEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingLocationForm = (function (_super) {
            __extends(MeetingLocationForm, _super);
            function MeetingLocationForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingLocationForm;
        }(Serenity.PrefixedContext));
        MeetingLocationForm.formKey = 'Meeting.MeetingLocation';
        Meeting.MeetingLocationForm = MeetingLocationForm;
        [['Name', function () { return Serenity.StringEditor; }], ['Address', function () { return Serenity.StringEditor; }], ['Latitude', function () { return Serenity.DecimalEditor; }], ['Longitude', function () { return Serenity.DecimalEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingLocationForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingLocationRow;
        (function (MeetingLocationRow) {
            MeetingLocationRow.idProperty = 'LocationId';
            MeetingLocationRow.nameProperty = 'Name';
            MeetingLocationRow.localTextPrefix = 'Meeting.MeetingLocation';
            MeetingLocationRow.lookupKey = 'Meeting.MeetingLocation';
            function getLookup() {
                return Q.getLookup('Meeting.MeetingLocation');
            }
            MeetingLocationRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = MeetingLocationRow.Fields || (MeetingLocationRow.Fields = {}));
            ['LocationId', 'Name', 'Address', 'Latitude', 'Longitude'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingLocationRow = Meeting.MeetingLocationRow || (Meeting.MeetingLocationRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingLocationService;
        (function (MeetingLocationService) {
            MeetingLocationService.baseUrl = 'Meeting/MeetingLocation';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingLocationService.Methods || (MeetingLocationService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingLocationService[x] = function (r, s, o) { return Q.serviceRequest(MeetingLocationService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingLocationService.baseUrl + '/' + x;
            });
        })(MeetingLocationService = Meeting.MeetingLocationService || (Meeting.MeetingLocationService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingRow;
        (function (MeetingRow) {
            MeetingRow.idProperty = 'MeetingId';
            MeetingRow.nameProperty = 'MeetingName';
            MeetingRow.localTextPrefix = 'Meeting.Meeting';
            var Fields;
            (function (Fields) {
            })(Fields = MeetingRow.Fields || (MeetingRow.Fields = {}));
            ['MeetingId', 'MeetingName', 'MeetingNumber', 'MeetingGuid', 'MeetingTypeId', 'StartDate', 'EndDate', 'LocationId', 'UnitId', 'OrganizerContactId', 'ReporterContactId', 'MeetingTypeName', 'LocationName', 'UnitName', 'UnitParentUnitId', 'OrganizerContactTitle', 'OrganizerContactFirstName', 'OrganizerContactLastName', 'OrganizerContactFullName', 'OrganizerContactEmail', 'OrganizerContactIdentityNo', 'OrganizerContactUserId', 'ReporterContactTitle', 'ReporterContactFirstName', 'ReporterContactLastName', 'ReporterContactFullName', 'ReporterContactEmail', 'ReporterContactIdentityNo', 'ReporterContactUserId', 'AttendeeList', 'InsertUserId', 'InsertDate', 'UpdateUserId', 'UpdateDate'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingRow = Meeting.MeetingRow || (Meeting.MeetingRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingService;
        (function (MeetingService) {
            MeetingService.baseUrl = 'Meeting/Meeting';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingService.Methods || (MeetingService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingService[x] = function (r, s, o) { return Q.serviceRequest(MeetingService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingService.baseUrl + '/' + x;
            });
        })(MeetingService = Meeting.MeetingService || (Meeting.MeetingService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingTypeForm = (function (_super) {
            __extends(MeetingTypeForm, _super);
            function MeetingTypeForm() {
                return _super.apply(this, arguments) || this;
            }
            return MeetingTypeForm;
        }(Serenity.PrefixedContext));
        MeetingTypeForm.formKey = 'Meeting.MeetingType';
        Meeting.MeetingTypeForm = MeetingTypeForm;
        [['Name', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(MeetingTypeForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingTypeRow;
        (function (MeetingTypeRow) {
            MeetingTypeRow.idProperty = 'MeetingTypeId';
            MeetingTypeRow.nameProperty = 'Name';
            MeetingTypeRow.localTextPrefix = 'Meeting.MeetingType';
            MeetingTypeRow.lookupKey = 'Meeting.MeetingType';
            function getLookup() {
                return Q.getLookup('Meeting.MeetingType');
            }
            MeetingTypeRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = MeetingTypeRow.Fields || (MeetingTypeRow.Fields = {}));
            ['MeetingTypeId', 'Name'].forEach(function (x) { return Fields[x] = x; });
        })(MeetingTypeRow = Meeting.MeetingTypeRow || (Meeting.MeetingTypeRow = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingTypeService;
        (function (MeetingTypeService) {
            MeetingTypeService.baseUrl = 'Meeting/MeetingType';
            var Methods;
            (function (Methods) {
            })(Methods = MeetingTypeService.Methods || (MeetingTypeService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MeetingTypeService[x] = function (r, s, o) { return Q.serviceRequest(MeetingTypeService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MeetingTypeService.baseUrl + '/' + x;
            });
        })(MeetingTypeService = Meeting.MeetingTypeService || (Meeting.MeetingTypeService = {}));
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var ChangePasswordForm = (function (_super) {
            __extends(ChangePasswordForm, _super);
            function ChangePasswordForm() {
                return _super.apply(this, arguments) || this;
            }
            return ChangePasswordForm;
        }(Serenity.PrefixedContext));
        ChangePasswordForm.formKey = 'Membership.ChangePassword';
        Membership.ChangePasswordForm = ChangePasswordForm;
        [['OldPassword', function () { return Serenity.PasswordEditor; }], ['NewPassword', function () { return Serenity.PasswordEditor; }], ['ConfirmPassword', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(ChangePasswordForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var ForgotPasswordForm = (function (_super) {
            __extends(ForgotPasswordForm, _super);
            function ForgotPasswordForm() {
                return _super.apply(this, arguments) || this;
            }
            return ForgotPasswordForm;
        }(Serenity.PrefixedContext));
        ForgotPasswordForm.formKey = 'Membership.ForgotPassword';
        Membership.ForgotPasswordForm = ForgotPasswordForm;
        [['Email', function () { return Serenity.EmailEditor; }]].forEach(function (x) { return Object.defineProperty(ForgotPasswordForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var LoginForm = (function (_super) {
            __extends(LoginForm, _super);
            function LoginForm() {
                return _super.apply(this, arguments) || this;
            }
            return LoginForm;
        }(Serenity.PrefixedContext));
        LoginForm.formKey = 'Membership.Login';
        Membership.LoginForm = LoginForm;
        [['Username', function () { return Serenity.StringEditor; }], ['Password', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(LoginForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var ResetPasswordForm = (function (_super) {
            __extends(ResetPasswordForm, _super);
            function ResetPasswordForm() {
                return _super.apply(this, arguments) || this;
            }
            return ResetPasswordForm;
        }(Serenity.PrefixedContext));
        ResetPasswordForm.formKey = 'Membership.ResetPassword';
        Membership.ResetPasswordForm = ResetPasswordForm;
        [['NewPassword', function () { return Serenity.PasswordEditor; }], ['ConfirmPassword', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(ResetPasswordForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var SignUpForm = (function (_super) {
            __extends(SignUpForm, _super);
            function SignUpForm() {
                return _super.apply(this, arguments) || this;
            }
            return SignUpForm;
        }(Serenity.PrefixedContext));
        SignUpForm.formKey = 'Membership.SignUp';
        Membership.SignUpForm = SignUpForm;
        [['DisplayName', function () { return Serenity.StringEditor; }], ['Email', function () { return Serenity.EmailEditor; }], ['ConfirmEmail', function () { return Serenity.EmailEditor; }], ['Password', function () { return Serenity.PasswordEditor; }], ['ConfirmPassword', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(SignUpForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CategoryForm = (function (_super) {
            __extends(CategoryForm, _super);
            function CategoryForm() {
                return _super.apply(this, arguments) || this;
            }
            return CategoryForm;
        }(Serenity.PrefixedContext));
        CategoryForm.formKey = 'Northwind.Category';
        Northwind.CategoryForm = CategoryForm;
        [['CategoryName', function () { return Serenity.StringEditor; }], ['Description', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(CategoryForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CategoryLangRow;
        (function (CategoryLangRow) {
            CategoryLangRow.idProperty = 'Id';
            CategoryLangRow.nameProperty = 'CategoryName';
            CategoryLangRow.localTextPrefix = 'Northwind.CategoryLang';
            var Fields;
            (function (Fields) {
            })(Fields = CategoryLangRow.Fields || (CategoryLangRow.Fields = {}));
            ['Id', 'CategoryId', 'LanguageId', 'CategoryName', 'Description'].forEach(function (x) { return Fields[x] = x; });
        })(CategoryLangRow = Northwind.CategoryLangRow || (Northwind.CategoryLangRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CategoryLangService;
        (function (CategoryLangService) {
            CategoryLangService.baseUrl = 'Northwind/CategoryLang';
            var Methods;
            (function (Methods) {
            })(Methods = CategoryLangService.Methods || (CategoryLangService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                CategoryLangService[x] = function (r, s, o) { return Q.serviceRequest(CategoryLangService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = CategoryLangService.baseUrl + '/' + x;
            });
        })(CategoryLangService = Northwind.CategoryLangService || (Northwind.CategoryLangService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CategoryRow;
        (function (CategoryRow) {
            CategoryRow.idProperty = 'CategoryID';
            CategoryRow.nameProperty = 'CategoryName';
            CategoryRow.localTextPrefix = 'Northwind.Category';
            CategoryRow.lookupKey = 'Northwind.Category';
            function getLookup() {
                return Q.getLookup('Northwind.Category');
            }
            CategoryRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = CategoryRow.Fields || (CategoryRow.Fields = {}));
            ['CategoryID', 'CategoryName', 'Description', 'Picture'].forEach(function (x) { return Fields[x] = x; });
        })(CategoryRow = Northwind.CategoryRow || (Northwind.CategoryRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CategoryService;
        (function (CategoryService) {
            CategoryService.baseUrl = 'Northwind/Category';
            var Methods;
            (function (Methods) {
            })(Methods = CategoryService.Methods || (CategoryService.Methods = {}));
            ['Create', 'Update', 'Delete', 'RetrieveLocalization', 'Retrieve', 'List'].forEach(function (x) {
                CategoryService[x] = function (r, s, o) { return Q.serviceRequest(CategoryService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = CategoryService.baseUrl + '/' + x;
            });
        })(CategoryService = Northwind.CategoryService || (Northwind.CategoryService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerCustomerDemoRow;
        (function (CustomerCustomerDemoRow) {
            CustomerCustomerDemoRow.idProperty = 'ID';
            CustomerCustomerDemoRow.nameProperty = 'CustomerID';
            CustomerCustomerDemoRow.localTextPrefix = 'Northwind.CustomerCustomerDemo';
            var Fields;
            (function (Fields) {
            })(Fields = CustomerCustomerDemoRow.Fields || (CustomerCustomerDemoRow.Fields = {}));
            ['ID', 'CustomerID', 'CustomerTypeID', 'CustomerCompanyName', 'CustomerContactName', 'CustomerContactTitle', 'CustomerAddress', 'CustomerCity', 'CustomerRegion', 'CustomerPostalCode', 'CustomerCountry', 'CustomerPhone', 'CustomerFax', 'CustomerTypeCustomerDesc'].forEach(function (x) { return Fields[x] = x; });
        })(CustomerCustomerDemoRow = Northwind.CustomerCustomerDemoRow || (Northwind.CustomerCustomerDemoRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerDemographicRow;
        (function (CustomerDemographicRow) {
            CustomerDemographicRow.idProperty = 'ID';
            CustomerDemographicRow.nameProperty = 'CustomerTypeID';
            CustomerDemographicRow.localTextPrefix = 'Northwind.CustomerDemographic';
            var Fields;
            (function (Fields) {
            })(Fields = CustomerDemographicRow.Fields || (CustomerDemographicRow.Fields = {}));
            ['ID', 'CustomerTypeID', 'CustomerDesc'].forEach(function (x) { return Fields[x] = x; });
        })(CustomerDemographicRow = Northwind.CustomerDemographicRow || (Northwind.CustomerDemographicRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerDetailsRow;
        (function (CustomerDetailsRow) {
            CustomerDetailsRow.idProperty = 'Id';
            CustomerDetailsRow.nameProperty = 'Email';
            CustomerDetailsRow.localTextPrefix = 'Northwind.CustomerDetails';
            var Fields;
            (function (Fields) {
            })(Fields = CustomerDetailsRow.Fields || (CustomerDetailsRow.Fields = {}));
            ['Id', 'LastContactDate', 'LastContactedBy', 'Email', 'SendBulletin', 'LastContactedByLastName', 'LastContactedByFirstName', 'LastContactedByTitle', 'LastContactedByTitleOfCourtesy', 'LastContactedByBirthDate', 'LastContactedByHireDate', 'LastContactedByAddress', 'LastContactedByCity', 'LastContactedByRegion', 'LastContactedByPostalCode', 'LastContactedByCountry', 'LastContactedByHomePhone', 'LastContactedByExtension', 'LastContactedByPhoto', 'LastContactedByNotes', 'LastContactedByReportsTo', 'LastContactedByPhotoPath'].forEach(function (x) { return Fields[x] = x; });
        })(CustomerDetailsRow = Northwind.CustomerDetailsRow || (Northwind.CustomerDetailsRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerForm = (function (_super) {
            __extends(CustomerForm, _super);
            function CustomerForm() {
                return _super.apply(this, arguments) || this;
            }
            return CustomerForm;
        }(Serenity.PrefixedContext));
        CustomerForm.formKey = 'Northwind.Customer';
        Northwind.CustomerForm = CustomerForm;
        [['CustomerID', function () { return Serenity.StringEditor; }], ['CompanyName', function () { return Serenity.StringEditor; }], ['ContactName', function () { return Serenity.StringEditor; }], ['ContactTitle', function () { return Serenity.StringEditor; }], ['Representatives', function () { return Serenity.LookupEditor; }], ['Address', function () { return Serenity.StringEditor; }], ['City', function () { return Serenity.StringEditor; }], ['Region', function () { return Serenity.StringEditor; }], ['PostalCode', function () { return Serenity.StringEditor; }], ['Country', function () { return Serenity.StringEditor; }], ['Phone', function () { return Serenity.StringEditor; }], ['Fax', function () { return Serenity.StringEditor; }], ['NoteList', function () { return Northwind.NotesEditor; }], ['LastContactDate', function () { return Serenity.DateEditor; }], ['LastContactedBy', function () { return Serenity.LookupEditor; }], ['Email', function () { return Serenity.EmailEditor; }], ['SendBulletin', function () { return Serenity.BooleanEditor; }]].forEach(function (x) { return Object.defineProperty(CustomerForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerRepresentativesRow;
        (function (CustomerRepresentativesRow) {
            CustomerRepresentativesRow.idProperty = 'RepresentativeId';
            CustomerRepresentativesRow.localTextPrefix = 'CustomerRepresentatives';
            var Fields;
            (function (Fields) {
            })(Fields = CustomerRepresentativesRow.Fields || (CustomerRepresentativesRow.Fields = {}));
            ['RepresentativeId', 'CustomerId', 'EmployeeId'].forEach(function (x) { return Fields[x] = x; });
        })(CustomerRepresentativesRow = Northwind.CustomerRepresentativesRow || (Northwind.CustomerRepresentativesRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerRow;
        (function (CustomerRow) {
            CustomerRow.idProperty = 'ID';
            CustomerRow.nameProperty = 'CompanyName';
            CustomerRow.localTextPrefix = 'Northwind.Customer';
            CustomerRow.lookupKey = 'Northwind.Customer';
            function getLookup() {
                return Q.getLookup('Northwind.Customer');
            }
            CustomerRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = CustomerRow.Fields || (CustomerRow.Fields = {}));
            ['ID', 'CustomerID', 'CompanyName', 'ContactName', 'ContactTitle', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'Phone', 'Fax', 'NoteList', 'Representatives', 'LastContactDate', 'LastContactedBy', 'Email', 'SendBulletin'].forEach(function (x) { return Fields[x] = x; });
        })(CustomerRow = Northwind.CustomerRow || (Northwind.CustomerRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerService;
        (function (CustomerService) {
            CustomerService.baseUrl = 'Northwind/Customer';
            var Methods;
            (function (Methods) {
            })(Methods = CustomerService.Methods || (CustomerService.Methods = {}));
            ['Create', 'Update', 'Delete', 'GetNextNumber', 'Retrieve', 'List'].forEach(function (x) {
                CustomerService[x] = function (r, s, o) { return Q.serviceRequest(CustomerService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = CustomerService.baseUrl + '/' + x;
            });
        })(CustomerService = Northwind.CustomerService || (Northwind.CustomerService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var EmployeeRow;
        (function (EmployeeRow) {
            EmployeeRow.idProperty = 'EmployeeID';
            EmployeeRow.nameProperty = 'FullName';
            EmployeeRow.localTextPrefix = 'Northwind.Employee';
            EmployeeRow.lookupKey = 'Northwind.Employee';
            function getLookup() {
                return Q.getLookup('Northwind.Employee');
            }
            EmployeeRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = EmployeeRow.Fields || (EmployeeRow.Fields = {}));
            ['EmployeeID', 'LastName', 'FirstName', 'FullName', 'Title', 'TitleOfCourtesy', 'BirthDate', 'HireDate', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'HomePhone', 'Extension', 'Photo', 'Notes', 'ReportsTo', 'PhotoPath', 'ReportsToFullName', 'ReportsToLastName', 'ReportsToFirstName', 'ReportsToTitle', 'ReportsToTitleOfCourtesy', 'ReportsToBirthDate', 'ReportsToHireDate', 'ReportsToAddress', 'ReportsToCity', 'ReportsToRegion', 'ReportsToPostalCode', 'ReportsToCountry', 'ReportsToHomePhone', 'ReportsToExtension', 'ReportsToPhoto', 'ReportsToNotes', 'ReportsToReportsTo', 'ReportsToPhotoPath', 'Gender'].forEach(function (x) { return Fields[x] = x; });
        })(EmployeeRow = Northwind.EmployeeRow || (Northwind.EmployeeRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var EmployeeTerritoryRow;
        (function (EmployeeTerritoryRow) {
            EmployeeTerritoryRow.idProperty = 'EmployeeID';
            EmployeeTerritoryRow.nameProperty = 'TerritoryID';
            EmployeeTerritoryRow.localTextPrefix = 'Northwind.EmployeeTerritory';
            var Fields;
            (function (Fields) {
            })(Fields = EmployeeTerritoryRow.Fields || (EmployeeTerritoryRow.Fields = {}));
            ['EmployeeID', 'TerritoryID', 'EmployeeLastName', 'EmployeeFirstName', 'EmployeeTitle', 'EmployeeTitleOfCourtesy', 'EmployeeBirthDate', 'EmployeeHireDate', 'EmployeeAddress', 'EmployeeCity', 'EmployeeRegion', 'EmployeePostalCode', 'EmployeeCountry', 'EmployeeHomePhone', 'EmployeeExtension', 'EmployeePhoto', 'EmployeeNotes', 'EmployeeReportsTo', 'EmployeePhotoPath', 'TerritoryTerritoryDescription', 'TerritoryRegionID'].forEach(function (x) { return Fields[x] = x; });
        })(EmployeeTerritoryRow = Northwind.EmployeeTerritoryRow || (Northwind.EmployeeTerritoryRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var Gender;
        (function (Gender) {
            Gender[Gender["Male"] = 1] = "Male";
            Gender[Gender["Female"] = 2] = "Female";
        })(Gender = Northwind.Gender || (Northwind.Gender = {}));
        Serenity.Decorators.registerEnum(Gender, 'Geshotel.Northwind.Entities.Gender');
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var NoteRow;
        (function (NoteRow) {
            NoteRow.idProperty = 'NoteId';
            NoteRow.nameProperty = 'EntityType';
            NoteRow.localTextPrefix = 'Northwind.Note';
            var Fields;
            (function (Fields) {
            })(Fields = NoteRow.Fields || (NoteRow.Fields = {}));
            ['NoteId', 'EntityType', 'EntityId', 'Text', 'InsertUserId', 'InsertDate', 'InsertUserDisplayName'].forEach(function (x) { return Fields[x] = x; });
        })(NoteRow = Northwind.NoteRow || (Northwind.NoteRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailForm = (function (_super) {
            __extends(OrderDetailForm, _super);
            function OrderDetailForm() {
                return _super.apply(this, arguments) || this;
            }
            return OrderDetailForm;
        }(Serenity.PrefixedContext));
        OrderDetailForm.formKey = 'Northwind.OrderDetail';
        Northwind.OrderDetailForm = OrderDetailForm;
        [['ProductID', function () { return Serenity.LookupEditor; }], ['UnitPrice', function () { return Serenity.DecimalEditor; }], ['Quantity', function () { return Serenity.IntegerEditor; }], ['Discount', function () { return Serenity.DecimalEditor; }]].forEach(function (x) { return Object.defineProperty(OrderDetailForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailRow;
        (function (OrderDetailRow) {
            OrderDetailRow.idProperty = 'DetailID';
            OrderDetailRow.localTextPrefix = 'Northwind.OrderDetail';
            var Fields;
            (function (Fields) {
            })(Fields = OrderDetailRow.Fields || (OrderDetailRow.Fields = {}));
            ['DetailID', 'OrderID', 'ProductID', 'UnitPrice', 'Quantity', 'Discount', 'OrderCustomerID', 'OrderEmployeeID', 'OrderDate', 'OrderShippedDate', 'OrderShipVia', 'OrderShipCity', 'OrderShipCountry', 'ProductName', 'ProductDiscontinued', 'ProductSupplierID', 'ProductQuantityPerUnit', 'ProductUnitPrice', 'LineTotal'].forEach(function (x) { return Fields[x] = x; });
        })(OrderDetailRow = Northwind.OrderDetailRow || (Northwind.OrderDetailRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailService;
        (function (OrderDetailService) {
            OrderDetailService.baseUrl = 'Northwind/OrderDetail';
            var Methods;
            (function (Methods) {
            })(Methods = OrderDetailService.Methods || (OrderDetailService.Methods = {}));
            ['Retrieve', 'List'].forEach(function (x) {
                OrderDetailService[x] = function (r, s, o) { return Q.serviceRequest(OrderDetailService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = OrderDetailService.baseUrl + '/' + x;
            });
        })(OrderDetailService = Northwind.OrderDetailService || (Northwind.OrderDetailService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderForm = (function (_super) {
            __extends(OrderForm, _super);
            function OrderForm() {
                return _super.apply(this, arguments) || this;
            }
            return OrderForm;
        }(Serenity.PrefixedContext));
        OrderForm.formKey = 'Northwind.Order';
        Northwind.OrderForm = OrderForm;
        [['CustomerID', function () { return Northwind.CustomerEditor; }], ['OrderDate', function () { return Serenity.DateEditor; }], ['RequiredDate', function () { return Serenity.DateEditor; }], ['EmployeeID', function () { return Serenity.LookupEditor; }], ['DetailList', function () { return Northwind.OrderDetailsEditor; }], ['ShippedDate', function () { return Serenity.DateEditor; }], ['ShipVia', function () { return Serenity.LookupEditor; }], ['Freight', function () { return Serenity.DecimalEditor; }], ['ShipName', function () { return Serenity.StringEditor; }], ['ShipAddress', function () { return Serenity.StringEditor; }], ['ShipCity', function () { return Serenity.StringEditor; }], ['ShipRegion', function () { return Serenity.StringEditor; }], ['ShipPostalCode', function () { return Serenity.StringEditor; }], ['ShipCountry', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(OrderForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderRow;
        (function (OrderRow) {
            OrderRow.idProperty = 'OrderID';
            OrderRow.nameProperty = 'CustomerID';
            OrderRow.localTextPrefix = 'Northwind.Order';
            OrderRow.lookupKey = 'Northwind.OrderShipCity';
            function getLookup() {
                return Q.getLookup('Northwind.OrderShipCity');
            }
            OrderRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = OrderRow.Fields || (OrderRow.Fields = {}));
            ['OrderID', 'CustomerID', 'EmployeeID', 'OrderDate', 'RequiredDate', 'ShippedDate', 'ShipVia', 'Freight', 'ShipName', 'ShipAddress', 'ShipCity', 'ShipRegion', 'ShipPostalCode', 'ShipCountry', 'CustomerCompanyName', 'CustomerContactName', 'CustomerContactTitle', 'CustomerCity', 'CustomerRegion', 'CustomerCountry', 'CustomerPhone', 'CustomerFax', 'EmployeeFullName', 'EmployeeGender', 'ShipViaCompanyName', 'ShipViaPhone', 'ShippingState', 'DetailList'].forEach(function (x) { return Fields[x] = x; });
        })(OrderRow = Northwind.OrderRow || (Northwind.OrderRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderService;
        (function (OrderService) {
            OrderService.baseUrl = 'Northwind/Order';
            var Methods;
            (function (Methods) {
            })(Methods = OrderService.Methods || (OrderService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                OrderService[x] = function (r, s, o) { return Q.serviceRequest(OrderService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = OrderService.baseUrl + '/' + x;
            });
        })(OrderService = Northwind.OrderService || (Northwind.OrderService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderShippingState;
        (function (OrderShippingState) {
            OrderShippingState[OrderShippingState["NotShipped"] = 0] = "NotShipped";
            OrderShippingState[OrderShippingState["Shipped"] = 1] = "Shipped";
        })(OrderShippingState = Northwind.OrderShippingState || (Northwind.OrderShippingState = {}));
        Serenity.Decorators.registerEnum(OrderShippingState, 'Northwind.OrderShippingState');
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductForm = (function (_super) {
            __extends(ProductForm, _super);
            function ProductForm() {
                return _super.apply(this, arguments) || this;
            }
            return ProductForm;
        }(Serenity.PrefixedContext));
        ProductForm.formKey = 'Northwind.Product';
        Northwind.ProductForm = ProductForm;
        [['ProductName', function () { return Serenity.StringEditor; }], ['ProductImage', function () { return Serenity.ImageUploadEditor; }], ['Discontinued', function () { return Serenity.BooleanEditor; }], ['SupplierID', function () { return Serenity.LookupEditor; }], ['CategoryID', function () { return Serenity.LookupEditor; }], ['QuantityPerUnit', function () { return Serenity.StringEditor; }], ['UnitPrice', function () { return Serenity.DecimalEditor; }], ['UnitsInStock', function () { return Serenity.IntegerEditor; }], ['UnitsOnOrder', function () { return Serenity.IntegerEditor; }], ['ReorderLevel', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(ProductForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductLangRow;
        (function (ProductLangRow) {
            ProductLangRow.idProperty = 'Id';
            ProductLangRow.nameProperty = 'ProductName';
            ProductLangRow.localTextPrefix = 'Northwind.ProductLang';
            var Fields;
            (function (Fields) {
            })(Fields = ProductLangRow.Fields || (ProductLangRow.Fields = {}));
            ['Id', 'ProductId', 'LanguageId', 'ProductName'].forEach(function (x) { return Fields[x] = x; });
        })(ProductLangRow = Northwind.ProductLangRow || (Northwind.ProductLangRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductLangService;
        (function (ProductLangService) {
            ProductLangService.baseUrl = 'Northwind/ProductLang';
            var Methods;
            (function (Methods) {
            })(Methods = ProductLangService.Methods || (ProductLangService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ProductLangService[x] = function (r, s, o) { return Q.serviceRequest(ProductLangService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ProductLangService.baseUrl + '/' + x;
            });
        })(ProductLangService = Northwind.ProductLangService || (Northwind.ProductLangService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductLogRow;
        (function (ProductLogRow) {
            ProductLogRow.idProperty = 'ProductLogID';
            ProductLogRow.localTextPrefix = 'Northwind.ProductLog';
            var Fields;
            (function (Fields) {
            })(Fields = ProductLogRow.Fields || (ProductLogRow.Fields = {}));
            ['ProductLogID', 'OperationType', 'ChangingUserId', 'ValidFrom', 'ValidUntil', 'ProductID', 'ProductName', 'ProductImage', 'Discontinued', 'SupplierID', 'CategoryID', 'QuantityPerUnit', 'UnitPrice', 'UnitsInStock', 'UnitsOnOrder', 'ReorderLevel'].forEach(function (x) { return Fields[x] = x; });
        })(ProductLogRow = Northwind.ProductLogRow || (Northwind.ProductLogRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductRow;
        (function (ProductRow) {
            ProductRow.idProperty = 'ProductID';
            ProductRow.nameProperty = 'ProductName';
            ProductRow.localTextPrefix = 'Northwind.Product';
            ProductRow.lookupKey = 'Northwind.Product';
            function getLookup() {
                return Q.getLookup('Northwind.Product');
            }
            ProductRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ProductRow.Fields || (ProductRow.Fields = {}));
            ['ProductID', 'ProductName', 'ProductImage', 'Discontinued', 'SupplierID', 'CategoryID', 'QuantityPerUnit', 'UnitPrice', 'UnitsInStock', 'UnitsOnOrder', 'ReorderLevel', 'SupplierCompanyName', 'SupplierContactName', 'SupplierContactTitle', 'SupplierAddress', 'SupplierCity', 'SupplierRegion', 'SupplierPostalCode', 'SupplierCountry', 'SupplierPhone', 'SupplierFax', 'SupplierHomePage', 'CategoryName', 'CategoryDescription', 'CategoryPicture'].forEach(function (x) { return Fields[x] = x; });
        })(ProductRow = Northwind.ProductRow || (Northwind.ProductRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductService;
        (function (ProductService) {
            ProductService.baseUrl = 'Northwind/Product';
            var Methods;
            (function (Methods) {
            })(Methods = ProductService.Methods || (ProductService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'RetrieveLocalization', 'List'].forEach(function (x) {
                ProductService[x] = function (r, s, o) { return Q.serviceRequest(ProductService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ProductService.baseUrl + '/' + x;
            });
        })(ProductService = Northwind.ProductService || (Northwind.ProductService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var RegionForm = (function (_super) {
            __extends(RegionForm, _super);
            function RegionForm() {
                return _super.apply(this, arguments) || this;
            }
            return RegionForm;
        }(Serenity.PrefixedContext));
        RegionForm.formKey = 'Northwind.Region';
        Northwind.RegionForm = RegionForm;
        [['RegionID', function () { return Serenity.IntegerEditor; }], ['RegionDescription', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(RegionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var RegionRow;
        (function (RegionRow) {
            RegionRow.idProperty = 'RegionID';
            RegionRow.nameProperty = 'RegionDescription';
            RegionRow.localTextPrefix = 'Northwind.Region';
            RegionRow.lookupKey = 'Northwind.Region';
            function getLookup() {
                return Q.getLookup('Northwind.Region');
            }
            RegionRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = RegionRow.Fields || (RegionRow.Fields = {}));
            ['RegionID', 'RegionDescription'].forEach(function (x) { return Fields[x] = x; });
        })(RegionRow = Northwind.RegionRow || (Northwind.RegionRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var RegionService;
        (function (RegionService) {
            RegionService.baseUrl = 'Northwind/Region';
            var Methods;
            (function (Methods) {
            })(Methods = RegionService.Methods || (RegionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                RegionService[x] = function (r, s, o) { return Q.serviceRequest(RegionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = RegionService.baseUrl + '/' + x;
            });
        })(RegionService = Northwind.RegionService || (Northwind.RegionService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var SalesByCategoryRow;
        (function (SalesByCategoryRow) {
            SalesByCategoryRow.nameProperty = 'CategoryName';
            SalesByCategoryRow.localTextPrefix = 'Northwind.SalesByCategory';
            var Fields;
            (function (Fields) {
            })(Fields = SalesByCategoryRow.Fields || (SalesByCategoryRow.Fields = {}));
            ['CategoryId', 'CategoryName', 'ProductName', 'ProductSales'].forEach(function (x) { return Fields[x] = x; });
        })(SalesByCategoryRow = Northwind.SalesByCategoryRow || (Northwind.SalesByCategoryRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var SalesByCategoryService;
        (function (SalesByCategoryService) {
            SalesByCategoryService.baseUrl = 'Northwind/SalesByCategory';
            var Methods;
            (function (Methods) {
            })(Methods = SalesByCategoryService.Methods || (SalesByCategoryService.Methods = {}));
            ['List'].forEach(function (x) {
                SalesByCategoryService[x] = function (r, s, o) { return Q.serviceRequest(SalesByCategoryService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = SalesByCategoryService.baseUrl + '/' + x;
            });
        })(SalesByCategoryService = Northwind.SalesByCategoryService || (Northwind.SalesByCategoryService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ShipperForm = (function (_super) {
            __extends(ShipperForm, _super);
            function ShipperForm() {
                return _super.apply(this, arguments) || this;
            }
            return ShipperForm;
        }(Serenity.PrefixedContext));
        ShipperForm.formKey = 'Northwind.Shipper';
        Northwind.ShipperForm = ShipperForm;
        [['CompanyName', function () { return Serenity.StringEditor; }], ['Phone', function () { return Northwind.PhoneEditor; }]].forEach(function (x) { return Object.defineProperty(ShipperForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ShipperRow;
        (function (ShipperRow) {
            ShipperRow.idProperty = 'ShipperID';
            ShipperRow.nameProperty = 'CompanyName';
            ShipperRow.localTextPrefix = 'Northwind.Shipper';
            ShipperRow.lookupKey = 'Northwind.Shipper';
            function getLookup() {
                return Q.getLookup('Northwind.Shipper');
            }
            ShipperRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ShipperRow.Fields || (ShipperRow.Fields = {}));
            ['ShipperID', 'CompanyName', 'Phone'].forEach(function (x) { return Fields[x] = x; });
        })(ShipperRow = Northwind.ShipperRow || (Northwind.ShipperRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ShipperService;
        (function (ShipperService) {
            ShipperService.baseUrl = 'Northwind/Shipper';
            var Methods;
            (function (Methods) {
            })(Methods = ShipperService.Methods || (ShipperService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ShipperService[x] = function (r, s, o) { return Q.serviceRequest(ShipperService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ShipperService.baseUrl + '/' + x;
            });
        })(ShipperService = Northwind.ShipperService || (Northwind.ShipperService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var SupplierForm = (function (_super) {
            __extends(SupplierForm, _super);
            function SupplierForm() {
                return _super.apply(this, arguments) || this;
            }
            return SupplierForm;
        }(Serenity.PrefixedContext));
        SupplierForm.formKey = 'Northwind.Supplier';
        Northwind.SupplierForm = SupplierForm;
        [['CompanyName', function () { return Serenity.StringEditor; }], ['ContactName', function () { return Serenity.StringEditor; }], ['ContactTitle', function () { return Serenity.StringEditor; }], ['Address', function () { return Serenity.StringEditor; }], ['Region', function () { return Serenity.StringEditor; }], ['PostalCode', function () { return Serenity.StringEditor; }], ['Country', function () { return Serenity.StringEditor; }], ['City', function () { return Serenity.StringEditor; }], ['Phone', function () { return Serenity.StringEditor; }], ['Fax', function () { return Serenity.StringEditor; }], ['HomePage', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(SupplierForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var SupplierRow;
        (function (SupplierRow) {
            SupplierRow.idProperty = 'SupplierID';
            SupplierRow.nameProperty = 'CompanyName';
            SupplierRow.localTextPrefix = 'Northwind.Supplier';
            SupplierRow.lookupKey = 'Northwind.Supplier';
            function getLookup() {
                return Q.getLookup('Northwind.Supplier');
            }
            SupplierRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = SupplierRow.Fields || (SupplierRow.Fields = {}));
            ['SupplierID', 'CompanyName', 'ContactName', 'ContactTitle', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'Phone', 'Fax', 'HomePage'].forEach(function (x) { return Fields[x] = x; });
        })(SupplierRow = Northwind.SupplierRow || (Northwind.SupplierRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var SupplierService;
        (function (SupplierService) {
            SupplierService.baseUrl = 'Northwind/Supplier';
            var Methods;
            (function (Methods) {
            })(Methods = SupplierService.Methods || (SupplierService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                SupplierService[x] = function (r, s, o) { return Q.serviceRequest(SupplierService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = SupplierService.baseUrl + '/' + x;
            });
        })(SupplierService = Northwind.SupplierService || (Northwind.SupplierService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var TerritoryForm = (function (_super) {
            __extends(TerritoryForm, _super);
            function TerritoryForm() {
                return _super.apply(this, arguments) || this;
            }
            return TerritoryForm;
        }(Serenity.PrefixedContext));
        TerritoryForm.formKey = 'Northwind.Territory';
        Northwind.TerritoryForm = TerritoryForm;
        [['TerritoryID', function () { return Serenity.StringEditor; }], ['TerritoryDescription', function () { return Serenity.StringEditor; }], ['RegionID', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(TerritoryForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var TerritoryRow;
        (function (TerritoryRow) {
            TerritoryRow.idProperty = 'ID';
            TerritoryRow.nameProperty = 'TerritoryID';
            TerritoryRow.localTextPrefix = 'Northwind.Territory';
            TerritoryRow.lookupKey = 'Northwind.Territory';
            function getLookup() {
                return Q.getLookup('Northwind.Territory');
            }
            TerritoryRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TerritoryRow.Fields || (TerritoryRow.Fields = {}));
            ['ID', 'TerritoryID', 'TerritoryDescription', 'RegionID', 'RegionDescription'].forEach(function (x) { return Fields[x] = x; });
        })(TerritoryRow = Northwind.TerritoryRow || (Northwind.TerritoryRow = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var TerritoryService;
        (function (TerritoryService) {
            TerritoryService.baseUrl = 'Northwind/Territory';
            var Methods;
            (function (Methods) {
            })(Methods = TerritoryService.Methods || (TerritoryService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TerritoryService[x] = function (r, s, o) { return Q.serviceRequest(TerritoryService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TerritoryService.baseUrl + '/' + x;
            });
        })(TerritoryService = Northwind.TerritoryService || (Northwind.TerritoryService = {}));
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var BusinessUnitForm = (function (_super) {
            __extends(BusinessUnitForm, _super);
            function BusinessUnitForm() {
                return _super.apply(this, arguments) || this;
            }
            return BusinessUnitForm;
        }(Serenity.PrefixedContext));
        BusinessUnitForm.formKey = 'Organization.BusinessUnit';
        Organization.BusinessUnitForm = BusinessUnitForm;
        [['Name', function () { return Serenity.StringEditor; }], ['ParentUnitId', function () { return Organization.BusinessUnitEditor; }]].forEach(function (x) { return Object.defineProperty(BusinessUnitForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var BusinessUnitRow;
        (function (BusinessUnitRow) {
            BusinessUnitRow.idProperty = 'UnitId';
            BusinessUnitRow.nameProperty = 'Name';
            BusinessUnitRow.localTextPrefix = 'Organization.BusinessUnit';
            BusinessUnitRow.lookupKey = 'Organization.BusinessUnit';
            function getLookup() {
                return Q.getLookup('Organization.BusinessUnit');
            }
            BusinessUnitRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = BusinessUnitRow.Fields || (BusinessUnitRow.Fields = {}));
            ['UnitId', 'Name', 'ParentUnitId', 'ParentUnitName', 'ParentUnitParentUnitId'].forEach(function (x) { return Fields[x] = x; });
        })(BusinessUnitRow = Organization.BusinessUnitRow || (Organization.BusinessUnitRow = {}));
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var BusinessUnitService;
        (function (BusinessUnitService) {
            BusinessUnitService.baseUrl = 'Organization/BusinessUnit';
            var Methods;
            (function (Methods) {
            })(Methods = BusinessUnitService.Methods || (BusinessUnitService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                BusinessUnitService[x] = function (r, s, o) { return Q.serviceRequest(BusinessUnitService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = BusinessUnitService.baseUrl + '/' + x;
            });
        })(BusinessUnitService = Organization.BusinessUnitService || (Organization.BusinessUnitService = {}));
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var ContactForm = (function (_super) {
            __extends(ContactForm, _super);
            function ContactForm() {
                return _super.apply(this, arguments) || this;
            }
            return ContactForm;
        }(Serenity.PrefixedContext));
        ContactForm.formKey = 'Organization.Contact';
        Organization.ContactForm = ContactForm;
        [['Title', function () { return Serenity.StringEditor; }], ['FirstName', function () { return Serenity.StringEditor; }], ['LastName', function () { return Serenity.StringEditor; }], ['Email', function () { return Serenity.EmailEditor; }], ['IdentityNo', function () { return Serenity.StringEditor; }], ['UserId', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(ContactForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var ContactRow;
        (function (ContactRow) {
            ContactRow.idProperty = 'ContactId';
            ContactRow.nameProperty = 'FullName';
            ContactRow.localTextPrefix = 'Organization.Contact';
            ContactRow.lookupKey = 'Organization.Contact';
            function getLookup() {
                return Q.getLookup('Organization.Contact');
            }
            ContactRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ContactRow.Fields || (ContactRow.Fields = {}));
            ['ContactId', 'Title', 'FirstName', 'LastName', 'FullName', 'Email', 'IdentityNo', 'UserId', 'Username', 'UserDisplayName', 'UserEmail', 'UserSource', 'UserPasswordHash', 'UserPasswordSalt', 'UserLastDirectoryUpdate', 'UserUserImage', 'UserInsertDate', 'UserInsertUserId', 'UserUpdateDate', 'UserUpdateUserId', 'UserIsActive'].forEach(function (x) { return Fields[x] = x; });
        })(ContactRow = Organization.ContactRow || (Organization.ContactRow = {}));
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var ContactService;
        (function (ContactService) {
            ContactService.baseUrl = 'Organization/Contact';
            var Methods;
            (function (Methods) {
            })(Methods = ContactService.Methods || (ContactService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ContactService[x] = function (r, s, o) { return Q.serviceRequest(ContactService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ContactService.baseUrl + '/' + x;
            });
        })(ContactService = Organization.ContactService || (Organization.ContactService = {}));
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var AmbitoOfertaForm = (function (_super) {
            __extends(AmbitoOfertaForm, _super);
            function AmbitoOfertaForm() {
                return _super.apply(this, arguments) || this;
            }
            return AmbitoOfertaForm;
        }(Serenity.PrefixedContext));
        AmbitoOfertaForm.formKey = 'Portal.AmbitoOferta';
        Portal.AmbitoOfertaForm = AmbitoOfertaForm;
        [['AmbitoOfertaId', function () { return Serenity.IntegerEditor; }], ['Nombre', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(AmbitoOfertaForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var AmbitoOfertaRow;
        (function (AmbitoOfertaRow) {
            AmbitoOfertaRow.idProperty = 'AmbitoOfertaId';
            AmbitoOfertaRow.nameProperty = 'Nombre';
            AmbitoOfertaRow.localTextPrefix = 'Portal.AmbitoOferta';
            var Fields;
            (function (Fields) {
            })(Fields = AmbitoOfertaRow.Fields || (AmbitoOfertaRow.Fields = {}));
            ['AmbitoOfertaId', 'Nombre'].forEach(function (x) { return Fields[x] = x; });
        })(AmbitoOfertaRow = Portal.AmbitoOfertaRow || (Portal.AmbitoOfertaRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var AmbitoOfertaService;
        (function (AmbitoOfertaService) {
            AmbitoOfertaService.baseUrl = 'Portal/AmbitoOferta';
            var Methods;
            (function (Methods) {
            })(Methods = AmbitoOfertaService.Methods || (AmbitoOfertaService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                AmbitoOfertaService[x] = function (r, s, o) { return Q.serviceRequest(AmbitoOfertaService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = AmbitoOfertaService.baseUrl + '/' + x;
            });
        })(AmbitoOfertaService = Portal.AmbitoOfertaService || (Portal.AmbitoOfertaService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var CategoriaHotelesForm = (function (_super) {
            __extends(CategoriaHotelesForm, _super);
            function CategoriaHotelesForm() {
                return _super.apply(this, arguments) || this;
            }
            return CategoriaHotelesForm;
        }(Serenity.PrefixedContext));
        CategoriaHotelesForm.formKey = 'Portal.CategoriaHoteles';
        Portal.CategoriaHotelesForm = CategoriaHotelesForm;
        [['Abreviatura', function () { return Serenity.StringEditor; }], ['Categoria', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(CategoriaHotelesForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var CategoriaHotelesRow;
        (function (CategoriaHotelesRow) {
            CategoriaHotelesRow.idProperty = 'CategoriaId';
            CategoriaHotelesRow.nameProperty = 'Categoria';
            CategoriaHotelesRow.localTextPrefix = 'Portal.CategoriaHoteles';
            CategoriaHotelesRow.lookupKey = 'Portal.CategoriaHoteles';
            function getLookup() {
                return Q.getLookup('Portal.CategoriaHoteles');
            }
            CategoriaHotelesRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = CategoriaHotelesRow.Fields || (CategoriaHotelesRow.Fields = {}));
            ['CategoriaId', 'Abreviatura', 'Categoria'].forEach(function (x) { return Fields[x] = x; });
        })(CategoriaHotelesRow = Portal.CategoriaHotelesRow || (Portal.CategoriaHotelesRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var CategoriaHotelesService;
        (function (CategoriaHotelesService) {
            CategoriaHotelesService.baseUrl = 'Portal/CategoriaHoteles';
            var Methods;
            (function (Methods) {
            })(Methods = CategoriaHotelesService.Methods || (CategoriaHotelesService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                CategoriaHotelesService[x] = function (r, s, o) { return Q.serviceRequest(CategoriaHotelesService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = CategoriaHotelesService.baseUrl + '/' + x;
            });
        })(CategoriaHotelesService = Portal.CategoriaHotelesService || (Portal.CategoriaHotelesService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ComunidadesAutonomasForm = (function (_super) {
            __extends(ComunidadesAutonomasForm, _super);
            function ComunidadesAutonomasForm() {
                return _super.apply(this, arguments) || this;
            }
            return ComunidadesAutonomasForm;
        }(Serenity.PrefixedContext));
        ComunidadesAutonomasForm.formKey = 'Portal.ComunidadesAutonomas';
        Portal.ComunidadesAutonomasForm = ComunidadesAutonomasForm;
        [['ComunidadAutonoma', function () { return Serenity.StringEditor; }], ['NacionId', function () { return Serenity.LookupEditor; }], ['ComunidadAutonomaIsta', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(ComunidadesAutonomasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ComunidadesAutonomasRow;
        (function (ComunidadesAutonomasRow) {
            ComunidadesAutonomasRow.idProperty = 'ComunidadId';
            ComunidadesAutonomasRow.nameProperty = 'ComunidadAutonoma';
            ComunidadesAutonomasRow.localTextPrefix = 'Portal.ComunidadesAutonomas';
            ComunidadesAutonomasRow.lookupKey = 'Portal.ComunidadesAutonomas';
            function getLookup() {
                return Q.getLookup('Portal.ComunidadesAutonomas');
            }
            ComunidadesAutonomasRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ComunidadesAutonomasRow.Fields || (ComunidadesAutonomasRow.Fields = {}));
            ['ComunidadId', 'NacionId', 'ComunidadAutonoma', 'ComunidadAutonomaIsta', 'Nacion', 'NacionDescCorta', 'NacionMonedaId', 'NacionIdiomaId', 'NacionNumeroIne', 'NacionPaisIsta', 'NacionDefecto', 'NacionNombreReal', 'NacionIdiomaMails'].forEach(function (x) { return Fields[x] = x; });
        })(ComunidadesAutonomasRow = Portal.ComunidadesAutonomasRow || (Portal.ComunidadesAutonomasRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ComunidadesAutonomasService;
        (function (ComunidadesAutonomasService) {
            ComunidadesAutonomasService.baseUrl = 'Portal/ComunidadesAutonomas';
            var Methods;
            (function (Methods) {
            })(Methods = ComunidadesAutonomasService.Methods || (ComunidadesAutonomasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ComunidadesAutonomasService[x] = function (r, s, o) { return Q.serviceRequest(ComunidadesAutonomasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ComunidadesAutonomasService.baseUrl + '/' + x;
            });
        })(ComunidadesAutonomasService = Portal.ComunidadesAutonomasService || (Portal.ComunidadesAutonomasService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ConceptosAceleradorReservasRow;
        (function (ConceptosAceleradorReservasRow) {
            ConceptosAceleradorReservasRow.idProperty = 'ConceptoAceleradorId';
            ConceptosAceleradorReservasRow.nameProperty = 'Concepto';
            ConceptosAceleradorReservasRow.localTextPrefix = 'Portal.ConceptosAceleradorReservas';
            ConceptosAceleradorReservasRow.lookupKey = 'Portal.ConceptosAceleradorReservas';
            function getLookup() {
                return Q.getLookup('Portal.ConceptosAceleradorReservas');
            }
            ConceptosAceleradorReservasRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ConceptosAceleradorReservasRow.Fields || (ConceptosAceleradorReservasRow.Fields = {}));
            ['ConceptoAceleradorId', 'Concepto'].forEach(function (x) { return Fields[x] = x; });
        })(ConceptosAceleradorReservasRow = Portal.ConceptosAceleradorReservasRow || (Portal.ConceptosAceleradorReservasRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var EmpresasForm = (function (_super) {
            __extends(EmpresasForm, _super);
            function EmpresasForm() {
                return _super.apply(this, arguments) || this;
            }
            return EmpresasForm;
        }(Serenity.PrefixedContext));
        EmpresasForm.formKey = 'Portal.Empresas';
        Portal.EmpresasForm = EmpresasForm;
        [['Empresa', function () { return Serenity.StringEditor; }], ['EmpresaContable', function () { return Serenity.StringEditor; }], ['Direccion', function () { return Serenity.StringEditor; }], ['Poblacion', function () { return Serenity.StringEditor; }], ['Zip', function () { return Serenity.StringEditor; }], ['ProvinciaId', function () { return Serenity.LookupEditor; }], ['Telefono', function () { return Serenity.StringEditor; }], ['Fax', function () { return Serenity.StringEditor; }], ['Cif', function () { return Serenity.StringEditor; }], ['RutaFicheros', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(EmpresasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var EmpresasRow;
        (function (EmpresasRow) {
            EmpresasRow.idProperty = 'EmpresaId';
            EmpresasRow.nameProperty = 'Empresa';
            EmpresasRow.localTextPrefix = 'Portal.Empresas';
            EmpresasRow.lookupKey = 'Portal.Empresas';
            function getLookup() {
                return Q.getLookup('Portal.Empresas');
            }
            EmpresasRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = EmpresasRow.Fields || (EmpresasRow.Fields = {}));
            ['EmpresaId', 'Empresa', 'EmpresaContable', 'Direccion', 'Poblacion', 'Zip', 'ProvinciaId', 'Telefono', 'Fax', 'Cif', 'RutaFicheros', 'Provincia', 'ProvinciaComunidadAutonomaId', 'ProvinciaNacionId', 'ProvinciaProvinciaIsta', 'ProvinciaDefectoIsta'].forEach(function (x) { return Fields[x] = x; });
        })(EmpresasRow = Portal.EmpresasRow || (Portal.EmpresasRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var EmpresasService;
        (function (EmpresasService) {
            EmpresasService.baseUrl = 'Portal/Empresas';
            var Methods;
            (function (Methods) {
            })(Methods = EmpresasService.Methods || (EmpresasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                EmpresasService[x] = function (r, s, o) { return Q.serviceRequest(EmpresasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = EmpresasService.baseUrl + '/' + x;
            });
        })(EmpresasService = Portal.EmpresasService || (Portal.EmpresasService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var EstadosFacturasRow;
        (function (EstadosFacturasRow) {
            EstadosFacturasRow.idProperty = 'EstadoFacturaId';
            EstadosFacturasRow.nameProperty = 'Descripcion';
            EstadosFacturasRow.localTextPrefix = 'Portal.EstadosFacturas';
            EstadosFacturasRow.lookupKey = 'Portal.EstadosFactura';
            function getLookup() {
                return Q.getLookup('Portal.EstadosFactura');
            }
            EstadosFacturasRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = EstadosFacturasRow.Fields || (EstadosFacturasRow.Fields = {}));
            ['EstadoFacturaId', 'Descripcion', 'EsError'].forEach(function (x) { return Fields[x] = x; });
        })(EstadosFacturasRow = Portal.EstadosFacturasRow || (Portal.EstadosFacturasRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FormasDePagoForm = (function (_super) {
            __extends(FormasDePagoForm, _super);
            function FormasDePagoForm() {
                return _super.apply(this, arguments) || this;
            }
            return FormasDePagoForm;
        }(Serenity.PrefixedContext));
        FormasDePagoForm.formKey = 'Portal.FormasDePago';
        Portal.FormasDePagoForm = FormasDePagoForm;
        [['FormaPago', function () { return Serenity.StringEditor; }], ['Credito', function () { return Serenity.BooleanEditor; }], ['SwEfectivo', function () { return Serenity.BooleanEditor; }], ['SwTarjeta', function () { return Serenity.BooleanEditor; }], ['TarjetaLength', function () { return Serenity.StringEditor; }], ['TarjetaPrefixes', function () { return Serenity.StringEditor; }], ['TarjetaCheckdigit', function () { return Serenity.BooleanEditor; }], ['SwDingus', function () { return Serenity.BooleanEditor; }], ['ProduccionTpv', function () { return Serenity.BooleanEditor; }]].forEach(function (x) { return Object.defineProperty(FormasDePagoForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FormasDePagoRow;
        (function (FormasDePagoRow) {
            FormasDePagoRow.idProperty = 'FormaPagoId';
            FormasDePagoRow.nameProperty = 'FormaPago';
            FormasDePagoRow.localTextPrefix = 'Portal.FormasDePago';
            FormasDePagoRow.lookupKey = 'Portal.FromasDePago';
            function getLookup() {
                return Q.getLookup('Portal.FromasDePago');
            }
            FormasDePagoRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = FormasDePagoRow.Fields || (FormasDePagoRow.Fields = {}));
            ['FormaPagoId', 'FormaPago', 'Credito', 'SwEfectivo', 'SwTarjeta', 'TarjetaLength', 'TarjetaPrefixes', 'TarjetaCheckdigit', 'SwDingus', 'ProduccionTpv'].forEach(function (x) { return Fields[x] = x; });
        })(FormasDePagoRow = Portal.FormasDePagoRow || (Portal.FormasDePagoRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FormasDePagoService;
        (function (FormasDePagoService) {
            FormasDePagoService.baseUrl = 'Portal/FormasDePago';
            var Methods;
            (function (Methods) {
            })(Methods = FormasDePagoService.Methods || (FormasDePagoService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                FormasDePagoService[x] = function (r, s, o) { return Q.serviceRequest(FormasDePagoService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = FormasDePagoService.baseUrl + '/' + x;
            });
        })(FormasDePagoService = Portal.FormasDePagoService || (Portal.FormasDePagoService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FrecuenciaFacturacionForm = (function (_super) {
            __extends(FrecuenciaFacturacionForm, _super);
            function FrecuenciaFacturacionForm() {
                return _super.apply(this, arguments) || this;
            }
            return FrecuenciaFacturacionForm;
        }(Serenity.PrefixedContext));
        FrecuenciaFacturacionForm.formKey = 'Portal.FrecuenciaFacturacion';
        Portal.FrecuenciaFacturacionForm = FrecuenciaFacturacionForm;
        [['FrecuenciaId', function () { return Serenity.IntegerEditor; }], ['DescripcionCorta', function () { return Serenity.StringEditor; }], ['Descripcion', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(FrecuenciaFacturacionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FrecuenciaFacturacionRow;
        (function (FrecuenciaFacturacionRow) {
            FrecuenciaFacturacionRow.idProperty = 'FrecuenciaId';
            FrecuenciaFacturacionRow.nameProperty = 'DescripcionCorta';
            FrecuenciaFacturacionRow.localTextPrefix = 'Portal.FrecuenciaFacturacion';
            var Fields;
            (function (Fields) {
            })(Fields = FrecuenciaFacturacionRow.Fields || (FrecuenciaFacturacionRow.Fields = {}));
            ['FrecuenciaId', 'DescripcionCorta', 'Descripcion'].forEach(function (x) { return Fields[x] = x; });
        })(FrecuenciaFacturacionRow = Portal.FrecuenciaFacturacionRow || (Portal.FrecuenciaFacturacionRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FrecuenciaFacturacionService;
        (function (FrecuenciaFacturacionService) {
            FrecuenciaFacturacionService.baseUrl = 'Portal/FrecuenciaFacturacion';
            var Methods;
            (function (Methods) {
            })(Methods = FrecuenciaFacturacionService.Methods || (FrecuenciaFacturacionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                FrecuenciaFacturacionService[x] = function (r, s, o) { return Q.serviceRequest(FrecuenciaFacturacionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = FrecuenciaFacturacionService.baseUrl + '/' + x;
            });
        })(FrecuenciaFacturacionService = Portal.FrecuenciaFacturacionService || (Portal.FrecuenciaFacturacionService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeClienteForm = (function (_super) {
            __extends(GruposDeClienteForm, _super);
            function GruposDeClienteForm() {
                return _super.apply(this, arguments) || this;
            }
            return GruposDeClienteForm;
        }(Serenity.PrefixedContext));
        GruposDeClienteForm.formKey = 'Portal.GruposDeCliente';
        Portal.GruposDeClienteForm = GruposDeClienteForm;
        [['NombreGrupo', function () { return Serenity.StringEditor; }], ['Huesped', function () { return Serenity.BooleanEditor; }], ['Contratos', function () { return Serenity.BooleanEditor; }], ['Facturar', function () { return Serenity.BooleanEditor; }], ['Agencia', function () { return Serenity.BooleanEditor; }], ['Perfil', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(GruposDeClienteForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeClienteRow;
        (function (GruposDeClienteRow) {
            GruposDeClienteRow.idProperty = 'GrupoClienteId';
            GruposDeClienteRow.nameProperty = 'NombreGrupo';
            GruposDeClienteRow.localTextPrefix = 'Portal.GruposDeCliente';
            GruposDeClienteRow.lookupKey = 'Portal.GruposDeCliente';
            function getLookup() {
                return Q.getLookup('Portal.GruposDeCliente');
            }
            GruposDeClienteRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = GruposDeClienteRow.Fields || (GruposDeClienteRow.Fields = {}));
            ['GrupoClienteId', 'NombreGrupo', 'Huesped', 'Contratos', 'Facturar', 'Agencia', 'Perfil'].forEach(function (x) { return Fields[x] = x; });
        })(GruposDeClienteRow = Portal.GruposDeClienteRow || (Portal.GruposDeClienteRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeClienteService;
        (function (GruposDeClienteService) {
            GruposDeClienteService.baseUrl = 'Portal/GruposDeCliente';
            var Methods;
            (function (Methods) {
            })(Methods = GruposDeClienteService.Methods || (GruposDeClienteService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                GruposDeClienteService[x] = function (r, s, o) { return Q.serviceRequest(GruposDeClienteService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = GruposDeClienteService.baseUrl + '/' + x;
            });
        })(GruposDeClienteService = Portal.GruposDeClienteService || (Portal.GruposDeClienteService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeServiciosForm = (function (_super) {
            __extends(GruposDeServiciosForm, _super);
            function GruposDeServiciosForm() {
                return _super.apply(this, arguments) || this;
            }
            return GruposDeServiciosForm;
        }(Serenity.PrefixedContext));
        GruposDeServiciosForm.formKey = 'Portal.GruposDeServicios';
        Portal.GruposDeServiciosForm = GruposDeServiciosForm;
        [['HotelId', function () { return Serenity.IntegerEditor; }], ['NombreGrupo', function () { return Serenity.StringEditor; }], ['CtaContable', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(GruposDeServiciosForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeServiciosRow;
        (function (GruposDeServiciosRow) {
            GruposDeServiciosRow.idProperty = 'GrupoServicioId';
            GruposDeServiciosRow.nameProperty = 'NombreGrupo';
            GruposDeServiciosRow.localTextPrefix = 'Portal.GruposDeServicios';
            GruposDeServiciosRow.lookupKey = 'Portal.GruposDeServicio';
            function getLookup() {
                return Q.getLookup('Portal.GruposDeServicio');
            }
            GruposDeServiciosRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = GruposDeServiciosRow.Fields || (GruposDeServiciosRow.Fields = {}));
            ['GrupoServicioId', 'NombreGrupo', 'CtaContable'].forEach(function (x) { return Fields[x] = x; });
        })(GruposDeServiciosRow = Portal.GruposDeServiciosRow || (Portal.GruposDeServiciosRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeServiciosService;
        (function (GruposDeServiciosService) {
            GruposDeServiciosService.baseUrl = 'Portal/GruposDeServicios';
            var Methods;
            (function (Methods) {
            })(Methods = GruposDeServiciosService.Methods || (GruposDeServiciosService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                GruposDeServiciosService[x] = function (r, s, o) { return Q.serviceRequest(GruposDeServiciosService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = GruposDeServiciosService.baseUrl + '/' + x;
            });
        })(GruposDeServiciosService = Portal.GruposDeServiciosService || (Portal.GruposDeServiciosService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposHabitacionForm = (function (_super) {
            __extends(GruposHabitacionForm, _super);
            function GruposHabitacionForm() {
                return _super.apply(this, arguments) || this;
            }
            return GruposHabitacionForm;
        }(Serenity.PrefixedContext));
        GruposHabitacionForm.formKey = 'Portal.GruposHabitacion';
        Portal.GruposHabitacionForm = GruposHabitacionForm;
        [['Habitacion', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(GruposHabitacionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposHabitacionRow;
        (function (GruposHabitacionRow) {
            GruposHabitacionRow.idProperty = 'HabitacionId';
            GruposHabitacionRow.nameProperty = 'Habitacion';
            GruposHabitacionRow.localTextPrefix = 'Portal.GruposHabitacion';
            GruposHabitacionRow.lookupKey = 'Portal.GruposHabitacion';
            function getLookup() {
                return Q.getLookup('Portal.GruposHabitacion');
            }
            GruposHabitacionRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = GruposHabitacionRow.Fields || (GruposHabitacionRow.Fields = {}));
            ['HabitacionId', 'Habitacion'].forEach(function (x) { return Fields[x] = x; });
        })(GruposHabitacionRow = Portal.GruposHabitacionRow || (Portal.GruposHabitacionRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposHabitacionService;
        (function (GruposHabitacionService) {
            GruposHabitacionService.baseUrl = 'Portal/GruposHabitacion';
            var Methods;
            (function (Methods) {
            })(Methods = GruposHabitacionService.Methods || (GruposHabitacionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                GruposHabitacionService[x] = function (r, s, o) { return Q.serviceRequest(GruposHabitacionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = GruposHabitacionService.baseUrl + '/' + x;
            });
        })(GruposHabitacionService = Portal.GruposHabitacionService || (Portal.GruposHabitacionService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var HotelesForm = (function (_super) {
            __extends(HotelesForm, _super);
            function HotelesForm() {
                return _super.apply(this, arguments) || this;
            }
            return HotelesForm;
        }(Serenity.PrefixedContext));
        HotelesForm.formKey = 'Portal.Hoteles';
        Portal.HotelesForm = HotelesForm;
        [['Hotel', function () { return Serenity.StringEditor; }], ['EmpresaId', function () { return Serenity.LookupEditor; }], ['TipoHotelId', function () { return Serenity.LookupEditor; }], ['CategoriaId', function () { return Serenity.LookupEditor; }], ['NombreCorto', function () { return Serenity.StringEditor; }], ['Direccion', function () { return Serenity.StringEditor; }], ['Poblacion', function () { return Serenity.StringEditor; }], ['Zip', function () { return Serenity.StringEditor; }], ['ProvinciaId', function () { return Serenity.LookupEditor; }], ['NacionId', function () { return Serenity.LookupEditor; }], ['Telefono', function () { return Serenity.StringEditor; }], ['Fax', function () { return Serenity.StringEditor; }], ['EmailReservas', function () { return Serenity.StringEditor; }], ['EmailVentas', function () { return Serenity.StringEditor; }], ['EmailSmtp', function () { return Serenity.StringEditor; }], ['TextoCancelacion', function () { return Serenity.StringEditor; }], ['CtaManocorriente', function () { return Serenity.StringEditor; }], ['DptoContable', function () { return Serenity.StringEditor; }], ['CtaContableCajas', function () { return Serenity.StringEditor; }], ['CtaContableBanco', function () { return Serenity.StringEditor; }], ['FechaInicioPrograma', function () { return Serenity.DateEditor; }], ['RutaFicheroPolicia', function () { return Serenity.StringEditor; }], ['ContadorFicheroPolicia', function () { return Serenity.IntegerEditor; }], ['IdentificadorFicheroPolicia', function () { return Serenity.StringEditor; }], ['UsuarioIsta', function () { return Serenity.StringEditor; }], ['PasswordIsta', function () { return Serenity.StringEditor; }], ['UrlIsta', function () { return Serenity.StringEditor; }], ['MunicipioIsta', function () { return Serenity.StringEditor; }], ['NumeroRegistroIsta', function () { return Serenity.IntegerEditor; }], ['RutaBavel', function () { return Serenity.StringEditor; }], ['DingusUsuario', function () { return Serenity.StringEditor; }], ['DingusPassword', function () { return Serenity.StringEditor; }], ['DingusHotelCode', function () { return Serenity.StringEditor; }], ['DingusTraductor', function () { return Serenity.StringEditor; }], ['DingusUrl', function () { return Serenity.StringEditor; }], ['CheckinOnLine', function () { return Serenity.IntegerEditor; }], ['MinimoDiasCheckinOnline', function () { return Serenity.IntegerEditor; }], ['ZoomMapa', function () { return Serenity.IntegerEditor; }], ['Lat', function () { return Serenity.DecimalEditor; }], ['Lng', function () { return Serenity.DecimalEditor; }], ['Ancho', function () { return Serenity.IntegerEditor; }], ['Alto', function () { return Serenity.IntegerEditor; }], ['OverbookingLimit', function () { return Serenity.DecimalEditor; }]].forEach(function (x) { return Object.defineProperty(HotelesForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var HotelesRow;
        (function (HotelesRow) {
            HotelesRow.idProperty = 'HotelId';
            HotelesRow.nameProperty = 'Hotel';
            HotelesRow.localTextPrefix = 'Portal.Hoteles';
            HotelesRow.lookupKey = 'Portal.Hoteles';
            function getLookup() {
                return Q.getLookup('Portal.Hoteles');
            }
            HotelesRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = HotelesRow.Fields || (HotelesRow.Fields = {}));
            ['HotelId', 'Hotel', 'EmpresaId', 'TipoHotelId', 'CategoriaId', 'NombreCorto', 'Direccion', 'Poblacion', 'Zip', 'ProvinciaId', 'NacionId', 'Telefono', 'Fax', 'CtaManocorriente', 'DptoContable', 'CtaContableCajas', 'CtaContableBanco', 'FechaInicioPrograma', 'RutaFicheroPolicia', 'ContadorFicheroPolicia', 'IdentificadorFicheroPolicia', 'EmailReservas', 'EmailVentas', 'EmailSmtp', 'TextoCancelacion', 'UsuarioIsta', 'PasswordIsta', 'UrlIsta', 'MunicipioIsta', 'NumeroRegistroIsta', 'RutaBavel', 'DingusUsuario', 'DingusPassword', 'DingusHotelCode', 'DingusTraductor', 'DingusUrl', 'CheckinOnLine', 'MinimoDiasCheckinOnline', 'ZoomMapa', 'Lat', 'Lng', 'Ancho', 'Alto', 'OverbookingLimit', 'Empresa', 'TipoHotel', 'TipoHotelAbreviatura', 'Categoria', 'CategoriaAbreviatura', 'Provincia', 'Nacion', 'ProvinciaComunidadAutonomaId', 'ProvinciaProvinciaIsta', 'ProvinciaDefectoIsta'].forEach(function (x) { return Fields[x] = x; });
        })(HotelesRow = Portal.HotelesRow || (Portal.HotelesRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var HotelesService;
        (function (HotelesService) {
            HotelesService.baseUrl = 'Portal/Hoteles';
            var Methods;
            (function (Methods) {
            })(Methods = HotelesService.Methods || (HotelesService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                HotelesService[x] = function (r, s, o) { return Q.serviceRequest(HotelesService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = HotelesService.baseUrl + '/' + x;
            });
        })(HotelesService = Portal.HotelesService || (Portal.HotelesService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var MonedasForm = (function (_super) {
            __extends(MonedasForm, _super);
            function MonedasForm() {
                return _super.apply(this, arguments) || this;
            }
            return MonedasForm;
        }(Serenity.PrefixedContext));
        MonedasForm.formKey = 'Portal.Monedas';
        Portal.MonedasForm = MonedasForm;
        [['Descripcion', function () { return Serenity.StringEditor; }], ['DescCorta', function () { return Serenity.StringEditor; }], ['Cambio', function () { return Serenity.DecimalEditor; }]].forEach(function (x) { return Object.defineProperty(MonedasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var MonedasRow;
        (function (MonedasRow) {
            MonedasRow.idProperty = 'MonedaId';
            MonedasRow.nameProperty = 'Descripcion';
            MonedasRow.localTextPrefix = 'Portal.Monedas';
            MonedasRow.lookupKey = 'Portal.Monedas';
            function getLookup() {
                return Q.getLookup('Portal.Monedas');
            }
            MonedasRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = MonedasRow.Fields || (MonedasRow.Fields = {}));
            ['MonedaId', 'DescCorta', 'Descripcion', 'Cambio'].forEach(function (x) { return Fields[x] = x; });
        })(MonedasRow = Portal.MonedasRow || (Portal.MonedasRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var MonedasService;
        (function (MonedasService) {
            MonedasService.baseUrl = 'Portal/Monedas';
            var Methods;
            (function (Methods) {
            })(Methods = MonedasService.Methods || (MonedasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                MonedasService[x] = function (r, s, o) { return Q.serviceRequest(MonedasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = MonedasService.baseUrl + '/' + x;
            });
        })(MonedasService = Portal.MonedasService || (Portal.MonedasService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var NacionesForm = (function (_super) {
            __extends(NacionesForm, _super);
            function NacionesForm() {
                return _super.apply(this, arguments) || this;
            }
            return NacionesForm;
        }(Serenity.PrefixedContext));
        NacionesForm.formKey = 'Portal.Naciones';
        Portal.NacionesForm = NacionesForm;
        [['Nacion', function () { return Serenity.StringEditor; }], ['DescCorta', function () { return Serenity.StringEditor; }], ['MonedaId', function () { return Serenity.LookupEditor; }], ['IdiomaId', function () { return Serenity.LookupEditor; }], ['NumeroIne', function () { return Serenity.IntegerEditor; }], ['PaisIsta', function () { return Serenity.StringEditor; }], ['Defecto', function () { return Serenity.IntegerEditor; }], ['NombreReal', function () { return Serenity.StringEditor; }], ['IdiomaMails', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(NacionesForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var NacionesRow;
        (function (NacionesRow) {
            NacionesRow.idProperty = 'NacionId';
            NacionesRow.nameProperty = 'Nacion';
            NacionesRow.localTextPrefix = 'Portal.Naciones';
            NacionesRow.lookupKey = 'Portal.Naciones';
            function getLookup() {
                return Q.getLookup('Portal.Naciones');
            }
            NacionesRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = NacionesRow.Fields || (NacionesRow.Fields = {}));
            ['NacionId', 'Nacion', 'DescCorta', 'MonedaId', 'IdiomaId', 'NumeroIne', 'PaisIsta', 'Defecto', 'NombreReal', 'IdiomaMails', 'MonedaDescripcion', 'MonedaDescCorta', 'MonedaCambio', 'IdiomaLanguageId', 'IdiomaLanguageName'].forEach(function (x) { return Fields[x] = x; });
        })(NacionesRow = Portal.NacionesRow || (Portal.NacionesRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var NacionesService;
        (function (NacionesService) {
            NacionesService.baseUrl = 'Portal/Naciones';
            var Methods;
            (function (Methods) {
            })(Methods = NacionesService.Methods || (NacionesService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                NacionesService[x] = function (r, s, o) { return Q.serviceRequest(NacionesService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = NacionesService.baseUrl + '/' + x;
            });
        })(NacionesService = Portal.NacionesService || (Portal.NacionesService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ProvinciasForm = (function (_super) {
            __extends(ProvinciasForm, _super);
            function ProvinciasForm() {
                return _super.apply(this, arguments) || this;
            }
            return ProvinciasForm;
        }(Serenity.PrefixedContext));
        ProvinciasForm.formKey = 'Portal.Provincias';
        Portal.ProvinciasForm = ProvinciasForm;
        [['Provincia', function () { return Serenity.StringEditor; }], ['ComunidadAutonomaId', function () { return Serenity.LookupEditor; }], ['NacionId', function () { return Serenity.LookupEditor; }], ['ProvinciaIsta', function () { return Serenity.StringEditor; }], ['DefectoIsta', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(ProvinciasForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ProvinciasRow;
        (function (ProvinciasRow) {
            ProvinciasRow.idProperty = 'ProvinciaId';
            ProvinciasRow.nameProperty = 'Provincia';
            ProvinciasRow.localTextPrefix = 'Portal.Provincias';
            ProvinciasRow.lookupKey = 'Portal.Provincias';
            function getLookup() {
                return Q.getLookup('Portal.Provincias');
            }
            ProvinciasRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ProvinciasRow.Fields || (ProvinciasRow.Fields = {}));
            ['ProvinciaId', 'Provincia', 'ComunidadAutonomaId', 'NacionId', 'ProvinciaIsta', 'DefectoIsta', 'ComunidadAutonomaNacionId', 'ComunidadAutonoma', 'ComunidadAutonomaComunidadAutonomaIsta', 'Nacion', 'NacionDescCorta', 'NacionMonedaId', 'NacionIdiomaId', 'NacionNumeroIne', 'NacionPaisIsta', 'NacionDefecto', 'NacionNombreReal', 'NacionIdiomaMails'].forEach(function (x) { return Fields[x] = x; });
        })(ProvinciasRow = Portal.ProvinciasRow || (Portal.ProvinciasRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ProvinciasService;
        (function (ProvinciasService) {
            ProvinciasService.baseUrl = 'Portal/Provincias';
            var Methods;
            (function (Methods) {
            })(Methods = ProvinciasService.Methods || (ProvinciasService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ProvinciasService[x] = function (r, s, o) { return Q.serviceRequest(ProvinciasService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ProvinciasService.baseUrl + '/' + x;
            });
        })(ProvinciasService = Portal.ProvinciasService || (Portal.ProvinciasService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ReservaEstadosRow;
        (function (ReservaEstadosRow) {
            ReservaEstadosRow.idProperty = 'EstadoReservaId';
            ReservaEstadosRow.nameProperty = 'Estado';
            ReservaEstadosRow.localTextPrefix = 'Portal.ReservaEstados';
            ReservaEstadosRow.lookupKey = 'Portal.ReservasEstados';
            function getLookup() {
                return Q.getLookup('Portal.ReservasEstados');
            }
            ReservaEstadosRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ReservaEstadosRow.Fields || (ReservaEstadosRow.Fields = {}));
            ['EstadoReservaId', 'Estado', 'EsErrorFechaini', 'EsErrorFechafin'].forEach(function (x) { return Fields[x] = x; });
        })(ReservaEstadosRow = Portal.ReservaEstadosRow || (Portal.ReservaEstadosRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ServiciosForm = (function (_super) {
            __extends(ServiciosForm, _super);
            function ServiciosForm() {
                return _super.apply(this, arguments) || this;
            }
            return ServiciosForm;
        }(Serenity.PrefixedContext));
        ServiciosForm.formKey = 'Portal.Servicios';
        Portal.ServiciosForm = ServiciosForm;
        [['NombreServicio', function () { return Serenity.StringEditor; }], ['Abreviatura', function () { return Serenity.StringEditor; }], ['TipoServicioId', function () { return Serenity.LookupEditor; }], ['TipoUnidadCalculoId', function () { return Serenity.LookupEditor; }], ['SwProduccion', function () { return Serenity.BooleanEditor; }], ['SwDescuento', function () { return Serenity.BooleanEditor; }], ['SwAjustes', function () { return Serenity.BooleanEditor; }], ['SwGastos', function () { return Serenity.BooleanEditor; }], ['SwPension', function () { return Serenity.BooleanEditor; }], ['SwRectificativa', function () { return Serenity.BooleanEditor; }], ['ConceptoAceleradorReservasId', function () { return Serenity.LookupEditor; }], ['SumaServicioId', function () { return Serenity.LookupEditor; }], ['RestaServicioId', function () { return Serenity.LookupEditor; }], ['TipoHab', function () { return Serenity.LookupEditor; }], ['TipoPension', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(ServiciosForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ServiciosRow;
        (function (ServiciosRow) {
            ServiciosRow.idProperty = 'ServicioId';
            ServiciosRow.nameProperty = 'NombreServicio';
            ServiciosRow.localTextPrefix = 'Portal.Servicios';
            ServiciosRow.lookupKey = 'Portal.Servicios';
            function getLookup() {
                return Q.getLookup('Portal.Servicios');
            }
            ServiciosRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = ServiciosRow.Fields || (ServiciosRow.Fields = {}));
            ['ServicioId', 'NombreServicio', 'Abreviatura', 'TipoServicioId', 'SwProduccion', 'SwDescuento', 'SwAjustes', 'SwGastos', 'SwPension', 'SwRectificativa', 'TipoUnidadCalculoId', 'ConceptoAceleradorReservasId', 'Costo', 'SumaServicioId', 'RestaServicioId', 'UserId', 'FechaModificacion', 'TipoHab', 'TipoPension', 'TipoServicioNombreTipoServicio', 'Tipo_UC', 'Concepto', 'Suma', 'Resta', 'NombreTipoHab', 'NombreTipoPension'].forEach(function (x) { return Fields[x] = x; });
        })(ServiciosRow = Portal.ServiciosRow || (Portal.ServiciosRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ServiciosService;
        (function (ServiciosService) {
            ServiciosService.baseUrl = 'Portal/Servicios';
            var Methods;
            (function (Methods) {
            })(Methods = ServiciosService.Methods || (ServiciosService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                ServiciosService[x] = function (r, s, o) { return Q.serviceRequest(ServiciosService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = ServiciosService.baseUrl + '/' + x;
            });
        })(ServiciosService = Portal.ServiciosService || (Portal.ServiciosService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var SexosRow;
        (function (SexosRow) {
            SexosRow.idProperty = 'SexoId';
            SexosRow.nameProperty = 'SexoId';
            SexosRow.localTextPrefix = 'Portal.Sexos';
            SexosRow.lookupKey = 'Portal.Sexos';
            function getLookup() {
                return Q.getLookup('Portal.Sexos');
            }
            SexosRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = SexosRow.Fields || (SexosRow.Fields = {}));
            ['SexoId', 'Sexo'].forEach(function (x) { return Fields[x] = x; });
        })(SexosRow = Portal.SexosRow || (Portal.SexosRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TipoAplicacionOfertaForm = (function (_super) {
            __extends(TipoAplicacionOfertaForm, _super);
            function TipoAplicacionOfertaForm() {
                return _super.apply(this, arguments) || this;
            }
            return TipoAplicacionOfertaForm;
        }(Serenity.PrefixedContext));
        TipoAplicacionOfertaForm.formKey = 'Portal.TipoAplicacionOferta';
        Portal.TipoAplicacionOfertaForm = TipoAplicacionOfertaForm;
        [['TipoAplicacionOfertaId', function () { return Serenity.StringEditor; }], ['AplicableSegunFechaDe', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(TipoAplicacionOfertaForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TipoAplicacionOfertaRow;
        (function (TipoAplicacionOfertaRow) {
            TipoAplicacionOfertaRow.idProperty = 'TipoAplicacionOfertaId';
            TipoAplicacionOfertaRow.nameProperty = 'TipoAplicacionOfertaId';
            TipoAplicacionOfertaRow.localTextPrefix = 'Portal.TipoAplicacionOferta';
            var Fields;
            (function (Fields) {
            })(Fields = TipoAplicacionOfertaRow.Fields || (TipoAplicacionOfertaRow.Fields = {}));
            ['TipoAplicacionOfertaId', 'AplicableSegunFechaDe'].forEach(function (x) { return Fields[x] = x; });
        })(TipoAplicacionOfertaRow = Portal.TipoAplicacionOfertaRow || (Portal.TipoAplicacionOfertaRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TipoAplicacionOfertaService;
        (function (TipoAplicacionOfertaService) {
            TipoAplicacionOfertaService.baseUrl = 'Portal/TipoAplicacionOferta';
            var Methods;
            (function (Methods) {
            })(Methods = TipoAplicacionOfertaService.Methods || (TipoAplicacionOfertaService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TipoAplicacionOfertaService[x] = function (r, s, o) { return Q.serviceRequest(TipoAplicacionOfertaService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TipoAplicacionOfertaService.baseUrl + '/' + x;
            });
        })(TipoAplicacionOfertaService = Portal.TipoAplicacionOfertaService || (Portal.TipoAplicacionOfertaService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposCondicionForm = (function (_super) {
            __extends(TiposCondicionForm, _super);
            function TiposCondicionForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposCondicionForm;
        }(Serenity.PrefixedContext));
        TiposCondicionForm.formKey = 'Portal.TiposCondicion';
        Portal.TiposCondicionForm = TiposCondicionForm;
        [['TipoCondicionId', function () { return Serenity.IntegerEditor; }], ['Condicion', function () { return Serenity.StringEditor; }], ['Literal', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(TiposCondicionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposCondicionRow;
        (function (TiposCondicionRow) {
            TiposCondicionRow.idProperty = 'TipoCondicionId';
            TiposCondicionRow.nameProperty = 'Condicion';
            TiposCondicionRow.localTextPrefix = 'Portal.TiposCondicion';
            var Fields;
            (function (Fields) {
            })(Fields = TiposCondicionRow.Fields || (TiposCondicionRow.Fields = {}));
            ['TipoCondicionId', 'Condicion', 'Literal'].forEach(function (x) { return Fields[x] = x; });
        })(TiposCondicionRow = Portal.TiposCondicionRow || (Portal.TiposCondicionRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposCondicionService;
        (function (TiposCondicionService) {
            TiposCondicionService.baseUrl = 'Portal/TiposCondicion';
            var Methods;
            (function (Methods) {
            })(Methods = TiposCondicionService.Methods || (TiposCondicionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposCondicionService[x] = function (r, s, o) { return Q.serviceRequest(TiposCondicionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposCondicionService.baseUrl + '/' + x;
            });
        })(TiposCondicionService = Portal.TiposCondicionService || (Portal.TiposCondicionService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeImputacionForm = (function (_super) {
            __extends(TiposDeImputacionForm, _super);
            function TiposDeImputacionForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposDeImputacionForm;
        }(Serenity.PrefixedContext));
        TiposDeImputacionForm.formKey = 'Portal.TiposDeImputacion';
        Portal.TiposDeImputacionForm = TiposDeImputacionForm;
        [['TipoImputacionId', function () { return Serenity.IntegerEditor; }], ['Imputacion', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(TiposDeImputacionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeImputacionRow;
        (function (TiposDeImputacionRow) {
            TiposDeImputacionRow.idProperty = 'TipoImputacionId';
            TiposDeImputacionRow.nameProperty = 'Imputacion';
            TiposDeImputacionRow.localTextPrefix = 'Portal.TiposDeImputacion';
            var Fields;
            (function (Fields) {
            })(Fields = TiposDeImputacionRow.Fields || (TiposDeImputacionRow.Fields = {}));
            ['TipoImputacionId', 'Imputacion'].forEach(function (x) { return Fields[x] = x; });
        })(TiposDeImputacionRow = Portal.TiposDeImputacionRow || (Portal.TiposDeImputacionRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeImputacionService;
        (function (TiposDeImputacionService) {
            TiposDeImputacionService.baseUrl = 'Portal/TiposDeImputacion';
            var Methods;
            (function (Methods) {
            })(Methods = TiposDeImputacionService.Methods || (TiposDeImputacionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposDeImputacionService[x] = function (r, s, o) { return Q.serviceRequest(TiposDeImputacionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposDeImputacionService.baseUrl + '/' + x;
            });
        })(TiposDeImputacionService = Portal.TiposDeImputacionService || (Portal.TiposDeImputacionService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeOfertaForm = (function (_super) {
            __extends(TiposDeOfertaForm, _super);
            function TiposDeOfertaForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposDeOfertaForm;
        }(Serenity.PrefixedContext));
        TiposDeOfertaForm.formKey = 'Portal.TiposDeOferta';
        Portal.TiposDeOfertaForm = TiposDeOfertaForm;
        [['TipoOfertaId', function () { return Serenity.IntegerEditor; }], ['Oferta', function () { return Serenity.StringEditor; }], ['PermitirMMayorQueN', function () { return Serenity.IntegerEditor; }], ['Rejilla', function () { return Serenity.IntegerEditor; }], ['Observaciones', function () { return Serenity.StringEditor; }], ['OrdenAplicacion', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(TiposDeOfertaForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeOfertaRow;
        (function (TiposDeOfertaRow) {
            TiposDeOfertaRow.idProperty = 'TipoOfertaId';
            TiposDeOfertaRow.nameProperty = 'Oferta';
            TiposDeOfertaRow.localTextPrefix = 'Portal.TiposDeOferta';
            var Fields;
            (function (Fields) {
            })(Fields = TiposDeOfertaRow.Fields || (TiposDeOfertaRow.Fields = {}));
            ['TipoOfertaId', 'Oferta', 'PermitirMMayorQueN', 'Rejilla', 'Observaciones', 'OrdenAplicacion'].forEach(function (x) { return Fields[x] = x; });
        })(TiposDeOfertaRow = Portal.TiposDeOfertaRow || (Portal.TiposDeOfertaRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeOfertaService;
        (function (TiposDeOfertaService) {
            TiposDeOfertaService.baseUrl = 'Portal/TiposDeOferta';
            var Methods;
            (function (Methods) {
            })(Methods = TiposDeOfertaService.Methods || (TiposDeOfertaService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposDeOfertaService[x] = function (r, s, o) { return Q.serviceRequest(TiposDeOfertaService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposDeOfertaService.baseUrl + '/' + x;
            });
        })(TiposDeOfertaService = Portal.TiposDeOfertaService || (Portal.TiposDeOfertaService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDocumentoRow;
        (function (TiposDocumentoRow) {
            TiposDocumentoRow.idProperty = 'DocumentoId';
            TiposDocumentoRow.nameProperty = 'Documento';
            TiposDocumentoRow.localTextPrefix = 'Portal.TiposDocumento';
            TiposDocumentoRow.lookupKey = 'Portal.TiposDocumento';
            function getLookup() {
                return Q.getLookup('Portal.TiposDocumento');
            }
            TiposDocumentoRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposDocumentoRow.Fields || (TiposDocumentoRow.Fields = {}));
            ['DocumentoId', 'Documento'].forEach(function (x) { return Fields[x] = x; });
        })(TiposDocumentoRow = Portal.TiposDocumentoRow || (Portal.TiposDocumentoRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHabitacionForm = (function (_super) {
            __extends(TiposHabitacionForm, _super);
            function TiposHabitacionForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposHabitacionForm;
        }(Serenity.PrefixedContext));
        TiposHabitacionForm.formKey = 'Portal.TiposHabitacion';
        Portal.TiposHabitacionForm = TiposHabitacionForm;
        [['DescCorta', function () { return Serenity.StringEditor; }], ['Descripcion', function () { return Serenity.StringEditor; }], ['GrupoHabitacionId', function () { return Serenity.LookupEditor; }], ['NumeroPersonas', function () { return Serenity.IntegerEditor; }], ['Desvios', function () { return Serenity.IntegerEditor; }], ['NoShow', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(TiposHabitacionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHabitacionRow;
        (function (TiposHabitacionRow) {
            TiposHabitacionRow.idProperty = 'TipoHabitacionId';
            TiposHabitacionRow.nameProperty = 'DescCorta';
            TiposHabitacionRow.localTextPrefix = 'Portal.TiposHabitacion';
            TiposHabitacionRow.lookupKey = 'Portal.TiposHabitacion';
            function getLookup() {
                return Q.getLookup('Portal.TiposHabitacion');
            }
            TiposHabitacionRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposHabitacionRow.Fields || (TiposHabitacionRow.Fields = {}));
            ['TipoHabitacionId', 'DescCorta', 'Descripcion', 'GrupoHabitacionId', 'NumeroPersonas', 'Desvios', 'NoShow', 'GrupoHabitacion'].forEach(function (x) { return Fields[x] = x; });
        })(TiposHabitacionRow = Portal.TiposHabitacionRow || (Portal.TiposHabitacionRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHabitacionService;
        (function (TiposHabitacionService) {
            TiposHabitacionService.baseUrl = 'Portal/TiposHabitacion';
            var Methods;
            (function (Methods) {
            })(Methods = TiposHabitacionService.Methods || (TiposHabitacionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposHabitacionService[x] = function (r, s, o) { return Q.serviceRequest(TiposHabitacionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposHabitacionService.baseUrl + '/' + x;
            });
        })(TiposHabitacionService = Portal.TiposHabitacionService || (Portal.TiposHabitacionService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHotelForm = (function (_super) {
            __extends(TiposHotelForm, _super);
            function TiposHotelForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposHotelForm;
        }(Serenity.PrefixedContext));
        TiposHotelForm.formKey = 'Portal.TiposHotel';
        Portal.TiposHotelForm = TiposHotelForm;
        [['TipoHotel', function () { return Serenity.StringEditor; }], ['Abreviatura', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(TiposHotelForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHotelRow;
        (function (TiposHotelRow) {
            TiposHotelRow.idProperty = 'TipoHotelId';
            TiposHotelRow.nameProperty = 'TipoHotel';
            TiposHotelRow.localTextPrefix = 'Portal.TiposHotel';
            TiposHotelRow.lookupKey = 'Portal.TiposHotel';
            function getLookup() {
                return Q.getLookup('Portal.TiposHotel');
            }
            TiposHotelRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposHotelRow.Fields || (TiposHotelRow.Fields = {}));
            ['TipoHotelId', 'TipoHotel', 'Abreviatura'].forEach(function (x) { return Fields[x] = x; });
        })(TiposHotelRow = Portal.TiposHotelRow || (Portal.TiposHotelRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHotelService;
        (function (TiposHotelService) {
            TiposHotelService.baseUrl = 'Portal/TiposHotel';
            var Methods;
            (function (Methods) {
            })(Methods = TiposHotelService.Methods || (TiposHotelService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposHotelService[x] = function (r, s, o) { return Q.serviceRequest(TiposHotelService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposHotelService.baseUrl + '/' + x;
            });
        })(TiposHotelService = Portal.TiposHotelService || (Portal.TiposHotelService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHuespedForm = (function (_super) {
            __extends(TiposHuespedForm, _super);
            function TiposHuespedForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposHuespedForm;
        }(Serenity.PrefixedContext));
        TiposHuespedForm.formKey = 'Portal.TiposHuesped';
        Portal.TiposHuespedForm = TiposHuespedForm;
        [['Descripcion', function () { return Serenity.StringEditor; }], ['DescCorta', function () { return Serenity.StringEditor; }], ['UcId', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(TiposHuespedForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHuespedRow;
        (function (TiposHuespedRow) {
            TiposHuespedRow.idProperty = 'TipoHuespedId';
            TiposHuespedRow.nameProperty = 'Descripcion';
            TiposHuespedRow.localTextPrefix = 'Portal.TiposHuesped';
            TiposHuespedRow.lookupKey = 'Portal.TiposHuesped';
            function getLookup() {
                return Q.getLookup('Portal.TiposHuesped');
            }
            TiposHuespedRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposHuespedRow.Fields || (TiposHuespedRow.Fields = {}));
            ['TipoHuespedId', 'Descripcion', 'DescCorta', 'UcId', 'UcDescripcionUnidadCalculo'].forEach(function (x) { return Fields[x] = x; });
        })(TiposHuespedRow = Portal.TiposHuespedRow || (Portal.TiposHuespedRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHuespedService;
        (function (TiposHuespedService) {
            TiposHuespedService.baseUrl = 'Portal/TiposHuesped';
            var Methods;
            (function (Methods) {
            })(Methods = TiposHuespedService.Methods || (TiposHuespedService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposHuespedService[x] = function (r, s, o) { return Q.serviceRequest(TiposHuespedService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposHuespedService.baseUrl + '/' + x;
            });
        })(TiposHuespedService = Portal.TiposHuespedService || (Portal.TiposHuespedService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposPensionRow;
        (function (TiposPensionRow) {
            TiposPensionRow.idProperty = 'TipoPensionId';
            TiposPensionRow.nameProperty = 'TipoPension';
            TiposPensionRow.localTextPrefix = 'Portal.TiposPension';
            TiposPensionRow.lookupKey = 'Portal.TiposPension';
            function getLookup() {
                return Q.getLookup('Portal.TiposPension');
            }
            TiposPensionRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposPensionRow.Fields || (TiposPensionRow.Fields = {}));
            ['TipoPensionId', 'TipoPension'].forEach(function (x) { return Fields[x] = x; });
        })(TiposPensionRow = Portal.TiposPensionRow || (Portal.TiposPensionRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposServicioForm = (function (_super) {
            __extends(TiposServicioForm, _super);
            function TiposServicioForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposServicioForm;
        }(Serenity.PrefixedContext));
        TiposServicioForm.formKey = 'Portal.TiposServicio';
        Portal.TiposServicioForm = TiposServicioForm;
        [['NombreTipoServicio', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(TiposServicioForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposServicioRow;
        (function (TiposServicioRow) {
            TiposServicioRow.idProperty = 'TipoServicioId';
            TiposServicioRow.nameProperty = 'NombreTipoServicio';
            TiposServicioRow.localTextPrefix = 'Portal.TiposServicio';
            TiposServicioRow.lookupKey = 'Portal.TiposServicio';
            function getLookup() {
                return Q.getLookup('Portal.TiposServicio');
            }
            TiposServicioRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposServicioRow.Fields || (TiposServicioRow.Fields = {}));
            ['TipoServicioId', 'NombreTipoServicio'].forEach(function (x) { return Fields[x] = x; });
        })(TiposServicioRow = Portal.TiposServicioRow || (Portal.TiposServicioRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposServicioService;
        (function (TiposServicioService) {
            TiposServicioService.baseUrl = 'Portal/TiposServicio';
            var Methods;
            (function (Methods) {
            })(Methods = TiposServicioService.Methods || (TiposServicioService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposServicioService[x] = function (r, s, o) { return Q.serviceRequest(TiposServicioService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposServicioService.baseUrl + '/' + x;
            });
        })(TiposServicioService = Portal.TiposServicioService || (Portal.TiposServicioService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposUnidadCalculoForm = (function (_super) {
            __extends(TiposUnidadCalculoForm, _super);
            function TiposUnidadCalculoForm() {
                return _super.apply(this, arguments) || this;
            }
            return TiposUnidadCalculoForm;
        }(Serenity.PrefixedContext));
        TiposUnidadCalculoForm.formKey = 'Portal.TiposUnidadCalculo';
        Portal.TiposUnidadCalculoForm = TiposUnidadCalculoForm;
        [['Uc', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(TiposUnidadCalculoForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposUnidadCalculoRow;
        (function (TiposUnidadCalculoRow) {
            TiposUnidadCalculoRow.idProperty = 'UnidadCalculoId';
            TiposUnidadCalculoRow.nameProperty = 'Uc';
            TiposUnidadCalculoRow.localTextPrefix = 'Portal.TiposUnidadCalculo';
            TiposUnidadCalculoRow.lookupKey = 'Portal.TiposUnidadCalculo';
            function getLookup() {
                return Q.getLookup('Portal.TiposUnidadCalculo');
            }
            TiposUnidadCalculoRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = TiposUnidadCalculoRow.Fields || (TiposUnidadCalculoRow.Fields = {}));
            ['UnidadCalculoId', 'Uc'].forEach(function (x) { return Fields[x] = x; });
        })(TiposUnidadCalculoRow = Portal.TiposUnidadCalculoRow || (Portal.TiposUnidadCalculoRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposUnidadCalculoService;
        (function (TiposUnidadCalculoService) {
            TiposUnidadCalculoService.baseUrl = 'Portal/TiposUnidadCalculo';
            var Methods;
            (function (Methods) {
            })(Methods = TiposUnidadCalculoService.Methods || (TiposUnidadCalculoService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                TiposUnidadCalculoService[x] = function (r, s, o) { return Q.serviceRequest(TiposUnidadCalculoService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = TiposUnidadCalculoService.baseUrl + '/' + x;
            });
        })(TiposUnidadCalculoService = Portal.TiposUnidadCalculoService || (Portal.TiposUnidadCalculoService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var UnidadesCalculoForm = (function (_super) {
            __extends(UnidadesCalculoForm, _super);
            function UnidadesCalculoForm() {
                return _super.apply(this, arguments) || this;
            }
            return UnidadesCalculoForm;
        }(Serenity.PrefixedContext));
        UnidadesCalculoForm.formKey = 'Portal.UnidadesCalculo';
        Portal.UnidadesCalculoForm = UnidadesCalculoForm;
        [['Uc', function () { return Serenity.StringEditor; }], ['DescripcionUnidadCalculo', function () { return Serenity.StringEditor; }], ['TipoUnidadCalculoId', function () { return Serenity.LookupEditor; }], ['Pax', function () { return Serenity.BooleanEditor; }], ['ServicioId', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(UnidadesCalculoForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var UnidadesCalculoRow;
        (function (UnidadesCalculoRow) {
            UnidadesCalculoRow.idProperty = 'UnidadCalculoId';
            UnidadesCalculoRow.nameProperty = 'Uc';
            UnidadesCalculoRow.localTextPrefix = 'Portal.UnidadesCalculo';
            UnidadesCalculoRow.lookupKey = 'Portal.UnidadesCalculo';
            function getLookup() {
                return Q.getLookup('Portal.UnidadesCalculo');
            }
            UnidadesCalculoRow.getLookup = getLookup;
            var Fields;
            (function (Fields) {
            })(Fields = UnidadesCalculoRow.Fields || (UnidadesCalculoRow.Fields = {}));
            ['UnidadCalculoId', 'Uc', 'DescripcionUnidadCalculo', 'TipoUnidadCalculoId', 'Pax', 'ServicioId', 'TipoUc', 'ServicioNombreServicio'].forEach(function (x) { return Fields[x] = x; });
        })(UnidadesCalculoRow = Portal.UnidadesCalculoRow || (Portal.UnidadesCalculoRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var UnidadesCalculoService;
        (function (UnidadesCalculoService) {
            UnidadesCalculoService.baseUrl = 'Portal/UnidadesCalculo';
            var Methods;
            (function (Methods) {
            })(Methods = UnidadesCalculoService.Methods || (UnidadesCalculoService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                UnidadesCalculoService[x] = function (r, s, o) { return Q.serviceRequest(UnidadesCalculoService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = UnidadesCalculoService.baseUrl + '/' + x;
            });
        })(UnidadesCalculoService = Portal.UnidadesCalculoService || (Portal.UnidadesCalculoService = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var UsuariosEmpresaRow;
        (function (UsuariosEmpresaRow) {
            UsuariosEmpresaRow.idProperty = 'UserId';
            UsuariosEmpresaRow.localTextPrefix = 'Portal.UsuariosEmpresa';
            var Fields;
            (function (Fields) {
            })(Fields = UsuariosEmpresaRow.Fields || (UsuariosEmpresaRow.Fields = {}));
            ['UserId', 'EmpresaId', 'UserUsername', 'UserDisplayName', 'UserEmail', 'UserSource', 'UserPasswordHash', 'UserPasswordSalt', 'UserInsertDate', 'UserInsertUserId', 'UserUpdateDate', 'UserUpdateUserId', 'UserIsActive', 'UserLastDirectoryUpdate', 'UserUserImage'].forEach(function (x) { return Fields[x] = x; });
        })(UsuariosEmpresaRow = Portal.UsuariosEmpresaRow || (Portal.UsuariosEmpresaRow = {}));
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Prtal;
    (function (Prtal) {
        var FrecuenciaFacturacionForm = (function (_super) {
            __extends(FrecuenciaFacturacionForm, _super);
            function FrecuenciaFacturacionForm() {
                return _super.apply(this, arguments) || this;
            }
            return FrecuenciaFacturacionForm;
        }(Serenity.PrefixedContext));
        FrecuenciaFacturacionForm.formKey = 'Prtal.FrecuenciaFacturacion';
        Prtal.FrecuenciaFacturacionForm = FrecuenciaFacturacionForm;
        [['FrecuenciaId', function () { return Serenity.IntegerEditor; }], ['DescripcionCorta', function () { return Serenity.StringEditor; }], ['Descripcion', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(FrecuenciaFacturacionForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
    })(Prtal = Geshotel.Prtal || (Geshotel.Prtal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Prtal;
    (function (Prtal) {
        var FrecuenciaFacturacionRow;
        (function (FrecuenciaFacturacionRow) {
            FrecuenciaFacturacionRow.idProperty = 'FrecuenciaId';
            FrecuenciaFacturacionRow.nameProperty = 'DescripcionCorta';
            FrecuenciaFacturacionRow.localTextPrefix = 'Prtal.FrecuenciaFacturacion';
            var Fields;
            (function (Fields) {
            })(Fields = FrecuenciaFacturacionRow.Fields || (FrecuenciaFacturacionRow.Fields = {}));
            ['FrecuenciaId', 'DescripcionCorta', 'Descripcion'].forEach(function (x) { return Fields[x] = x; });
        })(FrecuenciaFacturacionRow = Prtal.FrecuenciaFacturacionRow || (Prtal.FrecuenciaFacturacionRow = {}));
    })(Prtal = Geshotel.Prtal || (Geshotel.Prtal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Prtal;
    (function (Prtal) {
        var FrecuenciaFacturacionService;
        (function (FrecuenciaFacturacionService) {
            FrecuenciaFacturacionService.baseUrl = 'Prtal/FrecuenciaFacturacion';
            var Methods;
            (function (Methods) {
            })(Methods = FrecuenciaFacturacionService.Methods || (FrecuenciaFacturacionService.Methods = {}));
            ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                FrecuenciaFacturacionService[x] = function (r, s, o) { return Q.serviceRequest(FrecuenciaFacturacionService.baseUrl + '/' + x, r, s, o); };
                Methods[x] = FrecuenciaFacturacionService.baseUrl + '/' + x;
            });
        })(FrecuenciaFacturacionService = Prtal.FrecuenciaFacturacionService || (Prtal.FrecuenciaFacturacionService = {}));
    })(Prtal = Geshotel.Prtal || (Geshotel.Prtal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var EmpresaSelection = (function (_super) {
            __extends(EmpresaSelection, _super);
            function EmpresaSelection(select, currentEmpresa) {
                var _this = _super.call(this, select) || this;
                currentEmpresa = Q.coalesce(currentEmpresa, '1');
                _this.change(function (e) {
                    $.cookie('EmpresaPreference', select.val(), {
                        path: Q.Config.applicationPath,
                        expires: 365
                    });
                    window.location.reload(true);
                });
                Q.getLookupAsync('Portal.Empresas').then(function (x) {
                    if (!Q.any(x.items, function (z) { return z.EmpresaId.toString() === currentEmpresa; })) {
                        var idx = currentEmpresa.lastIndexOf('-');
                        if (idx >= 0) {
                            currentEmpresa = currentEmpresa.substr(0, idx);
                            if (!Q.any(x.items, function (y) { return y.EmpresaId.toString() === currentEmpresa; })) {
                                currentEmpresa = '1';
                            }
                        }
                        else {
                            currentEmpresa = '1';
                        }
                    }
                    for (var _i = 0, _a = x.items; _i < _a.length; _i++) {
                        var l = _a[_i];
                        Q.addOption(select, l.EmpresaId.toString(), l.Empresa);
                    }
                    select.val(currentEmpresa);
                });
                return _this;
            }
            return EmpresaSelection;
        }(Serenity.Widget));
        Common.EmpresaSelection = EmpresaSelection;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var LanguageSelection = (function (_super) {
            __extends(LanguageSelection, _super);
            function LanguageSelection(select, currentLanguage) {
                var _this = _super.call(this, select) || this;
                currentLanguage = Q.coalesce(currentLanguage, 'es');
                _this.change(function (e) {
                    $.cookie('LanguagePreference', select.val(), {
                        path: Q.Config.applicationPath,
                        expires: 365
                    });
                    window.location.reload(true);
                });
                Q.getLookupAsync('Administration.Language').then(function (x) {
                    if (!Q.any(x.items, function (z) { return z.LanguageId === currentLanguage; })) {
                        var idx = currentLanguage.lastIndexOf('-');
                        if (idx >= 0) {
                            currentLanguage = currentLanguage.substr(0, idx);
                            if (!Q.any(x.items, function (y) { return y.LanguageId === currentLanguage; })) {
                                currentLanguage = 'en';
                            }
                        }
                        else {
                            currentLanguage = 'en';
                        }
                    }
                    for (var _i = 0, _a = x.items; _i < _a.length; _i++) {
                        var l = _a[_i];
                        Q.addOption(select, l.LanguageId, l.LanguageName);
                    }
                    select.val(currentLanguage);
                });
                return _this;
            }
            return LanguageSelection;
        }(Serenity.Widget));
        Common.LanguageSelection = LanguageSelection;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var SidebarSearch = (function (_super) {
            __extends(SidebarSearch, _super);
            function SidebarSearch(input, menuUL) {
                var _this = _super.call(this, input) || this;
                new Serenity.QuickSearchInput(input, {
                    onSearch: function (field, text, success) {
                        _this.updateMatchFlags(text);
                        success(true);
                    }
                });
                _this.menuUL = menuUL;
                return _this;
            }
            SidebarSearch.prototype.updateMatchFlags = function (text) {
                var liList = this.menuUL.find('li').removeClass('non-match');
                text = Q.trimToNull(text);
                if (text == null) {
                    liList.show();
                    liList.removeClass('expanded');
                    return;
                }
                var parts = text.replace(',', ' ').split(' ').filter(function (x) { return !Q.isTrimmedEmpty(x); });
                for (var i = 0; i < parts.length; i++) {
                    parts[i] = Q.trimToNull(Select2.util.stripDiacritics(parts[i]).toUpperCase());
                }
                var items = liList;
                items.each(function (idx, e) {
                    var x = $(e);
                    var title = Select2.util.stripDiacritics(Q.coalesce(x.text(), '').toUpperCase());
                    for (var _i = 0, parts_1 = parts; _i < parts_1.length; _i++) {
                        var p = parts_1[_i];
                        if (p != null && !(title.indexOf(p) !== -1)) {
                            x.addClass('non-match');
                            break;
                        }
                    }
                });
                var matchingItems = items.not('.non-match');
                var visibles = matchingItems.parents('li').add(matchingItems);
                var nonVisibles = liList.not(visibles);
                nonVisibles.hide().addClass('non-match');
                visibles.show();
                liList.addClass('expanded');
            };
            return SidebarSearch;
        }(Serenity.Widget));
        Common.SidebarSearch = SidebarSearch;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var ThemeSelection = (function (_super) {
            __extends(ThemeSelection, _super);
            function ThemeSelection(select) {
                var _this = _super.call(this, select) || this;
                _this.change(function (e) {
                    $.cookie('ThemePreference', select.val(), {
                        path: Q.Config.applicationPath,
                        expires: 365
                    });
                    $('body').removeClass('skin-' + _this.getCurrentTheme());
                    $('body').addClass('skin-' + select.val());
                });
                Q.addOption(select, 'blue', Q.text('Site.Layout.ThemeBlue'));
                Q.addOption(select, 'blue-light', Q.text('Site.Layout.ThemeBlueLight'));
                Q.addOption(select, 'purple', Q.text('Site.Layout.ThemePurple'));
                Q.addOption(select, 'purple-light', Q.text('Site.Layout.ThemePurpleLight'));
                Q.addOption(select, 'red', Q.text('Site.Layout.ThemeRed'));
                Q.addOption(select, 'red-light', Q.text('Site.Layout.ThemeRedLight'));
                Q.addOption(select, 'green', Q.text('Site.Layout.ThemeGreen'));
                Q.addOption(select, 'green-light', Q.text('Site.Layout.ThemeGreenLight'));
                Q.addOption(select, 'yellow', Q.text('Site.Layout.ThemeYellow'));
                Q.addOption(select, 'yellow-light', Q.text('Site.Layout.ThemeYellowLight'));
                Q.addOption(select, 'black', Q.text('Site.Layout.ThemeBlack'));
                Q.addOption(select, 'black-light', Q.text('Site.Layout.ThemeBlackLight'));
                select.val(_this.getCurrentTheme());
                return _this;
            }
            ThemeSelection.prototype.getCurrentTheme = function () {
                var skinClass = Q.first(($('body').attr('class') || '').split(' '), function (x) { return Q.startsWith(x, 'skin-'); });
                if (skinClass) {
                    return skinClass.substr(5);
                }
                return 'blue';
            };
            return ThemeSelection;
        }(Serenity.Widget));
        Common.ThemeSelection = ThemeSelection;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var PdfExportHelper;
        (function (PdfExportHelper) {
            function toAutoTableColumns(srcColumns, columnStyles, columnTitles) {
                return srcColumns.map(function (src) {
                    var col = {
                        dataKey: src.id || src.field,
                        title: src.name || ''
                    };
                    if (columnTitles && columnTitles[col.dataKey] != null)
                        col.title = columnTitles[col.dataKey];
                    var style = {};
                    if ((src.cssClass || '').indexOf("align-right") >= 0)
                        style.halign = 'right';
                    else if ((src.cssClass || '').indexOf("align-center") >= 0)
                        style.halign = 'center';
                    columnStyles[col.dataKey] = style;
                    return col;
                });
            }
            function toAutoTableData(entities, keys, srcColumns) {
                var el = document.createElement('span');
                var row = 0;
                return entities.map(function (item) {
                    var dst = {};
                    for (var cell = 0; cell < srcColumns.length; cell++) {
                        var src = srcColumns[cell];
                        var fld = src.field || '';
                        var key = keys[cell];
                        var txt = void 0;
                        var html = void 0;
                        if (src.formatter) {
                            html = src.formatter(row, cell, item[fld], src, item);
                        }
                        else if (src.format) {
                            html = src.format({ row: row, cell: cell, item: item, value: item[fld] });
                        }
                        else {
                            dst[key] = item[fld];
                            continue;
                        }
                        if (!html || (html.indexOf('<') < 0 && html.indexOf('&') < 0))
                            dst[key] = html;
                        else {
                            el.innerHTML = html;
                            if (el.children.length == 1 &&
                                $(el.children[0]).is(":input")) {
                                dst[key] = $(el.children[0]).val();
                            }
                            else if (el.children.length == 1 &&
                                $(el.children).is('.check-box')) {
                                dst[key] = $(el.children).hasClass("checked") ? "X" : "";
                            }
                            else
                                dst[key] = el.textContent || '';
                        }
                    }
                    row++;
                    return dst;
                });
            }
            function exportToPdf(options) {
                var g = options.grid;
                if (!options.onViewSubmit())
                    return;
                includeAutoTable();
                var request = Q.deepClone(g.view.params);
                request.Take = 0;
                request.Skip = 0;
                var sortBy = g.view.sortBy;
                if (sortBy != null)
                    request.Sort = sortBy;
                var gridColumns = g.slickGrid.getColumns();
                gridColumns = gridColumns.filter(function (x) { return x.id !== "__select__"; });
                request.IncludeColumns = [];
                for (var _i = 0, gridColumns_1 = gridColumns; _i < gridColumns_1.length; _i++) {
                    var column = gridColumns_1[_i];
                    request.IncludeColumns.push(column.id || column.field);
                }
                Q.serviceCall({
                    url: g.view.url,
                    request: request,
                    onSuccess: function (response) {
                        var doc = new jsPDF('l', 'pt');
                        var srcColumns = gridColumns;
                        var columnStyles = {};
                        var columns = toAutoTableColumns(srcColumns, columnStyles, options.columnTitles);
                        var keys = columns.map(function (x) { return x.dataKey; });
                        var entities = response.Entities || [];
                        var data = toAutoTableData(entities, keys, srcColumns);
                        doc.setFontSize(options.titleFontSize || 10);
                        doc.setFontStyle('bold');
                        var reportTitle = options.reportTitle || g.getTitle() || "Report";
                        doc.autoTableText(reportTitle, doc.internal.pageSize.width / 2, options.titleTop || 25, { halign: 'center' });
                        var totalPagesExp = "{{T}}";
                        var pageNumbers = options.pageNumbers == null || options.pageNumbers;
                        var autoOptions = $.extend({
                            margin: { top: 25, left: 25, right: 25, bottom: pageNumbers ? 25 : 30 },
                            startY: 60,
                            styles: {
                                fontSize: 8,
                                overflow: 'linebreak',
                                cellPadding: 2,
                                valign: 'middle'
                            },
                            columnStyles: columnStyles
                        }, options.tableOptions);
                        if (pageNumbers) {
                            var footer = function (data) {
                                var str = data.pageCount;
                                // Total page number plugin only available in jspdf v1.0+
                                if (typeof doc.putTotalPages === 'function') {
                                    str = str + " / " + totalPagesExp;
                                }
                                doc.autoTableText(str, doc.internal.pageSize.width / 2, doc.internal.pageSize.height - autoOptions.margin.bottom, {
                                    halign: 'center'
                                });
                            };
                            autoOptions.afterPageContent = footer;
                        }
                        doc.autoTable(columns, data, autoOptions);
                        if (typeof doc.putTotalPages === 'function') {
                            doc.putTotalPages(totalPagesExp);
                        }
                        if (!options.output || options.output == "file") {
                            var fileName = options.reportTitle || "{0}_{1}.pdf";
                            fileName = Q.format(fileName, g.getTitle() || "report", Q.formatDate(new Date(), "yyyyMMdd_HHmm"));
                            doc.save(fileName);
                            return;
                        }
                        if (options.autoPrint)
                            doc.autoPrint();
                        var output = options.output;
                        if (output == 'newwindow' || '_blank')
                            output = 'dataurlnewwindow';
                        else if (output == 'window')
                            output = 'datauri';
                        doc.output(output);
                    }
                });
            }
            PdfExportHelper.exportToPdf = exportToPdf;
            function createToolButton(options) {
                return {
                    title: options.title || '',
                    hint: options.hint || 'PDF',
                    cssClass: 'export-pdf-button',
                    onClick: function () { return exportToPdf(options); },
                    separator: options.separator
                };
            }
            PdfExportHelper.createToolButton = createToolButton;
            function includeJsPDF() {
                if (typeof jsPDF !== "undefined")
                    return;
                var script = $("jsPDFScript");
                if (script.length > 0)
                    return;
                $("<script/>")
                    .attr("type", "text/javascript")
                    .attr("id", "jsPDFScript")
                    .attr("src", Q.resolveUrl("~/Scripts/jspdf.min.js"))
                    .appendTo(document.head);
            }
            function includeAutoTable() {
                includeJsPDF();
                if (typeof jsPDF === "undefined" ||
                    typeof jsPDF.API == "undefined" ||
                    typeof jsPDF.API.autoTable !== "undefined")
                    return;
                var script = $("jsPDFAutoTableScript");
                if (script.length > 0)
                    return;
                $("<script/>")
                    .attr("type", "text/javascript")
                    .attr("id", "jsPDFAutoTableScript")
                    .attr("src", Q.resolveUrl("~/Scripts/jspdf.plugin.autotable.min.js"))
                    .appendTo(document.head);
            }
        })(PdfExportHelper = Common.PdfExportHelper || (Common.PdfExportHelper = {}));
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var ReportDialog = (function (_super) {
            __extends(ReportDialog, _super);
            function ReportDialog(options) {
                var _this = _super.call(this, options) || this;
                _this.updateInterface();
                _this.loadReport(_this.options.reportKey);
                return _this;
            }
            ReportDialog.prototype.getDialogButtons = function () {
                return null;
            };
            ReportDialog.prototype.createPropertyGrid = function () {
                this.propertyGrid && this.byId('PropertyGrid').html('').attr('class', '');
                this.propertyGrid = new Serenity.PropertyGrid(this.byId('PropertyGrid'), {
                    idPrefix: this.idPrefix,
                    useCategories: true,
                    items: this.propertyItems
                }).init(null);
            };
            ReportDialog.prototype.loadReport = function (reportKey) {
                var _this = this;
                Q.serviceCall({
                    url: Q.resolveUrl('~/Report/Retrieve'),
                    request: {
                        ReportKey: reportKey
                    },
                    onSuccess: function (response) {
                        _this.report = response;
                        _this.element.dialog().dialog('option', 'title', _this.report.Title);
                        _this.createPropertyGrid();
                        _this.propertyGrid.load(_this.report.InitialSettings || {});
                        _this.updateInterface();
                        _this.dialogOpen();
                    }
                });
            };
            ReportDialog.prototype.updateInterface = function () {
                this.toolbar.findButton('print-preview-button')
                    .toggle(this.report && !this.report.IsDataOnlyReport);
                this.toolbar.findButton('export-pdf-button')
                    .toggle(this.report && !this.report.IsDataOnlyReport);
                this.toolbar.findButton('export-xlsx-button')
                    .toggle(this.report && this.report.IsDataOnlyReport);
            };
            ReportDialog.prototype.executeReport = function (target, ext, download) {
                if (!this.validateForm()) {
                    return;
                }
                var opt = {};
                this.propertyGrid.save(opt);
                Common.ReportHelper.execute({
                    download: download,
                    reportKey: this.report.ReportKey,
                    extension: ext,
                    target: target,
                    params: opt
                });
            };
            ReportDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                return [
                    {
                        title: 'Preview',
                        cssClass: 'print-preview-button',
                        onClick: function () { return _this.executeReport('_blank', null, false); }
                    },
                    {
                        title: 'PDF',
                        cssClass: 'export-pdf-button',
                        onClick: function () { return _this.executeReport('_blank', 'pdf', true); }
                    },
                    {
                        title: 'Excel',
                        cssClass: 'export-xlsx-button',
                        onClick: function () { return _this.executeReport('_blank', 'xlsx', true); }
                    }
                ];
            };
            return ReportDialog;
        }(Serenity.TemplatedDialog));
        Common.ReportDialog = ReportDialog;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var ReportHelper;
        (function (ReportHelper) {
            function createToolButton(options) {
                return {
                    title: Q.coalesce(options.title, 'Report'),
                    cssClass: Q.coalesce(options.cssClass, 'print-button'),
                    icon: options.icon,
                    onClick: function () {
                        ReportHelper.execute(options);
                    }
                };
            }
            ReportHelper.createToolButton = createToolButton;
            function execute(options) {
                var opt = options.getParams ? options.getParams() : options.params;
                Q.postToUrl({
                    url: '~/Report/' + (options.download ? 'Download' : 'Render'),
                    params: {
                        key: options.reportKey,
                        ext: Q.coalesce(options.extension, 'pdf'),
                        opt: opt ? $.toJSON(opt) : ''
                    },
                    target: Q.coalesce(options.target, '_blank')
                });
            }
            ReportHelper.execute = execute;
        })(ReportHelper = Common.ReportHelper || (Common.ReportHelper = {}));
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var ReportPage = (function (_super) {
            __extends(ReportPage, _super);
            function ReportPage(element) {
                var _this = _super.call(this, element) || this;
                $('.report-link', element).click(function (e) { return _this.reportLinkClick(e); });
                $('div.line', element).click(function (e) { return _this.categoryClick(e); });
                new Serenity.QuickSearchInput($('.s-QuickSearchBar input', element), {
                    onSearch: function (field, text, done) {
                        _this.updateMatchFlags(text);
                        done(true);
                    }
                });
                return _this;
            }
            ReportPage.prototype.updateMatchFlags = function (text) {
                var liList = $('.report-list', this.element).find('li').removeClass('non-match');
                text = Q.trimToNull(text);
                if (!text) {
                    liList.children('ul').hide();
                    liList.show().removeClass('expanded');
                    return;
                }
                text = Select2.util.stripDiacritics(text).toUpperCase();
                var reportItems = liList.filter('.report-item');
                reportItems.each(function (ix, e) {
                    var x = $(e);
                    var title = Select2.util.stripDiacritics(Q.coalesce(x.text(), '').toUpperCase());
                    if (title.indexOf(text) < 0) {
                        x.addClass('non-match');
                    }
                });
                var matchingItems = reportItems.not('.non-match');
                var visibles = matchingItems.parents('li').add(matchingItems);
                var nonVisibles = liList.not(visibles);
                nonVisibles.hide().addClass('non-match');
                visibles.show();
                if (visibles.length <= 100) {
                    liList.children('ul').show();
                    liList.addClass('expanded');
                }
            };
            ReportPage.prototype.categoryClick = function (e) {
                var li = $(e.target).closest('li');
                if (li.hasClass('expanded')) {
                    li.find('ul').hide('fast');
                    li.removeClass('expanded');
                    li.find('li').removeClass('expanded');
                }
                else {
                    li.addClass('expanded');
                    li.children('ul').show('fast');
                    if (li.children('ul').children('li').length === 1 && !li.children('ul').children('li').hasClass('expanded')) {
                        li.children('ul').children('li').children('.line').click();
                    }
                }
            };
            ReportPage.prototype.reportLinkClick = function (e) {
                e.preventDefault();
                new Common.ReportDialog({
                    reportKey: $(e.target).data('key')
                }).dialogOpen();
            };
            return ReportPage;
        }(Serenity.Widget));
        Common.ReportPage = ReportPage;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var ScriptInitialization;
    (function (ScriptInitialization) {
        Q.Config.responsiveDialogs = true;
        Q.Config.rootNamespaces.push('Geshotel');
    })(ScriptInitialization = Geshotel.ScriptInitialization || (Geshotel.ScriptInitialization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Common;
    (function (Common) {
        var UserPreferenceStorage = (function () {
            function UserPreferenceStorage() {
            }
            UserPreferenceStorage.prototype.getItem = function (key) {
                var value;
                Common.UserPreferenceService.Retrieve({
                    PreferenceType: "UserPreferenceStorage",
                    Name: key
                }, function (response) { return value = response.Value; }, {
                    async: false
                });
                return value;
            };
            UserPreferenceStorage.prototype.setItem = function (key, data) {
                Common.UserPreferenceService.Update({
                    PreferenceType: "UserPreferenceStorage",
                    Name: key,
                    Value: data
                });
            };
            return UserPreferenceStorage;
        }());
        Common.UserPreferenceStorage = UserPreferenceStorage;
    })(Common = Geshotel.Common || (Geshotel.Common = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var AgenciasDialog = (function (_super) {
            __extends(AgenciasDialog, _super);
            function AgenciasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.AgenciasForm(_this.idPrefix);
                return _this;
            }
            AgenciasDialog.prototype.getFormKey = function () { return Contratos.AgenciasForm.formKey; };
            AgenciasDialog.prototype.getIdProperty = function () { return Contratos.AgenciasRow.idProperty; };
            AgenciasDialog.prototype.getLocalTextPrefix = function () { return Contratos.AgenciasRow.localTextPrefix; };
            AgenciasDialog.prototype.getNameProperty = function () { return Contratos.AgenciasRow.nameProperty; };
            AgenciasDialog.prototype.getService = function () { return Contratos.AgenciasService.baseUrl; };
            return AgenciasDialog;
        }(Serenity.EntityDialog));
        AgenciasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], AgenciasDialog);
        Contratos.AgenciasDialog = AgenciasDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var AgenciasGrid = (function (_super) {
            __extends(AgenciasGrid, _super);
            function AgenciasGrid(container) {
                return _super.call(this, container) || this;
            }
            AgenciasGrid.prototype.getColumnsKey = function () { return 'Contratos.Agencias'; };
            AgenciasGrid.prototype.getDialogType = function () { return Contratos.AgenciasDialog; };
            AgenciasGrid.prototype.getIdProperty = function () { return Contratos.AgenciasRow.idProperty; };
            AgenciasGrid.prototype.getLocalTextPrefix = function () { return Contratos.AgenciasRow.localTextPrefix; };
            AgenciasGrid.prototype.getService = function () { return Contratos.AgenciasService.baseUrl; };
            return AgenciasGrid;
        }(Serenity.EntityGrid));
        AgenciasGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], AgenciasGrid);
        Contratos.AgenciasGrid = AgenciasGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ClientesDialog = (function (_super) {
            __extends(ClientesDialog, _super);
            function ClientesDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.ClientesForm(_this.idPrefix);
                return _this;
            }
            ClientesDialog.prototype.getFormKey = function () { return Contratos.ClientesForm.formKey; };
            ClientesDialog.prototype.getIdProperty = function () { return Contratos.ClientesRow.idProperty; };
            ClientesDialog.prototype.getLocalTextPrefix = function () { return Contratos.ClientesRow.localTextPrefix; };
            ClientesDialog.prototype.getNameProperty = function () { return Contratos.ClientesRow.nameProperty; };
            ClientesDialog.prototype.getService = function () { return Contratos.ClientesService.baseUrl; };
            return ClientesDialog;
        }(Serenity.EntityDialog));
        ClientesDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], ClientesDialog);
        Contratos.ClientesDialog = ClientesDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ClientesGrid = (function (_super) {
            __extends(ClientesGrid, _super);
            function ClientesGrid(container) {
                return _super.call(this, container) || this;
            }
            ClientesGrid.prototype.getColumnsKey = function () { return 'Contratos.Clientes'; };
            ClientesGrid.prototype.getDialogType = function () { return Contratos.ClientesDialog; };
            ClientesGrid.prototype.getIdProperty = function () { return Contratos.ClientesRow.idProperty; };
            ClientesGrid.prototype.getLocalTextPrefix = function () { return Contratos.ClientesRow.localTextPrefix; };
            ClientesGrid.prototype.getService = function () { return Contratos.ClientesService.baseUrl; };
            ClientesGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Contratos/Clientes/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return ClientesGrid;
        }(Serenity.EntityGrid));
        ClientesGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], ClientesGrid);
        Contratos.ClientesGrid = ClientesGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosCuposGrid = (function (_super) {
            __extends(ContratosCuposGrid, _super);
            function ContratosCuposGrid(container) {
                return _super.call(this, container) || this;
            }
            ContratosCuposGrid.prototype.getColumnsKey = function () { return 'Contratos.Cupos'; };
            ContratosCuposGrid.prototype.getIdProperty = function () { return Contratos.CuposRow.idProperty; };
            ContratosCuposGrid.prototype.getLocalTextPrefix = function () { return Contratos.CuposRow.localTextPrefix; };
            ContratosCuposGrid.prototype.getService = function () { return Contratos.CuposService.baseUrl; };
            ContratosCuposGrid.prototype.addButtonClick = function () {
                this.editItem({ clienteID: this.clienteID });
                this.editItem({ hotelID: this.hotelID });
            };
            ContratosCuposGrid.prototype.getInitialTitle = function () {
                return null;
            };
            ContratosCuposGrid.prototype.getGridCanLoad = function () {
                return true;
                //            return this.contratoID != null;
            };
            Object.defineProperty(ContratosCuposGrid.prototype, "hotelID", {
                get: function () {
                    return this._hotelID;
                },
                set: function (value) {
                    if (this._hotelID !== value) {
                        this._hotelID = value;
                        this.setEquality(Contratos.ContratosRow.Fields.HotelId, value);
                        this.refresh();
                    }
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(ContratosCuposGrid.prototype, "clienteID", {
                get: function () {
                    return this._clienteID;
                },
                set: function (value) {
                    if (this._clienteID !== value) {
                        this._clienteID = value;
                        this.setEquality(Contratos.ContratosRow.Fields.ClienteId, value);
                        this.refresh();
                    }
                },
                enumerable: true,
                configurable: true
            });
            return ContratosCuposGrid;
        }(Serenity.EntityGrid));
        ContratosCuposGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], ContratosCuposGrid);
        Contratos.ContratosCuposGrid = ContratosCuposGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosDialog = (function (_super) {
            __extends(ContratosDialog, _super);
            function ContratosDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Contratos.ContratosForm(_this.idPrefix);
                _this.LineasGrid = new Contratos.ContratosLineasGrid(_this.byId("LineasGrid"));
                _this.CuposGrid = new Contratos.ContratosCuposGrid(_this.byId("CuposGrid"));
                _this.tabs.on('tabsactivate', function (e, i) {
                    _this.arrange();
                });
                return _this;
            }
            ContratosDialog.prototype.getFormKey = function () { return Contratos.ContratosForm.formKey; };
            ContratosDialog.prototype.getIdProperty = function () { return Contratos.ContratosRow.idProperty; };
            ContratosDialog.prototype.getLocalTextPrefix = function () { return Contratos.ContratosRow.localTextPrefix; };
            ContratosDialog.prototype.getNameProperty = function () { return Contratos.ContratosRow.nameProperty; };
            ContratosDialog.prototype.getService = function () { return Contratos.ContratosService.baseUrl; };
            return ContratosDialog;
        }(Serenity.EntityDialog));
        ContratosDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], ContratosDialog);
        Contratos.ContratosDialog = ContratosDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosGrid = (function (_super) {
            __extends(ContratosGrid, _super);
            function ContratosGrid(container) {
                return _super.call(this, container) || this;
            }
            ContratosGrid.prototype.getColumnsKey = function () { return 'Contratos.Contratos'; };
            ContratosGrid.prototype.getDialogType = function () { return Contratos.ContratosDialog; };
            ContratosGrid.prototype.getIdProperty = function () { return Contratos.ContratosRow.idProperty; };
            ContratosGrid.prototype.getLocalTextPrefix = function () { return Contratos.ContratosRow.localTextPrefix; };
            ContratosGrid.prototype.getService = function () { return Contratos.ContratosService.baseUrl; };
            return ContratosGrid;
        }(Serenity.EntityGrid));
        ContratosGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], ContratosGrid);
        Contratos.ContratosGrid = ContratosGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ContratosLineasGrid = (function (_super) {
            __extends(ContratosLineasGrid, _super);
            function ContratosLineasGrid(container) {
                return _super.call(this, container) || this;
            }
            ContratosLineasGrid.prototype.getColumnsKey = function () { return 'Contratos.Lineas'; };
            ContratosLineasGrid.prototype.getIdProperty = function () { return Contratos.LineasRow.idProperty; };
            ContratosLineasGrid.prototype.getLocalTextPrefix = function () { return Contratos.LineasRow.localTextPrefix; };
            ContratosLineasGrid.prototype.getService = function () { return Contratos.LineasService.baseUrl; };
            ContratosLineasGrid.prototype.addButtonClick = function () {
                this.editItem({ contratoID: this.contratoID });
            };
            ContratosLineasGrid.prototype.getInitialTitle = function () {
                return null;
            };
            ContratosLineasGrid.prototype.getGridCanLoad = function () {
                return true;
                //            return this.contratoID != null;
            };
            Object.defineProperty(ContratosLineasGrid.prototype, "contratoID", {
                get: function () {
                    return this._contratoID;
                },
                set: function (value) {
                    if (this._contratoID !== value) {
                        this._contratoID = value;
                        this.setEquality(Contratos.LineasRow.Fields.ContratoId, value);
                        this.refresh();
                    }
                },
                enumerable: true,
                configurable: true
            });
            return ContratosLineasGrid;
        }(Serenity.EntityGrid));
        ContratosLineasGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], ContratosLineasGrid);
        Contratos.ContratosLineasGrid = ContratosLineasGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var CuposDialog = (function (_super) {
            __extends(CuposDialog, _super);
            function CuposDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.CuposForm(_this.idPrefix);
                return _this;
            }
            CuposDialog.prototype.getFormKey = function () { return Contratos.CuposForm.formKey; };
            CuposDialog.prototype.getIdProperty = function () { return Contratos.CuposRow.idProperty; };
            CuposDialog.prototype.getLocalTextPrefix = function () { return Contratos.CuposRow.localTextPrefix; };
            CuposDialog.prototype.getService = function () { return Contratos.CuposService.baseUrl; };
            return CuposDialog;
        }(Serenity.EntityDialog));
        CuposDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], CuposDialog);
        Contratos.CuposDialog = CuposDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var CuposGrid = (function (_super) {
            __extends(CuposGrid, _super);
            function CuposGrid(container) {
                return _super.call(this, container) || this;
            }
            CuposGrid.prototype.getColumnsKey = function () { return 'Contratos.Cupos'; };
            CuposGrid.prototype.getDialogType = function () { return Contratos.CuposDialog; };
            CuposGrid.prototype.getIdProperty = function () { return Contratos.CuposRow.idProperty; };
            CuposGrid.prototype.getLocalTextPrefix = function () { return Contratos.CuposRow.localTextPrefix; };
            CuposGrid.prototype.getService = function () { return Contratos.CuposService.baseUrl; };
            return CuposGrid;
        }(Serenity.EntityGrid));
        CuposGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], CuposGrid);
        Contratos.CuposGrid = CuposGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var EdadesDialog = (function (_super) {
            __extends(EdadesDialog, _super);
            function EdadesDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.EdadesForm(_this.idPrefix);
                return _this;
            }
            EdadesDialog.prototype.getFormKey = function () { return Contratos.EdadesForm.formKey; };
            EdadesDialog.prototype.getIdProperty = function () { return Contratos.EdadesRow.idProperty; };
            EdadesDialog.prototype.getLocalTextPrefix = function () { return Contratos.EdadesRow.localTextPrefix; };
            EdadesDialog.prototype.getService = function () { return Contratos.EdadesService.baseUrl; };
            return EdadesDialog;
        }(Serenity.EntityDialog));
        EdadesDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], EdadesDialog);
        Contratos.EdadesDialog = EdadesDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var EdadesGrid = (function (_super) {
            __extends(EdadesGrid, _super);
            function EdadesGrid(container) {
                return _super.call(this, container) || this;
            }
            EdadesGrid.prototype.getColumnsKey = function () { return 'Contratos.Edades'; };
            EdadesGrid.prototype.getDialogType = function () { return Contratos.EdadesDialog; };
            EdadesGrid.prototype.getIdProperty = function () { return Contratos.EdadesRow.idProperty; };
            EdadesGrid.prototype.getLocalTextPrefix = function () { return Contratos.EdadesRow.localTextPrefix; };
            EdadesGrid.prototype.getService = function () { return Contratos.EdadesService.baseUrl; };
            return EdadesGrid;
        }(Serenity.EntityGrid));
        EdadesGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], EdadesGrid);
        Contratos.EdadesGrid = EdadesGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var LineasDialog = (function (_super) {
            __extends(LineasDialog, _super);
            function LineasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.LineasForm(_this.idPrefix);
                return _this;
            }
            LineasDialog.prototype.getFormKey = function () { return Contratos.LineasForm.formKey; };
            LineasDialog.prototype.getIdProperty = function () { return Contratos.LineasRow.idProperty; };
            LineasDialog.prototype.getLocalTextPrefix = function () { return Contratos.LineasRow.localTextPrefix; };
            LineasDialog.prototype.getService = function () { return Contratos.LineasService.baseUrl; };
            return LineasDialog;
        }(Serenity.EntityDialog));
        LineasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], LineasDialog);
        Contratos.LineasDialog = LineasDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var LineasGrid = (function (_super) {
            __extends(LineasGrid, _super);
            function LineasGrid(container) {
                return _super.call(this, container) || this;
            }
            LineasGrid.prototype.getColumnsKey = function () { return 'Contratos.Lineas'; };
            LineasGrid.prototype.getDialogType = function () { return Contratos.LineasDialog; };
            LineasGrid.prototype.getIdProperty = function () { return Contratos.LineasRow.idProperty; };
            LineasGrid.prototype.getLocalTextPrefix = function () { return Contratos.LineasRow.localTextPrefix; };
            LineasGrid.prototype.getService = function () { return Contratos.LineasService.baseUrl; };
            return LineasGrid;
        }(Serenity.EntityGrid));
        LineasGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], LineasGrid);
        Contratos.LineasGrid = LineasGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var MercadosDialog = (function (_super) {
            __extends(MercadosDialog, _super);
            function MercadosDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.MercadosForm(_this.idPrefix);
                return _this;
            }
            MercadosDialog.prototype.getFormKey = function () { return Contratos.MercadosForm.formKey; };
            MercadosDialog.prototype.getIdProperty = function () { return Contratos.MercadosRow.idProperty; };
            MercadosDialog.prototype.getLocalTextPrefix = function () { return Contratos.MercadosRow.localTextPrefix; };
            MercadosDialog.prototype.getNameProperty = function () { return Contratos.MercadosRow.nameProperty; };
            MercadosDialog.prototype.getService = function () { return Contratos.MercadosService.baseUrl; };
            return MercadosDialog;
        }(Serenity.EntityDialog));
        MercadosDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MercadosDialog);
        Contratos.MercadosDialog = MercadosDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var MercadosGrid = (function (_super) {
            __extends(MercadosGrid, _super);
            function MercadosGrid(container) {
                return _super.call(this, container) || this;
            }
            MercadosGrid.prototype.getColumnsKey = function () { return 'Contratos.Mercados'; };
            MercadosGrid.prototype.getDialogType = function () { return Contratos.MercadosDialog; };
            MercadosGrid.prototype.getIdProperty = function () { return Contratos.MercadosRow.idProperty; };
            MercadosGrid.prototype.getLocalTextPrefix = function () { return Contratos.MercadosRow.localTextPrefix; };
            MercadosGrid.prototype.getService = function () { return Contratos.MercadosService.baseUrl; };
            return MercadosGrid;
        }(Serenity.EntityGrid));
        MercadosGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MercadosGrid);
        Contratos.MercadosGrid = MercadosGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasDialog = (function (_super) {
            __extends(OfertasDialog, _super);
            function OfertasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.OfertasForm(_this.idPrefix);
                return _this;
            }
            OfertasDialog.prototype.getFormKey = function () { return Contratos.OfertasForm.formKey; };
            OfertasDialog.prototype.getIdProperty = function () { return Contratos.OfertasRow.idProperty; };
            OfertasDialog.prototype.getLocalTextPrefix = function () { return Contratos.OfertasRow.localTextPrefix; };
            OfertasDialog.prototype.getNameProperty = function () { return Contratos.OfertasRow.nameProperty; };
            OfertasDialog.prototype.getService = function () { return Contratos.OfertasService.baseUrl; };
            return OfertasDialog;
        }(Serenity.EntityDialog));
        OfertasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], OfertasDialog);
        Contratos.OfertasDialog = OfertasDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasGrid = (function (_super) {
            __extends(OfertasGrid, _super);
            function OfertasGrid(container) {
                return _super.call(this, container) || this;
            }
            OfertasGrid.prototype.getColumnsKey = function () { return 'Contratos.Ofertas'; };
            OfertasGrid.prototype.getDialogType = function () { return Contratos.OfertasDialog; };
            OfertasGrid.prototype.getIdProperty = function () { return Contratos.OfertasRow.idProperty; };
            OfertasGrid.prototype.getLocalTextPrefix = function () { return Contratos.OfertasRow.localTextPrefix; };
            OfertasGrid.prototype.getService = function () { return Contratos.OfertasService.baseUrl; };
            return OfertasGrid;
        }(Serenity.EntityGrid));
        OfertasGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], OfertasGrid);
        Contratos.OfertasGrid = OfertasGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasRejillasDialog = (function (_super) {
            __extends(OfertasRejillasDialog, _super);
            function OfertasRejillasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.OfertasRejillasForm(_this.idPrefix);
                return _this;
            }
            OfertasRejillasDialog.prototype.getFormKey = function () { return Contratos.OfertasRejillasForm.formKey; };
            OfertasRejillasDialog.prototype.getIdProperty = function () { return Contratos.OfertasRejillasRow.idProperty; };
            OfertasRejillasDialog.prototype.getLocalTextPrefix = function () { return Contratos.OfertasRejillasRow.localTextPrefix; };
            OfertasRejillasDialog.prototype.getService = function () { return Contratos.OfertasRejillasService.baseUrl; };
            return OfertasRejillasDialog;
        }(Serenity.EntityDialog));
        OfertasRejillasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], OfertasRejillasDialog);
        Contratos.OfertasRejillasDialog = OfertasRejillasDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var OfertasRejillasGrid = (function (_super) {
            __extends(OfertasRejillasGrid, _super);
            function OfertasRejillasGrid(container) {
                return _super.call(this, container) || this;
            }
            OfertasRejillasGrid.prototype.getColumnsKey = function () { return 'Contratos.OfertasRejillas'; };
            OfertasRejillasGrid.prototype.getDialogType = function () { return Contratos.OfertasRejillasDialog; };
            OfertasRejillasGrid.prototype.getIdProperty = function () { return Contratos.OfertasRejillasRow.idProperty; };
            OfertasRejillasGrid.prototype.getLocalTextPrefix = function () { return Contratos.OfertasRejillasRow.localTextPrefix; };
            OfertasRejillasGrid.prototype.getService = function () { return Contratos.OfertasRejillasService.baseUrl; };
            return OfertasRejillasGrid;
        }(Serenity.EntityGrid));
        OfertasRejillasGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], OfertasRejillasGrid);
        Contratos.OfertasRejillasGrid = OfertasRejillasGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ReleasesDialog = (function (_super) {
            __extends(ReleasesDialog, _super);
            function ReleasesDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.ReleasesForm(_this.idPrefix);
                return _this;
            }
            ReleasesDialog.prototype.getFormKey = function () { return Contratos.ReleasesForm.formKey; };
            ReleasesDialog.prototype.getIdProperty = function () { return Contratos.ReleasesRow.idProperty; };
            ReleasesDialog.prototype.getLocalTextPrefix = function () { return Contratos.ReleasesRow.localTextPrefix; };
            ReleasesDialog.prototype.getNameProperty = function () { return Contratos.ReleasesRow.nameProperty; };
            ReleasesDialog.prototype.getService = function () { return Contratos.ReleasesService.baseUrl; };
            return ReleasesDialog;
        }(Serenity.EntityDialog));
        ReleasesDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], ReleasesDialog);
        Contratos.ReleasesDialog = ReleasesDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var ReleasesGrid = (function (_super) {
            __extends(ReleasesGrid, _super);
            function ReleasesGrid(container) {
                return _super.call(this, container) || this;
            }
            ReleasesGrid.prototype.getColumnsKey = function () { return 'Contratos.Releases'; };
            ReleasesGrid.prototype.getDialogType = function () { return Contratos.ReleasesDialog; };
            ReleasesGrid.prototype.getIdProperty = function () { return Contratos.ReleasesRow.idProperty; };
            ReleasesGrid.prototype.getLocalTextPrefix = function () { return Contratos.ReleasesRow.localTextPrefix; };
            ReleasesGrid.prototype.getService = function () { return Contratos.ReleasesService.baseUrl; };
            return ReleasesGrid;
        }(Serenity.EntityGrid));
        ReleasesGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], ReleasesGrid);
        Contratos.ReleasesGrid = ReleasesGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TemporadasDialog = (function (_super) {
            __extends(TemporadasDialog, _super);
            function TemporadasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Contratos.TemporadasForm(_this.idPrefix);
                return _this;
            }
            TemporadasDialog.prototype.getFormKey = function () { return Contratos.TemporadasForm.formKey; };
            TemporadasDialog.prototype.getIdProperty = function () { return Contratos.TemporadasRow.idProperty; };
            TemporadasDialog.prototype.getLocalTextPrefix = function () { return Contratos.TemporadasRow.localTextPrefix; };
            TemporadasDialog.prototype.getNameProperty = function () { return Contratos.TemporadasRow.nameProperty; };
            TemporadasDialog.prototype.getService = function () { return Contratos.TemporadasService.baseUrl; };
            return TemporadasDialog;
        }(Serenity.EntityDialog));
        TemporadasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TemporadasDialog);
        Contratos.TemporadasDialog = TemporadasDialog;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Contratos;
    (function (Contratos) {
        var TemporadasGrid = (function (_super) {
            __extends(TemporadasGrid, _super);
            function TemporadasGrid(container) {
                return _super.call(this, container) || this;
            }
            TemporadasGrid.prototype.getColumnsKey = function () { return 'Contratos.Temporadas'; };
            TemporadasGrid.prototype.getDialogType = function () { return Contratos.TemporadasDialog; };
            TemporadasGrid.prototype.getIdProperty = function () { return Contratos.TemporadasRow.idProperty; };
            TemporadasGrid.prototype.getLocalTextPrefix = function () { return Contratos.TemporadasRow.localTextPrefix; };
            TemporadasGrid.prototype.getService = function () { return Contratos.TemporadasService.baseUrl; };
            return TemporadasGrid;
        }(Serenity.EntityGrid));
        TemporadasGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TemporadasGrid);
        Contratos.TemporadasGrid = TemporadasGrid;
    })(Contratos = Geshotel.Contratos || (Geshotel.Contratos = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDialog = (function (_super) {
            __extends(MeetingDialog, _super);
            function MeetingDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Meeting.MeetingForm(_this.idPrefix);
                _this.agendaGrid = new Meeting.MeetingAgendaGrid(_this.byId('AgendaGrid'));
                _this.decisionGrid = new Meeting.MeetingDecisionGrid(_this.byId('DecisionGrid'));
                _this.element.closest('.ui-dialog').find('.ui-dialog-titlebar-maximize').click();
                _this.form.EndDate.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.EndDate.valueAsDate != null &&
                        _this.form.StartDate.valueAsDate != null &&
                        _this.form.StartDate.valueAsDate > _this.form.EndDate.valueAsDate) {
                        return "End Date can't be earlier than Start Date";
                    }
                    return null;
                });
                return _this;
            }
            MeetingDialog.prototype.getFormKey = function () { return Meeting.MeetingForm.formKey; };
            MeetingDialog.prototype.getIdProperty = function () { return Meeting.MeetingRow.idProperty; };
            MeetingDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingRow.localTextPrefix; };
            MeetingDialog.prototype.getNameProperty = function () { return Meeting.MeetingRow.nameProperty; };
            MeetingDialog.prototype.getService = function () { return Meeting.MeetingService.baseUrl; };
            MeetingDialog.prototype.arrange = function () {
                _super.prototype.arrange.call(this);
                var attendeeGrid = this.form.AttendeeList.element.find('.grid-container');
                attendeeGrid.css('height', Math.max(150, this.element.height() - attendeeGrid.position().top - 15) + 'px')
                    .triggerHandler('layout');
            };
            MeetingDialog.prototype.loadEntity = function (entity) {
                _super.prototype.loadEntity.call(this, entity);
                Serenity.TabsExtensions.setDisabled(this.tabs, 'Agenda', this.isNewOrDeleted());
                Serenity.TabsExtensions.setDisabled(this.tabs, 'Decision', this.isNewOrDeleted());
                //this.agendaGrid.customerID = entity.CustomerID;
            };
            return MeetingDialog;
        }(Serenity.EntityDialog));
        MeetingDialog = __decorate([
            Serenity.Decorators.maximizable(),
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingDialog);
        Meeting.MeetingDialog = MeetingDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingGrid = (function (_super) {
            __extends(MeetingGrid, _super);
            function MeetingGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingGrid.prototype.getColumnsKey = function () { return 'Meeting.Meeting'; };
            MeetingGrid.prototype.getDialogType = function () { return Meeting.MeetingDialog; };
            MeetingGrid.prototype.getIdProperty = function () { return Meeting.MeetingRow.idProperty; };
            MeetingGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingRow.localTextPrefix; };
            MeetingGrid.prototype.getService = function () { return Meeting.MeetingService.baseUrl; };
            return MeetingGrid;
        }(Serenity.EntityGrid));
        MeetingGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingGrid);
        Meeting.MeetingGrid = MeetingGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaDialog = (function (_super) {
            __extends(MeetingAgendaDialog, _super);
            function MeetingAgendaDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingAgendaForm(_this.idPrefix);
                return _this;
            }
            MeetingAgendaDialog.prototype.getFormKey = function () { return Meeting.MeetingAgendaForm.formKey; };
            MeetingAgendaDialog.prototype.getIdProperty = function () { return Meeting.MeetingAgendaRow.idProperty; };
            MeetingAgendaDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAgendaRow.localTextPrefix; };
            MeetingAgendaDialog.prototype.getNameProperty = function () { return Meeting.MeetingAgendaRow.nameProperty; };
            MeetingAgendaDialog.prototype.getService = function () { return Meeting.MeetingAgendaService.baseUrl; };
            return MeetingAgendaDialog;
        }(Serenity.EntityDialog));
        MeetingAgendaDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingAgendaDialog);
        Meeting.MeetingAgendaDialog = MeetingAgendaDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaGrid = (function (_super) {
            __extends(MeetingAgendaGrid, _super);
            function MeetingAgendaGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingAgendaGrid.prototype.getColumnsKey = function () { return 'Meeting.MeetingAgenda'; };
            MeetingAgendaGrid.prototype.getDialogType = function () { return Meeting.MeetingAgendaDialog; };
            MeetingAgendaGrid.prototype.getIdProperty = function () { return Meeting.MeetingAgendaRow.idProperty; };
            MeetingAgendaGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAgendaRow.localTextPrefix; };
            MeetingAgendaGrid.prototype.getService = function () { return Meeting.MeetingAgendaService.baseUrl; };
            MeetingAgendaGrid.prototype.addButtonClick = function () {
                this.editItem({ MeetingId: this.meetingId });
            };
            MeetingAgendaGrid.prototype.getInitialTitle = function () {
                return null;
            };
            MeetingAgendaGrid.prototype.getGridCanLoad = function () {
                return _super.prototype.getGridCanLoad.call(this) && !!this.meetingId;
            };
            Object.defineProperty(MeetingAgendaGrid.prototype, "meetingId", {
                get: function () {
                    return this._meetingId;
                },
                set: function (value) {
                    if (this._meetingId !== value) {
                        this._meetingId = value;
                        this.setEquality('MeetingId', value);
                        this.refresh();
                    }
                },
                enumerable: true,
                configurable: true
            });
            return MeetingAgendaGrid;
        }(Serenity.EntityGrid));
        MeetingAgendaGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingAgendaGrid);
        Meeting.MeetingAgendaGrid = MeetingAgendaGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaRelevantDialog = (function (_super) {
            __extends(MeetingAgendaRelevantDialog, _super);
            function MeetingAgendaRelevantDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingAgendaRelevantForm(_this.idPrefix);
                return _this;
            }
            MeetingAgendaRelevantDialog.prototype.getFormKey = function () { return Meeting.MeetingAgendaRelevantForm.formKey; };
            MeetingAgendaRelevantDialog.prototype.getIdProperty = function () { return Meeting.MeetingAgendaRelevantRow.idProperty; };
            MeetingAgendaRelevantDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAgendaRelevantRow.localTextPrefix; };
            MeetingAgendaRelevantDialog.prototype.getService = function () { return Meeting.MeetingAgendaRelevantService.baseUrl; };
            return MeetingAgendaRelevantDialog;
        }(Serenity.EntityDialog));
        MeetingAgendaRelevantDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingAgendaRelevantDialog);
        Meeting.MeetingAgendaRelevantDialog = MeetingAgendaRelevantDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaRelevantGrid = (function (_super) {
            __extends(MeetingAgendaRelevantGrid, _super);
            function MeetingAgendaRelevantGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingAgendaRelevantGrid.prototype.getColumnsKey = function () { return 'Meeting.MeetingAgendaRelevant'; };
            MeetingAgendaRelevantGrid.prototype.getDialogType = function () { return Meeting.MeetingAgendaRelevantDialog; };
            MeetingAgendaRelevantGrid.prototype.getIdProperty = function () { return Meeting.MeetingAgendaRelevantRow.idProperty; };
            MeetingAgendaRelevantGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAgendaRelevantRow.localTextPrefix; };
            MeetingAgendaRelevantGrid.prototype.getService = function () { return Meeting.MeetingAgendaRelevantService.baseUrl; };
            return MeetingAgendaRelevantGrid;
        }(Serenity.EntityGrid));
        MeetingAgendaRelevantGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingAgendaRelevantGrid);
        Meeting.MeetingAgendaRelevantGrid = MeetingAgendaRelevantGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaTypeDialog = (function (_super) {
            __extends(MeetingAgendaTypeDialog, _super);
            function MeetingAgendaTypeDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingAgendaTypeForm(_this.idPrefix);
                return _this;
            }
            MeetingAgendaTypeDialog.prototype.getFormKey = function () { return Meeting.MeetingAgendaTypeForm.formKey; };
            MeetingAgendaTypeDialog.prototype.getIdProperty = function () { return Meeting.MeetingAgendaTypeRow.idProperty; };
            MeetingAgendaTypeDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAgendaTypeRow.localTextPrefix; };
            MeetingAgendaTypeDialog.prototype.getNameProperty = function () { return Meeting.MeetingAgendaTypeRow.nameProperty; };
            MeetingAgendaTypeDialog.prototype.getService = function () { return Meeting.MeetingAgendaTypeService.baseUrl; };
            return MeetingAgendaTypeDialog;
        }(Serenity.EntityDialog));
        MeetingAgendaTypeDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingAgendaTypeDialog);
        Meeting.MeetingAgendaTypeDialog = MeetingAgendaTypeDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAgendaTypeGrid = (function (_super) {
            __extends(MeetingAgendaTypeGrid, _super);
            function MeetingAgendaTypeGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingAgendaTypeGrid.prototype.getColumnsKey = function () { return 'Meeting.MeetingAgendaType'; };
            MeetingAgendaTypeGrid.prototype.getDialogType = function () { return Meeting.MeetingAgendaTypeDialog; };
            MeetingAgendaTypeGrid.prototype.getIdProperty = function () { return Meeting.MeetingAgendaTypeRow.idProperty; };
            MeetingAgendaTypeGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAgendaTypeRow.localTextPrefix; };
            MeetingAgendaTypeGrid.prototype.getService = function () { return Meeting.MeetingAgendaTypeService.baseUrl; };
            return MeetingAgendaTypeGrid;
        }(Serenity.EntityGrid));
        MeetingAgendaTypeGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingAgendaTypeGrid);
        Meeting.MeetingAgendaTypeGrid = MeetingAgendaTypeGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAttendeeDialog = (function (_super) {
            __extends(MeetingAttendeeDialog, _super);
            function MeetingAttendeeDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingAttendeeForm(_this.idPrefix);
                return _this;
            }
            MeetingAttendeeDialog.prototype.getFormKey = function () { return Meeting.MeetingAttendeeForm.formKey; };
            MeetingAttendeeDialog.prototype.getIdProperty = function () { return Meeting.MeetingAttendeeRow.idProperty; };
            MeetingAttendeeDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAttendeeRow.localTextPrefix; };
            return MeetingAttendeeDialog;
        }(Geshotel.Common.GridEditorDialog));
        MeetingAttendeeDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingAttendeeDialog);
        Meeting.MeetingAttendeeDialog = MeetingAttendeeDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
/// <reference path="../../common/helpers/grideditorbase.ts" />
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingAttendeeEditor = (function (_super) {
            __extends(MeetingAttendeeEditor, _super);
            function MeetingAttendeeEditor(container) {
                var _this = _super.call(this, container) || this;
                _this.slickContainer.on('change', 'select', function (e) {
                    var cell = _this.slickGrid.getCellFromEvent(e);
                    if (!cell)
                        return;
                    var item = _this.itemAt(cell.row);
                    var field = _this.slickGrid.getColumns()[cell.cell].field;
                    item[field] = Q.toId($(e.target).val());
                    _this.view.updateItem(_this.id(item), item);
                });
                return _this;
            }
            MeetingAttendeeEditor.prototype.getColumnsKey = function () { return 'Meeting.MeetingAttendee'; };
            MeetingAttendeeEditor.prototype.getDialogType = function () { return Meeting.MeetingAttendeeDialog; };
            MeetingAttendeeEditor.prototype.getLocalTextPrefix = function () { return Meeting.MeetingAttendeeRow.localTextPrefix; };
            MeetingAttendeeEditor.prototype.getButtons = function () {
                return [];
            };
            MeetingAttendeeEditor.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                Serenity.Widget.create({
                    type: Serenity.LookupEditor,
                    options: {
                        lookupKey: Geshotel.Organization.ContactRow.lookupKey
                    },
                    element: function (e) { return e.attr('placeholder', '--select contact to add--').appendTo(_this.toolbar.element); },
                    init: function (w) { return w.changeSelect2(function (x) {
                        if (Q.isEmptyOrNull(w.value))
                            return;
                        var contact = Geshotel.Organization.ContactRow.getLookup().itemById[Q.toId(w.value)];
                        w.value = null;
                        if (!contact)
                            return;
                        if (Q.any(_this.getItems(), function (i) { return i.ContactId == contact.ContactId; })) {
                            Q.notifyWarning("Contact is already in attendee list!");
                            return;
                        }
                        var item = {
                            ContactId: contact.ContactId,
                            ContactFullName: contact.FullName,
                            AttendeeType: Meeting.MeetingAttendeeType.Attendee,
                            AttendanceStatus: Meeting.MeetingAttendanceStatus.NotSet
                        };
                        _this.setNewId(item);
                        var items = _this.getItems().slice();
                        items.push(item);
                        items.sort(function (a, b) { return Q.turkishLocaleCompare(a.ContactFullName, b.ContactFullName); });
                        _this.setItems(items);
                    }); }
                });
            };
            MeetingAttendeeEditor.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                columns.unshift({
                    field: 'Remove Attendee',
                    name: '',
                    format: function (ctx) { return '<a class="inline-action delete-row" title="delete">' +
                        '<i class="fa fa-times text-red"></i></a>'; },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });
                return columns;
            };
            MeetingAttendeeEditor.prototype.onClick = function (e, row, cell) {
                _super.prototype.onClick.call(this, e, row, cell);
                if (e.isDefaultPrevented())
                    return;
                var item = this.itemAt(row);
                var target = $(e.target);
                if (target.parent().hasClass('inline-action'))
                    target = target.parent();
                if (target.hasClass('inline-action')) {
                    e.preventDefault();
                    if (target.hasClass('delete-row')) {
                        var items = this.getItems();
                        items.splice(row, 1);
                        this.setItems(items);
                    }
                }
            };
            return MeetingAttendeeEditor;
        }(Geshotel.Common.GridEditorBase));
        MeetingAttendeeEditor = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingAttendeeEditor);
        Meeting.MeetingAttendeeEditor = MeetingAttendeeEditor;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionDialog = (function (_super) {
            __extends(MeetingDecisionDialog, _super);
            function MeetingDecisionDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingDecisionForm(_this.idPrefix);
                return _this;
            }
            MeetingDecisionDialog.prototype.getFormKey = function () { return Meeting.MeetingDecisionForm.formKey; };
            MeetingDecisionDialog.prototype.getIdProperty = function () { return Meeting.MeetingDecisionRow.idProperty; };
            MeetingDecisionDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingDecisionRow.localTextPrefix; };
            MeetingDecisionDialog.prototype.getNameProperty = function () { return Meeting.MeetingDecisionRow.nameProperty; };
            MeetingDecisionDialog.prototype.getService = function () { return Meeting.MeetingDecisionService.baseUrl; };
            return MeetingDecisionDialog;
        }(Serenity.EntityDialog));
        MeetingDecisionDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingDecisionDialog);
        Meeting.MeetingDecisionDialog = MeetingDecisionDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionGrid = (function (_super) {
            __extends(MeetingDecisionGrid, _super);
            function MeetingDecisionGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingDecisionGrid.prototype.getColumnsKey = function () { return 'Meeting.MeetingDecision'; };
            MeetingDecisionGrid.prototype.getDialogType = function () { return Meeting.MeetingDecisionDialog; };
            MeetingDecisionGrid.prototype.getIdProperty = function () { return Meeting.MeetingDecisionRow.idProperty; };
            MeetingDecisionGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingDecisionRow.localTextPrefix; };
            MeetingDecisionGrid.prototype.getService = function () { return Meeting.MeetingDecisionService.baseUrl; };
            MeetingDecisionGrid.prototype.addButtonClick = function () {
                this.editItem({ MeetingId: this.meetingId });
            };
            MeetingDecisionGrid.prototype.getInitialTitle = function () {
                return null;
            };
            MeetingDecisionGrid.prototype.getGridCanLoad = function () {
                return _super.prototype.getGridCanLoad.call(this) && !!this.meetingId;
            };
            Object.defineProperty(MeetingDecisionGrid.prototype, "meetingId", {
                get: function () {
                    return this._meetingId;
                },
                set: function (value) {
                    if (this._meetingId !== value) {
                        this._meetingId = value;
                        this.setEquality('MeetingId', value);
                        this.refresh();
                    }
                },
                enumerable: true,
                configurable: true
            });
            return MeetingDecisionGrid;
        }(Serenity.EntityGrid));
        MeetingDecisionGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingDecisionGrid);
        Meeting.MeetingDecisionGrid = MeetingDecisionGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionRelevantDialog = (function (_super) {
            __extends(MeetingDecisionRelevantDialog, _super);
            function MeetingDecisionRelevantDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingDecisionRelevantForm(_this.idPrefix);
                return _this;
            }
            MeetingDecisionRelevantDialog.prototype.getFormKey = function () { return Meeting.MeetingDecisionRelevantForm.formKey; };
            MeetingDecisionRelevantDialog.prototype.getIdProperty = function () { return Meeting.MeetingDecisionRelevantRow.idProperty; };
            MeetingDecisionRelevantDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingDecisionRelevantRow.localTextPrefix; };
            MeetingDecisionRelevantDialog.prototype.getService = function () { return Meeting.MeetingDecisionRelevantService.baseUrl; };
            return MeetingDecisionRelevantDialog;
        }(Serenity.EntityDialog));
        MeetingDecisionRelevantDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingDecisionRelevantDialog);
        Meeting.MeetingDecisionRelevantDialog = MeetingDecisionRelevantDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingDecisionRelevantGrid = (function (_super) {
            __extends(MeetingDecisionRelevantGrid, _super);
            function MeetingDecisionRelevantGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingDecisionRelevantGrid.prototype.getColumnsKey = function () { return 'Meeting.MeetingDecisionRelevant'; };
            MeetingDecisionRelevantGrid.prototype.getDialogType = function () { return Meeting.MeetingDecisionRelevantDialog; };
            MeetingDecisionRelevantGrid.prototype.getIdProperty = function () { return Meeting.MeetingDecisionRelevantRow.idProperty; };
            MeetingDecisionRelevantGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingDecisionRelevantRow.localTextPrefix; };
            MeetingDecisionRelevantGrid.prototype.getService = function () { return Meeting.MeetingDecisionRelevantService.baseUrl; };
            return MeetingDecisionRelevantGrid;
        }(Serenity.EntityGrid));
        MeetingDecisionRelevantGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingDecisionRelevantGrid);
        Meeting.MeetingDecisionRelevantGrid = MeetingDecisionRelevantGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingLocationDialog = (function (_super) {
            __extends(MeetingLocationDialog, _super);
            function MeetingLocationDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingLocationForm(_this.idPrefix);
                return _this;
            }
            MeetingLocationDialog.prototype.getFormKey = function () { return Meeting.MeetingLocationForm.formKey; };
            MeetingLocationDialog.prototype.getIdProperty = function () { return Meeting.MeetingLocationRow.idProperty; };
            MeetingLocationDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingLocationRow.localTextPrefix; };
            MeetingLocationDialog.prototype.getNameProperty = function () { return Meeting.MeetingLocationRow.nameProperty; };
            MeetingLocationDialog.prototype.getService = function () { return Meeting.MeetingLocationService.baseUrl; };
            return MeetingLocationDialog;
        }(Serenity.EntityDialog));
        MeetingLocationDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingLocationDialog);
        Meeting.MeetingLocationDialog = MeetingLocationDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingLocationGrid = (function (_super) {
            __extends(MeetingLocationGrid, _super);
            function MeetingLocationGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingLocationGrid.prototype.getColumnsKey = function () { return 'Meeting.MeetingLocation'; };
            MeetingLocationGrid.prototype.getDialogType = function () { return Meeting.MeetingLocationDialog; };
            MeetingLocationGrid.prototype.getIdProperty = function () { return Meeting.MeetingLocationRow.idProperty; };
            MeetingLocationGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingLocationRow.localTextPrefix; };
            MeetingLocationGrid.prototype.getService = function () { return Meeting.MeetingLocationService.baseUrl; };
            return MeetingLocationGrid;
        }(Serenity.EntityGrid));
        MeetingLocationGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingLocationGrid);
        Meeting.MeetingLocationGrid = MeetingLocationGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingTypeDialog = (function (_super) {
            __extends(MeetingTypeDialog, _super);
            function MeetingTypeDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Meeting.MeetingTypeForm(_this.idPrefix);
                return _this;
            }
            MeetingTypeDialog.prototype.getFormKey = function () { return Meeting.MeetingTypeForm.formKey; };
            MeetingTypeDialog.prototype.getIdProperty = function () { return Meeting.MeetingTypeRow.idProperty; };
            MeetingTypeDialog.prototype.getLocalTextPrefix = function () { return Meeting.MeetingTypeRow.localTextPrefix; };
            MeetingTypeDialog.prototype.getNameProperty = function () { return Meeting.MeetingTypeRow.nameProperty; };
            MeetingTypeDialog.prototype.getService = function () { return Meeting.MeetingTypeService.baseUrl; };
            return MeetingTypeDialog;
        }(Serenity.EntityDialog));
        MeetingTypeDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MeetingTypeDialog);
        Meeting.MeetingTypeDialog = MeetingTypeDialog;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Meeting;
    (function (Meeting) {
        var MeetingTypeGrid = (function (_super) {
            __extends(MeetingTypeGrid, _super);
            function MeetingTypeGrid(container) {
                return _super.call(this, container) || this;
            }
            MeetingTypeGrid.prototype.getColumnsKey = function () { return 'Meeting.MeetingType'; };
            MeetingTypeGrid.prototype.getDialogType = function () { return Meeting.MeetingTypeDialog; };
            MeetingTypeGrid.prototype.getIdProperty = function () { return Meeting.MeetingTypeRow.idProperty; };
            MeetingTypeGrid.prototype.getLocalTextPrefix = function () { return Meeting.MeetingTypeRow.localTextPrefix; };
            MeetingTypeGrid.prototype.getService = function () { return Meeting.MeetingTypeService.baseUrl; };
            return MeetingTypeGrid;
        }(Serenity.EntityGrid));
        MeetingTypeGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], MeetingTypeGrid);
        Meeting.MeetingTypeGrid = MeetingTypeGrid;
    })(Meeting = Geshotel.Meeting || (Geshotel.Meeting = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var ChangePasswordPanel = (function (_super) {
            __extends(ChangePasswordPanel, _super);
            function ChangePasswordPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.ChangePasswordForm(_this.idPrefix);
                _this.form.NewPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.w('ConfirmPassword', Serenity.PasswordEditor).value.length < 7) {
                        return Q.format(Q.text('Validation.MinRequiredPasswordLength'), 7);
                    }
                });
                _this.form.ConfirmPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value !== _this.form.NewPassword.value) {
                        return Q.text('Validation.PasswordConfirm');
                    }
                });
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    var request = _this.getSaveEntity();
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/ChangePassword'),
                        request: request,
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.ChangePassword.Success'), function () {
                                window.location.href = Q.resolveUrl('~/');
                            });
                        }
                    });
                });
                return _this;
            }
            ChangePasswordPanel.prototype.getFormKey = function () { return Membership.ChangePasswordForm.formKey; };
            return ChangePasswordPanel;
        }(Serenity.PropertyPanel));
        ChangePasswordPanel = __decorate([
            Serenity.Decorators.registerClass()
        ], ChangePasswordPanel);
        Membership.ChangePasswordPanel = ChangePasswordPanel;
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var ForgotPasswordPanel = (function (_super) {
            __extends(ForgotPasswordPanel, _super);
            function ForgotPasswordPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.ForgotPasswordForm(_this.idPrefix);
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    var request = _this.getSaveEntity();
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/ForgotPassword'),
                        request: request,
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.ForgotPassword.Success'), function () {
                                window.location.href = Q.resolveUrl('~/');
                            });
                        }
                    });
                });
                return _this;
            }
            ForgotPasswordPanel.prototype.getFormKey = function () { return Membership.ForgotPasswordForm.formKey; };
            return ForgotPasswordPanel;
        }(Serenity.PropertyPanel));
        ForgotPasswordPanel = __decorate([
            Serenity.Decorators.registerClass()
        ], ForgotPasswordPanel);
        Membership.ForgotPasswordPanel = ForgotPasswordPanel;
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var LoginPanel = (function (_super) {
            __extends(LoginPanel, _super);
            function LoginPanel(container) {
                var _this = _super.call(this, container) || this;
                $(function () {
                    $('body').vegas({
                        delay: 8000,
                        cover: true,
                        overlay: Q.resolveUrl("~/scripts/vegas/overlays/01.png"),
                        slides: [
                            { src: Q.resolveUrl('~/content/site/slides/slide1.jpg'), transition: 'fade' },
                            { src: Q.resolveUrl('~/content/site/slides/slide2.jpg'), transition: 'fade' },
                            { src: Q.resolveUrl('~/content/site/slides/slide3.jpg'), transition: 'zoomOut' },
                            { src: Q.resolveUrl('~/content/site/slides/slide4.jpg'), transition: 'blur' },
                            { src: Q.resolveUrl('~/content/site/slides/slide5.jpg'), transition: 'swirlLeft' },
                            { src: Q.resolveUrl('~/content/site/slides/slide6.jpg'), transition: 'zoomOut' },
                            { src: Q.resolveUrl('~/content/site/slides/slide7.jpg'), transition: 'swirlLeft' },
                            { src: Q.resolveUrl('~/content/site/slides/slide8.jpg'), transition: 'swirlLeft' },
                            { src: Q.resolveUrl('~/content/site/slides/slide9.jpg'), transition: 'fade' },
                            { src: Q.resolveUrl('~/content/site/slides/slide10.jpg'), transition: 'blur' }
                        ]
                    });
                });
                _this.form = new Membership.LoginForm(_this.idPrefix);
                _this.byId('LoginButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    var request = _this.getSaveEntity();
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/Login'),
                        request: request,
                        onSuccess: function (response) {
                            var q = Q.parseQueryString();
                            var returnUrl = q['returnUrl'] || q['ReturnUrl'];
                            if (returnUrl) {
                                window.location.href = returnUrl;
                            }
                            else {
                                window.location.href = Q.resolveUrl('~/');
                            }
                        }
                    });
                });
                return _this;
            }
            LoginPanel.prototype.getFormKey = function () { return Membership.LoginForm.formKey; };
            return LoginPanel;
        }(Serenity.PropertyPanel));
        LoginPanel = __decorate([
            Serenity.Decorators.registerClass()
        ], LoginPanel);
        Membership.LoginPanel = LoginPanel;
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var ResetPasswordPanel = (function (_super) {
            __extends(ResetPasswordPanel, _super);
            function ResetPasswordPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.ResetPasswordForm(_this.idPrefix);
                _this.form.NewPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value.length < 7) {
                        return Q.format(Q.text('Validation.MinRequiredPasswordLength'), 7);
                    }
                });
                _this.form.ConfirmPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value !== _this.form.NewPassword.value) {
                        return Q.text('Validation.PasswordConfirm');
                    }
                });
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    var request = _this.getSaveEntity();
                    request.Token = _this.byId('Token').val();
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/ResetPassword'),
                        request: request,
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.ResetPassword.Success'), function () {
                                window.location.href = Q.resolveUrl('~/Account/Login');
                            });
                        }
                    });
                });
                return _this;
            }
            ResetPasswordPanel.prototype.getFormKey = function () { return Membership.ResetPasswordForm.formKey; };
            return ResetPasswordPanel;
        }(Serenity.PropertyPanel));
        ResetPasswordPanel = __decorate([
            Serenity.Decorators.registerClass()
        ], ResetPasswordPanel);
        Membership.ResetPasswordPanel = ResetPasswordPanel;
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Membership;
    (function (Membership) {
        var SignUpPanel = (function (_super) {
            __extends(SignUpPanel, _super);
            function SignUpPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.SignUpForm(_this.idPrefix);
                _this.form.ConfirmEmail.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmEmail.value !== _this.form.Email.value) {
                        return Q.text('Validation.EmailConfirm');
                    }
                });
                _this.form.ConfirmPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value !== _this.form.Password.value) {
                        return Q.text('Validation.PasswordConfirm');
                    }
                });
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/SignUp'),
                        request: {
                            DisplayName: _this.form.DisplayName.value,
                            Email: _this.form.Email.value,
                            Password: _this.form.Password.value
                        },
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.SignUp.Success'), function () {
                                window.location.href = Q.resolveUrl('~/');
                            });
                        }
                    });
                });
                return _this;
            }
            SignUpPanel.prototype.getFormKey = function () { return Membership.SignUpForm.formKey; };
            return SignUpPanel;
        }(Serenity.PropertyPanel));
        SignUpPanel = __decorate([
            Serenity.Decorators.registerClass()
        ], SignUpPanel);
        Membership.SignUpPanel = SignUpPanel;
    })(Membership = Geshotel.Membership || (Geshotel.Membership = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CategoryDialog = (function (_super) {
            __extends(CategoryDialog, _super);
            function CategoryDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Northwind.CategoryForm(_this.idPrefix);
                return _this;
            }
            CategoryDialog.prototype.getFormKey = function () { return Northwind.CategoryForm.formKey; };
            CategoryDialog.prototype.getIdProperty = function () { return Northwind.CategoryRow.idProperty; };
            CategoryDialog.prototype.getLocalTextPrefix = function () { return Northwind.CategoryRow.localTextPrefix; };
            CategoryDialog.prototype.getNameProperty = function () { return Northwind.CategoryRow.nameProperty; };
            CategoryDialog.prototype.getService = function () { return Northwind.CategoryService.baseUrl; };
            CategoryDialog.prototype.getLanguages = function () {
                return Geshotel.LanguageList.getValue();
            };
            return CategoryDialog;
        }(Serenity.EntityDialog));
        CategoryDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], CategoryDialog);
        Northwind.CategoryDialog = CategoryDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CategoryGrid = (function (_super) {
            __extends(CategoryGrid, _super);
            function CategoryGrid(container) {
                return _super.call(this, container) || this;
            }
            CategoryGrid.prototype.getColumnsKey = function () { return "Northwind.Category"; };
            CategoryGrid.prototype.getDialogType = function () { return Northwind.CategoryDialog; };
            CategoryGrid.prototype.getIdProperty = function () { return Northwind.CategoryRow.idProperty; };
            CategoryGrid.prototype.getLocalTextPrefix = function () { return Northwind.CategoryRow.localTextPrefix; };
            CategoryGrid.prototype.getService = function () { return Northwind.CategoryService.baseUrl; };
            return CategoryGrid;
        }(Serenity.EntityGrid));
        CategoryGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], CategoryGrid);
        Northwind.CategoryGrid = CategoryGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerDialog = (function (_super) {
            __extends(CustomerDialog, _super);
            function CustomerDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Northwind.CustomerForm(_this.idPrefix);
                _this.ordersGrid = new Northwind.CustomerOrdersGrid(_this.byId('OrdersGrid'));
                _this.ordersGrid.element.flexHeightOnly(1);
                _this.byId('NoteList').closest('.field').hide().end().appendTo(_this.byId('TabNotes'));
                Geshotel.DialogUtils.pendingChangesConfirmation(_this.element, function () { return _this.getSaveState() != _this.loadedState; });
                return _this;
            }
            CustomerDialog.prototype.getFormKey = function () { return Northwind.CustomerForm.formKey; };
            CustomerDialog.prototype.getIdProperty = function () { return Northwind.CustomerRow.idProperty; };
            CustomerDialog.prototype.getLocalTextPrefix = function () { return Northwind.CustomerRow.localTextPrefix; };
            CustomerDialog.prototype.getNameProperty = function () { return Northwind.CustomerRow.nameProperty; };
            CustomerDialog.prototype.getService = function () { return Northwind.CustomerService.baseUrl; };
            CustomerDialog.prototype.getSaveState = function () {
                try {
                    return $.toJSON(this.getSaveEntity());
                }
                catch (e) {
                    return null;
                }
            };
            CustomerDialog.prototype.loadResponse = function (data) {
                _super.prototype.loadResponse.call(this, data);
                this.loadedState = this.getSaveState();
            };
            CustomerDialog.prototype.loadEntity = function (entity) {
                _super.prototype.loadEntity.call(this, entity);
                Serenity.TabsExtensions.setDisabled(this.tabs, 'Orders', this.isNewOrDeleted());
                this.ordersGrid.customerID = entity.CustomerID;
            };
            CustomerDialog.prototype.onSaveSuccess = function (response) {
                _super.prototype.onSaveSuccess.call(this, response);
                Q.reloadLookup('Northwind.Customer');
            };
            return CustomerDialog;
        }(Serenity.EntityDialog));
        CustomerDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], CustomerDialog);
        Northwind.CustomerDialog = CustomerDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerEditor = (function (_super) {
            __extends(CustomerEditor, _super);
            function CustomerEditor(hidden) {
                return _super.call(this, hidden) || this;
            }
            CustomerEditor.prototype.getLookupKey = function () {
                return 'Northwind.Customer';
            };
            CustomerEditor.prototype.getItemText = function (item, lookup) {
                return _super.prototype.getItemText.call(this, item, lookup) + ' [' + item.CustomerID + ']';
            };
            return CustomerEditor;
        }(Serenity.LookupEditorBase));
        CustomerEditor = __decorate([
            Serenity.Decorators.registerEditor()
        ], CustomerEditor);
        Northwind.CustomerEditor = CustomerEditor;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerGrid = (function (_super) {
            __extends(CustomerGrid, _super);
            function CustomerGrid(container) {
                return _super.call(this, container) || this;
            }
            CustomerGrid.prototype.getColumnsKey = function () { return "Northwind.Customer"; };
            CustomerGrid.prototype.getDialogType = function () { return Northwind.CustomerDialog; };
            CustomerGrid.prototype.getIdProperty = function () { return Northwind.CustomerRow.idProperty; };
            CustomerGrid.prototype.getLocalTextPrefix = function () { return Northwind.CustomerRow.localTextPrefix; };
            CustomerGrid.prototype.getService = function () { return Northwind.CustomerService.baseUrl; };
            CustomerGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Northwind/Customer/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return CustomerGrid;
        }(Serenity.EntityGrid));
        CustomerGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], CustomerGrid);
        Northwind.CustomerGrid = CustomerGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderDialog = (function (_super) {
            __extends(OrderDialog, _super);
            function OrderDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Northwind.OrderForm(_this.idPrefix);
                return _this;
            }
            OrderDialog.prototype.getFormKey = function () { return Northwind.OrderForm.formKey; };
            OrderDialog.prototype.getIdProperty = function () { return Northwind.OrderRow.idProperty; };
            OrderDialog.prototype.getLocalTextPrefix = function () { return Northwind.OrderRow.localTextPrefix; };
            OrderDialog.prototype.getNameProperty = function () { return Northwind.OrderRow.nameProperty; };
            OrderDialog.prototype.getService = function () { return Northwind.OrderService.baseUrl; };
            OrderDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getToolbarButtons.call(this);
                buttons.push(Geshotel.Common.ReportHelper.createToolButton({
                    title: 'Invoice',
                    cssClass: 'export-pdf-button',
                    reportKey: 'Northwind.OrderDetail',
                    getParams: function () { return ({
                        OrderID: _this.get_entityId()
                    }); }
                }));
                return buttons;
            };
            OrderDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.toolbar.findButton('export-pdf-button').toggle(this.isEditMode());
            };
            return OrderDialog;
        }(Serenity.EntityDialog));
        OrderDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], OrderDialog);
        Northwind.OrderDialog = OrderDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
/// <reference path="../Order/OrderDialog.ts" />
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerOrderDialog = (function (_super) {
            __extends(CustomerOrderDialog, _super);
            function CustomerOrderDialog() {
                return _super.call(this) || this;
            }
            CustomerOrderDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                Serenity.EditorUtils.setReadOnly(this.form.CustomerID, true);
            };
            return CustomerOrderDialog;
        }(Northwind.OrderDialog));
        CustomerOrderDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], CustomerOrderDialog);
        Northwind.CustomerOrderDialog = CustomerOrderDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderGrid = (function (_super) {
            __extends(OrderGrid, _super);
            function OrderGrid(container) {
                return _super.call(this, container) || this;
            }
            OrderGrid.prototype.getColumnsKey = function () { return "Northwind.Order"; };
            OrderGrid.prototype.getDialogType = function () { return Northwind.OrderDialog; };
            OrderGrid.prototype.getIdProperty = function () { return Northwind.OrderRow.idProperty; };
            OrderGrid.prototype.getLocalTextPrefix = function () { return Northwind.OrderRow.localTextPrefix; };
            OrderGrid.prototype.getService = function () { return Northwind.OrderService.baseUrl; };
            OrderGrid.prototype.getQuickFilters = function () {
                var _this = this;
                var filters = _super.prototype.getQuickFilters.call(this);
                filters.push({
                    type: Serenity.LookupEditor,
                    options: {
                        lookupKey: Northwind.ProductRow.lookupKey
                    },
                    field: 'ProductID',
                    title: 'Contains Product in Details',
                    handler: function (w) {
                        _this.view.params.ProductID = Q.toId(w.value);
                    }
                });
                return filters;
            };
            OrderGrid.prototype.createQuickFilters = function () {
                _super.prototype.createQuickFilters.call(this);
                var fld = Northwind.OrderRow.Fields;
                this.shippingStateFilter = this.findQuickFilter(Serenity.EnumEditor, fld.ShippingState);
            };
            OrderGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    service: Northwind.OrderService.baseUrl + '/ListExcel',
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            OrderGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                columns.splice(1, 0, {
                    field: 'Print Invoice',
                    name: '',
                    format: function (ctx) { return '<a class="inline-action print-invoice" title="invoice">' +
                        '<i class="fa fa-file-pdf-o text-red"></i></a>'; },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });
                return columns;
            };
            OrderGrid.prototype.onClick = function (e, row, cell) {
                _super.prototype.onClick.call(this, e, row, cell);
                if (e.isDefaultPrevented())
                    return;
                var item = this.itemAt(row);
                var target = $(e.target);
                // if user clicks "i" element, e.g. icon
                if (target.parent().hasClass('inline-action'))
                    target = target.parent();
                if (target.hasClass('inline-action')) {
                    e.preventDefault();
                    if (target.hasClass('print-invoice')) {
                        Geshotel.Common.ReportHelper.execute({
                            reportKey: 'Northwind.OrderDetail',
                            params: {
                                OrderID: item.OrderID
                            }
                        });
                    }
                }
            };
            OrderGrid.prototype.set_shippingState = function (value) {
                this.shippingStateFilter.value = value == null ? '' : value.toString();
            };
            return OrderGrid;
        }(Serenity.EntityGrid));
        OrderGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], OrderGrid);
        Northwind.OrderGrid = OrderGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
/// <reference path="../Order/OrderGrid.ts" />
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var CustomerOrdersGrid = (function (_super) {
            __extends(CustomerOrdersGrid, _super);
            function CustomerOrdersGrid(container) {
                return _super.call(this, container) || this;
            }
            CustomerOrdersGrid.prototype.getDialogType = function () { return Northwind.CustomerOrderDialog; };
            CustomerOrdersGrid.prototype.getColumns = function () {
                var fld = Northwind.OrderRow.Fields;
                return _super.prototype.getColumns.call(this).filter(function (x) { return x.field !== fld.CustomerCompanyName; });
            };
            CustomerOrdersGrid.prototype.initEntityDialog = function (itemType, dialog) {
                _super.prototype.initEntityDialog.call(this, itemType, dialog);
                Serenity.SubDialogHelper.cascade(dialog, this.element.closest('.ui-dialog'));
            };
            CustomerOrdersGrid.prototype.addButtonClick = function () {
                this.editItem({ CustomerID: this.customerID });
            };
            CustomerOrdersGrid.prototype.getInitialTitle = function () {
                return null;
            };
            CustomerOrdersGrid.prototype.getGridCanLoad = function () {
                return _super.prototype.getGridCanLoad.call(this) && !!this.customerID;
            };
            Object.defineProperty(CustomerOrdersGrid.prototype, "customerID", {
                get: function () {
                    return this._customerID;
                },
                set: function (value) {
                    if (this._customerID !== value) {
                        this._customerID = value;
                        this.setEquality('CustomerID', value);
                        this.refresh();
                    }
                },
                enumerable: true,
                configurable: true
            });
            return CustomerOrdersGrid;
        }(Northwind.OrderGrid));
        CustomerOrdersGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], CustomerOrdersGrid);
        Northwind.CustomerOrdersGrid = CustomerOrdersGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var EmployeeListFormatter = (function () {
            function EmployeeListFormatter() {
            }
            EmployeeListFormatter.prototype.format = function (ctx) {
                var idList = ctx.value;
                if (!idList || !idList.length)
                    return "";
                var byId = Northwind.EmployeeRow.getLookup().itemById;
                var z;
                return idList.map(function (x) { return ((z = byId[x]) ? z.FullName : x); }).join(", ");
            };
            return EmployeeListFormatter;
        }());
        EmployeeListFormatter = __decorate([
            Serenity.Decorators.registerFormatter()
        ], EmployeeListFormatter);
        Northwind.EmployeeListFormatter = EmployeeListFormatter;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var EmployeeFormatter = (function () {
            function EmployeeFormatter() {
            }
            EmployeeFormatter.prototype.format = function (ctx) {
                var text = Q.htmlEncode(ctx.value);
                if (!this.genderProperty) {
                    return text;
                }
                var gender = ctx.item[this.genderProperty];
                return "<span class='" + ((gender === Northwind.Gender.Female) ?
                    'employee-symbol female' : 'employee-symbol male') +
                    "'>" + text + '</span>';
            };
            EmployeeFormatter.prototype.initializeColumn = function (column) {
                column.referencedFields = column.referencedFields || [];
                if (this.genderProperty)
                    column.referencedFields.push(this.genderProperty);
            };
            return EmployeeFormatter;
        }());
        __decorate([
            Serenity.Decorators.option()
        ], EmployeeFormatter.prototype, "genderProperty", void 0);
        EmployeeFormatter = __decorate([
            Serenity.Decorators.registerFormatter([Serenity.ISlickFormatter, Serenity.IInitializeColumn])
        ], EmployeeFormatter);
        Northwind.EmployeeFormatter = EmployeeFormatter;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var NoteDialog = (function (_super) {
            __extends(NoteDialog, _super);
            function NoteDialog() {
                var _this = _super.call(this) || this;
                _this.textEditor = new Serenity.HtmlNoteContentEditor(_this.byId('Text'));
                return _this;
            }
            NoteDialog.prototype.getTemplate = function () {
                return ("<form id='~_Form' class='s-Form'>" +
                    "<textarea id='~_Text' class='required'></textarea>" +
                    "</form>");
            };
            NoteDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [{
                        text: Q.text('Dialogs.OkButton'),
                        click: function () {
                            if (!_this.validateForm()) {
                                return;
                            }
                            _this.okClick && _this.okClick();
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }
                ];
                return opt;
            };
            Object.defineProperty(NoteDialog.prototype, "text", {
                get: function () {
                    return this.textEditor.value;
                },
                set: function (value) {
                    this.textEditor.value = value;
                },
                enumerable: true,
                configurable: true
            });
            return NoteDialog;
        }(Serenity.TemplatedDialog));
        NoteDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], NoteDialog);
        Northwind.NoteDialog = NoteDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var NotesEditor = (function (_super) {
            __extends(NotesEditor, _super);
            function NotesEditor(div) {
                var _this = _super.call(this, div) || this;
                new Serenity.Toolbar(_this.byId('Toolbar'), {
                    buttons: [{
                            title: 'Add Note',
                            cssClass: 'add-button',
                            onClick: function (e) {
                                e.preventDefault();
                                _this.addClick();
                            }
                        }]
                });
                return _this;
            }
            NotesEditor.prototype.getTemplate = function () {
                return "<div><div id='~_Toolbar'></div><ul id='~_NoteList'></ul></div>";
            };
            NotesEditor.prototype.updateContent = function () {
                var _this = this;
                var noteList = this.byId('NoteList');
                noteList.children().remove();
                if (this.items) {
                    var index = 0;
                    for (var t1 = 0; t1 < this.items.length; t1++) {
                        var item = this.items[t1];
                        var li = $('<li/>');
                        $('<div/>').addClass('note-text').html(Q.coalesce(item.Text, '')).appendTo(li);
                        $('<a/>').attr('href', '#').addClass('note-date')
                            .text(item.InsertUserDisplayName + ' - ' +
                            Q.formatDate(item.InsertDate, 'g'))
                            .data('index', index).appendTo(li).click(function (e) { return _this.editClick(e); });
                        $('<a/>').attr('href', '#').addClass('note-delete')
                            .attr('title', 'delete note').data('index', index)
                            .appendTo(li).click(function (e) { return _this.deleteClick(e); });
                        li.appendTo(noteList);
                        index++;
                    }
                }
            };
            NotesEditor.prototype.addClick = function () {
                var _this = this;
                var dlg = new Northwind.NoteDialog();
                dlg.dialogTitle = 'Add Note';
                dlg.okClick = function () {
                    var text = Q.trimToNull(dlg.text);
                    if (text == null) {
                        return;
                    }
                    _this.items = _this.items || [];
                    Q.insert(_this.items, 0, {
                        Text: text,
                        InsertUserDisplayName: Geshotel.Authorization.userDefinition.DisplayName,
                        InsertDate: Q.formatISODateTimeUTC(new Date())
                    });
                    _this.updateContent();
                    dlg.dialogClose();
                    _this.set_isDirty(true);
                    _this.onChange && _this.onChange();
                };
                dlg.dialogOpen();
            };
            NotesEditor.prototype.editClick = function (e) {
                var _this = this;
                e.preventDefault();
                var index = $(e.target).data('index');
                var old = this.items[index];
                var dlg = new Northwind.NoteDialog();
                dlg.dialogTitle = 'Edit Note';
                dlg.text = old.Text;
                dlg.okClick = function () {
                    var text = Q.trimToNull(dlg.text);
                    if (!text) {
                        return;
                    }
                    _this.items[index].Text = text;
                    _this.updateContent();
                    dlg.dialogClose();
                    _this.set_isDirty(true);
                    _this.onChange && _this.onChange();
                };
                dlg.dialogOpen();
            };
            NotesEditor.prototype.deleteClick = function (e) {
                var _this = this;
                e.preventDefault();
                var index = $(e.target).data('index');
                Q.confirm('Delete this note?', function () {
                    _this.items.splice(index, 1);
                    _this.updateContent();
                    _this.set_isDirty(true);
                    _this.onChange && _this.onChange();
                });
            };
            Object.defineProperty(NotesEditor.prototype, "value", {
                get: function () {
                    return this.items;
                },
                set: function (value) {
                    this.items = value || [];
                    this.set_isDirty(false);
                    this.updateContent();
                },
                enumerable: true,
                configurable: true
            });
            NotesEditor.prototype.getEditValue = function (prop, target) {
                target[prop.name] = this.value;
            };
            NotesEditor.prototype.setEditValue = function (source, prop) {
                this.value = source[prop.name] || [];
            };
            NotesEditor.prototype.get_isDirty = function () {
                return this.isDirty;
            };
            NotesEditor.prototype.set_isDirty = function (value) {
                this.isDirty = value;
            };
            return NotesEditor;
        }(Serenity.TemplatedWidget));
        NotesEditor = __decorate([
            Serenity.Decorators.registerEditor([Serenity.IGetEditValue, Serenity.ISetEditValue]),
            Serenity.Decorators.element("<div/>")
        ], NotesEditor);
        Northwind.NotesEditor = NotesEditor;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var FreightFormatter = (function () {
            function FreightFormatter() {
            }
            FreightFormatter.prototype.format = function (ctx) {
                return "<span class='freight-symbol'>" + Q.htmlEncode(ctx.value) + '</span>';
            };
            return FreightFormatter;
        }());
        FreightFormatter = __decorate([
            Serenity.Decorators.registerFormatter()
        ], FreightFormatter);
        Northwind.FreightFormatter = FreightFormatter;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailDialog = (function (_super) {
            __extends(OrderDetailDialog, _super);
            function OrderDetailDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Northwind.OrderDetailForm(_this.idPrefix);
                _this.form.ProductID.changeSelect2(function (e) {
                    var productID = Q.toId(_this.form.ProductID.value);
                    if (productID != null) {
                        _this.form.UnitPrice.value = Northwind.ProductRow.getLookup().itemById[productID].UnitPrice;
                    }
                });
                _this.form.Discount.addValidationRule(_this.uniqueName, function (e) {
                    var price = _this.form.UnitPrice.value;
                    var quantity = _this.form.Quantity.value;
                    var discount = _this.form.Discount.value;
                    if (price != null && quantity != null && discount != null &&
                        discount > 0 && discount >= price * quantity) {
                        return "Discount can't be higher than total price!";
                    }
                });
                return _this;
            }
            OrderDetailDialog.prototype.getFormKey = function () { return Northwind.OrderDetailForm.formKey; };
            OrderDetailDialog.prototype.getLocalTextPrefix = function () { return Northwind.OrderDetailRow.localTextPrefix; };
            return OrderDetailDialog;
        }(Geshotel.Common.GridEditorDialog));
        OrderDetailDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], OrderDetailDialog);
        Northwind.OrderDetailDialog = OrderDetailDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailsEditor = (function (_super) {
            __extends(OrderDetailsEditor, _super);
            function OrderDetailsEditor(container) {
                return _super.call(this, container) || this;
            }
            OrderDetailsEditor.prototype.getColumnsKey = function () { return "Northwind.OrderDetail"; };
            OrderDetailsEditor.prototype.getDialogType = function () { return Northwind.OrderDetailDialog; };
            OrderDetailsEditor.prototype.getLocalTextPrefix = function () { return Northwind.OrderDetailRow.localTextPrefix; };
            OrderDetailsEditor.prototype.validateEntity = function (row, id) {
                row.ProductID = Q.toId(row.ProductID);
                var sameProduct = Q.tryFirst(this.view.getItems(), function (x) { return x.ProductID === row.ProductID; });
                if (sameProduct && this.id(sameProduct) !== id) {
                    Q.alert('This product is already in order details!');
                    return false;
                }
                row.ProductName = Northwind.ProductRow.getLookup().itemById[row.ProductID].ProductName;
                row.LineTotal = (row.Quantity || 0) * (row.UnitPrice || 0) - (row.Discount || 0);
                return true;
            };
            return OrderDetailsEditor;
        }(Geshotel.Common.GridEditorBase));
        OrderDetailsEditor = __decorate([
            Serenity.Decorators.registerClass()
        ], OrderDetailsEditor);
        Northwind.OrderDetailsEditor = OrderDetailsEditor;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductDialog = (function (_super) {
            __extends(ProductDialog, _super);
            function ProductDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Northwind.ProductForm(_this.idPrefix);
                return _this;
            }
            ProductDialog.prototype.getFormKey = function () { return Northwind.ProductForm.formKey; };
            ProductDialog.prototype.getIdProperty = function () { return Northwind.ProductRow.idProperty; };
            ProductDialog.prototype.getLocalTextPrefix = function () { return Northwind.ProductRow.localTextPrefix; };
            ProductDialog.prototype.getNameProperty = function () { return Northwind.ProductRow.nameProperty; };
            ProductDialog.prototype.getService = function () { return Northwind.ProductService.baseUrl; };
            ProductDialog.prototype.getLanguages = function () {
                return Geshotel.LanguageList.getValue();
            };
            return ProductDialog;
        }(Serenity.EntityDialog));
        ProductDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.maximizable()
        ], ProductDialog);
        Northwind.ProductDialog = ProductDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ProductGrid = (function (_super) {
            __extends(ProductGrid, _super);
            function ProductGrid(container) {
                var _this = _super.call(this, container) || this;
                _this.pendingChanges = {};
                _this.slickContainer.on('change', '.edit:input', function (e) { return _this.inputsChange(e); });
                return _this;
            }
            ProductGrid.prototype.getColumnsKey = function () { return "Northwind.Product"; };
            ProductGrid.prototype.getDialogType = function () { return Northwind.ProductDialog; };
            ProductGrid.prototype.getIdProperty = function () { return Northwind.ProductRow.idProperty; };
            ProductGrid.prototype.getLocalTextPrefix = function () { return Northwind.ProductRow.localTextPrefix; };
            ProductGrid.prototype.getService = function () { return Northwind.ProductService.baseUrl; };
            ProductGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    service: Northwind.ProductService.baseUrl + '/ListExcel',
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    reportTitle: 'Product List',
                    columnTitles: {
                        'Discontinued': 'Dis.',
                    },
                    tableOptions: {
                        columnStyles: {
                            ProductID: {
                                columnWidth: 25,
                                halign: 'right'
                            },
                            Discountinued: {
                                columnWidth: 25
                            }
                        }
                    }
                }));
                buttons.push({
                    title: 'Save Changes',
                    cssClass: 'apply-changes-button disabled',
                    onClick: function (e) { return _this.saveClick(); },
                    separator: true
                });
                return buttons;
            };
            ProductGrid.prototype.onViewProcessData = function (response) {
                this.pendingChanges = {};
                this.setSaveButtonState();
                return _super.prototype.onViewProcessData.call(this, response);
            };
            // PLEASE NOTE! Inline editing in grids is not something Serenity supports nor recommends.
            // SlickGrid has some set of limitations, UI is very hard to use on some devices like mobile, 
            // custom widgets and validations are not possible, and as a bonus the code can become a mess.
            // 
            // This was just a sample how-to after much requests, and is not supported. 
            // This is all we can offer, please don't ask us to Guide you...
            /**
             * It would be nice if we could use autonumeric, Serenity editors etc. here, to control input validation,
             * but it's not supported by SlickGrid as we are only allowed to return a string, and should attach
             * no event handlers to rendered cell contents
             */
            ProductGrid.prototype.numericInputFormatter = function (ctx) {
                var klass = 'edit numeric';
                var item = ctx.item;
                var pending = this.pendingChanges[item.ProductID];
                if (pending && pending[ctx.column.field] !== undefined) {
                    klass += ' dirty';
                }
                var value = this.getEffectiveValue(item, ctx.column.field);
                return "<input type='text' class='" + klass +
                    "' data-field='" + ctx.column.field +
                    "' value='" + Q.formatNumber(value, '0.##') + "'/>";
            };
            ProductGrid.prototype.stringInputFormatter = function (ctx) {
                var klass = 'edit string';
                var item = ctx.item;
                var pending = this.pendingChanges[item.ProductID];
                var column = ctx.column;
                if (pending && pending[column.field] !== undefined) {
                    klass += ' dirty';
                }
                var value = this.getEffectiveValue(item, column.field);
                return "<input type='text' class='" + klass +
                    "' data-field='" + column.field +
                    "' value='" + Q.htmlEncode(value) +
                    "' maxlength='" + column.sourceItem.maxLength + "'/>";
            };
            /**
             * Sorry but you cannot use LookupEditor, e.g. Select2 here, only possible is a SELECT element
             */
            ProductGrid.prototype.selectFormatter = function (ctx, idField, lookup) {
                var fld = Northwind.ProductRow.Fields;
                var klass = 'edit';
                var item = ctx.item;
                var pending = this.pendingChanges[item.ProductID];
                var column = ctx.column;
                if (pending && pending[idField] !== undefined) {
                    klass += ' dirty';
                }
                var value = this.getEffectiveValue(item, idField);
                var markup = "<select class='" + klass +
                    "' data-field='" + idField +
                    "' style='width: 100%; max-width: 100%'>";
                for (var _i = 0, _a = lookup.items; _i < _a.length; _i++) {
                    var c = _a[_i];
                    var id = c[lookup.idField];
                    markup += "<option value='" + id + "'";
                    if (id == value) {
                        markup += " selected";
                    }
                    markup += ">" + Q.htmlEncode(c[lookup.textField]) + "</option>";
                }
                return markup + "</select>";
            };
            ProductGrid.prototype.getEffectiveValue = function (item, field) {
                var pending = this.pendingChanges[item.ProductID];
                if (pending && pending[field] !== undefined) {
                    return pending[field];
                }
                return item[field];
            };
            ProductGrid.prototype.getColumns = function () {
                var _this = this;
                var columns = _super.prototype.getColumns.call(this);
                var num = function (ctx) { return _this.numericInputFormatter(ctx); };
                var str = function (ctx) { return _this.stringInputFormatter(ctx); };
                var fld = Northwind.ProductRow.Fields;
                Q.first(columns, function (x) { return x.field === 'QuantityPerUnit'; }).format = str;
                var category = Q.first(columns, function (x) { return x.field === fld.CategoryName; });
                category.referencedFields = [fld.CategoryID];
                category.format = function (ctx) { return _this.selectFormatter(ctx, fld.CategoryID, Northwind.CategoryRow.getLookup()); };
                var supplier = Q.first(columns, function (x) { return x.field === fld.SupplierCompanyName; });
                supplier.referencedFields = [fld.SupplierID];
                supplier.format = function (ctx) { return _this.selectFormatter(ctx, fld.SupplierID, Northwind.SupplierRow.getLookup()); };
                Q.first(columns, function (x) { return x.field === fld.UnitPrice; }).format = num;
                Q.first(columns, function (x) { return x.field === fld.UnitsInStock; }).format = num;
                Q.first(columns, function (x) { return x.field === fld.UnitsOnOrder; }).format = num;
                Q.first(columns, function (x) { return x.field === fld.ReorderLevel; }).format = num;
                return columns;
            };
            ProductGrid.prototype.inputsChange = function (e) {
                var cell = this.slickGrid.getCellFromEvent(e);
                var item = this.itemAt(cell.row);
                var input = $(e.target);
                var field = input.data('field');
                var text = Q.coalesce(Q.trimToNull(input.val()), '0');
                var pending = this.pendingChanges[item.ProductID];
                var effective = this.getEffectiveValue(item, field);
                var oldText;
                if (input.hasClass("numeric"))
                    oldText = Q.formatNumber(effective, '0.##');
                else
                    oldText = effective;
                var value;
                if (field === 'UnitPrice') {
                    value = Q.parseDecimal(text);
                    if (value == null || isNaN(value)) {
                        Q.notifyError(Q.text('Validation.Decimal'), '', null);
                        input.val(oldText);
                        input.focus();
                        return;
                    }
                }
                else if (input.hasClass("numeric")) {
                    var i = Q.parseInteger(text);
                    if (isNaN(i) || i > 32767 || i < 0) {
                        Q.notifyError(Q.text('Validation.Integer'), '', null);
                        input.val(oldText);
                        input.focus();
                        return;
                    }
                    value = i;
                }
                else
                    value = text;
                if (!pending) {
                    this.pendingChanges[item.ProductID] = pending = {};
                }
                pending[field] = value;
                item[field] = value;
                this.view.refresh();
                if (input.hasClass("numeric"))
                    value = Q.formatNumber(value, '0.##');
                input.val(value).addClass('dirty');
                this.setSaveButtonState();
            };
            ProductGrid.prototype.setSaveButtonState = function () {
                this.toolbar.findButton('apply-changes-button').toggleClass('disabled', Object.keys(this.pendingChanges).length === 0);
            };
            ProductGrid.prototype.saveClick = function () {
                if (Object.keys(this.pendingChanges).length === 0) {
                    return;
                }
                // this calls save service for all modified rows, one by one
                // you could write a batch update service
                var keys = Object.keys(this.pendingChanges);
                var current = -1;
                var self = this;
                (function saveNext() {
                    if (++current >= keys.length) {
                        self.refresh();
                        return;
                    }
                    var key = keys[current];
                    var entity = Q.deepClone(self.pendingChanges[key]);
                    entity.ProductID = key;
                    Q.serviceRequest('Northwind/Product/Update', {
                        EntityId: key,
                        Entity: entity
                    }, function (response) {
                        delete self.pendingChanges[key];
                        saveNext();
                    });
                })();
            };
            ProductGrid.prototype.getQuickFilters = function () {
                var flt = _super.prototype.getQuickFilters.call(this);
                var q = Q.parseQueryString();
                if (q["cat"]) {
                    var category = Q.tryFirst(flt, function (x) { return x.field == "CategoryID"; });
                    category.init = function (e) {
                        e.element.getWidget(Serenity.LookupEditor).value = q["cat"];
                    };
                }
                return flt;
            };
            return ProductGrid;
        }(Serenity.EntityGrid));
        ProductGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], ProductGrid);
        Northwind.ProductGrid = ProductGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var RegionDialog = (function (_super) {
            __extends(RegionDialog, _super);
            function RegionDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Northwind.RegionForm(_this.idPrefix);
                return _this;
            }
            RegionDialog.prototype.getFormKey = function () { return Northwind.RegionForm.formKey; };
            RegionDialog.prototype.getIdProperty = function () { return Northwind.RegionRow.idProperty; };
            RegionDialog.prototype.getLocalTextPrefix = function () { return Northwind.RegionRow.localTextPrefix; };
            RegionDialog.prototype.getNameProperty = function () { return Northwind.RegionRow.nameProperty; };
            RegionDialog.prototype.getService = function () { return Northwind.RegionService.baseUrl; };
            RegionDialog.prototype.getLanguages = function () {
                return Geshotel.LanguageList.getValue();
            };
            return RegionDialog;
        }(Serenity.EntityDialog));
        RegionDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], RegionDialog);
        Northwind.RegionDialog = RegionDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var RegionGrid = (function (_super) {
            __extends(RegionGrid, _super);
            function RegionGrid(container) {
                return _super.call(this, container) || this;
            }
            RegionGrid.prototype.getColumnsKey = function () { return "Northwind.Region"; };
            RegionGrid.prototype.getDialogType = function () { return Northwind.RegionDialog; };
            RegionGrid.prototype.getIdProperty = function () { return Northwind.RegionRow.idProperty; };
            RegionGrid.prototype.getLocalTextPrefix = function () { return Northwind.RegionRow.localTextPrefix; };
            RegionGrid.prototype.getService = function () { return Northwind.RegionService.baseUrl; };
            return RegionGrid;
        }(Serenity.EntityGrid));
        RegionGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], RegionGrid);
        Northwind.RegionGrid = RegionGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var PhoneEditor = PhoneEditor_1 = (function (_super) {
            __extends(PhoneEditor, _super);
            function PhoneEditor(input) {
                var _this = _super.call(this, input) || this;
                _this.addValidationRule(_this.uniqueName, function (e) {
                    var value = Q.trimToNull(_this.get_value());
                    if (value == null) {
                        return null;
                    }
                    return PhoneEditor_1.validate(value, _this.multiple);
                });
                input.bind('change', function (e) {
                    if (!Serenity.WX.hasOriginalEvent(e)) {
                        return;
                    }
                    _this.formatValue();
                });
                input.bind('blur', function (e) {
                    if (_this.element.hasClass('valid')) {
                        _this.formatValue();
                    }
                });
                return _this;
            }
            PhoneEditor.prototype.formatValue = function () {
                this.element.val(this.getFormattedValue());
            };
            PhoneEditor.prototype.getFormattedValue = function () {
                var value = this.element.val();
                if (this.multiple) {
                    return PhoneEditor_1.formatMulti(value, PhoneEditor_1.formatPhone);
                }
                return PhoneEditor_1.formatPhone(value);
            };
            PhoneEditor.prototype.get_value = function () {
                return this.getFormattedValue();
            };
            PhoneEditor.prototype.set_value = function (value) {
                this.element.val(value);
            };
            PhoneEditor.validate = function (phone, isMultiple) {
                var valid = (isMultiple ? PhoneEditor_1.isValidMulti(phone, PhoneEditor_1.isValidPhone) : PhoneEditor_1.isValidPhone(phone));
                if (valid) {
                    return null;
                }
                return Q.text((isMultiple ? 'Validation.NorthwindPhoneMultiple' : 'Validation.NorthwindPhone'));
            };
            PhoneEditor.isValidPhone = function (phone) {
                if (Q.isEmptyOrNull(phone)) {
                    return false;
                }
                phone = Q.replaceAll(Q.replaceAll(phone, ' ', ''), '-', '');
                if (phone.length < 10) {
                    return false;
                }
                if (Q.startsWith(phone, '0')) {
                    phone = phone.substring(1);
                }
                if (Q.startsWith(phone, '(') && phone.charAt(4) === ')') {
                    phone = phone.substr(1, 3) + phone.substring(5);
                }
                if (phone.length !== 10) {
                    return false;
                }
                if (Q.startsWith(phone, '0')) {
                    return false;
                }
                for (var i = 0; i < phone.length; i++) {
                    var c = phone.charAt(i);
                    if (c < '0' || c > '9') {
                        return false;
                    }
                }
                return true;
            };
            PhoneEditor.formatPhone = function (phone) {
                if (!PhoneEditor_1.isValidPhone(phone)) {
                    return phone;
                }
                phone = Q.replaceAll(Q.replaceAll(Q.replaceAll(Q.replaceAll(phone, ' ', ''), '-', ''), '(', ''), ')', '');
                if (Q.startsWith(phone, '0')) {
                    phone = phone.substring(1);
                }
                phone = '(' + phone.substr(0, 3) + ') ' + phone.substr(3, 3) + '-' + phone.substr(6, 2) + phone.substr(8, 2);
                return phone;
            };
            PhoneEditor.formatMulti = function (phone, format) {
                var phones = Q.replaceAll(phone, String.fromCharCode(59), String.fromCharCode(44)).split(String.fromCharCode(44));
                var result = '';
                for (var _i = 0, phones_1 = phones; _i < phones_1.length; _i++) {
                    var x = phones_1[_i];
                    var s = Q.trimToNull(x);
                    if (s == null) {
                        continue;
                    }
                    if (result.length > 0) {
                        result += ', ';
                    }
                    result += format(s);
                }
                return result;
            };
            PhoneEditor.isValidMulti = function (phone, check) {
                if (Q.isEmptyOrNull(phone)) {
                    return false;
                }
                var phones = Q.replaceAll(phone, String.fromCharCode(59), String.fromCharCode(44)).split(String.fromCharCode(44));
                var anyValid = false;
                for (var $t1 = 0; $t1 < phones.length; $t1++) {
                    var x = phones[$t1];
                    var s = Q.trimToNull(x);
                    if (s == null) {
                        continue;
                    }
                    if (!check(s)) {
                        return false;
                    }
                    anyValid = true;
                }
                if (!anyValid) {
                    return false;
                }
                return true;
            };
            return PhoneEditor;
        }(Serenity.StringEditor));
        __decorate([
            Serenity.Decorators.option()
        ], PhoneEditor.prototype, "multiple", void 0);
        PhoneEditor = PhoneEditor_1 = __decorate([
            Serenity.Decorators.registerEditor()
        ], PhoneEditor);
        Northwind.PhoneEditor = PhoneEditor;
        var PhoneEditor_1;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ShipperDialog = (function (_super) {
            __extends(ShipperDialog, _super);
            function ShipperDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Northwind.ShipperForm(_this.idPrefix);
                return _this;
            }
            ShipperDialog.prototype.getFormKey = function () { return Northwind.ShipperForm.formKey; };
            ShipperDialog.prototype.getIdProperty = function () { return Northwind.ShipperRow.idProperty; };
            ShipperDialog.prototype.getLocalTextPrefix = function () { return Northwind.ShipperRow.localTextPrefix; };
            ShipperDialog.prototype.getNameProperty = function () { return Northwind.ShipperRow.nameProperty; };
            ShipperDialog.prototype.getService = function () { return Northwind.ShipperService.baseUrl; };
            ShipperDialog.prototype.getLanguages = function () {
                return Geshotel.LanguageList.getValue();
            };
            return ShipperDialog;
        }(Serenity.EntityDialog));
        ShipperDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], ShipperDialog);
        Northwind.ShipperDialog = ShipperDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ShipperFormatter = (function () {
            function ShipperFormatter() {
            }
            ShipperFormatter.prototype.format = function (ctx) {
                return "<span class='shipper-symbol shipper-" +
                    Q.replaceAll((ctx.value || '').toString(), ' ', '') +
                    "'>" + Q.htmlEncode(ctx.value) + '</span>';
            };
            return ShipperFormatter;
        }());
        ShipperFormatter = __decorate([
            Serenity.Decorators.registerFormatter()
        ], ShipperFormatter);
        Northwind.ShipperFormatter = ShipperFormatter;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var ShipperGrid = (function (_super) {
            __extends(ShipperGrid, _super);
            function ShipperGrid(container) {
                return _super.call(this, container) || this;
            }
            ShipperGrid.prototype.getColumnsKey = function () { return "Northwind.Shipper"; };
            ShipperGrid.prototype.getDialogType = function () { return Northwind.ShipperDialog; };
            ShipperGrid.prototype.getIdProperty = function () { return Northwind.ShipperRow.idProperty; };
            ShipperGrid.prototype.getLocalTextPrefix = function () { return Northwind.ShipperRow.localTextPrefix; };
            ShipperGrid.prototype.getService = function () { return Northwind.ShipperService.baseUrl; };
            return ShipperGrid;
        }(Serenity.EntityGrid));
        ShipperGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], ShipperGrid);
        Northwind.ShipperGrid = ShipperGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var SupplierDialog = (function (_super) {
            __extends(SupplierDialog, _super);
            function SupplierDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Northwind.SupplierForm(_this.idPrefix);
                return _this;
            }
            SupplierDialog.prototype.getFormKey = function () { return Northwind.SupplierForm.formKey; };
            SupplierDialog.prototype.getIdProperty = function () { return Northwind.SupplierRow.idProperty; };
            SupplierDialog.prototype.getLocalTextPrefix = function () { return Northwind.SupplierRow.localTextPrefix; };
            SupplierDialog.prototype.getNameProperty = function () { return Northwind.SupplierRow.nameProperty; };
            SupplierDialog.prototype.getService = function () { return Northwind.SupplierService.baseUrl; };
            SupplierDialog.prototype.getLanguages = function () {
                return Geshotel.LanguageList.getValue();
            };
            return SupplierDialog;
        }(Serenity.EntityDialog));
        SupplierDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], SupplierDialog);
        Northwind.SupplierDialog = SupplierDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var SupplierGrid = (function (_super) {
            __extends(SupplierGrid, _super);
            function SupplierGrid(container) {
                return _super.call(this, container) || this;
            }
            SupplierGrid.prototype.getColumnsKey = function () { return "Northwind.Supplier"; };
            SupplierGrid.prototype.getDialogType = function () { return Northwind.SupplierDialog; };
            SupplierGrid.prototype.getIdProperty = function () { return Northwind.SupplierRow.idProperty; };
            SupplierGrid.prototype.getLocalTextPrefix = function () { return Northwind.SupplierRow.localTextPrefix; };
            SupplierGrid.prototype.getService = function () { return Northwind.SupplierService.baseUrl; };
            return SupplierGrid;
        }(Serenity.EntityGrid));
        SupplierGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], SupplierGrid);
        Northwind.SupplierGrid = SupplierGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var TerritoryDialog = (function (_super) {
            __extends(TerritoryDialog, _super);
            function TerritoryDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Northwind.TerritoryForm(_this.idPrefix);
                return _this;
            }
            TerritoryDialog.prototype.getFormKey = function () { return Northwind.TerritoryForm.formKey; };
            TerritoryDialog.prototype.getIdProperty = function () { return Northwind.TerritoryRow.idProperty; };
            TerritoryDialog.prototype.getLocalTextPrefix = function () { return Northwind.TerritoryRow.localTextPrefix; };
            TerritoryDialog.prototype.getNameProperty = function () { return Northwind.TerritoryRow.nameProperty; };
            TerritoryDialog.prototype.getService = function () { return Northwind.TerritoryService.baseUrl; };
            TerritoryDialog.prototype.getLanguages = function () {
                return Geshotel.LanguageList.getValue();
            };
            return TerritoryDialog;
        }(Serenity.EntityDialog));
        TerritoryDialog = __decorate([
            Serenity.Decorators.registerClass()
        ], TerritoryDialog);
        Northwind.TerritoryDialog = TerritoryDialog;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Northwind;
    (function (Northwind) {
        var TerritoryGrid = (function (_super) {
            __extends(TerritoryGrid, _super);
            function TerritoryGrid(container) {
                return _super.call(this, container) || this;
            }
            TerritoryGrid.prototype.getColumnsKey = function () { return "Northwind.Territory"; };
            TerritoryGrid.prototype.getDialogType = function () { return Northwind.TerritoryDialog; };
            TerritoryGrid.prototype.getIdProperty = function () { return Northwind.TerritoryRow.idProperty; };
            TerritoryGrid.prototype.getLocalTextPrefix = function () { return Northwind.TerritoryRow.localTextPrefix; };
            TerritoryGrid.prototype.getService = function () { return Northwind.TerritoryService.baseUrl; };
            return TerritoryGrid;
        }(Serenity.EntityGrid));
        TerritoryGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TerritoryGrid);
        Northwind.TerritoryGrid = TerritoryGrid;
    })(Northwind = Geshotel.Northwind || (Geshotel.Northwind = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var BusinessUnitDialog = (function (_super) {
            __extends(BusinessUnitDialog, _super);
            function BusinessUnitDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Organization.BusinessUnitForm(_this.idPrefix);
                return _this;
            }
            BusinessUnitDialog.prototype.getFormKey = function () { return Organization.BusinessUnitForm.formKey; };
            BusinessUnitDialog.prototype.getIdProperty = function () { return Organization.BusinessUnitRow.idProperty; };
            BusinessUnitDialog.prototype.getLocalTextPrefix = function () { return Organization.BusinessUnitRow.localTextPrefix; };
            BusinessUnitDialog.prototype.getNameProperty = function () { return Organization.BusinessUnitRow.nameProperty; };
            BusinessUnitDialog.prototype.getService = function () { return Organization.BusinessUnitService.baseUrl; };
            return BusinessUnitDialog;
        }(Serenity.EntityDialog));
        BusinessUnitDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], BusinessUnitDialog);
        Organization.BusinessUnitDialog = BusinessUnitDialog;
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var BusinessUnitEditor = (function (_super) {
            __extends(BusinessUnitEditor, _super);
            function BusinessUnitEditor(hidden) {
                return _super.call(this, hidden) || this;
            }
            BusinessUnitEditor.prototype.getLookupKey = function () {
                return Organization.BusinessUnitRow.lookupKey;
            };
            BusinessUnitEditor.prototype.getItemText = function (item, lookup) {
                var visited = {};
                var text = item.Name;
                while (item.ParentUnitId != null && !visited[item.ParentUnitId]) {
                    item = lookup.itemById[item.ParentUnitId];
                    if (!item)
                        break;
                    visited[item.UnitId] = true;
                    text = item.Name + " >> " + text;
                }
                return text;
            };
            return BusinessUnitEditor;
        }(Serenity.LookupEditorBase));
        BusinessUnitEditor = __decorate([
            Serenity.Decorators.registerEditor()
        ], BusinessUnitEditor);
        Organization.BusinessUnitEditor = BusinessUnitEditor;
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var BusinessUnitGrid = (function (_super) {
            __extends(BusinessUnitGrid, _super);
            function BusinessUnitGrid(container) {
                var _this = _super.call(this, container) || this;
                new Serenity.TreeGridMixin({
                    grid: _this,
                    getParentId: function (x) { return x.ParentUnitId; },
                    toggleField: Organization.BusinessUnitRow.Fields.Name,
                    initialCollapse: function () { return false; }
                });
                return _this;
            }
            BusinessUnitGrid.prototype.getColumnsKey = function () { return 'Organization.BusinessUnit'; };
            BusinessUnitGrid.prototype.getDialogType = function () { return Organization.BusinessUnitDialog; };
            BusinessUnitGrid.prototype.getIdProperty = function () { return Organization.BusinessUnitRow.idProperty; };
            BusinessUnitGrid.prototype.getLocalTextPrefix = function () { return Organization.BusinessUnitRow.localTextPrefix; };
            BusinessUnitGrid.prototype.getService = function () { return Organization.BusinessUnitService.baseUrl; };
            BusinessUnitGrid.prototype.subDialogDataChange = function () {
                _super.prototype.subDialogDataChange.call(this);
                Q.reloadLookup(Organization.BusinessUnitRow.lookupKey);
            };
            BusinessUnitGrid.prototype.usePager = function () {
                return false;
            };
            BusinessUnitGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                columns.splice(Q.indexOf(columns, function (x) { return x.name == Organization.BusinessUnitRow.Fields.Name; }) + 1, 0, {
                    field: 'Add Child Unit',
                    name: '',
                    format: function (ctx) { return '<a class="inline-action add-child-unit" title="add child unit"></a>'; },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });
                return columns;
            };
            BusinessUnitGrid.prototype.onClick = function (e, row, cell) {
                _super.prototype.onClick.call(this, e, row, cell);
                if (e.isDefaultPrevented())
                    return;
                var item = this.itemAt(row);
                var target = $(e.target);
                if (target.parent().hasClass('inline-action'))
                    target = target.parent();
                if (target.hasClass('inline-action')) {
                    e.preventDefault();
                    if (target.hasClass('add-child-unit')) {
                        var dlg = new Organization.BusinessUnitDialog();
                        this.initDialog(dlg);
                        dlg.loadEntityAndOpenDialog({
                            ParentUnitId: item.UnitId
                        });
                    }
                }
            };
            return BusinessUnitGrid;
        }(Serenity.EntityGrid));
        BusinessUnitGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], BusinessUnitGrid);
        Organization.BusinessUnitGrid = BusinessUnitGrid;
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var ContactDialog = (function (_super) {
            __extends(ContactDialog, _super);
            function ContactDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Organization.ContactForm(_this.idPrefix);
                return _this;
            }
            ContactDialog.prototype.getFormKey = function () { return Organization.ContactForm.formKey; };
            ContactDialog.prototype.getIdProperty = function () { return Organization.ContactRow.idProperty; };
            ContactDialog.prototype.getLocalTextPrefix = function () { return Organization.ContactRow.localTextPrefix; };
            ContactDialog.prototype.getNameProperty = function () { return Organization.ContactRow.nameProperty; };
            ContactDialog.prototype.getService = function () { return Organization.ContactService.baseUrl; };
            return ContactDialog;
        }(Serenity.EntityDialog));
        ContactDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], ContactDialog);
        Organization.ContactDialog = ContactDialog;
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Organization;
    (function (Organization) {
        var ContactGrid = (function (_super) {
            __extends(ContactGrid, _super);
            function ContactGrid(container) {
                return _super.call(this, container) || this;
            }
            ContactGrid.prototype.getColumnsKey = function () { return 'Organization.Contact'; };
            ContactGrid.prototype.getDialogType = function () { return Organization.ContactDialog; };
            ContactGrid.prototype.getIdProperty = function () { return Organization.ContactRow.idProperty; };
            ContactGrid.prototype.getLocalTextPrefix = function () { return Organization.ContactRow.localTextPrefix; };
            ContactGrid.prototype.getService = function () { return Organization.ContactService.baseUrl; };
            return ContactGrid;
        }(Serenity.EntityGrid));
        ContactGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], ContactGrid);
        Organization.ContactGrid = ContactGrid;
    })(Organization = Geshotel.Organization || (Geshotel.Organization = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var AmbitoOfertaDialog = (function (_super) {
            __extends(AmbitoOfertaDialog, _super);
            function AmbitoOfertaDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.AmbitoOfertaForm(_this.idPrefix);
                return _this;
            }
            AmbitoOfertaDialog.prototype.getFormKey = function () { return Portal.AmbitoOfertaForm.formKey; };
            AmbitoOfertaDialog.prototype.getIdProperty = function () { return Portal.AmbitoOfertaRow.idProperty; };
            AmbitoOfertaDialog.prototype.getLocalTextPrefix = function () { return Portal.AmbitoOfertaRow.localTextPrefix; };
            AmbitoOfertaDialog.prototype.getNameProperty = function () { return Portal.AmbitoOfertaRow.nameProperty; };
            AmbitoOfertaDialog.prototype.getService = function () { return Portal.AmbitoOfertaService.baseUrl; };
            return AmbitoOfertaDialog;
        }(Serenity.EntityDialog));
        AmbitoOfertaDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], AmbitoOfertaDialog);
        Portal.AmbitoOfertaDialog = AmbitoOfertaDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var AmbitoOfertaGrid = (function (_super) {
            __extends(AmbitoOfertaGrid, _super);
            function AmbitoOfertaGrid(container) {
                return _super.call(this, container) || this;
            }
            AmbitoOfertaGrid.prototype.getColumnsKey = function () { return 'Portal.AmbitoOferta'; };
            AmbitoOfertaGrid.prototype.getDialogType = function () { return Portal.AmbitoOfertaDialog; };
            AmbitoOfertaGrid.prototype.getIdProperty = function () { return Portal.AmbitoOfertaRow.idProperty; };
            AmbitoOfertaGrid.prototype.getLocalTextPrefix = function () { return Portal.AmbitoOfertaRow.localTextPrefix; };
            AmbitoOfertaGrid.prototype.getService = function () { return Portal.AmbitoOfertaService.baseUrl; };
            return AmbitoOfertaGrid;
        }(Serenity.EntityGrid));
        AmbitoOfertaGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], AmbitoOfertaGrid);
        Portal.AmbitoOfertaGrid = AmbitoOfertaGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var CategoriaHotelesDialog = (function (_super) {
            __extends(CategoriaHotelesDialog, _super);
            function CategoriaHotelesDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.CategoriaHotelesForm(_this.idPrefix);
                return _this;
            }
            CategoriaHotelesDialog.prototype.getFormKey = function () { return Portal.CategoriaHotelesForm.formKey; };
            CategoriaHotelesDialog.prototype.getIdProperty = function () { return Portal.CategoriaHotelesRow.idProperty; };
            CategoriaHotelesDialog.prototype.getLocalTextPrefix = function () { return Portal.CategoriaHotelesRow.localTextPrefix; };
            CategoriaHotelesDialog.prototype.getNameProperty = function () { return Portal.CategoriaHotelesRow.nameProperty; };
            CategoriaHotelesDialog.prototype.getService = function () { return Portal.CategoriaHotelesService.baseUrl; };
            return CategoriaHotelesDialog;
        }(Serenity.EntityDialog));
        CategoriaHotelesDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], CategoriaHotelesDialog);
        Portal.CategoriaHotelesDialog = CategoriaHotelesDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var CategoriaHotelesGrid = (function (_super) {
            __extends(CategoriaHotelesGrid, _super);
            function CategoriaHotelesGrid(container) {
                return _super.call(this, container) || this;
            }
            CategoriaHotelesGrid.prototype.getColumnsKey = function () { return 'Portal.CategoriaHoteles'; };
            CategoriaHotelesGrid.prototype.getDialogType = function () { return Portal.CategoriaHotelesDialog; };
            CategoriaHotelesGrid.prototype.getIdProperty = function () { return Portal.CategoriaHotelesRow.idProperty; };
            CategoriaHotelesGrid.prototype.getLocalTextPrefix = function () { return Portal.CategoriaHotelesRow.localTextPrefix; };
            CategoriaHotelesGrid.prototype.getService = function () { return Portal.CategoriaHotelesService.baseUrl; };
            return CategoriaHotelesGrid;
        }(Serenity.EntityGrid));
        CategoriaHotelesGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], CategoriaHotelesGrid);
        Portal.CategoriaHotelesGrid = CategoriaHotelesGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ComunidadesAutonomasDialog = (function (_super) {
            __extends(ComunidadesAutonomasDialog, _super);
            function ComunidadesAutonomasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.ComunidadesAutonomasForm(_this.idPrefix);
                return _this;
            }
            ComunidadesAutonomasDialog.prototype.getFormKey = function () { return Portal.ComunidadesAutonomasForm.formKey; };
            ComunidadesAutonomasDialog.prototype.getIdProperty = function () { return Portal.ComunidadesAutonomasRow.idProperty; };
            ComunidadesAutonomasDialog.prototype.getLocalTextPrefix = function () { return Portal.ComunidadesAutonomasRow.localTextPrefix; };
            ComunidadesAutonomasDialog.prototype.getNameProperty = function () { return Portal.ComunidadesAutonomasRow.nameProperty; };
            ComunidadesAutonomasDialog.prototype.getService = function () { return Portal.ComunidadesAutonomasService.baseUrl; };
            return ComunidadesAutonomasDialog;
        }(Serenity.EntityDialog));
        ComunidadesAutonomasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], ComunidadesAutonomasDialog);
        Portal.ComunidadesAutonomasDialog = ComunidadesAutonomasDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ComunidadesAutonomasGrid = (function (_super) {
            __extends(ComunidadesAutonomasGrid, _super);
            function ComunidadesAutonomasGrid(container) {
                return _super.call(this, container) || this;
            }
            ComunidadesAutonomasGrid.prototype.getColumnsKey = function () { return 'Portal.ComunidadesAutonomas'; };
            ComunidadesAutonomasGrid.prototype.getDialogType = function () { return Portal.ComunidadesAutonomasDialog; };
            ComunidadesAutonomasGrid.prototype.getIdProperty = function () { return Portal.ComunidadesAutonomasRow.idProperty; };
            ComunidadesAutonomasGrid.prototype.getLocalTextPrefix = function () { return Portal.ComunidadesAutonomasRow.localTextPrefix; };
            ComunidadesAutonomasGrid.prototype.getService = function () { return Portal.ComunidadesAutonomasService.baseUrl; };
            ComunidadesAutonomasGrid.prototype.getDefaultSortBy = function () {
                return [Portal.ComunidadesAutonomasRow.Fields.ComunidadAutonoma];
            };
            ComunidadesAutonomasGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/ComunidadesAutonomas/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return ComunidadesAutonomasGrid;
        }(Serenity.EntityGrid));
        ComunidadesAutonomasGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], ComunidadesAutonomasGrid);
        Portal.ComunidadesAutonomasGrid = ComunidadesAutonomasGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var EmpresasDialog = (function (_super) {
            __extends(EmpresasDialog, _super);
            function EmpresasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.EmpresasForm(_this.idPrefix);
                return _this;
            }
            EmpresasDialog.prototype.getFormKey = function () { return Portal.EmpresasForm.formKey; };
            EmpresasDialog.prototype.getIdProperty = function () { return Portal.EmpresasRow.idProperty; };
            EmpresasDialog.prototype.getLocalTextPrefix = function () { return Portal.EmpresasRow.localTextPrefix; };
            EmpresasDialog.prototype.getNameProperty = function () { return Portal.EmpresasRow.nameProperty; };
            EmpresasDialog.prototype.getService = function () { return Portal.EmpresasService.baseUrl; };
            return EmpresasDialog;
        }(Serenity.EntityDialog));
        EmpresasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], EmpresasDialog);
        Portal.EmpresasDialog = EmpresasDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var EmpresasGrid = (function (_super) {
            __extends(EmpresasGrid, _super);
            function EmpresasGrid(container) {
                return _super.call(this, container) || this;
            }
            EmpresasGrid.prototype.getColumnsKey = function () { return 'Portal.Empresas'; };
            EmpresasGrid.prototype.getDialogType = function () { return Portal.EmpresasDialog; };
            EmpresasGrid.prototype.getIdProperty = function () { return Portal.EmpresasRow.idProperty; };
            EmpresasGrid.prototype.getLocalTextPrefix = function () { return Portal.EmpresasRow.localTextPrefix; };
            EmpresasGrid.prototype.getService = function () { return Portal.EmpresasService.baseUrl; };
            EmpresasGrid.prototype.getDefaultSortBy = function () {
                return [Portal.EmpresasRow.Fields.Empresa];
            };
            EmpresasGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/Empresas/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return EmpresasGrid;
        }(Serenity.EntityGrid));
        EmpresasGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], EmpresasGrid);
        Portal.EmpresasGrid = EmpresasGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FormasDePagoDialog = (function (_super) {
            __extends(FormasDePagoDialog, _super);
            function FormasDePagoDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.FormasDePagoForm(_this.idPrefix);
                return _this;
            }
            FormasDePagoDialog.prototype.getFormKey = function () { return Portal.FormasDePagoForm.formKey; };
            FormasDePagoDialog.prototype.getIdProperty = function () { return Portal.FormasDePagoRow.idProperty; };
            FormasDePagoDialog.prototype.getLocalTextPrefix = function () { return Portal.FormasDePagoRow.localTextPrefix; };
            FormasDePagoDialog.prototype.getNameProperty = function () { return Portal.FormasDePagoRow.nameProperty; };
            FormasDePagoDialog.prototype.getService = function () { return Portal.FormasDePagoService.baseUrl; };
            return FormasDePagoDialog;
        }(Serenity.EntityDialog));
        FormasDePagoDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], FormasDePagoDialog);
        Portal.FormasDePagoDialog = FormasDePagoDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FormasDePagoGrid = (function (_super) {
            __extends(FormasDePagoGrid, _super);
            function FormasDePagoGrid(container) {
                return _super.call(this, container) || this;
            }
            FormasDePagoGrid.prototype.getColumnsKey = function () { return 'Portal.FormasDePago'; };
            FormasDePagoGrid.prototype.getDialogType = function () { return Portal.FormasDePagoDialog; };
            FormasDePagoGrid.prototype.getIdProperty = function () { return Portal.FormasDePagoRow.idProperty; };
            FormasDePagoGrid.prototype.getLocalTextPrefix = function () { return Portal.FormasDePagoRow.localTextPrefix; };
            FormasDePagoGrid.prototype.getService = function () { return Portal.FormasDePagoService.baseUrl; };
            FormasDePagoGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/FormasDePago/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return FormasDePagoGrid;
        }(Serenity.EntityGrid));
        FormasDePagoGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], FormasDePagoGrid);
        Portal.FormasDePagoGrid = FormasDePagoGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FrecuenciaFacturacionDialog = (function (_super) {
            __extends(FrecuenciaFacturacionDialog, _super);
            function FrecuenciaFacturacionDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.FrecuenciaFacturacionForm(_this.idPrefix);
                return _this;
            }
            FrecuenciaFacturacionDialog.prototype.getFormKey = function () { return Portal.FrecuenciaFacturacionForm.formKey; };
            FrecuenciaFacturacionDialog.prototype.getIdProperty = function () { return Portal.FrecuenciaFacturacionRow.idProperty; };
            FrecuenciaFacturacionDialog.prototype.getLocalTextPrefix = function () { return Portal.FrecuenciaFacturacionRow.localTextPrefix; };
            FrecuenciaFacturacionDialog.prototype.getNameProperty = function () { return Portal.FrecuenciaFacturacionRow.nameProperty; };
            FrecuenciaFacturacionDialog.prototype.getService = function () { return Portal.FrecuenciaFacturacionService.baseUrl; };
            return FrecuenciaFacturacionDialog;
        }(Serenity.EntityDialog));
        FrecuenciaFacturacionDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], FrecuenciaFacturacionDialog);
        Portal.FrecuenciaFacturacionDialog = FrecuenciaFacturacionDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var FrecuenciaFacturacionGrid = (function (_super) {
            __extends(FrecuenciaFacturacionGrid, _super);
            function FrecuenciaFacturacionGrid(container) {
                return _super.call(this, container) || this;
            }
            FrecuenciaFacturacionGrid.prototype.getColumnsKey = function () { return 'Portal.FrecuenciaFacturacion'; };
            FrecuenciaFacturacionGrid.prototype.getDialogType = function () { return Portal.FrecuenciaFacturacionDialog; };
            FrecuenciaFacturacionGrid.prototype.getIdProperty = function () { return Portal.FrecuenciaFacturacionRow.idProperty; };
            FrecuenciaFacturacionGrid.prototype.getLocalTextPrefix = function () { return Portal.FrecuenciaFacturacionRow.localTextPrefix; };
            FrecuenciaFacturacionGrid.prototype.getService = function () { return Portal.FrecuenciaFacturacionService.baseUrl; };
            return FrecuenciaFacturacionGrid;
        }(Serenity.EntityGrid));
        FrecuenciaFacturacionGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], FrecuenciaFacturacionGrid);
        Portal.FrecuenciaFacturacionGrid = FrecuenciaFacturacionGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeClienteDialog = (function (_super) {
            __extends(GruposDeClienteDialog, _super);
            function GruposDeClienteDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.GruposDeClienteForm(_this.idPrefix);
                return _this;
            }
            GruposDeClienteDialog.prototype.getFormKey = function () { return Portal.GruposDeClienteForm.formKey; };
            GruposDeClienteDialog.prototype.getIdProperty = function () { return Portal.GruposDeClienteRow.idProperty; };
            GruposDeClienteDialog.prototype.getLocalTextPrefix = function () { return Portal.GruposDeClienteRow.localTextPrefix; };
            GruposDeClienteDialog.prototype.getNameProperty = function () { return Portal.GruposDeClienteRow.nameProperty; };
            GruposDeClienteDialog.prototype.getService = function () { return Portal.GruposDeClienteService.baseUrl; };
            return GruposDeClienteDialog;
        }(Serenity.EntityDialog));
        GruposDeClienteDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], GruposDeClienteDialog);
        Portal.GruposDeClienteDialog = GruposDeClienteDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeClienteGrid = (function (_super) {
            __extends(GruposDeClienteGrid, _super);
            function GruposDeClienteGrid(container) {
                return _super.call(this, container) || this;
            }
            GruposDeClienteGrid.prototype.getColumnsKey = function () { return 'Portal.GruposDeCliente'; };
            GruposDeClienteGrid.prototype.getDialogType = function () { return Portal.GruposDeClienteDialog; };
            GruposDeClienteGrid.prototype.getIdProperty = function () { return Portal.GruposDeClienteRow.idProperty; };
            GruposDeClienteGrid.prototype.getLocalTextPrefix = function () { return Portal.GruposDeClienteRow.localTextPrefix; };
            GruposDeClienteGrid.prototype.getService = function () { return Portal.GruposDeClienteService.baseUrl; };
            return GruposDeClienteGrid;
        }(Serenity.EntityGrid));
        GruposDeClienteGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], GruposDeClienteGrid);
        Portal.GruposDeClienteGrid = GruposDeClienteGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeServiciosDialog = (function (_super) {
            __extends(GruposDeServiciosDialog, _super);
            function GruposDeServiciosDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.GruposDeServiciosForm(_this.idPrefix);
                return _this;
            }
            GruposDeServiciosDialog.prototype.getFormKey = function () { return Portal.GruposDeServiciosForm.formKey; };
            GruposDeServiciosDialog.prototype.getIdProperty = function () { return Portal.GruposDeServiciosRow.idProperty; };
            GruposDeServiciosDialog.prototype.getLocalTextPrefix = function () { return Portal.GruposDeServiciosRow.localTextPrefix; };
            GruposDeServiciosDialog.prototype.getNameProperty = function () { return Portal.GruposDeServiciosRow.nameProperty; };
            GruposDeServiciosDialog.prototype.getService = function () { return Portal.GruposDeServiciosService.baseUrl; };
            return GruposDeServiciosDialog;
        }(Serenity.EntityDialog));
        GruposDeServiciosDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], GruposDeServiciosDialog);
        Portal.GruposDeServiciosDialog = GruposDeServiciosDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposDeServiciosGrid = (function (_super) {
            __extends(GruposDeServiciosGrid, _super);
            function GruposDeServiciosGrid(container) {
                return _super.call(this, container) || this;
            }
            GruposDeServiciosGrid.prototype.getColumnsKey = function () { return 'Portal.GruposDeServicios'; };
            GruposDeServiciosGrid.prototype.getDialogType = function () { return Portal.GruposDeServiciosDialog; };
            GruposDeServiciosGrid.prototype.getIdProperty = function () { return Portal.GruposDeServiciosRow.idProperty; };
            GruposDeServiciosGrid.prototype.getLocalTextPrefix = function () { return Portal.GruposDeServiciosRow.localTextPrefix; };
            GruposDeServiciosGrid.prototype.getService = function () { return Portal.GruposDeServiciosService.baseUrl; };
            return GruposDeServiciosGrid;
        }(Serenity.EntityGrid));
        GruposDeServiciosGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], GruposDeServiciosGrid);
        Portal.GruposDeServiciosGrid = GruposDeServiciosGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposHabitacionDialog = (function (_super) {
            __extends(GruposHabitacionDialog, _super);
            function GruposHabitacionDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.GruposHabitacionForm(_this.idPrefix);
                return _this;
            }
            GruposHabitacionDialog.prototype.getFormKey = function () { return Portal.GruposHabitacionForm.formKey; };
            GruposHabitacionDialog.prototype.getIdProperty = function () { return Portal.GruposHabitacionRow.idProperty; };
            GruposHabitacionDialog.prototype.getLocalTextPrefix = function () { return Portal.GruposHabitacionRow.localTextPrefix; };
            GruposHabitacionDialog.prototype.getNameProperty = function () { return Portal.GruposHabitacionRow.nameProperty; };
            GruposHabitacionDialog.prototype.getService = function () { return Portal.GruposHabitacionService.baseUrl; };
            return GruposHabitacionDialog;
        }(Serenity.EntityDialog));
        GruposHabitacionDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], GruposHabitacionDialog);
        Portal.GruposHabitacionDialog = GruposHabitacionDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var GruposHabitacionGrid = (function (_super) {
            __extends(GruposHabitacionGrid, _super);
            function GruposHabitacionGrid(container) {
                return _super.call(this, container) || this;
            }
            GruposHabitacionGrid.prototype.getColumnsKey = function () { return 'Portal.GruposHabitacion'; };
            GruposHabitacionGrid.prototype.getDialogType = function () { return Portal.GruposHabitacionDialog; };
            GruposHabitacionGrid.prototype.getIdProperty = function () { return Portal.GruposHabitacionRow.idProperty; };
            GruposHabitacionGrid.prototype.getLocalTextPrefix = function () { return Portal.GruposHabitacionRow.localTextPrefix; };
            GruposHabitacionGrid.prototype.getService = function () { return Portal.GruposHabitacionService.baseUrl; };
            return GruposHabitacionGrid;
        }(Serenity.EntityGrid));
        GruposHabitacionGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], GruposHabitacionGrid);
        Portal.GruposHabitacionGrid = GruposHabitacionGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var HotelesDialog = (function (_super) {
            __extends(HotelesDialog, _super);
            function HotelesDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.HotelesForm(_this.idPrefix);
                return _this;
            }
            HotelesDialog.prototype.getFormKey = function () { return Portal.HotelesForm.formKey; };
            HotelesDialog.prototype.getIdProperty = function () { return Portal.HotelesRow.idProperty; };
            HotelesDialog.prototype.getLocalTextPrefix = function () { return Portal.HotelesRow.localTextPrefix; };
            HotelesDialog.prototype.getNameProperty = function () { return Portal.HotelesRow.nameProperty; };
            HotelesDialog.prototype.getService = function () { return Portal.HotelesService.baseUrl; };
            return HotelesDialog;
        }(Serenity.EntityDialog));
        HotelesDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], HotelesDialog);
        Portal.HotelesDialog = HotelesDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var HotelesGrid = (function (_super) {
            __extends(HotelesGrid, _super);
            function HotelesGrid(container) {
                return _super.call(this, container) || this;
            }
            HotelesGrid.prototype.getColumnsKey = function () { return 'Portal.Hoteles'; };
            HotelesGrid.prototype.getDialogType = function () { return Portal.HotelesDialog; };
            HotelesGrid.prototype.getIdProperty = function () { return Portal.HotelesRow.idProperty; };
            HotelesGrid.prototype.getLocalTextPrefix = function () { return Portal.HotelesRow.localTextPrefix; };
            HotelesGrid.prototype.getService = function () { return Portal.HotelesService.baseUrl; };
            HotelesGrid.prototype.getDefaultSortBy = function () {
                return [Portal.HotelesRow.Fields.HotelId];
            };
            HotelesGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/Hoteles/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return HotelesGrid;
        }(Serenity.EntityGrid));
        HotelesGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], HotelesGrid);
        Portal.HotelesGrid = HotelesGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var MonedasDialog = (function (_super) {
            __extends(MonedasDialog, _super);
            function MonedasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.MonedasForm(_this.idPrefix);
                return _this;
            }
            MonedasDialog.prototype.getFormKey = function () { return Portal.MonedasForm.formKey; };
            MonedasDialog.prototype.getIdProperty = function () { return Portal.MonedasRow.idProperty; };
            MonedasDialog.prototype.getLocalTextPrefix = function () { return Portal.MonedasRow.localTextPrefix; };
            MonedasDialog.prototype.getNameProperty = function () { return Portal.MonedasRow.nameProperty; };
            MonedasDialog.prototype.getService = function () { return Portal.MonedasService.baseUrl; };
            return MonedasDialog;
        }(Serenity.EntityDialog));
        MonedasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], MonedasDialog);
        Portal.MonedasDialog = MonedasDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var MonedasGrid = (function (_super) {
            __extends(MonedasGrid, _super);
            function MonedasGrid(container) {
                return _super.call(this, container) || this;
            }
            MonedasGrid.prototype.getColumnsKey = function () { return 'Portal.Monedas'; };
            MonedasGrid.prototype.getDialogType = function () { return Portal.MonedasDialog; };
            MonedasGrid.prototype.getIdProperty = function () { return Portal.MonedasRow.idProperty; };
            MonedasGrid.prototype.getLocalTextPrefix = function () { return Portal.MonedasRow.localTextPrefix; };
            MonedasGrid.prototype.getService = function () { return Portal.MonedasService.baseUrl; };
            MonedasGrid.prototype.getDefaultSortBy = function () {
                return [Portal.MonedasRow.Fields.MonedaId];
            };
            MonedasGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/Monedas/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return MonedasGrid;
        }(Serenity.EntityGrid));
        MonedasGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], MonedasGrid);
        Portal.MonedasGrid = MonedasGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var NacionesDialog = (function (_super) {
            __extends(NacionesDialog, _super);
            function NacionesDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.NacionesForm(_this.idPrefix);
                return _this;
            }
            NacionesDialog.prototype.getFormKey = function () { return Portal.NacionesForm.formKey; };
            NacionesDialog.prototype.getIdProperty = function () { return Portal.NacionesRow.idProperty; };
            NacionesDialog.prototype.getLocalTextPrefix = function () { return Portal.NacionesRow.localTextPrefix; };
            NacionesDialog.prototype.getNameProperty = function () { return Portal.NacionesRow.nameProperty; };
            NacionesDialog.prototype.getService = function () { return Portal.NacionesService.baseUrl; };
            return NacionesDialog;
        }(Serenity.EntityDialog));
        NacionesDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], NacionesDialog);
        Portal.NacionesDialog = NacionesDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var NacionesGrid = (function (_super) {
            __extends(NacionesGrid, _super);
            function NacionesGrid(container) {
                return _super.call(this, container) || this;
            }
            NacionesGrid.prototype.getColumnsKey = function () { return 'Portal.Naciones'; };
            NacionesGrid.prototype.getDialogType = function () { return Portal.NacionesDialog; };
            NacionesGrid.prototype.getIdProperty = function () { return Portal.NacionesRow.idProperty; };
            NacionesGrid.prototype.getLocalTextPrefix = function () { return Portal.NacionesRow.localTextPrefix; };
            NacionesGrid.prototype.getService = function () { return Portal.NacionesService.baseUrl; };
            NacionesGrid.prototype.getDefaultSortBy = function () {
                return [Portal.NacionesRow.Fields.Nacion];
            };
            NacionesGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/Naciones/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return NacionesGrid;
        }(Serenity.EntityGrid));
        NacionesGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], NacionesGrid);
        Portal.NacionesGrid = NacionesGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ProvinciasDialog = (function (_super) {
            __extends(ProvinciasDialog, _super);
            function ProvinciasDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.ProvinciasForm(_this.idPrefix);
                return _this;
            }
            ProvinciasDialog.prototype.getFormKey = function () { return Portal.ProvinciasForm.formKey; };
            ProvinciasDialog.prototype.getIdProperty = function () { return Portal.ProvinciasRow.idProperty; };
            ProvinciasDialog.prototype.getLocalTextPrefix = function () { return Portal.ProvinciasRow.localTextPrefix; };
            ProvinciasDialog.prototype.getNameProperty = function () { return Portal.ProvinciasRow.nameProperty; };
            ProvinciasDialog.prototype.getService = function () { return Portal.ProvinciasService.baseUrl; };
            return ProvinciasDialog;
        }(Serenity.EntityDialog));
        ProvinciasDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], ProvinciasDialog);
        Portal.ProvinciasDialog = ProvinciasDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ProvinciasGrid = (function (_super) {
            __extends(ProvinciasGrid, _super);
            function ProvinciasGrid(container) {
                return _super.call(this, container) || this;
            }
            ProvinciasGrid.prototype.getColumnsKey = function () { return 'Portal.Provincias'; };
            ProvinciasGrid.prototype.getDialogType = function () { return Portal.ProvinciasDialog; };
            ProvinciasGrid.prototype.getIdProperty = function () { return Portal.ProvinciasRow.idProperty; };
            ProvinciasGrid.prototype.getLocalTextPrefix = function () { return Portal.ProvinciasRow.localTextPrefix; };
            ProvinciasGrid.prototype.getService = function () { return Portal.ProvinciasService.baseUrl; };
            ProvinciasGrid.prototype.getDefaultSortBy = function () {
                return [Portal.ProvinciasRow.Fields.Provincia];
            };
            ProvinciasGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/Provincias/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return ProvinciasGrid;
        }(Serenity.EntityGrid));
        ProvinciasGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], ProvinciasGrid);
        Portal.ProvinciasGrid = ProvinciasGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ServiciosDialog = (function (_super) {
            __extends(ServiciosDialog, _super);
            function ServiciosDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.ServiciosForm(_this.idPrefix);
                return _this;
            }
            ServiciosDialog.prototype.getFormKey = function () { return Portal.ServiciosForm.formKey; };
            ServiciosDialog.prototype.getIdProperty = function () { return Portal.ServiciosRow.idProperty; };
            ServiciosDialog.prototype.getLocalTextPrefix = function () { return Portal.ServiciosRow.localTextPrefix; };
            ServiciosDialog.prototype.getNameProperty = function () { return Portal.ServiciosRow.nameProperty; };
            ServiciosDialog.prototype.getService = function () { return Portal.ServiciosService.baseUrl; };
            return ServiciosDialog;
        }(Serenity.EntityDialog));
        ServiciosDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], ServiciosDialog);
        Portal.ServiciosDialog = ServiciosDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var ServiciosGrid = (function (_super) {
            __extends(ServiciosGrid, _super);
            function ServiciosGrid(container) {
                return _super.call(this, container) || this;
            }
            ServiciosGrid.prototype.getColumnsKey = function () { return 'Portal.Servicios'; };
            ServiciosGrid.prototype.getDialogType = function () { return Portal.ServiciosDialog; };
            ServiciosGrid.prototype.getIdProperty = function () { return Portal.ServiciosRow.idProperty; };
            ServiciosGrid.prototype.getLocalTextPrefix = function () { return Portal.ServiciosRow.localTextPrefix; };
            ServiciosGrid.prototype.getService = function () { return Portal.ServiciosService.baseUrl; };
            ServiciosGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Portal/Servicios/ListExcel',
                    separator: true
                }));
                buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            return ServiciosGrid;
        }(Serenity.EntityGrid));
        ServiciosGrid = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.filterable()
        ], ServiciosGrid);
        Portal.ServiciosGrid = ServiciosGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TipoAplicacionOfertaDialog = (function (_super) {
            __extends(TipoAplicacionOfertaDialog, _super);
            function TipoAplicacionOfertaDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TipoAplicacionOfertaForm(_this.idPrefix);
                return _this;
            }
            TipoAplicacionOfertaDialog.prototype.getFormKey = function () { return Portal.TipoAplicacionOfertaForm.formKey; };
            TipoAplicacionOfertaDialog.prototype.getIdProperty = function () { return Portal.TipoAplicacionOfertaRow.idProperty; };
            TipoAplicacionOfertaDialog.prototype.getLocalTextPrefix = function () { return Portal.TipoAplicacionOfertaRow.localTextPrefix; };
            TipoAplicacionOfertaDialog.prototype.getNameProperty = function () { return Portal.TipoAplicacionOfertaRow.nameProperty; };
            TipoAplicacionOfertaDialog.prototype.getService = function () { return Portal.TipoAplicacionOfertaService.baseUrl; };
            return TipoAplicacionOfertaDialog;
        }(Serenity.EntityDialog));
        TipoAplicacionOfertaDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TipoAplicacionOfertaDialog);
        Portal.TipoAplicacionOfertaDialog = TipoAplicacionOfertaDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TipoAplicacionOfertaGrid = (function (_super) {
            __extends(TipoAplicacionOfertaGrid, _super);
            function TipoAplicacionOfertaGrid(container) {
                return _super.call(this, container) || this;
            }
            TipoAplicacionOfertaGrid.prototype.getColumnsKey = function () { return 'Portal.TipoAplicacionOferta'; };
            TipoAplicacionOfertaGrid.prototype.getDialogType = function () { return Portal.TipoAplicacionOfertaDialog; };
            TipoAplicacionOfertaGrid.prototype.getIdProperty = function () { return Portal.TipoAplicacionOfertaRow.idProperty; };
            TipoAplicacionOfertaGrid.prototype.getLocalTextPrefix = function () { return Portal.TipoAplicacionOfertaRow.localTextPrefix; };
            TipoAplicacionOfertaGrid.prototype.getService = function () { return Portal.TipoAplicacionOfertaService.baseUrl; };
            return TipoAplicacionOfertaGrid;
        }(Serenity.EntityGrid));
        TipoAplicacionOfertaGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TipoAplicacionOfertaGrid);
        Portal.TipoAplicacionOfertaGrid = TipoAplicacionOfertaGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposCondicionDialog = (function (_super) {
            __extends(TiposCondicionDialog, _super);
            function TiposCondicionDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposCondicionForm(_this.idPrefix);
                return _this;
            }
            TiposCondicionDialog.prototype.getFormKey = function () { return Portal.TiposCondicionForm.formKey; };
            TiposCondicionDialog.prototype.getIdProperty = function () { return Portal.TiposCondicionRow.idProperty; };
            TiposCondicionDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposCondicionRow.localTextPrefix; };
            TiposCondicionDialog.prototype.getNameProperty = function () { return Portal.TiposCondicionRow.nameProperty; };
            TiposCondicionDialog.prototype.getService = function () { return Portal.TiposCondicionService.baseUrl; };
            return TiposCondicionDialog;
        }(Serenity.EntityDialog));
        TiposCondicionDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposCondicionDialog);
        Portal.TiposCondicionDialog = TiposCondicionDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposCondicionGrid = (function (_super) {
            __extends(TiposCondicionGrid, _super);
            function TiposCondicionGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposCondicionGrid.prototype.getColumnsKey = function () { return 'Portal.TiposCondicion'; };
            TiposCondicionGrid.prototype.getDialogType = function () { return Portal.TiposCondicionDialog; };
            TiposCondicionGrid.prototype.getIdProperty = function () { return Portal.TiposCondicionRow.idProperty; };
            TiposCondicionGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposCondicionRow.localTextPrefix; };
            TiposCondicionGrid.prototype.getService = function () { return Portal.TiposCondicionService.baseUrl; };
            return TiposCondicionGrid;
        }(Serenity.EntityGrid));
        TiposCondicionGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposCondicionGrid);
        Portal.TiposCondicionGrid = TiposCondicionGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeImputacionDialog = (function (_super) {
            __extends(TiposDeImputacionDialog, _super);
            function TiposDeImputacionDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposDeImputacionForm(_this.idPrefix);
                return _this;
            }
            TiposDeImputacionDialog.prototype.getFormKey = function () { return Portal.TiposDeImputacionForm.formKey; };
            TiposDeImputacionDialog.prototype.getIdProperty = function () { return Portal.TiposDeImputacionRow.idProperty; };
            TiposDeImputacionDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposDeImputacionRow.localTextPrefix; };
            TiposDeImputacionDialog.prototype.getNameProperty = function () { return Portal.TiposDeImputacionRow.nameProperty; };
            TiposDeImputacionDialog.prototype.getService = function () { return Portal.TiposDeImputacionService.baseUrl; };
            return TiposDeImputacionDialog;
        }(Serenity.EntityDialog));
        TiposDeImputacionDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposDeImputacionDialog);
        Portal.TiposDeImputacionDialog = TiposDeImputacionDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeImputacionGrid = (function (_super) {
            __extends(TiposDeImputacionGrid, _super);
            function TiposDeImputacionGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposDeImputacionGrid.prototype.getColumnsKey = function () { return 'Portal.TiposDeImputacion'; };
            TiposDeImputacionGrid.prototype.getDialogType = function () { return Portal.TiposDeImputacionDialog; };
            TiposDeImputacionGrid.prototype.getIdProperty = function () { return Portal.TiposDeImputacionRow.idProperty; };
            TiposDeImputacionGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposDeImputacionRow.localTextPrefix; };
            TiposDeImputacionGrid.prototype.getService = function () { return Portal.TiposDeImputacionService.baseUrl; };
            return TiposDeImputacionGrid;
        }(Serenity.EntityGrid));
        TiposDeImputacionGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposDeImputacionGrid);
        Portal.TiposDeImputacionGrid = TiposDeImputacionGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeOfertaDialog = (function (_super) {
            __extends(TiposDeOfertaDialog, _super);
            function TiposDeOfertaDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposDeOfertaForm(_this.idPrefix);
                return _this;
            }
            TiposDeOfertaDialog.prototype.getFormKey = function () { return Portal.TiposDeOfertaForm.formKey; };
            TiposDeOfertaDialog.prototype.getIdProperty = function () { return Portal.TiposDeOfertaRow.idProperty; };
            TiposDeOfertaDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposDeOfertaRow.localTextPrefix; };
            TiposDeOfertaDialog.prototype.getNameProperty = function () { return Portal.TiposDeOfertaRow.nameProperty; };
            TiposDeOfertaDialog.prototype.getService = function () { return Portal.TiposDeOfertaService.baseUrl; };
            return TiposDeOfertaDialog;
        }(Serenity.EntityDialog));
        TiposDeOfertaDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposDeOfertaDialog);
        Portal.TiposDeOfertaDialog = TiposDeOfertaDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposDeOfertaGrid = (function (_super) {
            __extends(TiposDeOfertaGrid, _super);
            function TiposDeOfertaGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposDeOfertaGrid.prototype.getColumnsKey = function () { return 'Portal.TiposDeOferta'; };
            TiposDeOfertaGrid.prototype.getDialogType = function () { return Portal.TiposDeOfertaDialog; };
            TiposDeOfertaGrid.prototype.getIdProperty = function () { return Portal.TiposDeOfertaRow.idProperty; };
            TiposDeOfertaGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposDeOfertaRow.localTextPrefix; };
            TiposDeOfertaGrid.prototype.getService = function () { return Portal.TiposDeOfertaService.baseUrl; };
            return TiposDeOfertaGrid;
        }(Serenity.EntityGrid));
        TiposDeOfertaGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposDeOfertaGrid);
        Portal.TiposDeOfertaGrid = TiposDeOfertaGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHabitacionDialog = (function (_super) {
            __extends(TiposHabitacionDialog, _super);
            function TiposHabitacionDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposHabitacionForm(_this.idPrefix);
                return _this;
            }
            TiposHabitacionDialog.prototype.getFormKey = function () { return Portal.TiposHabitacionForm.formKey; };
            TiposHabitacionDialog.prototype.getIdProperty = function () { return Portal.TiposHabitacionRow.idProperty; };
            TiposHabitacionDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposHabitacionRow.localTextPrefix; };
            TiposHabitacionDialog.prototype.getNameProperty = function () { return Portal.TiposHabitacionRow.nameProperty; };
            TiposHabitacionDialog.prototype.getService = function () { return Portal.TiposHabitacionService.baseUrl; };
            return TiposHabitacionDialog;
        }(Serenity.EntityDialog));
        TiposHabitacionDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposHabitacionDialog);
        Portal.TiposHabitacionDialog = TiposHabitacionDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHabitacionGrid = (function (_super) {
            __extends(TiposHabitacionGrid, _super);
            function TiposHabitacionGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposHabitacionGrid.prototype.getColumnsKey = function () { return 'Portal.TiposHabitacion'; };
            TiposHabitacionGrid.prototype.getDialogType = function () { return Portal.TiposHabitacionDialog; };
            TiposHabitacionGrid.prototype.getIdProperty = function () { return Portal.TiposHabitacionRow.idProperty; };
            TiposHabitacionGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposHabitacionRow.localTextPrefix; };
            TiposHabitacionGrid.prototype.getService = function () { return Portal.TiposHabitacionService.baseUrl; };
            return TiposHabitacionGrid;
        }(Serenity.EntityGrid));
        TiposHabitacionGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposHabitacionGrid);
        Portal.TiposHabitacionGrid = TiposHabitacionGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHotelDialog = (function (_super) {
            __extends(TiposHotelDialog, _super);
            function TiposHotelDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposHotelForm(_this.idPrefix);
                return _this;
            }
            TiposHotelDialog.prototype.getFormKey = function () { return Portal.TiposHotelForm.formKey; };
            TiposHotelDialog.prototype.getIdProperty = function () { return Portal.TiposHotelRow.idProperty; };
            TiposHotelDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposHotelRow.localTextPrefix; };
            TiposHotelDialog.prototype.getNameProperty = function () { return Portal.TiposHotelRow.nameProperty; };
            TiposHotelDialog.prototype.getService = function () { return Portal.TiposHotelService.baseUrl; };
            return TiposHotelDialog;
        }(Serenity.EntityDialog));
        TiposHotelDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposHotelDialog);
        Portal.TiposHotelDialog = TiposHotelDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHotelGrid = (function (_super) {
            __extends(TiposHotelGrid, _super);
            function TiposHotelGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposHotelGrid.prototype.getColumnsKey = function () { return 'Portal.TiposHotel'; };
            TiposHotelGrid.prototype.getDialogType = function () { return Portal.TiposHotelDialog; };
            TiposHotelGrid.prototype.getIdProperty = function () { return Portal.TiposHotelRow.idProperty; };
            TiposHotelGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposHotelRow.localTextPrefix; };
            TiposHotelGrid.prototype.getService = function () { return Portal.TiposHotelService.baseUrl; };
            return TiposHotelGrid;
        }(Serenity.EntityGrid));
        TiposHotelGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposHotelGrid);
        Portal.TiposHotelGrid = TiposHotelGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHuespedDialog = (function (_super) {
            __extends(TiposHuespedDialog, _super);
            function TiposHuespedDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposHuespedForm(_this.idPrefix);
                return _this;
            }
            TiposHuespedDialog.prototype.getFormKey = function () { return Portal.TiposHuespedForm.formKey; };
            TiposHuespedDialog.prototype.getIdProperty = function () { return Portal.TiposHuespedRow.idProperty; };
            TiposHuespedDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposHuespedRow.localTextPrefix; };
            TiposHuespedDialog.prototype.getNameProperty = function () { return Portal.TiposHuespedRow.nameProperty; };
            TiposHuespedDialog.prototype.getService = function () { return Portal.TiposHuespedService.baseUrl; };
            return TiposHuespedDialog;
        }(Serenity.EntityDialog));
        TiposHuespedDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposHuespedDialog);
        Portal.TiposHuespedDialog = TiposHuespedDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposHuespedGrid = (function (_super) {
            __extends(TiposHuespedGrid, _super);
            function TiposHuespedGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposHuespedGrid.prototype.getColumnsKey = function () { return 'Portal.TiposHuesped'; };
            TiposHuespedGrid.prototype.getDialogType = function () { return Portal.TiposHuespedDialog; };
            TiposHuespedGrid.prototype.getIdProperty = function () { return Portal.TiposHuespedRow.idProperty; };
            TiposHuespedGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposHuespedRow.localTextPrefix; };
            TiposHuespedGrid.prototype.getService = function () { return Portal.TiposHuespedService.baseUrl; };
            return TiposHuespedGrid;
        }(Serenity.EntityGrid));
        TiposHuespedGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposHuespedGrid);
        Portal.TiposHuespedGrid = TiposHuespedGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposServicioDialog = (function (_super) {
            __extends(TiposServicioDialog, _super);
            function TiposServicioDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposServicioForm(_this.idPrefix);
                return _this;
            }
            TiposServicioDialog.prototype.getFormKey = function () { return Portal.TiposServicioForm.formKey; };
            TiposServicioDialog.prototype.getIdProperty = function () { return Portal.TiposServicioRow.idProperty; };
            TiposServicioDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposServicioRow.localTextPrefix; };
            TiposServicioDialog.prototype.getNameProperty = function () { return Portal.TiposServicioRow.nameProperty; };
            TiposServicioDialog.prototype.getService = function () { return Portal.TiposServicioService.baseUrl; };
            return TiposServicioDialog;
        }(Serenity.EntityDialog));
        TiposServicioDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposServicioDialog);
        Portal.TiposServicioDialog = TiposServicioDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposServicioGrid = (function (_super) {
            __extends(TiposServicioGrid, _super);
            function TiposServicioGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposServicioGrid.prototype.getColumnsKey = function () { return 'Portal.TiposServicio'; };
            TiposServicioGrid.prototype.getDialogType = function () { return Portal.TiposServicioDialog; };
            TiposServicioGrid.prototype.getIdProperty = function () { return Portal.TiposServicioRow.idProperty; };
            TiposServicioGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposServicioRow.localTextPrefix; };
            TiposServicioGrid.prototype.getService = function () { return Portal.TiposServicioService.baseUrl; };
            return TiposServicioGrid;
        }(Serenity.EntityGrid));
        TiposServicioGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposServicioGrid);
        Portal.TiposServicioGrid = TiposServicioGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposUnidadCalculoDialog = (function (_super) {
            __extends(TiposUnidadCalculoDialog, _super);
            function TiposUnidadCalculoDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.TiposUnidadCalculoForm(_this.idPrefix);
                return _this;
            }
            TiposUnidadCalculoDialog.prototype.getFormKey = function () { return Portal.TiposUnidadCalculoForm.formKey; };
            TiposUnidadCalculoDialog.prototype.getIdProperty = function () { return Portal.TiposUnidadCalculoRow.idProperty; };
            TiposUnidadCalculoDialog.prototype.getLocalTextPrefix = function () { return Portal.TiposUnidadCalculoRow.localTextPrefix; };
            TiposUnidadCalculoDialog.prototype.getNameProperty = function () { return Portal.TiposUnidadCalculoRow.nameProperty; };
            TiposUnidadCalculoDialog.prototype.getService = function () { return Portal.TiposUnidadCalculoService.baseUrl; };
            return TiposUnidadCalculoDialog;
        }(Serenity.EntityDialog));
        TiposUnidadCalculoDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], TiposUnidadCalculoDialog);
        Portal.TiposUnidadCalculoDialog = TiposUnidadCalculoDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var TiposUnidadCalculoGrid = (function (_super) {
            __extends(TiposUnidadCalculoGrid, _super);
            function TiposUnidadCalculoGrid(container) {
                return _super.call(this, container) || this;
            }
            TiposUnidadCalculoGrid.prototype.getColumnsKey = function () { return 'Portal.TiposUnidadCalculo'; };
            TiposUnidadCalculoGrid.prototype.getDialogType = function () { return Portal.TiposUnidadCalculoDialog; };
            TiposUnidadCalculoGrid.prototype.getIdProperty = function () { return Portal.TiposUnidadCalculoRow.idProperty; };
            TiposUnidadCalculoGrid.prototype.getLocalTextPrefix = function () { return Portal.TiposUnidadCalculoRow.localTextPrefix; };
            TiposUnidadCalculoGrid.prototype.getService = function () { return Portal.TiposUnidadCalculoService.baseUrl; };
            return TiposUnidadCalculoGrid;
        }(Serenity.EntityGrid));
        TiposUnidadCalculoGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], TiposUnidadCalculoGrid);
        Portal.TiposUnidadCalculoGrid = TiposUnidadCalculoGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var UnidadesCalculoDialog = (function (_super) {
            __extends(UnidadesCalculoDialog, _super);
            function UnidadesCalculoDialog() {
                var _this = _super.apply(this, arguments) || this;
                _this.form = new Portal.UnidadesCalculoForm(_this.idPrefix);
                return _this;
            }
            UnidadesCalculoDialog.prototype.getFormKey = function () { return Portal.UnidadesCalculoForm.formKey; };
            UnidadesCalculoDialog.prototype.getIdProperty = function () { return Portal.UnidadesCalculoRow.idProperty; };
            UnidadesCalculoDialog.prototype.getLocalTextPrefix = function () { return Portal.UnidadesCalculoRow.localTextPrefix; };
            UnidadesCalculoDialog.prototype.getNameProperty = function () { return Portal.UnidadesCalculoRow.nameProperty; };
            UnidadesCalculoDialog.prototype.getService = function () { return Portal.UnidadesCalculoService.baseUrl; };
            return UnidadesCalculoDialog;
        }(Serenity.EntityDialog));
        UnidadesCalculoDialog = __decorate([
            Serenity.Decorators.registerClass(),
            Serenity.Decorators.responsive()
        ], UnidadesCalculoDialog);
        Portal.UnidadesCalculoDialog = UnidadesCalculoDialog;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
var Geshotel;
(function (Geshotel) {
    var Portal;
    (function (Portal) {
        var UnidadesCalculoGrid = (function (_super) {
            __extends(UnidadesCalculoGrid, _super);
            function UnidadesCalculoGrid(container) {
                return _super.call(this, container) || this;
            }
            UnidadesCalculoGrid.prototype.getColumnsKey = function () { return 'Portal.UnidadesCalculo'; };
            UnidadesCalculoGrid.prototype.getDialogType = function () { return Portal.UnidadesCalculoDialog; };
            UnidadesCalculoGrid.prototype.getIdProperty = function () { return Portal.UnidadesCalculoRow.idProperty; };
            UnidadesCalculoGrid.prototype.getLocalTextPrefix = function () { return Portal.UnidadesCalculoRow.localTextPrefix; };
            UnidadesCalculoGrid.prototype.getService = function () { return Portal.UnidadesCalculoService.baseUrl; };
            return UnidadesCalculoGrid;
        }(Serenity.EntityGrid));
        UnidadesCalculoGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], UnidadesCalculoGrid);
        Portal.UnidadesCalculoGrid = UnidadesCalculoGrid;
    })(Portal = Geshotel.Portal || (Geshotel.Portal = {}));
})(Geshotel || (Geshotel = {}));
//# sourceMappingURL=Geshotel.Web.js.map