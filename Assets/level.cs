using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{

    public GameObject puzzelobj, levelobj, homeobj;
    public Button[] allbtn;
    public Sprite ticksing;
    
    // Start is called before the first frame update

    int levelno, maxlevelno;
    private void OnEnable()
    {
        levelno = PlayerPrefs.GetInt("Level", 1);
        maxlevelno=PlayerPrefs.GetInt("MaxLevel", 0);

        for (int i = 0; i <= maxlevelno; i++)
        {
            allbtn[i].interactable = true;

            allbtn[i].GetComponentInChildren<Text>().text=(i+1).ToString();
            if (i < maxlevelno)
            {
                if(PlayerPrefs.HasKey("skip_" + (i+1)))
                {
                    allbtn[i].GetComponent<Image>().sprite = null;
                }
                else
                {
                    allbtn[i].GetComponent<Image>().sprite = ticksing;
                }

            }
            else
            {
                allbtn[i].GetComponent<Image>().sprite = null;
            }

        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Levelbtnclick(int on)
    {
        PlayerPrefs.SetInt("Level", on);
        levelobj.SetActive(false);
        puzzelobj.SetActive(true);
    }
}
