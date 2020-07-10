using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    public Book book = null;

    public Text titleText;
    public Image image;

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
    }
}
