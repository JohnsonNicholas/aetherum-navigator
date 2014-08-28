using System;
using System.Collections.Generic;
using System.Text;

using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// List of possible settings that this program will be using.
    /// </summary>
    public enum PropertyName
    {
        /// <summary>
        /// This setting determines the stellar density, given in number of stars per 1000 cu ly.
        /// </summary>
        /// <remarks>This has a default density of .04 stars per 1000 cubic light years. 
        /// It can go as little as .001 and as high as .02.</remarks>
        [PropDefs(ValType.DoubleType, .001, .2, .04, 0)]
        StellarDensity,

        /// <summary>
        /// The size of the sector per side
        /// </summary>
        /// <remarks>The default value is 10 ly, but it can go as small as 1ly or as high as 100ly.</remarks>
        [PropDefs(ValType.IntegerType, 1,100,10,0)]
        SectorSizePerSide,

        /// <summary>
        /// Flag to determine what other objects are generated within the sector
        /// </summary>
        /// <remarks>This is a flag that tracks what generation options we use.</remarks>
        [PropDefs(ValType.EnumType, 0,0,0,0)]
        AdditionalGeneration,

        /// <summary>
        /// The minimum space between stars.
        /// </summary>
        /// <remarks>The default value is 1.1 ly, but it can go as small as 1 ly or as high as 10 ly.</remarks>
        [PropDefs(ValType.DoubleType,1,10,1.1,0)]
        MinimumStellarSeperation,

        /// <summary>
        /// Is this a 3D grid?
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        [PropDefs(ValType.BoolType,0,0,true,0)]
        Is3DGrid,

        /// <summary>
        /// The default prefix for the sector name
        /// </summary>
        /// <remarks>Defaults to GSC, max 7 characters</remarks>
        [PropDefs(ValType.StringType,0,0,"GSC",7)]
        DefaultSectorPrefix,

        /// <summary>
        /// The default prefix for a star/system name   
        /// </summary>
        /// <remarks>Defaults to ISC, max 7 characters</remarks>
        [PropDefs(ValType.StringType,0,0,"ISC",7)]
        DefaultStellarPrefix,

        /// <summary>
        /// The maximum number that the sector can be. IE GSXXXXX
        /// </summary>
        /// <remarks>Tracks the XXXXX number. Min is 10000, max is 10000000</remarks>
        [PropDefs(ValType.IntegerType,10000,10000000,50000, 0)]
        MaxSizeOfSectorCatalog,

        /// <summary>
        /// The maximum number that the system can be. IE ISCXXXXXXX
        /// </summary>
        /// <remarks>Tracks the XXXXX number. Min is 1000000, max is 1000000000000</remarks>
        [PropDefs(ValType.IntegerType, 1000000, 100000000000, 10000000, 0)]
        MaxSizeOfStellarCatalog,

        /// <summary>
        /// This setting contains how much detail for locations are used. 10 means .x, 100 means .xx and so on.
        /// </summary>
        /// <remarks>The default is 100, but can go from 1 to 10000</remarks>
        [PropDefs(ValType.IntegerType, 1, 10000, 100, 0)]
        LightYearResolutionFactor,

        /// <summary>
        /// This setting controls if the space opera override is on.
        /// </summary>
        /// <remarks>Defaults to false, true if enabled.</remarks>
        [PropDefs(ValType.BoolType,0,0,false,0)]
        AllowForSpaceOperaOverride,

        /// <summary>
        /// This setting is the amount of stars that should be replaced with a nebula.
        /// </summary>
        /// <remarks>The default value is .005%, but can go from 0% and 10%. This replaces the entire system.</remarks>
        [PropDefs(ValType.DoubleType,0,.1,.00005,0)]
        ThresholdForNebulaPlacement,

        /// <summary>
        /// The setting states the probablility that a generated nebula will be Interstellar
        /// </summary>
        /// <remarks>The default value is 80% (.8), but can go as small as 40% (.4) or as high as 99% (.99)</remarks>
        [PropDefs(ValType.DoubleType,.4,.99,.8,0)]
        InterstellarNebulaThreshold,

        /// <summary>
        /// The setting states the probability that a generated nebula will be a planetary nebula
        /// </summary>
        /// <remarks>The default value is 1% (.01), but can go small as .01%(.0001) or as high as 20% (.2)</remarks>
        [PropDefs(ValType.DoubleType, .0001, .2, .01, 0)]
        PlanetaryNebulaThreshold,

        /// <summary>
        /// This controls the multiplication factor for 2D grids compared to 3D.
        /// </summary>
        /// <remarks>The default value is 10, but can go between 1 and 100</remarks>
        [PropDefs(ValType.IntegerType, 1, 100, 10, 0)]
        TwoDMultiplication,

        /// <summary>
        /// This allows negative grid locations during sector generation
        /// </summary>
        /// <remarks>The default value is false.</remarks>
        [PropDefs(ValType.BoolType, 0,0, false, 0)]
        AllowNegativeGrid,

        /// <summary>
        /// This is the default prefix for a system
        /// </summary>
        /// <remarks>The default value is UNKS, but it can be up to 10 characters</remarks>
        [PropDefs(ValType.StringType,0,0,"UNKS",10)]
        DefaultSystemPrefix,

        /// <summary>
        /// This controls the maximum size of the system catalog
        /// </summary>
        /// <remarks>The default value is 100000, but can be between 1000 and 100000000</remarks>
        [PropDefs(ValType.IntegerType, 1000, 100000000, 100000, 0)]
        MaxSizeOfSystemCatalog,

        /// <summary>
        /// This controls if we should generate for a garden world. Trigger for a set of rules
        /// </summary>
        [PropDefs(ValType.BoolType,0,0,false,0)]
        FavorGardenWorldMass,

        /// <summary>
        /// This controls if we should use an alternate method to generate stellar mass.
        /// </summary>
        [PropDefs(ValType.BoolType, 0, 0, false, 0)] 
        AlternateHighMassGeneration,

        /// <summary>
        /// This controls the probability that the star is a unique object.
        /// </summary>
        /// <remarks>The default value is 1/6^4, but can go as little as 0 or as high as 1%</remarks>
        [PropDefs(ValType.DoubleType, 0, .01, .0007716, 0)]
        RareAstronomicalObjectProbability,

        /// <summary>
        /// This controls the minimum distance planetary orbits are placed
        /// </summary>
        /// <remarks>The default value .15 AU, but can become .10 and 1 AU</remarks>
        [PropDefs(ValType.DoubleType, .10,1,.15,0)]
        OrbitRangeMinAU,

        /// <summary>
        /// This controls the minimum radius the orbit is multiplied by to get the next orbit
        /// </summary>
        /// <remarks>The default value is *1.01, but it can between *1.01 and *1.7</remarks>
        [PropDefs(ValType.DoubleType, 1.01,1.7,1.01,0)]
        OrbitRangeMinRadius,

        /// <summary>
        /// This controls the maxmimum radius the orbit is multiplied by to get the next orbit
        /// </summary>
        /// <remarks>The default value is *2.11, but it can be betweeen *1.7 and *2.7</remarks>
        [PropDefs(ValType.DoubleType, 1.7, 2.7, 2.11, 0)]
        OrbitRangeMaxRadius
    }
}
