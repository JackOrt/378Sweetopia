using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballRoll : MonoBehaviour
{
    private AudioSource hitNoise;
    public PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        hitNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(0, 0, 1);
        GetComponent<Rigidbody2D>().velocity = new Vector3(-6f, 0, 0);
    }

    void OnCollisionEnter2D (Collision2D other){
         if(other.gameObject.tag == "Player"){
            Debug.Log("collided!");
            hitNoise.Play();
            player.Damage(5);
            //SceneManager.LoadScene("Lose");
        }
    }

}
