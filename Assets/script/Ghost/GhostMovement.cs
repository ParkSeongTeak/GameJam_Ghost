using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 der;
    // Start is called before the first frame update
    void Start()
    {
        der = Vector3.forward;
    }
    void FixedUpdate()
    {
        transform.Rotate( der * speed);

    }
    public void ChangeDer()
    {
        der = -der;
    }
}
