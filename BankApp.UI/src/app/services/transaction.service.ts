import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import Transaction from '../models/transaction.model';
import Response from '../models/response.model';

@Injectable({
  providedIn: 'root'
})

export class TransactionService {
  constructor(private http: HttpClient) { }

  makeTransaction(transaction: Transaction): Observable<Response> {
    return this.http.post<any>(`/api/account/${transaction.type}`, transaction);
  }
}
