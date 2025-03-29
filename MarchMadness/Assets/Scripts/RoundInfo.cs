using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundInfo : MonoBehaviour
{
    public static RoundInfo instance;
    public int PointTotal { get; private set; } = 0;
    public bool RoundActive { get; private set; } = true;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //RoundActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int addedPoints)
    {
        PointTotal += addedPoints;
        Debug.Log(PointTotal);
    }
}
