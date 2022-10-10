import { Injectable } from '@angular/core';
import { Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { BatchFileViewModel } from '../models/batch-file.viewmodel';
import { BatchFiles } from '../state/batch-files.action';
import { BatchFilesState } from '../state/batch-files.state';
import { IStoreService } from './store.service.base';

@Injectable()
export class StoreService extends IStoreService {
	constructor(private store: Store) {
		super();
	}

	public dispatch(action: BatchFiles.SubmitRequested | BatchFiles.ReportsLinkAttached): Observable<any> {
		return this.store.dispatch(action);
	}

	public selectLoadedViewModels(): BatchFileViewModel[] {
		return this.store.selectSnapshot(BatchFilesState.getBatchFiles);
	}
}
