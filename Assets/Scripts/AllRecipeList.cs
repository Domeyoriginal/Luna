using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllRecipeList : MonoBehaviour 
{
    public ItemObject material;

    private void Start()
    {
        print(material.Name);
    }
}
