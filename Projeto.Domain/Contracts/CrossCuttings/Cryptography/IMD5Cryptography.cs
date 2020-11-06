using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Contracts.CrossCuttings.Cryptography
{
    public interface IMD5Cryptography
    {
        string Encrypt(string value);
    }
}
