using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleControl : MonoBehaviour
{
    //sayý kontrollerinin yapýldýðý bir kod referansý ArmyCount
    //oyunda toplanýlan þeyler trigger enhancer(yukarýdakiler dragon aþaðýdakiler infantry artýrýr, bir hýz vs bonusu vardýr.)
    //enhancer ordu sayýsýna belirli eklemeler yapar ve ArmyCount eriþimi vardýr
    //HandleControl ArmyCount'a her zaman eriþimi vardýr ve sayýsýný günceller
    //HandleControl ArmyCount'dan aldýðý veriye göre set activeleri ayarlar
    //Eðer oyuncu FallTrigger'a girerse ArmyCount'dan asker eksilir
    //EnemyArmy sýradaki düþman kalesindeki asker sayýsýný tutar ve önceki kaleye girdiðinde güncellenir.
    //EnemyArmy ile ArmyCount arasýnda matematik hesabý yapýlýr ve savaþ sonucu belli olur
    // sonuçta biraz rastgelelik eklen(e)ir(random)
    // sýradaki kaledeki düþman sayýsý içn de biraz rastgelelik eklen(e)bilir.

    [SerializeField]
    private float dragSpeed; 
        
    public float defaultMoveSpeed, slowMoveSpeed, increaseMoveSpeed;

    [HideInInspector]
    public float currentMoveSpeed;

    [SerializeField]
    Vector3 firstPosition;

    private bool isPlayerFallableLeft=false, isPlayerFallableRight=false;

    private void Start()
    {
        firstPosition = transform.position;
        currentMoveSpeed = defaultMoveSpeed;
    }
    void FixedUpdate()
    {
        
        IsPlayerFallableCheck();

        TranslateForward();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (isPlayerCanMoveLeft(ref touch))
            {
                TranslateSide(touch);
                isPlayerFallableRight = false;
            }
            if (isPlayerCanMoveRight(ref touch))
            {
                TranslateSide(touch);
                isPlayerFallableLeft = false;
            }
        }
    }

    private bool isPlayerCanMoveRight(ref Touch touch)
    {
        return !isPlayerFallableRight && touch.deltaPosition.x > 0;
    }

    private bool isPlayerCanMoveLeft(ref Touch touch)
    {
        return !isPlayerFallableLeft && touch.deltaPosition.x < 0;
    }

    private void IsPlayerFallableCheck()
    {
        if (transform.position.z - firstPosition.z <= -3)
        {
            isPlayerFallableLeft = true;
        }
        if (transform.position.z - firstPosition.z >= 3)
        {
            isPlayerFallableRight = true;
        }
    }
    private void TranslateForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * currentMoveSpeed);
    }

    private void TranslateSide(Touch touch)
    {
        transform.Translate(Vector3.right * touch.deltaPosition.x * dragSpeed);
    }
}
