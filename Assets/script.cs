using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    [SerializeField] private string winScene;
    public PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("food").Length == 0){
            SceneManager.LoadScene(winScene);
        }
        else if(health.currentHealth <= 0){
            SceneManager.LoadScene("Lose");
        }
    }
}
