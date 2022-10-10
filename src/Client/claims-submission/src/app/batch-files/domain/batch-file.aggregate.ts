import { BatchFileViewModel } from '../models/batch-file.viewmodel';
import { BatchFiles } from '../state/batch-files.action';
import { IStoreService } from './store.service.base';

export class BatchFileAggregate {
	private constructor(
		private store: IStoreService,
		private id: string,
		private healthcareFacilityId: string,
		private isSubmittable: boolean,
		private submittedAt?: Date
	) {}

	static createFromModel(viewModel: BatchFileViewModel, store: IStoreService): BatchFileAggregate {
		return new BatchFileAggregate(store, viewModel.id, viewModel.healthcareFacilityId, viewModel.isSubmittable, viewModel.submittedAt);
	}

	public submit() {
		if (this.isSubmittable === false || this.submittedAt) {
			throw 'Batch file cannot be submitted';
		}

		this.store.dispatch(new BatchFiles.SubmitRequested(this.id));
	}
}
