using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance;
    private List<GameObject> fireBallList = new List<GameObject>();
    [SerializeField] private GameObject fireObj; //[SerializeField] lets the variable be accessible to Unity editor, but not public to the rest
    [SerializeField] private Transform fireBallParent;
    [SerializeField] private float fireSpeed = 1000;
    [SerializeField] private Transform fireBallSpawnpoint;
    [SerializeField] private Transform playerPosition;

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
        for(int i = 0; i < 20; i++){
            Vector3 spawnPoint = new Vector3(0, 0, 0);
            GameObject fireBall = Instantiate(fireObj, spawnPoint, Quaternion.Euler(90, 0, 0), fireBallParent);
            fireBall.SetActive(false);
            fireBallList.Add(fireBall);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(){ //Needs to be public so other Managers can access them
        GameObject fireBallToSpawn = getFireBall();
        if(fireBallToSpawn != null){ //Based on Introduction To Object Pooling In Unity - https://www.youtube.com/watch?v=YCHJwnmUGDk
            fireBallToSpawn.transform.position = fireBallSpawnpoint.position;
            fireBallToSpawn.transform.rotation = playerPosition.transform.rotation; //Rotation needs to be reset too
            fireBallToSpawn.SetActive(true);
        }
        fireBallToSpawn.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fireSpeed);
    }

    private GameObject getFireBall(){
        for(int i = 0; i < 20; i++){ //Finding first object in the FireBall List that isn't active and returning it
            if(!fireBallList[i].activeInHierarchy){
                return fireBallList[i];
            }
        }
        return null;
    }
}
