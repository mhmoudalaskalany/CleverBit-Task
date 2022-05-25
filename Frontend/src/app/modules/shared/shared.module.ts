import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ArabicNamePatternDirective } from 'core/services/directives/arabicNameValidator.directive';
import { DeviceArabicNamePatternDirective } from 'core/services/directives/deviceArabicNameValidator.directive';
import { DeviceEnglishNamePatternDirective } from 'core/services/directives/deviceEnglishNameValidator.directive';
import { EnglishNamePatternDirective } from 'core/services/directives/englishNameValidator.directive';
import { DeleteModalComponent } from './components/data-table/components/delete-modal.component';
import { DataTableComponent } from './components/data-table/data-table.component';
import { MaterialModule } from 'third-party/material.module';
import { PrimeNgModule } from 'third-party/primeng.module';
import { LoadingComponent } from './components/loading/loading.component';
import { CollapseContentComponent } from './components/collapse-content/collapse-content.component';
import { RtlDirective } from 'core/services/directives/rtl.directive';
import { ValidationHandlerPipe } from './pipes/validation-handler.pipe';




@NgModule({
    entryComponents: [
    ],
    declarations: [
        DataTableComponent,
        DeleteModalComponent,
        EnglishNamePatternDirective,
        ArabicNamePatternDirective,
        DeviceArabicNamePatternDirective,
        DeviceEnglishNamePatternDirective,
        RtlDirective,
        LoadingComponent,
        CollapseContentComponent,
        ValidationHandlerPipe
    ],
    imports: [
        CommonModule,
        MaterialModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        PrimeNgModule,
        TranslateModule
    ],
    exports: [
        LoadingComponent,
        DataTableComponent,
        EnglishNamePatternDirective,
        ArabicNamePatternDirective,
        DeviceArabicNamePatternDirective,
        DeviceEnglishNamePatternDirective,
        RtlDirective,
        MaterialModule,
        PrimeNgModule,
        FormsModule,
        ReactiveFormsModule,
        TranslateModule,
        CollapseContentComponent,
        ValidationHandlerPipe
    ]
})
export class SharedModule { }
