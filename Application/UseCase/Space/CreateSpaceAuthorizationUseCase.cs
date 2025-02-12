using Domain.Entities.AuthorizationSession;
using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.Entities.Service.Response;
using Domain.Entities.Space.Request;
using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
using Domain.Repository.Price;
using Domain.Repository.Service;
using Domain.ShareData.Base;
using Domain.Wrapper;
using System.Linq.Expressions;

namespace Application.UseCase.Space
{
    public class CreateSpaceAuthorizationUseCase
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IAuthorizationSessionRepository authorizationSessionRepository;

        public CreateSpaceAuthorizationUseCase(IServiceRepository serviceRepository, IAuthorizationSessionRepository authorizationSessionRepository)
        {
            this.serviceRepository = serviceRepository;
            this.authorizationSessionRepository = authorizationSessionRepository;
        }


        public async Task<Result<AuthorizationSessionWebResponse>> ExecuteAsync(SpaceRequest request)
        {

            try
            {

                ServiceResponse? service=null;
                if (!string.IsNullOrEmpty(request.ServiceId))
                {
                    service = await serviceRepository.GetOneAsync(request.ServiceId);
                }
                else
                {
                    var services = await serviceRepository.GetAllAsync();
                    if (services.Any())
                    {
                        service = services.FirstOrDefault(x => x.AbsolutePath.ToLower().Contains("createspace"));

                    }
                }


                if (service != null)
                {
                    var encrypt = await authorizationSessionRepository.EncryptFromWebAsync();
                    if (encrypt != null)
                    {
                        var response = await authorizationSessionRepository.CreateAuthorizationSessionAsync(new AuthorizationWebRequest
                        {
                            ServiceId = service.Id,
                            Token = encrypt.EncrptedToken
                        });
                        if (response != null)
                        {
                            return Result<AuthorizationSessionWebResponse>.Success(response);
                        }
                    }
                }

                //var taskEncrypt = Task.FromResult(async() => {

                //    try
                //    {
                //        return await authorizationSessionRepository.EncryptFromWebAsync();
                //    }
                //    catch (ServerException e) {
                //        throw;
                //    }
                //    catch (Exception e) {
                //        throw;
                //    }

                //});
                // var taskService = Task.FromResult(async () => {

                //         if (!string.IsNullOrEmpty(serviceId)) {

                //             return await serviceRepository.GetOneAsync(serviceId);
                //         }
                //         else
                //         {
                //             var services = await serviceRepository.GetAllAsync();
                //             if (services.Any())
                //             {
                //                 var service = services.FirstOrDefault(x => x.Name.ToLower().Contains("space") && x.Name.ToLower().Contains("create"));
                //                 if (service != null)
                //                 { }

                //                 return service;
                //             }

                //             return null;
                //         }

                //     });

                // taskEncrypt.Start();
                // taskService.Start();

                // var encrypt = taskEncrypt.WaitAsync(CancellationToken.None).ContinueWith(r => {

                //     if (r.IsCompletedSuccessfully && r.Status != TaskStatus.Faulted) 
                //     {

                //     }



                // });
                // var service = await taskEncrypt.WaitAsync(CancellationToken.None);
                // if (service.Invoke()!=null && encrypt != null)
                // {

                //     var response = await authorizationSessionRepository.CreateAuthorizationSessionAsync(new AuthorizationWebRequest
                //     {
                //         ServiceId = service.Id,
                //         Token = encrypt.
                //     });
                //     if (response != null)
                //     {


                //         return Result<AuthorizationSessionWebResponse>.Success(response);
                //     }
                // }



                return  Result<AuthorizationSessionWebResponse>.Fail();
            }
            catch (ServerException e) {

                return Result<AuthorizationSessionWebResponse>.Fail(e.Message,e.StatusCode);
            }
            catch (Exception e) {
               return Result<AuthorizationSessionWebResponse>.Fail(e.Message);
            }


        }
    }






}
