import { Injectable } from '@angular/core';
import { IBatchFileRepository } from './batch-file-repository.base';
import { BatchFileAggregate } from './batch-file.aggregate';
import { IStoreService } from './store.service.base';

@Injectable()
export class BatchFileRepository extends IBatchFileRepository {
	constructor(private store: IStoreService) {
		super();
	}

	public get(batchFileId: string): BatchFileAggregate {
		let viewModel = this.store.selectLoadedViewModels().filter((vm) => vm.id == batchFileId)[0];
		return BatchFileAggregate.createFromModel(viewModel, this.store);
	}
}
