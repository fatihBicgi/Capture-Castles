using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    //düþman piyadeleri merdiven gibi bir yerde beklese sayýlarý uzaktan daha net belli olur

    [SerializeField]
    private int enemyInfantryCount, enemyDragonCount;

    [SerializeField]
    private Transform center;

    [SerializeField]
    private GameObject infantrySpawn, airforceSpawn, enemyParent ;

    int spawnQueue = 0;

    [SerializeField]
    GameObject infantryPrefab, dragonPrefab;

    private void Start()
    {           

        for (spawnQueue=0; spawnQueue < enemyInfantryCount; spawnQueue++)
        {
            if (spawnQueue % 2 == 0 && spawnQueue != 0)
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
            //other.transform.position = center.position;         

            FindObjectOfType<HandleControl>().moveSpeed = 2;

            if (isPlayerStrongerThanEnemy())
            {
                

                StartCoroutine(WinTheStage());

                
            }
            else
            {
                                
               StartCoroutine(GameOver());

            }


        }
    }
    IEnumerator WinTheStage()
    {
        Debug.Log("You Win");

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
        FindObjectOfType<HandleControl>().moveSpeed = 5;
    }
    IEnumerator GameOver()
    {

        Debug.Log("You Lose");
       
        yield return new WaitForSeconds(3);
        
        Time.timeScale = 0;
        
    }


    private void AirforceInstantiateToNewPoint()
    {
        Vector3 stepToNextLine = Vector3.left * 6;

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
        airforceSpawn.transform.position += airforceSpawn.transform.TransformDirection(Vector3.right * 12);
    }

    private void InfantrySetNewLineStartPoint()
    {
        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(Vector3.forward);
        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(Vector3.right * 2);
    }

   

}
