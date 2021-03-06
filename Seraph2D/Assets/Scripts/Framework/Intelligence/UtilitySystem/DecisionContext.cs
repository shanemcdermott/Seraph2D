﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Intelligence.UtilitySystem
{

   [System.Serializable]
    public class DecisionContext
    {
        /*What are you trying to do?*/
        public int decisionId;

        /*Who is asking?*/
        public GameObject intelObject;

        //Optional target
        public GameObject targetObject;

        public DecisionContext(int decisionIdentifier, GameObject intelligenceController, GameObject targetObject)
        {
            this.decisionId = decisionIdentifier;
            this.intelObject= intelligenceController;
            this.targetObject = targetObject;
        }

        public GameObject GetIntelligence()
        {
            return intelObject;
        }

        public virtual float GetBonusFactor(DecisionContext lastDecision)
        {
            if (lastDecision.decisionId == decisionId)
                return 0.5f;
            else
                return 1f;
        }
    }

}