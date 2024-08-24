using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public event Action OnAttack;
    public event Action OnGetHit;
    public event Action OnDie;
    public event Action OnWalk;
}
