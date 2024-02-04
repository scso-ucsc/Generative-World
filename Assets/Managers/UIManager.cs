using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    private int playerScore = 0;

    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Score: " + playerScore.ToString(); //Updating score constantly
    }

    public void addScore(int addedValue){
        playerScore += addedValue;
    }
}
