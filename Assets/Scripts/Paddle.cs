using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits ;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    float speed = 10.0f;
    Ball ball;


    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        //way one
        //var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //transform.position += move * speed * Time.deltaTime;
        
        
        
        //way two
        //    if (Input.GetKeyDown(KeyCode.LeftArrow))
        //    {
        //        Vector3 position = transform.position;
        //        position.x--;
        //        transform.position = position;
        //    }

        //    if (Input.GetKeyDown(KeyCode.RightArrow))
        //    {
        //        Vector3 position = transform.position;
        //        position.x++;
        //        transform.position = position;
       //    }


        //way three
        float mousePosInUnites = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //// Vector2 paddlePos = new Vector2(Mathf.Clamp(mousePosInUnites, minX, maxX), transform.position.y);
        Vector2 paddlePos = new Vector2(GetXPos(), transform.position.y);
        ////paddlePos.x = ;
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled() && ball.hasStarted)
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
           return //Input.mousePosition.x / Screen.width * screenWidthInUnits;
            Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX);

        }
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GetComponent<AudioSource>().Play();
    //}
}


