using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAdministrator : MonoBehaviour
{
    [SerializeField] public GameObject LoseMenu;
    [SerializeField] public  GameObject WinMenu;

    public static UIAdministrator Menu;
    private void Awake()
    {
        Menu = this;
    }
}
