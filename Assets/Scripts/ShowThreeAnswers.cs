using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowThreeAnswers : MonoBehaviour
{
    [SerializeField] private GameObject rightHand, leftHand;
    [SerializeField] private Canvas questionCanvas;
    [SerializeField] private Button correctAnswer, incorrect1, incorrect2;
    [SerializeField] private Sprite incorrectAnswerSprite, correctAnswerSprite;
    [SerializeField] private TMP_Text incorrectText1, incorrectText2, correctText;

    public static bool hasButtonBeenClicked = false; // Static flag

    // Start is called before the first frame update
    void Start()
    {
        incorrect1.onClick.AddListener(() => OnClickIncorrect(incorrect1, incorrectText1));
        incorrect2.onClick.AddListener(() => OnClickIncorrect(incorrect2, incorrectText2));
        correctAnswer.onClick.AddListener(() => CorrectAnswer(correctText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickIncorrect(Button incorrect, TMP_Text incorrectText)
    {
        /*incorrect.image.sprite = incorrectAnswerSprite;
        correctAnswer.image.sprite = correctAnswerSprite;
        incorrect.gameObject.GetComponent<Button>().enabled = false;

        hasButtonBeenClicked = true; // Set flag to true when a button is clicked

        incorrectText.color = Color.white; // Change the chosen incorrect answer text color to white
        correctText.color = Color.white;   // Change the correct answer text color to white
        DisableAllButtons();

        Invoke(nameof(DestroyCorrectAnswerCanvas), 2f);*/

        if (hasButtonBeenClicked) return; // Prevent further interaction if a button has already been clicked

        incorrect.image.sprite = incorrectAnswerSprite;
        correctAnswer.image.sprite = correctAnswerSprite;
        incorrect.gameObject.GetComponent<Button>().enabled = false;

        hasButtonBeenClicked = true; // Set flag to true when a button is clicked

        incorrectText.color = Color.white; // Change the chosen incorrect answer text color to white
        correctText.color = Color.white;   // Change the correct answer text color to white
        DisableAllButtons();

        Invoke(nameof(DestroyCorrectAnswerCanvas), 2f);
    }


    private void CorrectAnswer(TMP_Text correctText)
    {
        if (hasButtonBeenClicked) return; // Prevent further interaction if a button has already been clicked

        correctAnswer.image.sprite = correctAnswerSprite;
        correctAnswer.gameObject.GetComponent<Button>().enabled = false;
        hasButtonBeenClicked = true; // Set flag to true when a button is clicked

        correctText.color = Color.white; // Change the correct answer text color to white

        DisableAllButtons();
        Invoke(nameof(DestroyCorrectAnswerCanvas), 2f);
    }

    private void DisableAllButtons()
    {
        correctAnswer.interactable = false;
        incorrect1.interactable = false;
        incorrect2.interactable = false;
    }

    public void DestroyCorrectAnswerCanvas()
    {
        questionCanvas.gameObject.SetActive(false);

        rightHand.gameObject.SetActive(true);
        leftHand.gameObject.SetActive(true);

        Debug.Log(ColliderManager.index);

        ColliderManager.index++;

        Debug.Log(ColliderManager.index);

        hasButtonBeenClicked = false;
    }
}
