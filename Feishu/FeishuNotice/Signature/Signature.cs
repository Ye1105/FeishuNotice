using System.Text;

namespace FeishuNotice.Signature
{
    public static class Signature
    {
        /// <summary>
        /// 自定义机器人签名校验
        /// </summary>
        /// <param name="timestamp">timestamp为距当前时间不超过 1 小时(3600)的时间戳，时间单位s，如：1599360473</param>
        /// <param name="secret">自定义机器人秘钥</param>
        /// <returns>签名 sign</returns>
        public static string SignatureCheck(string timestamp, string secret)
        {
            var signContent = $"{timestamp}\n{secret}";

            byte[] contentByte = Encoding.UTF8.GetBytes(signContent);

            using var hmacsha256 = new HMACSHA256Final(contentByte);

            return Convert.ToBase64String(hmacsha256.HashFinal());
        }



        /// <summary>
        /// 获取当前时间戳，单位 秒(s)
        /// </summary>
        /// <returns></returns>

        public static Int64 GetTimeStamp()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

    }
}