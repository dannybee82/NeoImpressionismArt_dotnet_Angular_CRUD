import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./pages/all-artworks/all-artworks').then((c) => c.AllArtworks),
    },
    {
        path: 'artwork/:id',
        loadComponent: () => import('./pages/artwork-details/artwork-details').then((c) => c.ArtworkDetails),
    },
    {
        path: 'create-or-update-artwork/:id',
        loadComponent: () => import('./pages/create-or-update-artwork/create-or-update-artwork').then((c) => c.CreateOrUpdateArtwork),
    }
];
