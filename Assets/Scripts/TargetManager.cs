using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    GameObject Menu;
    [SerializeField]
    GameObject Printer;
    [SerializeField]
    GameObject Lamp;
    [SerializeField]
    GameObject Vaas;
    [SerializeField]
    GameObject VStat;
    [SerializeField]
    GameObject LStat;
    [SerializeField]
    GameObject PStat;
    [SerializeField]
    GameObject targetPrefabBasic;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject targetPrefabBonus;
    [SerializeField]
    GameObject targetPrefabMalus;
    float counter = 0.0f;
    int targetPrefabBasicCounter = 0;
    int targetPrefabBonusCounter = 0;
    int targetPrefabMalusCounter = 0;
    bool menuActive = false;
    bool started = false;
    List<GameObject> Targets = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 2 && menuActive == false && started == true)
        {
            int xcount = Random.Range(1, 10);
            int xposition = Random.Range(-4, 4);
            int zposition = Random.Range(0, 7);
            if (xcount < 2)
            {
                GameObject target = Instantiate(targetPrefabMalus, new Vector3(xposition, 1, zposition), Quaternion.identity);
                target.GetComponent<MalusTarget>().SetPlayer(player);
                Targets.Add(target);

            }
            else if (xcount < 3)
            {
                GameObject target = Instantiate(targetPrefabBonus, new Vector3(xposition, 1, zposition), Quaternion.identity);
                target.GetComponent<BonusTarget>().SetPlayer(player);
                Targets.Add(target);
            }
            else
            {
                GameObject target = Instantiate(targetPrefabBasic, new Vector3(xposition, 1, zposition), Quaternion.identity);
                target.GetComponent<NormalTarger>().SetPlayer(player);
                Targets.Add(target);
            }
            counter = 0;
        }
        counter += Time.deltaTime;
    }
    public void SetMenuActive(bool menu)
    {
        menuActive = menu;
        if (menuActive == false)
        {
            Menu.SetActive(false);
        }
    }
    public void Restart()
    {
        counter = 0;
        player.GetComponent<PlayerManager>().Reset();
        DeleteTargets();

    }
    public void Starter()
    {
        started = true;
        Printer.SetActive(false);
        Lamp.SetActive(false);
        Vaas.SetActive(false);
        VStat.SetActive(false);
        LStat.SetActive(false);
        PStat.SetActive(false);
    }
    public void Back()
    {
        DeleteTargets();
        Menu.SetActive(false);
        started = false;
        Printer.SetActive(true);
        Lamp.SetActive(true);
        Vaas.SetActive(true);
        VStat.SetActive(true);
        LStat.SetActive(true);
        PStat.SetActive(true);
    }
    void DeleteTargets()
    {
        for (int i = 0; i < Targets.Count; i++)
        {

            Destroy(Targets[i]);
        }
    }
}
