using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ValidateBounds : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (_renderer == null) return;

        Handles.Label(transform.position, string.Format("Size: {0}", _renderer.bounds.size));
    }

#endif
}
