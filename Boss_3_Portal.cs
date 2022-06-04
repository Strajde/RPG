using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_Portal : Boss_3
{
    protected override void Death()
    {
        base.Death();
        Portal.instance.bossPortalOpen.SetTrigger("Open");
    }
}
