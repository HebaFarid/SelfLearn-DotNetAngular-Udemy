import { IResume } from "./resume";

export interface IResumePagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IResume[];
}