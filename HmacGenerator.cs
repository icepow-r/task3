using System.Security.Cryptography;
using System.Text;

namespace task3
{
    internal class HmacGenerator
    {
        private readonly string[] args;
        private byte[] randomBytes;
        private HMACSHA256 hmac;
        private byte[] moveBytes;

        public HmacGenerator(string[] args)
        {
            this.args = args;
            CreateHmac();
        }

        private void CreateHmac()
        {
            var random = RandomNumberGenerator.Create();
            randomBytes = new byte[256];
            random.GetBytes(randomBytes);
            hmac = new HMACSHA256(randomBytes);
        }

        public int GetNewMove()
        {
            var move = RandomNumberGenerator.GetInt32(0, args.Length);
            moveBytes = Encoding.Default.GetBytes(args[move]);
            return move;
        }

        public string GetMessage()
        {
            var hash = hmac.ComputeHash(moveBytes);
            var hmacMessage = new StringBuilder();
            foreach (var item in hash)
            {
                hmacMessage.Append(string.Format("{0:x2}", item));
            }
            return hmacMessage.ToString();
        }

        public string GetKey()
        {
            var hmacKey = new StringBuilder();
            foreach (var item in randomBytes)
            {
                hmacKey.Append(string.Format("{0:x2}", item));
            }
            return hmacKey.ToString();
        }

    }
}
