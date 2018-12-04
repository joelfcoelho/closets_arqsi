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

  private loadOrders() {
      this.loading = true;

      this.http.get<Encomenda[]>(`encomenda`, {
      }).subscribe(
          data => {
              this.loading = false;
              this.encomendas = data;
          },
          err => this.handleError(err)
      );
  }

  private handleError(err) {
      this.loading = false,
      this.toastr.error(err.error.message, 'Erro');
  }
}
