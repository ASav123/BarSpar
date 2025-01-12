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

    private int _randomSide;


    public Transform Player;

    private int _delay = 3;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnMonsters());

    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
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
