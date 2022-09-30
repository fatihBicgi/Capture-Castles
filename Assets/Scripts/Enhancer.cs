using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhancer : MonoBehaviour
{
    private GameObject infantryLeftSpawn, infantryRightSpawn, infantryLeftLineParent, infantryRightLineParent,
         airforceLeftSpawn, airforceRightSpawn,airforceLeftLineParent, airforceRightLineParent;

    [SerializeField]
    GameObject infantryPrefab, dragonPrefab;

    private void Start()
    {
        InfantryAssignment();

        AirforceAssignment();

    }
  
    private void OnTriggerEnter(Collider other)
    {      
        if (other.tag == "Infantry")
        {
            FindObjectOfType<ArmyCount>().currentInfantryCount++;

            bool isCurrentInfantryCountOdd = FindObjectOfType<ArmyCount>().currentInfantryCount % 2 == 1;


            if ( !(isCurrentInfantryCountOdd) && FindObjectOfType<ArmyCount>().currentInfantryCount > 0)
            {
                LeftInstantiateNewInfantry();

                LeftSetNewInfantrySpawnPoint();
            }
            if ( isCurrentInfantryCountOdd)
            {
                RightInstantiateNewInfantry();

                RightSetNewInfantrySpawnPoint();
            }
        }
        else if (other.tag == "Dragon")
        {
            FindObjectOfType<ArmyCount>().currentDragonCount++;

            bool isCurrentDragonCountOdd = FindObjectOfType<ArmyCount>().currentDragonCount % 2 == 1;

            if (!(isCurrentDragonCountOdd))
            {
                airforceLeftSpawn.transform.position += airforceLeftSpawn.transform.TransformDirection(Vector3.up * 0.6f);

                GameObject clone = Instantiate(dragonPrefab, airforceLeftSpawn.transform.position, airforceLeftSpawn.transform.rotation);
                clone.transform.parent = airforceLeftLineParent.transform;

                
            }
            if (isCurrentDragonCountOdd)
            {
                GameObject clone = Instantiate(dragonPrefab, airforceRightSpawn.transform.position, airforceRightSpawn.transform.rotation);
                clone.transform.parent = airforceRightLineParent.transform;

                airforceRightSpawn.transform.position += airforceRightSpawn.transform.TransformDirection(Vector3.up * 0.6f);
            }

        }
    }
    private void AirforceAssignment()
    {
        airforceLeftSpawn = GameObject.Find("Airforce Left Origin Spawn Point");
        airforceRightSpawn = GameObject.Find("Airforce Right Origin Spawn Point");

        airforceLeftLineParent = GameObject.Find("AirForce Left Line");
        airforceRightLineParent = GameObject.Find("AirForce Right Line");
    }

    private void InfantryAssignment()
    {
        infantryLeftSpawn = GameObject.Find("Infantry Left Origin Spawn Point");
        infantryRightSpawn = GameObject.Find("Infantry Right Origin Spawn Point");

        infantryLeftLineParent = GameObject.Find("Infantry Left Line");
        infantryRightLineParent = GameObject.Find("Infantry Right Line");
    }


    private void RightInstantiateNewInfantry()
    {
        GameObject clone = Instantiate(infantryPrefab, infantryRightSpawn.transform.position, infantryRightSpawn.transform.rotation);
        clone.transform.parent = infantryRightLineParent.transform;
    }

    private void LeftInstantiateNewInfantry()
    {
        GameObject clone = Instantiate(infantryPrefab, infantryLeftSpawn.transform.position, infantryLeftSpawn.transform.rotation);
        clone.transform.parent = infantryLeftLineParent.transform;
    }

    private void RightSetNewInfantrySpawnPoint()
    {
        infantryRightSpawn.transform.position += infantryRightSpawn.transform.TransformDirection(Vector3.forward*0.6f);
    }

    private void LeftSetNewInfantrySpawnPoint()
    {
        infantryLeftSpawn.transform.position += infantryLeftSpawn.transform.TransformDirection(Vector3.forward * 0.6f);
    }
}
