using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public ShopKeeperState state = ShopKeeperState.Idle;

    private Animator anim = null;

    private void Start()
    {
        getRef();    
    }

    private void Update()
    {
        switch(state)
        {
            case ShopKeeperState.Idle:
                {
                    SetAnimState(0f, 0f, 0.5f);
                    break;
                }
            case ShopKeeperState.Wave:
                {
                    SetAnimState(1f, 1f, 0.5f);
                    break;
                }
            case ShopKeeperState.Sigh:
                {
                    SetAnimState(0f, 1f, 0.5f);
                    break;
                }
            case ShopKeeperState.LookingAround:
                {
                    SetAnimState(1f, 0.01f, 0.5f);
                    break;
                }
            default:
                {
                    SetAnimState(0f, 0f, 0.5f);
                    break;
                }
        }
    }

    public enum ShopKeeperState
    {
        Idle,
        Wave,
        Sigh,
        LookingAround
    }

    private void getRef()
    {
        anim = GetComponent<Animator>();
    }

    private void SetAnimState(float X, float Y, float transisiontime)
    {
        anim.SetFloat("blendX", X, transisiontime, Time.deltaTime);
        anim.SetFloat("blendY", Y, transisiontime, Time.deltaTime);
    }
}
