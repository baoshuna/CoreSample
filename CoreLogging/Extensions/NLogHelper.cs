using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLogging.Extensions
{
    public class NLogHelper
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public static void ErrorLog(Exception ex)
        {
            string errorMsg = $"【异常信息】：{ex.Message}\r\n" +
                $"【异常类型】：{ex.GetType().Name}\r\n" +
                $"【堆栈调用】：{ex.StackTrace}";

            logger.Error(errorMsg);
        }

        public static async Task ErrorLogAsync(Exception ex)
        {
            string errorMsg = $"【异常信息】：{ex.Message}\r\n" +
                $"【异常类型】：{ex.GetType().Name}\r\n" +
                $"【堆栈调用】：{ex.StackTrace}";

            await Task.Run(() => logger.Error(errorMsg));
        }

        public static void InfoLog(string operateMsg)
        {
            string errorMsg = string.Format("【操作信息】：{0} <br>",
                new object[] { operateMsg });

            logger.Info(errorMsg);
        }
    }
}
