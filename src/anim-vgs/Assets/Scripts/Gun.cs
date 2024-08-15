using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Space(10)]
    [Header("MODEL")]
    public GameObject gun;

    [Space(10)]
    [Header("STATS")]
    public int ammo = 50;
    public int maxAmmo = 100;
    public float firerate = 0.2f;
    public float xFirerate = 1.0f;
    public float recoilRate = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
