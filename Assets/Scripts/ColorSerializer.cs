using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

public class ColorSerializer
{
    private const byte Code = 28;
    
    public static void RegisterType()
    {
        PhotonPeer.RegisterType(typeof(Color), Code, Serialize, Deserialize);
    }

    private static object Deserialize(byte[] data)
    {
        var result = new Color();

        for (int i = 0; i < 4; i++)
            result[i] = data[i] / 255f;
        
        return result;
    }

    private static byte[] Serialize(object obj)
    {
        var color = (Color)obj;
        var result = new byte[4];
        for (int i = 0; i < 4; i++)
            result[i] = (byte) (color[i] * 255);
        
        return result;
    }
}
