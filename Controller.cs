using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovaExchangeRateChecker.Managers;
using NovaExchangeRateChecker.Managers.CQMobile;
using NovaExchangeRateChecker.Models.CQMobile;
using LoggerLib;
using NovaExchangeRateChecker.Common;

namespace NovaExchangeRateChecker
{
    public class Controller
    {
        private static readonly string LOG_CATEGORY = typeof(Controller).FullName;
        public static DefaultLoggerService loggerService;

        public static List<ExchangeRateModel> ExchangeRateList = new List<ExchangeRateModel>();

        public static ExchangeRateManager ExchangeRateManager = new ExchangeRateManager();
        public static RedisManager RedisManager = new RedisManager();        
        public static ExchangeRateCheckerManager ExchangeRateCheckerManager = new ExchangeRateCheckerManager();

        public void init()
        {
            if(InitLoggerService())
            {
                RedisManager.RedisInitialize();
                ExchangeRateCheckerManager.Start();
            }
        }

        private bool InitLoggerService()
        {
            try
            {
                string logConfig = AppSetting.ServiceFolderPath + LogSetting.LogConfig;
                loggerService = new DefaultLoggerService();
                loggerService.LoggerConfigFile = logConfig;
                loggerService.Start();
                loggerService.Info(LOG_CATEGORY, "Logger Service Started.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public void Done()
        {
            RedisManager.Done();
            DoneLoggerService();
        }

        private void DoneLoggerService()
        {
            try
            {
                loggerService.Info(LOG_CATEGORY, "Application Shutdown.");
                loggerService.Stop();
            }
            catch (Exception ex)
            {
                loggerService.Error(LOG_CATEGORY, "Failed To Stop Logger Service : {0}", ex);
            }
        }
    }
}
