using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballRoll : MonoBehaviour
{
    private AudioSource hitNoise;
    public PlayerHealth player;
    public int damage = 5;
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

void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Player")) {
        //Debug.Log("collided!");
        hitNoise.Play();
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        playerHealth.Damage(damage);
        StartCoroutine(waitToHit());
        //SceneManager.LoadScene("Lose");
    }
}

     IEnumerator waitToHit()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.2f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}


