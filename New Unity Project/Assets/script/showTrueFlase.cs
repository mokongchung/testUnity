using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showTrueFlase : MonoBehaviour
{
    public GameObject img;
    public float timeLimit = 3f;
    private float time;
    private bool start= false;
    void Update()
    {
        StartCoroutine("CountTime");
    }
    public void show()
    {
        start = true;
        img.SetActive(true);
    }
    IEnumerator CountTime()
    {
        if (start)
        {
            time += Time.deltaTime * 1;

            while (time > timeLimit)
            {
            
                time = 0;
                img.SetActive(false);
                start = false;
            }
            yield return null;
        }
    }
}
