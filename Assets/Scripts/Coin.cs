using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] public int coinValue;
    // Start is called before the first frame update
    void Start()
    {
        coinValue = LootManager.instance.setCoinValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}