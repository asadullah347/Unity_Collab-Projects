using System;
using UnityEngine;

public static class MathUtils
{
    // public means it's global, and static means we can't do instantiate it. so no 'new MathUtils()' just 'MathUtils.Func(x)'
    // you don't really need this I am just making it so I can understand more stuff, and it might be handy later on.
    public static void RotateEuler(Vector3 direction)
    {
        float horizontal = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
    }
}

// not finished and not is use yet. ( will use for camera control.)