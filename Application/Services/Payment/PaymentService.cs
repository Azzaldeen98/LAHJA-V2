using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Services.Plans
{
    public class PaymentService
    {
        private readonly GetCheckoutUseCase getCheckoutUseCase;
        private readonly GetCheckoutManageUseCase getCheckoutManageUseCase;


        public PaymentService(GetCheckoutUseCase getCheckoutUseCase, GetCheckoutManageUseCase CheckoutManageAsync)
        {
            this.getCheckoutUseCase = getCheckoutUseCase;
            this.getCheckoutManageUseCase = CheckoutManageAsync;
        }

        public async Task<Result<CheckoutResponse>> getCheckout(CheckoutRequest  request)
        {
            return await getCheckoutUseCase.ExecuteAsync(request);

        }

        public async Task<Result<CheckoutResponse>> CheckoutManageAsync(SessionCreate request)
        {
            return await getCheckoutManageUseCase.ExecuteAsync(request);

        }




    } 
}
