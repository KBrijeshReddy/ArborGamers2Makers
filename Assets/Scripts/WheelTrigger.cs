using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class WheelTrigger : MonoBehaviour
{
    public WheelBehaviour wheelBehaviour;
    public bool opposite;

    public void RunRoll(bool isAbove)
    {
        if (opposite)
        {
            wheelBehaviour.Roll(!isAbove);
        }
        else
        {
            wheelBehaviour.Roll(isAbove);
        }
    }
}
