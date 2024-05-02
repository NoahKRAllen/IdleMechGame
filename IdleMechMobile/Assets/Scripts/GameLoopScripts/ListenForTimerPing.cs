using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class ListenForTimerPing : MonoBehaviour
{
    private Animator animator;

    private static readonly int PingTrigger = Animator.StringToHash("PingTrigger");

    // Start is called before the first frame update
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        // TimeCycleManager.Instance.OnTimeCycleOver.AddListener(AcceptTimerPing);
        
    }

    void AcceptTimerPing()
    {
        // tell animator that timer ping happened
        animator.SetTrigger(PingTrigger);
    }

}
