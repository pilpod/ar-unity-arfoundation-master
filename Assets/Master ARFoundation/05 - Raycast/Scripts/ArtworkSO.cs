using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Artwork", menuName = "Scriptable Object/New Artwork", order = 0)]
public class ArtworkSO : ScriptableObject
{
    public Texture texture;
    public string title;
    public string description;
}
