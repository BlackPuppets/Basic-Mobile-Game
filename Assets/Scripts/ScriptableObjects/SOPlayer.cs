using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SOPlayer")]
public class SOPlayer : ScriptableObject
{
    [Header("Movement Variables")]
    public float speedHorizontal;
    public float speedJump;
    public float runningSpeedHorizontal;

    [Header("MaxSpeed")]
    public float maxSpeedHorizontal;
    public float maxSpeedVertical;
}
