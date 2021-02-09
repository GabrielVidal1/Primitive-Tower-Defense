using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    public bool classicTurret;

    void Update()
    {
        if (classicTurret)
        {
            AimingSystem aM = GetComponent<AimingSystem>();

            if (aM.ClosestEnemy() != null)
                aM.SummonBullet();
        }
    }
}