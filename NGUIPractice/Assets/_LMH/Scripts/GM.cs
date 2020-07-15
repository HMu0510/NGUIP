using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [SerializeField] private GameObject bgSetObj;
    [SerializeField] private GameObject bgSetObj2;


    public float moveSpeed;
    public float moveSpeed2;

    private float xPosMoveCheck = 0f;
    private float xPosMoveCheck2 = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xPosMoveCheck -= moveSpeed * Time.deltaTime;
        xPosMoveCheck2 -= moveSpeed2 * Time.deltaTime;
        bgSetObj.transform.localPosition -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        bgSetObj2.transform.localPosition -= new Vector3(moveSpeed2 * Time.deltaTime, 0, 0);

        if (xPosMoveCheck <= -960)
        {
            xPosMoveCheck = 0;
            bgSetObj.transform.localPosition = new Vector3(960 * -1.0f, 0, 0);
        }
        if (xPosMoveCheck2 <= -960)
        {
            xPosMoveCheck2 = 0;
            bgSetObj2.transform.localPosition = new Vector3(960 * -1.0f, -400, 0);
        }
    }
}
