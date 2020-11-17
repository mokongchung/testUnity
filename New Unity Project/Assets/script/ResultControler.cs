using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultControler : MonoBehaviour
{
    public GameObject review;
    public Text score;
    public Sprite iconTrue;
    public Sprite iconFalse;
    private int Y = 120;

    void Start()
    {
        List<string> TrueAnswer = QuizController.TrueAnswer;
        List<string> UserAnswer = QuizController.UserAnswer;
        score.text = "Correct Answer: "+QuizController.point+@"/"+ TrueAnswer.Count;
        for (int i = 0; i < TrueAnswer.Count; i++)
        {
            spawPreFab(i, UserAnswer[i], TrueAnswer[i]);
        }

    }

    void spawPreFab(int no, string userAnswer, string TrueAnswer)
    {

        GameObject refabObj = Instantiate(review, new Vector3(160, Y, 0), Quaternion.identity);
        refabObj.GetComponentInChildren<Text>().text = userAnswer;
        
        if (userAnswer == TrueAnswer)
        {
            refabObj.GetComponentInChildren<Image>().sprite = iconTrue;
        }
        else
        {
            refabObj.GetComponentInChildren<Image>().sprite = iconFalse;
        }
        refabObj.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        Y -= 65;
    }


}
