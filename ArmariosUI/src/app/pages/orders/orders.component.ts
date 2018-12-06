import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { ItemDetailsComponent } from '../../dialogs/item-details/item-details.component';
import { Item, Encomenda } from '../../models';


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
    this.http.get<Encomenda[]>(`https://gestao-armarios.herokuapp.com/api/encomenda`)
    .subscribe(
      response => {
        this.encomendas = response;
        this.loading = false;
      },
      err => {
        this.toastr.error(err.error.message, 'Erro');
        this.loading = false;
      }
    );
  }



  showItems(item: Item) {
    this.bsModalRef = this.modalService.show(ItemDetailsComponent, {class: 'modal-lg'});
    this.bsModalRef.content.itens = item;
  }

}
