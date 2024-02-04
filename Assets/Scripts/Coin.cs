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

    // private void OnCollisionEnter(Collision collider){
    //     } else if(collider.gameObject.tag == "Coin"){
    //         collider.gameObject.SetActive(false);
    //         this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resetting velocity to 0 so that if active again, that force no longer applies
    //         this.gameObject.SetActive(false);
    //     }
    // }

    public static void resetCoinValue(){
        Debug.Log("Hello!");
    }
}
