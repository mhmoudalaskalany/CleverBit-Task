export interface Employee {
    id: number;
    firstName: string;
    lastName: string;
    region: Region;
}

interface Region {
    id: number;
    Name: string;
}