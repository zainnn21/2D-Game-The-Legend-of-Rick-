using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneend : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

}
