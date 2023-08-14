using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercontrol : MonoBehaviour
{
  public GameObject gameOverText, restartButton, blood;  

    // Start is called before the first frame update
    void Start()
    {
     gameOverText.SetActive (false);
     restartButton.SetActive (false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OncollisionEnter2D (Collision2D col){
        if (col.gameObject.tag.Equals ("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            Instantiate (blood, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
