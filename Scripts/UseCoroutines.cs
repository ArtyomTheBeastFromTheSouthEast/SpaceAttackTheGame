using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoroutines : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(CloneEnemyPrefab());
    }
    IEnumerator CloneEnemyPrefab()
    {
        while(true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-28.5f, 28.5f), 22.3f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4.0f);
        }
    }










   


}
