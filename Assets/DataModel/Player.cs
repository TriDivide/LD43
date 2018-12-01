using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player  {

    public enum ClassType {
        Fighter,
        Defender,
        Magician
    }

    ClassType playerClass;

    float health = 100f;
    float magic = 100f;
    List<System.Object> powerUps = new List<System.Object>();
    float attackStat = 10f;
    float defenceStat = 10f;
    float magicStat = 10f;
    List<System.Object> invenvory = new List<System.Object>();
    String name = "";

   
     



    
    
}
