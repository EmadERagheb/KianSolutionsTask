export interface Paging<T> {
    pageIndex: number;
    pageSize: number;
    totalCount: number;
    data: T;
}
