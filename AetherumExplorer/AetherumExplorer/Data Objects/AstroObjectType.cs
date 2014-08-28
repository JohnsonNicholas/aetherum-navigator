using System;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This enum categorizes stellar object generally by spectra but in a few cases by what they are
    /// </summary>
    public enum AstroObjectType
    {
        //Formation stars!
        [StringValue("T Tauri")]
        TTauri, 

        [StringValue("Herbig Ae/Be")]
        HerbigAeBe,

        //M class stars!
        M7, 
        M6,
        M5,
        M4, 
        M3, 
        M2, 
        M1, 
        M0,

        //K class stars!
        K8,
        K6, 
        K5, 
        K4, 
        K2, 
        K0,

        //G class stars!
        G8,
        G6,
        G5,
        G4, 
        G2, 
        G1, 
        G0,

        //F class stars!
        F9,
        F8,
        F7,
        F6,
        F5,
        F4,
        F3,
        F2,
        F0,

        //A class stars!
        A9,
        A5,

        //Giant stars!
        TypeAGiant, 
        TypeBGiant, 
        TypeFGiant, 
        TypeOGiant,

        //Exotic star types!
        BrownDwarf, 
        WhiteDwarf, 
        Supergiant, 
        RedGiant,

        //Special things
        NeutronStar, 
        Pulsar, 
        BlackHole,
        Anomaly, 
        NoObject, 

        //Nebula listing
        InterstellarNebula, 
        PlanetaryDenseNebula, 
        ProtoStarNebula,

        //Catch all
        ZClassStar
    }
}
