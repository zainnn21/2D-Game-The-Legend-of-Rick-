using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour   
{
    public static AudioClip hit, death, attack, step, select;
    static AudioSource audiosrc;

        // Start is called before the first frame update
        void Start()
    {
        hit = Resources.Load<AudioClip>("hit");
        death = Resources.Load<AudioClip>("death");
        attack = Resources.Load<AudioClip>("attack");
        step = Resources.Load<AudioClip>("step");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Playsound (string clip)
    {
        switch (clip)
        {
            case "hit":
                audiosrc.PlayOneShot(hit);
                break;
            case "death":
                audiosrc.PlayOneShot(death);
                break;
            case "attack":
                audiosrc.PlayOneShot(attack);
                break;
            case "step":
                audiosrc.PlayOneShot(step);
                break;
        }
    }
}
