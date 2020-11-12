using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

public class JSONReader
{

	public static List<Playlist> list;
	public static Playlist ListChoosed = null;

    public static List<Playlist> readJson (string json)
    {
		Debug.Log("read json test ");
		
		list = JsonConvert.DeserializeObject<List<Playlist>>(json);


		return list;
    }
	

	public static void checkChoosed(string playlistchoosed){
		foreach (Playlist e in list)
        {
			if(e.playlist == playlistchoosed){
				Debug.Log("here");
				ListChoosed = e;
				return;
			}
			Debug.Log("ko tim thay" +"  "+e.playlist);
		}
	}
}