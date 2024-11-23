using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance; void Awake() { instance = this; }
    public Transform currentCheckpoint;
}
