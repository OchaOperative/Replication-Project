using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracking : MonoBehaviour
{

    [SerializeField] private float rotateSpeed;

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject weapon;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 targetDirection = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles;

        Quaternion bodyRotation = Quaternion.Euler(0f, targetDirection.y, 0f);

        float weaponRotationY = targetDirection.y - transform.rotation.y;

        Quaternion weaponRotation = Quaternion.Euler(targetDirection.x, weaponRotationY, 0f);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, bodyRotation, rotateSpeed * Time.deltaTime);

        weapon.transform.localRotation = Quaternion.RotateTowards(weapon.transform.localRotation, weaponRotation, rotateSpeed * Time.deltaTime);
    }
}
