using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource eatNoise;
    bool grounded;
    private
   
    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        eatNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && grounded)
        {
            //grounded = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 12);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            if(gameObject.transform.localScale.x < 0){
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(5, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            if(gameObject.transform.localScale.x > 0){
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5, GetComponent<Rigidbody2D>().velocity.y);
        
        }
    }

    void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.tag == "terrain"){
            Debug.Log("true");
            grounded = true;
        }
       
    }
    void OnCollisionExit2D (Collision2D other){
        if(other.gameObject.tag == "terrain"){
            grounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "food"){
            eatNoise.Play();
            col.gameObject.GetComponent<Collected>().gotEaten();
        }
    }
}
