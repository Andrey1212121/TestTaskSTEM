using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SelectedFigureUI[] selectedFigures;

    public Sprite defaultSpriteShape;
    public Color defaultColorShape;
    public Sprite defaultSpriteAnimal;

    public void UpdateFigure(List<FigureAnimal> figures)
    {
        for (int i = 0; i < figures.Count; i++)
        {

            selectedFigures[i].SetFigure(figures[i].shapeFigure.sprite, figures[i].shapeFigure.color, figures[i].animalFigure.sprite);
        }
        for (int j = figures.Count; j < 7; j++)
        {
             selectedFigures[j].SetFigure(defaultSpriteShape, defaultColorShape, defaultSpriteAnimal);
        }
    }
}
