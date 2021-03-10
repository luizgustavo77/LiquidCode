using System.Security.Cryptography;
using System.Text;

namespace LiquidCode.Helpers
{
    public class Cripto
    {
        private string _chavePrivada { get => _settings.Get("chavePrivada"); }
        private string _chavePublica { get => _settings.Get("chavePublica"); }
        private appSettings _settings { get; set; }

        public Cripto()
        {
            _settings = new appSettings();
            RSACryptoServiceProvider encriptadorRSA = new RSACryptoServiceProvider();
            //_chavePrivada = encriptadorRSA.ToXmlString(includePrivateParameters: true);
            //_chavePublica = encriptadorRSA.ToXmlString(includePrivateParameters: false);
        }

        public byte[] CodificarMensagem(string mensagemOriginal)
        {
            byte[] bytesCifrados;
            ASCIIEncoding conversor = new ASCIIEncoding();
            byte[] mensagemBytes = conversor.GetBytes(mensagemOriginal);
            RSACryptoServiceProvider encriptadorRSA = new RSACryptoServiceProvider();
            encriptadorRSA.FromXmlString(_chavePublica);
            bytesCifrados = encriptadorRSA.Encrypt(mensagemBytes, fOAEP: false);
            return bytesCifrados;
        }

        public string DecodificarMensagem(byte[] bytesCifrados)
        {
            byte[] bytesDecifrados;
            RSACryptoServiceProvider decifradorRSA = new RSACryptoServiceProvider();
            decifradorRSA.FromXmlString(_chavePrivada);
            bytesDecifrados = decifradorRSA.Decrypt(bytesCifrados, fOAEP: false);
            ASCIIEncoding conversor = new ASCIIEncoding();
            return conversor.GetString(bytesDecifrados);
        }
    }
}