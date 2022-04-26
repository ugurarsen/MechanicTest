using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : Singleton<TouchHandler>
{
    
    private delegate void OnDownAction();
    private OnDownAction OnDown = null;
    private delegate void OnUpAction();
    private OnUpAction OnUp = null;
    private delegate void OnDragAction();
    private OnDragAction OnDrag = null;

    private bool isDragging = false;
    private bool canPlay = false;
    
    
    private Vector3 fp, lp, dif;
    
    public bool IsActive() => GameManager.isRunning && canPlay;
    public void Enable(bool isActive) => canPlay = isActive;
    
    
    
    
    public void OnGameStarted()
    {
        
        Enable(true);
    }

    private void Start()
    {
        OnDown = CoreDown;
        OnUp = CoreUp;
        OnDrag = CoreDrag;
        
    }

    private void Update()
    {
        HandleTouch();
    }

    void HandleTouch()
    {
        Debug.Log("Handle");
        if (!isDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnDown?.Invoke();
                isDragging = true;
            }
        }
        else
        {
            OnDrag?.Invoke();

            if (Input.GetMouseButtonUp(0))
            {
                OnUp?.Invoke();
                isDragging = false;
            }
        }
    }
    
    void CoreDown()
    {
        Debug.Log("Dif"+dif);
        fp = Input.mousePosition;
        Debug.Log(fp);
    }
    void CoreUp()
    {
        dif = Vector3.zero;
        PlayerController.S.StopRun();
    }

    void CoreDrag()
    {
        lp = Input.mousePosition;
        dif = lp - fp;
        PlayerController.S.Move(dif);
    }
}
