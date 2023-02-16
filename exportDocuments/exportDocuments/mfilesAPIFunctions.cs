using RestSharp;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using danaosDocuments.Dto;

namespace danaosDocuments
{
    class mfilesAPIFunctions
    {
        public static async Task<string> authentication()
        {
            string mfa = "";

            try
            {
                var options = new RestClientOptions()
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://mfiles.island-oil.com/REST/server/authenticationtokens", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = @"{" + "\n" +
                @"    ""Username"": ""admin_username""," + "\n" +
                @"    ""Password"": ""admin_password""," + "\n" +
                @"    ""VaultGuid"": ""vault_key""" + "\n" +
                @"}";
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request);
                var mfaToken = JsonConvert.DeserializeObject<MFAToken>(response.Content);
                mfa = mfaToken.Value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return mfa;
        }

        public static async Task<List<DocumentsDetails>> getDocuments(string mfaParam, string objectTypeParam, string objectIDParam)
        {
            List<DocumentsDetails> documentsDetails = new List<DocumentsDetails>();

            try
            {
                var options = new RestClientOptions()
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://mfiles.island-oil.com/REST/objects/" + objectTypeParam + "/" + objectIDParam + "/files", Method.Get);
                //request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-Authentication", mfaParam);
                request.AddHeader("Cookie", "ASP.NET_SessionId=13x4clvnniblgbyyzsvgavzb; fileDownload=true");
                RestResponse response = await client.ExecuteAsync(request);
                documentsDetails = JsonConvert.DeserializeObject<List<DocumentsDetails>>(response.Content);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return documentsDetails;
        }

        public static async Task<byte[]> downloadDocuments(string mfaParam, string objectTypeParam, string objectIDParam, string documentIDParam)
        {
            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://mfiles.island-oil.com/REST/objects/" + objectTypeParam + "/" + objectIDParam + "/files/" + documentIDParam + "/content", Method.Get);
            request.AddHeader("X-Authentication", mfaParam);
            request.AddHeader("Cookie", "ASP.NET_SessionId=5w5zjzopnu4ej2xrlsdyps4y; fileDownload=true");
            byte[] response = client.DownloadData(request);

            return response;
        }
    }
}
