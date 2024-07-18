export interface Country {
  id: string;
  name: string;
  provinces: Province[] | null;
}

export interface Province {
  id: string;
  name: string;
}
