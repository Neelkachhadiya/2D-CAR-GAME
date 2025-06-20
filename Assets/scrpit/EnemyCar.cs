using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    int carSp=0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt ("CarSpeed",0);

    }

    // Update is called once per frame
    void Update()
    {
        carSp = PlayerPrefs.GetInt("CarSpeed");
        if (carSp == 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.03f);
        }
        else if (carSp == 1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.05f);
        }
        else if (carSp == 2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.07f);
        }
        else if (carSp == 3)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.10f);
        }
        else if (carSp == 4)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.15f);
        }
        else if (carSp == 5)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.20f);
        }

    }
}
