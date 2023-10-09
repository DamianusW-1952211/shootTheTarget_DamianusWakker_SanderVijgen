using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int aantalLevens;
    [SerializeField]
    GameObject Menu;
    [SerializeField]
    GameObject Pointer;
    bool MenuBool = false;
    int score = 0;
    int highscore = 0;
    bool dubblePoints = false;
    int dubblePointsCountDown = 0;
    int dubblePointsTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        Pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            Menu.SetActive(true);
            Pointer.SetActive(true);
        }
        if (dubblePoints == true && dubblePointsCountDown == dubblePointsTime){
            dubblePoints = false;
        }
        else{
            dubblePointsCountDown++;
        }
    }
    

    public void Ontploft(){
        if(aantalLevens>0)
        {aantalLevens--;
        }
        else{
            Debug.Log("Game Over");
            Reset();
        }
    }

    public void IsRaak(int hitScore){
        if(dubblePoints == false){
        score = score + hitScore;
        }
        else{
            score = score + (hitScore*2);
        }
        if (score > highscore){
            highscore = score;
            Debug.Log("New Highscore: " + highscore);
        }
        else{
            Debug.Log("Score: " + score);
        }
    }

    public void Reset() {
        score = 0;
        aantalLevens = 3;
    }
    public void DubblePoints(int tijd){
        dubblePoints = true;
        dubblePointsCountDown = 0;
        dubblePointsTime = tijd;
    }
    public void GameOver(){
        aantalLevens = 0;
        Debug.Log("Game Over");
        Reset();
    }
}
