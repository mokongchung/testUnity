using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist
{
	public string id { get; set; }
	public List<Question> questions { get; set; }
	public string playlist{ get; set; }
}

public class Playlists
{
	public List<Playlist> playlists { get; set; }
}