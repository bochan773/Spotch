using System;
using System.Threading.Tasks;

namespace Spotch.Controller
{
    class ApplicationProperties : ISessionRepository
    {
        //データを設定
        public void SetValue<T>(T value) where T : class
        {
            App.Current.Properties[typeof(T).FullName] = value;
        }

        //データを取得
        public T GetValue<T>() where T : class
        {
            if (!App.Current.Properties.ContainsKey(typeof(T).FullName))
            {
                return null;
            }
            return App.Current.Properties[typeof(T).FullName] as T;
        }

        //初期化
        public bool Initilize()
        {
            try
            {
                App.Current.Properties.Clear();
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
    }
}
