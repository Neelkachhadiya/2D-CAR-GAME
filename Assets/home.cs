using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    public GameObject puzzelobj, levelobj, homeobj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onContinueClick()
    {
        homeobj.SetActive(false);
        puzzelobj.SetActive(true);
    }
    public void onPuzzelClick()
    {
        homeobj.SetActive(false);
        levelobj.SetActive(true);
    }

}
