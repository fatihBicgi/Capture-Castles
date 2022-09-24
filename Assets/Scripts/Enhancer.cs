using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhancer : MonoBehaviour
{
    //ArmyCount armyCount;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Infantry")
        {
            FindObjectOfType<ArmyCount>().currentInfantryCount++;
        }
        else if (other.tag == "Dragon")
        {
            FindObjectOfType<ArmyCount>().currentDragonCount++;
        }
    }
   
}
