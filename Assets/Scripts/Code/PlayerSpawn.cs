using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : Spawn 
    
    //spawn noktalar� ve rotasyonlar� enemyde �al��yor ama burda �al��m�yor
    // enhancer hava ve kara i�in ayr��t�r�lmad� hen�z
{
    protected override void Start()
    {
        base.Start();
        army = gameObject.GetComponent<PlayerArmy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enhancer")
        {
            army.currentInfantryCount++;

            InfantryInstantiateToNewPoint();
            if (army.currentInfantryCount %2==0)
            {
                InfantrySetNewLineStartPoint();
            }


            army.currentAirforceCount++;

            AirforceInstantiateToNewPoint();
            if (army.currentAirforceCount % 2 == 0 && army.currentAirforceCount !=2)
            {
                AirforceSetNewLineStartPoint();
            }
            

        }

    }
}
