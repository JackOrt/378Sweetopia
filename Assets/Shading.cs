using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shading : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(.5f, .5f, .5f, 1);

    }

    public void ShadeIn()
    {
        image.color = new Color(1, 1, 1, 1);
    }
}
