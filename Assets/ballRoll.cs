using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballRoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(0, 0, 1);
        GetComponent<Rigidbody2D>().velocity = new Vector3(-6f, 0, 0);
    }

}
