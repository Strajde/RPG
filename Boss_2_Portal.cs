using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2_Portal : Boss_2
{
    protected override void Death()
    {
        base.Death();
        Portal.instance.bossPortalOpen.SetTrigger("Open");
    }
}
