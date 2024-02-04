using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    //LootManager Variable
    public static LootManager instance;
    private List<GameObject> coinList = new List<GameObject>();
    private int maxCoins = 20;
    [SerializeField] private GameObject coinPrefab; //[SerializeField] lets the variable be accessible to Unity editor, but not public to the rest
    [SerializeField] private Transform coinParent;

    void Awake()
    {
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxCoins; i++){
            Vector3 randomSpawnPoint = new Vector3(Random.Range(-40, 41), 2.5f, Random.Range(-40, 41));
            GameObject coin = Instantiate(coinPrefab, randomSpawnPoint, Quaternion.Euler(90, 0, 0), coinParent);
            coin.SetActive(false);
            coinList.Add(coin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnCoin(){ // called via StartCoroutine(spawnCoin());
        yield return new WaitForSeconds(2f);
        Vector3 randomSpawnPoint = new Vector3(Random.Range(-40, 41), 2.5f, Random.Range(-40, 41));
        Instantiate(coinPrefab, randomSpawnPoint, Quaternion.Euler(90, 0, 0), coinParent); //Spawn coinPrefabs with 90 degree rotation; Assign parent to coinParent
    }

    public GameObject getCoin(){ //Based on Introduction To Object Pooling In Unity - https://www.youtube.com/watch?v=YCHJwnmUGDk
        for(int i = 0; i < coinList.Count; i++){
            if(!coinList[i].activeInHierarchy){
                return coinList[i];
            }
        }

        return null;
    }
}
