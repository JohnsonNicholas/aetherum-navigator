using System;
using System.Collections.Generic;

using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This class contains the reference tables this program uses for lookup.
    /// </summary>
    public static class StellarReference
    {
        //**********************static reference
        /// <summary>
        /// The distance that "Close orbital" stars orbit at. It is in AU.
        /// </summary>
        public static double closeOrbital = .008;

        public static DiceTreeNode stellarMassTree;

        //****************************************Table Members
        private static Dictionary<int, int> numberStarsTable = new Dictionary<int, int>()
        {
            {2, 3}, {3, 3}, {4, 1}, {5, 1}, {6, 1}, {7, 1},
            {8, 2}, {9, 2}, {10, 2}, {11, 2}, {12, 4}

        };

        public static AstroObjectType[] bonusAstronomicalObject = new AstroObjectType[10]{ 
            AstroObjectType.BlackHole, AstroObjectType.Pulsar, AstroObjectType.TypeFGiant,
            AstroObjectType.WhiteDwarf, AstroObjectType.RedGiant,
            AstroObjectType.TypeOGiant, AstroObjectType.TypeBGiant, AstroObjectType.Supergiant,
            AstroObjectType.NeutronStar, AstroObjectType.Anomaly
        };

        //****************************************Constructors
        /// <summary>
        /// Static Constructor. Used to create our objects.
        /// </summary>
        static StellarReference()
        {
            #region StellarMassTree
            stellarMassTree.SetRange(3, 3,   DiceTreeBase.Init(3, 2.00),
                                             DiceTreeBase.Init(11, 1.90));
            stellarMassTree.SetRange(4, 4,   DiceTreeBase.Init(3, 1.80),
                                             DiceTreeBase.Init(9, 1.70),
                                             DiceTreeBase.Init(12, 1.60));
            stellarMassTree.SetRange(5, 5,   DiceTreeBase.Init(3, 1.50),
                                             DiceTreeBase.Init(8, 1.45));
            stellarMassTree.SetRange(6, 6,   DiceTreeBase.Init(3, 1.30),
                                             DiceTreeBase.Init(8, 1.25),
                                             DiceTreeBase.Init(10, 1.20),
                                             DiceTreeBase.Init(11, 1.15),
                                             DiceTreeBase.Init(13, 1.10));
            stellarMassTree.SetRange(7, 7,   DiceTreeBase.Init(3, 1.05),
                                             DiceTreeBase.Init(8, 1.00),
                                             DiceTreeBase.Init(10, .95),
                                             DiceTreeBase.Init(11, .90),
                                             DiceTreeBase.Init(13, .85));
            stellarMassTree.SetRange(8, 8,   DiceTreeBase.Init(3, .80),
                                             DiceTreeBase.Init(8, .75),
                                             DiceTreeBase.Init(10, .70),
                                             DiceTreeBase.Init(11, .65),
                                             DiceTreeBase.Init(13, .60));
            stellarMassTree.SetRange(9, 9,   DiceTreeBase.Init(3, .55),
                                             DiceTreeBase.Init(9, .50),
                                             DiceTreeBase.Init(12, .45));
            stellarMassTree.SetRange(10, 10, DiceTreeBase.Init(3, .40),
                                             DiceTreeBase.Init(9, .35),
                                             DiceTreeBase.Init(12, .30));
            stellarMassTree.SetRange(11, 11, DiceTreeBase.Init(3, .25));
            stellarMassTree.SetRange(12, 12, DiceTreeBase.Init(3, .20));
            stellarMassTree.SetRange(13, 13, DiceTreeBase.Init(3, .15));
            stellarMassTree.SetRange(14, 18, DiceTreeBase.Init(3, .10));
            #endregion

        }

        //****************************************Functions
        /// <summary>
        /// Returns the entry from the dice roll table.
        /// </summary>
        /// <param name="roll">The dice roll.</param>
        /// <returns>The entry from the dice roll table</returns>
        public static int getNumberOfStars(int roll)
        {
            if (roll < 2 || roll > 12)
                throw new ArgumentException("This roll is out of bounds.");

            return numberStarsTable[roll];
        }

        /// <summary>
        /// This function converts the astronomical object to mass.
        /// </summary>
        /// <param name="aType">The object</param>
        /// <returns>the mass of the type</returns>
        public static double convBonusAstroObjectToMass(AstroObjectType aType, Dice d)
        {
            switch (aType)
            {
                case AstroObjectType.BlackHole:
                    return new RangePair(5.0, 10.0).RollInRange(d);
                case AstroObjectType.Pulsar:
                    return new RangePair(1.4, 5.0).RollInRange(d);
                case AstroObjectType.TypeFGiant:
                    return new RangePair(2.0, 5.0).RollInRange(d);
                case AstroObjectType.WhiteDwarf:
                    return new RangePair(.15, 1.4).RollInRange(d);
                case AstroObjectType.RedGiant:
                    return new RangePair(.5, 8).RollInRange(d);
                case AstroObjectType.TypeOGiant:
                    return new RangePair(5.0, 50.0).RollInRange(d);
                case AstroObjectType.TypeBGiant:
                    return new RangePair(4.0, 10.0).RollInRange(d);
                case AstroObjectType.Supergiant:
                    return new RangePair(25.0, 1000.0).RollInRange(d);
                case AstroObjectType.NeutronStar:
                    return new RangePair(1.4, 5.0).RollInRange(d);
                case AstroObjectType.Anomaly:
                    return 0;
                default:
                    return new RangePair(0.1, 2.0).RollInRange(d);
            }
        }


        /// <summary>
        /// This function converts the astronomical object to mass.
        /// </summary>
        /// <param name="aType">The object</param>
        /// <returns>the mass of the type</returns>
        public static double convBonusAstroObjectToAge(AstroObjectType aType, Dice d)
        {
            switch (aType)
            {
                case AstroObjectType.BlackHole:
                    return new RangePair(5.0, 10.0).RollInRange(d);
                case AstroObjectType.Pulsar:
                    return new RangePair(1.4, 5.0).RollInRange(d);
                case AstroObjectType.TypeFGiant:
                    return new RangePair(2.0, 5.0).RollInRange(d);
                case AstroObjectType.WhiteDwarf:
                    return new RangePair(.15, 1.4).RollInRange(d);
                case AstroObjectType.RedGiant:
                    return new RangePair(.5, 8).RollInRange(d);
                case AstroObjectType.TypeOGiant:
                    return new RangePair(5.0, 50.0).RollInRange(d);
                case AstroObjectType.TypeBGiant:
                    return new RangePair(4.0, 10.0).RollInRange(d);
                case AstroObjectType.Supergiant:
                    return new RangePair(25.0, 1000.0).RollInRange(d);
                case AstroObjectType.NeutronStar:
                    return new RangePair(1.4, 5.0).RollInRange(d);
                case AstroObjectType.Anomaly:
                    return 0;
                default:
                    return new RangePair(0.1, 2.0).RollInRange(d);
            }
        }


        /// <summary>
        /// This gets the age of the system
        /// </summary>
        /// <param name="ourDice">The dice object</param>
        /// <returns>System age</returns>
        public static double genSystemAge(Dice ourDice)
        {
            //get first roll
            int roll;
            roll = ourDice.gurpsRoll();

            if (roll == 3)
                return 0.01;
            if (roll >= 4 && roll <= 6)
                return (.1 + (ourDice.rng(1, 6, -1) * .3) + (ourDice.rng(1, 6, -1) * .05));
            if (roll >= 7 && roll <= 10)
                return (2 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));
            if (roll >= 11 && roll <= 14)
                return (5.6 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));
            if (roll >= 15 && roll <= 17)
                return (8 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));
            if (roll == 18)
                return (10 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));

            return 13.8;
        }
   
        //******************* Stellar spacing issues.
        /// <summary>
        /// This generates a close orbital distance.
        /// </summary>
        /// <param name="dist">The pre-distance of the star</param>
        /// <param name="d">The dice</param>
        /// <returns>The generated distance</returns>
        public static double genCloseOrbitalDist(double dist, Dice d)
        {
            int roll = d.rng(2, 6, -2);
            
            if (roll > 0)
                return (10 * roll) + dist;
            else
                return StellarReference.closeOrbital + dist;
        }

        /// <summary>
        /// This generates a furthest orbital distance.
        /// </summary>
        /// <param name="dist">The pre-distance of the star</param>
        /// <param name="d">The dice</param>
        /// <returns>The generated distance</returns>
        public static double genFartherOrbitalDist(double dist, Dice d)
        {
            return (1000 * d.rng(2, 6)) + dist;
        }

        /// <summary>
        /// This determines the distance of the object
        /// </summary>
        /// <param name="dist">The pre-distance of the star</param>
        /// <param name="d">The dice</param>
        /// <returns>The generated distance</returns>
        public static double genOrbitalSeperation(double dist, Dice d)
        {
            int roll = d.rng(1, 6);
            if (roll <= 3) 
                return genCloseOrbitalDist(dist, d);
            else 
                return genFartherOrbitalDist(dist, d);
        }

        /// <summary>
        /// This checks if a proposed orbit is within a forbidden zone, given the orbit of a second star
        /// </summary>
        /// <param name="starOrbit">Stellar Orbit</param>
        /// <param name="testOrbit">Test Orbit</param>
        /// <returns>true if within the forbidden zone, false without</returns>
        public static bool isWithinForbiddenZone(double starOrbit, double testOrbit)
        {
            if (testOrbit >= (starOrbit / 3) || testOrbit <= (3 * starOrbit))
                return true;
            else
                return false;
        }
    }
}
