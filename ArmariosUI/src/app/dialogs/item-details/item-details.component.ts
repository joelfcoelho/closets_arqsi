import { Component, OnInit } from '@angular/core';
import { Item } from '../../models/Item';
import { BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-modal-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit {
  itens   :   Array<Item> = [];

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

}
