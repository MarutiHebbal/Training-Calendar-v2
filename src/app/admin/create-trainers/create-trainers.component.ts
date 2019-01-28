import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from '../../Services/Service.services';
import { default as swal } from 'sweetalert2';


@Component({
  selector: 'app-create-trainers',
  templateUrl: './create-trainers.component.html',
  styleUrls: ['./create-trainers.component.css']
})
export class CreateTrainersComponent implements OnInit {

  public flag = 0;
  public Trainers: any;
  public id: any;
  public Trainer_Name: any
  public TrainerID: number;
  public TrainerName: any;
  public TrainerType: any;
  public TrainerData:any;
  public Description: any;
  public Trainer_Type: any = [{ name: 'Accionite', value: 1 }, { name: 'Guest', value: 0 }];

  constructor(private router: Router, private serv: ServicesService) { }

  ngOnInit() {
    this.serv.GetAllTrainers().subscribe((Response) => {
      console.log(Response);
      this.Trainers = Response;
    })
  }

  AddTrainers() {
    var data = { 'Trainer_Name': this.TrainerName, 'Trainer_Type': this.TrainerType, 'Description': this.Description }
    this.serv.CreateTrainers(data).subscribe((res: any) => {
      console.log(res);
      if (res != null) {
        swal("Trainer added ", "SuccessFully!", "success");
        this.router.navigate(['AdminDashboard/TrainerDetails']);
      }
      else {
        swal("Error in adding", 'warning')
      }
      this.flag = 0;
    });
  }
  back(){
    this.router.navigate(['AdminDashboard/TrainerDetails']);
  }
}
