using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Button RightButton;
    [SerializeField] private Button LeftButton;
    [SerializeField] private float AngleChange;
    [SerializeField] private float TurnSpeed;
    private Transform PlayerTf;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTf = this.transform;
        RightButton.onClick.AddListener(delegate { RotatePlayer(AngleChange); });
        LeftButton.onClick.AddListener(delegate { RotatePlayer(-AngleChange); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotatePlayer(float Angle)
    {
        PlayerTf.Rotate(0, Angle, 0);
    }
}
