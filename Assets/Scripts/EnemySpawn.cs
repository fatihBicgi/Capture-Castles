using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Spawn

     // it works once on start only
{
    private int spawnQueue = 0;

    protected override void Start()
    {
        base.Start();
        army = gameObject.GetComponent<EnemyArmy>();

        for (spawnQueue = 0; spawnQueue < army.currentInfantryCount; spawnQueue++)
        {
            if (spawnQueue % 2 == 0 && spawnQueue != 0)
            {
                InfantrySetNewLineStartPoint();
            }

            InfantryInstantiateToNewPoint();
        }

        for (spawnQueue = 0; spawnQueue < army.currentAirforceCount; spawnQueue++)
        {
            if (spawnQueue % 2 == 0 && spawnQueue != 0)
            {
                AirforceSetNewLineStartPoint();
            }

            AirforceInstantiateToNewPoint();

        }
    }

}
