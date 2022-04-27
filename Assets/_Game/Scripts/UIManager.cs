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

    [SerializeField] private float _coundSecond;
    
    
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
        public TextMeshProUGUI diamonMain, collectDiamondGameIn, diamondFinish, collectDiamondFinish;
    }

    private CanvasGroup activePanel = null;
    public Panels GetPanel() => pnl;
    public Buttons GetButtons() => btn;

    private int _collectDiamond = 0;
    #endregion

    
    
    #region UIChanger

    public void CollectDiamond(int add)
    {
        _collectDiamond += add;
        txt.collectDiamondGameIn.text = _collectDiamond.ToString();
        if (_collectDiamond >= 100)
        {
            GameManager.OnCompleted();
        }
    }
    
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        btn.play.gameObject.SetActive(true);
        txt.diamonMain.text = SaveLoadManager.GetDiamond().ToString();
        txt.collectDiamondGameIn.text = _collectDiamond.ToString();
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
        txt.collectDiamondFinish.text = _collectDiamond.ToString();
        StartCoroutine(FinishCollectCounter());
        btn.contuniue.gameObject.SetActive(true);
        FadeInAndOutPanels(pnl.success);
    }

    IEnumerator FinishCollectCounter()
    {
        var second = _coundSecond / _collectDiamond;
        var tempDiamond = SaveLoadManager.GetDiamond();
        SaveLoadManager.AddDiamond(_collectDiamond);
        txt.diamondFinish.text = tempDiamond.ToString();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(second);
            tempDiamond++;
            _collectDiamond--;
            txt.collectDiamondFinish.text = _collectDiamond.ToString();
            txt.diamondFinish.text = tempDiamond.ToString();

        }
        
        
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
