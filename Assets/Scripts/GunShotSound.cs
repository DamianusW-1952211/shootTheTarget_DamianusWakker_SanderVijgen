using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource gunShot;
    // Start is called before the first frame update
    void Start()
    {
        gunShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) // need to add that the pistol should be holded down
        {
            playGunShot();
        }
    }

    public void playGunShot()
    {
        gunShot.Play();
        Debug.Log("play sound");
    }
}
