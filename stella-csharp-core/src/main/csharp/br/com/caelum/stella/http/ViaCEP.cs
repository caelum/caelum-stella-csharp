using Caelum.Stella.CSharp.Http.Exceptions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Caelum.Stella.CSharp.Http
{
    public class ViaCEP
    {
        private readonly HttpClientHandler httpClientHandler;

        public ViaCEP()
        {
        }

        public ViaCEP(HttpClientHandler httpClientHandler)
        {
            this.httpClientHandler = httpClientHandler;
        }

        private IViaCEPClient GetViaCEPClient()
        {
            if (httpClientHandler != null)
            {
                return new ViaCEPClient(httpClientHandler);
            }
            else
            {
                return new ViaCEPClient(new HttpClientHandler());
            }
        }


        public Endereco GetEndereco(CEP cep)
        {
            var json = GetViaCEPClient().GetEndereco(cep, OutputType.Json);
            return TryConvertToEndereco(
                JsonConvert.DeserializeObject<Endereco>(json) as Endereco);
        }

        public async Task<Endereco> GetEnderecoAsync(CEP cep)
        {
            var json = await GetViaCEPClient().GetEnderecoAsync(cep, OutputType.Json);
            return TryConvertToEndereco(
                JsonConvert.DeserializeObject<Endereco>(json) as Endereco);
        }

        private static Endereco TryConvertToEndereco(Endereco endereco)
        {
            if (endereco.IsValid())
            {
                return endereco;
            }
            else
            {
                throw new ZipCodeDoesNotExist();
            }
        }

        public async Task<string> GetEnderecoXmlAsync(CEP cep)
        {
            return await GetViaCEPClient().GetEnderecoAsync(cep, OutputType.Xml);
        }

        public string GetEnderecoXml(CEP cep)
        {
            return GetViaCEPClient().GetEndereco(cep, OutputType.Xml);
        }

        public async Task<string> GetEnderecoJsonAsync(CEP cep)
        {
            return await GetViaCEPClient().GetEnderecoAsync(cep, OutputType.Json);
        }

        public string GetEnderecoJson(CEP cep)
        {
            return GetViaCEPClient().GetEndereco(cep, OutputType.Json);
        }

        public async Task<string> GetEnderecoPipedAsync(CEP cep)
        {
            return await GetViaCEPClient().GetEnderecoAsync(cep, OutputType.Piped);
        }

        public string GetEnderecoPiped(CEP cep)
        {
            return GetViaCEPClient().GetEndereco(cep, OutputType.Piped);
        }

        public async Task<string> GetEnderecoQuertyAsync(CEP cep)
        {
            return await GetViaCEPClient().GetEnderecoAsync(cep, OutputType.Querty);
        }

        public string GetEnderecoQuerty(CEP cep)
        {
            return GetViaCEPClient().GetEndereco(cep, OutputType.Querty);
        }
    }
}
