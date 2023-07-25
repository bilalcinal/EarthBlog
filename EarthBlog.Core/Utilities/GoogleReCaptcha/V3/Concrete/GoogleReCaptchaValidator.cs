using System.Net;
using EarthBlog.Core.Utilities.GoogleReCaptcha.V3.Abstract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace EarthBlog.Core.Utilities.GoogleReCaptcha.V3.Concrete;

public class GoogleReCaptchaValidator : ICaptchaValidator
{
	private readonly HttpClient _httpClient;

	private const string RemoteAddress = "https://www.google.com/recaptcha/api/siteverify";

	private string _secretKey;

	public GoogleReCaptchaValidator(HttpClient httpClient, IConfiguration configuration)
	{
		_httpClient = httpClient;
		_secretKey = configuration["googleReCaptcha:SecretKey"];
	}

	public async Task<bool> IsCaptchaPassedAsync(string token)
	{
		dynamic response = await GetCaptchaResultDataAsync(token);
		return response.success == "true";
	}

	public async Task<JObject> GetCaptchaResultDataAsync(string token)
	{
		var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[2]
		{
			new KeyValuePair<string, string>("secret", _secretKey),
			new KeyValuePair<string, string>("response", token)
		});
		HttpResponseMessage res = await _httpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
		if (res.StatusCode != HttpStatusCode.OK)
		{
			throw new HttpRequestException(res.ReasonPhrase);
		}
		return JObject.Parse(await res.Content.ReadAsStringAsync());
	}

	public void UpdateSecretKey(string key)
	{
		_secretKey = key;
	}
}