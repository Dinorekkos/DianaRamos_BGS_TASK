using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterBodyData", menuName = "BGS/Character/CharacterBodyData", order = 0)]
public class CharacterBodyData : ScriptableObject
{
    public List<BodyPart> characterBodyParts;
}


[Serializable]
public class BodyPart
{
    public string bodyPartName;
    public CharacterPartData bodyPart;
    
}