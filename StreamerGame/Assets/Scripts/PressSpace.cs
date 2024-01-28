using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSpace : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spaceText;
    [SerializeField] GameObject tutoriel1;
    [SerializeField] GameObject tutoriel2;
    [SerializeField] GameObject tutoriel3;
    void Start()
    {
        /*  spaceText = GameObject.Find("SpaceText");
          tutoriel1 = GameObject.Find("Tutorial1");
          tutoriel1.SetActive(false);
          tutoriel2 = GameObject.Find("Tutorial2");
          tutoriel2.SetActive(false);*/

        tutoriel1.SetActive(false);
        tutoriel2.SetActive(false);
        tutoriel3.SetActive(false);
    }
    int spacePress = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spacePress == 3)
        {
            SceneManager.LoadScene("PaulScene");
        }
        if (Input.GetKeyDown(KeyCode.Space) && spacePress == 2)
        {

            tutoriel2.SetActive(false);
            tutoriel3.SetActive(true);
            spacePress += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePress == 1)
        {

            tutoriel1.SetActive(false);
            tutoriel2.SetActive(true);
            spacePress += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && spacePress == 0)
        {
            tutoriel1.SetActive(true);
            spacePress += 1;
        }

       

        
    }
}
