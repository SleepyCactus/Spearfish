using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void DoAThing(string _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
