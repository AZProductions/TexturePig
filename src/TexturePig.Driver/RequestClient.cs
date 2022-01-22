using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexturePig.Driver;
using TexturePig.Driver.Models;

namespace TexturePig.Driver
{
    public static class RequestClient
    {
        public static void Send(ResponseType Type, string? ID = null) => SerializeType(Type, ID);
        internal static void SerializeType(ResponseType Type, string? ID = null) 
        {
            switch (Type)
            {
                case ResponseType.Index:
                    IndexResponse(ID);
                    break;
                case ResponseType.Profile:
                    break;
                case ResponseType.Pack:
                    break;
            }
        }

        internal static void IndexResponse(string ID) 
        {
            
        }
    }
}
