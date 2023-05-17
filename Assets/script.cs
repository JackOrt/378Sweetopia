using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    public PlayerHealth health;
    public string winSceneName = "SampleScene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("food").Length == 0){
            SceneManager.LoadScene(winSceneName);
        }
        else if(health.currentHealth <= 0){
            SceneManager.LoadScene("Lose");
        }
    }
}
