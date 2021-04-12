export interface ISalesOrder{
    salesOrderID: number,
    revisionNumber: number,
    orderDate: Date,
    accountNumber: string,
    totalDue: number,
    comment: string
}