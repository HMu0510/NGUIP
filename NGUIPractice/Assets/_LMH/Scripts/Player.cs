using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float hp;
    public float hpMax;
    [SerializeField] GameObject GM;
    public GM GMst;

    [SerializeField] private UISprite hpBar;
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up"))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime,0);
        }
        else if(Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }

        //TouchMove();

    }

    
    private void OnTriggerEnter(Collider other)
    {
        hp -= 10.0f;
        hpBar.fillAmount = hp * 0.01f;
        if(hp <=0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }
}
