using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    public PlayerHealth health;
    public string winSceneName = "SampleScene";
    static int _lastSceneIndex;
    private Scene currentScene;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
         currentScene = SceneManager.GetActiveScene();
 
        
        sceneName = currentScene.name;
    }

    public void ReturnToLastScene() {
        SceneManager.LoadScene(_lastSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName == "Lose"){
            StartCoroutine(waiter2());
        }
        else if(GameObject.FindGameObjectsWithTag("food").Length == 0){
            SceneManager.LoadScene(winSceneName);
        }
        else if(health.currentHealth <= 0){
            _lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Lose");
        }
    }

    IEnumerator waiter2(){
        yield return new WaitForSeconds(4);
        ReturnToLastScene();
    }
}
