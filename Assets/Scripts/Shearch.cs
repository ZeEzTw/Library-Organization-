using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shearch : MonoBehaviour
{
    public TMP_Text buttonText; // Referința către componenta TextMeshPro care este copilul butonului
    int stage = 1;
    Image buttonImage; // Corectarea numelui clasei Image
    public GameObject Search1;
    public GameObject Search2;
    LibraryManager libraryManager;
    public void Start()
    {
        // Obține componenta Image a butonului
        buttonImage = GetComponent<Image>();
        libraryManager = LibraryManager.Instance;
    }

    public void SearchBy()
    {
        if (stage == 1)
        {
            libraryManager.ChangeColorToGray();
            buttonText.text = "Title";
            // Schimbarea culorii textului pentru titlu în TextMeshPro
            buttonImage.color = Color.green; // Schimbarea culorii butonului
            Search1.SetActive(true);
            stage = 2;
        }
        else if (stage == 2)
        {
            buttonText.text = "Author";
            // Schimbarea culorii textului pentru autor în TextMeshPro
            buttonImage.color = Color.green; // Schimbarea culorii butonului
            Search1.SetActive(false);
            Search2.SetActive(true);
    
            stage = 3;
        }
        else if (stage == 3)
        {
            buttonText.text = "Cauta";
            buttonImage.color = new Color(1.0f, 0.5f, 0.0f); // Schimbarea culorii textului pentru căutare în TextMeshPro
            Search2.SetActive(false);
            stage = 1;
            libraryManager.ChangeColorBack();
        }
    }
}
