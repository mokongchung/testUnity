using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizButton : MonoBehaviour
{
    public GameObject canvas;
    public void answer()
    {
        QuizController scriptName = canvas.GetComponent<QuizController>();
        scriptName.Answer(this.GetComponentInChildren<Text>().text, this.GetComponent<Button>());
    }


}
