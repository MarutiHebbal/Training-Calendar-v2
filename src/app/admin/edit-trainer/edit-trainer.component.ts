import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Params, Router } from '@angular/router';
import { ServicesService } from 'src/app/Services/Service.services';
import { DatePipe } from '@angular/common';
import { default as Swal } from 'sweetalert2';


@Component({
  selector: 'app-edit-trainer',
  templateUrl: './edit-trainer.component.html',
  styleUrls: ['./edit-trainer.component.css']
})
export class EditTrainerComponent implements OnInit {
  public data;
  public TrainerName : any;
  public TrainerType : any;
  public description : any;
  public id: number;
  public display;
  public trainerid: any;
  public TrainerData:any;
  public Trainer_Type: any = [{ name: 'Accionite', value: true }, { name: 'Guest', value: false }];

  constructor(private router:ActivatedRoute,private rout:Router,private serv:ServicesService, public datepipe: DatePipe) { }

  ngOnInit() {
    this.router.params.subscribe((params:Params)=>{
      this.loadProject(params.id);
    })
  }
  loadProject(id) {
    console.log("IDDDDDDDD");
    console.log(id);
    this.trainerid = id;
  
    var data = { "Trainer_ID": this.trainerid }
  
    this.serv.GetTrainersByID(data).subscribe((Response) => {
      if (Response != null) 
          console.log(Response);
          this.TrainerName = Response[0].Trainer_Name;
          this.description = Response[0].Description;
          this.TrainerData=Response[0].Trainer_Type;
    })
    
    this.display = 'block';
     
  }
  UpdateTrainers() {
    var data = { 'Trainer_ID':this.trainerid,'Trainer_Name': this.TrainerName, 'Description': this.description, 'Trainer_Type':this.TrainerData }
    this.serv.UpdateTrainers(data).subscribe((Response) => {
      if (Response) {
       
            Swal("Trainers Updated ", "SuccessFully!", "success");
            this.display = 'none';
            this.rout.navigate(["AdminDashboard/TrainerDetails"]);
            window.location.reload();  
          } 
        }) 
  }
  cancel(){
    this.rout.navigate(["AdminDashboard/TrainerDetails"]);
  }
}
