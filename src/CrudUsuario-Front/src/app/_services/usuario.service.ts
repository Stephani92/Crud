import { Usuario } from './../_models/usuario';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  baseURL = 'http://localhost:5000/api/usuario';
  constructor(private http: HttpClient) { }

  getAllUsuarios(): Observable<Usuario[]>{
    return this.http.get<Usuario[]>(this.baseURL+ '/getall');
  }
  getUsuarioId(id: number): Observable<Usuario>{
    return this.http.get<Usuario>(`${this.baseURL}/${id}`);
  }
  postUsuario(usuario: Usuario){
    return this.http.post<Usuario>(`${this.baseURL}`, usuario);
  }
  putUsuario(usuario: Usuario): Observable<any> {
    return this.http.put<any>(`${this.baseURL}/${usuario.id}`, usuario);
  }

  deleteUsuario(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
