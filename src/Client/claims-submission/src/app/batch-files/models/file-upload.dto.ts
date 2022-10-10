export class FileUploadDto {
	readonly file: File;

	constructor(file: File) {
		this.file = file;
	}
}
