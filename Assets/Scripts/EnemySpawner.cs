using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    //Ghost prefab
    [SerializeField]
    private GameObject[] _monsterReferance;
    private GameObject _spawnedMonster;

    // Spawn positions
    [SerializeField]
    private Transform _topPos, _bottomPos, _backPos;

    // Spawner attributes
    private int _randomSide;
    public Transform Player;
    private int _delay = 3;
    private int monsterCount;

    void Awake()
    {
        monsterCount= 0;
        // Starts spawing
        StartCoroutine(SpawnMonsters());

    }
    // Picks a random spawn location and spawns a ghost
    IEnumerator SpawnMonsters()
    {
        while (monsterCount < 50)
        {
            monsterCount += 1;
            yield return new WaitForSeconds(this._delay);

            this._randomSide = Random.Range(0, 3);

            this._spawnedMonster = Instantiate(this._monsterReferance[0]);

            if (this._randomSide == 0)
            {
                this._spawnedMonster.transform.position = this._topPos.position;
            }

            else if (this._randomSide == 1)
            {
                this._spawnedMonster.transform.position = this._bottomPos.position;

            }
            else if (this._randomSide == 2)
            {
                this._spawnedMonster.transform.position = this._backPos.position;

            }






        }
    }


}
