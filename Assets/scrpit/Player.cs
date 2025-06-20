using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float speed = .05f, carRotation=0f;
    public Text CoinText;
    int Coin;
    public Slider slider;
    float slidercnt =5f;
    public Sprite[] allcar;
    int move=4;
    int carSp = 0, carSpmax;
    public GameObject settingobj,onoffobj, setbtnobj;
    bool btnRight, btnleft, touchRight, touchLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CarSpeed", 1);
        int carno = PlayerPrefs.GetInt("CarIn");

        SpriteRenderer carimage = GetComponent<SpriteRenderer>();
        carimage.sprite = allcar[carno];
        onoffobj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(move)
        {
            case 1:
                PlayerPrefs.SetInt("CarSpeed", 1);

                onoffobj.SetActive(false);
                if (Input.touchCount > 0)
                {
                    float screenHalf = Screen.width / 2;
                    Touch t = Input.GetTouch(0);
                    Vector2 pos = t.position;
                    
                    if (pos.x < screenHalf)
                    {
                        float xpos = Mathf.Clamp(transform.position.x - speed, -1.50f, 1.50f);
                        transform.position = new Vector2(xpos, transform.position.y);
                        if (carRotation < 5f)
                        {
                            carRotation += Time.deltaTime * 10f;
                            touchRight=false;
                        }
                        transform.rotation = Quaternion.Euler(0, 0, carRotation);
                    }
                    else
                    {
                        float xpos = Mathf.Clamp(transform.position.x + speed, -1.50f, 1.50f);
                        transform.position = new Vector2(xpos, transform.position.y);
                        if (carRotation > -5f)
                        {
                            carRotation -= Time.deltaTime * 10f;
                            touchLeft = false;
                        }
                        transform.rotation = Quaternion.Euler(0, 0, carRotation);
                    }
                  
                }
                else
                {
                    carRotation = 0;
                    transform.rotation = Quaternion.Euler(0, 0, carRotation);
                }


                break;
            case 2:
                PlayerPrefs.SetInt("CarSpeed", 1);

                onoffobj.SetActive(false);
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    float xpos = Mathf.Clamp(transform.position.x + speed, -1.50f, 1.50f);
                    transform.position = new Vector2(xpos, transform.position.y);
                    if(carRotation>-5f)
                    {
                        carRotation -= Time.deltaTime * 10f;
                    }
                    transform.rotation=Quaternion.Euler(0, 0, carRotation);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    float xpos = Mathf.Clamp(transform.position.x - speed, -1.50f, 1.50f);
                    transform.position = new Vector2(xpos, transform.position.y);
                    if (carRotation < 5f)
                    {
                        carRotation += Time.deltaTime * 10f;
                    }
                    transform.rotation = Quaternion.Euler(0, 0, carRotation);
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    carRotation = 0;
                    transform.rotation =Quaternion.Euler(0, 0, carRotation);    
                }
                break;
            case 3:
                PlayerPrefs.SetInt("CarSpeed", 1);
                
                onoffobj.SetActive(false);
                    if (Input.acceleration.x<-0.1f)
                    {
                        float xpos = Mathf.Clamp(transform.position.x - speed, -1.50f, 1.50f);
                        transform.position = new Vector2(xpos, transform.position.y);
                        if (carRotation < 5f)
                        {
                            carRotation += Time.deltaTime * 10f;
                        }
                        transform.rotation = Quaternion.Euler(0, 0, carRotation);
                    }   
                    else if(Input.acceleration.x>0.1f)
                    {
                        float xpos = Mathf.Clamp(transform.position.x + speed, -1.50f, 1.50f);
                        transform.position = new Vector2(xpos, transform.position.y);
                        if (carRotation > -5f)
                        {
                            carRotation -= Time.deltaTime * 10f;
                        }
                        transform.rotation = Quaternion.Euler(0, 0, carRotation);
                    }
                    else
                    {
                        carRotation = 0;
                        transform.rotation = Quaternion.Euler(0, 0, carRotation);
                    }
                break;
            case 4:
                PlayerPrefs.SetInt("CarSpeed", 1);

                onoffobj.SetActive(true);
                    if(btnRight)
                    {
                      float xpos = Mathf.Clamp(transform.position.x + speed, -1.50f, 1.50f);
                      transform.position = new Vector2(xpos, transform.position.y);
                        if (carRotation > -5f)
                        {
                            carRotation -= Time.deltaTime * 10f;
                        }
                        transform.rotation = Quaternion.Euler(0, 0, carRotation);
                    }
                    if(btnleft)
                    {
                        float xpos = Mathf.Clamp(transform.position.x - speed, -1.50f, 1.50f);
                        transform.position = new Vector2(xpos, transform.position.y);
                        if (carRotation < 5f)
                        {
                            carRotation += Time.deltaTime * 10f;
                        }
                        transform.rotation = Quaternion.Euler(0, 0, carRotation);
                    }
                        
                break;

        }
     



}
    public void rightmovedown()
    {
        btnRight = true;

    }
    public void rightmoveup()
    {
        btnRight = false;
        carRotation = 0;
        transform.rotation = Quaternion.Euler(0, 0, carRotation);
    }
    public void leftmovedown()
    {
        btnleft = true;
    }
    public void leftmoveup()
    {
        btnleft = false;
        carRotation = 0;
        transform.rotation = Quaternion.Euler(0, 0, carRotation);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            slidercnt--;
            slider.value = slidercnt;
            print("slider"+slider.value);
            Destroy(collision.gameObject);
            if (slider.value==0)
            {
                PlayerPrefs.SetInt("CarSpeed", 1);
                SceneManager.LoadScene("reset");
            }
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            Coin += 100;
            CoinText.text = "Coin : " + Coin;
            carSp += 1;
            print(carSp);
            if (carSp == 5)
            {
                PlayerPrefs.SetInt("CarSpeed", 1);

            }
            else if (carSp == 15)
            {
                PlayerPrefs.SetInt("CarSpeed", 2);

            }
            else if (carSp == 25)
            {
                PlayerPrefs.SetInt("CarSpeed", 3);

            }
            else if (carSp == 45)
            {
                PlayerPrefs.SetInt("CarSpeed", 4);

            }
            else if (carSp == 60)
            {
                PlayerPrefs.SetInt("CarSpeed", 5);

            }
        }
        if (collision.gameObject.tag == "heart")
        {
            Destroy(collision.gameObject);
            if (slider.value < 5)
            {
                slidercnt = slidercnt + 1f;
                slider.value = slidercnt;
            }

        }

    }
    //public void setting()
    //{
    //    settingobj.SetActive(true);

    //}
    //public void MovementSelect(int se)
    //{
    //    settingobj.SetActive(false);
    //    move = se;
    //}
    public void setting()
    {
        setbtnobj.SetActive(false);
        carSpmax = PlayerPrefs.GetInt("CarSpeed");
        print("s=" + carSpmax);

        PlayerPrefs.SetInt("CarSpeed", -1);
        settingobj.SetActive(true);

    }
    public void MovementSelect(int se)
    {
        setbtnobj.SetActive(true);
        PlayerPrefs.SetInt("CarSpeed", carSpmax);
        print("m=" + carSpmax);

        settingobj.SetActive(false);
        move = se;
    }
}
