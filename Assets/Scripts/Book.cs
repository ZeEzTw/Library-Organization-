using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public string title;
    public string author;
    public int row;
    public bool back;
    public GameObject BackMarker;
    public void ChangeColor(Color color)
    {
        Image bookImage = GetComponentInParent<Image>(); // Obține componenta Image din părinții obiectului curent

        if (bookImage != null)
        {
            Debug.Log("Image component found in parent!"); // Afișează un mesaj dacă găsește componenta Image
            bookImage.color = color; // Schimbă culoarea componentei Image
        }
        else
        {
            Debug.LogWarning("Image component not found in parent!"); // Afișează un avertisment dacă nu găsește componenta Image
        }
    }
    public void BackMark(){
        if (back == false)
        {
            BackMarker.SetActive(true);
        }
        else
        {
            BackMarker.SetActive(false);
        }
    }
    /*public void OnMouseOver()
    {
        SetBoxCollider();
        if (showInfo != null)
        {
            showInfo.ShowInfoText(title, author, row);
        }
        else
        {
            Debug.LogWarning("ShowInfo reference not set!"); // Afișează un avertisment dacă referința la ShowInfo nu este setată
        }
    }
    void SetBoxCollider()
    {
        RectTransform itemRectTransform = this.gameObject.GetComponent<RectTransform>();
        // strech box collider
        BoxCollider2D itemBoxCollider2D =  itemRectTransform.gameObject.GetComponent<BoxCollider2D>();
        if (itemBoxCollider2D != null)
        {
            Image image = itemRectTransform.gameObject.GetComponent<Image>();

			if (image.preserveAspect) {
				
				var originalW = (int)(image.sprite.rect.width);
				var originalH = (int)(image.sprite.rect.height);

				var currentW = image.rectTransform.rect.width;
				var currentH = image.rectTransform.rect.height;

				var ratio = Mathf.Min (currentW / originalW, currentH / originalH);

				var newW = image.sprite.rect.width * ratio;
				var newH = image.sprite.rect.height * ratio;

				itemBoxCollider2D.size = new Vector2 (newW, newH);
			} else {

				itemBoxCollider2D.size = image.rectTransform.rect.size;

			}
        }
    }*/
}
