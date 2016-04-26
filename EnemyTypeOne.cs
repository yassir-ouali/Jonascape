using UnityEngine;
using System.Collections;

public class EnemyTypeOne : MonoBehaviour
{

    /* Variable Configuration
    **************************/
    private float speedEnemyFly = 2.2f;

    /* Variable Works
    **************************/

    Camera camMain;
    float camHeight;
    float camWidth;

    float enemyHeight;
    float enemyWidth;

    /* Declare Objects
    **************************/



    /* Start & Update
    **************************/
    void Start()
    {
        
        // Get Cam size
        camMain = Camera.main;
        camHeight = 2f * camMain.orthographicSize;
        camWidth = camHeight * camMain.aspect;

        // Get Enemy size
        enemyHeight = GetComponent<Renderer>().bounds.size.y;
        enemyWidth = GetComponent<Renderer>().bounds.size.x;

    }

    void Update()
    {
        transform.position -= new Vector3(speedEnemyFly * Time.deltaTime, 0.0f, 0.0f);

        // Reset position of enemy
        if (transform.position.x <= (-camWidth/2 - enemyWidth ))
        {
            transform.position = new Vector3(camWidth/2+enemyWidth, transform.position.y, transform.position.z);
        }

    }


   
}
