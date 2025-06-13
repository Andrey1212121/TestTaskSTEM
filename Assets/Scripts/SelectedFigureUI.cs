using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedFigureUI : MonoBehaviour
{
    public Image imageShape;
    //public Color colorShape;
    public Image imageAnimal;

    public void SetFigure(Sprite shape, Color color, Sprite animal)
    {
        imageShape.sprite = shape;
        imageShape.color = color;
        imageAnimal.sprite = animal;
    }
}
