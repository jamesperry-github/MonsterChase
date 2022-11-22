using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsters;
    private GameObject spawnedMonster;
    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIdx;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnMonsters() // co-routine
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // random range between 1-5 seconds
            randomIdx = Random.Range(0, monsters.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsters[randomIdx]);

            if (randomSide == 0) //left side
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            else //right side
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4, 10); //negative number
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // rotate to face from the right-side
            }
        } // while
    }
} //class
