import { Routes } from '@angular/router';
import { Home } from './features/home/home.component';
import { Themes } from './features/themes/themes';
import { Login } from './features/auth/login/login';
import { Register } from './features/auth/register/register';
import { ThemeContent } from './features/themes/theme-content/theme-content';
import { Profile } from './features/profile/profile';
import { authGuard } from './core/guards/auth.guard';
import { NotFound } from './features/not-found/not-found';
import { NewTheme } from './features/themes/new-theme/new-theme';


export const routes: Routes = [
    { path: "", redirectTo: 'home', pathMatch: 'full' },

    { path: "home", component: Home },

    { path: 'login', component: Login },
    { path: 'register', component: Register },

    { path: "themes", component: Themes },
    { path: "themes/:themeId", component: ThemeContent },
    { path: "add-theme", component: NewTheme, canActivate: [authGuard]  },

    { path: "profile", component: Profile, canActivate: [authGuard] },
    { path: '**', component: NotFound }
];
