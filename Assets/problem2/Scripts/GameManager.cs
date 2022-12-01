using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //재화는 1000 = 1A , 1000A = 1B, 1000B = 1C ······ 1000Z = 1AA 로 표기
    public static GameManager instance;

    public Text scoreText;
    public Text cubeCount;

    public float autoEarn = 0;
    public float time = 0;
    public float score = 0;
    public float alphabetCnt = 0;    
    public char alphabet = 'A';
    char second_alphabet = ' ';
    
    public void CubePlus()
    {
        if(alphabetCnt == 0)
        {
            autoEarn++;
        }
        else
        {
            autoEarn += 1 / Mathf.Pow(1000, alphabetCnt);
        }
    }

    public void GetScore()
    {
        score += autoEarn * 10f;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time >= 1)
        {
            score += autoEarn;
            time = 0;
            
            if (score >= 1000)
            {
                score = score / 1000;
                autoEarn /= 1000;                
                alphabetCnt++;

                if(alphabet != 'Z')
                {
                    alphabet++;
                }
                else
                {
                    alphabet = 'A';

                    if(second_alphabet != ' ')
                    {
                        second_alphabet++;
                    }
                    else
                    {
                        second_alphabet = 'A';
                    }
                }
            }
        }

        scoreText.text = "Gold : " + Mathf.Round(score * 100) * 0.01f + alphabet + second_alphabet;
        cubeCount.text = "Auto Earn : " + autoEarn + alphabet + second_alphabet;
    }
}