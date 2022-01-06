using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Ball1 ballCommand ;
    public Vector3 goalStartPosition;
    public GameObject camera ;
    public Rigidbody ball;
    float speed = 0.1f, JumpForce = 5f;
    bool clicked = false;
    bool goalcheck = false;
    Vector2 firstpos;
    float timeclicked,t;

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked = true;
        firstpos = Input.mousePosition;
        timeclicked = Time.realtimeSinceStartup;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        clicked = false;
        if (Time.realtimeSinceStartup -  timeclicked > 0.5f)
        {
            return;
        }

        if (Input.mousePosition.y - firstpos.y >= 1 && ballCommand.DoubleJump)
        {
            ballCommand.DoubleJump = false;

            
        }
    }
    void Start()
    {
        firstpos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        //ball.velocity = Vector3.Slerp(ball.gameObject.transform.position, ballCommand.BasketPosition, 0.1f) * JumpForce * 1.4f;

        if (clicked && !ballCommand.Goal)
        {
            Vector2 movedirection = new Vector2(firstpos.x - Input.mousePosition.x, Input.mousePosition.y - firstpos.y);
            /*if(Input.mousePosition.x > firstpos.x)
            {
                movedirection.x = -1f;
            }
            if (Input.mousePosition.x < firstpos.x)
            {
                movedirection.x = 1f;
            }
            if (Input.mousePosition.y > firstpos.y)
            {
                movedirection.y = 1f;
            }
            if (Input.mousePosition.y < firstpos.y)
            {
                movedirection.y = -1f;
            }*/
            if (Vector3.Distance(ball.gameObject.transform.position, ballCommand.BasketPosition) < 2)
            {
                ball.gameObject.transform.LookAt(ballCommand.BasketPosition);

                ball.MovePosition(ball.gameObject.transform.position + new Vector3(ball.transform.forward.x, 0, ball.transform.forward.y));
            }
            Vector3 move = (camera.transform.right * movedirection.x + -camera.transform.forward* movedirection.y) * Time.deltaTime * speed;
            ball.MovePosition(ball.gameObject.transform.position + ball.gameObject.transform.TransformDirection(move));
        }
    }
}
