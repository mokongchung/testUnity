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
    private List<Sprite> listSprite =new List<Sprite>();
    private List<AudioClip> listAudio = new List<AudioClip>();
     
    public static List<string> TrueAnswer = new List<string>();
    public static List<string> UserAnswer = new List<string>();
    public static int point=0;

    void Start()
    {
        list = JSONReader.ListChoosed;
        questions = list.questions;
        LoadAllSrc();
        StartCoroutine(waitAndCreateQ(4));
        UserAnswer = new List<string>();
        TrueAnswer = new List<string>();
        point = 0;

    }

    public void createquestion() {
        List<Choice> choices = questions[numOfQuestion].choices;
        btn1.GetComponentInChildren<Text>().text = choices[0].title;
        btn2.GetComponentInChildren<Text>().text = choices[1].title;
        btn3.GetComponentInChildren<Text>().text = choices[2].title;
        btn4.GetComponentInChildren<Text>().text = choices[3].title;

        LoadSprite();
        LoadSong();
    }

    public void Answer(string answer,Button e)
    {
        if (answer == questions[numOfQuestion].song.title)
        {
            
            point += 1;

            imgTrue.transform.position = e.transform.position + new Vector3(210,0,0);
            imgTrue.GetComponent<showTrueFlase>().show();
        }
        else
        {
            imgFalse.transform.position = e.transform.position + new Vector3(210, 0, 0);
            imgFalse.GetComponent<showTrueFlase>().show();
        }

        TrueAnswer.Add( questions[numOfQuestion].song.title);
        UserAnswer.Add(answer);

        numOfQuestion += 1;
        if(numOfQuestion < questions.Count)
        {
            StartCoroutine(waitAndCreateQ(1));
        }
        else
        {
            numOfQuestion = 0;
            SceneManager.LoadScene("result");
        }

    }

    void LoadAllSrc()
    {
        for( int i =0; i < questions.Count; i++)
        {
            StartCoroutine(DownloadImage(questions[i].song.picture));
            StartCoroutine(GetAudioClip(questions[i].song.sample));
        }
    }

	IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {

        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            listSprite.Add(sprite);
        }
    }

    void LoadSprite()
    {
        Sprite sprite = listSprite[numOfQuestion];
        if (sprite != null)
        {
            backgroup.GetComponent<Image>().overrideSprite = sprite;
            backgroup.enabled = true;
        }
        else
        {
            Debug.Log("Error when loading image from url ");
        }
    }
	IEnumerator GetAudioClip(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(MediaUrl, AudioType.WAV);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {

        }
        else
        {
            listAudio.Add( DownloadHandlerAudioClip.GetContent(request));
        }


    }
    void LoadSong()
    {

        AudioClip audioClip = listAudio[numOfQuestion];
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Error when loading song from url ");
        }
    }
    IEnumerator waitAndCreateQ(float time)
    {
        
        btn1.GetComponent<Button>().enabled = false;
        btn2.GetComponent<Button>().enabled = false;
        btn3.GetComponent<Button>().enabled = false;
        btn4.GetComponent<Button>().enabled = false;
        //Wait for 4 seconds
        yield return new WaitForSeconds(time);
        btn1.GetComponent<Button>().enabled = true;
        btn2.GetComponent<Button>().enabled = true;
        btn3.GetComponent<Button>().enabled = true;
        btn4.GetComponent<Button>().enabled = true;
        createquestion();
    }

}
