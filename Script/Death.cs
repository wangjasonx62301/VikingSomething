using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleEndScore(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
    }

    public void Restart()
    {
        //GetComponent<Score>().setZero();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetMenu()
    {
        //GetComponent<Score>().setZero();
        SceneManager.LoadScene("MainMenu");
    }
}
