using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMan
{
	class CSVAccounts
	{
		public CSVHelper csvHelper;
		public CSVAccounts(string fileName)
		{
			csvHelper = new CSVHelper(fileName);
			csvHelper.Populate();
		}
		public JToken GetAccountById(string accountId)
		{
			return csvHelper.GetCSVEntities().SelectToken($"$.[?(@.customExtIdField__c == '{accountId}')]");
		}
		public string GetAccountProperty(JToken account, string propertyName)
		{
			var value = account.SelectToken($"{propertyName}")?.Value<string>();
			return  value != null ? value : "";
		}
		public string GetAccountProperty(string accountId, string propertyName)
		{
			JToken jt = GetAccountById(accountId);
			return GetAccountProperty(jt, propertyName);
		}

	}
}
