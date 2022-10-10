import {
	ProgressSpinnerDialogComponent
} from "../ui/components/progress-spinner-dialog/progress-spinner-dialog.component";
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {IProgressSpinnerService} from "./progress-spinner.service.base";
import {Injectable} from "@angular/core";

@Injectable()
export class ProgressSpinnerService implements IProgressSpinnerService {
	private progressSpinnerDialogRef?: MatDialogRef<ProgressSpinnerDialogComponent>;
	private invocationCounter: number = 0;

	hideProgressSpinner(): void {
		this.invocationCounter--;
		if(this.invocationCounter > 0) {
			return;
		}
		this.hide();
	}

	showProgressSpinner(): void {
		this.hide();
		this.invocationCounter++;
		this.progressSpinnerDialogRef = this.dialog.open(ProgressSpinnerDialogComponent, {
			panelClass: 'transparent',

			disableClose: true
		});
	}

	private hide(): void {
		if (this.progressSpinnerDialogRef) {
			this.progressSpinnerDialogRef.close();

			this.progressSpinnerDialogRef = undefined;
		}
	}


	constructor(private dialog: MatDialog) {
	}
}
