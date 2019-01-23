import { Component, OnInit } from "@angular/core";
import {
  startOfDay,
  endOfDay,
  subDays,
  addDays,
  endOfMonth,
  isSameDay,
  isSameMonth,
  addHours
} from "date-fns";
import { Subject, from } from "rxjs";
import {
  CalendarEvent,
  CalendarEventAction,
  CalendarEventTimesChangedEvent,
  CalendarView
} from "angular-calendar";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AuthService } from "angular-6-social-login";
import { Router } from "@angular/router";
import { DatePipe } from "@angular/common";
import {
  animate,
  state,
  style,
  transition,
  trigger
} from "@angular/animations";
import Swal from "sweetalert2";
import { ServicesService } from "src/app/Services/Service.services";
import { toDate } from "@angular/common/src/i18n/format_date";

export interface CourseDetails {
  CourseID: number;
  CourseName: string;
  TrainerName: string;
  Duration: string;
  description: string;
  FromDate: string;
  ToDate: string;
  LastDateToEnroll: string;
  Venue: string;
}
@Component({
  selector: "app-table-display",
  templateUrl: "./table-display.component.html",
  styleUrls: ["./table-display.component.css"],
  animations: [
    trigger("detailExpand", [
      state(
        "collapsed",
        style({ height: "0px", minHeight: "0", display: "none" })
      ),
      state("expanded", style({ height: "*" })),
      transition(
        "expanded <=> collapsed",
        animate("225ms cubic-bezier(0.4, 0.0, 0.2, 1)")
      )
    ])
  ]
})
export class TableDisplayComponent implements OnInit {
  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();
  public user = localStorage.getItem("isLoggedIn");
  public userurl;
  public username;
  public res = 0;
  public flag = 0;
  reg =0;
  public reason;
  course: CourseDetails;
  constructor(
    private modal: NgbModal,
    private authService: AuthService,
    private router: Router,
    public service: ServicesService,
    public datepipe: DatePipe
  ) {}
  ngOnInit() {
    this.userurl = sessionStorage.getItem("Userurl");
    this.username = sessionStorage.getItem("Username");

    this.service.GetTableDetails().subscribe((res: any) => {
      console.log(res);
      this.getData(res);
    });

  
  }

  getData = (data: any[]) => {
    let temp = [];
    data.forEach(result => {
      console.log("result=", result);

      result.CourseName = result.Course_Name;
      result.TrainerName = result.Trainer_Name;
      result.Duration = result.Duration;
      result.description = result.Description;
      var from = result.FromDate;
      result.FromDate = this.datepipe.transform(from, "MMM-dd-yyyy");
      var to = result.ToDate;
      result.ToDate = this.datepipe.transform(to, "MMM-dd-yyyy");
      result.LastDateToEnroll = result.Last_date_to_enroll;
      result.Venue = result.Venue;
      temp.push(result);
    });
    this.dataSource = temp;

    this.expandedElement = temp;
  };
  dataSource: any[];
  expandedElement: any[];

  columnsToDisplay = [
    "CourseName",
    "TrainerName",
    "Duration",
    "FromDate",
    "ToDate",
    "LastDateToEnroll",
    "Venue"
  ];
  registerationClosed(res){
    var data = {"User_Name":this.user,"Course_Name":res.CourseName}
    var result = {"Course_Name":res.CourseName}
    this.service.checkforregister(result).subscribe((Response)=>
    {
      if(Response === "Success"){
        this.reg=1;
      }
      else{
        this.reg=0;
      }
    })
    this.service.check(data).subscribe((Response) => {
      console.log(Response);
      if (Response == "Success") {
        this.flag = 1;
      }
    });

  }



  Register(res) {
    console.log(res);

    var data = { User_Name: this.user, Course_Name: res.CourseName };
    console.log("user==", data);
    this.service.Register(data).subscribe(Response => {
      if (Response) {
        this.flag = 1;
        Swal("Registeration!", "Done!", "success");
      } else {
        Swal("Registeration Failed", "warning");
      }
    });
  }
  
  LeaveCourse(result) {
    var data = { User_Name: this.user, Course_Name: result.CourseName };
    debugger;
    this.service.check(data).subscribe(Response => {
      console.log("Response:", Response);
      // if(Response=trur)
    });
    this.res = 1;
  }
  UnRegister() {
    var data = { User_Name: this.user, Reason_For_Unreg: this.reason };
    debugger;
    this.service.UnRegister(data).subscribe(Response => {
      if (Response) {
        this.flag = 0;
        this.reason = null;
        this.res = 0;
        Swal("Left Course!", "Done!", "success");
      } else {
        Swal("Left Course!", "warning");
      }
    });
  }
}
