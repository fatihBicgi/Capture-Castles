using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    //düþman piyadeleri merdiven gibi bir yerde beklese sayýlarý uzaktan daha net belli olur

    [SerializeField]
    private int enemyInfantryCount, enemyDragonCount;

    private GameObject infantrySpawn, airforceSpawn, enemyParent ;

    int spawnQueue = 0;

    [SerializeField]
    GameObject infantryPrefab, dragonPrefab;

    private void Start()
    {
        infantrySpawn = GameObject.Find("Enemy Infantry Spawn Point");
        airforceSpawn = GameObject.Find("Enemy AirForce Spawn Point");
        enemyParent = GameObject.Find("Simple Wooden Castle");

        ;

        for (spawnQueue=0; spawnQueue < enemyInfantryCount; spawnQueue++)
        {
            if (spawnQueue % 3 == 0 && spawnQueue != 0)
            {
                InfantrySetNewLineStartPoint();
            }

            InfantryInstantiateToNewPoint();

        }

        for (spawnQueue = 0; spawnQueue < enemyDragonCount; spawnQueue++)
        {
            if (spawnQueue % 2 == 0 && spawnQueue != 0)
            {
                AirforceSetNewLineStartPoint();

            }

            AirforceInstantiateToNewPoint();

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isPlayerStrongerThanEnemy())
            {
                Debug.Log("You Win");
            }
            else
            {
                Debug.Log("You Lose");
            }
        }
    }

   

    private void AirforceInstantiateToNewPoint()
    {
        Vector3 stepToNextLine = Vector3.left * 8;

        GameObject clone = Instantiate(dragonPrefab, airforceSpawn.transform.position, airforceSpawn.transform.rotation);
        clone.transform.parent = enemyParent.transform;

        airforceSpawn.transform.position += airforceSpawn.transform.TransformDirection(stepToNextLine);
    }

    private bool isPlayerStrongerThanEnemy()
    {
        return FindObjectOfType<ArmyCount>().currentDragonCount > enemyDragonCount && 
            FindObjectOfType<ArmyCount>().currentInfantryCount > enemyInfantryCount;
    }

    private void InfantryInstantiateToNewPoint()
    {
        Vector3 stepToNextLine = Vector3.left;

        GameObject clone = Instantiate(infantryPrefab, infantrySpawn.transform.position, infantrySpawn.transform.rotation);
        clone.transform.parent = enemyParent.transform;

        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(stepToNextLine);
    }

    private void AirforceSetNewLineStartPoint()
    {
        airforceSpawn.transform.position += airforceSpawn.transform.TransformDirection(Vector3.up * 1);
        airforceSpawn.transform.position += airforceSpawn.transform.TransformDirection(Vector3.right * 16);
    }

    private void InfantrySetNewLineStartPoint()
    {
        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(Vector3.forward * 2);
        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(Vector3.right * 3);
    }

   

}
