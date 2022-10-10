import { HttpErrorResponse } from '@angular/common/http';

export class ErrorPayload {
	public response: HttpErrorResponse | undefined;
	public title: string | undefined;
	public customError: { title: string; body } | undefined;
	public redirectToErrorPage = false;
	public errorPage = 'ErrorScreen';
	public sendToSentry = true;

	constructor(init?: Partial<ErrorPayload>) {
		Object.assign(this, { ...init });
	}
}
