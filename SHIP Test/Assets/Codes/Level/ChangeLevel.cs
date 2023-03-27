using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour
{
    public void LoadAnother_Level(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
}
