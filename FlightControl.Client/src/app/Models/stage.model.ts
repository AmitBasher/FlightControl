import flight from "./flight.model";
export default class stage implements Iterable<flight>{
    constructor(
        public id:number= 0,
        public Title:string="",
        public NextDepartureStageId:number= 0,
        public NextArrivalStageId:number= 0,
        public isTerminal:Boolean=false,
        public Flights:flight[]=[]
    ){};
    [Symbol.iterator](): Iterator<flight, any> {
        let index=0;
        return {
            next:(): IteratorResult<flight, any> =>{
                if (index<this.Flights.length){
                    const Flight = this.Flights[index];
                    index++;
                    return { value:Flight , done:false};
                }
                else{
                    return { value:undefined as any, done:true};
                }
            }
        }
    }
};