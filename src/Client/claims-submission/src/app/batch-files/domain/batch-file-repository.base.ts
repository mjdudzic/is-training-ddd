import { BatchFileAggregate } from './batch-file.aggregate';

export abstract class IBatchFileRepository {
	public abstract get(batchFileId: string): BatchFileAggregate;
}
