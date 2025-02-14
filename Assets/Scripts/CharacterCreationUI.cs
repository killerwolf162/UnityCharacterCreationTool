using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using UnityEngine.UIElements;
using System.Xml.Serialization;
using UnityEngine.Events;

public class CharacterCreationUI : MonoBehaviour
{

    public Button headForward, headBackward, 
        chestForward, chestBackward, 
        legForward, legBackward, 
        feetForward, feetBackward;

    private List<List<Sprite>> imageListList = new List<List<Sprite>>();
    public VisualElement headDisplay, chestDisplay, legDisplay, feetDisplay;
    private List<Sprite> headImages = new List<Sprite>();
    private List<Sprite> chestImages = new List<Sprite>();
    private List<Sprite> legImages = new List<Sprite>();
    private List<Sprite> feetImages = new List<Sprite>();

    [SerializeField] private int headIndex = 0, chestIndex = 0, legIndex = 0, feetIndex = 0;

    private ImageLoader loader;


    private void Awake()
    {
        #region Fill list
        imageListList.Add(headImages);
        imageListList.Add(chestImages);
        imageListList.Add(legImages);
        imageListList.Add(feetImages);
        #endregion

        loader = GetComponent<ImageLoader>();
        loader.onImageLoaded.AddListener(UpdateList);

        #region UI Init
        var root = GetComponent<UIDocument>().rootVisualElement;
        headForward = root.Q<Button>("headforward");
        headBackward = root.Q<Button>("headbackward");
        chestForward = root.Q<Button>("chestforward");
        chestBackward = root.Q<Button>("chestbackward");
        legForward = root.Q<Button>("legsforward");
        legBackward = root.Q<Button>("legsbackward");
        feetForward = root.Q<Button>("feetforward");
        feetBackward = root.Q<Button>("feetbackward");

        headDisplay = root.Q<VisualElement>("headdisplay");
        chestDisplay = root.Q<VisualElement>("chestdisplay");
        legDisplay = root.Q<VisualElement>("legdisplay");
        feetDisplay = root.Q<VisualElement>("feetdisplay");

        headForward.clicked += headForwardClicked;
        headBackward.clicked += headBackwardClicked;
        chestForward.clicked += chestForwardClicked;
        chestBackward.clicked += chestBackwardClicked;
        legForward.clicked += legForwardClicked;
        legBackward.clicked += legBackwardClicked;
        feetForward.clicked += feetForwardClicked;
        feetBackward.clicked += feetBackwardClicked;
        #endregion
    }

    public void UpdateList()
    {

        for (int i = 0; i < imageListList.Count; i++)
        {
            foreach (var image in loader.imageCategories[i].imageList)
            {
                imageListList[i].Add(image);
            }
        }

        Debug.Log("Lists updated");
    }

    private void SetImage(VisualElement visElement, List<Sprite> spriteList, int index)
    {
        var texture = spriteList[index];
        visElement.style.backgroundImage = new StyleBackground(texture);
    }

    private void headForwardClicked()
    {
        SetImage(headDisplay, headImages, headIndex);
        headIndex++;
    }

    private void headBackwardClicked()
    {
        SetImage(headDisplay, headImages, headIndex);
        headIndex--;
    }

    private void chestForwardClicked()
    {
        SetImage(chestDisplay, chestImages, chestIndex);
        chestIndex++;
    }

    private void chestBackwardClicked()
    {
        SetImage(chestDisplay, chestImages, chestIndex);
        chestIndex--;
    }

    private void legForwardClicked()
    {
        SetImage(legDisplay, legImages, legIndex);
        legIndex++;
    }

    private void legBackwardClicked()
    {
        SetImage(legDisplay, legImages, legIndex);
        legIndex--;
    }

    private void feetForwardClicked()
    {
        SetImage(feetDisplay, feetImages, feetIndex);
        feetIndex++;
    }

    private void feetBackwardClicked()
    {
        SetImage(feetDisplay, feetImages, feetIndex);
        feetIndex--;
    }
}
