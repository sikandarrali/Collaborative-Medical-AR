using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestAccessButtons : MonoBehaviour
{
    public static bool isAccepted;

    public static bool OnClick_AcceptRequest()
    {
        return isAccepted = true;
    }

    public static bool OnClick_RejectRequest()
    {
        return isAccepted = false;
    }
}
