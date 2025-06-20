using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    Renderer rr;
    int carSp;
    float yOffset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CarSpeed",0);
        rr = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        carSp = PlayerPrefs.GetInt("CarSpeed");
        if (carSp == 0)
        {
            yOffset = Time.time * .3f;
            rr.material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));

        }
        else if (carSp == 1)
        {
            yOffset = Time.time * .5f;
            rr.material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));

        }
        else if (carSp == 2)
        {
            yOffset = Time.time * .7f;
            rr.material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));
        }
        else if (carSp == 3)
        {
            yOffset = Time.time * .9f;
            rr.material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));
        }
        else if (carSp == 4)
        {
            yOffset = Time.time * .14f;
            rr.material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));
        }
        else if (carSp == 5)
        {
            yOffset = Time.time * .19f;
            rr.material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));
        }
    }
    
}
