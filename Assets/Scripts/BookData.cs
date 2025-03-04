using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BookData
{
    public string title;
    public string author;
    public int row; 
    public bool back;
    public BookData (Book book)
    {
        title = book.title;
        author = book.author;
        row = book.row;
        back = book.back;
    }
}
