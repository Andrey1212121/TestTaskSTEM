using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    public List<FigureAnimal> figureAnimalsSelected = new List<FigureAnimal>(7);


    public void AddFigure(FigureAnimal selectFigure)
    {
        figureAnimalsSelected.Add(selectFigure);
        CheckFigures();
        Debug.Log(figureAnimalsSelected);
    }

    public void CheckFigures()
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

    public void DeleteThree(string DeletedID) 
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
            figureAnimalsSelected.Remove(figure); // Удаляем из списка
            Destroy(figure.gameObject);            // Уничтожаем GameObject
        }

        toRemove.Clear();
    }
}
