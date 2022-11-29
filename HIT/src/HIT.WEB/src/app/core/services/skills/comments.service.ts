import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ToasterService } from '../toaster.service';

@Injectable({
  providedIn: 'root'
})
export class CommentApiService {

  api: string = `${environment.api}/job-posting-applications`;
  constructor(private httpClient: HttpClient, private router: Router, private toastr: ToasterService) { }

  private Comments$$ = new BehaviorSubject<string[]>([]);
  Comments$ = this.Comments$$.asObservable();

  addComment(id: number,newComment: string) {
    return this.create(id,newComment).pipe(
      tap((res : string) => {
        console.log(res)
        this.Comments$$.next([newComment, ...this.Comments$$.getValue()])
        this.toastr.success("Comment added successfully!!!")
      })
    );
  }

  loadComment(id: number): Observable<string[]> {
    return this.GetAll(id).pipe(
    // return of(this.examples).pipe(
      tap((res: string[]) => {
        console.log(id)
        this.Comments$$.next(res)
      })
    )
  }

  create(id: number,newComment: string): Observable<string> {
   return this.httpClient.post<string>(`${this.api}/${id}`, {comment: newComment})
  }

  GetAll(id: number): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.api}/${id}`);
  }
}
