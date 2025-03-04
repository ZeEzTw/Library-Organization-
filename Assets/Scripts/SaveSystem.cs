
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveBooks(LibraryManager libraryManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/biblioteca.neagoe";
        FileStream stream = new FileStream(path, FileMode.Create);

        BookData[] books = new BookData[libraryManager.books.Count];
        for (int i = 0; i < libraryManager.books.Count; i++)
        {
            books[i] = new BookData(libraryManager.books[i]);
        }

        formatter.Serialize(stream, books);
        stream.Close();
    }

    public static BookData[] LoadBooks()
    {
        string path = Application.persistentDataPath + "/biblioteca.neagoe";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            BookData[] books = formatter.Deserialize(stream) as BookData[];
            stream.Close();

            return books;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
