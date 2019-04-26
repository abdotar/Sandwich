using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sandwich.Models.ConnectionsCFG
{
	public class NewsService
	{
		// adres of api
		const string Url = "http://sandwichbistro.ru/api/news/";
		// настройка клиента

		private HttpClient GetClient()
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			return client;
		}

		// получаем все Новости
		public async Task<IEnumerable<New>> Get()
		{
			HttpClient client = GetClient();
			string result = await client.GetStringAsync(Url);
			return JsonConvert.DeserializeObject<IEnumerable<New>>(result);
		}



		//to do if needed to add new news from app
		// добавляем одно блюдо
		/*public async Task<Meal> Add(Meal meal)
		{
			HttpClient client = GetClient();
			var response = await client.PostAsync(Url,
				new StringContent(
					JsonConvert.SerializeObject(meal),
					Encoding.UTF8, "application/json"));

			if (response.StatusCode != HttpStatusCode.OK)
				return null;

			return JsonConvert.DeserializeObject<Meal>(
				await response.Content.ReadAsStringAsync());
		}*/
		// обновляем блюдо
		/*public async Task<Meal> Update(Meal meal)
		{
			HttpClient client = GetClient();
			var response = await client.PutAsync(Url + "/" + meal.Id,
				new StringContent(
					JsonConvert.SerializeObject(meal),
					Encoding.UTF8, "application/json"));

			if (response.StatusCode != HttpStatusCode.OK)
				return null;

			return JsonConvert.DeserializeObject<Meal>(
				await response.Content.ReadAsStringAsync());
		}*/
		// удаляем блюдо
		/*public async Task<Meal> Delete(int id)
		{
			HttpClient client = GetClient();
			var response = await client.DeleteAsync(Url + "/" + id);
			if (response.StatusCode != HttpStatusCode.OK)
				return null;

			return JsonConvert.DeserializeObject<Meal>(
			   await response.Content.ReadAsStringAsync());
		}*/
	}
}
