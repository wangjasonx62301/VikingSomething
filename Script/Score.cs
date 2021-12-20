using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public static float score = 0.0f;
    public Text scoreText;
    private bool isDead = false;
    public Death death;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }

    public void onDeath()
    {
        isDead = true;
        death.toggleEndScore(score);
    }

    public void addCoin()
    {
        score += 10;
    }

    public void setZero()
    {
        score = 0;
    }
}
