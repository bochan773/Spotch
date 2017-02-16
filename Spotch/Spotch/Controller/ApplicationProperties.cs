using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spotch.Controller
{
    public class ApplicationProperties : ISessionRepository
    {
        //データを設定
        public void SetValue<T>(T value) where T : class
        {
            Application.Current.Properties[typeof(T).FullName] = value;
            Application.Current.SavePropertiesAsync();
        }

        //データを取得
        public T GetValue<T>() where T : class
        {
            if (!Application.Current.Properties.ContainsKey(typeof(T).FullName))
            {
                return null;
            }
            return Application.Current.Properties[typeof(T).FullName] as T;
        }

        //初期化
        public bool Initilize()
        {
            try
            {
                Application.Current.Properties.Clear();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //セッションデータ読み込み
        public Task<bool> LoadAsync()
        {
            // 読み込み不要
            return Task.FromResult(true);
        }

        //セッションデータ保存
        public Task<bool> SaveAsync()
        {
            // 保存不要
            return Task.FromResult(true);
        }
    
        public void SaveID(string value)
        {
            Application.Current.Properties["userid"] = value;
        }

        public string LoadID()
        {
            if (!Application.Current.Properties.ContainsKey("userid"))
            {
                return null;
            }
            return Application.Current.Properties["userid"] as string;
        }
    }
}
