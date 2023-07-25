using Newtonsoft.Json.Linq;

namespace EarthBlog.Core.Utilities.GoogleReCaptcha.V3.Abstract;

public interface ICaptchaValidator
{
	Task<bool> IsCaptchaPassedAsync(string token);

	Task<JObject> GetCaptchaResultDataAsync(string token);

	void UpdateSecretKey(string key);
}