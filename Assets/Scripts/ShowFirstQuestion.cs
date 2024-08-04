using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowFirstQuestion : MonoBehaviour
{
    [SerializeField] private GameObject rightHand, leftHand;
    [SerializeField] private Canvas questionCanvas;
    [SerializeField] private Button correctAnswer, incorrect1, incorrect2, incorrect3;
    [SerializeField] private Sprite incorrectAnswerSprite, correctAnswerSprite;
    [SerializeField] private TMP_Text incorrectText1, incorrectText2, incorrectText3, correctText;

    public static bool hasButtonBeenClicked = false; // Static flag



    // Start is called before the first frame update
    void Start()
    {
        incorrect1.onClick.AddListener(() => OnClickIncorrect(incorrect1, incorrectText1));
        incorrect2.onClick.AddListener(() => OnClickIncorrect(incorrect2, incorrectText2));
        incorrect3.onClick.AddListener(() => OnClickIncorrect(incorrect3, incorrectText3));

        correctAnswer.onClick.AddListener(() => CorrectAnswer (correctText));
    }

    // Update is called once per frame
    void Update()
    {
        /*if (ColliderManager.index == 1)
        {
            incorrect3.gameObject.SetActive(false);
            incorrectText3.gameObject.SetActive(false);
        }*/
    }

    private void OnClickIncorrect(Button incorrect, TMP_Text incorrectText)
    {
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
        incorrect3.interactable = false;
    }

    public void DestroyCorrectAnswerCanvas()
    {
        //Destroy(questionCanvas);
        questionCanvas.gameObject.SetActive(false);

        rightHand.gameObject.SetActive(true);
        leftHand.gameObject.SetActive(true);

        hasButtonBeenClicked = true; // Set flag to true when a button is clicked

        Debug.Log(ColliderManager.index);

        ColliderManager.index++;

        Debug.Log(ColliderManager.index);

        hasButtonBeenClicked = false;
        Switchhands.GetInstance().isUI= false;

    }
}
