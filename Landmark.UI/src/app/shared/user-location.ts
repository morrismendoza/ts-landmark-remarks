import { IUserLocation } from "./user-location.interface";

export class UserLocation implements IUserLocation {
    public latitude: number;
    public longitude:number;
    public address: string;
    public notes: string;
    public username: string;
    public dateCreated: Date;
}
