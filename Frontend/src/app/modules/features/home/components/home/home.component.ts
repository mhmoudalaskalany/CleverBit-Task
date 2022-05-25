import { Component, OnInit } from '@angular/core';
import { Shell } from 'base/components/shell';
import { TranslationService } from 'core/services/localization/translation.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  profileModel: any = {};
  cards: any = {};

  get Localize(): TranslationService { return Shell.Injector.get(TranslationService); }



  constructor() { }

  ngOnInit(): void {


  }





}
