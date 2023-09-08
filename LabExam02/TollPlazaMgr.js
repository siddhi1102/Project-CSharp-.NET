
class TollPlaza {
    constructor(regNo, type, date, amount){
    this.regNo = regNo;
    this.type = type;
    this.date = date;
    this.amount = amount;
    }
    // dateString = this.date.getDate() + "/" + this.date.getMonth() + "/" + this.date.getFullYear();
}

class TollManager{
    vehicles = []

    getData(){
        if(localStorage.getItem("all" != undefined)){
            this.vehicles = JSON.parse(localStorage.getItem("all"));
        }
    }

    getVehicles = () => {
        this.getData();
        return this.vehicles;
    }

    AddVehicles = (vehicle) =>{
        this.getData();
        this.vehicles.push(vehicle);
        localStorage.setItem("all", JSON.stringify(this.vehicles));
    }


    findVehicleByCategory(type){
        this.getData();
        return this.vehicles.filter((e) => e.type == type);
    }

    findVehicleByRegistrationNo(regNo){
        this.getData();
        return this.vehicles.filter((e) => e.regNo == regNo);
    }

    getStringDate(date1){
        return `${date1.getDate()}/${date1.getMonth()+1}/${date1.getFullYear()}`;
    }
    
    findVehicleByDate(date){
        this.getData();
        return this.vehicles.filter((e) => this.getStringDate(dt)==this.getStringDate(new Date(e.date)));
    }
}