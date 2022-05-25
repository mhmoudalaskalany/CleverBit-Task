import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Shell } from 'base/components/shell';
import { AuthService } from 'core/services/auth/auth.service';
import { ConfigService } from 'core/services/config/config.service';
import { TranslationService } from 'core/services/localization/translation.service';
import { StorageService } from 'core/services/storage/storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  profileModel: any = {};
  lang;
  get Localize(): TranslationService { return Shell.Injector.get(TranslationService); }
  get Storage(): StorageService { return Shell.Injector.get(StorageService); }
  get Router(): Router { return Shell.Injector.get(Router); }
  get Config(): ConfigService { return Shell.Injector.get(ConfigService); }
  get AuthService(): AuthService { return Shell.Injector.get(AuthService); }
  get Dialog(): MatDialog { return Shell.Injector.get(MatDialog); }
  constructor() { }

  ngOnInit(): void {
  }



  toggleSidebar(): void {
    const item = document.querySelector('.sidebar');
    item.classList.toggle('collapsed');
  }

  setLanguage(lang: string): void {
    this.lang = lang;
    this.Localize.setLanguage(lang);
    this.Storage.setItem('language', lang);
  }


  logout() {
    this.AuthService.logout();
    this.Router.navigate(['/login']);
  }
}


