using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D col){
        Debug.Log("On box");
        if(col.gameObject.tag == "Player" && Input.GetKey("space")){
            Debug.Log("Here");
            gameObject.transform.localScale = new Vector3(2, 2, 2);
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 22, 0);
        }
    }
}
