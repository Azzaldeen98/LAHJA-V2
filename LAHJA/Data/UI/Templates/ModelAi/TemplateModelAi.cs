using AutoMapper;
using Domain.Entities.ModelAi;
using Domain.Repository.ModelAi;
using Domain.Wrapper;
using LAHJA.Data.UI.Templates.ModelAi;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using LAHJA.ApplicationLayer.AuthorizationSession;
using LAHJA.Data.UI.Components;
using LAHJA.Data.UI.Templates.ModelAi;
using LAHJA.Data.UI.Templates.ModelAi;
using LAHJA.ApplicationLayer.ModelAi;
using LAHJA.Data.UI.Models.ModelAi;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DataSource.ApiClient.Payment;

namespace LAHJA.Data.UI.Templates.ModelAi
{
    public interface IBuilderModelAiComponent<T>
    {
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByCategory { get; set; }
        Func<T, Task<Result<ModelAiResponseEntity>>> GetModelAi { get; set; }
        Func<T, Task<Result<ItemEntity>>> GetStartStudio { get; set; }
        Func<T, Task<Result<ICollection<ValueFilterModelEntity>>>> GetValueFilterService { get; set; }
        Func<T, Task<Result<ModelPropertyValuesEntity>>> GetSettingModelAi { get; set; }
        Func<T, Task<Result<IDictionary<string, object>>>> GetModelChatStudio { get; set; }
        Func<Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsAi { get; set; }
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByDialect { get; set; }
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByGender { get; set; }
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByLanguage { get; set; }
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByIsStandard { get; set; }
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByLanguageAndDialect { get; set; }
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByTypeAndGender { get; set; }
        Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByLanguageDialectType { get; set; }
        Func<T, Task<Result<IDictionary<string, object>>>> GetModelSpeechStudio { get; set; }
        Func<T, Task<Result<IDictionary<string, object>>>> GetModelTextStudio { get; set; }
    }
    public interface IBuilderModelAiApi<T>
    {
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByCategoryAsync(T dataBuild);
        Task<Result<ModelAiResponseEntity>> GetModelAiAsync(T dataBuild);
        Task<Result<ItemEntity>> GetStartStudioAsync(T dataBuild);
        Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(T dataBuild);
        Task<Result<ModelPropertyValuesEntity>> GetSettingModelAiAsync(T dataBuild);
        Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsAiAsync();
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByDialectAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByGenderAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByIsStandardAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAndDialectAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByTypeAndGenderAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageDialectTypeAsync(T dataBuild);
        Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(T dataBuild);
        Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(T dataBuild);
    }
    public abstract class BuilderModelAiApi<T, E> : BuilderApi<T, E>, IBuilderModelAiApi<E>
    {
    

        public BuilderModelAiApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

       
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByCategoryAsync(E dataBuild);
        public abstract Task<Result<ModelAiResponseEntity>> GetModelAiAsync(E dataBuild);
        public abstract Task<Result<ItemEntity>> GetStartStudioAsync(E dataBuild);
        public abstract Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(E dataBuild);
        public abstract Task<Result<ModelPropertyValuesEntity>> GetSettingModelAiAsync(E dataBuild);
        public abstract Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsAiAsync();
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByDialectAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByGenderAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByIsStandardAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAndDialectAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByTypeAndGenderAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageDialectTypeAsync(E dataBuild);
        public abstract Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(E dataBuild);
        public abstract Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(E dataBuild);
    }

    public class BuilderModelAiComponent<T> : IBuilderModelAiComponent<T>
    {
        public Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByCategory { get; set; }
        public Func<T, Task<Result<ModelAiResponseEntity>>> GetModelAi { get; set; }
        public Func<T, Task<Result<ItemEntity>>> GetStartStudio { get; set; }
        public Func<T, Task<Result<ICollection<ValueFilterModelEntity>>>> GetValueFilterService { get; set; }
        public Func<T, Task<Result<ModelPropertyValuesEntity>>> GetSettingModelAi { get; set; }
        public Func<T, Task<Result<IDictionary<string, object>>>> GetModelChatStudio { get; set; }
        public Func<Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsAi { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByDialect { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByGender { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByLanguage { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByIsStandard { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByLanguageAndDialect { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByTypeAndGender { get; set; }
        public Func<T,  Task<Result<ICollection<ModelAiResponseEntity>>>> GetModelsByLanguageDialectType { get; set; }
        public Func<T, Task<Result<IDictionary<string, object>>>> GetModelSpeechStudio { get; set; }
        public Func<T, Task<Result<IDictionary<string, object>>>> GetModelTextStudio { get; set; }
    }

    public class TemplateModelAiShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderModelAiApi<E> builderApi;
        private readonly IBuilderModelAiComponent<E> builderComponents;
        public IBuilderModelAiComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateModelAiShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderModelAiComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderModelAiComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            this.builderComponents = builderComponents;


        }


    }
    public class BuilderModelAiApiClient : BuilderModelAiApi<ModelAiClientService, DataBuildModelAi>, IBuilderModelAiApi<DataBuildModelAi>
    {
       

        public BuilderModelAiApiClient(IMapper mapper, ModelAiClientService service):base(mapper, service) {    
        
            
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByCategoryAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByCategoryAsync(dataBuild.Category);
        }

        public override async Task<Result<ModelAiResponseEntity>> GetModelAiAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelAiAsync(dataBuild.Id);
        }

        public override async Task<Result<ItemEntity>> GetStartStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetStartStudioAsync(dataBuild.Language);
        }

        public override async Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetValueFilterServiceAsync(dataBuild.Language);
        }

        public override async Task<Result<ModelPropertyValuesEntity>> GetSettingModelAiAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetSettingModelAiAsync(dataBuild.Language);
        }

