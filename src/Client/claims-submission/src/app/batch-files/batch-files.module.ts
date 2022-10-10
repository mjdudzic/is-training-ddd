import { NgModule } from '@angular/core';
import { BatchFilesRoutingModule } from './batch-files-routing.module';
import { BatchFilesComponent } from './components/batch-files/batch-files.component';
import { BatchFilesListComponent } from './components/batch-files-list/batch-files-list.component';
import { SharedModule } from '../shared/shared.module';
import { BatchFilesState } from './state/batch-files.state';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { IBatchFileService } from './services/batch-file.service.base';
import { BatchFileService } from './services/batch-file.service';
import { NgxsModule } from '@ngxs/store';
import { NgxFileDropModule } from 'ngx-file-drop';
import { IBatchFileRepository } from './domain/batch-file-repository.base';
import { IStoreService } from './domain/store.service.base';
import { StoreService } from './domain/store.service';
import { BatchFileRepository } from './domain/batch-file-repository';

@NgModule({
	declarations: [BatchFilesComponent, BatchFilesListComponent],
	imports: [SharedModule, BatchFilesRoutingModule, NgxFileDropModule, NgxsModule.forFeature([BatchFilesState]), NgxsFormPluginModule],
	providers: [
		{ provide: IBatchFileService, useClass: BatchFileService },
		{ provide: IStoreService, useClass: StoreService },
		{ provide: IBatchFileRepository, useClass: BatchFileRepository }
	]
})
export class BatchFilesModule {}
