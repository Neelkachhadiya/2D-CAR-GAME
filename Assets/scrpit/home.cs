using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public GameObject carselectobj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CarSelect(int se)
    {
        PlayerPrefs.SetInt("CarIn",se);
        SceneManager.LoadScene("Play");
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }
    public void Select()
    {
        carselectobj.SetActive(true);
    }
   
    

}
