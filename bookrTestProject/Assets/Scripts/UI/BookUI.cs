using System;
using Assets.Scripts.ApiCallers;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    public Book book = null;

    public Text titleText;
    public Image image;

    bool bookIsSet = false;
    bool imageQuerySent = false;

    private void Start()
    {
        if (book == null)
        {
            titleText.text = "Book is not set";
            image.sprite = null;
        }
    }

    public void SetBook(Book book)
    {
        this.book = book;
        titleText.text = book.bookName;
        image.sprite = null;
        bookIsSet = true;
    }

    bool First = true;

    private void Update()
    {
        if (First)
        {
            First = false;
            return;
        }
        if (bookIsSet && !imageQuerySent)
        {
            if (IsVisible())
            {
                StartCoroutine(CoverApiCaller.GetBookCover(book.imageUrl, SetImage));
                imageQuerySent = true;
                Debug.Log(transform.position.y + " Image Query is sent of " + book.bookName);
            }
        }
    }

    private bool IsVisible()
    {
        return transform.position.y < Screen.height && transform.position.y > 0;
    }

    private void SetImage(Texture2D texture)
    {
        var rect = new Rect(0,0,texture.width, texture.height);
        var pivot = new Vector2(texture.width / 2, texture.height / 2);
        image.sprite = Sprite.Create(texture, rect, pivot);
    }
}
