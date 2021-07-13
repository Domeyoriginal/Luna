using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe",
    menuName = "Items/Recipe")]
public class PotionRecipe : ScriptableObject
{
    public List<string> Materials;
    public ItemObject Result;
}
