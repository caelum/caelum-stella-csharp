using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CaelumStellaCSharp.http
{
    public class ViaCEP
    {
        public ViaCEP()
        {
        }

        public async Task<string> GetEndereco(string cep)
        {
            return await GetStringResponseAsync(string.Format("https://viacep.com.br/ws/{0}/json/", cep));
        }

        private static async Task<string> GetStringResponseAsync(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    return await r.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
