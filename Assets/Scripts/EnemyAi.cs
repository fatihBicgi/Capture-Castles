using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;   

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag=="Player")
        {
            moveSpeed = 0;

            //saldýrma animasyon(larý) true
            //5sn bekleme
            //player kazanmýþsa bütün düþman askerin ölüm animasyonu
            //enemy kazanmýþsa bütün player askerin ölüm animasyonu
        }
    }
}
