using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

public class welcomeControler : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset jsonFile;
	public Button _buttonPlayList1;
	public Button _buttonPlayList2;
	public Button _buttonPlayList3;
    void Start()
    {
        List<Playlist> list = JSONReader.readJson(jsonFile.text);
		_buttonPlayList1.GetComponentInChildren<Text>().text = list[0].playlist;
		_buttonPlayList2.GetComponentInChildren<Text>().text = list[1].playlist;
		_buttonPlayList3.GetComponentInChildren<Text>().text = list[2].playlist;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
