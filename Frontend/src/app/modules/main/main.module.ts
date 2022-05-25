import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "shared/shared.module";
import { LayoutComponent } from "./components/layout/layout.component";
import { MainRoutingModule } from "./main-routing.module";
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';

@NgModule({
    declarations: [
        LayoutComponent,
        SidebarComponent,
        NavbarComponent,
        FooterComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        MainRoutingModule,
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule
    ],
    providers: [
    ]
})
export class MainModule { }