using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public event Action OnSingleShot;
    public event Action OnBurstShot;
    public event Action OnDie;
    public event Action OnWalk;
}
