using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public UserService( IHttpClientFactory httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<User>> GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v2/users");

            var client = _httpClient.CreateClient("auth0");

            var httpResponse = await client.SendAsync(request);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            var contentStream = await httpResponse.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(contentStream);
            using var jsonReader = new JsonTextReader(streamReader);

            var serializer = new JsonSerializer();

            try
            {
                return serializer.Deserialize<List<User>>(jsonReader);
            }
            catch (JsonReaderException ex)
            {
                throw new Exception("Get users error", ex);
            }
        }
    }
}