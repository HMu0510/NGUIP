using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject bgSetObj;
    public GameObject bgSetObj2;
    public GameObject enemySet1;

    public List<GameObject> nowEnemyChild = new List<GameObject>();
    public int enemyInt = 0;
    public float yPos;

    public float moveSpeed;
    public float moveSpeed2;
    public float maxSpeed;

    private float xPosMoveCheck = 0f;
    private float xPosMoveCheck2 = 0f;

    public float xPosMoveChkVal1 = 0f;
    public float xPosMoveChkVal2 = 0f;


    public float timerLim;
    public float timerForSpeed;

    public UILabel Score;
    public float gameScore;
    public int gameScorePer;

    public GameObject resultUI;
    public UILabel resultPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        SpeedLimChk();

        xPosMoveCheck -= moveSpeed * Time.deltaTime;
        xPosMoveCheck2 -= moveSpeed2 * Time.deltaTime;
        bgSetObj.transform.localPosition -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        bgSetObj2.transform.localPosition -= new Vector3(moveSpeed2 * Time.deltaTime, 0, 0);
        enemySet1.transform.localPosition -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);

        gameScore += moveSpeed * Time.deltaTime * 0.01f;
        //Score.text = gameScore.ToString();
        Score.text = gameScore.ToString("N0");
        if (xPosMoveCheck <= -960)
        {
            xPosMoveCheck = 0;
            bgSetObj.transform.localPosition = new Vector3(960 * -1.0f, 0, 0);

    
        }
        if (xPosMoveCheck2 <= -960)
        {
            xPosMoveCheck2 = 0;
            bgSetObj2.transform.localPosition = new Vector3(960* -1.0f, -400, 0);

            if(enemySet1.transform.localPosition.x < xPosMoveChkVal1)
            {
                xPosMoveChkVal1 -= xPosMoveChkVal2;
                ResetChildSet();
                enemyInt++;
                if(enemyInt >4)
                {
                    enemyInt = 0;
                }
            }
        }
    }

    private void SpeedLimChk()
    {
        timerForSpeed += Time.deltaTime;

        if (timerForSpeed > timerLim)
        {
            timerForSpeed = 0;
            if (moveSpeed < maxSpeed)
            {
                moveSpeed = moveSpeed * 1.1f;
                moveSpeed2 = moveSpeed2 * 1.1f;
            }
        }
    }
    private void ResetChildSet()
    {
        nowEnemyChild[enemyInt].transform.localPosition += new Vector3(2880.0f, 0, 0);
        switch(Random.Range(1,4))
        {
            case 1:
                yPos = -150f;
                break;
            case 2:
                yPos = 150.0f;
                break;
            case 3:
                yPos = 300f;
                break;
        }
        nowEnemyChild[enemyInt].transform.localPosition =
            new Vector3(nowEnemyChild[enemyInt].transform.localPosition.x,
            yPos, nowEnemyChild[enemyInt].transform.localPosition.z);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        resultUI.SetActive(true);
        resultPoint.text = gameScore.ToString("N0");
    }

    public void Regame()
    {
        resultUI.SetActive(false);
        Time.timeScale = 1;
        //Application.LoadLevel("1");
        SceneManager.LoadScene(0);
    }
}
