using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    string currentState;
    string nextState;

    [SerializeField] float recoverTime;

    [SerializeField] int hp = 4;

    [SerializeField] 
    Color[] hpColors;

    MeshRenderer myRenderer;

    private void Start()
    {
        currentState = "Normal";
        nextState = currentState;
        SwitchState();

        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = hpColors[hp - 1];

    }
    private void Update()
    {
        if(currentState != nextState)
        {
            currentState = nextState;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void SwitchState()
    {
        StopAllCoroutines();
        StartCoroutine(currentState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        --hp;
        myRenderer.material.color = hpColors[hp - 1];
    }

    IEnumerator Normal()
    {
        while(hp > 2)
        {
            yield return new WaitForEndOfFrame();
        }
        nextState = "Critical";
        yield return new WaitForEndOfFrame();
        SwitchState();
    }

    IEnumerator Critical()
    {
        while(hp < 4)
        {
            yield return new WaitForSeconds(recoverTime);
            ++hp;
            myRenderer.material.color = hpColors[hp - 1];
        }
        nextState = "Normal";
        yield return new WaitForEndOfFrame();
        SwitchState();
    }


    /*public bool start;

    public int[] numbers = { };
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TimedMessage());
        StartCoroutine(StartTimer());

    }

    IEnumerator StartTimer()
    {
        
        while (!start) //one time trigger when bool is changed to true
        {
            //yield return new WaitForSeconds(3f);
            for (int i = 0; i < numbers.Length; i++)
            {
                Debug.Log(numbers[i]);
                yield return Timer();
            }
        }
        yield return new WaitForSeconds(3f);
        Debug.Log("Timer is done");
        
        Debug.Log("starting list array");
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
            yield return new WaitForSeconds(3f);
        }

    }
    
    IEnumerator TimedMessage()
    {
        yield return StartTimer();
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("message 1");
        }
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
    }
*/
}
