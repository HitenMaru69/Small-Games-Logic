using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WordDetect : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    GraphicRaycaster graphicRaycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    private Image detectedImage;
    [SerializeField]private Color orignalColor;

    [SerializeField] List<Image> listOfDetectdImage;

    private void Awake()
    {
        graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = FindFirstObjectByType<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (!CheckImageInList(detectedImage))
            {
                detectedImage = GetImage();

                if (detectedImage != null)
                {

                    listOfDetectdImage.Add(detectedImage);
                    if (detectedImage != null)
                    {

                        ChangeColorOfImage(detectedImage);
                        GetWord(detectedImage);
                    }
                }
            }




        }
        if (Input.GetMouseButton(0))
        {
            Image image = GetImage();

            if (!CheckImageInList(image))
            {
                if (image != null && image != detectedImage)
                {

                    detectedImage = image;
                    listOfDetectdImage.Add(detectedImage);
                    if (detectedImage != null)
                    {
                        ChangeColorOfImage(detectedImage);
                        GetWord(detectedImage);

                    }

                }
            }



        }
        if (Input.GetMouseButtonUp(0))
        {
            
            if(UIManager.Instance.wordText.text == UIManager.Instance.word)
            {
                // For Win Logic
                UIManager.Instance.GameOverEventInvoke();
            }
            else
            {
                if(detectedImage != null)
                {
                    detectedImage.color = orignalColor;
                    detectedImage = null;

                    foreach (Image image in listOfDetectdImage)
                    {

                        image.color = orignalColor;
                    }

                    listOfDetectdImage.Clear();
                    UIManager.Instance.wordText.text = "";
                }


            }


        }
    }

    private Image GetImage() {

        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> result = new List<RaycastResult>();

        graphicRaycaster.Raycast(pointerEventData, result);

        foreach(RaycastResult raycastResult in result)
        {
            Image newImage = raycastResult.gameObject.GetComponent<Image>();

            if (newImage != null && newImage.gameObject.tag == "DetectedImage") { 
            
                return newImage;
            }
        }

        return null;
    }

    private void ChangeColorOfImage(Image image)
    {
        orignalColor = image.color; 
        image.color = Color.red;
    }

    private void GetWord(Image image)
    {
        string newWord ;
        TextMeshProUGUI textMeshProUGUI = image.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        newWord = textMeshProUGUI.text;

        UIManager.Instance.wordText.text += newWord;
    }

    private bool CheckImageInList(Image image)
    {
        if (image != null)
        {
            return listOfDetectdImage.Contains(image);
        }
        return false;
    }
}
