import { organiser, coOrdinator } from './../events';
export interface event{
    eventName:string,
    categoryId:number,
    organiser:organiser,
    coOrdinator:coOrdinator,
    description:string

}