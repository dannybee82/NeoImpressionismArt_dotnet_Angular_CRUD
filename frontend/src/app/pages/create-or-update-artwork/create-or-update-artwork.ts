import { Component, inject, input, InputSignal, OnInit, signal, WritableSignal } from '@angular/core';
import { GetAll } from '../../core/services/generics/get-all/get-all';
import { Artist } from '../../core/models/artist/artist.interface';
import { RESOURCE_CONFIG } from '../../core/services/generics/tokens/resource.config';
import { EMPTY, Observable, switchMap } from 'rxjs';
import { Artwork } from '../../core/models/art/artwork.interface';
import { GetById } from '../../core/services/generics/get-by-id/get-by-id';
import { Create } from '../../core/services/generics/create/create';
import { Update } from '../../core/services/generics/update/update';
import { environment } from '../../../environments/environment';
import { CreateOrUpdateArtworkInterface } from '../../core/models/create-or-update-artwork/create-or-update-artwork.interface';
import { form, min, required, FormField } from '@angular/forms/signals';
import { OpenFile } from '../../core/components/open-file/open-file';
import { AsyncPipe } from '@angular/common';
import { LoadFilesInBrowser } from '../../core/services/load-file-in-browser/load-file-in-browser';
import { BackToMainComponent } from '../../core/components/back-to-main/back-to-main.component';
import { DeleteDialogData } from '../../core/models/dialogs/delete-dialog-data.interface';
import { DeleteDialog } from '../../core/components/delete-dialog/delete-dialog';
import { DeleteById } from '../../core/services/generics/delete-by-id/delete-by-id';

// Angular Material Modules
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { ToastService } from '../../core/services/toast/toast-service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

@Component({
  imports: [FormField, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, OpenFile, MatIconModule, AsyncPipe, BackToMainComponent],
  selector: 'app-create-or-update-artwork',
  styleUrl: './create-or-update-artwork.scss',
  templateUrl: './create-or-update-artwork.html',
  providers: [
    GetAll<Artist>, GetById<Artwork>, Create<Artwork>, Update<Artwork>, DeleteById,
    {
      provide: RESOURCE_CONFIG,
      useValue: {
        methodGetAll: { controller: 'Artist', method: 'GetAll' },
        methodById: { controller: 'Artwork', method: 'GetById' },
        methodCreate: { controller: 'Artwork', method: 'Create' },
        methodUpdate: { controller: 'Artwork', method: 'Update' },
        methodDeleteById: { controller: 'Artwork', method: 'Delete' }
      }
    }
  ],
})
export class CreateOrUpdateArtwork implements OnInit {

  protected readonly id: InputSignal<number | undefined> = input.required<number | undefined>();

  artists$?: Observable<Artist[]>;
  private _apiurl: string = environment.apiUrl;
  private _artworkToUpdate: WritableSignal<Artwork | undefined> = signal(undefined);
  protected isUpdateMode: WritableSignal<boolean> = signal<boolean>(false);
  protected imagePreview: WritableSignal<string> = signal('');

  private _defaultData: CreateOrUpdateArtworkInterface = {
    id: undefined,
    name: '',
    description: '',
    artistId: 0
  };
  protected formModel: WritableSignal<CreateOrUpdateArtworkInterface> = signal<CreateOrUpdateArtworkInterface>(structuredClone(this._defaultData));
  protected form = form(this.formModel, (form) => {
    required(form.name, { message: 'Name for the Artwork is required' });
    required(form.description, { message: 'Description for the Artwork is required' });
    required(form.artistId, { message: 'Artist for the Artwork is required' });
    min(form.artistId, 1, { message: 'Artist for the Artwork is required' });
  });
  private _file: File | undefined = undefined;
  protected isSubmitting: WritableSignal<boolean> = signal<boolean>(false);

  private readonly getAllArtistsService = inject(GetAll<Artist>);
  private readonly getByIdArtworkService = inject(GetById<Artwork>);
  private readonly createArtworkService = inject(Create<Artwork>);
  private readonly updateArtworkService = inject(Update<Artwork>);
  private readonly deleteArtworkService = inject(DeleteById);
  private readonly loadFilesInBrowser = inject(LoadFilesInBrowser);
  private readonly toast = inject(ToastService);
  private readonly router = inject(Router);
  protected readonly dialog = inject(MatDialog);

  ngOnInit(): void {
    this.artists$ = this.getAllArtistsService.getAll();
    this.loadById();
  }

