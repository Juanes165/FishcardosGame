using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WinnerController : MonoBehaviour
{
   public static bool win;

   private void Start()
   {
      win = false;
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      win = true;
   }

}
