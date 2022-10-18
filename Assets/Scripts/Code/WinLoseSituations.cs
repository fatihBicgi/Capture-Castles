using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseSituations : MonoBehaviour
{
    HandleControl handleControl;
    PlayerArmy playerArmy;
    HandleEnemyArmy enemyArmy;

    [SerializeField]
    private GameObject capturedText;

    [SerializeField]
    private GameObject retry;

    private GameObject currentCastle;

    private void Start()
    {
        handleControl = gameObject.GetComponent<HandleControl>();
        playerArmy = gameObject.GetComponent<PlayerArmy>();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Castle")
        {
            enemyArmy = other.gameObject.GetComponent<HandleEnemyArmy>();

            handleControl.currentMoveSpeed = handleControl.slowMoveSpeed;

            if (isPlayerStrongerThanEnemy())
            {
                StartCoroutine(WinTheStage());

                currentCastle = other.gameObject;
            }
            else
            {
                StartCoroutine(GameOver());
            }

        }
    }

    private bool isPlayerStrongerThanEnemy()
    {
        return playerArmy.currentInfantryCount > enemyArmy.currentInfantryCount && playerArmy.currentAirforceCount > enemyArmy.currentAirforceCount;
    }

    IEnumerator WinTheStage()
    {
        Debug.Log("You Win");


        yield return new WaitForSeconds(3);

        capturedText.GetComponent<Text>().enabled = true;

        yield return new WaitForSeconds(1);

        capturedText.GetComponent<Text>().enabled = false;

        Destroy(currentCastle);

        handleControl.defaultMoveSpeed = handleControl.defaultMoveSpeed + handleControl.increaseMoveSpeed;
        handleControl.currentMoveSpeed = handleControl.defaultMoveSpeed;


    }
    IEnumerator GameOver()
    {
        Debug.Log("You Lose");

        yield return new WaitForSeconds(3);

        Time.timeScale = 0;
        retry.GetComponent<Image>().enabled = true;
        retry.GetComponentInChildren<Text>().enabled = true;
    }
}
