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
		public JToken GetContactByAccountId(string accountId)
		{
			return csvHelper.GetCSVEntities().SelectToken($"$.[?(@.Account--customExtIdField__c == '{accountId}')]");
		}
		public string GetContactProperty(JToken contact, string propertyName)
		{
			var value = contact.SelectToken($"{propertyName}")?.Value<string>();
			return  value != null ? value : "";
		}

		public string GetContactProperty(string accountId, string propertyName)
		{
			JToken jt = GetContactByAccountId(accountId);
			return GetContactProperty(jt, propertyName);
		}

	}
}
