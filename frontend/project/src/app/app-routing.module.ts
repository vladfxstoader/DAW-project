import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('src/app/modules/artists/artists.module').then(m => m.ArtistsModule),
      },
      {
        path: 'songs',
        loadChildren: () => import('src/app/modules/songs/songs.module').then(m => m.SongsModule),
      }
    ]
  },
  {
    path: 'login',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
