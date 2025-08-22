using System.Text;
using System.Text.Json.Serialization;

namespace Idp.Contract.Authentication.Response;

public record InternalAuthorizeRedirectResponse(
    [property: JsonIgnore] string Root,
    [property: JsonIgnore] ParamsWrapper ParamWrapper)
{
    public string Link
    {
        get
        {
            var rootUrl = new StringBuilder($"{Root}");

            if (ParamWrapper.Params.Count > 0)
                rootUrl.Append('?');

            foreach (var param in ParamWrapper.Params)
            {
                rootUrl.Append($"{param.Key}={param.Value}&");
            }

            rootUrl.Remove(rootUrl.Length - 1, 1);

            return rootUrl.ToString();
        }
    }
}