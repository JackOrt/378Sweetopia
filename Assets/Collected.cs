using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public Shading foodIcon;

    public void gotEaten (){
        foodIcon.ShadeIn();
        Destroy(gameObject);
    }
}