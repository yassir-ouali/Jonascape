using UnityEngine;
using System.Collections;

public class map : MonoBehaviour {

    public Material material;
    float width = 10;
    float top;
    Rect position = new Rect(0, 0, 0, 0);
    Rect heroRect = new Rect(0, 0, 0, 0);
    Rect winRect = new Rect(0, 0, 0, 0);

    Color color = Color.blue;
    Color colorBlack = Color.black;
    Color colorGreen = Color.green;

    public GameObject hero;
	// Use this for initialization
	void Start () {
       
        position.y = Screen.height;
       // position.x= Screen.width / 2;
        heroRect.y = Screen.height;
        winRect.y += width/2;

        winRect.size = new Vector2(width, -width/2);
        heroRect.size = new Vector2(width, -width);
	}
	
	// Update is called once per frame
	void Update () {
        top = config.heightOfWater * config.LevelSize / 2;
        float x=-(config.head.transform.position.y )*Screen.height/top;
        position.size = new Vector2(width, x);
       
        float y = -(config.hero.transform.position.y - config.heightOfWater);
        heroRect.position = new Vector2(0, y * Screen.height / top + Screen.height);
        win();
	}

    void OnGUI()
    {
        DrawRectangle(winRect, colorGreen);
        DrawRectangle(heroRect, colorBlack);
        DrawRectangle(position, color);
    }

    void DrawRectangle(Rect position, Color color)
    {
        // We shouldn't draw until we are told to do so.
        if (Event.current.type != EventType.Repaint)
            return;

        // Please assign a material that is using position and color.
        if (material == null)
        {
            Debug.LogError("You have forgot to set a material.");
          //  return;
        }

        material.SetPass(0);

        // Optimization hint: 
        // Consider Graphics.DrawMeshNow
        
        GL.Begin(GL.QUADS);
        GL.Color(color);
        GL.Vertex3(position.x, position.y, 0);
        GL.Vertex3(position.x + position.width, position.y, 0);
        GL.Vertex3(position.x + position.width, position.y + position.height, 0);
        GL.Vertex3(position.x, position.y + position.height, 0);
        GL.End();
    }

    void win()
    {/*
        if (heroRect.y <= winRect.y*4/5)
        {
            config.finish = true;
            config.head.GetComponent<BoxCollider2D>().isTrigger = true;
        }*/
    }
    
}
