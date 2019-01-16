using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopReview
{
    public class Die
    {
        //create an new instance of the math class Random
        //this instance (occurance, object) will be shared by each
        // instance of the class Die
        //this instance will be created when the first instance
        //of Die is created
        private static Random _rnd = new Random();
        //this is  the definition of object
        //it is a conceptual view of the data
        // that will be held by physical
        // instance (object) of this class

        // data Members
        //is  an internal private data storage item
        //private data memebers cannot be reached directly by the user

        private int _Sides;
        private string _Color;
        private int _FaceValue;


        // Properties
        // a property is an external interface between the user
        //and a single piece of data within the instance
        // a property has two abilities
        //  a) the ability to assign a value to the internal
        // data memeber
        //   b)return a internal data memeber value to the use


        // Fully Implemented Property
        public int Sides
        {
            get
            {
                //take internal values and returns it to the user
                return _Sides;
            }
            set
            {
                //take the supplied user value and places it into
                //the internal private data member
                // the incoming piece of data is placed into a special
                // variable that is called: value
                //optionally you may place validation on the incoming value

                if (value >= 6 && value <= 20)
                {
                    _Sides = value;
                    Roll();  // consider placing this method within the property
                    //if the set is public and not private
                    //if private then the method SetSides solve this problem

                }
                else
                {
                    throw new Exception("Die cannot be" + value.ToString() + "sides. Die must have between 6 and 20 sides.");
                }

            }
        }

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                // (value == null) this will fail for an empty string
                //(value == "") this will fail for a null value
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Color has no value.");
                }
                else
                {
                    _Color = value;
                }
            }
        }

        //another versio of Sides using a private set and auto implemented property
        //in this version you would need to code a method like SetSides()
        public int Sides {get; private set;}

        //Auto Implemented Property
        //Public
        // it  has a data type
        //it has a name
        //it Does not have an internal data member that you can DIRECTLY access
        //the system will create, internally, a data storage area of the appropriate
        // datatype and manage the area
        // the only way to access the data of an  Auto Impelemented Property is via the property
        //Usually use when there is no need for any internal validation or other property logic
        public int FaceValue { get; set; }


        // Contructors
        //optional; if not suplied the system default constructor is used
        //which will assign a system value to each data member/auto
        //implement property according to it's datatype

        // you can have  any number of constructors withiun your class
        //as soon as you consructor, your program is responsible for
        // all constructors

        //Syntax public classname([list of parameters]) { ......}

        //Typical Constructors
        //Default Constructor
        //this is similiar to the system default constructor
        public Die()
        {
            //you could leave this constructor empty and the system would 
            //access the normal default value to your data members and 
            //auto implemented properties
            //you can directly access a private data member any place within your class
            _Sides = 6;

            // you can access any property any place within your class
            Color = "white";

            // you could use a class method to generate a value for 
            // a data member/auto 
        }

        //Greedy Constructur
        //typical has a parameter for each data member and auto property
        //within your class
        //parameter order is not important
        //this constructor allows the outside user to create and assign their
        //own values to the data members/auto properties attime of
        //instance creation
        public Die(int sides, string color)
        {
            //since this data comming from outside source , it is best
            //to use your property to save the value; specially if the
            // property has validation
            Sides = sides;
            Color = color;
            Roll();
        }



        // Behaviours (methods)

        //these are actions that the class can perform
        //the actions may or may not alter data members/auto values
        //the actions could simply take a value(s) from the user
        // and perform some logic operations against the values

        //can be public or private
        //create a method that allows the user to change the number of
        //sides on a die
        public void SetSides(int sides)
        {
            if (sides >= 6 && sides <= 20)
            {
                Sides = sides;
            }
            else
            {
                //optionally
                // a) throw a new exeption
                throw new Exception("Invalid value for sides");
                // b) set _Sides to a default value
                //Sides = 6;

            }
            Roll();
        }

        public void Roll()
        {
            // no parameters are required for this method since it will be 
            //using the internal data values to complete its functionality

            //randomly generate a value for the die depending on the maximum
            //Sides 
            FaceValue = _rnd.Next(1, Sides + 1);
        }

    }
}

