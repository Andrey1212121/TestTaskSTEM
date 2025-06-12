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

    public List<FigureAnimal> figureAnimalsSelected = new List<FigureAnimal>(7);

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < countTrio; i++)
        {
            int randomIndexShape = UnityEngine.Random.Range(0, spritesShape.Length);
            int randomIndexAnimal = UnityEngine.Random.Range(0, spritesAnimal.Length);
            int randomIndexColor = UnityEngine.Random.Range(0, colorFigure.Length);
            string id = randomIndexShape.ToString() + randomIndexAnimal.ToString() + randomIndexColor.ToString();
            for (int j = 0; j < 3; j++)
            {
                GameObject figure = Instantiate(prefabFigure, transform.position, transform.rotation);
                figure.GetComponent<FigureAnimal>().gameManager = this;
                //Debug.Log(randomIndexAnimal);
                //Debug.Log(randomIndexShape);
                //Debug.Log(randomIndexColor);
                //Debug.Log(id);
                figure.GetComponent<FigureAnimal>().SetInfo(spritesShape[randomIndexShape], spritesAnimal[randomIndexAnimal], colorFigure[randomIndexColor], id);
            }

        }
    }


    public void AddFigure(FigureAnimal selectFigure)
    {
        figureAnimalsSelected.Add(selectFigure);
        CheckFigures();
        Debug.Log(figureAnimalsSelected);
    }

    private void CheckFigures()
    {
        Dictionary<string, int> idCounts = new Dictionary<string, int>();

        foreach (FigureAnimal figure in figureAnimalsSelected)
        {
            if (idCounts.ContainsKey(figure.ID))
            {
                idCounts[figure.ID]++;
            }
            else
            {
                idCounts[figure.ID] = 1;
            }
        }

        foreach (var pair in idCounts)
        {
            if (pair.Value >= 3)
            {
                DeleteThree(pair.Key); 
                break;
            }
        }
    }

    private void DeleteThree(string DeletedID) 
    {
        List<FigureAnimal> toRemove = new List<FigureAnimal>();
        //int count = 0;

        
        foreach (FigureAnimal figure in figureAnimalsSelected)
        {
            if (figure.ID == DeletedID)
            {
                toRemove.Add(figure);
              //  count++;
            }
        }

        // Удаляем найденные фигуры
        foreach (FigureAnimal figure in toRemove)
        {
            figureAnimalsSelected.Remove(figure); 
            Destroy(figure.gameObject);            
        }

        toRemove.Clear();
    }

}
