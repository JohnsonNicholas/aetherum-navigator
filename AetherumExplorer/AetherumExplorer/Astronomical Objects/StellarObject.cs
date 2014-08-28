using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This class contains details of a star
    /// </summary>
    public class StellarObject
    {
       //member functions 
       /// <summary>
       /// The mass of the object.
       /// </summary>
       public double stellarMass {get; set; }

       /// <summary>
       /// Name of the object.
       /// </summary>
       public string stellarName {get; set; }

       /// <summary>
       /// The type of the object.
       /// </summary>
       public StarType stellarType {get; set; }

       /// <summary>
       /// Brightness of the object.
       /// </summary>
       public double brightness { get; set; }

       /// <summary>
       /// Age of the object.
       /// </summary>
       public double age { get; set; }

       /// <summary>
       /// The GUID.
       /// </summary>
       public string ident { get; private set; }

       /// <summary>
       /// Tracks if this star is a flare star.
       /// </summary>
       public bool isFlareStar = false;

       public override bool Equals(object obj)
       {
           if (obj == null)
               return false;
           
           StellarObject p = obj as StellarObject;
           if ((Object)p == null) return false; // if the cast fails, return false

           if (this.ident == p.ident)
               return true;

           return false;
       }

       public override int GetHashCode()
       {
           return base.GetHashCode();
       }

       /// <summary>
       /// This is a base consturctor
       /// </summary>
       public StellarObject()
       {
           this.stellarType = SOOpCode.None;
           this.ident = Guid.NewGuid().ToString();
       }

       /// <summary>
       /// Copy constructor.
       /// </summary>
       /// <param name="s">Object being copied.</param>
       public StellarObject(StellarObject s)
       {
           this.age = s.age;
           this.stellarType = s.stellarType;
           this.isFlareStar = s.isFlareStar;
           this.brightness = s.brightness;
           this.stellarMass = s.stellarMass;
           this.stellarName = s.stellarName;
           this.ident = s.ident;
       }

       /// <summary>
       /// This constructor is for ones where we know the StarOpCode
       /// </summary>
       /// <param name="c">The OpCode (what type of system it is)</param>
       public StellarObject(SOOpCode c)
       {
           this.stellarType = c;
           this.ident = Guid.NewGuid().ToString();
       }

       public StellarObject(SOOpCode c, string n)
       {
           this.stellarType = c;
           this.stellarName = n;
           this.ident = Guid.NewGuid().ToString();
       }

       /// <summary>
       /// This constructor is for provided StarOpCode + flareStar
       /// </summary>
       /// <param name="c">The OpCode (what type of system it is)</param>
       /// <param name="flareStar">Whether or not the object is a flare star</param>
       public StellarObject(SOOpCode c, bool flareStar)
       {
           this.stellarType = c;
           this.isFlareStar = flareStar;
           this.ident = Guid.NewGuid().ToString();
       }

       /// <summary>
       /// This returns the inner limit of the planetary generation radius
       /// </summary>
       /// <returns>The radius in AU</returns>
       public double calcInnerLimit()
       {
           if ((.1 * this.stellarMass) > (.01 * Math.Sqrt(this.brightness)))
               return .1 * this.stellarMass;
           else
               return .01 * Math.Sqrt(this.brightness);
       }
      
       /// <summary>
       /// This returns the outer limit of the planetary generation radius
       /// </summary>
       /// <returns>The radius in AU</returns>
       public double calcOuterLimit()
       {
           return 40 * this.stellarMass;
       }

       /// <summary>
       /// This sets the name of the object.
       /// </summary>
       /// <param name="name">The object name</param>
       public void setObjectName(string name)
       {
           this.stellarName = name;
       }

       /// <summary>
       /// Function describing the stellar object.
       /// </summary>
       /// <returns>A string describing the object</returns>
       public override string ToString()
       {
           string str = "";
           str = "Stellar Object: " + stellarName + " type: " + stellarType;
           str = str + " with brightness: " + brightness + " and solar mass: ";
           str = str + stellarMass;

           if (isFlareStar)
               str = str + " and is a flare star.";

           return str;
       }

    }
}
