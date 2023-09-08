using System.ComponentModel.Design;

namespace FeishuNotice.Signature
{
    public class RobotSignature
    {

        /// <summary>
        /// 签名安全校验的开关
        /// </summary>
        private readonly bool _status = false;

        /// <summary>
        /// 签名校验秘钥
        /// </summary>
        public readonly string _key;


        private static RobotSignature? instance;

        private RobotSignature(string key, bool status)
        {
            _key = key;
            _status = status;
        }

        /// <summary>
        /// 全局配置自定义机器人安全设置签名校验
        /// </summary>
        /// <param name="key"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static RobotSignature Configure(string key, bool status = true)
        {
            instance ??= new RobotSignature(key, status);
            return instance;
        }

        /// <summary>
        /// Tuple  Item1 :时间戳  Item2: 签名
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string> Encryption()
        {
            if (instance == null || instance._status == false)
            {
                return Tuple.Create("", "");
            }
            else
            {
                var timeStamp = Signature.GetTimeStamp().ToString();
                return Tuple.Create(timeStamp, Signature.SignatureCheck(timeStamp, instance._key));
            }
        }
    }
}
