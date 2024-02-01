export interface CatalogueDto {
    masterId: any,
    name: string,
    details: CatalogueDetailDto[]

}

export interface CatalogueDetailDto {
    detailId: any,
    name: string
}