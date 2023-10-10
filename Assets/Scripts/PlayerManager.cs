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
    [SerializeField]
    GameObject ScoreTXT;
    [SerializeField]
    GameObject HighScoreTXT;
    [SerializeField]
    GameObject LevensTXT;
    bool MenuBool = false;
    int score = 0;
    int highscore = 0;
    bool dubblePoints = false;
    float dubblePointsCountDown = 0;
    float dubblePointsTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        Pointer.SetActive(false);
        ScoreTXT.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
        HighScoreTXT.GetComponent<TMPro.TextMeshProUGUI>().text = "Highscore: " + highscore;
        LevensTXT.GetComponent<TMPro.TextMeshProUGUI>().text = "Levens: " + aantalLevens;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            Menu.SetActive(true);
            Pointer.SetActive(true);
        }
        if (dubblePoints == true && dubblePointsCountDown >= dubblePointsTime){
            dubblePoints = false;
        }
        else if (dubblePoints == true){
            dubblePointsCountDown+=Time.deltaTime;
        }
    }
    

    public void Ontploft(){
        if(aantalLevens>0)
        {aantalLevens--;
        }
        else{
            Debug.Log("Game Over");
            GameOver();
        }
        LevensTXT.GetComponent<TMPro.TextMeshProUGUI>().text = "Levens: " + aantalLevens;
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
            HighScoreTXT.GetComponent<TMPro.TextMeshProUGUI>().text = "Highscore: " + highscore;
        }
        else{
        }
        ScoreTXT.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
    }

    public void Reset() {
        score = 0;
        aantalLevens = 3;
    }
    public void DubblePoints(float tijd){
        dubblePoints = true;
        dubblePointsCountDown = 0;
        dubblePointsTime = tijd;
    }
    public void GameOver(){
        aantalLevens = 0;
        Debug.Log("Game Over");
        Menu.SetActive(true);
        Pointer.SetActive(true);
        LevensTXT.GetComponent<TMPro.TextMeshProUGUI>().text = "Levens: " + aantalLevens;
    }
    public void SetAantalLevens(int levens){
        aantalLevens = levens;
    }
}
