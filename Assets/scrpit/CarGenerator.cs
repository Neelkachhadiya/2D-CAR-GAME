using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    public GameObject[] Cargenerate;
    public GameObject cionprefab, heartprefab;

    // Start is called before the first frame update3
    float randomX;
    int carSp;
    void Start()
    {

        InvokeRepeating("generate", 1.5f, 2f);
        InvokeRepeating("Coingenerate", 1f, 5f);
        InvokeRepeating("heartgenerate", 5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void generate()
    {
        randomX = Random.Range(-1.70f, 1.90f);
        carSp = PlayerPrefs.GetInt("CarSpeed", -1);
        if (carSp != -1)
        {
            int cnt = Random.Range(0, 3);
            GameObject car = Instantiate(Cargenerate[cnt], new Vector2(randomX, 7.4f), Quaternion.identity);
        }

    }
    void Coingenerate()
    {
        if (carSp != -1)
        {
            randomX = Random.Range(-1.70f, 1.90f);
            GameObject coin = Instantiate(cionprefab, new Vector2(randomX, 7.4f), Quaternion.identity);
        }

    }
    void heartgenerate()
    {
        if (carSp != -1)
        {

            randomX = Random.Range(-1.70f, 1.90f);
            GameObject coin = Instantiate(heartprefab, new Vector2(randomX, 7.4f), Quaternion.identity);
        }

    }

}


