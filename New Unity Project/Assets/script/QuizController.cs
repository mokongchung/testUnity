using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class QuizController : MonoBehaviour
{
	Playlist list = null;
	public Image backgroup;
	public AudioSource audioSource;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

    public GameObject imgTrue;
    public GameObject imgFalse;


    private static List<Question> questions;
    private static int numOfQuestion = 0;

    public static List<string> TrueAnswer = new List<string>();
    public static List<string> UserAnswer = new List<string>();
    public static int point=0;
    void Start()
    {
        list = JSONReader.ListChoosed;
        questions = list.questions;
        createquestion();
        UserAnswer = new List<string>();
        TrueAnswer = new List<string>();
        point = 0;
    }

    public void createquestion() {
        List<Choice> choices = questions[numOfQuestion].choices;
        btn1.GetComponentInChildren<Text>().text = choices[0].artist + "\r\n" + choices[0].title;
        btn2.GetComponentInChildren<Text>().text = choices[1].artist + "\r\n" + choices[1].title;
        btn3.GetComponentInChildren<Text>().text = choices[2].artist + "\r\n" + choices[2].title;
        btn4.GetComponentInChildren<Text>().text = choices[3].artist + "\r\n" + choices[3].title;


        StartCoroutine(DownloadImage(questions[numOfQuestion].song.picture));
        //StartCoroutine(GetAudioClip(questions[numOfQuestion].song.sample));
    }

    public void Answer(string answer,Button e)
    {
        if (answer == questions[numOfQuestion].song.artist + "\r\n" + questions[numOfQuestion].song.title)
        {
            
            point += 1;
            imgTrue.transform.position = e.transform.position;
            imgTrue.GetComponent<showTrueFlase>().show();
        }
        else
        {
            imgFalse.transform.position = e.transform.position;
            imgFalse.GetComponent<showTrueFlase>().show();
        }

        TrueAnswer.Add(questions[numOfQuestion].song.artist + "\r\n" + questions[numOfQuestion].song.title);
        UserAnswer.Add(answer);

        numOfQuestion += 1;
        if(numOfQuestion < questions.Count)
        {
            createquestion();
        }
        else
        {

            numOfQuestion = 0;
            SceneManager.LoadScene("result");
        }
        backgroup.enabled = false;
    }


	IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        Debug.LogFormat("downloadxong");
        //backgroup.texture  = ((DownloadHandlerTexture)request.downloadHandler).texture;
        Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
        backgroup.GetComponent<Image>().overrideSprite = sprite;
        backgroup.enabled = true;
    }
	IEnumerator GetAudioClip(string MediaUrl)
    {
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(MediaUrl, AudioType.WAV);
        yield return www.SendWebRequest();
        
        audioSource.clip = DownloadHandlerAudioClip.GetContent(www);
        audioSource.Play();

    }
}
