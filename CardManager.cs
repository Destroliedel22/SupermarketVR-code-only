using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    GameObject productCard;

    [SerializeField]
    GameObject cardParent;

    [SerializeField]
    public List<GameObject> Cards = new List<GameObject>();

    private void Start()
    {
        SpawnCards();
    }

    private void SpawnCards()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject clone = Instantiate(productCard, cardParent.transform);
            Cards.Add(clone);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Cards.RemoveAt(Cards.Count - 1);
            Destroy(cardParent);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Cards.Add(productCard);
        }
    }
}
