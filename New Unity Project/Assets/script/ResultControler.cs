using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultControler : MonoBehaviour
{
    public GameObject review;
    public Text score;
    private int Y = 50;
    // Start is called before the first frame update
    void Start()
    {
        List<string> TrueAnswer = QuizController.TrueAnswer;
        List<string> UserAnswer = QuizController.UserAnswer;
        score.text = "score: "+QuizController.point;
        for (int i = 0; i < TrueAnswer.Count; i++)
        {
            spawPreFab(i, UserAnswer[i], TrueAnswer[i]);
        }

    }

    void spawPreFab(int no, string userAnswer, string TrueAnswer)
    {

        GameObject a = Instantiate(review, new Vector3(0, Y, 0), Quaternion.identity);
        Text[] text = a.GetComponentsInChildren<Text>();
        text[0].text = no.ToString();
        text[1].text = userAnswer;
        text[2].text = TrueAnswer;

        a.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        Y -= 57;
    }


}
