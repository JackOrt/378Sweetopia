using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public Shading foodIcon;
    private AudioSource eatNoise;

    void Start(){
        eatNoise = GetComponent<AudioSource>();
    }

    public void gotEaten (){
        foodIcon.ShadeIn();
        eatNoise.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1.7f);
    }
}