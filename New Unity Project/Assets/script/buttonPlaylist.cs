using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonPlaylist : MonoBehaviour
{
	public TextAsset jsonFile;
	private Playlist dataQuiz;
    public void ChangeText()
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        Debug.Log(txt.text);
		
		JSONReader.checkChoosed(txt.text);
        SceneManager.LoadScene("quiz");
    }

}
