import { Observable } from 'rxjs';
import { BatchFileViewModel } from '../models/batch-file.viewmodel';
import { BatchFiles } from '../state/batch-files.action';

export abstract class IStoreService {
	public abstract dispatch(action: BatchFiles.SubmitRequested | BatchFiles.ReportsLinkAttached): Observable<any>;
	public abstract selectLoadedViewModels(): BatchFileViewModel[];
}
