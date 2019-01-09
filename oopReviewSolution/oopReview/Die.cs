using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopReview
{
    public class Die
    {
        //this is  the definition of object
        //it is a conceptual view of the data
        // that will be held by physical
        // instance (object) of this class

        // data Members
        //is  an internal private data storage item
        //private data memebers cannot be reached directly by the user

        private int _Size;


        // Properties
        // a property is an external interface between the user
        //and a single piece of data within the instance
        // a property has two abilities
        //  a) the ability to assign a value to the internal
        // data memeber
        //   b)return a internal data memeber value to the use


        // Fully Implemented Property
        public int Size
        {
            get
            {
                //take internal values and returns it to the user
               return _Size;
            }
            set
            {
                //take the supplied user value and places it into
                //the internal private data member
                // the incoming piece of data is placed into a special
                // variable that is called: value
                _Size = value;
            }

        // Contructors


        // Behaviours (methods)
    }
}
