using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    
    #region VERIBLES

    [Header("Panels")]
    [SerializeField] Panels pnl;
    [Header("Buttons")]
    [SerializeField] Buttons btn;
    [Header("Texts")]
    [SerializeField] Texts txt;

    [Range(0.01f, 2f)]
    [SerializeField] private float _fade;
    
    
    
    [System.Serializable]
    public class Panels
    {
        public CanvasGroup mainMenu, gameIn, success;
    }
    [System.Serializable]
    public class Buttons
    {
        public Button play, contuniue;
    }
    [System.Serializable]
    public class Texts
    {
        public TextMeshProUGUI diamonMain, collectDiamondGameIn, diamondFinis, collectDiamondFinish;
    }

    private CanvasGroup activePanel = null;
    public Panels GetPanel() => pnl;
    public Buttons GetButtons() => btn;
    
    #endregion

    
    
    #region UIChanger

    public void Initialize(bool isButtonDerived)
    {
        btn.play.gameObject.SetActive(isButtonDerived);
        FadeInAndOutPanels(pnl.mainMenu);
    }
    
    public void StartGame()
    {
        GameManager.OnStartGame();
    }

    public void OnGameStarted()
    {
        activePanel = pnl.mainMenu;
        FadeInAndOutPanels(pnl.gameIn);
    }
    
    public void OnSuccess()
    {
        btn.contuniue.gameObject.SetActive(true);
        FadeInAndOutPanels(pnl.success);
    }
    
    void FadeInAndOutPanels(CanvasGroup _in)
    {
        CanvasGroup _out = activePanel;
        activePanel = _in;

        if(_out != null)
        {
            _out.interactable = false;
            _out.blocksRaycasts = false;

            _out.DOFade(0f, _fade).OnComplete(() =>
            {
                _in.DOFade(1f, _fade).OnComplete(() =>
                {
                    _in.interactable = true;
                    _in.blocksRaycasts = true;
                });
            });
        }
        else
        {
            _in.DOFade(1f, _fade).OnComplete(() =>
            {
                _in.interactable = true;
                _in.blocksRaycasts = true;
            });
        }
    }
    
    public void ReloadScene()
    {
        GameManager.ReloadScene();
    }
    

    #endregion
}
