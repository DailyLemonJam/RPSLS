using System;
using System.Text;
using System.Security.Cryptography;

namespace RPSLS
{
    class SecurityGenerator
    {
        private readonly string _key;
        private readonly string _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // any symbols you want here
        private readonly byte[] _hmac;
        private readonly int _move;

        public SecurityGenerator(string[] args)
        {
            _key = GenerateKey(32);
            _move = RandomNumberGenerator.GetInt32(args.Length);
            var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(_key));
            _hmac = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(args[_move]));
        }

        private string GenerateKey(int amount)
        {
            string key = "";
            for (int i = 0; i < amount; i++)
            {
                key += _alpha[RandomNumberGenerator.GetInt32(_alpha.Length)];
            }
            return key;
        }

        public int GetMoveIndex()
        {
            return _move;
        }

        public string GetKey()
        {
            return _key;
        }

        public string GetHMAC()
        {
            return BitConverter.ToString(_hmac).Replace("-", string.Empty);
        }
    }
}
