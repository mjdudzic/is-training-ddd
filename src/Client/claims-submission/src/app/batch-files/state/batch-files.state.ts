import { HttpErrorResponse } from '@angular/common/http';
import { Injectable, NgZone } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Action, Selector, State, StateContext, StateToken, Store } from '@ngxs/store';
import { catchError, Observable, take, throwError, switchMap, of } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { tap } from 'rxjs/operators';
import { patch, updateItem } from '@ngxs/store/operators';
import { BatchFileViewModel } from '../models/batch-file.viewmodel';
import { ProgressSpinnerDialogComponent } from 'src/app/shared/ui/components/progress-spinner-dialog/progress-spinner-dialog.component';
import { BatchFiles } from './batch-files.action';
import { IBatchFileService } from '../services/batch-file.service.base';
import { IBatchFileRepository } from '../domain/batch-file-repository.base';

export interface BatchFilesStateModel {
	batchFiles: BatchFileViewModel[];
}

const BATCH_FILES_STATE_TOKEN = new StateToken<BatchFilesStateModel>('batchFilesData');

@State<BatchFilesStateModel>({
	name: BATCH_FILES_STATE_TOKEN,
	defaults: {
		batchFiles: []
	}
})
@Injectable()
export class BatchFilesState {
	private progressSpinnerDialogRef?: MatDialogRef<ProgressSpinnerDialogComponent>;

	constructor(
		private batchFileService: IBatchFileService,
		private store: Store,
		private toastService: ToastrService,
		private dialog: MatDialog,
		private repository: IBatchFileRepository
	) {}

	@Selector([BATCH_FILES_STATE_TOKEN])
	static getBatchFiles(state: BatchFilesStateModel): BatchFileViewModel[] {
		return state.batchFiles;
	}

	@Action(BatchFiles.GetAll)
	getAll(ctx: StateContext<BatchFilesStateModel>, _: BatchFiles.GetAll) {
		this.showProgressSpinner();

		return this.batchFileService.loadBatches().pipe(
			take(1),
			tap((response) => {
				this.closeProgressSpinner();

				ctx.patchState({
					batchFiles: response
				});
			}),
			catchError((error) => {
				return this.handleErrorResponse(error);
			})
		);
	}

	@Action(BatchFiles.UploadRequested)
	upload(ctx: StateContext<BatchFilesStateModel>, action: BatchFiles.UploadRequested) {
		this.showProgressSpinner();

		return this.batchFileService.uploadBatchFile('test_001', action.batchFile).pipe(
			tap((_) => {
				this.closeProgressSpinner();
			}),
			catchError((error) => {
				return this.handleErrorResponse(error);
			})
		);
	}

	@Action(BatchFiles.SubmitRequested)
	submitRequested(ctx: StateContext<BatchFilesStateModel>, action: BatchFiles.SubmitRequested) {
		this.showProgressSpinner();

		return this.batchFileService.submitBatchFile(action.batchFileId).pipe(
			tap((model) => {
				this.closeProgressSpinner();

				this.toastService.success('File has been submitted');
				ctx.setState(
					patch({
						batchFiles: updateItem<BatchFileViewModel>(
							(batch) => batch.id === action.batchFileId,
							patch({
								submittedAt: model.submittedAt,
								reportUri: model.reportsUri
							})
						)
					})
				);

				ctx.dispatch(new BatchFiles.SubmitCompleted(action.batchFileId));
				// let entity = this.repository.get(action.batchFileId);
				// console.log(entity);
			}),
			catchError((error) => {
				return this.handleErrorResponse(error);
			})
		);
	}

	@Action(BatchFiles.SubmitCompleted)
	submitCompleted(ctx: StateContext<BatchFilesStateModel>, action: BatchFiles.SubmitRequested) {
		let entity = this.repository.get(action.batchFileId);
		console.log(entity);
	}

	private handleErrorResponse(error: HttpErrorResponse): Observable<any> {
		this.closeProgressSpinner();
		return throwError(() => error);
	}

	private showProgressSpinner(): void {
		this.closeProgressSpinner();
		this.progressSpinnerDialogRef = this.dialog.open(ProgressSpinnerDialogComponent, {
			panelClass: 'transparent',
			disableClose: true
		});
	}

	private closeProgressSpinner(): void {
		if (this.progressSpinnerDialogRef) {
			this.progressSpinnerDialogRef.close();
			this.progressSpinnerDialogRef = undefined;
		}
	}
}
