export interface User{
    Id: number;
    Email: string;
    Password: string;
    FullName: string;
    Status: boolean;
    Avatar: string;
    PhoneNumber: string;
    CreatedBy: number;
    CreatedDate: Date;
    UpdateBy: number;
    UpdatedDate: Date;
    deviceId?: string;
}