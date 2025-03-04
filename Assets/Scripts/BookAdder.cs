using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookAdder : MonoBehaviour
{
    public GameObject bookPrefab;
    public Transform bookshelf;
    bool isBookAuthorComplete = false;
    bool isBookTitleComplete = false;
    public Book bookComponent;
    Color bookColor; // Variabilă pentru culoarea cărții
    LibraryManager libraryManager;
    
    void Start()
    {
        bookComponent = bookPrefab.GetComponent<Book>();
        bookColor = bookPrefab.GetComponent<Image>().color;
        libraryManager = LibraryManager.Instance;
    }
    public void InputBookRow()
    {
        bookComponent.row = libraryManager.index;
    }
    public void InputBookAuthor(string author)
    {
        bookComponent.author = author;
        isBookAuthorComplete = true;
        Debug.Log("Author: " + author);
        Debug.Log("Title: " + bookComponent.title);
    }

    public void InputBookTitle(string title)
    {
        bookComponent.title = title;
        isBookTitleComplete = true;
        

    }
    public void AddBook()
    {
        if (isBookAuthorComplete && isBookTitleComplete)
        {
            Debug.Log("Book is complete!");
            bookColor = bookColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);; // Obține o culoare aleatoare pentru cărțile noi
            GameObject newBook = Instantiate(bookPrefab);
            newBook.GetComponent<Image>().color = bookColor; // Setează culoarea cărții noi
            newBook.transform.SetParent(bookshelf); // Setează noul obiect ca fiind copilul raftului
            libraryManager.AddBook(newBook.GetComponent<Book>()); // Adaugă cartea în lista de cărți
            // Resetează starea pentru a putea adăuga noi cărți
            isBookAuthorComplete = false;
            isBookTitleComplete = false;
        }
    }
}
