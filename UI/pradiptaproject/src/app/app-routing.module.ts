import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/Category/category-list/category-list.component';
import { AddCategoryComponent } from './features/Category/add-category/add-category.component';
import { EdirCategoryComponent } from './features/Category/edir-category/edir-category.component';
const routes: Routes = [
  {
    path:'admin/categories',
    component:CategoryListComponent
  },

  {
    path:'admin/categories/add',
    component:AddCategoryComponent
  },

  {
    path:'admin/categories/:id',
    component: EdirCategoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
