using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_0_Portal : Boss_0
{
    protected override void Death()
    {
        base.Death();
        Portal.instance.bossPortalOpen.SetTrigger("Open");
    }
}
