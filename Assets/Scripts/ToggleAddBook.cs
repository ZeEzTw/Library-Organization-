using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAddBook : MonoBehaviour
{
    public int index;
    public Sprite Check;
    public Sprite Uncheck;
    public GameObject Title;
    public GameObject Author;
    public GameObject Add;
    public GameObject Back;
    bool check = false;
    LibraryManager libraryManager;

    void Start()
    {
        libraryManager = LibraryManager.Instance;
        if (libraryManager == null)
        {
            Debug.LogError("LibraryManager instance not found!");
        }
    }

    public void ToggleAddBookButton()
    {
        if (check == false)
        {
            check = true;
            this.GetComponent<Image>().sprite = Check;
            if (libraryManager != null)
            {
                libraryManager.index = index;
                Author.SetActive(true);
                Title.SetActive(true);
                Add.SetActive(true);
                Back.SetActive(true);
            }
            else
            {
                Debug.LogError("LibraryManager instance is null!");
            }
        }
        else
        {
            check = false;
            this.GetComponent<Image>().sprite = Uncheck;
            Author.SetActive(false);
            Title.SetActive(false);
            Add.SetActive(false);
            Back.SetActive(false);
        }
    }
}
