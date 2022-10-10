import { BatchFileAggregate } from '../domain/batch-file.aggregate';
import { FileUploadDto } from '../models/file-upload.dto';

export namespace BatchFiles {
	const prefix = '[BatchFiles]';

	export class GetAll {
		static readonly type = `${prefix} ${GetAll.name}`;
	}

	export class UploadRequested {
		static readonly type = `${prefix} ${UploadRequested.name}`;

		constructor(public batchFile: FileUploadDto) {}
	}

	export class SubmitRequested {
		static readonly type = `${prefix} ${SubmitRequested.name}`;

		constructor(public batchFileId: string) {}
	}

	export class SubmitCompleted {
		static readonly type = `${prefix} ${SubmitCompleted.name}`;

		constructor(public batchFileId: string) {}
	}
}
