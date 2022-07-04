﻿using cards;
using System;
using drawphasemanager;
using System.Collections.Generic;
using System.Text;

namespace shared
{
    internal class Draw : AbstactEffect
    {
       public Draw() : base(effectName: "Draw", effectDescriprion: "When this card enters the battlefield, the owner draws a card", imageEffectURL: "effects/effect_draw.png")
        {

        }

        public override ActivationEvent ActivationEvent { get => ActivationEvent.POSITIONING; }


        public override void UseEffect(Player cardOwner, Player enemy, int boardPosition)
        {
            new DrawPhaseManagerImpl(cardOwner, enemy).drawWhitoutMana(cardOwner);
        }
    }
}
