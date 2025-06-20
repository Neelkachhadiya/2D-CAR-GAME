using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private static Music instance;
    public Slider volume;
    public AudioSource bgaudio;
    public GameObject soundobj;
    public Sprite[] soundimage;
    public Image mainsoundimage;
    float sound=1f;
    public Text music;
    // Start is called before the first frame update
    void Start()
    {
        if (Music.instance == null)
        {
            Music.instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        //DontDestroyOnLoad(this); 
        //bgaudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolume(float val)
    {
        int a=PlayerPrefs.GetInt("Images");
        if (a == 0)
        {
            bgaudio.volume = val;
            sound = val;
        }
        else if (a == 1) 
        {
            bgaudio.volume = 0f;
            sound = val;
        }
    }
    public void soundbtn()
    {
        soundobj.SetActive(true);
    }
    public void soundonoff()
    {
        int a = PlayerPrefs.GetInt("Images", 0);

        if (a == 0)
        {
            mainsoundimage.sprite = soundimage[0];
            music.text = "Music Off";
            bgaudio.volume = 0f;
            print("a=0"+bgaudio.volume);
            PlayerPrefs.SetInt("Images", 1);
        }
        else if (a == 1)
        {
            mainsoundimage.sprite = soundimage[1];
            music.text = "Music On";
            bgaudio.volume = sound;
            print("a=1" + bgaudio.volume);

            PlayerPrefs.SetInt("Images", 0);

            a = 0;
        }
    }
    public void okbtn()
    {
        soundobj.SetActive(false);
    }
}
