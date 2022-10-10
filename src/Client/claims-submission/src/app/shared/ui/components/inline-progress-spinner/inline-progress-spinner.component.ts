import { Component, Input } from '@angular/core';

@Component({
	selector: 'app-inline-progress-spinner',
	templateUrl: './inline-progress-spinner.component.html',
	styleUrls: ['./inline-progress-spinner.component.scss']
})
export class InlineProgressSpinnerComponent {
	@Input() visible: boolean = false;
	@Input() diameter: number = 25;
	constructor() {}

	show() {
		this.visible = true;
	}

	hide() {
		this.visible = false;
	}
}
