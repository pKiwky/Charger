import { IStation } from "../interfaces/station.interface";

export class Station implements IStation {
  id: number;
  city: string;
  street: string;
  longitude: number;
  latitude: number;
}
