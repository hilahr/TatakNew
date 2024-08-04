using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!ShowFirstQuestion.hasButtonBeenClicked) // Check if any button has been clicked
        {
            theText.color = Color.white; // Change to hover color
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!ShowFirstQuestion.hasButtonBeenClicked) // Check if any button has been clicked
        {
            theText.color = Color.black; // Revert to original color
        }
    }
}
