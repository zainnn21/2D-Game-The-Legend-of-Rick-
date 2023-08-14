using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStunStateData", menuName = "Data/state Data/Stun State")]

public class D_StuntState : ScriptableObject
{
    public float stuntTime = 3f;

    public float stuntKockbackTime = 0.2f;
    public float stuntKnockbackSpeed = 20f;
    public Vector2 stuntKnockbackAngle;

 
}
