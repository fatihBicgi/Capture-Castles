using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : Spawn 
    
    // it works when on trigger enter only
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
