using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Progression", fileName = "Niveau00")]
public class NiveauProgression : ScriptableObject
{
    public int ennemiTotal;
    public int ennemiMax;

    public bool[] objects;
}