        public override async Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelChatStudioAsync(dataBuild.Language);
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsAiAsync()
        {
            return await Service.GetModelsAiAsync();
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByDialectAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByDialectAsync(dataBuild.Dialect);
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByGenderAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByGenderAsync(dataBuild.Gender);
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByLanguageAsync(dataBuild.Language);
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByIsStandardAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByIsStandardAsync(dataBuild.SsStandard);
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAndDialectAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByLanguageAndDialectAsync(dataBuild.Language, dataBuild.Dialect);
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByTypeAndGenderAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByTypeAndGenderAsync(dataBuild.Type, dataBuild.Gender);
        }

        public override async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageDialectTypeAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelsByLanguageDialectTypeAsync(dataBuild.Language, dataBuild.Dialect, dataBuild.Type);
        }

        public override async Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelSpeechStudioAsync(dataBuild.Language);
        }

        public override async Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelTextStudioAsync(dataBuild.Language);
        }
    }
    public class TemplateModelAi: TemplateBase<ModelAiClientService, DataBuildModelAi>
    {
        private readonly IBuilderModelAiApi<DataBuildModelAi> _builderApi;
        private readonly IBuilderModelAiComponent<DataBuildModelAi> _builderComponents;

        public IBuilderModelAiComponent<DataBuildModelAi> BuilderComponents => _builderComponents;

        public TemplateModelAi(
            IMapper mapper,
            ModelAiClientService client,
            AuthService authService,
            IBuilderModelAiComponent<DataBuildModelAi> builderComponents,
            IBuilderModelAiApi<DataBuildModelAi> builderApi): base(mapper, authService, client)
        {
            _builderApi = builderApi;
            _builderComponents = builderComponents;

            // ربط الوظائف من ModelAiApiClient مع الوظائف في BuilderComponents
            _builderComponents.GetModelsByCategory = OnGetModelsByCategoryAsync;
            _builderComponents.GetModelAi = OnGetModelAiAsync;
            _builderComponents.GetStartStudio = OnGetStartStudioAsync;
            _builderComponents.GetValueFilterService = OnGetValueFilterServiceAsync;
            _builderComponents.GetSettingModelAi = OnGetSettingModelAiAsync;
            _builderComponents.GetModelChatStudio = OnGetModelChatStudioAsync;
            _builderComponents.GetModelsAi = OnGetModelsAiAsync;
            _builderComponents.GetModelsByDialect = OnGetModelsByDialectAsync;
            _builderComponents.GetModelsByGender = OnGetModelsByGenderAsync;
            _builderComponents.GetModelsByLanguage = OnGetModelsByLanguageAsync;
            _builderComponents.GetModelsByIsStandard = OnGetModelsByIsStandardAsync;
            _builderComponents.GetModelsByLanguageAndDialect = OnGetModelsByLanguageAndDialectAsync;
            _builderComponents.GetModelsByTypeAndGender = OnGetModelsByTypeAndGenderAsync;
            _builderComponents.GetModelsByLanguageDialectType = OnGetModelsByLanguageDialectTypeAsync;
            _builderComponents.GetModelSpeechStudio = OnGetModelSpeechStudioAsync;
            _builderComponents.GetModelTextStudio = OnGetModelTextStudioAsync;
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByCategoryAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByCategoryAsync(dataBuild);
        }

        private async Task<Result<ModelAiResponseEntity>> OnGetModelAiAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelAiAsync(dataBuild);
        }

        private async Task<Result<ItemEntity>> OnGetStartStudioAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetStartStudioAsync(dataBuild);
        }

        private async Task<Result<ICollection<ValueFilterModelEntity>>> OnGetValueFilterServiceAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetValueFilterServiceAsync(dataBuild);
        }

        private async Task<Result<ModelPropertyValuesEntity>> OnGetSettingModelAiAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetSettingModelAiAsync(dataBuild);
        }

        private async Task<Result<IDictionary<string, object>>> OnGetModelChatStudioAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelChatStudioAsync(dataBuild);
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsAiAsync()
        {
            return await _builderApi.GetModelsAiAsync();
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByDialectAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByDialectAsync(dataBuild);
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByGenderAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByGenderAsync(dataBuild);
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByLanguageAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByLanguageAsync(dataBuild);
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByIsStandardAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByIsStandardAsync(dataBuild);
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByLanguageAndDialectAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByLanguageAndDialectAsync(dataBuild);
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByTypeAndGenderAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByTypeAndGenderAsync(dataBuild);
        }

        private async Task<Result<ICollection<ModelAiResponseEntity>>> OnGetModelsByLanguageDialectTypeAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelsByLanguageDialectTypeAsync(dataBuild);
        }

        private async Task<Result<IDictionary<string, object>>> OnGetModelSpeechStudioAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelSpeechStudioAsync(dataBuild);
        }

        private async Task<Result<IDictionary<string, object>>> OnGetModelTextStudioAsync(DataBuildModelAi dataBuild)
        {
            return await _builderApi.GetModelTextStudioAsync(dataBuild);
        }
    }
}


