using System.Runtime.Serialization;

namespace Caelum.Stella.CSharp.Http
{
    [DataContract]
    public class Endereco
    {
        private readonly string cep;
        [DataMember(Name="cep")]
        public string CEP => cep;

        private readonly string logradouro;
        [DataMember(Name="logradouro")]
        public string Logradouro => logradouro;

        private readonly string complemento;
        [DataMember(Name="complemento")]
        public string Complemento => complemento;

        private readonly string bairro;
        [DataMember(Name="bairro")]
        public string Bairro => bairro;

        private readonly string localidade;
        [DataMember(Name="localidade")]
        public string Localidade => localidade;

        private readonly string uf;
        [DataMember(Name="uf")]
        public string UF => uf;

        private readonly string unidade;
        [DataMember(Name="unidade")]
        public string Unidade => unidade;

        private readonly string ibge;
        [DataMember(Name="ibge")]
        public string IBGE => ibge;

        private readonly string gia;
        [DataMember(Name="gia")]
        public string GIA => gia;

        public Endereco(string cep, string logradouro, string complemento
                        , string bairro, string localidade, string uf
                        , string unidade, string ibge, string gia)
        {
            this.cep = cep;
            this.logradouro = logradouro;
            this.complemento = complemento;
            this.bairro = bairro;
            this.localidade = localidade;
            this.uf = uf;
            this.unidade = unidade;
            this.ibge = ibge;
            this.gia = gia;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(this.cep);
        }
    }
}
