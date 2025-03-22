using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NavigateArray : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Button _backBtn;
    [SerializeField] private Button _nextBtn;

    public UnityAction<int> OnMove;

    private int _currentIndex;
    private int _arrayLength;
    private bool _isLoop;

    public void Initialize(int arrayLength, bool isLoop, UnityAction<int> callback)
    {
        _currentIndex = 0;
        _arrayLength = arrayLength - 1;
        _isLoop = isLoop;
        OnMove = callback;

        _backBtn.onClick.AddListener(MoveBack);
        _nextBtn.onClick.AddListener(MoveNext);

        CheckButtonState();
    }

    private void MoveNext()
    {
        _currentIndex++;
        if (_currentIndex > _arrayLength)
        {
            _currentIndex = _isLoop ? 0 : _arrayLength;
        }

        CheckButtonState();

        OnMove.Invoke(_currentIndex);
    }

    private void MoveBack()
    {
        _currentIndex--;

        if (_currentIndex < 0)
        {
            _currentIndex = _isLoop ? _arrayLength : 0;
        }

        CheckButtonState();

        OnMove.Invoke(_currentIndex);
    }
    private void CheckButtonState()
    {
        if (_isLoop) return;

        _backBtn.interactable = _currentIndex != 0;
        _nextBtn.interactable = _currentIndex != _arrayLength;
    }

}
