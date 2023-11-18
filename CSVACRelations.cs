using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMan
{
	class CSVACRelations
	{
		public CSVHelper csvHelper;
		public CSVACRelations(string fileName)
		{
			csvHelper = new CSVHelper(fileName);
			csvHelper.Populate();
		}
		public JToken[] GetACRsByAccountId(string accountId)
		{
			return csvHelper.GetCSVEntities().SelectTokens($"$.[?(@.Account--customExtIdField__c == '{accountId}')]").ToArray();
		}
		//public JToken[] GetACRsByEmail(string accountId)
		//{
		//	return csvHelper.GetCSVEntities().SelectTokens($"$.[?(@.Contact--customExtIdField__c == '{accountId}')]").ToArray();
		//}
		public JToken[] GetACRsById(int id)
		{
			return csvHelper.GetCSVEntities().SelectTokens($"$.[?(@.Contact.customExtIdField__c == '{id}')]").ToArray();
		}
		public string GetACRProperty(JToken acRel, string propertyName)
		{
			var value = acRel.SelectToken($"{propertyName}")?.Value<string>();
			return value != null ? value : "";
		}

		public string GetACRProperty(string accountId, string propertyName)
		{
			JToken jt = GetACRsByAccountId(accountId)[0];
			return GetACRProperty(jt, propertyName);
		}

	}
}
