using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int _value;

    public AudioClip sound;

    public int Value { get { return _value; } private set { _value = value; } }

    public int Collect()
    {
        return Value;
    }
}
