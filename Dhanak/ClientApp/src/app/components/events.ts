export interface events{
    eventName:string,
    categoryId:category,
    organiser:organiser,
    coOrdinator:coOrdinator,
    description:string,
}
export interface category{
    id:number;
    name:string
}
export interface organiser{
    name:string,
    email:string,
    phone:string
}
export interface coOrdinator{
    name:string,
  
    phone:string
}

