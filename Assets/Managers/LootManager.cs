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
    private int[] coinValuesList = {10, 20, 30};

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
            GameObject coin = Instantiate(coinPrefab, randomSpawnPoint, Quaternion.Euler(90, 0, 0), coinParent); //Spawn coinPrefabs with 90 degree rotation; Assign parent to coinParent
            coin.tag = "Coin"; //Setting tag
            coin.SetActive(false);
            coinList.Add(coin);
        }

        StartCoroutine(spawnCoin()); //Starting coroutine
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnCoin(){ // called via StartCoroutine(spawnCoin());
        while(true){ //Infinite loop
            yield return new WaitForSeconds(1.5f);
            Vector3 randomSpawnPoint = new Vector3(Random.Range(-40, 41), 2.5f, Random.Range(-40, 41)); //Generating random spawn point

            GameObject newCoin = getCoin();
            if(newCoin != null){ //Acquires inactive coin from pull, changes position on map, and sets to active
                newCoin.transform.position = randomSpawnPoint;
                newCoin.transform.rotation = Quaternion.Euler(0, Random.Range(-180, 181), -90); //Randomly adjusting y rotation of coin - https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
                newCoin.SetActive(true);
            } //This coroutine will keep spawning until there are 20 active coins
        }
    }

    public GameObject getCoin(){ //Based on Introduction To Object Pooling In Unity - https://www.youtube.com/watch?v=YCHJwnmUGDk
        for(int i = 0; i < coinList.Count; i++){
            if(!coinList[i].activeInHierarchy){
                return coinList[i];
            }
        }

        return null;
    }

    public int generateCoinValue(){
        int randomIndex = Random.Range(0, 3); //Generate random integer from 0 to 2
        return coinValuesList[randomIndex];
    }
}
