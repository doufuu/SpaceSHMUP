/**** 
 * Created by: Bobby Ouyang
 * Date Created: March 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 28, 2022
 * 
 * Description: Spawn enemies
****/

/** Using Namespaces **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*** VARIBALES ***/
    [Header("Enemy settings")]
    public GameObject[] prefabEnemies; //array of all enemy prefabs
    public float enemySpawnPerSecond; //enemy count to spawn per second
    public float enemyDeafultPadding; //padding position of each enemy


    private BoundsCheck bndCheck; //reference to the BoundsCheck component
    

    // Start is called before the first frame update
    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);




    }

    void SpawnEnemy() 
    {
        //pick a random enemy to instantiate 
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //position the enemy above the screen with a random x position
        float enemyPadding = enemyDeafultPadding;

        if (go.GetComponent<BoundsCheck>() != null) 
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //Set the initial position
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax); //range between the xmin and xmax
        pos.y = bndCheck.camHeight + enemyPadding; //height plus padding, off screen

        go.transform.position = pos;

        //invoke again
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);



    }
}
