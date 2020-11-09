using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 offset = new Vector3(15, 30, 45);

    void Update()
    {
        transform.Rotate(offset * Time.deltaTime);
    }
}
