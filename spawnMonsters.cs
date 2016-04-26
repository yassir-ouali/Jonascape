using UnityEngine;
using System.Collections;

public class spawnMonsters : MonoBehaviour {

    public int DifferenceBetweenLines;
    public float speedEnemyFly ;
    public int nmbrOfEnemies;

    public GameObject enemie1 = null;
    public GameObject enemie2 = null;

    Camera camMain;
    float camHeight;
    float camWidth;

    float enemyHeight;
    float enemyWidth;

	// Use this for initialization
	void Start () {

        // Get Cam size
        camMain = Camera.main;
        camHeight = 2f * camMain.orthographicSize;
        camWidth = camHeight * camMain.aspect;

        // Get Enemy size
        enemyHeight = enemie1.GetComponent<Renderer>().bounds.size.y;
        enemyWidth = enemie1.GetComponent<Renderer>().bounds.size.x;

        for (int i = 2; i < nmbrOfEnemies; i++)
        {

                int y = Random.Range(0, 2);
                //print(y);
                if (y == 1)
                {
                    creatMonster(enemie1, i);
                }
                else
                {
                    creatMonster(enemie2, i);
                }

        }
	}
	
	// Update is called once per frame
	void Update () {

       
	}

    void creatMonster(GameObject go, int i)
    {
        GameObject GO = GameObject.Instantiate(go, new Vector3(camWidth*(Random.Range(0, 3)-1), i * DifferenceBetweenLines, 0), Quaternion.identity) as GameObject;
    }
}
