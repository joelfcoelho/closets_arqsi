import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Produto } from '../../models';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  produtos    : Array<Produto>;
  bsModalRef  : BsModalRef;
  loading     : boolean = false;

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private modalService: BsModalService
  ) {}

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
      this.loading = true;
      this.http.get<Produto[]>(`/produtos`)
      .subscribe(
          response => {
              this.produtos = response;
              this.loading = false;
          },
          err => {
              this.toastr.error(err.error.message, 'Erro');
              this.loading = false;
          }
      );
  }
}
