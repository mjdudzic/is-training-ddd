import {Observable, take, throwError} from "rxjs";
import {catchError, tap} from "rxjs/operators";
import {IProgressSpinnerService} from "../services/progress-spinner.service.base";


export function handleServiceResponse<T>(progressSpinnerService: IProgressSpinnerService, responseHandler: (response: T) => void) {
	return function handleOperator(source: Observable<T>): Observable<T> {
		return source.pipe(take(1), tap(response => {
			progressSpinnerService.hideProgressSpinner();
			responseHandler(response);
		}),
		catchError(error => {
			progressSpinnerService.hideProgressSpinner();
			return throwError(() => error);
		}))
	}
}
