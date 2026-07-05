import { Injectable } from '@angular/core'
import { Subject } from 'rxjs'

@Injectable({ providedIn: 'root' })
export class CheckoutRequestEventsService {
  private _checkoutRequestsChanged = new Subject<void>()
  checkoutRequestsChanged$ = this._checkoutRequestsChanged.asObservable()

  emitCheckoutRequestsChanged(): void {
    this._checkoutRequestsChanged.next()
  }
}
