using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    public Button Active;
    private int ActiveOrNot = 1;

    public GameObject canvasCurve;
    public GameObject canvasButton;
    public GameObject MainCanvas;
    public GameObject EventCanvas;

    public Button ButtonCanvas;
    public bool IsGameStarting = false;

    public void OnClickActive()
    {
        CanvasGroup canvasGroup = canvasCurve.GetComponent<CanvasGroup>();

        if(Active.IsInteractable())
        {
            if(ActiveOrNot == 1 )
            {
                canvasGroup.alpha = (canvasGroup.alpha == 0) ? 1 : 0;
                canvasGroup.interactable = !canvasGroup.interactable;
                canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
                canvasButton.SetActive(false);
                EventCanvas.SetActive(false);
                ActiveOrNot= 2;
            }
            if(ActiveOrNot == 2 )
            {
                canvasGroup.alpha = (canvasGroup.alpha == 0) ? 1 : 0;
                canvasGroup.interactable = !canvasGroup.interactable;
                canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
                canvasButton.SetActive(true);
                EventCanvas.SetActive(false);
                ActiveOrNot= 3;
            }
            else
            {
                canvasGroup.alpha = (canvasGroup.alpha == 0) ? 1 : 0;
                canvasGroup.interactable = !canvasGroup.interactable;
                canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
                canvasButton.SetActive(false);
                EventCanvas.SetActive(true);
                ActiveOrNot= 1;
            }
            
        }
    }

    public void OnClickCanvas()
    {
        if(ButtonCanvas.IsInteractable())
        {
            MainCanvas.SetActive(false);
            IsGameStarting = true;
            if(ActiveOrNot == 1 )
            {
                CanvasGroup canvasGroup = canvasCurve.GetComponent<CanvasGroup>();

                canvasGroup.alpha = (canvasGroup.alpha == 0) ? 1 : 0;
                canvasGroup.interactable = !canvasGroup.interactable;
                canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
                canvasButton.SetActive(false);
                EventCanvas.SetActive(false);
                ActiveOrNot= 2;
            }
            if(ActiveOrNot == 2 )
            {
                canvasButton.SetActive(true);
                EventCanvas.SetActive(false);
                ActiveOrNot= 3;
            }
            else
            {
                canvasButton.SetActive(false);
                EventCanvas.SetActive(true);
                ActiveOrNot= 1;
            }
           
        }
    }
}
