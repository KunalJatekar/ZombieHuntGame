using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Joystiick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{

    private Image bgImage;
    private Image joystick;

    public Vector3 InputDirection;

    public Animationp animationp;
    public Movement movement;

    void Start()
    {

        bgImage = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (bgImage.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out position);

        position.x = (position.x / bgImage.rectTransform.sizeDelta.x);
        position.y = (position.y / bgImage.rectTransform.sizeDelta.y);

        float x = (bgImage.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        //float y = (bgImage.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputDirection = new Vector3(x, 0, 0);  // InputDirection = new Vector3(x, y, 0); if we want to move at x and y both
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImage.rectTransform.sizeDelta.x / 3)
                                                               , InputDirection.y * (bgImage.rectTransform.sizeDelta.y/ 3));



        animationp.Run();
        movement.movespeed = 5;
    }

    public void OnPointerDown(PointerEventData ped)
    {

        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {

        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;


        animationp.NotRun();
        movement.movespeed = 0;

    }

    /*public Vector3 Direct()
    {
        return InputDirection;
    }*/

    public float Horizontal()
    {
        return InputDirection.x;
    }

    public void Atend()
    {
        InputDirection = new Vector3(0, 0, 0);
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
