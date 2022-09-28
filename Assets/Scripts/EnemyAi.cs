using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public bool playerOnTriggerEntered=false;

    void Update()
    {
        if(playerOnTriggerEntered)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag=="Player")
        {
            moveSpeed = 0;

            //sald�rma animasyon(lar�) true
            //5sn bekleme
            //player kazanm��sa b�t�n d��man askerin �l�m animasyonu
            //enemy kazanm��sa b�t�n player askerin �l�m animasyonu
        }
    }
}
