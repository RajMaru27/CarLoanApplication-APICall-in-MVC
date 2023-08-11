using CarLoanApplication.Models;
using CarLoanApplication.Models.APIResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace CarLoanApplication.Controllers
{
    public class CarLoanController : Controller
    {
        // GET: CarLoan
        public ActionResult Index()
        {
            var details = new CarLoanApp();

            return View(details);
        }

        [HttpPost]
        public ActionResult Add(CarLoanApp app)
        {
            var RequestAPI = app;
            string APIResponse = string.Empty;
            HttpResponseMessage APIResponseMessage = new HttpResponseMessage();
            // var ReturnResponse = (T)Activator.CreateInstance(typeof(T));
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                //    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                clientHandler.Proxy = null;
                var httpClientHandler = new HttpClientHandler() { Proxy = null };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/Add");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    ByteArrayContent ByteContent = null;
                    if (RequestAPI != null)
                    {
                        var ContentBody = JsonConvert.SerializeObject(RequestAPI);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(ContentBody);
                        ByteContent = new ByteArrayContent(buffer);
                        ByteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }

                    APIResponseMessage = client.PostAsync("https://localhost:7268/api/CarLoanApplicationAPI/Add", ByteContent).Result;


                    APIResponse = APIResponseMessage.Content.ReadAsStringAsync().Result;
                    var respo = JsonConvert.DeserializeObject<Models.APIResponse.AddFormResponse>(APIResponse);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            ListResponse listResponse = new ListResponse();
            string ApiResponse = string.Empty;
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.Proxy = null;
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/ApplicantList");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;



                    httpResponse = client.GetAsync("https://localhost:7268/api/CarLoanApplicationAPI/ApplicantList").Result;
                    ApiResponse = httpResponse.Content.ReadAsStringAsync().Result;
                    listResponse = JsonConvert.DeserializeObject<Models.APIResponse.ListResponse>(ApiResponse);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return View(listResponse);
        }

        public ActionResult Details(string LoanId)
        {
            var RequestAPI = LoanId;
            string ApiResponse = string.Empty;
            HttpResponseMessage APIResponseMessage = new HttpResponseMessage();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.Proxy = null;
                var httpClientHandler = new HttpClientHandler() { Proxy = null };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/Details?LoanId=" + LoanId);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    ByteArrayContent ByteContent = null;
                    if (RequestAPI != null)
                    {
                        var ContentBody = JsonConvert.SerializeObject(RequestAPI);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(ContentBody);
                        ByteContent = new ByteArrayContent(buffer);
                        ByteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }

                    APIResponseMessage = client.PostAsync("https://localhost:7268/api/CarLoanApplicationAPI/Details?LoanId=" + LoanId, ByteContent).Result;
                    ApiResponse = APIResponseMessage.Content.ReadAsStringAsync().Result;
                    var respo = JsonConvert.DeserializeObject<Models.APIResponse.DetailApiResponse>(ApiResponse);

                    
                    return View(respo);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Update(DetailApiResponse request)
        {
            APIUpdateRequest aPIUpdate = new APIUpdateRequest();
            aPIUpdate.updatePersonadetail = new APIUpdateRequest.UpdatePersonalDetail
            {
                loanId = request.data.result.loanId,
                firstName = request.data.result.firstName,
                lastName = request.data.result.lastName,
                birthDate = request.data.result.birthDate,
                maritalStatus = request.data.result.maritalStatus,
                email = request.data.result.email,
                phoneNumber = request.data.result.phoneNumber,
                emergencyContactNumber = request.data.result.emergencyContactNumber,
                driversLicenseNumber = request.data.result.driversLicenseNumber
            };
            aPIUpdate.updateAddressdetail = new APIUpdateRequest.UpdateAddressDetail
            {
                addressLine1 = request.data.result.addressLine1,
                addressLine2 = request.data.result.addressLine2,
                city = request.data.result.city,
                state = request.data.result.state,
                postalCode = request.data.result.postalCode
            };
            aPIUpdate.updateFinancialdetail = new APIUpdateRequest.UpdateFinancialDetail
            {
                bankName = request.data.result.bankName,
                branch = request.data.result.branch,
                accountType = request.data.result.accountType,
                accountNumber = request.data.result.accountNumber,
                ownOrRent = request.data.result.ownOrRent,
                currentLoan = request.data.result.currentLoan,
                workingStatus = request.data.result.workingStatus,
                monthlyIncome = request.data.result.monthlyIncome
            };
            aPIUpdate.updateVehicaldetail = new APIUpdateRequest.UpdateVehicalDetail
            {
                makeAndModel = request.data.result.makeAndModel,
                variant = request.data.result.variant,
                registeredDate = request.data.result.registeredDate,
                mileage = request.data.result.mileage,
                insurance = request.data.result.insurance,
                registrationNumber = request.data.result.registrationNumber,
                nEWorSECONDHAND = request.data.result.nEWorSECONDHAND,
                hpi = request.data.result.hpi,
                fullPrice = request.data.result.fullPrice
            };
            aPIUpdate.updateRequestedloandetail = new APIUpdateRequest.UpdateRequestedLoanDetail
            {
                carType = request.data.result.carType,
                loanAmount = request.data.result.loanAmount,
                terms = request.data.result.terms,
                prefferedPayment = request.data.result.prefferedPayment,
                coSigner = request.data.result.coSigner,
                coSignerName = request.data.result.coSignerName,
                coSignerPhoneNo = request.data.result.coSignerPhoneNo
            };

            var RequestApi = aPIUpdate;
            string ApiResponse = string.Empty;
            HttpResponseMessage APIResponseMessage = new HttpResponseMessage();
            try
            {
                HttpClientHandler ClientHandler = new HttpClientHandler();
                ClientHandler.Proxy = null;
                var httpClientHandler = new HttpClientHandler() { Proxy = null };
                using (HttpClient Client = new HttpClient(httpClientHandler))
                {
                    Client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/Update");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    ByteArrayContent bytecontent = null;
                    if (RequestApi != null)
                    {
                        var ContentBody = JsonConvert.SerializeObject(RequestApi);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(ContentBody);
                        bytecontent = new ByteArrayContent(buffer);
                        bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }

                    APIResponseMessage = Client.PutAsync("https://localhost:7268/api/CarLoanApplicationAPI/Update", bytecontent).Result;

                    ApiResponse = APIResponseMessage.Content.ReadAsStringAsync().Result;
                    var respo = JsonConvert.DeserializeObject<Models.APIResponse.UpdateApiResponse>(ApiResponse);

                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return RedirectToAction("List");
        }

        public ActionResult InActive(string LoanId)
        {
            ActivityStatusRequest StatusId = new ActivityStatusRequest();
            StatusId.LoanId = LoanId;

            var requestApi = StatusId;
            string ApiResponse = string.Empty;
            HttpResponseMessage APIResponseMessage = new HttpResponseMessage();

            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.Proxy = null;
                var httpClientHandler = new HttpClientHandler() { Proxy = null };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/InActive");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    ByteArrayContent ByteContent = null;
                    if (requestApi != null)
                    {
                        var ContentBody = JsonConvert.SerializeObject(requestApi);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(ContentBody);
                        ByteContent = new ByteArrayContent(buffer);
                        ByteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }

                    APIResponseMessage = client.PostAsync("https://localhost:7268/api/CarLoanApplicationAPI/InActive", ByteContent).Result;
                    ApiResponse = APIResponseMessage.Content.ReadAsStringAsync().Result;
                    var respo = JsonConvert.DeserializeObject<Models.APIResponse.ActivityStatusResponse>(ApiResponse);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return RedirectToAction("List");
        }

        public ActionResult Active(string LoanId)
        {
            ActivityStatusRequest StatusId = new ActivityStatusRequest();
            StatusId.LoanId = LoanId;

            var requestApi = StatusId;
            string ApiResponse = string.Empty;
            HttpResponseMessage APIResponseMessage = new HttpResponseMessage();

            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.Proxy = null;
                var httpClientHandler = new HttpClientHandler() { Proxy = null };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/Active");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    ByteArrayContent ByteContent = null;
                    if (requestApi != null)
                    {
                        var ContentBody = JsonConvert.SerializeObject(requestApi);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(ContentBody);
                        ByteContent = new ByteArrayContent(buffer);
                        ByteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }

                    APIResponseMessage = client.PutAsync("https://localhost:7268/api/CarLoanApplicationAPI/Active", ByteContent).Result;
                    ApiResponse = APIResponseMessage.Content.ReadAsStringAsync().Result;
                    var respo = JsonConvert.DeserializeObject<Models.APIResponse.ActivityStatusResponse>(ApiResponse);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return RedirectToAction("List");
        }

        public ActionResult SearchList(string search)
        {
            ListResponse listResponse = new ListResponse();
            listResponse.loanApplicantLists = new List<ListApirequest>();
            ActiveListDetails request = new ActiveListDetails();
            request.data = search;

            var requestApi = request;
            string ApiResponse = string.Empty;
            HttpResponseMessage APIResponseMessage = new HttpResponseMessage();

            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.Proxy = null;
                var httpClientHandler = new HttpClientHandler() { Proxy = null };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/ActivityList");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    ByteArrayContent ByteContent = null;
                    if (requestApi != null)
                    {
                        var ContentBody = JsonConvert.SerializeObject(requestApi);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(ContentBody);
                        ByteContent = new ByteArrayContent(buffer);
                        ByteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }

                    APIResponseMessage = client.PostAsync("https://localhost:7268/api/CarLoanApplicationAPI/ActivityList", ByteContent).Result;
                    ApiResponse = APIResponseMessage.Content.ReadAsStringAsync().Result;
                    var respo = JsonConvert.DeserializeObject<Models.APIResponse.ActiveListResponse>(ApiResponse);

                    foreach (var data in respo.data)
                    {
                        listResponse.loanApplicantLists.Add(new ListApirequest
                        {
                            loanId = data.loanId,
                            email = data.email,
                            firstName = data.firstName,
                            lastName = data.lastName,
                            birthDate = data.birthDate,
                            maritalStatus = data.maritalStatus,
                            loanType = data.loanType,
                            loanAmount = data.loanAmount,
                            status = data.activityStatus

                        });
                        if (data.activityStatus == true)
                        {
                            return View("List", listResponse);
                        }
                        else
                        {
                            return View("InActiveList", listResponse);
                        }
                    }                 
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return RedirectToAction("List");
        }

        public ActionResult InActiveList()
        {
            ListResponse listResponse = new ListResponse();
            string ApiResponse = string.Empty;
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.Proxy = null;
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/InActiveListOnly");
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;



                    httpResponse = client.GetAsync("https://localhost:7268/api/CarLoanApplicationAPI/InActiveListOnly").Result;
                    ApiResponse = httpResponse.Content.ReadAsStringAsync().Result;
                    listResponse = JsonConvert.DeserializeObject<Models.APIResponse.ListResponse>(ApiResponse);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return View(listResponse);
        }
        //public static void CallAPI(CarLoanApp RequestAPI)
        //{
        //    string APIResponse = string.Empty;
        //    HttpResponseMessage APIResponseMessage = new HttpResponseMessage();
        //    // var ReturnResponse = (T)Activator.CreateInstance(typeof(T));
        //    try
        //    {
        //        HttpClientHandler clientHandler = new HttpClientHandler();
        //        //    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        //        clientHandler.Proxy = null;
        //        var httpClientHandler = new HttpClientHandler() { Proxy = null };
        //        using (HttpClient client = new HttpClient(clientHandler))
        //        {
        //            client.BaseAddress = new Uri("https://localhost:7268/api/CarLoanApplicationAPI/Add"); // API Url
        //            //if (RequestAPI.QuerryStringParameters != null && RequestAPI.QuerryStringParameters.Count > 0)
        //            //{
        //            //    RequestAPI.EndPoint += "?"; //string.Format(RequestAPI.EndPoint + "?{0}", HttpUtility.UrlEncode(string.Join("&", RequestAPI.QuerryStringParameters.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)))));
        //            //    int QueryCounter = 0;
        //            //    foreach (var queries in RequestAPI.QuerryStringParameters)
        //            //    {
        //            //        if (QueryCounter > 0)
        //            //        {
        //            //            RequestAPI.EndPoint += "&";
        //            //        }
        //            //        RequestAPI.EndPoint += queries.Key + "=" + HttpUtility.UrlEncode(queries.Value);
        //            //        QueryCounter++;
        //            //    }
        //            //}
        //            //if (RequestAPI.OAuths != null && RequestAPI.OAuths.Count > 0)
        //            //{
        //            //    foreach (var oauth in RequestAPI.OAuths)
        //            //    {
        //            //        client.DefaultRequestHeaders.Add(oauth.Key, oauth.Value);
        //            //    }
        //            //}
        //            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //            if (RequestAPI.RequestType.ToLower() != "get" && RequestAPI.RequestType.ToLower() != "delete")
        //            {
        //                ByteArrayContent ByteContent = null;
        //                if (RequestAPI.RequestBody != null)
        //                {
        //                    var ContentBody = JsonConvert.SerializeObject(RequestAPI.RequestBody);
        //                    var buffer = System.Text.Encoding.UTF8.GetBytes(ContentBody);
        //                    ByteContent = new ByteArrayContent(buffer);
        //                    ByteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //                }
        //                if (RequestAPI.RequestType.ToLower() == "patch")
        //                {
        //                    var method = new HttpMethod("PATCH");

        //                    var request = new HttpRequestMessage(method, RequestAPI.EndPoint)
        //                    {
        //                        Content = ByteContent
        //                    };
        //                    APIResponseMessage = client.SendAsync(request).Result;
        //                }
        //                else
        //                {
        //                    APIResponseMessage = client.PostAsync(RequestAPI.EndPoint, ByteContent).Result;
        //                }
        //            }
        //            else if (RequestAPI.RequestType.ToLower() == "get")
        //            {
        //                APIResponseMessage = client.GetAsync(RequestAPI.EndPoint).Result;
        //            }
        //            else if (RequestAPI.RequestType.ToLower() == "delete")
        //            {
        //                APIResponseMessage = client.DeleteAsync(RequestAPI.EndPoint).Result;
        //            }

        //            if (APIResponseMessage == null || (APIResponseMessage.StatusCode != HttpStatusCode.OK && APIResponseMessage.StatusCode != HttpStatusCode.Created && APIResponseMessage.StatusCode != HttpStatusCode.NoContent))
        //            {
        //                throw new Exception("Invalid Response from " + RequestAPI.APIType + " API");
        //            }
        //            APIResponse = APIResponseMessage.Content.ReadAsStringAsync().Result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //}
    }
}