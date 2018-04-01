using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityInfoEvent<T> : UnityEvent<InfoEventArgs<T>>
{

}