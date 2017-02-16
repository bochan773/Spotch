using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotch.Controller
{
    public interface ISessionRepository
    {
        //データを設定
        void SetValue<T>(T value) where T : class;

        //データを取得
        T GetValue<T>() where T : class;

        //初期化
        bool Initilize();

        //セッションデータ読み込み
        Task<bool> LoadAsync();

        //セッションデータ保存
        Task<bool> SaveAsync();

        //端末内にユーザーID保存
        void SaveID(string value);

        //端末内ユーザーID取得
        string LoadID();
    }
}
