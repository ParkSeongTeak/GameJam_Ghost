using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_SomeThing : MonoBehaviour
{
    public GameObject SomeThing;
    public float speed;
    public float Accelerate;
    int RAND;
    

    // Start is called before the first frame update
    void Start()
    {        
        Destroy(gameObject, 7);
    }
    void FixedUpdate()
    {
        SomeThing.transform.position += new Vector3(Accelerate * -speed * Time.deltaTime, 0, 0);
    }
}
