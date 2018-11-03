import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Getdata } from '../../app/Model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  payment: any;
  amount: any;
  data: Getdata = { "Note": "", "Change": "499", "Bill1000": "0", "Bill500": "0", "Bill100": "4", "Bill50": "1", "Bill20": "2", "Bill5": "1", "Bill1": "4" };
  Ischeck: boolean = false;
  constructor(public navCtrl: NavController, private http: HttpClient) {

  }
  OK() {
    this.http.get("http://localhost:5000/api/Change/" + this.amount + "/" + this.payment)
      .subscribe((data: any) => {
        this.data = data
        if (this.data.Note != '') {
          this.data.Note = "เงินไม่พอโว้ยยยยยยยยยยยยยยยยยยยยยยยยยยยย"
        }
        this.Ischeck = true;
      },
        error => {

          console.log(error);
        });
  }


  IsCheck() {
    return this.Ischeck && this.data.Note == '';
  }
  // https://localhost:5001/api/Change/

}
