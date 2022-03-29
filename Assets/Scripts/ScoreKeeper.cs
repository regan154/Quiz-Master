using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int intCorrectAnswers = 0;
    int intQuestionsSeen = 0;

    public int intGetCorrectAnswers()
    {
        return intCorrectAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        intCorrectAnswers++;
    }

    public int GetQuestionSeen()
    {
        return intQuestionsSeen;
    }

    public void IncrementQuestionsSeen()
    {
        intQuestionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(intCorrectAnswers / (float)intQuestionsSeen * 100); 
    }
}
