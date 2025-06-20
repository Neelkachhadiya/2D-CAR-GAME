using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject puzzelobj, winobj, hintobj;
    public Image PuzzleImage;
    public Sprite[] Allimage;
    public Text leveltext, scortext,hinttext;
    int levelno = 0;
    public Text Anstext;
    int score, cnt = 0;

    string[] trueAns = { "10", "25", "6", "14", "128", "7", "50", "1025", "100", "3", "212", "3011", "14", "16", "1", "2", "44", "45", "625", "1", "13", "47", "50", "34" };
    string[] HintAns = { "Sum", "Multiplication", "5*6", "Square count", "Multiplication" ,"Try Difference Between Two Number ", "Try Division, Multiplication, Subtraction, Sum ","Try Two Number First Sum Before Multiplication ","Try (33 => 3+3 = 6) * (33 => 3+3 = 6) = 36 ","Try 4 + 2 = 6 ","Try 5 - 3 = 2,5 + 3 = 8 =>28 ","Try 2 * 1 = 2, 2 * 1 = 3 => 3 ","Try Division, Multiplication, Subtraction, Sum ","Try ","Try (First Second Row) 5 + 7 + 3 == (Third Row) 5 + 8 + 2 ","Try Difference Between 10, 8, 6, 4 ","Try Second Number, Subtraction between Two Number ","Try (First Row) 2 + 1 = 3 * (Second Row) 2 => 9 ","Try X^2, X^3, X^4 ","Try 6 + 7 = 13, 7 + 2 = 9 ", "Try Count Triangle " };

    // {"Try Sum ","Try Multiplication ","Try 5 * 6 = 30 ","Try Square Count ", "Try Multiplication " , "Try Difference Between Two Number ", "Try Division, Multiplication, Subtraction, Sum ","Try Two Number First Sum Before Multiplication ","Try (33 => 3+3 = 6) * (33 => 3+3 = 6) = 36 ","Try 4 + 2 = 6 ","Try 5 - 3 = 2,5 + 3 = 8 =>28 ","Try 2 * 1 = 2, 2 * 1 = 3 => 3 ","Try Division, Multiplication, Subtraction, Sum ","Try ","Try (First Second Row) 5 + 7 + 3 == (Third Row) 5 + 8 + 2 ","Try Difference Between 10, 8, 6, 4 ","Try Second Number, Subtraction between Two Number ","Try (First Row) 2 + 1 = 3 * (Second Row) 2 => 9 ","Try X^2, X^3, X^4 ","Try 6 + 7 = 13, 7 + 2 = 9 ", "Try Count Triangle " }
    private void OnEnable()
    {
        levelno=PlayerPrefs.GetInt("Level", 1);
        print("pla" + levelno);
        leveltext.text = "Puzzel " + levelno;

        score = PlayerPrefs.GetInt("Score", 0);
        scortext.text ="Score="+score;


        PlayerPrefs.SetInt("Level", levelno);
        PlayerPrefs.SetInt("Score", score);

        PuzzleImage.sprite = Allimage[levelno - 1];

        
    }
    // Start is called before the first frame update
    void Start()
    {
        scortext.text= "Score=" + score;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void btnClick(int th)
    {
        Anstext.text += th;
    }

    public void Delete()
    {
        if (Anstext.text.Length > 0)
        {
            Anstext.text = Anstext.text.Substring(0, Anstext.text.Length - 1);
        }

    }
    public void Submit()
    {
        if (Anstext.text == trueAns[levelno-1])
        {
            
            Anstext.text = "";

            PlayerPrefs.DeleteKey("skip_"+levelno);

            puzzelobj.SetActive(false);
            winobj.SetActive(true);
            
            score += 10;
            scortext.text = "Score=" + score;
            PlayerPrefs.SetInt("Score", score);

            if (PlayerPrefs.GetInt("MaxLevel", 1) <= PlayerPrefs.GetInt("Level", 1))
            {
                PlayerPrefs.SetInt("MaxLevel", levelno);
            }
        }
        else
        {
            Debug.Log("Wrong Ans..");
        }
    }
    public void Hint()
    {
        
        if(score>20)
        {
            hintobj.SetActive(true);
            //if(HintAns.Length > levelno-1)
            //{
               hinttext.text=HintAns[levelno - 1];
            //}else
            //{
            //    hinttext.text = "No Hint Available";
            //}
            if (cnt == 0)
            {

                score -= 20;
                cnt = 1;
            }
            scortext.text = "Score=" + score;
            PlayerPrefs.SetInt("Score", score);
        }
        else
        {
            Debug.Log("Not Use Hint");
        }

    }
    public void OK()
    {
        hintobj.SetActive(false);
    }

    public void skipbtn()
    {
        PlayerPrefs.SetInt("skip_" + levelno, levelno);
        PlayerPrefs.SetInt("Level", levelno+1);
        puzzelobj.SetActive(false);
        puzzelobj.SetActive(true);
    }

}
