using System;

namespace Prototype
{
    interface IPrototype<U> 
    {
        public U Clone();
    }

    class Psina<T>:IPrototype<Psina<T>>
    {
        
        public int blohi = 120;
        public bool sluni = true;
        public T Zhratva { get; set; } = default;

        public Psina<T> Clone()
        {
            return (Psina<T>)this.MemberwiseClone(); 
            //var Zhratva = new Zhratva {gram };
           // 


          //  return new Psina<T>(blohi, sluni);
        }
    }

    class Pedigree
    {
        public Pedigree() : this(1000, "koshka", "oblozhka") { }
        
        public Pedigree(int gramm, string vkus, string someinfo)
        {
            this.gramm = gramm;
            this.vkus = vkus;
            this.someinfo = someinfo;
        }

        public int gramm;
        public string vkus;
        public string someinfo;

    }

    class Program
    {
        
    }

}
