using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Tutorial Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
