using Projeto01.Domain.Contracts.CrossCuttings.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Projeto01.CrossCutting.Cryptography
{
    public class MD5Cryptography : IMD5Cryptography
    {
        public string Encrypt(string value)
        {
            var md5 = new MD5CryptoServiceProvider();

            //criptografar o valor recebido no método para MD5
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            //converter o conteudo da variavel hash em string
            var result = string.Empty;
            foreach (var item in hash)
            {
                result += item.ToString("X2"); //X2 -> hexadecimal
            }

            return result;
        }
    }
}
