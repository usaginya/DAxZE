using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace DAxZE.Extension
{
    internal class AppSettings
    {
        public class UpdateInfo
        {
            public bool haveUpdate = false;
            public string newVer = string.Empty;
            public string downloadUrl = string.Empty;
            public string updateMsg = string.Empty;
        }

        public delegate void CheckUpdateDelegate(UpdateInfo haveUpdate);
        private const string defaultUpdateUrl = "https://cdn.jsdelivr.net/gh/usaginya/mkAppUpInfo@master/DAxZE/update.json";
        private readonly string settingFile = "DAxZE.json";
        private dynamic settings;

        public AppSettings()
        {
            settingFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + settingFile;
            LoadSetting();
        }

        /// <summary>
        /// 加载本地配置
        /// </summary>
        /// <returns></returns>
        private bool LoadSetting()
        {
            try
            {
                string json = FileHelper.ReadText(settingFile);
                if (string.IsNullOrWhiteSpace(json))
                { return false; }
                settings = JsonConvert.DeserializeObject<dynamic>(json);
                return true;
            }
            catch { }
            return false;
        }

        /// <summary>
        /// 异步检查更新、更新信息返回到checkDelegate委托方法
        /// </summary>
        /// <param name="version">本程序版本</param>
        /// <param name="checkDelegate">检查结果回调</param>
        /// <returns></returns>
        public async Task CheckUpdate(string version, CheckUpdateDelegate checkDelegate)
        {
            await Task.Run(() =>
          {
              UpdateInfo updateInfo = new UpdateInfo();
              if (settings == null || ((JObject)settings).Count < 1)
              {
                  checkDelegate(updateInfo);
                  return;
              }

              string updateUrl = settings.update;
              if (string.IsNullOrWhiteSpace(updateUrl))
              {
                  updateUrl = defaultUpdateUrl;
              }

              string data = WebRequestHelper.HttpGet(updateUrl);
              updateInfo.downloadUrl = GeneralHelper.FindBetweenString(data, "[dl>", "<dl]").Trim();
              updateInfo.newVer = GeneralHelper.FindBetweenString(data, "[ver>", "<ver]");
              updateInfo.newVer = updateInfo.newVer.Replace(".", string.Empty);
              version = version.Replace(".", string.Empty);
              try
              {
                  if (Convert.ToUInt32(updateInfo.newVer) > Convert.ToUInt32(version) && updateInfo.downloadUrl.Length > 7)
                  {
                      updateInfo.haveUpdate = true;
                      updateInfo.updateMsg = GeneralHelper.FindBetweenString(data, "[msg>", "<msg]");
                  }
              }
              catch { }
              checkDelegate(updateInfo);
          });
        }

        /// <summary>
        /// 取服务器域名列表
        /// </summary>
        public JArray GetServerList()
        {
            JArray serverList = new JArray();
            try
            {
                if (LoadSetting() && ((JObject)settings).ContainsKey("server"))
                {
                    serverList = (JArray)settings.server;
                }
            }
            catch { }
            return serverList;
        }

    }
}
