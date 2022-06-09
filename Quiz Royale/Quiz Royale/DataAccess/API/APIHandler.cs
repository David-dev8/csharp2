﻿using Quiz_Royale.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class APIHandler
    {
        private const string BASE_URL = "https://localhost:7264/";

        // De Client moet static zijn zodat er niet telkens een nieuwe connectie wordt aangemaakt
        private static HttpClient s_httpClient;

        public APIHandler()
        {
            if(s_httpClient == null)
            {
                InitalizeClient();
            }
        }

        private static void InitalizeClient()
        {
            s_httpClient = new HttpClient();
            s_httpClient.BaseAddress = new Uri(BASE_URL);
        }

        public async Task<ICollection<T>> Fetch<T>(string endpoint)
        {
            return await GetFromAPI<ICollection<T>>(endpoint);
        }

        public async Task<T> Fetch<T>(string endpoint, int id)
        {
            return await GetFromAPI<T>(endpoint + "/" + id);
        }

        public async Task<R> Create<R, T>(string endpoint, T data)
        {
            using (HttpResponseMessage response = await s_httpClient.PostAsync(endpoint, ToJSON<T>(data)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await FromJSON<R>(response);
                }
                else
                {
                    DetermineException(response.StatusCode);
                }
            }
            // Er moet iets worden geretourneerd omdat niet wordt gerkend dat er een exceptie wordt gegooid in de else
            return default(R);
        }

        private async Task<T> GetFromAPI<T>(string endpoint)
        {
            using (HttpResponseMessage response = await s_httpClient.GetAsync(endpoint))
            {
                if(response.IsSuccessStatusCode)
                {
                    return await FromJSON<T>(response);
                }
                else
                {
                    DetermineException(response.StatusCode);
                }
            }
            // Er moet iets worden geretourneerd omdat niet wordt gerkend dat er een exceptie wordt gegooid in de else
            return default(T);
        }

        private async Task<T> FromJSON<T>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json);
        }

        private HttpContent ToJSON<T>(T data)
        {
            string json = JsonSerializer.Serialize<T>(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private void DetermineException(HttpStatusCode statusCode)
        {
            switch((int)statusCode)
            {
                case 400:
                    throw new InvalidDataException();
                case 404:
                    throw new NotFoundException();
                default:
                    throw new InternalErrorException();
            }
        }
    }
}