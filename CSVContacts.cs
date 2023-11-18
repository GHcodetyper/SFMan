using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMan
{
	class CSVContacts
	{
		public CSVHelper csvHelper;
		public CSVContacts(string fileName)
		{
			csvHelper = new CSVHelper(fileName);
			csvHelper.Populate();
		}
		public JToken GetContactById(int id)
		{
			return csvHelper.GetCSVEntities().SelectToken($"$.[?(@.customExtIdField__c == '{id}')]");
		}
		public JToken[] GetContactsByAccountId(string accountId)
		{
			return csvHelper.GetCSVEntities().SelectTokens($"$.[?(@.Account--customExtIdField__c == '{accountId}')]").ToArray();
		}
		public string GetContactProperty(JToken contact, string propertyName)
		{
			var value = contact.SelectToken($"{propertyName}")?.Value<string>();
			return  value != null ? value : "";
		}

		public string GetContactProperty(int id, string propertyName)
		{
			JToken jt = GetContactById(id);
			return GetContactProperty(jt, propertyName);
		}

	}
}
