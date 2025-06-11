using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureAnimal : MonoBehaviour
{
    public SpriteRenderer shapeFigure;
    public SpriteRenderer animalFigure;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInfo(Sprite shape, Sprite animal, Color color)
    {
        shapeFigure.sprite = shape;
        animalFigure.sprite = animal;
        shapeFigure.color = color;
        PolygonCollider2D polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        
    }
}
