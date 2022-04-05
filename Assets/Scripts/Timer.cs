using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float fltTimeToCompleteQuestion = 15f;
    [SerializeField] float fltTimeToShowCorrectAnswer = 5f;

    public bool blLoadNextQuestion;
    public float fltFillFraction;

    public bool blIsAnsweringQuestion;
    float fltTimerValue;
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        fltTimerValue = 0;
    }

    void UpdateTimer()
    {
        fltTimerValue -= Time.deltaTime;

        if (blIsAnsweringQuestion)
        {
            if(fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToCompleteQuestion;
            }
            else
            {
                blIsAnsweringQuestion = false;
                fltTimerValue = fltTimeToShowCorrectAnswer;
            }
        }
        else
        {
            if (fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToShowCorrectAnswer;
            }
            else
            {
                blIsAnsweringQuestion = true;
                fltTimerValue = fltTimeToCompleteQuestion;
                blLoadNextQuestion = true;
            }
        }
    }
}
