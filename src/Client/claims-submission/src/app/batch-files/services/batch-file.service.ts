import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BatchFileViewModel } from '../models/batch-file.viewmodel';
import { FileUploadDto } from '../models/file-upload.dto';
import { SubmittedBatchFileDto } from '../models/submitted-batch-file.dto';
import { IBatchFileService } from './batch-file.service.base';

@Injectable()
export class BatchFileService extends IBatchFileService {
	constructor(httpClient: HttpClient) {
		super(httpClient);
	}

	loadBatches(): Observable<BatchFileViewModel[]> {
		const url = `${this.apiEndpoint}/batchfile`;
		return this.httpClient.get<BatchFileViewModel[]>(url);
	}

	uploadBatchFile(accreditationCode: string, fileUploadDto: FileUploadDto): Observable<HttpEvent<any>> {
		const headers = new HttpHeaders();
		headers.set('Content-Type', 'multipart/form-data');

		const formData = new FormData();
		Object.entries(fileUploadDto).forEach(([key, value]) => {
			if (value instanceof Date) {
				value = value.toISOString();
			}
			formData.append(key, value);
		});

		formData.append('HealthcareFacilityId', accreditationCode);

		const options = {
			headers,
			reportProgress: true
		};

		const request = new HttpRequest('POST', `${this.apiEndpoint}/batchfile`, formData, options);

		return this.httpClient.request(request);
	}

	submitBatchFile(batchFileId: string): Observable<SubmittedBatchFileDto> {
		return this.httpClient.put<SubmittedBatchFileDto>(`${this.apiEndpoint}/batchfile/${batchFileId}`, {
			BatchFileAction: 0
		});
	}
}
