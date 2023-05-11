using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    public PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("food").Length == 0){
            SceneManager.LoadScene("Win");
        }
        if(health.currentHealth <= 0){
            SceneManager.LoadScene("Lose");
        }
    }
}
