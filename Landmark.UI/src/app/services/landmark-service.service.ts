import { environment } from '../../environments/environment.prod';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response } from '@angular/http';
import { UserLocation } from "../shared/user-location";

@Injectable()
export class LandmarkService {

  baseUrl:string;
  constructor(private http: Http) { 
    this.baseUrl = environment.apiUrl
  }

  getLocations(): Observable<UserLocation[]> {
    return this.http
      .get(this.baseUrl)
      .map((res:Response) =>{ 
        console.log('Locations found', res.json().location);
        return <UserLocation[]>res.json().location 
      })
      .catch(this.handleError);
  }

  addLocation(userLocation): Observable<UserLocation> {
    return this.http
      .post(this.baseUrl, userLocation)
      .map((response: Response) =>  { 
        return <UserLocation>response.json().userLocation 
      });
  }

  private handleError(error:Response){
    console.log(error);
    let msg = `Error with ${error.status} and url ${error.url}`
    return Observable.throw(msg);
  }

}
