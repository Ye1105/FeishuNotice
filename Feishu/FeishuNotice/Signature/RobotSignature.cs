namespace FeishuNotice.Signature
{
    public class RobotSignature
    {
        /// <summary>
        /// 加密后的返回值
        /// </summary>
        private readonly string _sign;

        /// <summary>
        /// 时间戳
        /// </summary>
        private readonly string _timestamp;

        /// <summary>
        /// 签名安全校验的开关
        /// </summary>
        private readonly bool _status = false;


        private static RobotSignature? instance;

        private RobotSignature(string sign, string timestamp, bool status)
        {
            _sign = sign;
            _timestamp = timestamp;
            _status = status;
        }


        /// <summary>
        /// 全局配置自定义机器人安全设置签名校验
        /// </summary>
        /// <param name="sign">签名</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="status">true 开启签名认证，false 关闭，配置完成后默认开启</param>
        /// <returns></returns>
        public static RobotSignature Configure(string sign, string timestamp, bool status = true)
        {
            instance ??= new RobotSignature(sign, timestamp, status);
            return instance;
        }

        /// <summary>
        /// 安全校验的开启或关闭状态
        /// </summary>
        /// <returns></returns>
        public static bool Status()
        {
            return instance != null && instance._status;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <returns></returns>
        public static string Sign()
        {
            return instance == null ? string.Empty : instance._sign;
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        public static string TimeStamp()
        {
            return instance == null ? string.Empty : instance._timestamp;
        }
    }
}
