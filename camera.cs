using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Basketball, Basket;
    

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Basketball.transform.position.x,1, Basketball.transform.position.z);
        gameObject.transform.LookAt(new Vector3(Basket.transform.position.x, gameObject.transform.position.y, Basket.transform.position.z - 2.5f));
    }
}
