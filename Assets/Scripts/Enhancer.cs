using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhancer : MonoBehaviour
{
    private GameObject infantryLeftSpawn, infantryRightSpawn, leftLineParent, rightLineParent;

    [SerializeField]
    GameObject infantryPrefab, dragonPrefab;
    private void Start()
    {
        infantryLeftSpawn = GameObject.Find("Infantry Left Origin Spawn Point (1)");
        infantryRightSpawn = GameObject.Find("Infantry Right Origin Spawn Point (1)");

        leftLineParent = GameObject.Find("LeftLine");
        rightLineParent = GameObject.Find("RightLine");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Infantry")
        {
            FindObjectOfType<ArmyCount>().currentInfantryCount++;

            if (FindObjectOfType<ArmyCount>().currentInfantryCount % 2 == 0 && !(FindObjectOfType<ArmyCount>().currentInfantryCount == 0))
            {
                GameObject clone = Instantiate(infantryPrefab, infantryLeftSpawn.transform.position, infantryLeftSpawn.transform.rotation);
                clone.transform.parent = leftLineParent.transform;
                infantryLeftSpawn.transform.position += infantryLeftSpawn.transform.TransformDirection(Vector3.fwd);
            }
            if (FindObjectOfType<ArmyCount>().currentInfantryCount % 2 == 1)
            {
                GameObject clone = Instantiate(infantryPrefab, infantryRightSpawn.transform.position, infantryRightSpawn.transform.rotation);
                clone.transform.parent = rightLineParent.transform;
                infantryRightSpawn.transform.position += infantryRightSpawn.transform.TransformDirection(Vector3.fwd);
            }
        }
        else if (other.tag == "Dragon")
        {
            FindObjectOfType<ArmyCount>().currentDragonCount++;
        }
    }
   
}
