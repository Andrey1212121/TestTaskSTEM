using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite[] spritesShape;
    public Sprite[] spritesAnimal;
    public Color[] colorFigure;
    public GameObject prefabFigure;
    public int countTrio = 7;
    public UIManager uIManager;
    public float spawnDelay = 0.2f; 
    public float spawnRadius = 1f;
    public GameObject LoseImage;
    public GameObject WinImage;

    public List<FigureAnimal> figureAnimalsSelected = new List<FigureAnimal>(7);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFigures()); 
    }

    private IEnumerator SpawnFigures()
    {
        for (int i = 0; i < countTrio; i++)
        {
            int randomIndexShape = UnityEngine.Random.Range(0, spritesShape.Length);
            int randomIndexAnimal = UnityEngine.Random.Range(0, spritesAnimal.Length);
            int randomIndexColor = UnityEngine.Random.Range(0, colorFigure.Length);
            string id = randomIndexShape.ToString() + randomIndexAnimal.ToString() + randomIndexColor.ToString();
            for (int j = 0; j < 3; j++)
            {
                StartCoroutine(CreateFigure(randomIndexShape, randomIndexAnimal, randomIndexColor, id));
                yield return new WaitForSeconds(spawnDelay); 
            }
            yield return new WaitForSeconds(spawnDelay); 
        }
    }

    private IEnumerator CreateFigure(int shape, int animal, int color, string id)
    {
      
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

        GameObject figure = Instantiate(prefabFigure, spawnPosition, transform.rotation);
        figure.GetComponent<FigureAnimal>().gameManager = this;
        figure.GetComponent<FigureAnimal>().SetInfo(spritesShape[shape], spritesAnimal[animal], colorFigure[color], id);
        yield return null; 
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void AddFigure(FigureAnimal selectFigure)
    {
        figureAnimalsSelected.Add(selectFigure);
        if (figureAnimalsSelected.Count == 7)
        {
            LoseImage.SetActive(true);
        }
        CheckFigures();
        uIManager.UpdateFigure(figureAnimalsSelected);
        //Debug.Log(figureAnimalsSelected);

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
                uIManager.UpdateFigure(figureAnimalsSelected);
                countTrio--;
                if (countTrio == 0)
                {
                    WinImage.SetActive(true);
                }
                break;

            }
        }

        
    }

    private void DeleteThree(string DeletedID)
    {
        List<FigureAnimal> toRemove = new List<FigureAnimal>();

        foreach (FigureAnimal figure in figureAnimalsSelected)
        {
            if (figure.ID == DeletedID)
            {
                toRemove.Add(figure);
                
            }
        }


        foreach (FigureAnimal figure in toRemove)
        {
            figureAnimalsSelected.Remove(figure);
            Destroy(figure.gameObject);
        }

        toRemove.Clear();

    }


}
