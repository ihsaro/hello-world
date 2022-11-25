import { Injectable } from '@angular/core';

export interface Menu {
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  // { name: 'Dashboard', type: 'link', icon: 'av_timer' },
 
  { name: 'Candidates', type: 'link', icon: 'groups' },
  { name: 'skill', type: 'link', icon: 'stars' },
  { name: 'job-adverts', type: 'link', icon: 'work' },
  { name: 'Administration', type: 'link', icon: 'admin_panel_settings' },
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
