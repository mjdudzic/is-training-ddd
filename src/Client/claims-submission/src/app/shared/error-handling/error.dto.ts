export class ErrorDto {
	public errorCode: number | undefined;
	public errorDescription: string | undefined;

	constructor(init?: Partial<ErrorDto>) {
		Object.assign(this, { ...init });
	}
}
