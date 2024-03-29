﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReproductorMusicaAdmin.API.Entitas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaAdmin.API
{
    public class Api : IDisposable
    {
        private readonly HttpClient client;
        private String jsonRuta = "C:\\Users\\Moha\\source\\repos\\ReproductorMusicaAdmin\\ReproductorMusicaAdmin\\config_doc.json";
        private String url = "";

        /// <summary>
        ///  Creation to the connection to the api that has acces to the Database
        /// </summary>
        public Api()
        {
            string jsonContent = File.ReadAllText(jsonRuta);
            dynamic configData = JObject.Parse(jsonContent);
            url = configData.urlSQL;

            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to do an asyncronous get request and later return the response as a string
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud GET: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// This method performs an HTTP PUT request, handle success or failure, and return the content 
        /// of the response as a string.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="jsonContent"></param>
        /// <returns></returns>
        public async Task<string> PutAsync(string endpoint, string jsonContent)
        {
            try
            {
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud PUT: {ex.Message}");
                throw; // Puedes lanzar una excepción personalizada si lo prefieres
            }
        }

        /// <summary>
        /// Method to retrieve all the information of all songs 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Song>> GetSongs()
        {
            try
            {
                string endpoint = "api/Song";
                string responseJson = await GetAsync(endpoint);

                if (string.IsNullOrEmpty(responseJson))
                {
                    return new List<Song>();
                }

                var songs = JsonConvert.DeserializeObject<List<Song>>(responseJson);
                return songs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during GetSongsFromApi request: {ex.Message}");
                return new List<Song>();
            }
        }

        /// <summary>
        /// Method to retrieve all the information of all songs 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Song>> GetSong(string songuid)
        {
            try
            {
                string endpoint = $"api/Song/{songuid}";
                string responseJson = await GetAsync(endpoint);

                if (string.IsNullOrEmpty(responseJson))
                {
                    return new List<Song>();
                }

                var songs = JsonConvert.DeserializeObject<List<Song>>(responseJson);
                return songs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during GetSong request: {ex.Message}");
                return new List<Song>();
            }
        }

        /// <summary>
        /// NO ESTA VERIFICAT
        /// </summary>

        public async Task<string> AddExtension(String songId, string extension)
        {
            try
            {
                string endpoint = $"api/Song/AddExtension/{songId}/{extension}";
                string responseJson = await PutAsync(endpoint, string.Empty);

                return responseJson;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during AddExtension request: {ex.Message}");
                return string.Empty;
            }
        }
        public async Task<string> AddDuration(string songId, string duration)
        {
            try
            {
                string endpoint = $"api/Song/AddDuration/{songId}/{duration}";
                string responseJson = await PutAsync(endpoint, string.Empty);

                return responseJson;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during AddDuration request: {ex.Message}");
                return string.Empty;
            }
        }
        public async Task<string> UpdateSong(String songuid, Song updatedSong)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(updatedSong);

                // Construct the API endpoint for updating the song
                string endpoint = $"api/Song/{songuid}";

                // Perform the PUT request
                string responseJson = await PutAsync(endpoint, jsonContent);

                return responseJson;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during UpdateSong request: {ex.Message}");
                return string.Empty;
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
