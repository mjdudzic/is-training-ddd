import { Component, Input } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Store } from '@ngxs/store';

@Component({
	selector: 'app-toolbar',
	templateUrl: './toolbar.component.html',
	styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {
	@Input() sidenav: MatSidenav | undefined;

	constructor(private store: Store) {}

	resolveLogoutSelected(): void {}

	changePassword() {}
}
