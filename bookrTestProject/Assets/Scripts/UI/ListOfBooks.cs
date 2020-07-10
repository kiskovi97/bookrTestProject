using System.Collections.Generic;
using Assets.Scripts.Model;
using UnityEngine;

public class ListOfBooks : MonoBehaviour
{
    public GameObject bookUIPrefab;

    public int LineCount = 5;

    internal void SetBooks(IEnumerable<Book> books)
    {
        DestroyAllChildren();

        foreach (var book in books)
        {
            var obj = Instantiate(bookUIPrefab, transform);
            var bookUI = obj.GetComponent<BookUI>();
            bookUI.SetBook(book);
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
