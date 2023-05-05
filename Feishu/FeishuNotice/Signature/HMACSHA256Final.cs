using System.Security.Cryptography;

namespace FeishuNotice.Signature
{

    public class HMACSHA256Final : HMACSHA256
    {
        public HMACSHA256Final(byte[] bytes) : base(bytes)
        {

        }

        public new byte[] HashFinal()
        {
            return base.HashFinal();
        }
    }
}
