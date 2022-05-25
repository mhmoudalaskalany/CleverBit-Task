import { Component } from '@angular/core';
import { Shell } from 'base/components/shell';
import { AuthService } from 'core/services/auth/auth.service';
import { TranslationService } from 'core/services/localization/translation.service';
import { StorageService } from 'core/services/storage/storage.service';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {

  lang;
  get Localize(): TranslationService { return Shell.Injector.get(TranslationService); }
  get Storage(): StorageService { return Shell.Injector.get(StorageService); }
  get AuthService(): AuthService { return Shell.Injector.get(AuthService); }
  activeTab


  constructor() { }

  setLanguage(lang: string): void {
    this.lang = lang;
    this.Localize.setLanguage(lang);
    this.Storage.setItem('language', lang);
    console.log('language', this.Localize.lang);
  }

  setActive(tabTab) {
    this.activeTab = this.activeTab === tabTab ? '' : tabTab;
    this.showCollapsed();
  }

  showCollapsed() {
    setTimeout(() => {
      const accordions = document.querySelectorAll(".collapse-wrapper");

      const openAccordion = (accordion: any) => {
        accordion.style.height = accordion.scrollHeight + "px";
      };

      const closeAccordion = (accordion: any) => {
        accordion.style.height = '0';
      };

      accordions.forEach((accordion) => {
        const showContent = accordion.querySelector(".showContent");
        const content = accordion.querySelector(".contentCollapsed");

        if (showContent) {
          openAccordion(showContent);
        } else {
          closeAccordion(content);
        }
      });
    });
  }

  
}
