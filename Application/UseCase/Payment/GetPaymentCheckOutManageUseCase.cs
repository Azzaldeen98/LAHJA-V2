using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Domain.Repository.Checkout;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetCheckoutManageUseCase
    {
        private readonly ICheckoutRepository repository;
        public GetCheckoutManageUseCase(ICheckoutRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<CheckoutResponse>> ExecuteAsync(SessionCreate request)
        {

            return await repository.CheckoutManageAsync(request);

        }
    }

}
