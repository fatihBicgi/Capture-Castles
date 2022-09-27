using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyCount : MonoBehaviour
{
    //say� kontrollerinin yap�ld��� bir kod referans� ArmyCount
    //oyunda toplan�lan �eyler trigger enhancer(yukar�dakiler dragon a�a��dakiler infantry art�r�r, bir h�z vs bonusu vard�r.)
    //enhancer ordu say�s�na belirli eklemeler yapar ve ArmyCount eri�imi vard�r
    //HandleControl ArmyCount'a her zaman eri�imi vard�r ve say�s�n� g�nceller
    //HandleControl ArmyCount'dan ald��� veriye g�re set activeleri ayarlar
    //E�er oyuncu FallTrigger'a girerse ArmyCount'dan asker eksilir
    //EnemyArmy s�radaki d��man kalesindeki asker say�s�n� tutar ve �nceki kaleye girdi�inde g�ncellenir.
    //EnemyArmy ile ArmyCount aras�nda matematik hesab� yap�l�r ve sava� sonucu belli olur
    // sonu�ta biraz rastgelelik eklen(e)ir(random)
    // s�radaki kaledeki d��man say�s� i�n de biraz rastgelelik eklen(e)bilir.

    [SerializeField]
    private int maxInfantryCount,maxDragonCount;

    public int currentInfantryCount,currentDragonCount;

  

}
