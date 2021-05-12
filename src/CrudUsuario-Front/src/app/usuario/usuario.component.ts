
import { UsuarioService } from './../_services/usuario.service';
import { Usuario } from './../_models/usuario';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { EscolaridadeEnum } from '../_models/_Enum/EscolaridadeEnum.enum';


@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent implements OnInit {

  maxDate: Date;

  constructor(private usuarioService: UsuarioService,
              private modalService: BsModalService,
              private fb: FormBuilder) {

                this.maxDate = new Date();
                this.maxDate.setDate(this.maxDate.getDate());
              }
  // Geral
  options = EscolaridadeEnum;
  usuarios: Usuario[];
  key = [];
  p = 1;
  usuario: Usuario;
  registerForm: FormGroup;
  modalRef: BsModalRef;
  modoSalvar = 'post';
  DataNascimento: Date;
  bodyDeletarusuario: string;


  ngOnInit() {
    this.key = Object.keys(this.options);
    this.validation();
    this.getUsuarios();

  }
  // openModal(template: TemplateRef<any>) {

  //   this.modalRef = this.modalService.show(template);


  // }
  openModal(template: any) {
    this.registerForm.reset();
    this.modalRef = this.modalService.show(template);
  }
  closeModal(template: any) {

    this.modalRef.hide();
  }

  validation(){
    this.registerForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      sobrenome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      dataNascimento: ['', Validators.required],
      escolaridade: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }
  editarUsuario(usuario: Usuario, template: any) {
    this.modoSalvar = 'put';
    this.openModal(template);
    this.usuario = Object.assign({}, usuario);
    this.registerForm.patchValue(this.usuario);
  }
  excluirEvento(usuario: Usuario, template: any) {
    template.show();
    this.usuario = usuario;
    this.bodyDeletarusuario = `Tem certeza que deseja excluir o usuario: ${usuario.nome}, Código: ${usuario.id}`;
  }
  novoUsuario(template: any) {
    this.modoSalvar = 'post';
    console.log(this.modoSalvar);
    this.usuario = null;
    this.openModal(template);
  }
  confirmeDelete(template: any) {
    this.usuarioService.deleteUsuario(this.usuario.id).subscribe(
      () => {

        this.getUsuarios();
      }, error => {
        console.log(error);
      }

    );
    this.getUsuarios();
    template.hide();
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'put') {
        this.usuario = Object.assign({ id: this.usuario.id }, this.registerForm.value);
        this.usuarioService.putUsuario(this.usuario).subscribe(
          (x) => {
            this.closeModal(template);
            this.getUsuarios();
          }
        );
      } else {
        this.usuario = Object.assign({}, this.registerForm.value);
        this.usuarioService.postUsuario(this.usuario).subscribe(
          () => {
            this.closeModal(template);
            this.getUsuarios();
          }
        );

      }
      template.close();
    }
  }
  getUsuarios(){
    this.usuarioService.getAllUsuarios().subscribe(
      (_usuario: Usuario[]) =>
      {
        this.usuarios = _usuario;
      }
    );
  }

}
