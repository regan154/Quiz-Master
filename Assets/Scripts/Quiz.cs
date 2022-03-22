using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO Question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int intCorrectAnswerIndex;
    bool blHasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite sprDefaultAnswerSprite;
    [SerializeField] Sprite sprCorrectAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
        //DisplayQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fltFillFraction;
        if (timer.blLoadNextQuestion)
        {
            blHasAnsweredEarly = false;
            GetNextQuestion();
            timer.blLoadNextQuestion = false;
        }
        else if (!blHasAnsweredEarly && !timer.blIsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
            
        }
    }

    public void OnAnswerSelected(int index)
    {
        blHasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == Question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = sprCorrectAnswerSprite;
        }
        else
        {
            intCorrectAnswerIndex = Question.GetCorrectAnswerIndex();
            string correctAnswer = Question.GetAnswer(intCorrectAnswerIndex);
            questionText.text = "Sorry, the corerect answer was;\n " + correctAnswer;
            buttonImage = answerButtons[intCorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = sprCorrectAnswerSprite;
        }
    }
    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }
    void DisplayQuestion()
    {
        questionText.text = Question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = Question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = sprDefaultAnswerSprite;
        }
    }
}
