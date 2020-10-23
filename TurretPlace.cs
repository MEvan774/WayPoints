using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretPlace : MonoBehaviour
{
    public GameObject[] turrets;
    private GameObject currentTurret;

    public UnityEvent placeEvent;

    public HotbarButton buttons;
    private int keyCode;

    private float mouseWheel;

    public bool isHolding = false;

    private void Awake()
    {
        foreach (var button in GetComponentsInChildren<HotbarButton>())
            button.OnButtonClicked += ButtonOnButtonClicked;
    }

    private void Update()
    {
        if(currentTurret != null)
        {
            isHolding = true;
            MoveTurret();
            RotateTurret();
            ReleaseTurret();
        }
    }

    private void MoveTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            currentTurret.transform.position = hitInfo.point;
            currentTurret.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    void RotateTurret()
    {
        mouseWheel += Input.mouseScrollDelta.y;
        currentTurret.transform.Rotate(Vector3.up, mouseWheel * 10f);
    }

    private void ReleaseTurret()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isHolding = false;
            placeEvent.Invoke();
            currentTurret = null;
        }
    }

    private void ButtonOnButtonClicked(int buttonNumber)
    {
        if (currentTurret != null)
        {
            isHolding = false;
            Destroy(currentTurret);
        }
            currentTurret = Instantiate(turrets[buttonNumber]);
            //turrets[buttonNumber];
        //Debug.Log(message: $"Button {buttonNumber} clicked!");
    }
}
