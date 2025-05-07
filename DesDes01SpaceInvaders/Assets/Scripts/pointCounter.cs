using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointCounter : MonoBehaviour
{
    [SerializeField] PointHUD pointHUD;


    public void AddPoints(int amount)
    {
        pointHUD.Points += amount;
    }
   
}
