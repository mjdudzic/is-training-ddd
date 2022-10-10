import { NgModule } from '@angular/core';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';
import { NgxsRouterPluginModule } from '@ngxs/router-plugin';
import { NgxsModule } from '@ngxs/store';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { environment } from 'src/environments/environment';

@NgModule({
	imports: [
		NgxsModule.forRoot([], {
			developmentMode: !environment.production,
			selectorOptions: {
				suppressErrors: false,
				injectContainerState: false
			}
		}),
		NgxsLoggerPluginModule.forRoot({
			collapsed: false,
			disabled: false
		}),
		NgxsReduxDevtoolsPluginModule.forRoot({
			name: 'Claims Submission',
			disabled: false
		}),
		NgxsRouterPluginModule.forRoot(),
		NgxsFormPluginModule.forRoot()
	],
	exports: [NgxsReduxDevtoolsPluginModule]
})
export class AppNgxsModule {}
