using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandleControl : MonoBehaviour
{
    [SerializeField] 
    float dragSpeed, moveSpeed;


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            transform.Translate(Vector3.right* touch.deltaPosition.x* dragSpeed);
            Debug.Log(touch.deltaPosition.x);

        }
    }
}
