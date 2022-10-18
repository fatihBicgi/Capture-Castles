using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : Spawn 
    
    //spawn noktalarý ve rotasyonlarý enemyde çalýýyor ama burda çalýþmýyor
    // enhancer hava ve kara için ayrýþtýrýlmadý henüz
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
        }

        if (other.tag == "Air Enhancer")
        {          
            army.currentAirforceCount++;
                
            AirforceInstantiateToNewPoint();            
            if (army.currentAirforceCount % 2 == 0 && army.currentAirforceCount != 2)              
            {                   
                AirforceSetNewLineStartPoint();               
            }
        }
            
            

        

    }
}
