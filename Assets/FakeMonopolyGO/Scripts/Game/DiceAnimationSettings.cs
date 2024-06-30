using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceAnimationSettings", menuName = "ScriptableObjects/DiceAnimationSettings")]
public class DiceAnimationSettings : ScriptableObject
{
    public List<GameObject> Dices;
    public Vector3[] FaceRotations;
    public float DropHeight = 5f;
    public float ForwardDistance = 2f;
    public float DropDuration = 0.5f;
    public float RollDuration = 1f;
    public float BounceHeight = 1f;
    public float BounceDuration = 0.3f;
    public float BounceRandomness = 15f;
    public int BounceCount = 5;
}