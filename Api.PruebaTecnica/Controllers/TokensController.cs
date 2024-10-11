using Application.Tokens.Generate;
using Domain.Security.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace Api.PruebaTecnica.Controllers;

[Route("tokens")]
[AllowAnonymous]
public class TokensController(ISender _mediator) : ApiController
{
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateToken(GenerateTokenRequest request)
    {


        var query = new GenerateTokenQuery(
            request.Id,
            request.FirstName,
            request.LastName,
            request.Email,
            request.Permissions,
            request.Roles);

        var result = await _mediator.Send(query);

        return result.Match(
            generateTokenResult => Ok(ToDto(generateTokenResult)),
            Problem);
    }

    private static TokenResponse ToDto(GenerateTokenResult authResult)
    {
        return new TokenResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);
    }
}