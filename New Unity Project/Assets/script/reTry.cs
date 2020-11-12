using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class reTry : MonoBehaviour
{
    public void reTryClick()
    {
        SceneManager.LoadScene("welcome_screen");
    }
}
