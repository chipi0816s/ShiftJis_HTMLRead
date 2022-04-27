//これらを参考にしました
//https://vdlz.xyz/Csharp/Porpose/WebTool/HttpClient/HttpClient_GetWebSite.html
//https://atmarkit.itmedia.co.jp/ait/articles/1501/13/news142.html
//https://qiita.com/sugasaki/items/0639ea9ca07f1ba7a9e0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHTMLService
{
    public class GetHTMLClass
    {

        /// <summary>
        /// HTML取得処理
        /// </summary>
        /// <param name="uri">接続するサイトのURL</param>
        /// <returns></returns>
        public async Task<string> GetAsync(string uri)
        {
            var client = new HttpClient();

            // HttpClientクラスのGetAsyncメソッドを使ってWebページにアクセスする
            HttpResponseMessage res = await client.GetAsync(uri);

            // もしも取得に失敗していたら、GetStringAsyncメソッドのときと同じ例外を投げる
            res.EnsureSuccessStatusCode();

            //shift_jisが使えるようになるおまじない...
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // 文字エンコーディングはシフトJIS固定とする
            Encoding enc = Encoding.GetEncoding("shift_jis");

            // 文字エンコーディングを指定してTextReaderオブジェクトを作り、ストリームから読み取る
            using (var stream = (await res.Content.ReadAsStreamAsync()))
            using (var reader = (new StreamReader(stream, enc, true)) as TextReader)
            {
                return await reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// DLLが正しく使えてるかのテスト用呼び出しメソッド
        /// </summary>
        /// <returns></returns>
        public String DllTestString()
        {
            string dayTime = DateTime.Now.ToString();
            return dayTime + "-- DLLが使えました";
        }
    }
}
