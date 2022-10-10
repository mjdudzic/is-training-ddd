import { HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RemoteServiceBase } from 'src/app/shared/services/remote.service.base';
import { BatchFileViewModel } from '../models/batch-file.viewmodel';
import { FileUploadDto } from '../models/file-upload.dto';
import { SubmittedBatchFileDto } from '../models/submitted-batch-file.dto';

export abstract class IBatchFileService extends RemoteServiceBase {
	public abstract loadBatches(): Observable<BatchFileViewModel[]>;
	public abstract uploadBatchFile(accreditationCode: string, fileUploadDto: FileUploadDto): Observable<HttpEvent<any>>;
	public abstract submitBatchFile(batchFileId: string): Observable<SubmittedBatchFileDto>;
}
