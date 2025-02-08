using Application.Services.Plans;
using AutoMapper;
using Domain.Wrapper;
using LAHJA.Helpers.Services;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;

namespace LAHJA.ApplicationLayer.Payment
{
    public class PaymentClientService
    {
        private readonly PaymentService paymentService;
        private readonly TokenService tokenService;
        private readonly IMapper _mapper;



        public PaymentClientService(PaymentService paymentService, IMapper mapper, TokenService tokenService)
        {

            this.paymentService = paymentService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }




        public async Task<Result<CheckoutResponse>> getCheckoutPage(CheckoutRequest request)
        {

            var result=await paymentService.getCheckout(request);
            return result;

       

        }     
        
        public async Task<Result<CheckoutResponse>> CheckoutManageAsync(SessionCreate request)
        {

            var result=await paymentService.CheckoutManageAsync(request);
            return result;

       
        }

    }
}
