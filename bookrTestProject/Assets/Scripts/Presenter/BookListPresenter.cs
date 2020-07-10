using Assets.Scripts.ApiCallers;
using Assets.Scripts.Model;
using System.Collections.Generic;
using UnityEngine;

public class BookListPresenter : MonoBehaviour
{
    public ListOfBooks ListOfBooks;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BookListApiCaller.GetBooks(BooksGet));
    }

    private void BooksGet(IEnumerable<Book> books)
    {
        foreach (var book in books)
        {
            Debug.Log(book.bookName + " : " + book.imageUrl);
        }
        ListOfBooks.SetBooks(books);
    }
}
