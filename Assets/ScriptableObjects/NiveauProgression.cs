using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Progression", fileName = "Niveau00")]
public class NiveauProgression : ScriptableObject
{
    [Header("Ennemis")]
    public int nbEnnemi;
    public int nbEnnemiMax;

    public bool[] objects;
}
