using UnityEngine;
using System.Collections;

public class EnemiesLines : MonoBehaviour {

	/* Variable Configuration
	**************************/
	public int LineToDisplay = 9; // 9
	public float DifferenceBetweenLines = 0.0f; // 1.5;
    public GameObject enemie1 = null;
    public GameObject enemie2 = null;
    public GameObject enemie3 = null;


	/* Variable Works
	**************************/ 
	private GameObject Player = null;


	/* Declare Objects
	**************************/

	/* Start & Update
	**************************/

	void Start() {
		Player = GameObject.FindGameObjectWithTag ("Player");
        float nmbrOfEnemies =Mathf.Round(config.heightOfWater * config.LevelSize * 2 / DifferenceBetweenLines);
        for(int i=0;i<nmbrOfEnemies;i++)
        {
            if(i==nmbrOfEnemies-1)
            {
                createNewLine(enemie2,i*3/2);
            }
            else
            {
                int y=Random.Range(0,2);
                //print(y);
                if(y==1)
                {
                    createNewLine(enemie1, i);
                }
                else
                {
                    createNewLine(enemie3, i);
                }
                
            }
            
        }
	}

	void Update () {
		/*if (checkToCreateNewLine ()) {
			createNewLine ();
		}*/

       // print(config.heightOfWater * config.LevelSize * 2 - config.hero.transform.position.y);
	}

	/* Collision detecting
	*************************
	void OnCollisionEnter2D(Collision2D C){

	}

	void OnCollisionExit2D(Collision2D C){

	}

	void OnCollisionStay2D(Collision2D C){

	}*/


	/* Core
	**************************/
	private float getPositionOfLastLineByTag(string LinetagName){
		GameObject[] lines = null;
		lines = GameObject.FindGameObjectsWithTag(LinetagName);

		bool isFirst = true;
		float resultPositionYOfLastLine = 0.0f;
		int counterLine = 0;

		foreach (GameObject line in lines) {

			counterLine++;

			if (isFirst) {
				resultPositionYOfLastLine = line.transform.position.y;
				isFirst = false;
			} else {
				if (line.transform.position.y > resultPositionYOfLastLine) {
					resultPositionYOfLastLine = line.transform.position.y;
				}

			}



		}

		return resultPositionYOfLastLine;
	}
	private bool checkToCreateNewLine(){
		if (Player.transform.position.y >= getPositionOfLastLineByTag ("line_middle")) {
			return true;
		} else {
			return false;
		}
	}
	private void createNewLine(GameObject go,int i){
		GameObject GO = null;
		//for (int i = 0; i < LineToDisplay; i++) {
       //     if (config.heightOfWater * config.LevelSize * 2-config.hero.transform.position.y >= 5 )
         //   {
                GO = GameObject.Instantiate(go, new Vector3(0, i * DifferenceBetweenLines, 0), Quaternion.identity) as GameObject;
           /* }
            else
            {
                GO = GameObject.Instantiate(enemie2, new Vector3(0, (getPositionOfLastLineByTag("enemy_circle") + DifferenceBetweenLines), 0), Quaternion.identity) as GameObject;
            }
                 */
            /*
			if (i == (LineToDisplay / 2)) {
				GO.tag = "line_middle";
			}*/

		//}
	}


}
