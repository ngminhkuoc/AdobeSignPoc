using AdobeSign.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdobeSign
{
    partial class Program
    {
        //You have to have an Adobe account then go to setting to create this access token
        private const string AccessToken = "BlahBlah";

        private const string apiUrl = "api/rest/v6/";
        private const string HostName = "https://api.na1.echosign.com:443/";
        private const string FilePath1 = @"C:\Users\quoc.nguyen\Desktop\dummy.pdf";
        private const string FilePath2 = @"C:\Users\quoc.nguyen\Desktop\Hello world.pdf";
        private const string TestEmail = "quoc.nguyen@mailinator.com";
        private const string AzureFunctionUrl = "https://testadobeesignwebhook.azurewebsites.net/api/Function1?code=EL/8iy2eU6uBR9HWGKdcnIkfYkBjFodGWN3VlBmTSNxvpVEZqgtfUA==";

        private static string _apiAccessPoint;

        static void Main(string[] args)
        {
            try
            {
                RunAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task RunAsync()
        {
            //Get base uri info
            BaseUriInfo uriInfo = await GetBaseUri();
            _apiAccessPoint = uriInfo.ApiAccessPoint;

            //Create Webhook
            WebhookCreationResponse webhookCreationResponse = await CreateWebhook();
            Console.WriteLine("Webhook ID: " + webhookCreationResponse.ID);

            ////Upload document
            TransientDocumentResponse transientDocumentResponse1 = await PostTransientDocument(FilePath1);
            TransientDocumentResponse transientDocumentResponse2 = await PostTransientDocument(FilePath2);
            var docIds = new[] { transientDocumentResponse1.TransientDocumentID, transientDocumentResponse2.TransientDocumentID };

            ////Create agreement and send email
            AgreementCreationResponse agreementCreationResponse = await PostAgreement(docIds);
            Console.WriteLine("Agreement ID: " + agreementCreationResponse.ID);

            await DownloadFile("CBJCHBCAABAAYumJeqRwtbNpk1emzfIpBCdNrw0F55e1");

            //Delete Webhook
            if (webhookCreationResponse.IsSuccess)
            {
                await DeleteWebhook(webhookCreationResponse.ID);
            }
        }

        private static async Task DownloadFile(string agreementId)
        {
            //GET /agreements/{agreementId}/combinedDocument
            HttpClient client = CreateClient(_apiAccessPoint);

            HttpResponseMessage responseMesage = await client.GetAsync($"agreements/{agreementId}/combinedDocument");

            string path = Path.GetFullPath(string.Format(@"C:\Users\quoc.nguyen\Desktop\{0}.pdf", agreementId));
            using (var fs = new FileStream(path, FileMode.CreateNew))
            {
                await responseMesage.Content.CopyToAsync(fs);
            }
        }

        private static async Task DeleteWebhook(string webhookId)
        {
            HttpClient client = CreateClient(_apiAccessPoint);

            HttpResponseMessage responseMesage = await client.DeleteAsync($"webhooks/{webhookId}");
        }

        private static async Task<WebhookCreationResponse> CreateWebhook()
        {
            HttpClient client = CreateClient(_apiAccessPoint);

            WebhookInfo model = new WebhookInfo
            {
                Name = "Webhook 1",
                Scope = StaticData.Scope.User,
                State = "ACTIVE",
                WebhookSubscriptionEvents = new[]
                {
                    //StaticData.Event.AgreementCreated,
                    StaticData.Event.AgreementActionCompleted,
                },
                WebhookUrlInfo = new WebhookUrlInfo { Url = AzureFunctionUrl },
                ApplicationName = "ApplicationName",
                ApplicationDisplayName = "ApplicationDisplayName",
                WebhookConditionalParams = new WebhookConditionalParams
                {
                    WebhookAgreementEvents = new WebhookAgreementEvents
                    {
                        IncludeDetailedInfo = true,
                        //IncludeDocumentsInfo = true,
                        IncludeSignedDocuments = true,
                    }
                }
            };

            string json = JsonConvert.SerializeObject(model);
            HttpResponseMessage responseMesage = await client.PostAsync("webhooks", new StringContent(json, Encoding.UTF8, "application/json"));
            WebhookCreationResponse response = await HandleResponseMessageAsync<WebhookCreationResponse>(responseMesage);

            return response;
        }

        private static async Task<TransientDocumentResponse> PostTransientDocument(string filePath)
        {
            HttpClient client = CreateClient(_apiAccessPoint);
            client.DefaultRequestHeaders.Add("Mime-Type", "application/pdf");

            // we need to send a request with multipart/form-data
            ByteArrayContent byteArrayContent = new ByteArrayContent(File.ReadAllBytes(filePath));
            byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");

            MultipartFormDataContent multiForm = new MultipartFormDataContent
            {
                { new StringContent(Path.GetFileName(filePath)), "File-Name" },
                { byteArrayContent, "File" },
            };

            HttpResponseMessage responseMesage = await client.PostAsync("transientDocuments", multiForm);
            TransientDocumentResponse response = await HandleResponseMessageAsync<TransientDocumentResponse>(responseMesage);

            return response;
        }

        private static async Task<AgreementCreationResponse> PostAgreement(IEnumerable<string> transientDocumentIDs)
        {
            HttpClient client = CreateClient(_apiAccessPoint);

            var fileInfos = transientDocumentIDs.Select(id => new Models.FileInfo { TransientDocumentID = id });

            AgreementInfo model = new AgreementInfo
            {
                FileInfos = fileInfos,
                Name = "Customer Order",
                ParticipantSetsInfo = new[]
                {
                    new ParticipantSetInfo
                    {
                        MemberInfos = new []
                        {
                            new ParticipantInfo { Email = TestEmail },
                        },
                        Order = 1,
                        Role = StaticData.Role.Signer,
                    },
                },
                SignatureType = StaticData.SignatureType.ESign,
                State = StaticData.State.InProgress,
            };

            string json = JsonConvert.SerializeObject(model);
            HttpResponseMessage responseMesage = await client.PostAsync("agreements", new StringContent(json, Encoding.UTF8, "application/json"));
            AgreementCreationResponse response = await HandleResponseMessageAsync<AgreementCreationResponse>(responseMesage);

            return response;
        }

        private static async Task<T> HandleResponseMessageAsync<T>(HttpResponseMessage responseMesage) where T : BaseResponse
        {
            T result = JsonConvert.DeserializeObject<T>(await responseMesage.Content.ReadAsStringAsync());
            result.IsSuccess = responseMesage.IsSuccessStatusCode;

            return result;
        }

        private static async Task<BaseUriInfo> GetBaseUri()
        {
            HttpClient client = CreateClient(HostName);
            HttpResponseMessage responseMesage = await client.GetAsync("baseUris");
            BaseUriInfo response = await HandleResponseMessageAsync<BaseUriInfo>(responseMesage);
            return response;
        }

        private static HttpClient CreateClient(string accessPoint)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri($"{accessPoint}{apiUrl}")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            return client;
        }
    }
}
