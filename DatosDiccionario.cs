using System;
namespace InstantFood
{
    public class DatosDiccionario
    {
            private static readonly DatosDiccionario instance = new DatosDiccionario();
        
            public static DatosDiccionario Instance
            {
                get { return instance; }
            }

            public Dictionary<int, object> DiccionarioPlatillos { get; set; }

    }
}


