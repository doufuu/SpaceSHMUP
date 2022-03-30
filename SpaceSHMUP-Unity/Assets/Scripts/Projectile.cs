/**** 
 * Created by: Bobby Ouyang
 * Date Created: Marhch 30, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 30, 2022
 * 
 * Description: Projectile Behaviours
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /***VARIABLES***/
    private BoundsCheck bndCheck; //refrence to the bounds check


    // Start is called before the first frame update
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //if off screen up
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
