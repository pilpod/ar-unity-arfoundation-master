using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct ModelInfo
{
    public GameObject model;
    public string description;
    public bool isActivated;
}

public class UpdateModelInfo : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _titleTxt;
    [SerializeField] private TextMeshProUGUI _descriptionTxt;

    public void ReceiveData(ModelInfo data)
    {
        _titleTxt.text = data.model.name;
        _descriptionTxt.text = data.description;
    }
    
}
