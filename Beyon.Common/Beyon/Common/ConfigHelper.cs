namespace Beyon.Common
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// 配置信息读取类
    /// </summary>
    public class ConfigHelper
    {
        public static string GetAssemblyPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string[] strArray = codeBase.Substring(8, codeBase.Length - 8).Split(new char[] { '/' });
            string str2 = "";
            for (int i = 0; i < (strArray.Length - 1); i++)
            {
                str2 = str2 + strArray[i] + "/";
            }
            return str2;
        }

        public static KeyValueConfigurationCollection GetValueBy(string configFileName)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = GetAssemblyPath() + configFileName
            };
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None).AppSettings.Settings;
        }

        public static string GetValueByKey(string configFileName, string key)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = GetAssemblyPath() + configFileName
            };
            System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            if (!configuration.AppSettings.Settings.AllKeys.Contains<string>(key))
            {
                throw new SettingsPropertyNotFoundException("未找到相应的配置信息，请检查配置文件！");
            }
            return configuration.AppSettings.Settings[key].Value.ToString();
        }
    }
}

