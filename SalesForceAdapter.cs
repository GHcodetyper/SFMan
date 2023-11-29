using Newtonsoft.Json;
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
		readonly string _sObjectService = @"sobjects/{0}";
		readonly string _sObjectServiceWithId = @"sobjects/{0}/{1}";

		public SFAdapter(string hostUrl, string apiToken)
		{
			_hostUrl = hostUrl;
			_apiToken = apiToken;
		}
		public dynamic GetContactRelationsByAccount(string accountId)
		{
			_httpclient = new HttpClient();

			string query = $"select AccountId, ContactId, Relationship_Strength__c from AccountContactRelation where AccountId= '{accountId}'";
			
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _hostUrl + _queryService + query);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//request.Content = content;

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			dynamic respObj = JObject.Parse(response);
			//Console.WriteLine(re.totalSize);

			var recs = respObj.records;
			if (recs.Count == 0)
				return null;
			
			dynamic result = recs;
			return result;


		}
		//Name,AccountNumber,Phone,Type,Brand__c,Status__c,OwnerId,RecordTypeId,customExtIdField__c
		//"Account.customExtIdField__c","Department","Email","Phone","MobilePhone","FirstName","MiddleName","LastName","MailingStreet","MailingCity","MailingState","MailingCountry","MailingPostalCode","RecordTypeId","Type__c","Contact_Status__c",customExtIdField__c
		public dynamic GetAccountAndContactsByExtId(string extId)
		{
			_httpclient = new HttpClient();

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
			_httpclient = new HttpClient();

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
			_httpclient = new HttpClient();

			string sObjectStr = String.Format(_sObjectServiceWithId, "Contact", Id);
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _hostUrl + sObjectStr);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			dynamic respObj = JObject.Parse(response);

			return respObj;
		}

		public string CreateContact(dynamic contact)
		{
			_httpclient = new HttpClient();

			var str = JsonConvert.SerializeObject(contact, Formatting.Indented);
			Console.WriteLine(str);

			string sObjectStr = String.Format(_sObjectService, "Contact");
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _hostUrl + sObjectStr);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Content = new StringContent(str, Encoding.UTF8, "application/json");

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			dynamic respObj = JObject.Parse(response);

			return respObj.id;
		}


		public bool UpdateContact(dynamic contact, string id)
		{
			_httpclient = new HttpClient();

			var str = JsonConvert.SerializeObject(contact, Formatting.Indented);
			//Console.WriteLine(str);

			string sObjectStr = String.Format(_sObjectServiceWithId, "Contact", id);
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, _hostUrl + sObjectStr);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Content = new StringContent(str, Encoding.UTF8, "application/json");

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			return message.IsSuccessStatusCode;
		}

		public bool UpdateAccount(dynamic account, string id)
		{
			_httpclient = new HttpClient();

			var str = JsonConvert.SerializeObject(account, Formatting.Indented);
			//Console.WriteLine(str);

			string sObjectStr = String.Format(_sObjectServiceWithId, "Account", id);
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, _hostUrl + sObjectStr);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Content = new StringContent(str, Encoding.UTF8, "application/json");

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			return message.IsSuccessStatusCode;
		}
		public string CreateAccount(dynamic account)
		{
			_httpclient = new HttpClient();

			var str = JsonConvert.SerializeObject(account, Formatting.Indented);
			Console.WriteLine(str);

			string sObjectStr = String.Format(_sObjectService, "Account");
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _hostUrl + sObjectStr);

			request.Headers.Add("Authorization", "Bearer " + _apiToken);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Content = new StringContent(str, Encoding.UTF8, "application/json");

			HttpResponseMessage message = _httpclient.SendAsync(request).Result;
			string response = message.Content.ReadAsStringAsync().Result;

			dynamic respObj = JObject.Parse(response);

			return respObj.id;
		}

		public dynamic GetNewAccountDto(dynamic csvAccount)
		{
			dynamic newSFAcc = new System.Dynamic.ExpandoObject();

			newSFAcc.Name = csvAccount.Name;
			newSFAcc.AccountNumber = csvAccount.AccountNumber;
			newSFAcc.Phone = csvAccount.Phone;
			newSFAcc.Type = csvAccount.Type;
			newSFAcc.Brand__c = csvAccount.Brand__c;
			newSFAcc.Status__c = csvAccount.Status__c;
			newSFAcc.RecordTypeId = csvAccount.RecordTypeId;
			newSFAcc.customExtIdField__c = csvAccount.customExtIdField__c;

			return newSFAcc;
		}

		public dynamic GetAccountUpdateDto(dynamic csvAccount)
		{
			dynamic updSFAcc = new System.Dynamic.ExpandoObject();

			updSFAcc.Name = csvAccount.Name;
			updSFAcc.AccountNumber = csvAccount.AccountNumber;
			updSFAcc.Phone = csvAccount.Phone;
			updSFAcc.Type = csvAccount.Type;
			updSFAcc.Brand__c = csvAccount.Brand__c;
			updSFAcc.Status__c = csvAccount.Status__c;
			updSFAcc.RecordTypeId = csvAccount.RecordTypeId;
			updSFAcc.customExtIdField__c = csvAccount.customExtIdField__c;

			return updSFAcc;
		}

		public dynamic GetNewContactDto(dynamic csvContact, string sfAccountId)
		{
			dynamic newSFCon = new System.Dynamic.ExpandoObject();

			newSFCon.AccountId = sfAccountId;
			newSFCon.Department = csvContact.Department;
			newSFCon.Email = csvContact.Email;
			newSFCon.Secondary_Email__c = csvContact.Secondary_Email__c;
			newSFCon.MobilePhone = csvContact.MobilePhone;
			newSFCon.FirstName = csvContact.FirstName;
			newSFCon.MiddleName = csvContact.MiddleName;
			newSFCon.LastName = csvContact.LastName;
			newSFCon.MailingStreet = csvContact.MailingStreet;
			newSFCon.MailingCity = csvContact.MailingCity;
			newSFCon.MailingState = csvContact.MailingState;
			newSFCon.MailingCountry = csvContact.MailingCountry;
			newSFCon.MailingPostalCode = csvContact.MailingPostalCode;
			newSFCon.Type__c = csvContact.Type__c;
			newSFCon.Contact_Status__c = csvContact.Contact_Status__c;
			newSFCon.RecordTypeId = csvContact.RecordTypeId;
			newSFCon.customExtIdField__c = csvContact.customExtIdField__c;
			newSFCon.Phone = csvContact.Phone;

			return newSFCon;
		}

		public dynamic GetContactUpdateDto(dynamic csvContact)
		{
			dynamic updSFCon = new System.Dynamic.ExpandoObject();

			updSFCon.Department = csvContact.Department;
			updSFCon.Email = csvContact.Email;
			updSFCon.Secondary_Email__c = csvContact.Secondary_Email__c;
			updSFCon.MobilePhone = csvContact.MobilePhone;
			updSFCon.FirstName = csvContact.FirstName;
			updSFCon.MiddleName = csvContact.MiddleName;
			updSFCon.LastName = csvContact.LastName;
			updSFCon.MailingStreet = csvContact.MailingStreet;
			updSFCon.MailingCity = csvContact.MailingCity;
			updSFCon.MailingState = csvContact.MailingState;
			updSFCon.MailingCountry = csvContact.MailingCountry;
			updSFCon.MailingPostalCode = csvContact.MailingPostalCode;
			updSFCon.Type__c = csvContact.Type__c;
			updSFCon.Contact_Status__c = csvContact.Contact_Status__c;
			updSFCon.RecordTypeId = csvContact.RecordTypeId;
			updSFCon.customExtIdField__c = csvContact.customExtIdField__c;
			updSFCon.Phone = csvContact.Phone;

			return updSFCon;
		}
	}
}
