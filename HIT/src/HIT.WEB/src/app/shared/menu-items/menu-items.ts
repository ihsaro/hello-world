import { Injectable } from '@angular/core';

export interface Menu {
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  // { name: 'Dashboard', type: 'link', icon: 'av_timer' },
 
  { label: 'Candidates', name: 'Candidates', type: 'link', icon: 'groups' },
  { label: 'Skills', name: 'skill', type: 'link', icon: 'stars' },
  { label: 'Job Adverts', name: 'job-adverts', type: 'link', icon: 'work' },
  { label: 'Administration', name: 'Administration', type: 'link', icon: 'admin_panel_settings' },
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
