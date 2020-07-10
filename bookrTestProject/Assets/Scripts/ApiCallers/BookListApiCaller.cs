using Assets.Scripts.Model;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace Assets.Scripts.ApiCallers
{
    public class BookListApiCaller
    {
        private static readonly string apiBase = @"https://bookrlab.com/test/";
        public static IEnumerator GetBooks(Action<IEnumerable<Book>> callback)
        {
            UnityWebRequest request = UnityWebRequest.Get(apiBase);

            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var rootObject = JSON.Parse(request.downloadHandler.text);
                var books = ConvertToBooks(rootObject);
                callback(books);
            }
        }

        private static IEnumerable<Book> ConvertToBooks(JSONNode rootObject)
        {
            var list = new List<Book>();
            foreach (var child in rootObject.Children)
            {
                list.Add(new Book()
                {
                    bookName = child["title"].Value,
                    imageUrl = child["media"].Value,
                });
            }
            return list;
        }
    }
}
