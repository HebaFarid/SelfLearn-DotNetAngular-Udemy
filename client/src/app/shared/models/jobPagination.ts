import { IJob } from "./job";

export interface IJobPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IJob[];
}