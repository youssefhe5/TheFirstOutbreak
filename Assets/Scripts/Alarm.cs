using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{

    public float alarmStartTime = 5f;

    public GameObject alarm;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAlarm());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator StartAlarm()
    {
        yield return new WaitForSeconds(alarmStartTime);
        alarm.SetActive(true);
    }
}
