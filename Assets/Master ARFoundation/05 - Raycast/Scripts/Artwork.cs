using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Artwork : MonoBehaviour
{
    [SerializeField] private ArtworkSO _artworkSO;
    [SerializeField] private int _materialId;

    private void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.materials[_materialId].mainTexture = _artworkSO.texture;
    }
}
