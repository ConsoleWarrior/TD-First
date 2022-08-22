using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaubica : Cannon
{
    public override IEnumerator Fire()
    {
        isshoot = true;

        GameObject b = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<Projectile>().target = target;
        yield return new WaitForSeconds(firespeed*10);
        isshoot = false;
    }
}
