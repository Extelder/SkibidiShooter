using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTelegramm : MonoBehaviour
{

    public void OpenTG()
    {
        Application.ExternalEval("window.open(\"" + "https://t.me/infinityrequiemstudio" + "\")");
    }
}