using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float hp;
    public float hpMax;
    public GameObject GM;
    public GM GMst;

    public UISprite hpBar;
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }

        TouchMove();

    }

    
    private void OnTriggerEnter(Collider other)
    {
        hp -= 10.0f;
        hpBar.fillAmount = hp * 0.01f;
        if(hp <=0)
        {
            GMst.GameOver();
        }
    }


    void TouchMove()
    {
        if(Input.touchCount >0)
        {
            if (Input.GetTouch(0).deltaPosition.y > 1.0f)
            {
                transform.position += new Vector3(0, Mathf.Lerp(0, speed * Time.deltaTime, Time.time), 0);
            }
            else if (Input.GetTouch(0).deltaPosition.y < -1.0f)
            {
                transform.position -= new Vector3(0, Mathf.Lerp(0, speed * Time.deltaTime, Time.time), 0);
            }
        }
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.Clamp(transform.localPosition.y, -200.0f, 180.0f), transform.localPosition.z);

    }
}
