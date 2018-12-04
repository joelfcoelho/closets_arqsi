import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Encomenda } from '../../models';


@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  encomendas  : Array<Encomenda>;
  bsModalRef  : BsModalRef;
  loading     : boolean = false;

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private modalService: BsModalService
  ) {}

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.loading = true;
    this.http.get<Encomenda[]>('encomenda')
    .subscribe(
      response => {
        this.loading = false;
        this.encomendas = response;

      },
      err => {
        this.toastr.error(err.error.message, 'Erro');
        this.loading = false;
      }
    );
  }
}
