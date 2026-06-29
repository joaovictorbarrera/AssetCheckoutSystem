import { inject } from "@angular/core";
import { CanActivateChildFn, Router } from "@angular/router";
import { AuthService } from "../services/api/auth.service";
import { PageLoadingService } from "../services/util/page-loading.service";

export const authGuard: CanActivateChildFn = async () => {
  const auth = inject(AuthService)
  const router = inject(Router)
  const pageLoading = inject(PageLoadingService)

  pageLoading.setLoading(true)
  const user = await auth.loadUser()
  pageLoading.setLoading(false)

  return user
    ? true
    : router.createUrlTree(['/login'])
};
