using System.Text.Json.Serialization;
using Idp.Contract.Enum;

namespace Idp.Contract.Authentication.Request;

public record CodeAuthorizeRequest(
    [property:JsonPropertyName("client_id")]
    string ClientId,
    [property:JsonPropertyName("redirect_uri")]
    string RedirectUri,
    [property:JsonPropertyName("scopes")]
    string[] Scopes,
    [property:JsonPropertyName("state")]
    string State,
    [property:JsonPropertyName("code_challenge")]
    string CodeChallenge,
    [property:JsonPropertyName("code_challenge_method")]
    CodeChallengeMethod CodeChallengeMethod);