using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fifteens
{  

    class Game
    {
        Value[,] Field;
        //private int FirstNumber;
        //private int SecondNumber;
        private int ZeroX;
        private int ZeroY;
        private int Side;
        public Dictionary<int, ValueCoordiante> Dictionary = new Dictionary<int, ValueCoordiante>();
        

        public Game(params int[] values)
        {
            bool zero = false;
            int count = 0;

            Side = (int)Math.Sqrt(values.Length);

            if (!CheckFieldCreation(values.Length))
            {
                throw new ArgumentException("Невозмжно создать поле такого размера.");
            }

            if (!CheckUniqueValues(values))
            {
                throw new ArgumentException("Встречаются одинаковые числа.");
            }
            if (CheckNegativeNumbers(values))
            {
                throw new ArgumentException("Есть отрицательные числа.");
            }
             
                    
            Field = new Value[Side, Side];
            

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {                    
                    if (values[count] == 0)
                    {
                        zero = true;                        
                        ZeroX = i;
                        ZeroY = j;                        
                        Field[i, j] = new Value(values[count]);
                        Dictionary.Add(count, new ValueCoordiante(i,j));
                        count++;
                    }
                    else
                    {                       
                        Field[i, j] = new Value(values[count]);
                        Dictionary.Add(count, new ValueCoordiante(i, j));
                        count++;
                    }   
         
                }
            }            
            if (!zero) throw new ArgumentException("В игре нет нуля.");
        }       

      
        public Value this[int index1, int index2]
        {
            get
            {
                return Field[ index1, index2 ];
            }
            set
            {
                Field[index1, index2] = value;
            }
        }


       private ValueCoordiante GetLocation(int value) 
       {
           
            if ((value < Math.Pow(value, 2) - 1)&&(value>0)) 
            {
                return Dictionary[value];
            } 
              else throw new ArgumentException("Числа " + value + " не существует в данной игре");
          
       }

       public void Shift(int value)
       {
           Print.PrintInfo(Field, Side);
           if (Dictionary[value] - Dictionary[0] == 1)
           {
               ValueCoordiante positionZero = Dictionary[0];
               this[Dictionary[0].X, Dictionary[0].Y] = new Value(value);
               this[Dictionary[value].X, Dictionary[value].Y] = new Value(0);
               Dictionary[0] = Dictionary[value];
               Dictionary[value] = positionZero;
               
           }
           else throw new ArgumentException("Невозможно передвинуть фишку");
           Print.PrintInfo(Field, Side);
       }      
           

        private bool CheckFieldCreation(int size)
        {
            return ((Math.Sqrt(size) % 1) == 0);
        }

        private bool CheckUniqueValues(int[] mass)
        {
            int temp;
            for (int i = 0; i < mass.Length; i++)
            {
                temp = mass[i];
                for (int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[j] == temp)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckNegativeNumbers(int[] values)
        {
            foreach (int i in values)
            {
                return values[i] < 0;
            }
             return true;
        }

        public static Game FromCSV(string file)
        {
            string[] Lines = File.ReadAllLines(file);
            int[] elem = new int[Lines.Length];           

            for (int i = 0; i < Lines.Length; i++)
            {                
                string s = Lines[i];
                string[] substring = s.Split(';');                
                elem[i] = Convert.ToInt32(substring[i]);                               
            }            
            return new Game(elem);
        }

   }   
}
 
