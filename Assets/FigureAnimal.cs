using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureAnimal : MonoBehaviour
{
    public SpriteRenderer shapeFigure;
    public SpriteRenderer animalFigure;

    // Start is called before the first frame update
    public string ID;
    public GameManager gameManager;
    private bool isTouched = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began) 
            {
                // Преобразуем координаты касания в мировые координаты
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0; 
                
                Collider2D targetObject = Physics2D.OverlapPoint(touchPosition);

                if (targetObject == GetComponent<Collider2D>() && !isTouched) 
                {
                    isTouched = true;
                    gameManager.AddFigure(this);
                }
            }
        }
    }
    public void SetInfo(Sprite shape, Sprite animal, Color color, string id)
    {
        shapeFigure.sprite = shape;
        animalFigure.sprite = animal;
        shapeFigure.color = color;
        PolygonCollider2D polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        ID = id;

    }
}
