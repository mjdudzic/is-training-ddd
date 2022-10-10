import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BatchFilesListComponent } from './components/batch-files-list/batch-files-list.component';
import { BatchFilesComponent } from './components/batch-files/batch-files.component';


const routes: Routes = [
	{
		path: '',
		component: BatchFilesComponent,
		children: [
			{
				path: '',
				component: BatchFilesListComponent
			}
		]
	}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BatchFilesRoutingModule { }
