import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MaterialModule } from './modules/material.module';
import { ProgressSpinnerDialogComponent } from './ui/components/progress-spinner-dialog/progress-spinner-dialog.component';
import { InlineProgressSpinnerComponent } from './ui/components/inline-progress-spinner/inline-progress-spinner.component';
import { ProgressSpinnerService } from './services/progress-spinner.service';
import { IProgressSpinnerService } from './services/progress-spinner.service.base';

export const MY_FORMATS = {
	parse: {
		dateInput: 'DD-MM-YYYY'
	},
	display: {
		dateInput: 'DD-MM-YYYY',
		monthYearLabel: 'MMM YYYY'
	}
};

@NgModule({
	declarations: [ProgressSpinnerDialogComponent, InlineProgressSpinnerComponent],
	imports: [CommonModule, MaterialModule, ReactiveFormsModule],
	exports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		MaterialModule,
		FlexLayoutModule,
		ProgressSpinnerDialogComponent,
		InlineProgressSpinnerComponent
	],
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
		{ provide: MAT_DATE_LOCALE, useValue: 'en-GH' },
		{ provide: IProgressSpinnerService, useClass: ProgressSpinnerService }
	]
})
export class SharedModule {}
