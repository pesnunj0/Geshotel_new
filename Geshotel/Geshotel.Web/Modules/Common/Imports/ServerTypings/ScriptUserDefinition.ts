
namespace Geshotel {
    export interface ScriptUserDefinition {
        Username?: string;
        DisplayName?: string;
        IsAdmin?: boolean;
        Permissions?: { [key: string]: boolean };
        EmpresaId?: number;
        HotelId?: number;
    }
}

