using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SFMan
{
	class Program
	{
		static string _token = "00DEm000000iVkr!AQEAQAZws3z3_jvUtFXiXz2knYPEp0KpwMfXwGtunFEvyZkUC2f6E6Sj7h_VGOeClnJItabuRKiZbhz3IeNJVrtYlKvnDpPp";
		static string hostUrl = "https://hostway2--datadev.sandbox.my.salesforce.com/services/data/v59.0/";
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");
			//MainAsync().GetAwaiter().GetResult();
			//GetContactRelationsByAccount("acct2667385");
			//GetAccountAndContactsByExtId("acct2667385");
			//var json = ConvertCsvFileToJsonObject(@"c:\temp\SF\Contact.csv");

			//json = "{[{\"Account.customExtIdField__c\":\"acct8567906\",\"Department\":\"regular\",\"Email\":\"test-20210226-0113@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"17788824811\",\"MobilePhone\":\"\",\"FirstName\":\"Regular\",\"MiddleName\":\"\",\"LastName\":\"Contact\",\"MailingStreet\":\"405-3021 St George Street\",\"MailingCity\":\"Port Moody\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V3H0K3\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"test-20210226-0113@hostway.com\"},{\"Account.customExtIdField__c\":\"acct2986226\",\"Department\":\"regular\",\"Email\":\"fhsjdf@fhsdjk.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"5248541254\",\"MobilePhone\":\"\",\"FirstName\":\"sdfa\",\"MiddleName\":\"\",\"LastName\":\"sdfafd\",\"MailingStreet\":\"550 Burrard Street Suite 200\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C 2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"fhsjdf@fhsdjk.com\"},{\"Account.customExtIdField__c\":\"acct2145814\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc011815.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc011815.com\"},{\"Account.customExtIdField__c\":\"acct1838351\",\"Department\":\"regular\",\"Email\":\"dewitt.kev@gmail.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4561252545\",\"MobilePhone\":\"\",\"FirstName\":\"kevin\",\"MiddleName\":\"\",\"LastName\":\"saunders\",\"MailingStreet\":\"550 burrard street suite 200\",\"MailingCity\":\"vancouver\",\"MailingState\":\"bc\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"dewitt.kev@gmail.com\"},{\"Account.customExtIdField__c\":\"sjdfkl2502958\",\"Department\":\"regular\",\"Email\":\"fjls@jsdfklk.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4567891230\",\"MobilePhone\":\"\",\"FirstName\":\"sdjfksl\",\"MiddleName\":\"\",\"LastName\":\"djkfsljf\",\"MailingStreet\":\"100 N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"fjls@jsdfklk.com\"},{\"Account.customExtIdField__c\":\"acct3878888\",\"Department\":\"regular\",\"Email\":\"stoeva.zvezdelina@gmail.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"5555555555\",\"MobilePhone\":\"\",\"FirstName\":\"Zvezdelina\",\"MiddleName\":\"\",\"LastName\":\"Stoeva\",\"MailingStreet\":\"211 W WACKER DR STE 900E\",\"MailingCity\":\"CHICAGO\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"stoeva.zvezdelina@gmail.com\"},{\"Account.customExtIdField__c\":\"acct1877532\",\"Department\":\"regular\",\"Email\":\"sdfhjk@fdshjk.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"5346456521\",\"MobilePhone\":\"\",\"FirstName\":\"hfdskj\",\"MiddleName\":\"\",\"LastName\":\"fshjk\",\"MailingStreet\":\"550 burrard street\",\"MailingCity\":\"vancouver\",\"MailingState\":\"bc\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"v6c2b5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"sdfhjk@fdshjk.com\"},{\"Account.customExtIdField__c\":\"acct4683266\",\"Department\":\"regular\",\"Email\":\"corinne.chui@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7788824811\",\"MobilePhone\":\"\",\"FirstName\":\"Corinne\",\"MiddleName\":\"\",\"LastName\":\"Chui\",\"MailingStreet\":\"405-3021 St George Street\",\"MailingCity\":\"Port Moody\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V3H0K3\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"corinne.chui@netnation.com\"},{\"Account.customExtIdField__c\":\"acct9000889\",\"Department\":\"regular\",\"Email\":\"fhsjdkf@dsfhjkf.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7788824811\",\"MobilePhone\":\"\",\"FirstName\":\"Corinne\",\"MiddleName\":\"\",\"LastName\":\"Chui\",\"MailingStreet\":\"405-3021 St George Street\",\"MailingCity\":\"Port Moody\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V3H0K3\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"fhsjdkf@dsfhjkf.com\"},{\"Account.customExtIdField__c\":\"acct5221413\",\"Department\":\"regular\",\"Email\":\"olivier.r.maguire@gmail.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7787725683\",\"MobilePhone\":\"\",\"FirstName\":\"Olivier\",\"MiddleName\":\"\",\"LastName\":\"Maguire\",\"MailingStreet\":\"33333\",\"MailingCity\":\"asdf\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6Z1W1\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"olivier.r.maguire@gmail.com\"},{\"Account.customExtIdField__c\":\"acct6192394\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-182634.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"100N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-182634.com\"},{\"Account.customExtIdField__c\":\"acct6944978\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-214017.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"100N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-214017.com\"},{\"Account.customExtIdField__c\":\"acct9071825\",\"Department\":\"regular\",\"Email\":\"designamnetnation@gmail.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"designamnetnation@gmail.com\"},{\"Account.customExtIdField__c\":\"acct2701683\",\"Department\":\"regular\",\"Email\":\"fjkl@fsjkl.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"9876543210\",\"MobilePhone\":\"\",\"FirstName\":\"djfkl\",\"MiddleName\":\"\",\"LastName\":\"fjkls\",\"MailingStreet\":\"200- 500 burrard street\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"fjkl@fsjkl.com\"},{\"Account.customExtIdField__c\":\"acct4880393\",\"Department\":\"regular\",\"Email\":\"george.kaloyanov@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"george.kaloyanov@netnation.com\"},{\"Account.customExtIdField__c\":\"acct5163501\",\"Department\":\"regular\",\"Email\":\"test-20210224-0805@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"3125552222\",\"MobilePhone\":\"3125553333\",\"FirstName\":\"Regular\",\"MiddleName\":\"\",\"LastName\":\"Contact\",\"MailingStreet\":\"100 n riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"test-20210224-0805@hostway.com\"},{\"Account.customExtIdField__c\":\"test5781640\",\"Department\":\"regular\",\"Email\":\"ahfjk@fdkjfl.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4567891235\",\"MobilePhone\":\"\",\"FirstName\":\"test\",\"MiddleName\":\"\",\"LastName\":\"test\",\"MailingStreet\":\"100 N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"ahfjk@fdkjfl.com\"},{\"Account.customExtIdField__c\":\"acct9296070\",\"Department\":\"regular\",\"Email\":\"training@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4567891320\",\"MobilePhone\":\"\",\"FirstName\":\"Support Test\",\"MiddleName\":\"\",\"LastName\":\"Inc Account\",\"MailingStreet\":\"550 Burrard Street Suite 200\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"training@netnation.com\"},{\"Account.customExtIdField__c\":\"acct1769185\",\"Department\":\"regular\",\"Email\":\"waproduct-mh@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"6046888946\",\"MobilePhone\":\"\",\"FirstName\":\"WA\",\"MiddleName\":\"\",\"LastName\":\"Product\",\"MailingStreet\":\"550 Burrard Street Suite 200\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"waproduct-mh@netnation.com\"},{\"Account.customExtIdField__c\":\"acct3384330\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc053843.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc053843.com\"},{\"Account.customExtIdField__c\":\"acct9983870\",\"Department\":\"regular\",\"Email\":\"sdfjkl@fsjlk.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7894561233\",\"MobilePhone\":\"\",\"FirstName\":\"jsdfkl\",\"MiddleName\":\"\",\"LastName\":\"sfjlk\",\"MailingStreet\":\"550 Burrard Street\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"sdfjkl@fsjlk.com\"},{\"Account.customExtIdField__c\":\"acct9517140\",\"Department\":\"regular\",\"Email\":\"testprod@saleschannel.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4567891230\",\"MobilePhone\":\"\",\"FirstName\":\"testprod\",\"MiddleName\":\"\",\"LastName\":\"sales channel\",\"MailingStreet\":\"550 Burrard Street Suite 200\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"testprod@saleschannel.com\"},{\"Account.customExtIdField__c\":\"acct1646943\",\"Department\":\"regular\",\"Email\":\"waproduct@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"6046888946\",\"MobilePhone\":\"\",\"FirstName\":\"WA\",\"MiddleName\":\"\",\"LastName\":\"Product\",\"MailingStreet\":\"550 Burrard Street Suite 200\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"waproduct@netnation.com\"},{\"Account.customExtIdField__c\":\"acct4755950\",\"Department\":\"regular\",\"Email\":\"shenaz.bedi@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"6048314068\",\"MobilePhone\":\"\",\"FirstName\":\"Shenaz\",\"MiddleName\":\"\",\"LastName\":\"Bedi\",\"MailingStreet\":\"1234 Seasame Street\",\"MailingCity\":\"Pitt Meadows\",\"MailingState\":\"AL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"12345\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"shenaz.bedi@netnation.com\"},{\"Account.customExtIdField__c\":\"acct5545827\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc014729.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc014729.com\"},{\"Account.customExtIdField__c\":\"acct2772749\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc054601.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc054601.com\"},{\"Account.customExtIdField__c\":\"acct4451119\",\"Department\":\"regular\",\"Email\":\"kate.mullin@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7736808951\",\"MobilePhone\":\"\",\"FirstName\":\"Kate\",\"MiddleName\":\"\",\"LastName\":\"Mullin\",\"MailingStreet\":\"923 Belle Plaine Ave\",\"MailingCity\":\"Park Ridge\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60068\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"kate.mullin@netnation.com\"},{\"Account.customExtIdField__c\":\"acct7361571\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-032641.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"100N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-032641.com\"},{\"Account.customExtIdField__c\":\"acct2523699\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc013353.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc013353.com\"},{\"Account.customExtIdField__c\":\"acct2382802\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc044112.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc044112.com\"},{\"Account.customExtIdField__c\":\"acct3659921\",\"Department\":\"regular\",\"Email\":\"test-20210308-0104@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"3125552222\",\"MobilePhone\":\"3125553333\",\"FirstName\":\"Regular\",\"MiddleName\":\"\",\"LastName\":\"Contact\",\"MailingStreet\":\"100 n riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"test-20210308-0104@hostway.com\"},{\"Account.customExtIdField__c\":\"acct2859456\",\"Department\":\"regular\",\"Email\":\"velizar.apo@gmail.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"359899520396\",\"MobilePhone\":\"\",\"FirstName\":\"Velizar\",\"MiddleName\":\"\",\"LastName\":\"Angelov\",\"MailingStreet\":\"ul. Prolet 8\",\"MailingCity\":\"Sofia\",\"MailingState\":\"Sofia\",\"MailingCountry\":\"BG\",\"MailingPostalCode\":\"1849\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"velizar.apo@gmail.com\"},{\"Account.customExtIdField__c\":\"acct8979600\",\"Department\":\"regular\",\"Email\":\"mail@testbox95.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"18664678929\",\"MobilePhone\":\"\",\"FirstName\":\"Netnation\",\"MiddleName\":\"\",\"LastName\":\"Product\",\"MailingStreet\":\"550 Burrard St. Suite 200\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"mail@testbox95.com\"},{\"Account.customExtIdField__c\":\"acct1691884\",\"Department\":\"regular\",\"Email\":\"corinne.chui@hostwaycorp.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7788824811\",\"MobilePhone\":\"\",\"FirstName\":\"Corinne\",\"MiddleName\":\"\",\"LastName\":\"Chui\",\"MailingStreet\":\"405-3021 St George Street\",\"MailingCity\":\"Port Moody\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V3H 0K3\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"corinne.chui@hostwaycorp.com\"},{\"Account.customExtIdField__c\":\"acct3414267\",\"Department\":\"regular\",\"Email\":\"wrehk@sfuoi.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"1352438547\",\"MobilePhone\":\"\",\"FirstName\":\"sdfhjl\",\"MiddleName\":\"\",\"LastName\":\"sfhk\",\"MailingStreet\":\"550 Burrard Street\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"wrehk@sfuoi.com\"},{\"Account.customExtIdField__c\":\"acct6140441\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc025622.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc025622.com\"},{\"Account.customExtIdField__c\":\"acct3773202\",\"Department\":\"regular\",\"Email\":\"alexander.lochhead@netnation.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"12355555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"alexander.lochhead@netnation.com\"},{\"Account.customExtIdField__c\":\"acct1240430\",\"Department\":\"regular\",\"Email\":\"alexlochhead@gmail.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7782300222\",\"MobilePhone\":\"\",\"FirstName\":\"Alexander\",\"MiddleName\":\"\",\"LastName\":\"Lochhead\",\"MailingStreet\":\"885 60th AVE West\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6P2A2\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"alexlochhead@gmail.com\"},{\"Account.customExtIdField__c\":\"acct5091320\",\"Department\":\"regular\",\"Email\":\"Stephenthegreat1@stephenthegreat.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"7787787788\",\"MobilePhone\":\"\",\"FirstName\":\"Stephen\",\"MiddleName\":\"\",\"LastName\":\"Botha\",\"MailingStreet\":\"108 - 22255 122nd Ave\",\"MailingCity\":\"Maple Ridge\",\"MailingState\":\"Bc\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V2X3X8\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"Stephenthegreat1@stephenthegreat.com\"},{\"Account.customExtIdField__c\":\"acct5575021\",\"Department\":\"regular\",\"Email\":\"fjksldfl@jksflsd.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4567891230\",\"MobilePhone\":\"\",\"FirstName\":\"test\",\"MiddleName\":\"\",\"LastName\":\"Yola Addon\",\"MailingStreet\":\"100N River\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"fjksldfl@jksflsd.com\"},{\"Account.customExtIdField__c\":\"acct3461547\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc020155.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc020155.com\"},{\"Account.customExtIdField__c\":\"acct7545821\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-231425.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"100N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-231425.com\"},{\"Account.customExtIdField__c\":\"acct3811705\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc034931.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc034931.com\"},{\"Account.customExtIdField__c\":\"acct8201710\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc121247.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc121247.com\"},{\"Account.customExtIdField__c\":\"acct4694874\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-135735.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"100N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-135735.com\"},{\"Account.customExtIdField__c\":\"acct2667385\",\"Department\":\"regular\",\"Email\":\"sdfjlsjl@fjdsksdfl.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"778824811\",\"MobilePhone\":\"\",\"FirstName\":\"corinne\",\"MiddleName\":\"\",\"LastName\":\"chui\",\"MailingStreet\":\"405-3021 St George Street\",\"MailingCity\":\"Port Moody\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V3H0K3\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"sdfjlsjl@fjdsksdfl.com\"},{\"Account.customExtIdField__c\":\"acct7370245\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-161019.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"100N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-161019.com\"},{\"Account.customExtIdField__c\":\"acct4537548\",\"Department\":\"regular\",\"Email\":\"khashi_yousefi@yahoo.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"6046579662\",\"MobilePhone\":\"\",\"FirstName\":\"Khashayar\",\"MiddleName\":\"\",\"LastName\":\"Yousefi\",\"MailingStreet\":\"5899 Nancy Greene Way\",\"MailingCity\":\"North Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V7R4W6\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"khashi_yousefi@yahoo.com\"},{\"Account.customExtIdField__c\":\"acct4014901\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc045315.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc045315.com\"},{\"Account.customExtIdField__c\":\"acct6935400\",\"Department\":\"regular\",\"Email\":\"sfdjl@dfjskl.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"6155324865\",\"MobilePhone\":\"\",\"FirstName\":\"sdfjkl\",\"MiddleName\":\"\",\"LastName\":\"sfdjl\",\"MailingStreet\":\"550 burrard street\",\"MailingCity\":\"vancouver\",\"MailingState\":\"bc\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"v6c2b5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"sfdjl@dfjskl.com\"},{\"Account.customExtIdField__c\":\"acct5347195\",\"Department\":\"regular\",\"Email\":\"test-20210225-1202@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"3125552222\",\"MobilePhone\":\"3125553333\",\"FirstName\":\"Regular\",\"MiddleName\":\"\",\"LastName\":\"Contact\",\"MailingStreet\":\"100 n riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"test-20210225-1202@hostway.com\"},{\"Account.customExtIdField__c\":\"acct2174517\",\"Department\":\"regular\",\"Email\":\"5stef5@comcast.net\",\"Secondary_Email__c\":\"\",\"Phone\":\"6306773157\",\"MobilePhone\":\"\",\"FirstName\":\"Stefan\",\"MiddleName\":\"\",\"LastName\":\"Raduha\",\"MailingStreet\":\"1920 Elm Ct Apt 5A\",\"MailingCity\":\"Hanover Park\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60133\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"5stef5@comcast.net\"},{\"Account.customExtIdField__c\":\"acct1202800\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc055126.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc055126.com\"},{\"Account.customExtIdField__c\":\"acct9269246\",\"Department\":\"regular\",\"Email\":\"corinne.chui@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"Corinne\",\"MiddleName\":\"\",\"LastName\":\"Chui\",\"MailingStreet\":\"405-3021 St George street\",\"MailingCity\":\"Port Moody\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V3H0K3\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"corinne.chui@hostway.com\"},{\"Account.customExtIdField__c\":\"acct7202994\",\"Department\":\"regular\",\"Email\":\"george.kaloyanov@netnation2.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"1235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"george.kaloyanov@netnation2.com\"},{\"Account.customExtIdField__c\":\"acct7487633\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc055801.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc055801.com\"},{\"Account.customExtIdField__c\":\"acct5375401\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc122859.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"123 First Str.\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60000\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc122859.com\"},{\"Account.customExtIdField__c\":\"acct9345396\",\"Department\":\"billing\",\"Email\":\"email@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"3125552222\",\"MobilePhone\":\"3125553333\",\"FirstName\":\"Billing\",\"MiddleName\":\"X\",\"LastName\":\"Customer\",\"MailingStreet\":\"100 n riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"email@hostway.com\"},{\"Account.customExtIdField__c\":\"acct2066230\",\"Department\":\"regular\",\"Email\":\"dsfjlsj@fjsdkl.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4567891230\",\"MobilePhone\":\"\",\"FirstName\":\"sjafdkjl\",\"MiddleName\":\"\",\"LastName\":\"jfsdkfjl\",\"MailingStreet\":\"550 Burrard Street Suite 200\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"dsfjlsj@fjsdkl.com\"},{\"Account.customExtIdField__c\":\"acct9345396\",\"Department\":\"regular\",\"Email\":\"test-20210226-1239@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"3125552222\",\"MobilePhone\":\"3125553333\",\"FirstName\":\"Regular\",\"MiddleName\":\"\",\"LastName\":\"Contact\",\"MailingStreet\":\"100 n riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"test-20210226-1239@hostway.com\"},{\"Account.customExtIdField__c\":\"acct2350330\",\"Department\":\"regular\",\"Email\":\"S_botha@shaw.ca\",\"Secondary_Email__c\":\"\",\"Phone\":\"7789967204\",\"MobilePhone\":\"\",\"FirstName\":\"Stephen\",\"MiddleName\":\"\",\"LastName\":\"Botha\",\"MailingStreet\":\"200 550 Burrard Street\",\"MailingCity\":\"Vancouver\",\"MailingState\":\"BC\",\"MailingCountry\":\"CA\",\"MailingPostalCode\":\"V6C2B5\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"S_botha@shaw.ca\"},{\"Account.customExtIdField__c\":\"acct9333677\",\"Department\":\"regular\",\"Email\":\"test-20210305-1116@hostway.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"3125552222\",\"MobilePhone\":\"3125553333\",\"FirstName\":\"Regular\",\"MiddleName\":\"\",\"LastName\":\"Contact\",\"MailingStreet\":\"100 n riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"test-20210305-1116@hostway.com\"},{\"Account.customExtIdField__c\":\"acct5225735\",\"Department\":\"regular\",\"Email\":\"admin@ng-test-cc022359.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"11235555555\",\"MobilePhone\":\"\",\"FirstName\":\"John\",\"MiddleName\":\"\",\"LastName\":\"Doe\",\"MailingStreet\":\"100 N Riverside\",\"MailingCity\":\"Chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"admin@ng-test-cc022359.com\"},{\"Account.customExtIdField__c\":\"acct7746920\",\"Department\":\"regular\",\"Email\":\"fjsk@fdksl.com\",\"Secondary_Email__c\":\"\",\"Phone\":\"4567891350\",\"MobilePhone\":\"\",\"FirstName\":\"test\",\"MiddleName\":\"\",\"LastName\":\"test\",\"MailingStreet\":\"9485 fsjfkl\",\"MailingCity\":\"chicago\",\"MailingState\":\"IL\",\"MailingCountry\":\"US\",\"MailingPostalCode\":\"60606\",\"RecordTypeId\":\"0126g000000iYxv\",\"Type__c\":\"Channel\",\"Contact_Status__c\":\"Qualified\",\"customExtIdField__c\":\"fjsk@fdksl.com\"}]}";
			//json = "{\"Contacts\": [{\"Account.customExtIdField__c\":\"acct8567906\"}]}";
			//JObject o = JObject.Parse(json);
			//IEnumerable<JToken> sel = o.SelectToken("$.records[?(@.Account--customExtIdField__c == 'acct8567906')]");
			//JToken sel = o.SelectToken("$.records[?(@.Email == 'test-20210226-0113@hostway.com')]");
			//IList<string> deps = o["records"].Select(r => (string)r.SelectToken("Account--customExtIdField__c")).ToList();
			//foreach (JToken item in sel)
			//{
			//	Console.WriteLine(item);
			//}

			var csvContacts = new CSVContacts(@"c:\temp\SF\Contact 1.csv");
			//foreach (var ac in csvContacts.csvHelper.GetCSVEntities())
			//{
			//	Console.WriteLine(ac.GetEntityProperty("MailingStreet"));
			//}

			dynamic cons = csvContacts.GetContactsByAccountId("acct8567906");
			string e0 = cons[0]?.Email;

			dynamic con = csvContacts.GetContactById(103191671);
			string e1 = con.Email;
			string e2 = csvContacts.GetContactProperty(103191671, "Email");
			
			string e3 = csvContacts.GetContactProperty(con, "Email");



			 var csvAccounts = new CSVAccounts(@"c:\temp\SF\Account 1.csv");
			//foreach (var ac in csvAccounts.csvHelper.GetCSVEntities())
			//{
			//	Console.WriteLine(ac.GetEntityProperty("Name"));
			//}

			var acc = csvAccounts.GetAccountById("acct8567906");
			string phone = csvAccounts.GetAccountProperty("acct8567906", "Phone");



			SFAdapter sfa = new SFAdapter(hostUrl, _token);




			//-------------------------------------------------------------

			var csvACRelations = new CSVACRelations(@"c:\temp\SF\AccountContactRelation 2.csv");

			foreach (dynamic csvAccount in csvAccounts.csvHelper.GetCSVEntities())
			{
				//for the case when: foreach (var csvAccount in ....
				//string csvAccountId = csvAccount.GetEntityProperty("customExtIdField__c");//"acct8567906";
				string csvAccountId = csvAccount.customExtIdField__c;


				if (csvAccountId != "acct8567906")
					continue;

				dynamic sfAccStruct = sfa.GetAccountAndContactsByExtId(csvAccountId);
				if (sfAccStruct == null)
				{
					// Handle the case when on CSV side there is the Account but on SF side there is not any
					string accPhone = csvAccounts.GetAccountProperty(csvAccountId, "Phone");
					//TODO: insert the account using the SObject API call
					sfa.CreateAccount(csvAccount);
					continue;
				}

				//dynamic sfAcc = new System.Dynamic.ExpandoObject();
				////Name,AccountNumber,Phone,Type,Brand__c,Status__c,OwnerId,RecordTypeId,customExtIdField__c
				//sfAcc.Name = csvAccount.Name + "_123";
				//sfAcc.AccountNumber = csvAccount.AccountNumber + "_123";
				//sfAcc.Phone = csvAccount.Phone + "_123123";
				//sfAcc.Type = csvAccount.Type; // "Channel";
				//sfAcc.Brand__c = csvAccount.Brand__c;  // "Hostway";
				//sfAcc.Status__c = csvAccount.Status__c;
				//sfAcc.RecordTypeId = csvAccount.RecordTypeId; // "0126g000000iYxgAAE";
				//sfAcc.customExtIdField__c = csvAccount.customExtIdField__c + "_123";
				//sfa.CreateAccount(sfAcc);

				dynamic sfAccount = sfAccStruct.Account;
				Console.WriteLine($"SF Account: {{{sfAccount.customExtIdField__c}, {sfAccount.Id}, {sfAccount.Name}, {sfAccount.Type}}}");

				dynamic sfAccountUpdateDto = new System.Dynamic.ExpandoObject();
				sfAccountUpdateDto.Phone = csvAccount.Phone;
				sfa.UpdateAccount(sfAccountUpdateDto, (string)sfAccount.Id);

				dynamic sfContactArray = sfAccStruct.Contacts;
				Console.WriteLine(sfContactArray);

				dynamic csvContactArray = csvContacts.GetContactsByAccountId(csvAccountId);


				List<dynamic> sfContactsToDelete = new List<dynamic>();
				List<dynamic> sfContactsToUpdate = new List<dynamic>();

				foreach (dynamic sfContact in sfContactArray)
				{
					if (sfContact.customExtIdField__c == null)
					{
						sfContact.SyncOperation = "del-id-null";
						sfContactsToDelete.Add(sfContact);
						continue;
					}

					foreach(dynamic csvContact in csvContactArray)
					{
						if ((int)sfContact.customExtIdField__c == (int)csvContact.customExtIdField__c)
						{
							sfContact.SyncOperation = "upd";
							sfContactsToUpdate.Add(sfContact);
						}
					}
				}

				foreach (dynamic sfContact in sfContactArray)
				{
					if (sfContact.SyncOperation == null)
						sfContact.SyncOperation = "del-id-not-found";

					switch ((string)sfContact.SyncOperation)
					{
						case "del-id-null":
						case "del-id-not-found":
							sfa.DeleteContact(sfContact);
							break;
						case "upd":
							break;
						default:
							break;
					}
				}
			}



			//foreach (var acRel in csvACRelations.csvHelper.GetCSVEntities())
			//{
			//	string csvAccountId = acRel.GetEntityProperty("Account--customExtIdField__c");
			//	int csvContactId = int.Parse(acRel.GetEntityProperty("Contact--customExtIdField__c"));
			//	string RelationshipStrength = acRel.GetEntityProperty("Relationship_Strength__c");


			//	dynamic csvContact = csvContacts.GetContactById(csvContactId);
			//	Console.WriteLine(csvContact);
			//	dynamic csvAccount = csvAccounts.GetAccountById(csvAccountId);
			//	Console.WriteLine(csvAccount);

			//	if (csvAccountId != "acct8567906")
			//		continue;

			//	dynamic sfAccStruct = sfa.GetAccountAndContactsByExtId(csvAccountId);
			//	Console.WriteLine($"SF Account: {{{sfAccStruct.Account.customExtIdField__c}, {sfAccStruct.Account.Id}, {sfAccStruct.Account.Name}, {sfAccStruct.Account.Type}}}");

			//	if (sfAccStruct == null)
			//	{
			//		// Handle the case when on CSV side there is the Account but on SF side there is not any
			//		string accPhone = csvAccounts.GetAccountProperty(csvAccountId, "Phone");
			//		//TODO: insert the account using the SObject API call
			//		continue;
			//	}



			//	var csvACRArray = csvACRelations.GetACRsByAccountId(csvAccountId);
			//	List<int> csvContactIds = new List<int>();
			//	foreach (var acr in csvACRArray)
			//		csvContactIds.Add(int.Parse(acr.GetEntityProperty("Contact--customExtIdField__c")));

			//	dynamic sfContactArray = sfAccStruct.Contacts;

			//	List<int> sfContactIds = new List<int>();
			//	foreach (var sfc in sfContactArray)
			//	{
			//		int sfContCustExtFieldId = (sfc.customExtIdField__c == null) ? -1 : (int)sfc.customExtIdField__c;
			//		sfContactIds.Add(sfContCustExtFieldId);
			//	}

			//	IEnumerable<int> newCSVIds = csvContactIds.Except(sfContactIds);
			//	foreach (var csvId in newCSVIds)
			//	{
			//		// Handle the case when the CSV account has a new contact
			//		// add the contact on the SF side
			//		Console.WriteLine(csvId);
			//	}

			//	IEnumerable<int> newSFIds = sfContactIds.Except(csvContactIds);
			//	foreach (var csvId in newSFIds)
			//	{
			//		// Handle the case when the SF account has a new contact
			//		// ?? delete the account on the SF side
			//		Console.WriteLine(csvId);
			//	}

			//	IEnumerable<int> commonIds = sfContactIds.Intersect(csvContactIds);
			//	foreach (var csvId in commonIds)
			//	{
			//		// Handle the case when the CSV account and the SF account have the same contact
			//		// ?? update the account on the SF side
			//		Console.WriteLine(csvId);
			//	}
			//	}







			//var acrAr = csvACRelations.GetACRsByAccountId("acct8567906");

			//foreach (var acr in acrAr)
			//{
			//	//Console.WriteLine(csvACRelations.GetACRProperty(acr, "Account--customExtIdField__c"));
			//	//Console.WriteLine(acr.GetEntityProperty("Account--customExtIdField__c"));


			//	dynamic acrStruct = new System.Dynamic.ExpandoObject();
			//	acrStruct.AccountId = acr.GetEntityProperty("Account--customExtIdField__c");
			//	acrStruct.ContactId = int.Parse(acr.GetEntityProperty("Contact--customExtIdField__c"));
			//	acrStruct.RelationshipStrength = acr.GetEntityProperty("Relationship_Strength__c");
			//	Console.WriteLine($"CSV: {{{acrStruct.AccountId}, {acrStruct.ContactId}, {acrStruct.RelationshipStrength}}}");

			//	dynamic csvCon = csvContacts.GetContactById(acrStruct.ContactId);
			//	Console.WriteLine(csvCon);
			//	dynamic csvAccount = csvAccounts.GetAccountById(acrStruct.AccountId);
			//	Console.WriteLine(csvAccount);



			//}


			//var accStruct = GetAccountAndContactsByExtId("acct2Z667385");
			//foreach (var contact in accStruct.Contacts)
			//	Console.WriteLine((int)contact.customExtIdField__c);

			//Console.WriteLine(accStruct.Account.Id);
			//Console.WriteLine(accStruct.Account.customExtIdField__c);

			var d = sfa.GetContact("003Em0000075h57IAA");

			var a = 5;
		}

		static async Task MainAsync()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Get, "https://hostway2--datadev.sandbox.my.salesforce.com/services/data/v59.0/query/?q=SELECT FIELDS(All) FROM ACCOUNT ORDER BY Name LIMIT 50");
			request.Headers.Add("Authorization", "Bearer 00D3J0000000MkA!ARcAQGMWQHXX86mkfavN9PnG4UPW9RpP5l3uTVMll.DX3Mh29Jk.pKermYhxvPKtsvIl35zyWEQe4ONyFk_sqOid078jpfXv");
			request.Headers.Add("Cookie", "BrowserId=kAf-TW8AEe6OOQsj47s6lg; CookieConsentPolicy=0:1; LSKey-c$CookieConsentPolicy=0:1");
			var content = new StringContent(string.Empty);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			request.Content = content;
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			Console.WriteLine(await response.Content.ReadAsStringAsync());
		}

	}

}