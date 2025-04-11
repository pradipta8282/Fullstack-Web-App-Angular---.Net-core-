import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { __param } from 'tslib';
import { CategoryService } from '../services/category.service';
import { category } from '../models/category.model';
import { UpdateCategotyRequest } from '../models/update-category-request-model';

@Component({
  selector: 'app-edir-category',
  templateUrl: './edir-category.component.html',
  styleUrls: ['./edir-category.component.css']
})
export class EdirCategoryComponent implements OnInit, OnDestroy{
  id: string | null=null;
  paramSubscription?: Subscription;
  editCategorySubscription?: Subscription;


  category?: category;
constructor(private route: ActivatedRoute,
private categoryService: CategoryService,
private router:Router
){}

 
ngOnInit(): void {
  this.paramSubscription= this.route.paramMap.subscribe({
    next:(params)=>{
     this.id= params.get('id');
     if(this.id){
      //get the data from the api for category id.
      this.categoryService.getCategoryByID(this.id)
      .subscribe({
            next:(response) =>{
              this.category= response;
            }
      })
     }
    }
  });
}
onFormSubmit():void{
  const UpdateCategotyRequest:UpdateCategotyRequest= {
    name: this.category?.name ?? '',
    urlHandle:this.category?.urlHandle  ?? ''
  };
  //pass this object to service
  if(this.id)
  this.editCategorySubscription=this.categoryService.updateCategory(this.id ,UpdateCategotyRequest)
.subscribe({
  next:(response) =>{
  this.router.navigateByUrl('/admin/categories');
  }
})
}


ngOnDestroy(): void {
  this.paramSubscription?.unsubscribe();
  this.editCategorySubscription?.unsubscribe();
}
}
