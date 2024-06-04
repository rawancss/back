using ApiWithJWT.Dtos;
using ApiWithJWT.Wrappers;

namespace ApiWithJWT.Services.Interfaces;
public interface IAccountService
{
    Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
    Task<BaseResult> RegisterCustomer(RegistrationRequest request);
}