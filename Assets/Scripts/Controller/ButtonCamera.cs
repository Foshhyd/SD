using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCamera : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Player;
    [SerializeField] private float Angle;
    private bool ButtonDown;
    public void OnPointerDown(PointerEventData pointerEventData) 
    {
        ButtonDown = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        ButtonDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonDown)
        {
            Player.transform.Rotate(0, Angle, 0);
        }
    }
}
