namespace Coevent.Api.Authentication;

using Coevent.Api.Models.Tokens;

public interface IAuthenticator
{
    string HashPassword(string password);

    Entities.User FindUser(string username);

    Entities.User FindUser(Guid key);

    Entities.User Validate(string username, string password);

    Task<TokenModel> AuthenticateAsync(Entities.User user);
}
