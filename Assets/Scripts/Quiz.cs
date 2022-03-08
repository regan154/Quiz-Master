using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI QuestionText;
    [SerializeField] QuestionSO Question;
    void Start()
    {
        QuestionText.text = Question.GetQuestion();
    }
}
