using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
public class welcomeControler : MonoBehaviour
{
    // Start is called before the first frame update

	public Button _buttonPlayList1;
	public Button _buttonPlayList2;
	public Button _buttonPlayList3;
    void Start()
    {
        var fileContents = File.ReadAllText(Application.streamingAssetsPath + "/coding-test-frontend-unity.json");
        List<Playlist> list = JSONReader.readJson(fileContents.ToString());
		_buttonPlayList1.GetComponentInChildren<Text>().text = list[0].playlist;
		_buttonPlayList2.GetComponentInChildren<Text>().text = list[1].playlist;
		_buttonPlayList3.GetComponentInChildren<Text>().text = list[2].playlist;
    }

   
}
