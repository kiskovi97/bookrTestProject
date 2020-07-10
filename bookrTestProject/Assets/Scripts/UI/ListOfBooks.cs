using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Model;
using UnityEngine;

public class ListOfBooks : MonoBehaviour
{
    public List<BookUI> bookUIList = new List<BookUI>();

    public GameObject Line;

    public GameObject bookUIPrefab;

    public int LineCount = 5;

    internal void SetBooks(IEnumerable<Book> books)
    {
        DestroyAllChildren();

        int count = 0;
        var currentLine = Instantiate(Line, transform);
        foreach (var book in books)
        {
            if (count != 0 && count % LineCount == 0)
            {
                currentLine = Instantiate(Line, transform);
            }
            var obj = Instantiate(bookUIPrefab, currentLine.transform);
            var bookUI = obj.GetComponent<BookUI>();
            bookUI.SetBook(book);
            bookUIList.Add(bookUI);
            count++;
        }
    }

    private void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
