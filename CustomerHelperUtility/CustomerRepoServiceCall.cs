using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static CustomerHelperUtility.EnumeratorsEntity;

namespace CustomerHelperUtility
{
    public class CustomerRepoServiceCall
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseURL = "https://customer-repository.dev.cndt.cf";

        public async Task RunAsync(string customerID, string action)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.DefaultRequestHeaders.Accept.Clear();

            //  passing reqired parameters 
            var customer = new WriteProvisionStatusDto
            {
                PipelineId = "1225AB",
                ErrorMessage = "error message"
            };
            var infrastructureAttributesValues = new CustomAttributeDto
            {
                Key = "Key-1",
                Value = "MyKey-1"
            };
            customer.InfrastructureAttributes = new List<CustomAttributeDto>
                {
                    infrastructureAttributesValues
                };

            // Update the product
            switch (action.ToLower())
            {
                case "pending":
                    await UpdateCustomerPending(customer, customerID);
                    break;
                case "inprocess":
                    await UpdateCustomerInProcess(customer, customerID);
                    break;
                case "completed":
                    await UpdateCustomerCompleted(customer, customerID);
                    break;
                case "failed":
                    await UpdateCustomerFailed(customer, customerID);
                    break;
                case "deletecustomer":
                    await DeleteCustomer(customerID);
                    break;
                default:
                    throw new NotSupportedException("No action is known, please provide a correct action.");
            }
        }

        private async Task UpdateCustomerPending(WriteProvisionStatusDto customer, string customerID)
        {
            customer.Status = ProvisionStatuses.Pending;
            string putBody = JsonConvert.SerializeObject(customer);

            HttpResponseMessage response = await client.PutAsync(baseURL + $"/customerapi/Customers/{customerID}/provision",
                new StringContent(putBody, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode == true)
            {
                // HTTP GET
                response = await client.GetAsync(baseURL + $"/customerapi/Customers/{customerID}/");

                var product = JsonConvert.DeserializeObject<ReadCustomerDto>(await response.Content.ReadAsStringAsync());
                Console.WriteLine("{0}\t{1}\t{2}", product.Id, product.ProvisionStatus, response.StatusCode);
            }
        }

        private async Task UpdateCustomerInProcess(WriteProvisionStatusDto customer, string customerID)
        {
            customer.Status = ProvisionStatuses.InProcess;
            string putBody = JsonConvert.SerializeObject(customer);

            HttpResponseMessage response = await client.PutAsync(baseURL + $"/customerapi/Customers/{customerID}/provision",
                new StringContent(putBody, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {

                // HTTP GET
                response = await client.GetAsync(baseURL + $"/customerapi/Customers/{customerID}/");

                var product = JsonConvert.DeserializeObject<ReadCustomerDto>(await response.Content.ReadAsStringAsync());
                Console.WriteLine("{0}\t{1}\t{2}", product.Id, product.ProvisionStatus, response.StatusCode);
            }
        }

        private async Task UpdateCustomerCompleted(WriteProvisionStatusDto customer, string customerID)
        {
            customer.Status = ProvisionStatuses.Completed;
            string putBody = JsonConvert.SerializeObject(customer);

            HttpResponseMessage response = await client.PutAsync(baseURL + $"/customerapi/Customers/{customerID}/provision",
                new StringContent(putBody, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                // HTTP GET
                response = await client.GetAsync(baseURL + $"/customerapi/Customers/{customerID}/");

                var product = JsonConvert.DeserializeObject<ReadCustomerDto>(await response.Content.ReadAsStringAsync());
                Console.WriteLine("{0}\t{1}\t{2}", product.Id, product.ProvisionStatus, response.StatusCode);
            }
        }

        private async Task UpdateCustomerFailed(WriteProvisionStatusDto customer, string customerID)
        {
            customer.Status = ProvisionStatuses.Failed;
            string putBody = JsonConvert.SerializeObject(customer);
            HttpResponseMessage response = await client.PutAsync(baseURL + $"/customerapi/Customers/{customerID}/provision",
                new StringContent(putBody, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode == true)
            {
                // HTTP GET
                response = await client.GetAsync(baseURL + $"/customerapi/Customers/{customerID}/");

                var product = JsonConvert.DeserializeObject<ReadCustomerDto>(await response.Content.ReadAsStringAsync());
                Console.WriteLine("{0}\t{1}\t{2}", product.Id, product.ProvisionStatus, response.StatusCode);
            }
        }
        private async Task DeleteCustomer(string customerID)
        {
            HttpResponseMessage response = await client.DeleteAsync(baseURL + $"/customerapi/Customers/{customerID}");
            Console.WriteLine(response.StatusCode);
        }
    }
}
