import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { environment } from '../../../../environments/environment'
import { CheckoutRequestDetailDto } from '../../DTOs/checkout-request/checkout-request-detail.dto'
import { CheckoutRequestDto } from '../../DTOs/checkout-request/checkout-request.dto'
import PaginatedResponse from '../../DTOs/shared/paginated.response'
import CheckoutRequestFields from '../../DTOs/checkout-request/checkout-request-fields.dto'
@Injectable({
    providedIn: 'root',
})
export class CheckoutRequestService {
    private readonly apiUrl = `${environment.apiUrl}/checkout-requests`

    constructor(private http: HttpClient) {}

    getCheckoutRequests(request: any = {}) {
        return this.http.get<PaginatedResponse<CheckoutRequestDto>>(this.apiUrl, {
            params: request,
        })
    }

    getDetail(id: string) {
        return this.http.get<CheckoutRequestDetailDto>(`${this.apiUrl}/${id}`)
    }

    getFields() {
        return this.http.get<CheckoutRequestFields>(`${this.apiUrl}/fields`)
    }

    create(request: any) {
        return this.http.post<void>(this.apiUrl, request)
    }

    archive(id: string) {
        return this.http.delete<void>(`${this.apiUrl}/${id}`)
    }

    cancel(id: string) {
        return this.http.patch<void>(`${this.apiUrl}/${id}/cancel`, {})
    }

    approve(id: string) {
        return this.http.patch<void>(`${this.apiUrl}/${id}/approve`, {})
    }

    reject(id: string) {
        return this.http.patch<void>(`${this.apiUrl}/${id}/reject`, {})
    }

    assignAsset(id: string, request: any) {
        return this.http.patch<void>(
        `${this.apiUrl}/${id}/assign-asset`,
        request
        )
    }

    return(id: string) {
        return this.http.patch<void>(`${this.apiUrl}/${id}/return`, {})
    }
}
