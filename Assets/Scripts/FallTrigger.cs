using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
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

    ArmyCount armyCount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            armyCount.currentInfantryCount--;
        }
    }
}
