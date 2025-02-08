using AutoMapper;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Response;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Payment;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Templates.Payment
{

    public class DataBuildPaymentBase {

        public string PlanId  { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; } 
    }


    public interface IBuilderPaymentComponent<T> : IBuilderComponents<T>
    {

        public Func<T, Task> SubmitCheckout { get; set; }




    }



    public interface IBuilderCheckoutApi<T> : IBuilderApi<T>
    {


        //Task<Result<List<InputCategory>>> OnInitialize();


        Task<Result<CheckoutResponse>> CheckoutAsync(T data);


    }

    public abstract class BuilderCheckoutApi<T, E> : BuilderApi<T, E>, IBuilderCheckoutApi<E>
    {

        public BuilderCheckoutApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        //public abstract Task<Result<List<InputCategory>>> OnInitialize();

        public abstract Task<Result<CheckoutResponse>> CheckoutAsync(E data);




    }
    public class BuilderPaymentComponent<T> : IBuilderPaymentComponent<T>
    {
        public Func<T, Task> SubmitCheckout { get; set; }
    }


    public class TemplatePaymentShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderCheckoutApi<E> builderApi;
        private readonly IBuilderPaymentComponent<E> builderComponents;
        public IBuilderPaymentComponent<E> BuilderComponents { get => builderComponents; }
        public TemplatePaymentShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderPaymentComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderPaymentComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }

     
    public class BuilderCheckoutApiClient : BuilderCheckoutApi<PaymentClientService, DataBuildPaymentBase>, IBuilderCheckoutApi<DataBuildPaymentBase>
    {
        public BuilderCheckoutApiClient(IMapper mapper, PaymentClientService service) : base(mapper, service)
        {
        }


        public override async Task<Result<CheckoutResponse>> CheckoutAsync(DataBuildPaymentBase data)
        {

            var model = Mapper.Map<CheckoutRequest>(data);
            var res = await Service.getCheckoutPage(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<CheckoutResponse>(res.Data);
                    return Result<CheckoutResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<CheckoutResponse>.Fail();
                }
            }
            else
            {
                return Result<CheckoutResponse>.Fail(res.Messages);
            }
        }
    }


    public class TemplatePayment : TemplatePaymentShare<PaymentClientService, DataBuildPaymentBase>
    {

   
        public List<string> Errors { get => _errors; }

   


        public TemplatePayment(
            IMapper mapper,
            AuthService AuthService,
            PaymentClientService client,
            IBuilderPaymentComponent<DataBuildPaymentBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCheckout = onSubmitCheckout;
       

            this.builderApi = new BuilderCheckoutApiClient(mapper, client);

            //Task.FromResult(OnInitialize());

        }



        public async Task onSubmitCheckout(DataBuildPaymentBase data) {
            
            data.SuccessUrl = $"{navigation.BaseUri}settings";
            data.CancelUrl = $"{navigation.BaseUri}settings/billing";
			var res=await  builderApi.CheckoutAsync(data);
            if (res.Succeeded && res.Data!=null && !string.IsNullOrEmpty(res.Data.url)) {
                navigation.NavigateTo(res.Data.url,true);
            }
            else
            {
                Snackbar.Add("Field Option ! Please try anther once or again login ", Severity.Error);
            }

        } 

        public async Task<Result<CheckoutResponse>> getCheckoutUrlPage(DataBuildPaymentBase DataBuildPaymentBase)
        {
      
               return await builderApi.CheckoutAsync(DataBuildPaymentBase);

        }

   


    }

}
