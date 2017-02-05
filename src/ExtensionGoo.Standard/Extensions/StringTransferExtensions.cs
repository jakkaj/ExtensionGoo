using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ExtensionGoo.Standard.Helpers;
using Newtonsoft.Json;

namespace ExtensionGoo.Standard.Extensions
{
    public static class StringTransferExtensions
    {
        public static async Task<TEntityType> GetAndParse<TEntityType>(this string url, IDictionary<string, string> headers = null)
       where TEntityType : class
        {
            var config = HttpConfigHelper.GetJsonConfig(url, null, null, "GET", headers);

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode || result.Result == null)
            {
                return null;
            }

            var des = _deserialise<TEntityType>(result.Result);

            return des;
        }

        public static async Task<string> GetRaw(this string url, IDictionary<string, string> headers = null)

        {
            var config = HttpConfigHelper.GetJsonConfig(url, null, null, "GET", headers);

            var result = await HttpHelper.Transfer(config);

            return result.Result;
        }

        public static async Task<string> Post(this string url, string data, IDictionary<string, string> headers = null)

        {
            var config = HttpConfigHelper.GetJsonConfig(url, data, null, "POST", headers);

            var result = await HttpHelper.Transfer(config);

            return result.Result;
        }

        public static async Task<string> Post(this string url, byte[] data, IDictionary<string, string> headers = null)
        {
            var config = HttpConfigHelper.GetJsonConfig(url, null, data, "POST", headers, "application/octet-stream");

            var result = await HttpHelper.Transfer(config);

            return result.Result;
        }

        public static async Task<TEntityResult> PostAndParse<TEntityResult, TEntitySend>(this string url,
            TEntitySend postObject, string method = "POST", IDictionary<string, string> headers = null)
        where TEntityResult : class
        where TEntitySend : class

        {
            var objSer = postObject.Serialise();

            var config = HttpConfigHelper.GetJsonConfig(url, objSer);

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode)
            {
                return null;
            }

            var des = _deserialise<TEntityResult>(result.Result);

            return des;
        }


        public static async Task<TEntityResult> PostAndParse<TEntityResult>(this string url,
            byte[] data, string method = "POST", IDictionary<string, string> headers = null)
        where TEntityResult : class
        {
            var config = HttpConfigHelper.GetJsonConfig(url, null, data, "POST", headers, "application/octet-stream");

            var result = await HttpHelper.Transfer(config);

            if (!result.IsSuccessCode)
            {
                return null;
            }

            var des = _deserialise<TEntityResult>(result.Result);

            return des;
        }

        private static T _deserialise<T>(string entity) where T : class
        {
            //there is a weird really annoying bug we cannot track that casues json to get an extra } on the end sometimes
            try
            {
                var resultCatch1 = JsonConvert.DeserializeObject<T>(entity);
                return resultCatch1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(entity);
                Debug.WriteLine("JSON Load corrupt: {0}", ex.ToString());
            }

            return null;
        }
    }
}
