using Assets.Scripts.Model;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.ApiCallers
{
    public class CoverApiCaller
    {
        private static readonly string apiBase = @"https://api.bookrclass.com/index.php?extension=bookrkids-media&action=default&path=";

        public static IEnumerator GetBookCover(string path, Action<Texture2D> callback)
        {
            var url = apiBase + path.Replace("\\", "");
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                if (request.downloadHandler is DownloadHandlerTexture textureHandler)
                {
                    callback(textureHandler.texture);
                }
            }
        }
    }
}
