using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TopDownButton : MonoBehaviour, IPointerClickHandler
{
    public Camera PlayerCamera;
    public float Speed = 0.5f;
    private Vector3 TopPos = new Vector3(-3.3f, 6.6f, -1.25f);
    private Vector3 DownPos = new Vector3(-1.46f, 6.6f, -1.25f);
    private Vector3 TargetPos;
    private bool IsDown = false;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.transform.Rotate(0, 0, 180);
        MoveCamera();
    }

    void MoveCamera()
    {
        if(IsDown)
        {
            IsDown = false;
            TargetPos = TopPos;
            
        }
        else 
        {
            IsDown = true;
            TargetPos = DownPos;
        }
    }

    void Start()
    {
        TargetPos = PlayerCamera.transform.position;
    }

    void Update()
    {
        if(PlayerCamera.transform.position != TargetPos)
        {
            PlayerCamera.transform.position = Vector3.Lerp(PlayerCamera.transform.position, TargetPos, Speed * Time.deltaTime);
        }
    }
}
