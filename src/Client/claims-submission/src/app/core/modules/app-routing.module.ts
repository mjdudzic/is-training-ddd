import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavigationComponent } from '../ui/base-components/navigation/navigation.component';
import { BatchFilesComponent } from 'src/app/batch-files/components/batch-files/batch-files.component';

export const RoutePaths = {
	BatchFiles: 'batch-files'
};

const routes: Routes = [
	{
		path: '',
		component: NavigationComponent,
		children: [
			{
				path: RoutePaths.BatchFiles,
				loadChildren: () => import('../../batch-files/batch-files.module').then((m) => m.BatchFilesModule)
			},
			{ path: '', redirectTo: RoutePaths.BatchFiles, pathMatch: 'full' }
		]
	},
	{
		path: '**',
		redirectTo: ''
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {}
