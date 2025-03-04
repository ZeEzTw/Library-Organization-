using System.Collections;
using UnityEngine;

public class Save : MonoBehaviour
{
    LibraryManager libraryManager;
    void Start()
   {
    libraryManager = LibraryManager.Instance;
   }

    void LoadData()
    {
        BookData[] books = SaveSystem.LoadBooks();
        for (int i = 0; i < books.Length; i++)
        {
            libraryManager.index = books[i].row;
            libraryManager.AddBookByAuthor(books[i].author);
            libraryManager.AddBookByTitle(books[i].title);
            libraryManager.IsComplete();
            if(books[i].back == false){
                libraryManager.AddBookInBack();
            }
        }
    }
    public void SaveData(){
        SaveSystem.SaveBooks(libraryManager);
    }

  
}
