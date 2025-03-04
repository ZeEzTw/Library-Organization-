using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowInfo : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI authorText;
    public TextMeshProUGUI rowText;
    public GameObject infoPanel;
    private static ShowInfo _instance;

    public static ShowInfo Instance { get { return _instance; } }

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

    public void ShowInfoText(string title, string author, int row)
    {
        infoPanel.SetActive(true);
        titleText.text = "Titlu: " + title;
        authorText.text = "Autor: " + author;
        rowText.text = "Rand: " + row.ToString();
    }
    
}

