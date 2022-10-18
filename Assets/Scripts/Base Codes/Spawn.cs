using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //it handled spawn things

    [SerializeField]
    protected private GameObject infantrySpawn, airforceSpawn, spawnParent;

    [SerializeField]
    protected private GameObject infantryPrefab, dragonPrefab;

    protected private Army army;

    protected virtual void Start()
    {
        army = gameObject.GetComponent<Army>();
    }
    protected virtual void AirforceInstantiateToNewPoint()
    {
        Vector3 stepToNextLine = Vector3.left * 5;

        GameObject clone = Instantiate(dragonPrefab, airforceSpawn.transform.position, airforceSpawn.transform.rotation);
        clone.transform.parent = spawnParent.transform;

        airforceSpawn.transform.position += airforceSpawn.transform.TransformDirection(stepToNextLine);

    }
    protected private void InfantryInstantiateToNewPoint()
    {
        Vector3 stepToNextLine = Vector3.left * 1;

        GameObject clone = Instantiate(infantryPrefab, infantrySpawn.transform.position, infantrySpawn.transform.rotation);
        clone.transform.parent = spawnParent.transform;

        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(stepToNextLine);
    }

    protected private void InfantrySetNewLineStartPoint()
    {
        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(Vector3.forward * 1);
        infantrySpawn.transform.position += infantrySpawn.transform.TransformDirection(Vector3.right * 2);
    }
    protected private void AirforceSetNewLineStartPoint()
    {
        airforceSpawn.transform.position += airforceSpawn.transform.TransformDirection(Vector3.up * 1);
        airforceSpawn.transform.position += airforceSpawn.transform.TransformDirection(Vector3.right * 10);
    }
   

}
