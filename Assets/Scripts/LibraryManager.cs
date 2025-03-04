using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryManager : MonoBehaviour
{  
    public List<BookAdder> shelf = new List<BookAdder>();
    public int index;
    private static LibraryManager _instance;
    public static LibraryManager Instance { get { return _instance; } }

    public List<Book> books = new List<Book>();
    List<Book> booksCopy = new List<Book>();
    bool author = false;
    bool title = false;
    string authorText;
    string titleText;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); // Dacă există deja o instanță, distruge această nouă instanță
        }
        else
        {
            _instance = this; // Altfel, aceasta devine instanța singleton
            DontDestroyOnLoad(this.gameObject); // Menține instanța când se trece între scene
        }

    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public void ChangeColorToGray()
    {
        booksCopy = new List<Book>(books); // Copiază lista de cărți
        foreach (Book book in books)
        {
            book.ChangeColor(Color.gray); // Schimbă culoarea tuturor cărților în gri
        }
    }

    public void SearchBookByTitle(string title)
    {
         // Schimbă culoarea tuturor cărților în gri
        foreach (Book book in books)
        {
            if (book.title.Equals(title)) // Verifică dacă titlul cărții corespunde exact titlului căutat
            {
                Debug.Log("Book found: " + book.title);
                book.ChangeColor(Color.green); // Schimbă culoarea cărții în verde doar dacă titlurile coincid exact
            }
        }
    }
    public void SearchByAuthor(string author){
        ChangeColorToGray();
        foreach (Book book in books)
        {
            if (book.author.Equals(author))
            {
                Debug.Log("Book found: " + book.author);
                book.ChangeColor(Color.green);
            }
        }
    }
    public void ChangeColorBack(){
        Debug.Log("Change color back");
        foreach (Book book in books)
        {
            book.ChangeColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        }
        
    }
    public void AddBookByAuthor(string authort){
        authorText = authort;
        //Debug.Log(authorText);
        author = true;
    }
    public void AddBookByTitle(string titlet){
        titleText = titlet;
        //Debug.Log(titleText);
        title = true;
    }
    public void AddBookInBack()
    {
        if (books.Count > 0)
        {
            int lastIndex = books.Count - 1;
            Book lastBook = books[lastIndex].GetComponent<Book>();
            if (lastBook != null)
            {
                lastBook.back = false;
                lastBook.BackMark();
            }
        }
    }
    

    public void IsComplete(){
        Debug.Log("Is complete");
        Debug.Log(author);
        Debug.Log(title);
        if(author && title){
            author = false;
            title = false;
            Debug.Log("Book is complete!");
            BookAdder bookAdder = shelf[index-1].GetComponent<BookAdder>();
            bookAdder.InputBookAuthor(authorText);
            bookAdder.InputBookTitle(titleText);
            bookAdder.InputBookRow();
            bookAdder.AddBook();

        }
    }


}
