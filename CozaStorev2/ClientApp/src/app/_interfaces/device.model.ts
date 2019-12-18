import { User } from './user.model';

export interface Device {
    Id: number;
    FullName: string;
    ProductType: string;
    BranchName: string;
    Origin: string;
    SerialNumber: string;
    QualityStatus: number;
    OwnerId: number;
    CurrentLocationId: number;
    Quantity: number;
    ReceivedDate: Date;
    LastUpdateBy?: number;
    user?: User[];
    LocationHistory: string;
    GroupDeviceId?: number;
}
