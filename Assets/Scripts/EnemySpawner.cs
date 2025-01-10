using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    //Ghost prefab
    [SerializeField]
    private GameObject[] monsterReferance;
    private GameObject spawnedMonster;

    // Spawn positions
    [SerializeField]
    private Transform topPos, bottomPos, backPos;

    private int randomIndex;
    private int randomSide;


    public Transform player;

    private int _delay = 5;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnMonsters());

    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            randomSide = Random.Range(0, 3);

            spawnedMonster = Instantiate(monsterReferance[0]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = topPos.position;
            }

            else if (randomSide == 1)
            {
                spawnedMonster.transform.position = bottomPos.position;

            }
            else if (randomSide == 2)
            {
                spawnedMonster.transform.position = backPos.position;

            }






        }
    }


}
