﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringDemo : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 10f, 0);
    }
}
