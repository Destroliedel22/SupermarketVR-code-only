using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRUIButtonClick : MonoBehaviour
{
    [SerializeField]
    private Button button;

    public void VRUnityUIButtonInvoke()
    {
        button.onClick.Invoke();
    }
}
