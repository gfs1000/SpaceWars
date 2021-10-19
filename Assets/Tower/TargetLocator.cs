using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Enemymover>().transform;
    }

    // Update is called once per frame 
    void Update()
    {
        aimWeapon();
    }

    void aimWeapon()
    {
        weapon.LookAt(target);
    }
}
