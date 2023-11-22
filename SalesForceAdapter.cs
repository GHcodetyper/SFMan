using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SFMan
{
	class SFAdapter
	{
		HttpClient _httpclient;
		string _hostUrl;
		string _apiToken;
		readonly string _queryService = "/query/?q=";
		readonly string _sObjectService = @"sobjects/{0}/{1}";

		public SFAdapter(string hostUrl, string apiToken)
		{
			_hostUrl = hostUrl;
			_apiToken = apiToken;
			_httpclient = new HttpClient();
		}
		public void GetContactRelationsByAccount(string extAccountId)
		{
			string query = $"select id, name, customExtIdField__c, (select id, name, customExtIdField__c from Contacts) from account where customExtIdField__c = '{extAccountId}'";
			//HttpContent content = new StringContent(jobconfig, Encoding.UTF8, "application/json");
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _hostUrl + _queryService + query);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//request.Content = content;

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			JObject re = JObject.Parse(response);

			var Name = re.SelectToken($"$.records[0].Name");

			var contacts = re.SelectToken($"$.records[0].Contacts.records");




			//Console.WriteLine(re.totalSize);

			//var recs = re.records;

			//foreach (var rec in recs)
			//{
			//	Console.WriteLine(rec.Id);
			//}

			var a = 5;
		}

		public dynamic GetAccountAndContactsByExtId(string extId)
		{
			string query = String.Format(
				" select Id, Name, CustomExtIdField__c, Type, Phone " +
				" , (select Id, Name, Email, CustomExtIdField__c, Department, Phone, MobilePhone, Secondary_Email__c " +
				" from Contacts) " +
				" from account where CustomExtIdField__c = '{0}'",
			extId);

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _hostUrl + _queryService + query);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			dynamic respObj = JObject.Parse(response);
			//Console.WriteLine(re.totalSize);

			var recs = respObj.records;
			if (recs.Count == 0)
				return null;

			dynamic result = new System.Dynamic.ExpandoObject();
			result.Contacts = respObj.records[0].Contacts.records;
			result.Account = respObj.records[0];

			return result;

			//foreach (var rec in recs)
			//{
			//	foreach (var contact in rec.Contacts.records)
			//	{
			//		Console.WriteLine((int)contact.customExtIdField__c);
			//	}
			//}

			//var a = 5;
		}

		public bool DeleteContact(dynamic contact)
		{
			string sObjectStr = String.Format(_sObjectService, "Contact", (string)contact.Id);
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, _hostUrl + sObjectStr);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			request.Method = HttpMethod.Options;

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			//string response = message.Content.ReadAsStringAsync().Result;

			return message.IsSuccessStatusCode;
		}
		public dynamic GetContact(string Id)
		{
			string sObjectStr = String.Format(_sObjectService, "Contact", Id);
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _hostUrl + sObjectStr);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			dynamic respObj = JObject.Parse(response);

			return respObj;
		}

		public void UpdateContact(dynamic contact)
		{
			return;
		}

		public void UpdateAccount(dynamic account)
		{
			return;
		}
		public void CreateAccount(dynamic account)
		{
			return;
		}
	}
}