  submit($event: SubmitEvent): void {
    $event.preventDefault();
    this.isSubmitting.set(true);
    
    if(!this.form().valid) {
      this.isSubmitting.set(false);
      this.toast.show(`Form is invalid.`, 'error');
      return;
    }

    if(!this._file && !this.isUpdateMode()) {
      this.toast.show(`There is no image added yet.`, 'error');
      this.isSubmitting.set(false);
      return;
    }

    const data: CreateOrUpdateArtworkInterface = this.form().value();

    const action$ = this.isUpdateMode()
      ? this.updateArtworkService.updateReturnEntity(this.getFormData(data, this._file))
      : this.createArtworkService.createReturnEntity(this.getFormData(data, this._file));

    action$.subscribe({
      next: () => {},
      error: (error) => {
        console.error('Error submitting artwork:', error);
        const message: string = this.isUpdateMode() ? 
          `Error updating Artwork.` : 
          `Can't create Artwork.`;
        this.toast.show(message, 'error');
      },
      complete: () => {
        const message: string = this.isUpdateMode() ? 
          `Artwork has been updated successfully` : 
          `Artwork has been created successfully`;
        this.toast.show(message, 'success');
        this.isSubmitting.set(false);
        this.router.navigate(['']);
      }
    });
  }

  getImageSource(): string {
    if(this.isUpdateMode()) {
      if(this._artworkToUpdate()?.imageId) {
        return `${this._apiurl}/Artwork/${this._artworkToUpdate()!.imageId}`;
      }      
    } 

    return this.imagePreview() !== '' ? this.imagePreview() : '';
  }

  getImageUrl(): string {    
    return this._artworkToUpdate()?.imageId ? `${this._apiurl}/Artwork/${this._artworkToUpdate()?.imageId}` : '';
  }

  removeFile(): void {
    this._file = undefined;
    this.imagePreview.set('');

    if(this.isUpdateMode() && this._artworkToUpdate()) {
      this._artworkToUpdate()!.imageId = undefined;
    }
  }

  loadFile($event: File): void {
    this._file = $event;

    this.loadFilesInBrowser.readFile($event).then((result: string | null) => {
      if (result) {
        if (
          this.loadFilesInBrowser.isValidDataType(result) &&
          this.loadFilesInBrowser.checkMaximumSize($event.size)
        ) {
          this.imagePreview.set(result);
        } else {
          if (!this.loadFilesInBrowser.isValidDataType(result)) {
            this.toast.show('File is invalid', 'error');
          } else if (this.loadFilesInBrowser.checkMaximumSize($event.size)) {
           this.toast.show('File exceeds 10 MB', 'error');
          }
        }
      } else {
        this.toast.show('Invalid file', 'error');
      }
    });
  }

  delete(): void {
    const dialogData: DeleteDialogData = {
      title: 'Delete Artwork',
      message: 'Do you really want to the delete the Artwork here below?',
      additionalData: `${this._artworkToUpdate()!.name} - ${this._artworkToUpdate()!.artist?.name}`,
      confirmDelete: false,
    };

    const dialog = this.dialog.open(DeleteDialog, { data: dialogData });

    const result$: Observable<void> = dialog.afterClosed().pipe(
      switchMap((data: DeleteDialogData) => {
        if (data) {
          if (data.confirmDelete) {
            return this.deleteArtworkService.delete(this._artworkToUpdate()!.id);
          }
        }

        return EMPTY;
      }),
    );

    result$.subscribe({
      next: () => {
        this.toast.show('Artwork successfully deleted', 'success');
        this.router.navigate(['/']);
      },
      error: () => {
        this.toast.show("Can't delete Drawing", 'error');
      },
    });
  }

  private loadById(): void {
    if(this.id() && !isNaN(parseInt(this.id()?.toString() ?? ''))) {
      this.getByIdArtworkService.getById(this.id() as number).subscribe({
        next: (artwork: Artwork) => {
          this._artworkToUpdate.set(artwork);
          this.isUpdateMode.set(true);
        },
        error: (error) => {       
          this.toast.show(`Error fetching artwork by ID: ${error}`, 'error');
        },
        complete: () => {
          if(this.isUpdateMode() && this._artworkToUpdate()) {
            this.formModel.set({
              id: this._artworkToUpdate()?.id,
              name: this._artworkToUpdate()?.name ?? '',
              description: this._artworkToUpdate()?.description ?? '',
              artistId: this._artworkToUpdate()?.artist?.id ?? 0
            });
          }
        }
      });      
    } else {
      this.isUpdateMode.set(false);
      this._artworkToUpdate.set(undefined);
    }
  }

  private getFormData(data: CreateOrUpdateArtworkInterface, file?: File): FormData {
    const form = new FormData();

    if(file) {
      form.append('file', file);
    }        
  
    if (data.id) {  
      form.append('Id', data.id.toString());
    }  

    form.append('Name', data.name);          
    form.append('Description', data.description);  
    form.append('ArtistId', data.artistId.toString());     

    return form;
  }

}
