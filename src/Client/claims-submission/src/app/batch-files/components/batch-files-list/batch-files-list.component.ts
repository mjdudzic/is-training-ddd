import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { ToastrService } from 'ngx-toastr';
import { FileSystemFileEntry, NgxFileDropEntry } from 'ngx-file-drop';
import { BatchFileViewModel } from '../../models/batch-file.viewmodel';
import { BatchFiles } from '../../state/batch-files.action';
import { BatchFilesState } from '../../state/batch-files.state';
import { FileUploadDto } from '../../models/file-upload.dto';
import { IBatchFileRepository } from '../../domain/batch-file-repository.base';

@Component({
	selector: 'app-batch-files-list',
	templateUrl: './batch-files-list.component.html',
	styleUrls: ['./batch-files-list.component.scss']
})
export class BatchFilesListComponent implements OnInit {
	columnsToDisplay: string[] = [
		'createdAt',
		'healthcareFacilityId',
		'fileOriginalName',
		'claimsTotalCount',
		'validClaimsRatio',
		'actions'
	];

	batchFiles$ = this.store.select(BatchFilesState.getBatchFiles);

	constructor(private store: Store, private repository: IBatchFileRepository, private toastService: ToastrService) {}

	trackById(index: number, element: BatchFileViewModel): string {
		return element.id;
	}

	ngOnInit(): void {
		this.store.dispatch(new BatchFiles.GetAll());
	}

	refresh() {
		this.store.dispatch(new BatchFiles.GetAll());
	}

	isSubmittable(batchFile: BatchFileViewModel): boolean {
		return batchFile.isSubmittable;
	}

	submit(batchFileId: string): void {
		var entity = this.repository.get(batchFileId);
		entity.submit();
	}

	public onFileDropped(files: NgxFileDropEntry[]) {
		for (const droppedFile of files) {
			if (!droppedFile.fileEntry.isFile) {
				this.toastService.error('Only JSON files are allowed.', 'Invalid file format');
				return;
			}

			const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
			fileEntry.file((file: File) => {
				if (this.getFileExtension(file.name) !== 'json') {
					this.toastService.error('Only JSON files are allowed.', 'Invalid file format');
					return;
				}

				this.store.dispatch(new BatchFiles.UploadRequested(new FileUploadDto(file)));
			});
		}
	}

	private getFileExtension(filename: string) {
		return filename.split('.').pop().toLowerCase();
	}
}
