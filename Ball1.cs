using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball1 : MonoBehaviour
{
    public bool DoubleJump = true, Goal = false;
    public Rigidbody rb;
    public float speed, JumpForce;
    public GameObject camera, FinishText, Particles, GameObjectChild;
    public Vector3 BasketPosition = new Vector3(-4.5f, 4.25f, -15.5f), ballRotate;
    public Vector3 velocity = Vector3.zero;
    

    public void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag == "Ground" && !Goal)
        {
            rb.velocity = Vector3.up * JumpForce;
            DoubleJump = true;
            // rb.AddForce(Vector3.up * JumpForce);
            GameObject temp_gameobject = Instantiate(Particles, transform.position, new Quaternion());
            Destroy(temp_gameobject, 3);
            ballRotate = new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bitirdin");
        FinishText.GetComponent<MeshRenderer>().enabled = true;
        Goal = true;
    }

    void Update()
    {
        Vector3 center = new Vector3(0, 4.339f, 0);



        if (Input.GetKeyDown(KeyCode.R))
            GameReset();
        if (!Goal)
        {
            /*Vector3 move = (camera.transform.right * -* 0.2f + camera.transform.forward * -joyStick.Vertical* 0.2f) * Time.deltaTime * speed;

            rb.MovePosition(gameObject.transform.position + gameObject.transform.TransformDirection(move));

            if (joyButton.Pressed && DoubleJump)
            {
                rb.velocity = Vector3.up * JumpForce * 1.2f;
                DoubleJump = false;
            }

            
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            move = (camera.transform.right * -x + camera.transform.forward * -z) * Time.deltaTime * speed;
            rb.MovePosition(transform.position + transform.TransformDirection(move));

            if (Input.GetKeyDown(KeyCode.Space) && DoubleJump)
            {
                rb.velocity = Vector3.up * JumpForce * 1.5f;
                DoubleJump = false;
            }*/

            GameObjectChild.transform.Rotate(ballRotate * 0.5f);
           


            if (gameObject.transform.position.y <= 0)
            {
                GameReset();
            }
        }
    }

    public void GameReset()
    {
        rb.velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(-7, 2, -6.5f);
        DoubleJump = true;
        Goal = false;
        FinishText.GetComponent<MeshRenderer>().enabled = false;
    }
}
 
