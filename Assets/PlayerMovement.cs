using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource[] sounds;
    private AudioSource dieNoise;
    private AudioSource eatNoise;
    bool grounded;
   
    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        sounds = GetComponents<AudioSource>();
        dieNoise = sounds[0];
        eatNoise = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up") && grounded)
        {
            //grounded = false;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 12, 0);
        }
        else if(Input.GetKey("right"))
        {
            if(gameObject.transform.localScale.x < 0){
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector3(4, 0, 0);
        }
        else if(Input.GetKey("left"))
        {
            if(gameObject.transform.localScale.x > 0){
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);
        
        }
    }

    void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.tag == "terrain"){
            Debug.Log("true");
            grounded = true;
        }
        if(other.gameObject.tag == "enemy"){
            Debug.Log("collided!");
            dieNoise.Play();
            SceneManager.LoadScene("Lose");
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
            Destroy(col.gameObject);
        }
    }
}
