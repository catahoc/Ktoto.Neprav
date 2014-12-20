using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ktoto.Neprav.Utils
{
	public class VkArgsSource : IVkArgsSource
	{
		private readonly string markerVar = "user_id";
		private readonly string markerPrefix = "vk.";
		private readonly string[] _varsNames = new[]
		{
			"api_url", //это адрес сервиса API, по которому необходимо осуществлять запросы.
			"api_id", //это id запущенного приложения.
			"user_id",//это id пользователя, со страницы которого было запущено приложение. Если приложение запущено не со страницы пользователя, то значение равно 0.
			"sid", //id сессии для осуществления запросов к API
			"secret", //Секрет, необходимый для осуществления подписи запросов к API
			"group_id",//это id группы, со страницы которой было запущено приложение. Если приложение запущено не со страницы группы, то значение равно 0.
			"viewer_id", //это id пользователя, который просматривает приложение.
			"is_app_user", //если пользователь установил приложение",//1, иначе",//0.
			"is_secure", //если пользователем используется защищенное соединение",//1, иначе",//0.
			"viewer_type", //это тип пользователя, который просматривает приложение (возможные значения описаны ниже).
			"auth_key", //это ключ, необходимый для авторизации пользователя на стороннем сервере (см. описание ниже).
			"language", //это id языка пользователя, просматривающего приложение (см. список языков ниже).
			"api_settings",//битовая маска настроек текущего пользователя в данном приложении (подробнее см. в описании метода account.getAppPermissions).
			"referrer", //это обозначение места откуда пользователь перешёл в приложение (см. список значений ниже).
			"access_token", //ключ доступа для использования упрощённого вызова методов API.
			"lc_name" //— служебные параметры."
		};

		public Dictionary<string, string> GetVkArgs(HttpRequest request, HttpResponse response)
		{
			if (HasVkArgs(request))
			{
				SaveToCookie(request, response);
				return GetFromCookies(response.Cookies);
			}
			else
			{
				if (HasVkCookies(request.Cookies))
				{
					return GetFromCookies(request.Cookies);
				}
				else
				{
					throw new InvalidOperationException("Vk cookies missing");
				}
			}
		}

		private void SaveToCookie(HttpRequest request, HttpResponse response)
		{
			var query = request.QueryString;
			var args = query.AllKeys.SelectMany(query.GetValues, (k, v) => new { key = k, value = v }).ToDictionary(_ => _.key, _ => _.value);
			foreach (var arg in args)
			{
				response.AppendCookie(new HttpCookie(markerPrefix + arg.Key, arg.Value));
			}
		}

		private Dictionary<string, string> GetFromCookies(HttpCookieCollection cookies)
		{
			return cookies.AllKeys.ToDictionary(_ => _, _ => cookies[_]).Values
				.Where(cook => cook.Name.StartsWith(markerPrefix))
				.ToDictionary(_ => _.Name, _ => _.Value);
		}

		private bool HasVkCookies(HttpCookieCollection cookies)
		{
			return cookies.AllKeys.ToDictionary(_ => _, _ => cookies[_]).Values.Any(cook => cook.Name.StartsWith(markerPrefix));
		}

		private bool HasVkArgs(HttpRequest request)
		{
			var nonProvidedVkArgs = _varsNames.Except(request.QueryString.AllKeys);
			return !nonProvidedVkArgs.Any();
		}
	}
}