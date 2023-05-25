using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonRising : MonoBehaviour
{
    public float risingSpeed = 1f;

    private void Update()
    {
        transform.Translate(Vector3.up * risingSpeed * Time.deltaTime);
    }
}
