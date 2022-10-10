import { HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from 'src/app/core/modules/app-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { NavigationComponent } from './ui/base-components/navigation/navigation.component';
import { ToolbarComponent } from './ui/base-components/toolbar/toolbar.component';
import { AppNgxsModule } from './modules/app-ngxs.module';
import { GlobalHttpErrorsInterceptor } from '../shared/interceptors/global-http-errors.interceptor';

export function windowFactory(): Window {
	return window;
}

@NgModule({
	declarations: [ToolbarComponent, NavigationComponent],
	imports: [SharedModule, FlexLayoutModule, AppRoutingModule, AppNgxsModule, ToastrModule.forRoot()],
	exports: [AppRoutingModule, ToolbarComponent, NavigationComponent, ToastrModule],
	providers: [
		{ provide: 'window', useFactory: windowFactory },
		{ provide: HTTP_INTERCEPTORS, useClass: GlobalHttpErrorsInterceptor, multi: true }
	]
})
export class CoreModule {}
