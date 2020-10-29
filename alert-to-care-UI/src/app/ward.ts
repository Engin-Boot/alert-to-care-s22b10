export class Wards {

    WardNumber:string;
    NumberOfBed:number;
    Department:string;
    NumberOfRow:number;
    NumberOfColumn:number;



    constructor(WardNumber,NumberOfBed,Department,NumberOfRow,NumberOfColumn)
    {
        this.WardNumber = WardNumber;
        this.NumberOfBed = NumberOfBed;
        this.Department = Department;
        this.NumberOfColumn = NumberOfColumn;
        this.NumberOfRow = NumberOfRow;
    }
}