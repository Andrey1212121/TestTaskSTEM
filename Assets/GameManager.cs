using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Sprite[] spritesShape;
    public Sprite[] spritesAnimal;
    public Color[] colorFigure;
    public GameObject prefabFigure;
    public int countTrio = 7;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < countTrio; i++)
        {
            int randomIndexShape = UnityEngine.Random.Range(0, spritesShape.Length);
            int randomIndexAnimal = UnityEngine.Random.Range(0, spritesAnimal.Length);
            int randomIndexColor = UnityEngine.Random.Range(0, colorFigure.Length);
            for (int j = 0; j < 3; j++)
            {
                GameObject figure = Instantiate(prefabFigure, transform.position, transform.rotation);
                Debug.Log(randomIndexAnimal);
                Debug.Log(randomIndexShape);
                Debug.Log(randomIndexColor);
                figure.GetComponent<FigureAnimal>().SetInfo(spritesShape[randomIndexShape], spritesAnimal[randomIndexAnimal], colorFigure[randomIndexColor]);

            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
