using System;
using System.Security.Cryptography;
using System.Text;

namespace Jansson.AdventOfCode.DayFive
{
    public class SecurityDoorCodeCracker
    {
        private char[] _result;
        public int Index;

        public string CrackCode(string code)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < 8; i++)
                builder.Append(GetNextChar(code));

            return builder.ToString();
        }

        public string CrackInnerCode(string code)
        {
            _result = new[] { '9', '9', '9', '9', '9', '9', '9', '9' };
            SetChars(code);
            return new string(_result);
        }

        private void SetChars(string code)
        {
            using (var md5 = MD5.Create())
            {
                while (true)
                {
                    var result = md5.ComputeHash(Encoding.ASCII.GetBytes(code + Index));
                    var hashPassword = BitConverter.ToString(result).Replace("-", "");
                    if (hashPassword.StartsWith("00000", StringComparison.CurrentCulture))
                        try
                        {
                            if ((int.Parse(hashPassword[5].ToString()) >= 0) &&
                                (int.Parse(hashPassword[5].ToString()) < 8))
                                if (_result[int.Parse(hashPassword[5].ToString())] == '9')
                                {
                                    _result[int.Parse(hashPassword[5].ToString().ToLower())] =
                                        hashPassword[6].ToString().ToLower()[0];
                                    var isEmpty = false;
                                    foreach (var character in _result)
                                        if (character == '9')
                                            isEmpty = true;
                                    if (!isEmpty)
                                        break;
                                }
                        }
                        catch (Exception)
                        {
                        }

                    Index++;
                }
            }
        }


        private char GetNextChar(string code)
        {
            using (var md5 = MD5.Create())
            {
                while (true)
                {
                    var result = md5.ComputeHash(Encoding.ASCII.GetBytes(code + Index));
                    var hashPassword = BitConverter.ToString(result).Replace("-", "");
                    if (hashPassword.StartsWith("00000", StringComparison.CurrentCulture))
                    {
                        Index++;
                        return hashPassword[5].ToString().ToLower()[0];
                    }

                    Index++;
                }
            }
        }
    }
}