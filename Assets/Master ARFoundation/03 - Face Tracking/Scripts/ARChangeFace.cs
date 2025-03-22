using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARChangeFace : MonoBehaviour
{
    [SerializeField] private Texture2D[] _textures;
    [SerializeField] private bool _isLoop;

    [Header("References")]
    [SerializeField] private NavigateArray _navigateArray;
    [SerializeField] private Material _material;

    private void Start()
    {
        _navigateArray.Initialize(_textures.Length, _isLoop, OnChangeFace); 
    }

    private void OnChangeFace(int index)
    {
        _material.SetTexture("_BaseMap", _textures[index]);
    }
}
