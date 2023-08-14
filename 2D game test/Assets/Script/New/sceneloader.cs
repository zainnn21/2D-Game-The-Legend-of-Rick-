using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("level1", LoadSceneMode.Single);
    }

}
