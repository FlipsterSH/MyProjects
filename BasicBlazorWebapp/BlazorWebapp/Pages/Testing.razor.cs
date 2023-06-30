using BlazorWebapp.Core;
using System.Text;
using System.Text.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWebapp.Pages
{
    public class Testing1
    {
        private readonly HttpClient _client;
        public string Name = "test";

        public Testing1()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://data.ssb.no/api/v0/no/table/");
        }

        public async Task<string> MakeApiCall()
        {
            try
            {
                ApiRequest request = new ApiRequest
                {
                    query = new List<Query>
    {
        new Query
        {
            code = "Region",
            selection = new Selection
            {
                filter = "item",
                values = new List<string> { "002" }
            }
        },
        new Query
        {
            code = "Boligtype",
            selection = new Selection
            {
                filter = "item",
                values = new List<string> { "01" }
            }
        },
        new Query
        {
            code = "ContentsCode",
            selection = new Selection
            {
                filter = "item",
                values = new List<string> { "Boligindeks" }
            }
        },
        new Query
        {
            code = "Tid",
            selection = new Selection
            {
                filter = "item",
                values = new List<string>
                {
                    "2004K1", "2004K2", "2004K3", "2004K4", "2005K1", "2005K2", "2005K3",
                    "2005K4", "2006K1", "2006K2", "2006K3", "2006K4", "2007K1", "2007K2",
                    "2007K3", "2007K4", "2008K1", "2008K2", "2008K3", "2008K4", "2009K1",
                    "2009K2", "2009K3", "2009K4", "2010K1", "2010K2", "2010K3", "2010K4",
                    "2011K1", "2011K2", "2011K3", "2011K4", "2012K1", "2012K2", "2012K3",
                    "2012K4", "2013K1", "2013K2", "2013K3", "2013K4", "2014K1", "2014K2",
                    "2014K3", "2014K4", "2015K1", "2015K2", "2015K3", "2015K4", "2016K1",
                    "2016K2", "2016K3", "2016K4", "2017K1", "2017K2", "2017K3", "2017K4",
                    "2018K1", "2018K2", "2018K3", "2018K4", "2019K1", "2019K2", "2019K3",
                    "2019K4", "2020K1", "2020K2", "2020K3", "2020K4", "2021K1", "2021K2",
                    "2021K3", "2021K4", "2022K1", "2022K2", "2022K3", "2022K4", "2023K1"
                }
            }
        }
    },
                    response = new Response
                    {
                        format = "json-stat2"
                    }
                };


                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("07221/", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return null;
        }
    }
}
