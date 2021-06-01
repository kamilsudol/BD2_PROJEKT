using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Punkt : INullable
{
    private double wspolrz_x1;

    private double wspolrz_y1;

     public Punkt(List<double> args)
    {
        m_Null = false;

        wspolrz_x1 = args[0];
        wspolrz_y1 = args[1];
    }

     public double WyznaczObwod()
     {
         return 0.0;
     }

     public double WyznaczPole()
     {
         return 0.0;
     }

    public override string ToString()
    {
        string returning_str = "Punkt o wspolrzednych (" + this.wspolrz_x1.ToString()
                + ", " + this.wspolrz_y1.ToString() + ").";
        return returning_str;
    }

    public bool IsNull
    {
        get
        {
            // Put your code here
            return m_Null;
        }
    }

    public static Punkt Null
    {
        get
        {
            Punkt h = new Punkt();
            h.m_Null = true;
            return h;
        }
    }

    public static Punkt Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        string[] arguments = s.Value.Split("/".ToCharArray());

        if (arguments.Length != arguments_amount)
        {
            throw new ArgumentException("Niepoprawna liczba argumentów! (wymagane " + arguments_amount.ToString() + ")");
        }

        List<double> tmp = new List<double>();

        try
        {
            foreach (var x in arguments)
            {
                tmp.Add(double.Parse(x));
            }
        }
        catch
        {
            throw new ArgumentException("Niepoprawny typ danych!");
        }
        Punkt u = new Punkt(tmp);
        // Put your code here
        return u;
    }

    // This is a place-holder field member
    public static int arguments_amount = 2;
    // Private member
    private bool m_Null;
}


