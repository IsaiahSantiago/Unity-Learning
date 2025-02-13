using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject Prefab;
    public float timer;
    public float fixedTimer;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f; //f stands for float
        InvokeRepeating("SpawnObj", 1.0f, interval);
        //Can also do InvokeRepeating(nameof(SpawnObj), 1.0f, interval); as suggested via the code program


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }

    private void FixedUpdate() {

        fixedTimer += Time.fixedDeltaTime;
    }


    void SpawnObj()
{
Instantiate(Prefab);
//Instantiate(Prefab, new vector3(4, 3, 0), Quaternion.identity);




}



} //end of update method
















