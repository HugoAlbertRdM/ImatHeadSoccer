using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayer", menuName = "Player")]

public class Player : ScriptableObject
{
    public GameObject footballPlayer;
    public Sprite image;
    public string name;
    public float jumpingForce;
    public float moveSpeed;
    public float shootForce;
}
