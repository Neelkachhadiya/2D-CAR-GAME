using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    public GameObject winobj, levelobj, puzzelobj;
    public Text completed;
    int levelno;
    // Start is called before the first frame update
    private void OnEnable()
    {
        levelno = PlayerPrefs.GetInt("Level", 1);

        completed.text = "Puzzel " + (levelno) + " Completed";

        
        print("one" + levelno);

        

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onContinueClick()
    {
        PlayerPrefs.SetInt("Level", levelno + 1);
      
        print("con"+levelno);
        winobj.SetActive(false);
        puzzelobj.SetActive(true);
    }
    public void onMainClick()
    {
        PlayerPrefs.SetInt("Level", levelno + 1);
        winobj.SetActive(false);
        levelobj.SetActive(true);
    }


}
