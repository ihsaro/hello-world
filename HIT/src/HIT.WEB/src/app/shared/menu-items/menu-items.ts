import { Injectable } from '@angular/core';

export interface Menu {
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  // { label:'Dashboard',  name: '', type: 'link', icon: 'av_timer' },
  
  { label: 'Job Adverts', name: 'job-adverts', type: 'link', icon: 'work' },
  { label: 'Candidates', name: 'Candidates', type: 'link', icon: 'groups' },
  { label: 'Skills', name: 'skill', type: 'link', icon: 'stars' }
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
