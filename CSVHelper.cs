﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMan
{
	class CSVHelper
	{
		private string _fileName;
		private string _json;
		public CSVHelper(string fileName)
		{
			_fileName = fileName;
		}

		public void Populate()
		{
			_json = ConvertCsvFileToJsonObject();
		}

		public JToken GetCSVEntities()
		{
			return JToken.Parse(_json)["records"];
		}

		private string ConvertCsvFileToJsonObject()
		{
			var csv = new List<string[]>();
			var lines = File.ReadAllLines(_fileName);

			foreach (string line in lines)
				csv.Add(line.Split(','));

			var properties = lines[0].Split(',');

			//for ( int i properties)
			//{
			//	property = property.Substring(1, property.Length - 2);
			//}

			var listObjResult = new List<Dictionary<string, string>>();

			for (int i = 1; i < lines.Length; i++)
			{
				var objResult = new Dictionary<string, string>();
				string prop = string.Empty;
				string val = string.Empty;

				for (int j = 0; j < properties.Length; j++)
				{
					prop = properties[j];
					val = csv[i][j];

					if (prop.Contains('\"'))
						prop = properties[j].Substring(1, properties[j].Length - 2);
					if (val.Contains('\"'))
						val = val.Substring(1, csv[i][j].Length - 2);
					objResult.Add(prop.Replace(".", "--"), val);
				}

				listObjResult.Add(objResult);
			}

			return String.Format("{{\"records\" : {0} }}", JsonConvert.SerializeObject(listObjResult, Formatting.Indented));
		}
	}

	public static class JObjectExtensions
	{
		public static string GetEntityProperty(this JToken entity, string propertyName)
		{
			var value = entity.SelectToken($"{propertyName}")?.Value<string>();
			return value != null ? value : "";
		}
	}
}
